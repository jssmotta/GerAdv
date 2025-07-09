#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ParteClienteOutrasService(IOptions<AppSettings> appSettings, IParteClienteOutrasReader reader, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IParteClienteOutrasService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ParteClienteOutrasResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ParteClienteOutras: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ParteClienteOutras-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ParteClienteOutrasResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBParteClienteOutras.SensivelCamposSqlX}, [OutrasPartesCliente].[opcNome],[Processos].[proNroPasta]
                   FROM {DBParteClienteOutras.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"OutrasPartesCliente".dbo(oCnn)} (NOLOCK) ON [OutrasPartesCliente].[opcCodigo]=[ParteClienteOutras].[pcoCliente]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[ParteClienteOutras].[pcoProcesso]
 
                   {where}
                   ORDER BY [ParteClienteOutras].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ParteClienteOutrasResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBParteClienteOutras(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var parteclienteoutras = reader.ReadAll(dbRec, item);
                if (parteclienteoutras != null)
                {
                    lista.Add(parteclienteoutras);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ParteClienteOutrasResponseAll>> Filter(Filters.FilterParteClienteOutras filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ParteClienteOutras-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ParteClienteOutrasResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ParteClienteOutrasResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ParteClienteOutras-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ParteClienteOutras - {uri}-: GetById");
        }
    }

    private async Task<ParteClienteOutrasResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ParteClienteOutrasResponse?> AddAndUpdate([FromBody] Models.ParteClienteOutras regParteClienteOutras, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ParteClienteOutras: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regParteClienteOutras == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regParteClienteOutras, this, outraspartesclienteReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regParteClienteOutras, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<ParteClienteOutrasResponse?> Validation([FromBody] Models.ParteClienteOutras regParteClienteOutras, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ParteClienteOutras: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regParteClienteOutras == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regParteClienteOutras, this, outraspartesclienteReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regParteClienteOutras.Id.IsEmptyIDNumber())
            {
                return new ParteClienteOutrasResponse();
            }

            return reader.Read(regParteClienteOutras.Id, oCnn);
        });
    }

    public async Task<ParteClienteOutrasResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ParteClienteOutras: URI inválida");
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

            var parteclienteoutras = reader.Read(id, oCnn);
            try
            {
                if (parteclienteoutras != null)
                {
                    writer.Delete(parteclienteoutras, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return parteclienteoutras;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterParteClienteOutras filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBParteClienteOutrasDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBParteClienteOutrasDicInfo.Processo)}", filtro.Processo));
        }

        var cWhere = filtro.Cliente == int.MinValue ? string.Empty : $"{DBParteClienteOutrasDicInfo.Cliente} = @{nameof(DBParteClienteOutrasDicInfo.Cliente)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBParteClienteOutrasDicInfo.Processo} = @{nameof(DBParteClienteOutrasDicInfo.Processo)}";
        return (cWhere, parameters);
    }
}