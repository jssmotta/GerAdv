#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OutrasPartesClienteService(IOptions<AppSettings> appSettings, IOutrasPartesClienteReader reader, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, ICidadeReader cidadeReader, IParteClienteOutrasService parteclienteoutrasService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IOutrasPartesClienteService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<OutrasPartesClienteResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OutrasPartesCliente: URI inválida");
            }
        }

        var cacheKey = $"{uri}-OutrasPartesCliente-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<OutrasPartesClienteResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBOutrasPartesCliente.SensivelCamposSqlX}, [Cidade].[cidNome]
                   FROM {DBOutrasPartesCliente.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[OutrasPartesCliente].[opcCidade]
 
                   {where}
                   ORDER BY [OutrasPartesCliente].[opcNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<OutrasPartesClienteResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBOutrasPartesCliente(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var outraspartescliente = reader.ReadAll(dbRec, item);
                if (outraspartescliente != null)
                {
                    lista.Add(outraspartescliente);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<OutrasPartesClienteResponseAll>> Filter(Filters.FilterOutrasPartesCliente filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-OutrasPartesCliente-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<OutrasPartesClienteResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new OutrasPartesClienteResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-OutrasPartesCliente-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"OutrasPartesCliente - {uri}-: GetById");
        }
    }

    private async Task<OutrasPartesClienteResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<OutrasPartesClienteResponse?> AddAndUpdate([FromBody] Models.OutrasPartesCliente regOutrasPartesCliente, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OutrasPartesCliente: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOutrasPartesCliente == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOutrasPartesCliente, this, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regOutrasPartesCliente, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<OutrasPartesClienteResponse?> Validation([FromBody] Models.OutrasPartesCliente regOutrasPartesCliente, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OutrasPartesCliente: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOutrasPartesCliente == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOutrasPartesCliente, this, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regOutrasPartesCliente.Id.IsEmptyIDNumber())
            {
                return new OutrasPartesClienteResponse();
            }

            return reader.Read(regOutrasPartesCliente.Id, oCnn);
        });
    }

    public async Task<OutrasPartesClienteResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OutrasPartesCliente: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, parteclienteoutrasService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var outraspartescliente = reader.Read(id, oCnn);
            try
            {
                if (outraspartescliente != null)
                {
                    writer.Delete(outraspartescliente, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return outraspartescliente;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOutrasPartesCliente? filtro, [FromRoute, Required] string uri, CancellationToken token)
    {
        // Tracking: 20250606-0
        ThrowIfDisposed();
        var filtroResult = filtro == null ? null : WFiltro(filtro!);
        string where = filtroResult?.where ?? string.Empty;
        List<SqlParameter> parameters = filtroResult?.parametros ?? [];
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception($"Coneão nula.");
        }

        var keyCache = await reader.ReadStringAuditor(uri, "", [], oCnn);
        var cacheKey = $"{uri}-OutrasPartesCliente-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataListNAsync(max, uri, where, parameters, cancel), entryOptions, cancellationToken: token) ?? [];
    }

    private async Task<IEnumerable<NomeID>> GetDataListNAsync(int max, string uri, string where, List<SqlParameter> parameters, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            var result = new List<NomeID>(max);
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBOutrasPartesClienteDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterOutrasPartesCliente filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.ClientePrincipal != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.ClientePrincipal)}", filtro.ClientePrincipal));
        }

        if (!string.IsNullOrEmpty(filtro.CPF))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.CPF)}", filtro.CPF));
        }

        if (!string.IsNullOrEmpty(filtro.RG))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.RG)}", filtro.RG));
        }

        if (!string.IsNullOrEmpty(filtro.CNPJ))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.CNPJ)}", filtro.CNPJ));
        }

        if (!string.IsNullOrEmpty(filtro.InscEst))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.InscEst)}", filtro.InscEst));
        }

        if (!string.IsNullOrEmpty(filtro.NomeFantasia))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.NomeFantasia)}", filtro.NomeFantasia));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.Endereco)}", filtro.Endereco));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.Bairro)}", filtro.Bairro));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.Site))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.Site)}", filtro.Site));
        }

        if (!string.IsNullOrEmpty(filtro.Class))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.Class)}", filtro.Class));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBOutrasPartesClienteDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Nome.IsEmpty() ? string.Empty : $"{DBOutrasPartesClienteDicInfo.Nome} = @{nameof(DBOutrasPartesClienteDicInfo.Nome)}";
        cWhere += filtro.ClientePrincipal == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.ClientePrincipal} = @{nameof(DBOutrasPartesClienteDicInfo.ClientePrincipal)}";
        cWhere += filtro.CPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.CPF} = @{nameof(DBOutrasPartesClienteDicInfo.CPF)}";
        cWhere += filtro.RG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.RG} = @{nameof(DBOutrasPartesClienteDicInfo.RG)}";
        cWhere += filtro.CNPJ.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.CNPJ} = @{nameof(DBOutrasPartesClienteDicInfo.CNPJ)}";
        cWhere += filtro.InscEst.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.InscEst} = @{nameof(DBOutrasPartesClienteDicInfo.InscEst)}";
        cWhere += filtro.NomeFantasia.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.NomeFantasia} = @{nameof(DBOutrasPartesClienteDicInfo.NomeFantasia)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.Endereco} = @{nameof(DBOutrasPartesClienteDicInfo.Endereco)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.Cidade} = @{nameof(DBOutrasPartesClienteDicInfo.Cidade)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.CEP} = @{nameof(DBOutrasPartesClienteDicInfo.CEP)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.Bairro} = @{nameof(DBOutrasPartesClienteDicInfo.Bairro)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.Fone} = @{nameof(DBOutrasPartesClienteDicInfo.Fone)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.Fax} = @{nameof(DBOutrasPartesClienteDicInfo.Fax)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.EMail} = @{nameof(DBOutrasPartesClienteDicInfo.EMail)}";
        cWhere += filtro.Site.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.Site} = @{nameof(DBOutrasPartesClienteDicInfo.Site)}";
        cWhere += filtro.Class.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.Class} = @{nameof(DBOutrasPartesClienteDicInfo.Class)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOutrasPartesClienteDicInfo.GUID} = @{nameof(DBOutrasPartesClienteDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}