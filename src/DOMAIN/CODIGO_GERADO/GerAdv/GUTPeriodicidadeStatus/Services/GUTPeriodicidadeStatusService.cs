#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class GUTPeriodicidadeStatusService(IOptions<AppSettings> appSettings, IGUTPeriodicidadeStatusReader reader, IGUTPeriodicidadeStatusValidation validation, IGUTPeriodicidadeStatusWriter writer, IGUTAtividadesReader gutatividadesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IGUTPeriodicidadeStatusService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<GUTPeriodicidadeStatusResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
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
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<GUTPeriodicidadeStatusResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBGUTPeriodicidadeStatus.SensivelCamposSqlX}, [GUTAtividades].[agtNome]
                   FROM {DBGUTPeriodicidadeStatus.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"GUTAtividades".dbo(oCnn)} (NOLOCK) ON [GUTAtividades].[agtCodigo]=[GUTPeriodicidadeStatus].[pgsGUTAtividade]
 
                   {where}
                   ORDER BY [GUTPeriodicidadeStatus].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<GUTPeriodicidadeStatusResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBGUTPeriodicidadeStatus(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var gutperiodicidadestatus = reader.ReadAll(dbRec, item);
                if (gutperiodicidadestatus != null)
                {
                    lista.Add(gutperiodicidadestatus);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<GUTPeriodicidadeStatusResponseAll>> Filter(Filters.FilterGUTPeriodicidadeStatus filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var filtroResult = filtro == null ? null : WFiltro(filtro!);
        string where = filtroResult?.where ?? string.Empty;
        List<SqlParameter> parameters = filtroResult?.parametros ?? [];
        var keyCache = await reader.ReadStringAuditor(uri, where, parameters, oCnn);
        var cacheKey = $"{uri}-GUTPeriodicidadeStatus-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<GUTPeriodicidadeStatusResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new GUTPeriodicidadeStatusResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var keyCache = await reader.ReadStringAuditor(id, uri, oCnn);
            var result = await _cache.GetOrCreateAsync($"{uri}-GUTPeriodicidadeStatus-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"GUTPeriodicidadeStatus - {uri}-: GetById");
        }
    }

    private async Task<GUTPeriodicidadeStatusResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<GUTPeriodicidadeStatusResponse?> AddAndUpdate([FromBody] Models.GUTPeriodicidadeStatus regGUTPeriodicidadeStatus, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
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

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regGUTPeriodicidadeStatus, this, gutatividadesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regGUTPeriodicidadeStatus, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<GUTPeriodicidadeStatusResponse?> Validation([FromBody] Models.GUTPeriodicidadeStatus regGUTPeriodicidadeStatus, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
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

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regGUTPeriodicidadeStatus, this, gutatividadesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regGUTPeriodicidadeStatus.Id.IsEmptyIDNumber())
            {
                return new GUTPeriodicidadeStatusResponse();
            }

            return reader.Read(regGUTPeriodicidadeStatus.Id, oCnn);
        });
    }

    public async Task<GUTPeriodicidadeStatusResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("GUTPeriodicidadeStatus: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var deleteValidation = await validation.CanDelete(id, this, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var gutperiodicidadestatus = reader.Read(id, oCnn);
            try
            {
                if (gutperiodicidadestatus != null)
                {
                    writer.Delete(gutperiodicidadestatus, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
                    if (_memoryCache is MemoryCache memCache)
                    {
                        memCache.Compact(1.0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterGUTPeriodicidadeStatus filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.GUTAtividade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBGUTPeriodicidadeStatusDicInfo.GUTAtividade)}", filtro.GUTAtividade));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBGUTPeriodicidadeStatusDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.GUTAtividade == int.MinValue ? string.Empty : $"{DBGUTPeriodicidadeStatusDicInfo.GUTAtividade} = @{nameof(DBGUTPeriodicidadeStatusDicInfo.GUTAtividade)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBGUTPeriodicidadeStatusDicInfo.GUID} = @{nameof(DBGUTPeriodicidadeStatusDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}