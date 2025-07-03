#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ProDepositosService(IOptions<AppSettings> appSettings, IProDepositosReader reader, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IProDepositosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ProDepositosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProDepositos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ProDepositos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ProDepositosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBProDepositos.SensivelCamposSqlX}, [Processos].[proNroPasta],[Fase].[fasDescricao],[TipoProDesposito].[tpdNome]
                   FROM {DBProDepositos.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[ProDepositos].[pdsProcesso]
LEFT JOIN {"Fase".dbo(oCnn)} (NOLOCK) ON [Fase].[fasCodigo]=[ProDepositos].[pdsFase]
LEFT JOIN {"TipoProDesposito".dbo(oCnn)} (NOLOCK) ON [TipoProDesposito].[tpdCodigo]=[ProDepositos].[pdsTipoProDesposito]
 
                   {where}
                   ORDER BY [ProDepositos].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ProDepositosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBProDepositos(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var prodepositos = reader.ReadAll(dbRec, item);
                if (prodepositos != null)
                {
                    lista.Add(prodepositos);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ProDepositosResponseAll>> Filter(Filters.FilterProDepositos filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ProDepositos-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ProDepositosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ProDepositosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ProDepositos-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ProDepositos - {uri}-: GetById");
        }
    }

    private async Task<ProDepositosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ProDepositosResponse?> AddAndUpdate([FromBody] Models.ProDepositos regProDepositos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProDepositos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProDepositos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProDepositos, this, processosReader, faseReader, tipoprodespositoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regProDepositos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ProDepositosResponse?> Validation([FromBody] Models.ProDepositos regProDepositos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProDepositos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProDepositos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProDepositos, this, processosReader, faseReader, tipoprodespositoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regProDepositos.Id.IsEmptyIDNumber())
            {
                return new ProDepositosResponse();
            }

            return reader.Read(regProDepositos.Id, oCnn);
        });
    }

    public async Task<ProDepositosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProDepositos: URI inválida");
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

            var prodepositos = reader.Read(id, oCnn);
            try
            {
                if (prodepositos != null)
                {
                    writer.Delete(prodepositos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return prodepositos;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterProDepositos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProDepositosDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Fase != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProDepositosDicInfo.Fase)}", filtro.Fase));
        }

        if (filtro.TipoProDesposito != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProDepositosDicInfo.TipoProDesposito)}", filtro.TipoProDesposito));
        }

        var cWhere = filtro.Processo == int.MinValue ? string.Empty : $"{DBProDepositosDicInfo.Processo} = @{nameof(DBProDepositosDicInfo.Processo)}";
        cWhere += filtro.Fase == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProDepositosDicInfo.Fase} = @{nameof(DBProDepositosDicInfo.Fase)}";
        cWhere += filtro.TipoProDesposito == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProDepositosDicInfo.TipoProDesposito} = @{nameof(DBProDepositosDicInfo.TipoProDesposito)}";
        return (cWhere, parameters);
    }
}