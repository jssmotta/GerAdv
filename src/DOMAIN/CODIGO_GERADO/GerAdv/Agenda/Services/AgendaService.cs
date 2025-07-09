#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AgendaService(IOptions<AppSettings> appSettings, IAgendaReader reader, IAgendaValidation validation, IAgendaWriter writer, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgenda2AgendaService agenda2agendaService, IAgendaRecordsService agendarecordsService, IAgendaStatusService agendastatusService, IAlarmSMSService alarmsmsService, IRecadosService recadosService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IAgendaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<AgendaResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Agenda: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Agenda-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AgendaResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBAgenda.SensivelCamposSqlX}, [Cidade].[cidNome],[Advogados].[advNome],[Funcionarios].[funNome],[TipoCompromisso].[tipDescricao],[Clientes].[cliNome],[Area].[areDescricao],[Justica].[jusNome],[Processos].[proNroPasta],[Operador].[operNome],[Prepostos].[preNome]
                   FROM {DBAgenda.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[Agenda].[ageCidade]
LEFT JOIN {"Advogados".dbo(oCnn)} (NOLOCK) ON [Advogados].[advCodigo]=[Agenda].[ageAdvogado]
LEFT JOIN {"Funcionarios".dbo(oCnn)} (NOLOCK) ON [Funcionarios].[funCodigo]=[Agenda].[ageFuncionario]
LEFT JOIN {"TipoCompromisso".dbo(oCnn)} (NOLOCK) ON [TipoCompromisso].[tipCodigo]=[Agenda].[ageTipoCompromisso]
LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[Agenda].[ageCliente]
LEFT JOIN {"Area".dbo(oCnn)} (NOLOCK) ON [Area].[areCodigo]=[Agenda].[ageArea]
LEFT JOIN {"Justica".dbo(oCnn)} (NOLOCK) ON [Justica].[jusCodigo]=[Agenda].[ageJustica]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[Agenda].[ageProcesso]
LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[Agenda].[ageUsuario]
LEFT JOIN {"Prepostos".dbo(oCnn)} (NOLOCK) ON [Prepostos].[preCodigo]=[Agenda].[agePreposto]
 
                   {where}
                   ORDER BY [Agenda].[ageData]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<AgendaResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBAgenda(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var agenda = reader.ReadAll(dbRec, item);
                if (agenda != null)
                {
                    lista.Add(agenda);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<AgendaResponseAll>> Filter(Filters.FilterAgenda filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Agenda-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<AgendaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new AgendaResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Agenda-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Agenda - {uri}-: GetById");
        }
    }

    private async Task<AgendaResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<AgendaResponse?> AddAndUpdate([FromBody] Models.Agenda regAgenda, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Agenda: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgenda == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgenda, this, cidadeReader, advogadosReader, funcionariosReader, tipocompromissoReader, clientesReader, areaReader, justicaReader, processosReader, operadorReader, prepostosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regAgenda, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<AgendaResponse?> Validation([FromBody] Models.Agenda regAgenda, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Agenda: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgenda == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgenda, this, cidadeReader, advogadosReader, funcionariosReader, tipocompromissoReader, clientesReader, areaReader, justicaReader, processosReader, operadorReader, prepostosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regAgenda.Id.IsEmptyIDNumber())
            {
                return new AgendaResponse();
            }

            return reader.Read(regAgenda.Id, oCnn);
        });
    }

    public async Task<AgendaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Agenda: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, agenda2agendaService, agendarecordsService, agendastatusService, alarmsmsService, recadosService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var agenda = reader.Read(id, oCnn);
            try
            {
                if (agenda != null)
                {
                    writer.Delete(agenda, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return agenda;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterAgenda filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.IDCOB != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.IDCOB)}", filtro.IDCOB));
        }

        if (filtro.IDNE != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.IDNE)}", filtro.IDNE));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Cidade)}", filtro.Cidade));
        }

        if (filtro.Oculto != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Oculto)}", filtro.Oculto));
        }

        if (filtro.CartaPrecatoria != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.CartaPrecatoria)}", filtro.CartaPrecatoria));
        }

        if (filtro.Advogado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Advogado)}", filtro.Advogado));
        }

        if (filtro.EventoGerador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.EventoGerador)}", filtro.EventoGerador));
        }

        if (filtro.Funcionario != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Funcionario)}", filtro.Funcionario));
        }

        if (filtro.EventoPrazo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.EventoPrazo)}", filtro.EventoPrazo));
        }

        if (!string.IsNullOrEmpty(filtro.Compromisso))
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Compromisso)}", filtro.Compromisso));
        }

        if (filtro.TipoCompromisso != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.TipoCompromisso)}", filtro.TipoCompromisso));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.Area != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Area)}", filtro.Area));
        }

        if (filtro.Justica != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Justica)}", filtro.Justica));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.IDHistorico != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.IDHistorico)}", filtro.IDHistorico));
        }

        if (filtro.IDInsProcesso != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.IDInsProcesso)}", filtro.IDInsProcesso));
        }

        if (filtro.Usuario != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Usuario)}", filtro.Usuario));
        }

        if (filtro.Preposto != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Preposto)}", filtro.Preposto));
        }

        if (filtro.QuemID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.QuemID)}", filtro.QuemID));
        }

        if (filtro.QuemCodigo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.QuemCodigo)}", filtro.QuemCodigo));
        }

        if (!string.IsNullOrEmpty(filtro.Status))
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Status)}", filtro.Status));
        }

        if (!string.IsNullOrEmpty(filtro.Decisao))
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Decisao)}", filtro.Decisao));
        }

        if (filtro.Sempre != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.Sempre)}", filtro.Sempre));
        }

        if (filtro.PrazoDias != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.PrazoDias)}", filtro.PrazoDias));
        }

        if (filtro.ProtocoloIntegrado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.ProtocoloIntegrado)}", filtro.ProtocoloIntegrado));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBAgendaDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.IDCOB == int.MinValue ? string.Empty : $"{DBAgendaDicInfo.IDCOB} = @{nameof(DBAgendaDicInfo.IDCOB)}";
        cWhere += filtro.IDNE == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.IDNE} = @{nameof(DBAgendaDicInfo.IDNE)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Cidade} = @{nameof(DBAgendaDicInfo.Cidade)}";
        cWhere += filtro.Oculto == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Oculto} = @{nameof(DBAgendaDicInfo.Oculto)}";
        cWhere += filtro.CartaPrecatoria == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.CartaPrecatoria} = @{nameof(DBAgendaDicInfo.CartaPrecatoria)}";
        cWhere += filtro.Advogado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Advogado} = @{nameof(DBAgendaDicInfo.Advogado)}";
        cWhere += filtro.EventoGerador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.EventoGerador} = @{nameof(DBAgendaDicInfo.EventoGerador)}";
        cWhere += filtro.Funcionario == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Funcionario} = @{nameof(DBAgendaDicInfo.Funcionario)}";
        cWhere += filtro.EventoPrazo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.EventoPrazo} = @{nameof(DBAgendaDicInfo.EventoPrazo)}";
        cWhere += filtro.Compromisso.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Compromisso} = @{nameof(DBAgendaDicInfo.Compromisso)}";
        cWhere += filtro.TipoCompromisso == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.TipoCompromisso} = @{nameof(DBAgendaDicInfo.TipoCompromisso)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Cliente} = @{nameof(DBAgendaDicInfo.Cliente)}";
        cWhere += filtro.Area == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Area} = @{nameof(DBAgendaDicInfo.Area)}";
        cWhere += filtro.Justica == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Justica} = @{nameof(DBAgendaDicInfo.Justica)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Processo} = @{nameof(DBAgendaDicInfo.Processo)}";
        cWhere += filtro.IDHistorico == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.IDHistorico} = @{nameof(DBAgendaDicInfo.IDHistorico)}";
        cWhere += filtro.IDInsProcesso == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.IDInsProcesso} = @{nameof(DBAgendaDicInfo.IDInsProcesso)}";
        cWhere += filtro.Usuario == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Usuario} = @{nameof(DBAgendaDicInfo.Usuario)}";
        cWhere += filtro.Preposto == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Preposto} = @{nameof(DBAgendaDicInfo.Preposto)}";
        cWhere += filtro.QuemID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.QuemID} = @{nameof(DBAgendaDicInfo.QuemID)}";
        cWhere += filtro.QuemCodigo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.QuemCodigo} = @{nameof(DBAgendaDicInfo.QuemCodigo)}";
        cWhere += filtro.Status.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Status} = @{nameof(DBAgendaDicInfo.Status)}";
        cWhere += filtro.Decisao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Decisao} = @{nameof(DBAgendaDicInfo.Decisao)}";
        cWhere += filtro.Sempre == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.Sempre} = @{nameof(DBAgendaDicInfo.Sempre)}";
        cWhere += filtro.PrazoDias == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.PrazoDias} = @{nameof(DBAgendaDicInfo.PrazoDias)}";
        cWhere += filtro.ProtocoloIntegrado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.ProtocoloIntegrado} = @{nameof(DBAgendaDicInfo.ProtocoloIntegrado)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaDicInfo.GUID} = @{nameof(DBAgendaDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}