#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ProcessOutputEngineService(IOptions<AppSettings> appSettings, IProcessOutputEngineReader reader, IProcessOutputEngineValidation validation, IProcessOutputEngineWriter writer, IProcessOutputRequestService processoutputrequestService, HybridCache cache, IMemoryCache memory) : IProcessOutputEngineService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ProcessOutputEngineResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessOutputEngine: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ProcessOutputEngine-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ProcessOutputEngineResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBProcessOutputEngine.SensivelCamposSqlX}
                   FROM {DBProcessOutputEngine.PTabelaNome.dbo(oCnn)} (NOLOCK)
                    
                   {where}
                   ORDER BY [ProcessOutputEngine].[poeNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ProcessOutputEngineResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBProcessOutputEngine(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var processoutputengine = reader.ReadAll(dbRec, item);
                if (processoutputengine != null)
                {
                    lista.Add(processoutputengine);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ProcessOutputEngineResponseAll>> Filter(Filters.FilterProcessOutputEngine filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ProcessOutputEngine-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ProcessOutputEngineResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ProcessOutputEngineResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-ProcessOutputEngine-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ProcessOutputEngine - {uri}-: GetById");
        }
    }

    private async Task<ProcessOutputEngineResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ProcessOutputEngineResponse?> AddAndUpdate([FromBody] Models.ProcessOutputEngine regProcessOutputEngine, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessOutputEngine: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProcessOutputEngine == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProcessOutputEngine, this, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regProcessOutputEngine, oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ProcessOutputEngineResponse?> Validation([FromBody] Models.ProcessOutputEngine regProcessOutputEngine, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessOutputEngine: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProcessOutputEngine == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProcessOutputEngine, this, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regProcessOutputEngine.Id.IsEmptyIDNumber())
            {
                return new ProcessOutputEngineResponse();
            }

            return reader.Read(regProcessOutputEngine.Id, oCnn);
        });
    }

    public async Task<ProcessOutputEngineResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessOutputEngine: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, processoutputrequestService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var processoutputengine = reader.Read(id, oCnn);
            try
            {
                if (processoutputengine != null)
                {
                    writer.Delete(processoutputengine, 0, oCnn);
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

            return processoutputengine;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessOutputEngine? filtro, [FromRoute, Required] string uri, CancellationToken token)
    {
        // Tracking: 20250606-1
        ThrowIfDisposed();
        var filtroResult = filtro == null ? null : WFiltro(filtro!);
        string where = filtroResult?.where ?? string.Empty;
        List<SqlParameter> parameters = filtroResult?.parametros ?? [];
        var cacheKey = $"{uri}-ProcessOutputEngine-{max}-{where.GetHashCode()}-{parameters.GetHashCode()}GetListN";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataListNAsync(max, uri, where, parameters, cancel), entryOptions, cancellationToken: token) ?? [];
    }

    private async Task<IEnumerable<NomeID>> GetDataListNAsync(int max, string uri, string where, List<SqlParameter> parameters, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            var result = new List<NomeID>(max);
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBProcessOutputEngineDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterProcessOutputEngine filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.Nome)}", filtro.Nome));
        }

        if (!string.IsNullOrEmpty(filtro.Database))
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.Database)}", filtro.Database));
        }

        if (!string.IsNullOrEmpty(filtro.Tabela))
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.Tabela)}", filtro.Tabela));
        }

        if (!string.IsNullOrEmpty(filtro.Campo))
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.Campo)}", filtro.Campo));
        }

        if (!string.IsNullOrEmpty(filtro.Valor))
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.Valor)}", filtro.Valor));
        }

        if (!string.IsNullOrEmpty(filtro.Output))
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.Output)}", filtro.Output));
        }

        if (filtro.OutputSource != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.OutputSource)}", filtro.OutputSource));
        }

        if (filtro.IDModulo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.IDModulo)}", filtro.IDModulo));
        }

        if (filtro.MyID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.MyID)}", filtro.MyID));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBProcessOutputEngineDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Nome.IsEmpty() ? string.Empty : $"{DBProcessOutputEngineDicInfo.Nome} = @{nameof(DBProcessOutputEngineDicInfo.Nome)}";
        cWhere += filtro.Database.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputEngineDicInfo.Database} = @{nameof(DBProcessOutputEngineDicInfo.Database)}";
        cWhere += filtro.Tabela.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputEngineDicInfo.Tabela} = @{nameof(DBProcessOutputEngineDicInfo.Tabela)}";
        cWhere += filtro.Campo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputEngineDicInfo.Campo} = @{nameof(DBProcessOutputEngineDicInfo.Campo)}";
        cWhere += filtro.Valor.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputEngineDicInfo.Valor} = @{nameof(DBProcessOutputEngineDicInfo.Valor)}";
        cWhere += filtro.Output.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputEngineDicInfo.Output} = @{nameof(DBProcessOutputEngineDicInfo.Output)}";
        cWhere += filtro.OutputSource == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputEngineDicInfo.OutputSource} = @{nameof(DBProcessOutputEngineDicInfo.OutputSource)}";
        cWhere += filtro.IDModulo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputEngineDicInfo.IDModulo} = @{nameof(DBProcessOutputEngineDicInfo.IDModulo)}";
        cWhere += filtro.MyID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputEngineDicInfo.MyID} = @{nameof(DBProcessOutputEngineDicInfo.MyID)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessOutputEngineDicInfo.GUID} = @{nameof(DBProcessOutputEngineDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}