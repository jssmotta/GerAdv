#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class GUTPeriodicidadeStatusService(IOptions<AppSettings> appSettings, IGUTPeriodicidadeStatusReader reader, IGUTPeriodicidadeStatusValidation validation, IGUTPeriodicidadeStatusWriter writer, IGUTAtividadesReader gutatividadesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IGUTPeriodicidadeStatusService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<GUTPeriodicidadeStatusResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("GUTPeriodicidadeStatus: URI inválida");
            }
        }

        var cacheKey = $"{uri}-GUTPeriodicidadeStatus-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<GUTPeriodicidadeStatusResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBGUTPeriodicidadeStatus.SensivelCamposSqlX} 
                   FROM {DBGUTPeriodicidadeStatus.PTabelaNome} (NOLOCK)
                   ORDER BY {DBGUTPeriodicidadeStatusDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBGUTPeriodicidadeStatus>(max);
        await foreach (var item in DBGUTPeriodicidadeStatus.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<GUTPeriodicidadeStatusResponse>> Filter(Filters.FilterGUTPeriodicidadeStatus filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("GUTPeriodicidadeStatus: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<GUTPeriodicidadeStatusResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBGUTPeriodicidadeStatus.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<GUTPeriodicidadeStatusResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("GUTPeriodicidadeStatus: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new GUTPeriodicidadeStatusResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-GUTPeriodicidadeStatus-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"GUTPeriodicidadeStatus - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<GUTPeriodicidadeStatusResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<GUTPeriodicidadeStatusResponse?> AddAndUpdate([FromBody] Models.GUTPeriodicidadeStatus regGUTPeriodicidadeStatus, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("GUTPeriodicidadeStatus: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regGUTPeriodicidadeStatus == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regGUTPeriodicidadeStatus, this, gutatividadesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"GUTPeriodicidadeStatus: {validade}");
            }

            var saved = writer.Write(regGUTPeriodicidadeStatus, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<GUTPeriodicidadeStatusResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("GUTPeriodicidadeStatus: URI inválida");
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

            var gutperiodicidadestatus = reader.Read(id, oCnn);
            if (gutperiodicidadestatus != null)
            {
                new DBGUTPeriodicidadeStatus().DeletarItem(gutperiodicidadestatus.Id, oCnn, null);
            }

            return gutperiodicidadestatus;
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

    private static string WFiltro(Filters.FilterGUTPeriodicidadeStatus filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.GUTAtividade == -2147483648 ? string.Empty : DBGUTPeriodicidadeStatusDicInfo.GUTAtividadeSql(filtro.GUTAtividade);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBGUTPeriodicidadeStatusDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}