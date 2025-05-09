﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class StatusBiuService(IOptions<AppSettings> appSettings, IStatusBiuReader reader, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, HybridCache cache) : IStatusBiuService, IDisposable
{
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<StatusBiuResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("StatusBiu: URI inválida");
            }
        }

        var cacheKey = $"{uri}-StatusBiu-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<StatusBiuResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBStatusBiu.SensivelCamposSqlX} 
                   FROM {DBStatusBiu.PTabelaNome} (NOLOCK)
                   ORDER BY {DBStatusBiuDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBStatusBiu>(max);
        await foreach (var item in DBStatusBiu.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
        {
            if (item != null)
            {
                lista.Add(item);
                if (lista.Count % 100 == 0)
                    token.ThrowIfCancellationRequested();
            }
        }

        return lista.Count > 0 ? lista.Select(item => reader.Read(item)!).Where(item => item != null).ToList() : [];
    }

    public async Task<IEnumerable<StatusBiuResponse>> Filter(Filters.FilterStatusBiu filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("StatusBiu: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<StatusBiuResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBStatusBiu.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<StatusBiuResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("StatusBiu: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new StatusBiuResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-StatusBiu-GetById-{id}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"StatusBiu - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<StatusBiuResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            return oCnn == null ? null : reader.Read(id, oCnn);
        });
    }

    public async Task<StatusBiuResponse?> AddAndUpdate([FromBody] Models.StatusBiu regStatusBiu, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("StatusBiu: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regStatusBiu == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regStatusBiu, this, tipostatusbiuReader, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"StatusBiu: {validade}");
            }

            var saved = writer.Write(regStatusBiu, oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<StatusBiuResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("StatusBiu: URI inválida");
            }
        }

        return await Task.Run(() =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var statusbiu = reader.Read(id, oCnn);
            if (statusbiu != null)
            {
                new DBStatusBiu().DeletarItem(statusbiu.Id, oCnn, null);
            }

            return statusbiu;
        });
    }

    public async Task<StatusBiuResponse?> GetByName(string name, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("StatusBiu: URI inválida");
            }
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var cWhere = $"{DBStatusBiuDicInfo.CampoNome} like '{name.PreparaParaSql()}'";
            var result = reader.Read(cWhere, oCnn);
            return result ?? new();
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusBiu? filtro, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("StatusBiu: URI inválida");
        }

        var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
        var cacheKey = $"{uri}-StatusBiu-{max}-{cWhere.GetHashCode()}-GetListN";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataListNAsync(max, uri, cWhere, cancel), entryOptions, cancellationToken: token) ?? [];
    }

    private static async Task<IEnumerable<NomeID>> GetDataListNAsync(int max, string uri, string cWhere, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            var result = new List<NomeID>(max);
            foreach (var item in DBStatusBiu.ListarN(cWhere, DBStatusBiuDicInfo.CampoNome, Configuracoes.ConnectionByUri(uri), max: max))
            {
                if (token.IsCancellationRequested)
                    break;
                if (item?.FNome != null)
                {
                    result.Add(new NomeID { Nome = item.FNome, ID = item.ID });
                }
            }

            return result;
        }, token);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        if (disposing)
        {
        //_cache?.Dispose();
        }

        _disposed = true;
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(GetType().Name);
        }
    }

    private static string WFiltro(Filters.FilterStatusBiu filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.Nome.IsEmpty() ? string.Empty : DBStatusBiuDicInfo.NomeSql(filtro.Nome);
        cWhere += filtro.TipoStatusBiu == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBStatusBiuDicInfo.TipoStatusBiuSql(filtro.TipoStatusBiu);
        cWhere += filtro.Operador == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBStatusBiuDicInfo.OperadorSql(filtro.Operador);
        cWhere += filtro.Icone == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBStatusBiuDicInfo.IconeSql(filtro.Icone);
        return cWhere;
    }
}