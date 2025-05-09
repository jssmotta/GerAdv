﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class InstanciaService(IOptions<AppSettings> appSettings, IInstanciaReader reader, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IInstanciaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<InstanciaResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Instancia: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Instancia-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<InstanciaResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBInstancia.SensivelCamposSqlX} 
                   FROM {DBInstancia.PTabelaNome} (NOLOCK)
                   ORDER BY {DBInstanciaDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBInstancia>(max);
        await foreach (var item in DBInstancia.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<InstanciaResponse>> Filter(Filters.FilterInstancia filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("Instancia: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<InstanciaResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBInstancia.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<InstanciaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Instancia: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new InstanciaResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        try
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            var keyCache = await reader.ReadStringAuditor(id, uri, oCnn);
            var result = await _cache.GetOrCreateAsync($"{uri}-Instancia-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Instancia - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<InstanciaResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<InstanciaResponse?> AddAndUpdate([FromBody] Models.Instancia regInstancia, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Instancia: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regInstancia == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regInstancia, this, processosReader, acaoReader, foroReader, tiporecursoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"Instancia: {validade}");
            }

            var saved = writer.Write(regInstancia, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<InstanciaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Instancia: URI inválida");
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

            var instancia = reader.Read(id, oCnn);
            if (instancia != null)
            {
                new DBInstancia().DeletarItem(instancia.Id, oCnn, null);
            }

            return instancia;
        });
    }

    public async Task<InstanciaResponse?> GetByName(string name, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Instancia: URI inválida");
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

            var cWhere = $"{DBInstanciaDicInfo.CampoNome} like '{name.PreparaParaSql()}'";
            var result = reader.Read(cWhere, oCnn);
            return result ?? new();
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterInstancia? filtro, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("Instancia: URI inválida");
        }

        var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
        var cacheKey = $"{uri}-Instancia-{max}-{cWhere.GetHashCode()}-GetListN";
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
            foreach (var item in DBInstancia.ListarN(cWhere, DBInstanciaDicInfo.CampoNome, Configuracoes.ConnectionByUri(uri), max: max))
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

    private static string WFiltro(Filters.FilterInstancia filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.LiminarPedida.IsEmpty() ? string.Empty : DBInstanciaDicInfo.LiminarPedidaSql(filtro.LiminarPedida);
        cWhere += filtro.Objeto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.ObjetoSql(filtro.Objeto);
        cWhere += filtro.StatusResultado == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.StatusResultadoSql(filtro.StatusResultado);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.LiminarResultado.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.LiminarResultadoSql(filtro.LiminarResultado);
        cWhere += filtro.NroProcesso.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.NroProcessoSql(filtro.NroProcesso);
        cWhere += filtro.Divisao == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.DivisaoSql(filtro.Divisao);
        cWhere += filtro.Comarca == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.ComarcaSql(filtro.Comarca);
        cWhere += filtro.SubDivisao == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.SubDivisaoSql(filtro.SubDivisao);
        cWhere += filtro.Acao == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.AcaoSql(filtro.Acao);
        cWhere += filtro.Foro == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.ForoSql(filtro.Foro);
        cWhere += filtro.TipoRecurso == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.TipoRecursoSql(filtro.TipoRecurso);
        cWhere += filtro.ZKey.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.ZKeySql(filtro.ZKey);
        cWhere += filtro.ZKeyQuem == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.ZKeyQuemSql(filtro.ZKeyQuem);
        cWhere += filtro.NroAntigo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.NroAntigoSql(filtro.NroAntigo);
        cWhere += filtro.AccessCode.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.AccessCodeSql(filtro.AccessCode);
        cWhere += filtro.Julgador == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.JulgadorSql(filtro.Julgador);
        cWhere += filtro.ZKeyIA.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.ZKeyIASql(filtro.ZKeyIA);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBInstanciaDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}