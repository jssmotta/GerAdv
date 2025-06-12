#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ContratosService(IOptions<AppSettings> appSettings, IContratosReader reader, IContratosValidation validation, IContratosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IContratosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ContratosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Contratos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Contratos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ContratosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBContratos.SensivelCamposSqlX}, proNroPasta,cliNome,advNome
                   FROM {DBContratos.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON proCodigo=cttProcesso
LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON cliCodigo=cttCliente
LEFT JOIN {"Advogados".dbo(oCnn)} (NOLOCK) ON advCodigo=cttAdvogado
 
                   {where}
                   ORDER BY 
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ContratosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBContratos(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var contratos = reader.ReadAll(dbRec, item);
                if (contratos != null)
                {
                    lista.Add(contratos);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ContratosResponseAll>> Filter(Filters.FilterContratos filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Contratos-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ContratosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ContratosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Contratos-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Contratos - {uri}-: GetById");
        }
    }

    private async Task<ContratosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ContratosResponse?> AddAndUpdate([FromBody] Models.Contratos regContratos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Contratos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regContratos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regContratos, this, processosReader, clientesReader, advogadosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"Contratos: {validade}");
            }

            var saved = writer.Write(regContratos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ContratosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Contratos: URI inválida");
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

            var contratos = reader.Read(id, oCnn);
            try
            {
                if (contratos != null)
                {
                    writer.Delete(contratos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return contratos;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterContratos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.Advogado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Advogado)}", filtro.Advogado));
        }

        if (filtro.Dia != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Dia)}", filtro.Dia));
        }

        if (filtro.TipoCobranca != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.TipoCobranca)}", filtro.TipoCobranca));
        }

        if (!string.IsNullOrEmpty(filtro.Protestar))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Protestar)}", filtro.Protestar));
        }

        if (!string.IsNullOrEmpty(filtro.Juros))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Juros)}", filtro.Juros));
        }

        if (!string.IsNullOrEmpty(filtro.DOCUMENTO))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.DOCUMENTO)}", filtro.DOCUMENTO));
        }

        if (!string.IsNullOrEmpty(filtro.EMail1))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.EMail1)}", filtro.EMail1));
        }

        if (!string.IsNullOrEmpty(filtro.EMail2))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.EMail2)}", filtro.EMail2));
        }

        if (!string.IsNullOrEmpty(filtro.EMail3))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.EMail3)}", filtro.EMail3));
        }

        if (!string.IsNullOrEmpty(filtro.Pessoa1))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Pessoa1)}", filtro.Pessoa1));
        }

        if (!string.IsNullOrEmpty(filtro.Pessoa2))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Pessoa2)}", filtro.Pessoa2));
        }

        if (!string.IsNullOrEmpty(filtro.Pessoa3))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Pessoa3)}", filtro.Pessoa3));
        }

        if (!string.IsNullOrEmpty(filtro.OBS))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.OBS)}", filtro.OBS));
        }

        if (filtro.ClienteContrato != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.ClienteContrato)}", filtro.ClienteContrato));
        }

        if (filtro.IdExtrangeiro != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.IdExtrangeiro)}", filtro.IdExtrangeiro));
        }

        if (!string.IsNullOrEmpty(filtro.ChaveContrato))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.ChaveContrato)}", filtro.ChaveContrato));
        }

        if (!string.IsNullOrEmpty(filtro.Multa))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.Multa)}", filtro.Multa));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBContratosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Processo == int.MinValue ? string.Empty : $"{DBContratosDicInfo.Processo} = @{nameof(DBContratosDicInfo.Processo)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.Cliente} = @{nameof(DBContratosDicInfo.Cliente)}";
        cWhere += filtro.Advogado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.Advogado} = @{nameof(DBContratosDicInfo.Advogado)}";
        cWhere += filtro.Dia == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.Dia} = @{nameof(DBContratosDicInfo.Dia)}";
        cWhere += filtro.TipoCobranca == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.TipoCobranca} = @{nameof(DBContratosDicInfo.TipoCobranca)}";
        cWhere += filtro.Protestar.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.Protestar} = @{nameof(DBContratosDicInfo.Protestar)}";
        cWhere += filtro.Juros.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.Juros} = @{nameof(DBContratosDicInfo.Juros)}";
        cWhere += filtro.DOCUMENTO.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.DOCUMENTO} = @{nameof(DBContratosDicInfo.DOCUMENTO)}";
        cWhere += filtro.EMail1.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.EMail1} = @{nameof(DBContratosDicInfo.EMail1)}";
        cWhere += filtro.EMail2.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.EMail2} = @{nameof(DBContratosDicInfo.EMail2)}";
        cWhere += filtro.EMail3.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.EMail3} = @{nameof(DBContratosDicInfo.EMail3)}";
        cWhere += filtro.Pessoa1.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.Pessoa1} = @{nameof(DBContratosDicInfo.Pessoa1)}";
        cWhere += filtro.Pessoa2.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.Pessoa2} = @{nameof(DBContratosDicInfo.Pessoa2)}";
        cWhere += filtro.Pessoa3.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.Pessoa3} = @{nameof(DBContratosDicInfo.Pessoa3)}";
        cWhere += filtro.OBS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.OBS} = @{nameof(DBContratosDicInfo.OBS)}";
        cWhere += filtro.ClienteContrato == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.ClienteContrato} = @{nameof(DBContratosDicInfo.ClienteContrato)}";
        cWhere += filtro.IdExtrangeiro == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.IdExtrangeiro} = @{nameof(DBContratosDicInfo.IdExtrangeiro)}";
        cWhere += filtro.ChaveContrato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.ChaveContrato} = @{nameof(DBContratosDicInfo.ChaveContrato)}";
        cWhere += filtro.Multa.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.Multa} = @{nameof(DBContratosDicInfo.Multa)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContratosDicInfo.GUID} = @{nameof(DBContratosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}