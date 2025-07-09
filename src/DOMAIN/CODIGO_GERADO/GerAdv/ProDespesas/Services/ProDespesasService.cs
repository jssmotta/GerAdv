#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ProDespesasService(IOptions<AppSettings> appSettings, IProDespesasReader reader, IProDespesasValidation validation, IProDespesasWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IProDespesasService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ProDespesasResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProDespesas: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ProDespesas-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ProDespesasResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBProDespesas.SensivelCamposSqlX}, [Clientes].[cliNome],[Processos].[proNroPasta]
                   FROM {DBProDespesas.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[ProDespesas].[desCliente]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[ProDespesas].[desProcesso]
 
                   {where}
                   ORDER BY [ProDespesas].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ProDespesasResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBProDespesas(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var prodespesas = reader.ReadAll(dbRec, item);
                if (prodespesas != null)
                {
                    lista.Add(prodespesas);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ProDespesasResponseAll>> Filter(Filters.FilterProDespesas filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ProDespesas-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ProDespesasResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ProDespesasResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ProDespesas-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ProDespesas - {uri}-: GetById");
        }
    }

    private async Task<ProDespesasResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ProDespesasResponse?> AddAndUpdate([FromBody] Models.ProDespesas regProDespesas, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProDespesas: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProDespesas == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProDespesas, this, clientesReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regProDespesas, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<ProDespesasResponse?> Validation([FromBody] Models.ProDespesas regProDespesas, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProDespesas: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProDespesas == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProDespesas, this, clientesReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regProDespesas.Id.IsEmptyIDNumber())
            {
                return new ProDespesasResponse();
            }

            return reader.Read(regProDespesas.Id, oCnn);
        });
    }

    public async Task<ProDespesasResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProDespesas: URI inválida");
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

            var prodespesas = reader.Read(id, oCnn);
            try
            {
                if (prodespesas != null)
                {
                    writer.Delete(prodespesas, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return prodespesas;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterProDespesas filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.LigacaoID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProDespesasDicInfo.LigacaoID)}", filtro.LigacaoID));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProDespesasDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProDespesasDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Quitado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProDespesasDicInfo.Quitado)}", filtro.Quitado));
        }

        if (!string.IsNullOrEmpty(filtro.Historico))
        {
            parameters.Add(new($"@{nameof(DBProDespesasDicInfo.Historico)}", filtro.Historico));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBProDespesasDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.LigacaoID == int.MinValue ? string.Empty : $"{DBProDespesasDicInfo.LigacaoID} = @{nameof(DBProDespesasDicInfo.LigacaoID)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProDespesasDicInfo.Cliente} = @{nameof(DBProDespesasDicInfo.Cliente)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProDespesasDicInfo.Processo} = @{nameof(DBProDespesasDicInfo.Processo)}";
        cWhere += filtro.Quitado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProDespesasDicInfo.Quitado} = @{nameof(DBProDespesasDicInfo.Quitado)}";
        cWhere += filtro.Historico.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProDespesasDicInfo.Historico} = @{nameof(DBProDespesasDicInfo.Historico)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProDespesasDicInfo.GUID} = @{nameof(DBProDespesasDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}