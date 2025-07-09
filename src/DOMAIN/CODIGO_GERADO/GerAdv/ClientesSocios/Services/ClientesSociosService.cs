#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ClientesSociosService(IOptions<AppSettings> appSettings, IClientesSociosReader reader, IClientesSociosValidation validation, IClientesSociosWriter writer, IClientesReader clientesReader, ICidadeReader cidadeReader, IAgendaRecordsService agendarecordsService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IClientesSociosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ClientesSociosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ClientesSocios: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ClientesSocios-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ClientesSociosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBClientesSocios.SensivelCamposSqlX}, [Clientes].[cliNome],[Cidade].[cidNome]
                   FROM {DBClientesSocios.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[ClientesSocios].[cscCliente]
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[ClientesSocios].[cscCidade]
 
                   {where}
                   ORDER BY [ClientesSocios].[cscNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ClientesSociosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBClientesSocios(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var clientessocios = reader.ReadAll(dbRec, item);
                if (clientessocios != null)
                {
                    lista.Add(clientessocios);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ClientesSociosResponseAll>> Filter(Filters.FilterClientesSocios filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ClientesSocios-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ClientesSociosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ClientesSociosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ClientesSocios-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ClientesSocios - {uri}-: GetById");
        }
    }

    private async Task<ClientesSociosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ClientesSociosResponse?> AddAndUpdate([FromBody] Models.ClientesSocios regClientesSocios, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ClientesSocios: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regClientesSocios == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regClientesSocios, this, clientesReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regClientesSocios, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<ClientesSociosResponse?> Validation([FromBody] Models.ClientesSocios regClientesSocios, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ClientesSocios: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regClientesSocios == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regClientesSocios, this, clientesReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regClientesSocios.Id.IsEmptyIDNumber())
            {
                return new ClientesSociosResponse();
            }

            return reader.Read(regClientesSocios.Id, oCnn);
        });
    }

    public async Task<ClientesSociosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ClientesSocios: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, agendarecordsService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var clientessocios = reader.Read(id, oCnn);
            try
            {
                if (clientessocios != null)
                {
                    writer.Delete(clientessocios, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return clientessocios;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterClientesSocios? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-ClientesSocios-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBClientesSociosDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterClientesSocios filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Idade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Idade)}", filtro.Idade));
        }

        if (!string.IsNullOrEmpty(filtro.Qualificacao))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Qualificacao)}", filtro.Qualificacao));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Nome)}", filtro.Nome));
        }

        if (!string.IsNullOrEmpty(filtro.Site))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Site)}", filtro.Site));
        }

        if (!string.IsNullOrEmpty(filtro.RepresentanteLegal))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.RepresentanteLegal)}", filtro.RepresentanteLegal));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Cliente)}", filtro.Cliente));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Bairro)}", filtro.Bairro));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.CEP)}", filtro.CEP));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.RG))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.RG)}", filtro.RG));
        }

        if (!string.IsNullOrEmpty(filtro.CPF))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.CPF)}", filtro.CPF));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.Participacao))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Participacao)}", filtro.Participacao));
        }

        if (!string.IsNullOrEmpty(filtro.Cargo))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Cargo)}", filtro.Cargo));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.Obs))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Obs)}", filtro.Obs));
        }

        if (!string.IsNullOrEmpty(filtro.CNH))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.CNH)}", filtro.CNH));
        }

        if (!string.IsNullOrEmpty(filtro.CNPJ))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.CNPJ)}", filtro.CNPJ));
        }

        if (!string.IsNullOrEmpty(filtro.InscEst))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.InscEst)}", filtro.InscEst));
        }

        if (!string.IsNullOrEmpty(filtro.SocioEmpresaAdminNome))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.SocioEmpresaAdminNome)}", filtro.SocioEmpresaAdminNome));
        }

        if (!string.IsNullOrEmpty(filtro.EnderecoSocio))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.EnderecoSocio)}", filtro.EnderecoSocio));
        }

        if (!string.IsNullOrEmpty(filtro.BairroSocio))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.BairroSocio)}", filtro.BairroSocio));
        }

        if (!string.IsNullOrEmpty(filtro.CEPSocio))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.CEPSocio)}", filtro.CEPSocio));
        }

        if (filtro.CidadeSocio != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.CidadeSocio)}", filtro.CidadeSocio));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.Class))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.Class)}", filtro.Class));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBClientesSociosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Idade == int.MinValue ? string.Empty : $"{DBClientesSociosDicInfo.Idade} = @{nameof(DBClientesSociosDicInfo.Idade)}";
        cWhere += filtro.Qualificacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Qualificacao} = @{nameof(DBClientesSociosDicInfo.Qualificacao)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Nome} = @{nameof(DBClientesSociosDicInfo.Nome)}";
        cWhere += filtro.Site.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Site} = @{nameof(DBClientesSociosDicInfo.Site)}";
        cWhere += filtro.RepresentanteLegal.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.RepresentanteLegal} = @{nameof(DBClientesSociosDicInfo.RepresentanteLegal)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Cliente} = @{nameof(DBClientesSociosDicInfo.Cliente)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Endereco} = @{nameof(DBClientesSociosDicInfo.Endereco)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Bairro} = @{nameof(DBClientesSociosDicInfo.Bairro)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.CEP} = @{nameof(DBClientesSociosDicInfo.CEP)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Cidade} = @{nameof(DBClientesSociosDicInfo.Cidade)}";
        cWhere += filtro.RG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.RG} = @{nameof(DBClientesSociosDicInfo.RG)}";
        cWhere += filtro.CPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.CPF} = @{nameof(DBClientesSociosDicInfo.CPF)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Fone} = @{nameof(DBClientesSociosDicInfo.Fone)}";
        cWhere += filtro.Participacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Participacao} = @{nameof(DBClientesSociosDicInfo.Participacao)}";
        cWhere += filtro.Cargo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Cargo} = @{nameof(DBClientesSociosDicInfo.Cargo)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.EMail} = @{nameof(DBClientesSociosDicInfo.EMail)}";
        cWhere += filtro.Obs.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Obs} = @{nameof(DBClientesSociosDicInfo.Obs)}";
        cWhere += filtro.CNH.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.CNH} = @{nameof(DBClientesSociosDicInfo.CNH)}";
        cWhere += filtro.CNPJ.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.CNPJ} = @{nameof(DBClientesSociosDicInfo.CNPJ)}";
        cWhere += filtro.InscEst.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.InscEst} = @{nameof(DBClientesSociosDicInfo.InscEst)}";
        cWhere += filtro.SocioEmpresaAdminNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.SocioEmpresaAdminNome} = @{nameof(DBClientesSociosDicInfo.SocioEmpresaAdminNome)}";
        cWhere += filtro.EnderecoSocio.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.EnderecoSocio} = @{nameof(DBClientesSociosDicInfo.EnderecoSocio)}";
        cWhere += filtro.BairroSocio.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.BairroSocio} = @{nameof(DBClientesSociosDicInfo.BairroSocio)}";
        cWhere += filtro.CEPSocio.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.CEPSocio} = @{nameof(DBClientesSociosDicInfo.CEPSocio)}";
        cWhere += filtro.CidadeSocio == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.CidadeSocio} = @{nameof(DBClientesSociosDicInfo.CidadeSocio)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Fax} = @{nameof(DBClientesSociosDicInfo.Fax)}";
        cWhere += filtro.Class.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.Class} = @{nameof(DBClientesSociosDicInfo.Class)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesSociosDicInfo.GUID} = @{nameof(DBClientesSociosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}