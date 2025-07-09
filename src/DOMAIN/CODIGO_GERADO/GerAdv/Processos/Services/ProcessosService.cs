#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ProcessosService(IOptions<AppSettings> appSettings, IProcessosReader reader, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ICidadeReader cidadeReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaRepetirService agendarepetirService, IAndamentosMDService andamentosmdService, IApensoService apensoService, IApenso2Service apenso2Service, IContaCorrenteService contacorrenteService, IContatoCRMService contatocrmService, IContratosService contratosService, IDocumentosService documentosService, IEnderecoSistemaService enderecosistemaService, IHistoricoService historicoService, IHonorariosDadosContratoService honorariosdadoscontratoService, IHorasTrabService horastrabService, IInstanciaService instanciaService, ILigacoesService ligacoesService, ILivroCaixaService livrocaixaService, INENotasService nenotasService, IParceriaProcService parceriaprocService, IParteClienteOutrasService parteclienteoutrasService, IPenhoraService penhoraService, IPrecatoriaService precatoriaService, IProCDAService procdaService, IProcessosObsReportService processosobsreportService, IProcessosParadosService processosparadosService, IProcessOutputRequestService processoutputrequestService, IProDepositosService prodepositosService, IProDespesasService prodespesasService, IProObservacoesService proobservacoesService, IProPartesService propartesService, IProProcuradoresService proprocuradoresService, IProResumosService proresumosService, IProSucumbenciaService prosucumbenciaService, IProValoresService provaloresService, IRecadosService recadosService, ITerceirosService terceirosService, IUltimosProcessosService ultimosprocessosService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IProcessosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ProcessosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Processos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Processos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ProcessosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBProcessos.SensivelCamposSqlX}, [Advogados].[advNome],[Justica].[jusNome],[Advogados].[advNome],[Prepostos].[preNome],[Clientes].[cliNome],[Oponentes].[opoNome],[Area].[areDescricao],[Cidade].[cidNome],[Situacao].[],[Rito].[ritDescricao],[Atividades].[atvDescricao]
                   FROM {DBProcessos.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Advogados".dbo(oCnn)} (NOLOCK) ON [Advogados].[advCodigo]=[Processos].[proAdvOpo]
LEFT JOIN {"Justica".dbo(oCnn)} (NOLOCK) ON [Justica].[jusCodigo]=[Processos].[proJustica]
LEFT JOIN {"Advogados".dbo(oCnn)} (NOLOCK) ON [Advogados].[advCodigo]=[Processos].[proAdvogado]
LEFT JOIN {"Prepostos".dbo(oCnn)} (NOLOCK) ON [Prepostos].[preCodigo]=[Processos].[proPreposto]
LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[Processos].[proCliente]
LEFT JOIN {"Oponentes".dbo(oCnn)} (NOLOCK) ON [Oponentes].[opoCodigo]=[Processos].[proOponente]
LEFT JOIN {"Area".dbo(oCnn)} (NOLOCK) ON [Area].[areCodigo]=[Processos].[proArea]
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[Processos].[proCidade]
LEFT JOIN {"Situacao".dbo(oCnn)} (NOLOCK) ON [Situacao].[sitCodigo]=[Processos].[proSituacao]
LEFT JOIN {"Rito".dbo(oCnn)} (NOLOCK) ON [Rito].[ritCodigo]=[Processos].[proRito]
LEFT JOIN {"Atividades".dbo(oCnn)} (NOLOCK) ON [Atividades].[atvCodigo]=[Processos].[proAtividade]
 
                   {where}
                   ORDER BY [Processos].[proNroPasta]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ProcessosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBProcessos(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var processos = reader.ReadAll(dbRec, item);
                if (processos != null)
                {
                    lista.Add(processos);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ProcessosResponseAll>> Filter(Filters.FilterProcessos filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Processos-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ProcessosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ProcessosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Processos-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Processos - {uri}-: GetById");
        }
    }

    private async Task<ProcessosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ProcessosResponse?> AddAndUpdate([FromBody] Models.Processos regProcessos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Processos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProcessos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProcessos, this, advogadosReader, justicaReader, prepostosReader, clientesReader, oponentesReader, areaReader, cidadeReader, situacaoReader, ritoReader, atividadesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regProcessos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<ProcessosResponse?> Validation([FromBody] Models.Processos regProcessos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Processos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProcessos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProcessos, this, advogadosReader, justicaReader, prepostosReader, clientesReader, oponentesReader, areaReader, cidadeReader, situacaoReader, ritoReader, atividadesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regProcessos.Id.IsEmptyIDNumber())
            {
                return new ProcessosResponse();
            }

            return reader.Read(regProcessos.Id, oCnn);
        });
    }

    public async Task<ProcessosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Processos: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, agendaService, agendafinanceiroService, agendarepetirService, andamentosmdService, apensoService, apenso2Service, contacorrenteService, contatocrmService, contratosService, documentosService, enderecosistemaService, historicoService, honorariosdadoscontratoService, horastrabService, instanciaService, ligacoesService, livrocaixaService, nenotasService, parceriaprocService, parteclienteoutrasService, penhoraService, precatoriaService, procdaService, processosobsreportService, processosparadosService, processoutputrequestService, prodepositosService, prodespesasService, proobservacoesService, propartesService, proprocuradoresService, proresumosService, prosucumbenciaService, provaloresService, recadosService, terceirosService, ultimosprocessosService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var processos = reader.Read(id, oCnn);
            try
            {
                if (processos != null)
                {
                    writer.Delete(processos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return processos;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessos? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Processos-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBProcessosDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterProcessos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.AdvParc != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.AdvParc)}", filtro.AdvParc));
        }

        if (filtro.TipoBaixa != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.TipoBaixa)}", filtro.TipoBaixa));
        }

        if (filtro.ClassRisco != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.ClassRisco)}", filtro.ClassRisco));
        }

        if (!string.IsNullOrEmpty(filtro.ObsBCX))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.ObsBCX)}", filtro.ObsBCX));
        }

        if (!string.IsNullOrEmpty(filtro.NroExtra))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.NroExtra)}", filtro.NroExtra));
        }

        if (filtro.AdvOpo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.AdvOpo)}", filtro.AdvOpo));
        }

        if (filtro.Justica != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Justica)}", filtro.Justica));
        }

        if (filtro.Advogado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Advogado)}", filtro.Advogado));
        }

        if (!string.IsNullOrEmpty(filtro.NroCaixa))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.NroCaixa)}", filtro.NroCaixa));
        }

        if (filtro.Preposto != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Preposto)}", filtro.Preposto));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.Oponente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Oponente)}", filtro.Oponente));
        }

        if (filtro.Area != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Area)}", filtro.Area));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Cidade)}", filtro.Cidade));
        }

        if (filtro.Situacao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Situacao)}", filtro.Situacao));
        }

        if (filtro.Rito != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Rito)}", filtro.Rito));
        }

        if (!string.IsNullOrEmpty(filtro.Fato))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Fato)}", filtro.Fato));
        }

        if (!string.IsNullOrEmpty(filtro.NroPasta))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.NroPasta)}", filtro.NroPasta));
        }

        if (filtro.Atividade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Atividade)}", filtro.Atividade));
        }

        if (!string.IsNullOrEmpty(filtro.CaixaMorto))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.CaixaMorto)}", filtro.CaixaMorto));
        }

        if (!string.IsNullOrEmpty(filtro.MotivoBaixa))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.MotivoBaixa)}", filtro.MotivoBaixa));
        }

        if (!string.IsNullOrEmpty(filtro.OBS))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.OBS)}", filtro.OBS));
        }

        if (!string.IsNullOrEmpty(filtro.ZKey))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.ZKey)}", filtro.ZKey));
        }

        if (filtro.ZKeyQuem != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.ZKeyQuem)}", filtro.ZKeyQuem));
        }

        if (!string.IsNullOrEmpty(filtro.Resumo))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.Resumo)}", filtro.Resumo));
        }

        if (!string.IsNullOrEmpty(filtro.NroContrato))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.NroContrato)}", filtro.NroContrato));
        }

        if (!string.IsNullOrEmpty(filtro.PercProbExitoJustificativa))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.PercProbExitoJustificativa)}", filtro.PercProbExitoJustificativa));
        }

        if (filtro.FaseAuditoria != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.FaseAuditoria)}", filtro.FaseAuditoria));
        }

        if (filtro.ValorCondenacaoProvisorio != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.ValorCondenacaoProvisorio)}", filtro.ValorCondenacaoProvisorio));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBProcessosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.AdvParc == int.MinValue ? string.Empty : $"{DBProcessosDicInfo.AdvParc} = @{nameof(DBProcessosDicInfo.AdvParc)}";
        cWhere += filtro.TipoBaixa == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.TipoBaixa} = @{nameof(DBProcessosDicInfo.TipoBaixa)}";
        cWhere += filtro.ClassRisco == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.ClassRisco} = @{nameof(DBProcessosDicInfo.ClassRisco)}";
        cWhere += filtro.ObsBCX.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.ObsBCX} = @{nameof(DBProcessosDicInfo.ObsBCX)}";
        cWhere += filtro.NroExtra.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.NroExtra} = @{nameof(DBProcessosDicInfo.NroExtra)}";
        cWhere += filtro.AdvOpo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.AdvOpo} = @{nameof(DBProcessosDicInfo.AdvOpo)}";
        cWhere += filtro.Justica == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Justica} = @{nameof(DBProcessosDicInfo.Justica)}";
        cWhere += filtro.Advogado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Advogado} = @{nameof(DBProcessosDicInfo.Advogado)}";
        cWhere += filtro.NroCaixa.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.NroCaixa} = @{nameof(DBProcessosDicInfo.NroCaixa)}";
        cWhere += filtro.Preposto == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Preposto} = @{nameof(DBProcessosDicInfo.Preposto)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Cliente} = @{nameof(DBProcessosDicInfo.Cliente)}";
        cWhere += filtro.Oponente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Oponente} = @{nameof(DBProcessosDicInfo.Oponente)}";
        cWhere += filtro.Area == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Area} = @{nameof(DBProcessosDicInfo.Area)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Cidade} = @{nameof(DBProcessosDicInfo.Cidade)}";
        cWhere += filtro.Situacao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Situacao} = @{nameof(DBProcessosDicInfo.Situacao)}";
        cWhere += filtro.Rito == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Rito} = @{nameof(DBProcessosDicInfo.Rito)}";
        cWhere += filtro.Fato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Fato} = @{nameof(DBProcessosDicInfo.Fato)}";
        cWhere += filtro.NroPasta.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.NroPasta} = @{nameof(DBProcessosDicInfo.NroPasta)}";
        cWhere += filtro.Atividade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Atividade} = @{nameof(DBProcessosDicInfo.Atividade)}";
        cWhere += filtro.CaixaMorto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.CaixaMorto} = @{nameof(DBProcessosDicInfo.CaixaMorto)}";
        cWhere += filtro.MotivoBaixa.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.MotivoBaixa} = @{nameof(DBProcessosDicInfo.MotivoBaixa)}";
        cWhere += filtro.OBS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.OBS} = @{nameof(DBProcessosDicInfo.OBS)}";
        cWhere += filtro.ZKey.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.ZKey} = @{nameof(DBProcessosDicInfo.ZKey)}";
        cWhere += filtro.ZKeyQuem == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.ZKeyQuem} = @{nameof(DBProcessosDicInfo.ZKeyQuem)}";
        cWhere += filtro.Resumo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.Resumo} = @{nameof(DBProcessosDicInfo.Resumo)}";
        cWhere += filtro.NroContrato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.NroContrato} = @{nameof(DBProcessosDicInfo.NroContrato)}";
        cWhere += filtro.PercProbExitoJustificativa.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.PercProbExitoJustificativa} = @{nameof(DBProcessosDicInfo.PercProbExitoJustificativa)}";
        cWhere += filtro.FaseAuditoria == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.FaseAuditoria} = @{nameof(DBProcessosDicInfo.FaseAuditoria)}";
        cWhere += filtro.ValorCondenacaoProvisorio == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.ValorCondenacaoProvisorio} = @{nameof(DBProcessosDicInfo.ValorCondenacaoProvisorio)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProcessosDicInfo.GUID} = @{nameof(DBProcessosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}