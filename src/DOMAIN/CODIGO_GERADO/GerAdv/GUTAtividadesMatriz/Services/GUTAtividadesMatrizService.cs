#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class GUTAtividadesMatrizService(IOptions<AppSettings> appSettings, IGUTAtividadesMatrizReader reader, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IGUTAtividadesMatrizService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<GUTAtividadesMatrizResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("GUTAtividadesMatriz: URI inválida");
            }
        }

        var cacheKey = $"{uri}-GUTAtividadesMatriz-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<GUTAtividadesMatrizResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBGUTAtividadesMatriz.SensivelCamposSqlX}, [GUTMatriz].[gutDescricao],[GUTAtividades].[agtNome]
                   FROM {DBGUTAtividadesMatriz.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"GUTMatriz".dbo(oCnn)} (NOLOCK) ON [GUTMatriz].[gutCodigo]=[GUTAtividadesMatriz].[amgGUTMatriz]
LEFT JOIN {"GUTAtividades".dbo(oCnn)} (NOLOCK) ON [GUTAtividades].[agtCodigo]=[GUTAtividadesMatriz].[amgGUTAtividade]
 
                   {where}
                   ORDER BY [GUTAtividadesMatriz].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<GUTAtividadesMatrizResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBGUTAtividadesMatriz(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var gutatividadesmatriz = reader.ReadAll(dbRec, item);
                if (gutatividadesmatriz != null)
                {
                    lista.Add(gutatividadesmatriz);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<GUTAtividadesMatrizResponseAll>> Filter(Filters.FilterGUTAtividadesMatriz filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-GUTAtividadesMatriz-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<GUTAtividadesMatrizResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new GUTAtividadesMatrizResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-GUTAtividadesMatriz-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"GUTAtividadesMatriz - {uri}-: GetById");
        }
    }

    private async Task<GUTAtividadesMatrizResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<GUTAtividadesMatrizResponse?> AddAndUpdate([FromBody] Models.GUTAtividadesMatriz regGUTAtividadesMatriz, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("GUTAtividadesMatriz: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regGUTAtividadesMatriz == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regGUTAtividadesMatriz, this, gutmatrizReader, gutatividadesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regGUTAtividadesMatriz, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<GUTAtividadesMatrizResponse?> Validation([FromBody] Models.GUTAtividadesMatriz regGUTAtividadesMatriz, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("GUTAtividadesMatriz: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regGUTAtividadesMatriz == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regGUTAtividadesMatriz, this, gutmatrizReader, gutatividadesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regGUTAtividadesMatriz.Id.IsEmptyIDNumber())
            {
                return new GUTAtividadesMatrizResponse();
            }

            return reader.Read(regGUTAtividadesMatriz.Id, oCnn);
        });
    }

    public async Task<GUTAtividadesMatrizResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("GUTAtividadesMatriz: URI inválida");
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

            var gutatividadesmatriz = reader.Read(id, oCnn);
            try
            {
                if (gutatividadesmatriz != null)
                {
                    writer.Delete(gutatividadesmatriz, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return gutatividadesmatriz;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterGUTAtividadesMatriz filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.GUTMatriz != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBGUTAtividadesMatrizDicInfo.GUTMatriz)}", filtro.GUTMatriz));
        }

        if (filtro.GUTAtividade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBGUTAtividadesMatrizDicInfo.GUTAtividade)}", filtro.GUTAtividade));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBGUTAtividadesMatrizDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.GUTMatriz == int.MinValue ? string.Empty : $"{DBGUTAtividadesMatrizDicInfo.GUTMatriz} = @{nameof(DBGUTAtividadesMatrizDicInfo.GUTMatriz)}";
        cWhere += filtro.GUTAtividade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBGUTAtividadesMatrizDicInfo.GUTAtividade} = @{nameof(DBGUTAtividadesMatrizDicInfo.GUTAtividade)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBGUTAtividadesMatrizDicInfo.GUID} = @{nameof(DBGUTAtividadesMatrizDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}