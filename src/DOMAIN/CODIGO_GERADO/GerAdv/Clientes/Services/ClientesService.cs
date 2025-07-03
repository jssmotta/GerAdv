#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ClientesService(IOptions<AppSettings> appSettings, IClientesReader reader, IClientesValidation validation, IClientesWriter writer, ICidadeReader cidadeReader, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaRepetirService agendarepetirService, IAnexamentoRegistrosService anexamentoregistrosService, IClientesSociosService clientessociosService, IColaboradoresService colaboradoresService, IContaCorrenteService contacorrenteService, IContatoCRMService contatocrmService, IContratosService contratosService, IDadosProcuracaoService dadosprocuracaoService, IDiario2Service diario2Service, IGruposEmpresasService gruposempresasService, IGruposEmpresasCliService gruposempresascliService, IHonorariosDadosContratoService honorariosdadoscontratoService, IHorasTrabService horastrabService, ILigacoesService ligacoesService, ILivroCaixaClientesService livrocaixaclientesService, IOperadoresService operadoresService, IPreClientesService preclientesService, IProcessosService processosService, IProDespesasService prodespesasService, IRecadosService recadosService, IReuniaoService reuniaoService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IClientesService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ClientesResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Clientes: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Clientes-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ClientesResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBClientes.SensivelCamposSqlX}, [Cidade].[cidNome],[RegimeTributacao].[rdtNome],[EnquadramentoEmpresa].[eqeNome]
                   FROM {DBClientes.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[Clientes].[cliCidade]
LEFT JOIN {"RegimeTributacao".dbo(oCnn)} (NOLOCK) ON [RegimeTributacao].[rdtCodigo]=[Clientes].[cliRegimeTributacao]
LEFT JOIN {"EnquadramentoEmpresa".dbo(oCnn)} (NOLOCK) ON [EnquadramentoEmpresa].[eqeCodigo]=[Clientes].[cliEnquadramentoEmpresa]
 
                   {where}
                   ORDER BY [Clientes].[cliNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ClientesResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBClientes(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var clientes = reader.ReadAll(dbRec, item);
                if (clientes != null)
                {
                    lista.Add(clientes);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ClientesResponseAll>> Filter(Filters.FilterClientes filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Clientes-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ClientesResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ClientesResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Clientes-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Clientes - {uri}-: GetById");
        }
    }

    private async Task<ClientesResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ClientesResponse?> AddAndUpdate([FromBody] Models.Clientes regClientes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Clientes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regClientes == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regClientes, this, cidadeReader, regimetributacaoReader, enquadramentoempresaReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regClientes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ClientesResponse?> Validation([FromBody] Models.Clientes regClientes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Clientes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regClientes == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regClientes, this, cidadeReader, regimetributacaoReader, enquadramentoempresaReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regClientes.Id.IsEmptyIDNumber())
            {
                return new ClientesResponse();
            }

            return reader.Read(regClientes.Id, oCnn);
        });
    }

    public async Task<ClientesResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Clientes: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, agendaService, agendafinanceiroService, agendarepetirService, anexamentoregistrosService, clientessociosService, colaboradoresService, contacorrenteService, contatocrmService, contratosService, dadosprocuracaoService, diario2Service, gruposempresasService, gruposempresascliService, honorariosdadoscontratoService, horastrabService, ligacoesService, livrocaixaclientesService, operadoresService, preclientesService, processosService, prodespesasService, recadosService, reuniaoService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var clientes = reader.Read(id, oCnn);
            try
            {
                if (clientes != null)
                {
                    writer.Delete(clientes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return clientes;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterClientes? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Clientes-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBClientesDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterClientes filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Empresa != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Empresa)}", filtro.Empresa));
        }

        if (!string.IsNullOrEmpty(filtro.Icone))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Icone)}", filtro.Icone));
        }

        if (!string.IsNullOrEmpty(filtro.NomeMae))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.NomeMae)}", filtro.NomeMae));
        }

        if (!string.IsNullOrEmpty(filtro.QuemIndicou))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.QuemIndicou)}", filtro.QuemIndicou));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.Adv != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Adv)}", filtro.Adv));
        }

        if (filtro.IDRep != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.IDRep)}", filtro.IDRep));
        }

        if (!string.IsNullOrEmpty(filtro.NomeFantasia))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.NomeFantasia)}", filtro.NomeFantasia));
        }

        if (!string.IsNullOrEmpty(filtro.Class))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Class)}", filtro.Class));
        }

        if (!string.IsNullOrEmpty(filtro.InscEst))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.InscEst)}", filtro.InscEst));
        }

        if (!string.IsNullOrEmpty(filtro.Qualificacao))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Qualificacao)}", filtro.Qualificacao));
        }

        if (filtro.Idade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Idade)}", filtro.Idade));
        }

        if (!string.IsNullOrEmpty(filtro.CNPJ))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.CNPJ)}", filtro.CNPJ));
        }

        if (!string.IsNullOrEmpty(filtro.CPF))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.CPF)}", filtro.CPF));
        }

        if (!string.IsNullOrEmpty(filtro.RG))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.RG)}", filtro.RG));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Observacao)}", filtro.Observacao));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Bairro)}", filtro.Bairro));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.HomePage))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.HomePage)}", filtro.HomePage));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.NomePai))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.NomePai)}", filtro.NomePai));
        }

        if (!string.IsNullOrEmpty(filtro.RGOExpeditor))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.RGOExpeditor)}", filtro.RGOExpeditor));
        }

        if (filtro.RegimeTributacao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.RegimeTributacao)}", filtro.RegimeTributacao));
        }

        if (filtro.EnquadramentoEmpresa != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.EnquadramentoEmpresa)}", filtro.EnquadramentoEmpresa));
        }

        if (!string.IsNullOrEmpty(filtro.CNH))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.CNH)}", filtro.CNH));
        }

        if (!string.IsNullOrEmpty(filtro.PessoaContato))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.PessoaContato)}", filtro.PessoaContato));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBClientesDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Empresa == int.MinValue ? string.Empty : $"{DBClientesDicInfo.Empresa} = @{nameof(DBClientesDicInfo.Empresa)}";
        cWhere += filtro.Icone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Icone} = @{nameof(DBClientesDicInfo.Icone)}";
        cWhere += filtro.NomeMae.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.NomeMae} = @{nameof(DBClientesDicInfo.NomeMae)}";
        cWhere += filtro.QuemIndicou.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.QuemIndicou} = @{nameof(DBClientesDicInfo.QuemIndicou)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Nome} = @{nameof(DBClientesDicInfo.Nome)}";
        cWhere += filtro.Adv == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Adv} = @{nameof(DBClientesDicInfo.Adv)}";
        cWhere += filtro.IDRep == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.IDRep} = @{nameof(DBClientesDicInfo.IDRep)}";
        cWhere += filtro.NomeFantasia.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.NomeFantasia} = @{nameof(DBClientesDicInfo.NomeFantasia)}";
        cWhere += filtro.Class.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Class} = @{nameof(DBClientesDicInfo.Class)}";
        cWhere += filtro.InscEst.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.InscEst} = @{nameof(DBClientesDicInfo.InscEst)}";
        cWhere += filtro.Qualificacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Qualificacao} = @{nameof(DBClientesDicInfo.Qualificacao)}";
        cWhere += filtro.Idade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Idade} = @{nameof(DBClientesDicInfo.Idade)}";
        cWhere += filtro.CNPJ.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.CNPJ} = @{nameof(DBClientesDicInfo.CNPJ)}";
        cWhere += filtro.CPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.CPF} = @{nameof(DBClientesDicInfo.CPF)}";
        cWhere += filtro.RG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.RG} = @{nameof(DBClientesDicInfo.RG)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Observacao} = @{nameof(DBClientesDicInfo.Observacao)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Endereco} = @{nameof(DBClientesDicInfo.Endereco)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Bairro} = @{nameof(DBClientesDicInfo.Bairro)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Cidade} = @{nameof(DBClientesDicInfo.Cidade)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.CEP} = @{nameof(DBClientesDicInfo.CEP)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Fax} = @{nameof(DBClientesDicInfo.Fax)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.Fone} = @{nameof(DBClientesDicInfo.Fone)}";
        cWhere += filtro.HomePage.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.HomePage} = @{nameof(DBClientesDicInfo.HomePage)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.EMail} = @{nameof(DBClientesDicInfo.EMail)}";
        cWhere += filtro.NomePai.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.NomePai} = @{nameof(DBClientesDicInfo.NomePai)}";
        cWhere += filtro.RGOExpeditor.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.RGOExpeditor} = @{nameof(DBClientesDicInfo.RGOExpeditor)}";
        cWhere += filtro.RegimeTributacao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.RegimeTributacao} = @{nameof(DBClientesDicInfo.RegimeTributacao)}";
        cWhere += filtro.EnquadramentoEmpresa == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.EnquadramentoEmpresa} = @{nameof(DBClientesDicInfo.EnquadramentoEmpresa)}";
        cWhere += filtro.CNH.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.CNH} = @{nameof(DBClientesDicInfo.CNH)}";
        cWhere += filtro.PessoaContato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.PessoaContato} = @{nameof(DBClientesDicInfo.PessoaContato)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBClientesDicInfo.GUID} = @{nameof(DBClientesDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}