#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ContaCorrenteService(IOptions<AppSettings> appSettings, IContaCorrenteReader reader, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IContaCorrenteService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ContaCorrenteResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ContaCorrente: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ContaCorrente-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ContaCorrenteResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBContaCorrente.SensivelCamposSqlX}, proNroPasta,cliNome
                   FROM {DBContaCorrente.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON proCodigo=ctoProcesso
LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON cliCodigo=ctoCliente
 
                   {where}
                   ORDER BY 
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ContaCorrenteResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBContaCorrente(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var contacorrente = reader.ReadAll(dbRec, item);
                if (contacorrente != null)
                {
                    lista.Add(contacorrente);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ContaCorrenteResponseAll>> Filter(Filters.FilterContaCorrente filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ContaCorrente-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ContaCorrenteResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ContaCorrenteResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ContaCorrente-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ContaCorrente - {uri}-: GetById");
        }
    }

    private async Task<ContaCorrenteResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ContaCorrenteResponse?> AddAndUpdate([FromBody] Models.ContaCorrente regContaCorrente, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ContaCorrente: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regContaCorrente == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regContaCorrente, this, processosReader, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"ContaCorrente: {validade}");
            }

            var saved = writer.Write(regContaCorrente, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ContaCorrenteResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ContaCorrente: URI inválida");
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

            var contacorrente = reader.Read(id, oCnn);
            try
            {
                if (contacorrente != null)
                {
                    writer.Delete(contacorrente, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return contacorrente;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterContaCorrente filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.CIAcordo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.CIAcordo)}", filtro.CIAcordo));
        }

        if (filtro.IDContrato != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.IDContrato)}", filtro.IDContrato));
        }

        if (filtro.QuitadoID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.QuitadoID)}", filtro.QuitadoID));
        }

        if (filtro.DebitoID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.DebitoID)}", filtro.DebitoID));
        }

        if (filtro.LivroCaixaID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.LivroCaixaID)}", filtro.LivroCaixaID));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.ParcelaX != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.ParcelaX)}", filtro.ParcelaX));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.Cliente)}", filtro.Cliente));
        }

        if (!string.IsNullOrEmpty(filtro.Historico))
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.Historico)}", filtro.Historico));
        }

        if (filtro.IDHTrab != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.IDHTrab)}", filtro.IDHTrab));
        }

        if (filtro.NroParcelas != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.NroParcelas)}", filtro.NroParcelas));
        }

        if (filtro.ParcelaPrincipalID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.ParcelaPrincipalID)}", filtro.ParcelaPrincipalID));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBContaCorrenteDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.CIAcordo == int.MinValue ? string.Empty : $"{DBContaCorrenteDicInfo.CIAcordo} = @{nameof(DBContaCorrenteDicInfo.CIAcordo)}";
        cWhere += filtro.IDContrato == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.IDContrato} = @{nameof(DBContaCorrenteDicInfo.IDContrato)}";
        cWhere += filtro.QuitadoID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.QuitadoID} = @{nameof(DBContaCorrenteDicInfo.QuitadoID)}";
        cWhere += filtro.DebitoID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.DebitoID} = @{nameof(DBContaCorrenteDicInfo.DebitoID)}";
        cWhere += filtro.LivroCaixaID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.LivroCaixaID} = @{nameof(DBContaCorrenteDicInfo.LivroCaixaID)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.Processo} = @{nameof(DBContaCorrenteDicInfo.Processo)}";
        cWhere += filtro.ParcelaX == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.ParcelaX} = @{nameof(DBContaCorrenteDicInfo.ParcelaX)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.Cliente} = @{nameof(DBContaCorrenteDicInfo.Cliente)}";
        cWhere += filtro.Historico.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.Historico} = @{nameof(DBContaCorrenteDicInfo.Historico)}";
        cWhere += filtro.IDHTrab == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.IDHTrab} = @{nameof(DBContaCorrenteDicInfo.IDHTrab)}";
        cWhere += filtro.NroParcelas == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.NroParcelas} = @{nameof(DBContaCorrenteDicInfo.NroParcelas)}";
        cWhere += filtro.ParcelaPrincipalID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.ParcelaPrincipalID} = @{nameof(DBContaCorrenteDicInfo.ParcelaPrincipalID)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContaCorrenteDicInfo.GUID} = @{nameof(DBContaCorrenteDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}