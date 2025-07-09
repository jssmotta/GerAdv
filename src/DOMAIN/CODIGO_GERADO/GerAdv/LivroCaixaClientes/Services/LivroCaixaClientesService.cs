#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class LivroCaixaClientesService(IOptions<AppSettings> appSettings, ILivroCaixaClientesReader reader, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : ILivroCaixaClientesService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<LivroCaixaClientesResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("LivroCaixaClientes: URI inválida");
            }
        }

        var cacheKey = $"{uri}-LivroCaixaClientes-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<LivroCaixaClientesResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBLivroCaixaClientes.SensivelCamposSqlX}, [LivroCaixa].[],[Clientes].[cliNome]
                   FROM {DBLivroCaixaClientes.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"LivroCaixa".dbo(oCnn)} (NOLOCK) ON [LivroCaixa].[livCodigo]=[LivroCaixaClientes].[lccLivroCaixa]
LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[LivroCaixaClientes].[lccCliente]
 
                   {where}
                   ORDER BY [LivroCaixaClientes].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<LivroCaixaClientesResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBLivroCaixaClientes(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var livrocaixaclientes = reader.ReadAll(dbRec, item);
                if (livrocaixaclientes != null)
                {
                    lista.Add(livrocaixaclientes);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<LivroCaixaClientesResponseAll>> Filter(Filters.FilterLivroCaixaClientes filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-LivroCaixaClientes-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<LivroCaixaClientesResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new LivroCaixaClientesResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-LivroCaixaClientes-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"LivroCaixaClientes - {uri}-: GetById");
        }
    }

    private async Task<LivroCaixaClientesResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<LivroCaixaClientesResponse?> AddAndUpdate([FromBody] Models.LivroCaixaClientes regLivroCaixaClientes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("LivroCaixaClientes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regLivroCaixaClientes == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regLivroCaixaClientes, this, livrocaixaReader, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regLivroCaixaClientes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<LivroCaixaClientesResponse?> Validation([FromBody] Models.LivroCaixaClientes regLivroCaixaClientes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("LivroCaixaClientes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regLivroCaixaClientes == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regLivroCaixaClientes, this, livrocaixaReader, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regLivroCaixaClientes.Id.IsEmptyIDNumber())
            {
                return new LivroCaixaClientesResponse();
            }

            return reader.Read(regLivroCaixaClientes.Id, oCnn);
        });
    }

    public async Task<LivroCaixaClientesResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("LivroCaixaClientes: URI inválida");
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

            var livrocaixaclientes = reader.Read(id, oCnn);
            try
            {
                if (livrocaixaclientes != null)
                {
                    writer.Delete(livrocaixaclientes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return livrocaixaclientes;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterLivroCaixaClientes filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.LivroCaixa != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLivroCaixaClientesDicInfo.LivroCaixa)}", filtro.LivroCaixa));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLivroCaixaClientesDicInfo.Cliente)}", filtro.Cliente));
        }

        var cWhere = filtro.LivroCaixa == int.MinValue ? string.Empty : $"{DBLivroCaixaClientesDicInfo.LivroCaixa} = @{nameof(DBLivroCaixaClientesDicInfo.LivroCaixa)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLivroCaixaClientesDicInfo.Cliente} = @{nameof(DBLivroCaixaClientesDicInfo.Cliente)}";
        return (cWhere, parameters);
    }
}