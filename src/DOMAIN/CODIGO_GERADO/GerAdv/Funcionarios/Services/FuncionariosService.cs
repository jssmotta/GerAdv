#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class FuncionariosService(IOptions<AppSettings> appSettings, IFuncionariosReader reader, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, ICidadeReader cidadeReader, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaQuemService agendaquemService, IAgendaRepetirService agendarepetirService, IHorasTrabService horastrabService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IFuncionariosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<FuncionariosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Funcionarios: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Funcionarios-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<FuncionariosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBFuncionarios.SensivelCamposSqlX}, carNome,funDescricao,cidNome
                   FROM {DBFuncionarios.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Cargos".dbo(oCnn)} (NOLOCK) ON carCodigo=funCargo
LEFT JOIN {"Funcao".dbo(oCnn)} (NOLOCK) ON funCodigo=funFuncao
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON cidCodigo=funCidade
 
                   {where}
                   ORDER BY funNome
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<FuncionariosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBFuncionarios(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var funcionarios = reader.ReadAll(dbRec, item);
                if (funcionarios != null)
                {
                    lista.Add(funcionarios);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<FuncionariosResponseAll>> Filter(Filters.FilterFuncionarios filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Funcionarios-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<FuncionariosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new FuncionariosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Funcionarios-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Funcionarios - {uri}-: GetById");
        }
    }

    private async Task<FuncionariosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<FuncionariosResponse?> AddAndUpdate([FromBody] Models.Funcionarios regFuncionarios, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Funcionarios: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regFuncionarios == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regFuncionarios, this, cargosReader, funcaoReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"Funcionarios: {validade}");
            }

            var saved = writer.Write(regFuncionarios, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<FuncionariosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Funcionarios: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, agendaService, agendafinanceiroService, agendaquemService, agendarepetirService, horastrabService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var funcionarios = reader.Read(id, oCnn);
            try
            {
                if (funcionarios != null)
                {
                    writer.Delete(funcionarios, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return funcionarios;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterFuncionarios? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Funcionarios-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBFuncionariosDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterFuncionarios filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.EMailPro))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.EMailPro)}", filtro.EMailPro));
        }

        if (filtro.Cargo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Cargo)}", filtro.Cargo));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.Funcao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Funcao)}", filtro.Funcao));
        }

        if (!string.IsNullOrEmpty(filtro.Registro))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Registro)}", filtro.Registro));
        }

        if (!string.IsNullOrEmpty(filtro.CPF))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.CPF)}", filtro.CPF));
        }

        if (!string.IsNullOrEmpty(filtro.RG))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.RG)}", filtro.RG));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Observacao)}", filtro.Observacao));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Bairro)}", filtro.Bairro));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.Contato))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Contato)}", filtro.Contato));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.CTPSNumero))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.CTPSNumero)}", filtro.CTPSNumero));
        }

        if (!string.IsNullOrEmpty(filtro.CTPSSerie))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.CTPSSerie)}", filtro.CTPSSerie));
        }

        if (!string.IsNullOrEmpty(filtro.PIS))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.PIS)}", filtro.PIS));
        }

        if (!string.IsNullOrEmpty(filtro.Pasta))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Pasta)}", filtro.Pasta));
        }

        if (!string.IsNullOrEmpty(filtro.Class))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.Class)}", filtro.Class));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBFuncionariosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.EMailPro.IsEmpty() ? string.Empty : $"{DBFuncionariosDicInfo.EMailPro} = @{nameof(DBFuncionariosDicInfo.EMailPro)}";
        cWhere += filtro.Cargo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Cargo} = @{nameof(DBFuncionariosDicInfo.Cargo)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Nome} = @{nameof(DBFuncionariosDicInfo.Nome)}";
        cWhere += filtro.Funcao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Funcao} = @{nameof(DBFuncionariosDicInfo.Funcao)}";
        cWhere += filtro.Registro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Registro} = @{nameof(DBFuncionariosDicInfo.Registro)}";
        cWhere += filtro.CPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.CPF} = @{nameof(DBFuncionariosDicInfo.CPF)}";
        cWhere += filtro.RG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.RG} = @{nameof(DBFuncionariosDicInfo.RG)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Observacao} = @{nameof(DBFuncionariosDicInfo.Observacao)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Endereco} = @{nameof(DBFuncionariosDicInfo.Endereco)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Bairro} = @{nameof(DBFuncionariosDicInfo.Bairro)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Cidade} = @{nameof(DBFuncionariosDicInfo.Cidade)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.CEP} = @{nameof(DBFuncionariosDicInfo.CEP)}";
        cWhere += filtro.Contato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Contato} = @{nameof(DBFuncionariosDicInfo.Contato)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Fax} = @{nameof(DBFuncionariosDicInfo.Fax)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Fone} = @{nameof(DBFuncionariosDicInfo.Fone)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.EMail} = @{nameof(DBFuncionariosDicInfo.EMail)}";
        cWhere += filtro.CTPSNumero.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.CTPSNumero} = @{nameof(DBFuncionariosDicInfo.CTPSNumero)}";
        cWhere += filtro.CTPSSerie.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.CTPSSerie} = @{nameof(DBFuncionariosDicInfo.CTPSSerie)}";
        cWhere += filtro.PIS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.PIS} = @{nameof(DBFuncionariosDicInfo.PIS)}";
        cWhere += filtro.Pasta.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Pasta} = @{nameof(DBFuncionariosDicInfo.Pasta)}";
        cWhere += filtro.Class.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.Class} = @{nameof(DBFuncionariosDicInfo.Class)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBFuncionariosDicInfo.GUID} = @{nameof(DBFuncionariosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}