#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ProcessosParadosService(IOptions<AppSettings> appSettings, IProcessosParadosReader reader, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, HybridCache cache, IMemoryCache memory) : IProcessosParadosService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ProcessosParadosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessosParados: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ProcessosParados-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ProcessosParadosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBProcessosParados.SensivelCamposSqlX}, [Processos].[proNroPasta],[Operador].[operNome]
                   FROM {DBProcessosParados.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[ProcessosParados].[pprProcesso]
LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[ProcessosParados].[pprOperador]
 
                   {where}
                   ORDER BY [ProcessosParados].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ProcessosParadosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBProcessosParados(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var processosparados = reader.ReadAll(dbRec, item);
                if (processosparados != null)
                {
                    lista.Add(processosparados);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ProcessosParadosResponseAll>> Filter(Filters.FilterProcessosParados filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ProcessosParados-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ProcessosParadosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ProcessosParadosResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-ProcessosParados-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ProcessosParados - {uri}-: GetById");
        }
    }

    private async Task<ProcessosParadosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ProcessosParadosResponse?> AddAndUpdate([FromBody] Models.ProcessosParados regProcessosParados, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessosParados: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProcessosParados == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProcessosParados, this, processosReader, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regProcessosParados, oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<ProcessosParadosResponse?> Validation([FromBody] Models.ProcessosParados regProcessosParados, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessosParados: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProcessosParados == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProcessosParados, this, processosReader, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regProcessosParados.Id.IsEmptyIDNumber())
            {
                return new ProcessosParadosResponse();
            }

            return reader.Read(regProcessosParados.Id, oCnn);
        });
    }

    public async Task<ProcessosParadosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProcessosParados: URI inválida");
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

            var processosparados = reader.Read(id, oCnn);
            try
            {
                if (processosparados != null)
                {
                    writer.Delete(processosparados, 0, oCnn);
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

            return processosparados;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterProcessosParados filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosParadosDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Semana != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosParadosDicInfo.Semana)}", filtro.Semana));
        }

        if (filtro.Ano != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosParadosDicInfo.Ano)}", filtro.Ano));
        }

        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosParadosDicInfo.Operador)}", filtro.Operador));
        }

        var cWhere = filtro.Processo == int.MinValue ? string.Empty : $"{DBProcessosParadosDicInfo.Processo} = @{nameof(DBProcessosParadosDicInfo.Processo)}";
        cWhere += filtro.Semana == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosParadosDicInfo.Semana} = @{nameof(DBProcessosParadosDicInfo.Semana)}";
        cWhere += filtro.Ano == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosParadosDicInfo.Ano} = @{nameof(DBProcessosParadosDicInfo.Ano)}";
        cWhere += filtro.Operador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosParadosDicInfo.Operador} = @{nameof(DBProcessosParadosDicInfo.Operador)}";
        return (cWhere, parameters);
    }
}