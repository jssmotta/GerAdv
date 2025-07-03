#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AgendaFinanceiroService(IOptions<AppSettings> appSettings, IAgendaFinanceiroReader reader, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IAgendaFinanceiroService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<AgendaFinanceiroResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaFinanceiro: URI inválida");
            }
        }

        var cacheKey = $"{uri}-AgendaFinanceiro-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AgendaFinanceiroResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBAgendaFinanceiro.SensivelCamposSqlX}, [Cidade].[cidNome],[Advogados].[advNome],[Funcionarios].[funNome],[TipoCompromisso].[tipDescricao],[Clientes].[cliNome],[Area].[areDescricao],[Justica].[jusNome],[Processos].[proNroPasta],[Operador].[operNome],[Prepostos].[preNome]
                   FROM {DBAgendaFinanceiro.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[AgendaFinanceiro].[ageCidade]
LEFT JOIN {"Advogados".dbo(oCnn)} (NOLOCK) ON [Advogados].[advCodigo]=[AgendaFinanceiro].[ageAdvogado]
LEFT JOIN {"Funcionarios".dbo(oCnn)} (NOLOCK) ON [Funcionarios].[funCodigo]=[AgendaFinanceiro].[ageFuncionario]
LEFT JOIN {"TipoCompromisso".dbo(oCnn)} (NOLOCK) ON [TipoCompromisso].[tipCodigo]=[AgendaFinanceiro].[ageTipoCompromisso]
LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[AgendaFinanceiro].[ageCliente]
LEFT JOIN {"Area".dbo(oCnn)} (NOLOCK) ON [Area].[areCodigo]=[AgendaFinanceiro].[ageArea]
LEFT JOIN {"Justica".dbo(oCnn)} (NOLOCK) ON [Justica].[jusCodigo]=[AgendaFinanceiro].[ageJustica]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[AgendaFinanceiro].[ageProcesso]
LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[AgendaFinanceiro].[ageUsuario]
LEFT JOIN {"Prepostos".dbo(oCnn)} (NOLOCK) ON [Prepostos].[preCodigo]=[AgendaFinanceiro].[agePreposto]
 
                   {where}
                   ORDER BY [AgendaFinanceiro].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<AgendaFinanceiroResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBAgendaFinanceiro(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var agendafinanceiro = reader.ReadAll(dbRec, item);
                if (agendafinanceiro != null)
                {
                    lista.Add(agendafinanceiro);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<AgendaFinanceiroResponseAll>> Filter(Filters.FilterAgendaFinanceiro filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-AgendaFinanceiro-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<AgendaFinanceiroResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new AgendaFinanceiroResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-AgendaFinanceiro-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"AgendaFinanceiro - {uri}-: GetById");
        }
    }

    private async Task<AgendaFinanceiroResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<AgendaFinanceiroResponse?> AddAndUpdate([FromBody] Models.AgendaFinanceiro regAgendaFinanceiro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaFinanceiro: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaFinanceiro == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaFinanceiro, this, cidadeReader, advogadosReader, funcionariosReader, tipocompromissoReader, clientesReader, areaReader, justicaReader, processosReader, operadorReader, prepostosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regAgendaFinanceiro, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<AgendaFinanceiroResponse?> Validation([FromBody] Models.AgendaFinanceiro regAgendaFinanceiro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaFinanceiro: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaFinanceiro == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaFinanceiro, this, cidadeReader, advogadosReader, funcionariosReader, tipocompromissoReader, clientesReader, areaReader, justicaReader, processosReader, operadorReader, prepostosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regAgendaFinanceiro.Id.IsEmptyIDNumber())
            {
                return new AgendaFinanceiroResponse();
            }

            return reader.Read(regAgendaFinanceiro.Id, oCnn);
        });
    }

    public async Task<AgendaFinanceiroResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaFinanceiro: URI inválida");
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

            var agendafinanceiro = reader.Read(id, oCnn);
            try
            {
                if (agendafinanceiro != null)
                {
                    writer.Delete(agendafinanceiro, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return agendafinanceiro;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterAgendaFinanceiro filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.IDCOB != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.IDCOB)}", filtro.IDCOB));
        }

        if (filtro.IDNE != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.IDNE)}", filtro.IDNE));
        }

        if (filtro.PrazoProvisionado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.PrazoProvisionado)}", filtro.PrazoProvisionado));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Cidade)}", filtro.Cidade));
        }

        if (filtro.Oculto != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Oculto)}", filtro.Oculto));
        }

        if (filtro.CartaPrecatoria != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.CartaPrecatoria)}", filtro.CartaPrecatoria));
        }

        if (filtro.RepetirDias != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.RepetirDias)}", filtro.RepetirDias));
        }

        if (filtro.Repetir != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Repetir)}", filtro.Repetir));
        }

        if (filtro.Advogado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Advogado)}", filtro.Advogado));
        }

        if (filtro.EventoGerador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.EventoGerador)}", filtro.EventoGerador));
        }

        if (filtro.Funcionario != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Funcionario)}", filtro.Funcionario));
        }

        if (filtro.EventoPrazo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.EventoPrazo)}", filtro.EventoPrazo));
        }

        if (!string.IsNullOrEmpty(filtro.Compromisso))
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Compromisso)}", filtro.Compromisso));
        }

        if (filtro.TipoCompromisso != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.TipoCompromisso)}", filtro.TipoCompromisso));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.Dias != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Dias)}", filtro.Dias));
        }

        if (filtro.Area != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Area)}", filtro.Area));
        }

        if (filtro.Justica != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Justica)}", filtro.Justica));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.IDHistorico != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.IDHistorico)}", filtro.IDHistorico));
        }

        if (filtro.IDInsProcesso != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.IDInsProcesso)}", filtro.IDInsProcesso));
        }

        if (filtro.Usuario != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Usuario)}", filtro.Usuario));
        }

        if (filtro.Preposto != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Preposto)}", filtro.Preposto));
        }

        if (filtro.QuemID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.QuemID)}", filtro.QuemID));
        }

        if (filtro.QuemCodigo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.QuemCodigo)}", filtro.QuemCodigo));
        }

        if (!string.IsNullOrEmpty(filtro.Status))
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Status)}", filtro.Status));
        }

        if (!string.IsNullOrEmpty(filtro.CompromissoHTML))
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.CompromissoHTML)}", filtro.CompromissoHTML));
        }

        if (!string.IsNullOrEmpty(filtro.Decisao))
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Decisao)}", filtro.Decisao));
        }

        if (filtro.Sempre != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.Sempre)}", filtro.Sempre));
        }

        if (filtro.PrazoDias != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.PrazoDias)}", filtro.PrazoDias));
        }

        if (filtro.ProtocoloIntegrado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.ProtocoloIntegrado)}", filtro.ProtocoloIntegrado));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBAgendaFinanceiroDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.IDCOB == int.MinValue ? string.Empty : $"{DBAgendaFinanceiroDicInfo.IDCOB} = @{nameof(DBAgendaFinanceiroDicInfo.IDCOB)}";
        cWhere += filtro.IDNE == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.IDNE} = @{nameof(DBAgendaFinanceiroDicInfo.IDNE)}";
        cWhere += filtro.PrazoProvisionado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.PrazoProvisionado} = @{nameof(DBAgendaFinanceiroDicInfo.PrazoProvisionado)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Cidade} = @{nameof(DBAgendaFinanceiroDicInfo.Cidade)}";
        cWhere += filtro.Oculto == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Oculto} = @{nameof(DBAgendaFinanceiroDicInfo.Oculto)}";
        cWhere += filtro.CartaPrecatoria == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.CartaPrecatoria} = @{nameof(DBAgendaFinanceiroDicInfo.CartaPrecatoria)}";
        cWhere += filtro.RepetirDias == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.RepetirDias} = @{nameof(DBAgendaFinanceiroDicInfo.RepetirDias)}";
        cWhere += filtro.Repetir == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Repetir} = @{nameof(DBAgendaFinanceiroDicInfo.Repetir)}";
        cWhere += filtro.Advogado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Advogado} = @{nameof(DBAgendaFinanceiroDicInfo.Advogado)}";
        cWhere += filtro.EventoGerador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.EventoGerador} = @{nameof(DBAgendaFinanceiroDicInfo.EventoGerador)}";
        cWhere += filtro.Funcionario == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Funcionario} = @{nameof(DBAgendaFinanceiroDicInfo.Funcionario)}";
        cWhere += filtro.EventoPrazo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.EventoPrazo} = @{nameof(DBAgendaFinanceiroDicInfo.EventoPrazo)}";
        cWhere += filtro.Compromisso.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Compromisso} = @{nameof(DBAgendaFinanceiroDicInfo.Compromisso)}";
        cWhere += filtro.TipoCompromisso == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.TipoCompromisso} = @{nameof(DBAgendaFinanceiroDicInfo.TipoCompromisso)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Cliente} = @{nameof(DBAgendaFinanceiroDicInfo.Cliente)}";
        cWhere += filtro.Dias == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Dias} = @{nameof(DBAgendaFinanceiroDicInfo.Dias)}";
        cWhere += filtro.Area == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Area} = @{nameof(DBAgendaFinanceiroDicInfo.Area)}";
        cWhere += filtro.Justica == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Justica} = @{nameof(DBAgendaFinanceiroDicInfo.Justica)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Processo} = @{nameof(DBAgendaFinanceiroDicInfo.Processo)}";
        cWhere += filtro.IDHistorico == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.IDHistorico} = @{nameof(DBAgendaFinanceiroDicInfo.IDHistorico)}";
        cWhere += filtro.IDInsProcesso == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.IDInsProcesso} = @{nameof(DBAgendaFinanceiroDicInfo.IDInsProcesso)}";
        cWhere += filtro.Usuario == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Usuario} = @{nameof(DBAgendaFinanceiroDicInfo.Usuario)}";
        cWhere += filtro.Preposto == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Preposto} = @{nameof(DBAgendaFinanceiroDicInfo.Preposto)}";
        cWhere += filtro.QuemID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.QuemID} = @{nameof(DBAgendaFinanceiroDicInfo.QuemID)}";
        cWhere += filtro.QuemCodigo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.QuemCodigo} = @{nameof(DBAgendaFinanceiroDicInfo.QuemCodigo)}";
        cWhere += filtro.Status.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Status} = @{nameof(DBAgendaFinanceiroDicInfo.Status)}";
        cWhere += filtro.CompromissoHTML.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.CompromissoHTML} = @{nameof(DBAgendaFinanceiroDicInfo.CompromissoHTML)}";
        cWhere += filtro.Decisao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Decisao} = @{nameof(DBAgendaFinanceiroDicInfo.Decisao)}";
        cWhere += filtro.Sempre == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.Sempre} = @{nameof(DBAgendaFinanceiroDicInfo.Sempre)}";
        cWhere += filtro.PrazoDias == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.PrazoDias} = @{nameof(DBAgendaFinanceiroDicInfo.PrazoDias)}";
        cWhere += filtro.ProtocoloIntegrado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.ProtocoloIntegrado} = @{nameof(DBAgendaFinanceiroDicInfo.ProtocoloIntegrado)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaFinanceiroDicInfo.GUID} = @{nameof(DBAgendaFinanceiroDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}