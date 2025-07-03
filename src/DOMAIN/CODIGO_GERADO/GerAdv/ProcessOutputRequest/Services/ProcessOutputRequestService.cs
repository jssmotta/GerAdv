#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ProcessOutputRequestService(IOptions<AppSettings> appSettings, IProcessOutputRequestReader reader, IProcessOutputRequestValidation validation, IProcessOutputRequestWriter writer, IProcessOutputEngineReader processoutputengineReader, IOperadorReader operadorReader, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IProcessOutputRequestService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ProcessOutputRequestResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessOutputRequest: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ProcessOutputRequest-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ProcessOutputRequestResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBProcessOutputRequest.SensivelCamposSqlX}, [ProcessOutputEngine].[poeNome],[Operador].[operNome],[Processos].[proNroPasta]
                   FROM {DBProcessOutputRequest.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"ProcessOutputEngine".dbo(oCnn)} (NOLOCK) ON [ProcessOutputEngine].[poeCodigo]=[ProcessOutputRequest].[porProcessOutputEngine]
LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[ProcessOutputRequest].[porOperador]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[ProcessOutputRequest].[porProcesso]
 
                   {where}
                   ORDER BY [ProcessOutputRequest].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ProcessOutputRequestResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBProcessOutputRequest(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var processoutputrequest = reader.ReadAll(dbRec, item);
                if (processoutputrequest != null)
                {
                    lista.Add(processoutputrequest);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ProcessOutputRequestResponseAll>> Filter(Filters.FilterProcessOutputRequest filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ProcessOutputRequest-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ProcessOutputRequestResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ProcessOutputRequestResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ProcessOutputRequest-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ProcessOutputRequest - {uri}-: GetById");
        }
    }

    private async Task<ProcessOutputRequestResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ProcessOutputRequestResponse?> AddAndUpdate([FromBody] Models.ProcessOutputRequest regProcessOutputRequest, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessOutputRequest: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProcessOutputRequest == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProcessOutputRequest, this, processoutputengineReader, operadorReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regProcessOutputRequest, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ProcessOutputRequestResponse?> Validation([FromBody] Models.ProcessOutputRequest regProcessOutputRequest, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessOutputRequest: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProcessOutputRequest == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProcessOutputRequest, this, processoutputengineReader, operadorReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regProcessOutputRequest.Id.IsEmptyIDNumber())
            {
                return new ProcessOutputRequestResponse();
            }

            return reader.Read(regProcessOutputRequest.Id, oCnn);
        });
    }

    public async Task<ProcessOutputRequestResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessOutputRequest: URI inválida");
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

            var processoutputrequest = reader.Read(id, oCnn);
            try
            {
                if (processoutputrequest != null)
                {
                    writer.Delete(processoutputrequest, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return processoutputrequest;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterProcessOutputRequest filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.ProcessOutputEngine != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessOutputRequestDicInfo.ProcessOutputEngine)}", filtro.ProcessOutputEngine));
        }

        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessOutputRequestDicInfo.Operador)}", filtro.Operador));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessOutputRequestDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.UltimoIdTabelaExo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessOutputRequestDicInfo.UltimoIdTabelaExo)}", filtro.UltimoIdTabelaExo));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBProcessOutputRequestDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.ProcessOutputEngine == int.MinValue ? string.Empty : $"{DBProcessOutputRequestDicInfo.ProcessOutputEngine} = @{nameof(DBProcessOutputRequestDicInfo.ProcessOutputEngine)}";
        cWhere += filtro.Operador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputRequestDicInfo.Operador} = @{nameof(DBProcessOutputRequestDicInfo.Operador)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputRequestDicInfo.Processo} = @{nameof(DBProcessOutputRequestDicInfo.Processo)}";
        cWhere += filtro.UltimoIdTabelaExo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputRequestDicInfo.UltimoIdTabelaExo} = @{nameof(DBProcessOutputRequestDicInfo.UltimoIdTabelaExo)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputRequestDicInfo.GUID} = @{nameof(DBProcessOutputRequestDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}