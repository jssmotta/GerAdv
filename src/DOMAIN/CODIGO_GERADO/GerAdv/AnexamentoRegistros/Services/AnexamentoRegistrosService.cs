﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AnexamentoRegistrosService(IOptions<AppSettings> appSettings, IAnexamentoRegistrosReader reader, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IAnexamentoRegistrosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<AnexamentoRegistrosResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AnexamentoRegistros: URI inválida");
            }
        }

        var cacheKey = $"{uri}-AnexamentoRegistros-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AnexamentoRegistrosResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBAnexamentoRegistros.SensivelCamposSqlX} 
                   FROM {DBAnexamentoRegistros.PTabelaNome} (NOLOCK)
                   ORDER BY {DBAnexamentoRegistrosDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBAnexamentoRegistros>(max);
        await foreach (var item in DBAnexamentoRegistros.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<AnexamentoRegistrosResponse>> Filter(Filters.FilterAnexamentoRegistros filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("AnexamentoRegistros: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<AnexamentoRegistrosResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBAnexamentoRegistros.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<AnexamentoRegistrosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AnexamentoRegistros: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new AnexamentoRegistrosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-AnexamentoRegistros-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"AnexamentoRegistros - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<AnexamentoRegistrosResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<AnexamentoRegistrosResponse?> AddAndUpdate([FromBody] Models.AnexamentoRegistros regAnexamentoRegistros, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AnexamentoRegistros: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAnexamentoRegistros == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAnexamentoRegistros, this, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"AnexamentoRegistros: {validade}");
            }

            var saved = writer.Write(regAnexamentoRegistros, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<AnexamentoRegistrosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AnexamentoRegistros: URI inválida");
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

            var anexamentoregistros = reader.Read(id, oCnn);
            if (anexamentoregistros != null)
            {
                new DBAnexamentoRegistros().DeletarItem(anexamentoregistros.Id, oCnn, null);
            }

            return anexamentoregistros;
        });
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

    private static string WFiltro(Filters.FilterAnexamentoRegistros filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.Cliente == -2147483648 ? string.Empty : DBAnexamentoRegistrosDicInfo.ClienteSql(filtro.Cliente);
        cWhere += filtro.GUIDReg.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAnexamentoRegistrosDicInfo.GUIDRegSql(filtro.GUIDReg);
        cWhere += filtro.CodigoReg == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAnexamentoRegistrosDicInfo.CodigoRegSql(filtro.CodigoReg);
        cWhere += filtro.IDReg == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAnexamentoRegistrosDicInfo.IDRegSql(filtro.IDReg);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAnexamentoRegistrosDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}