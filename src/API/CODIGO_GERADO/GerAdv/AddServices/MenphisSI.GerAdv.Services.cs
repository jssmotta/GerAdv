﻿using MenphisSI.GerAdv.Services;

#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AddServices
{
    public static void Add(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAcaoService, AcaoService>();
        builder.Services.AddScoped<AcaoService>();
        builder.Services.AddScoped<IAdvogadosService, AdvogadosService>();
        builder.Services.AddScoped<AdvogadosService>();
        builder.Services.AddScoped<IAgendaService, AgendaService>();
        builder.Services.AddScoped<AgendaService>();
        builder.Services.AddScoped<IAgenda2AgendaService, Agenda2AgendaService>();
        builder.Services.AddScoped<Agenda2AgendaService>();
        builder.Services.AddScoped<IAgendaFinanceiroService, AgendaFinanceiroService>();
        builder.Services.AddScoped<AgendaFinanceiroService>();
        builder.Services.AddScoped<IAgendaQuemService, AgendaQuemService>();
        builder.Services.AddScoped<AgendaQuemService>();
        builder.Services.AddScoped<IAgendaRecordsService, AgendaRecordsService>();
        builder.Services.AddScoped<AgendaRecordsService>();
        builder.Services.AddScoped<IAgendaRepetirService, AgendaRepetirService>();
        builder.Services.AddScoped<AgendaRepetirService>();
        builder.Services.AddScoped<IAgendaRepetirDiasService, AgendaRepetirDiasService>();
        builder.Services.AddScoped<AgendaRepetirDiasService>();
        builder.Services.AddScoped<IAgendaStatusService, AgendaStatusService>();
        builder.Services.AddScoped<AgendaStatusService>();
        builder.Services.AddScoped<IAlarmSMSService, AlarmSMSService>();
        builder.Services.AddScoped<AlarmSMSService>();
        builder.Services.AddScoped<IAlertasService, AlertasService>();
        builder.Services.AddScoped<AlertasService>();
        builder.Services.AddScoped<IAlertasEnviadosService, AlertasEnviadosService>();
        builder.Services.AddScoped<AlertasEnviadosService>();
        builder.Services.AddScoped<IAndamentosMDService, AndamentosMDService>();
        builder.Services.AddScoped<AndamentosMDService>();
        builder.Services.AddScoped<IAndCompService, AndCompService>();
        builder.Services.AddScoped<AndCompService>();
        builder.Services.AddScoped<IAnexamentoRegistrosService, AnexamentoRegistrosService>();
        builder.Services.AddScoped<AnexamentoRegistrosService>();
        builder.Services.AddScoped<IApensoService, ApensoService>();
        builder.Services.AddScoped<ApensoService>();
        builder.Services.AddScoped<IApenso2Service, Apenso2Service>();
        builder.Services.AddScoped<Apenso2Service>();
        builder.Services.AddScoped<IAreaService, AreaService>();
        builder.Services.AddScoped<AreaService>();
        builder.Services.AddScoped<IAreasJusticaService, AreasJusticaService>();
        builder.Services.AddScoped<AreasJusticaService>();
        builder.Services.AddScoped<IAtividadesService, AtividadesService>();
        builder.Services.AddScoped<AtividadesService>();
        builder.Services.AddScoped<IAuditor4KService, Auditor4KService>();
        builder.Services.AddScoped<Auditor4KService>();
        builder.Services.AddScoped<IBensClassificacaoService, BensClassificacaoService>();
        builder.Services.AddScoped<BensClassificacaoService>();
        builder.Services.AddScoped<IBensMateriaisService, BensMateriaisService>();
        builder.Services.AddScoped<BensMateriaisService>();
        builder.Services.AddScoped<ICargosService, CargosService>();
        builder.Services.AddScoped<CargosService>();
        builder.Services.AddScoped<ICargosEscService, CargosEscService>();
        builder.Services.AddScoped<CargosEscService>();
        builder.Services.AddScoped<ICargosEscClassService, CargosEscClassService>();
        builder.Services.AddScoped<CargosEscClassService>();
        builder.Services.AddScoped<ICidadeService, CidadeService>();
        builder.Services.AddScoped<CidadeService>();
        builder.Services.AddScoped<IClientesService, ClientesService>();
        builder.Services.AddScoped<ClientesService>();
        builder.Services.AddScoped<IClientesSociosService, ClientesSociosService>();
        builder.Services.AddScoped<ClientesSociosService>();
        builder.Services.AddScoped<IColaboradoresService, ColaboradoresService>();
        builder.Services.AddScoped<ColaboradoresService>();
        builder.Services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
        builder.Services.AddScoped<ContaCorrenteService>();
        builder.Services.AddScoped<IContatoCRMService, ContatoCRMService>();
        builder.Services.AddScoped<ContatoCRMService>();
        builder.Services.AddScoped<IContatoCRMOperadorService, ContatoCRMOperadorService>();
        builder.Services.AddScoped<ContatoCRMOperadorService>();
        builder.Services.AddScoped<IContatoCRMViewService, ContatoCRMViewService>();
        builder.Services.AddScoped<ContatoCRMViewService>();
        builder.Services.AddScoped<IContratosService, ContratosService>();
        builder.Services.AddScoped<ContratosService>();
        builder.Services.AddScoped<IDadosProcuracaoService, DadosProcuracaoService>();
        builder.Services.AddScoped<DadosProcuracaoService>();
        builder.Services.AddScoped<IDiario2Service, Diario2Service>();
        builder.Services.AddScoped<Diario2Service>();
        builder.Services.AddScoped<IDivisaoTribunalService, DivisaoTribunalService>();
        builder.Services.AddScoped<DivisaoTribunalService>();
        builder.Services.AddScoped<IDocsRecebidosItensService, DocsRecebidosItensService>();
        builder.Services.AddScoped<DocsRecebidosItensService>();
        builder.Services.AddScoped<IDocumentosService, DocumentosService>();
        builder.Services.AddScoped<DocumentosService>();
        builder.Services.AddScoped<IEMPClassRiscosService, EMPClassRiscosService>();
        builder.Services.AddScoped<EMPClassRiscosService>();
        builder.Services.AddScoped<IEnderecosService, EnderecosService>();
        builder.Services.AddScoped<EnderecosService>();
        builder.Services.AddScoped<IEnderecoSistemaService, EnderecoSistemaService>();
        builder.Services.AddScoped<EnderecoSistemaService>();
        builder.Services.AddScoped<IEndTitService, EndTitService>();
        builder.Services.AddScoped<EndTitService>();
        builder.Services.AddScoped<IEnquadramentoEmpresaService, EnquadramentoEmpresaService>();
        builder.Services.AddScoped<EnquadramentoEmpresaService>();
        builder.Services.AddScoped<IEscritoriosService, EscritoriosService>();
        builder.Services.AddScoped<EscritoriosService>();
        builder.Services.AddScoped<IEventoPrazoAgendaService, EventoPrazoAgendaService>();
        builder.Services.AddScoped<EventoPrazoAgendaService>();
        builder.Services.AddScoped<IFaseService, FaseService>();
        builder.Services.AddScoped<FaseService>();
        builder.Services.AddScoped<IFornecedoresService, FornecedoresService>();
        builder.Services.AddScoped<FornecedoresService>();
        builder.Services.AddScoped<IForoService, ForoService>();
        builder.Services.AddScoped<ForoService>();
        builder.Services.AddScoped<IFuncaoService, FuncaoService>();
        builder.Services.AddScoped<FuncaoService>();
        builder.Services.AddScoped<IFuncionariosService, FuncionariosService>();
        builder.Services.AddScoped<FuncionariosService>();
        builder.Services.AddScoped<IGraphService, GraphService>();
        builder.Services.AddScoped<GraphService>();
        builder.Services.AddScoped<IGruposEmpresasService, GruposEmpresasService>();
        builder.Services.AddScoped<GruposEmpresasService>();
        builder.Services.AddScoped<IGruposEmpresasCliService, GruposEmpresasCliService>();
        builder.Services.AddScoped<GruposEmpresasCliService>();
        builder.Services.AddScoped<IGUTAtividadesService, GUTAtividadesService>();
        builder.Services.AddScoped<GUTAtividadesService>();
        builder.Services.AddScoped<IGUTAtividadesMatrizService, GUTAtividadesMatrizService>();
        builder.Services.AddScoped<GUTAtividadesMatrizService>();
        builder.Services.AddScoped<IGUTMatrizService, GUTMatrizService>();
        builder.Services.AddScoped<GUTMatrizService>();
        builder.Services.AddScoped<IGUTPeriodicidadeService, GUTPeriodicidadeService>();
        builder.Services.AddScoped<GUTPeriodicidadeService>();
        builder.Services.AddScoped<IGUTPeriodicidadeStatusService, GUTPeriodicidadeStatusService>();
        builder.Services.AddScoped<GUTPeriodicidadeStatusService>();
        builder.Services.AddScoped<IGUTTipoService, GUTTipoService>();
        builder.Services.AddScoped<GUTTipoService>();
        builder.Services.AddScoped<IHistoricoService, HistoricoService>();
        builder.Services.AddScoped<HistoricoService>();
        builder.Services.AddScoped<IHonorariosDadosContratoService, HonorariosDadosContratoService>();
        builder.Services.AddScoped<HonorariosDadosContratoService>();
        builder.Services.AddScoped<IHorasTrabService, HorasTrabService>();
        builder.Services.AddScoped<HorasTrabService>();
        builder.Services.AddScoped<IInstanciaService, InstanciaService>();
        builder.Services.AddScoped<InstanciaService>();
        builder.Services.AddScoped<IJusticaService, JusticaService>();
        builder.Services.AddScoped<JusticaService>();
        builder.Services.AddScoped<ILigacoesService, LigacoesService>();
        builder.Services.AddScoped<LigacoesService>();
        builder.Services.AddScoped<ILivroCaixaService, LivroCaixaService>();
        builder.Services.AddScoped<LivroCaixaService>();
        builder.Services.AddScoped<ILivroCaixaClientesService, LivroCaixaClientesService>();
        builder.Services.AddScoped<LivroCaixaClientesService>();
        builder.Services.AddScoped<IModelosDocumentosService, ModelosDocumentosService>();
        builder.Services.AddScoped<ModelosDocumentosService>();
        builder.Services.AddScoped<INECompromissosService, NECompromissosService>();
        builder.Services.AddScoped<NECompromissosService>();
        builder.Services.AddScoped<INENotasService, NENotasService>();
        builder.Services.AddScoped<NENotasService>();
        builder.Services.AddScoped<INEPalavrasChavesService, NEPalavrasChavesService>();
        builder.Services.AddScoped<NEPalavrasChavesService>();
        builder.Services.AddScoped<IObjetosService, ObjetosService>();
        builder.Services.AddScoped<ObjetosService>();
        builder.Services.AddScoped<IOperadorService, OperadorService>();
        builder.Services.AddScoped<OperadorService>();
        builder.Services.AddScoped<IOperadorEMailPopupService, OperadorEMailPopupService>();
        builder.Services.AddScoped<OperadorEMailPopupService>();
        builder.Services.AddScoped<IOperadoresService, OperadoresService>();
        builder.Services.AddScoped<OperadoresService>();
        builder.Services.AddScoped<IOperadorGrupoService, OperadorGrupoService>();
        builder.Services.AddScoped<OperadorGrupoService>();
        builder.Services.AddScoped<IOperadorGruposService, OperadorGruposService>();
        builder.Services.AddScoped<OperadorGruposService>();
        builder.Services.AddScoped<IOperadorGruposAgendaService, OperadorGruposAgendaService>();
        builder.Services.AddScoped<OperadorGruposAgendaService>();
        builder.Services.AddScoped<IOperadorGruposAgendaOperadoresService, OperadorGruposAgendaOperadoresService>();
        builder.Services.AddScoped<OperadorGruposAgendaOperadoresService>();
        builder.Services.AddScoped<IOponentesService, OponentesService>();
        builder.Services.AddScoped<OponentesService>();
        builder.Services.AddScoped<IOponentesRepLegalService, OponentesRepLegalService>();
        builder.Services.AddScoped<OponentesRepLegalService>();
        builder.Services.AddScoped<IOutrasPartesClienteService, OutrasPartesClienteService>();
        builder.Services.AddScoped<OutrasPartesClienteService>();
        builder.Services.AddScoped<IPaisesService, PaisesService>();
        builder.Services.AddScoped<PaisesService>();
        builder.Services.AddScoped<IParceriaProcService, ParceriaProcService>();
        builder.Services.AddScoped<ParceriaProcService>();
        builder.Services.AddScoped<IParteClienteOutrasService, ParteClienteOutrasService>();
        builder.Services.AddScoped<ParteClienteOutrasService>();
        builder.Services.AddScoped<IPenhoraService, PenhoraService>();
        builder.Services.AddScoped<PenhoraService>();
        builder.Services.AddScoped<IPenhoraStatusService, PenhoraStatusService>();
        builder.Services.AddScoped<PenhoraStatusService>();
        builder.Services.AddScoped<IPoderJudiciarioAssociadoService, PoderJudiciarioAssociadoService>();
        builder.Services.AddScoped<PoderJudiciarioAssociadoService>();
        builder.Services.AddScoped<IPontoVirtualService, PontoVirtualService>();
        builder.Services.AddScoped<PontoVirtualService>();
        builder.Services.AddScoped<IPontoVirtualAcessosService, PontoVirtualAcessosService>();
        builder.Services.AddScoped<PontoVirtualAcessosService>();
        builder.Services.AddScoped<IPosicaoOutrasPartesService, PosicaoOutrasPartesService>();
        builder.Services.AddScoped<PosicaoOutrasPartesService>();
        builder.Services.AddScoped<IPrecatoriaService, PrecatoriaService>();
        builder.Services.AddScoped<PrecatoriaService>();
        builder.Services.AddScoped<IPreClientesService, PreClientesService>();
        builder.Services.AddScoped<PreClientesService>();
        builder.Services.AddScoped<IPrepostosService, PrepostosService>();
        builder.Services.AddScoped<PrepostosService>();
        builder.Services.AddScoped<IProCDAService, ProCDAService>();
        builder.Services.AddScoped<ProCDAService>();
        builder.Services.AddScoped<IProcessosService, ProcessosService>();
        builder.Services.AddScoped<ProcessosService>();
        builder.Services.AddScoped<IProcessosObsReportService, ProcessosObsReportService>();
        builder.Services.AddScoped<ProcessosObsReportService>();
        builder.Services.AddScoped<IProcessosParadosService, ProcessosParadosService>();
        builder.Services.AddScoped<ProcessosParadosService>();
        builder.Services.AddScoped<IProcessOutputEngineService, ProcessOutputEngineService>();
        builder.Services.AddScoped<ProcessOutputEngineService>();
        builder.Services.AddScoped<IProcessOutPutIDsService, ProcessOutPutIDsService>();
        builder.Services.AddScoped<ProcessOutPutIDsService>();
        builder.Services.AddScoped<IProcessOutputRequestService, ProcessOutputRequestService>();
        builder.Services.AddScoped<ProcessOutputRequestService>();
        builder.Services.AddScoped<IProcessOutputSourcesService, ProcessOutputSourcesService>();
        builder.Services.AddScoped<ProcessOutputSourcesService>();
        builder.Services.AddScoped<IProDepositosService, ProDepositosService>();
        builder.Services.AddScoped<ProDepositosService>();
        builder.Services.AddScoped<IProDespesasService, ProDespesasService>();
        builder.Services.AddScoped<ProDespesasService>();
        builder.Services.AddScoped<IProObservacoesService, ProObservacoesService>();
        builder.Services.AddScoped<ProObservacoesService>();
        builder.Services.AddScoped<IProPartesService, ProPartesService>();
        builder.Services.AddScoped<ProPartesService>();
        builder.Services.AddScoped<IProProcuradoresService, ProProcuradoresService>();
        builder.Services.AddScoped<ProProcuradoresService>();
        builder.Services.AddScoped<IProResumosService, ProResumosService>();
        builder.Services.AddScoped<ProResumosService>();
        builder.Services.AddScoped<IProSucumbenciaService, ProSucumbenciaService>();
        builder.Services.AddScoped<ProSucumbenciaService>();
        builder.Services.AddScoped<IProTipoBaixaService, ProTipoBaixaService>();
        builder.Services.AddScoped<ProTipoBaixaService>();
        builder.Services.AddScoped<IProValoresService, ProValoresService>();
        builder.Services.AddScoped<ProValoresService>();
        builder.Services.AddScoped<IRamalService, RamalService>();
        builder.Services.AddScoped<RamalService>();
        builder.Services.AddScoped<IRecadosService, RecadosService>();
        builder.Services.AddScoped<RecadosService>();
        builder.Services.AddScoped<IRegimeTributacaoService, RegimeTributacaoService>();
        builder.Services.AddScoped<RegimeTributacaoService>();
        builder.Services.AddScoped<IReuniaoService, ReuniaoService>();
        builder.Services.AddScoped<ReuniaoService>();
        builder.Services.AddScoped<IReuniaoPessoasService, ReuniaoPessoasService>();
        builder.Services.AddScoped<ReuniaoPessoasService>();
        builder.Services.AddScoped<IRitoService, RitoService>();
        builder.Services.AddScoped<RitoService>();
        builder.Services.AddScoped<IServicosService, ServicosService>();
        builder.Services.AddScoped<ServicosService>();
        builder.Services.AddScoped<ISetorService, SetorService>();
        builder.Services.AddScoped<SetorService>();
        builder.Services.AddScoped<ISituacaoService, SituacaoService>();
        builder.Services.AddScoped<SituacaoService>();
        builder.Services.AddScoped<ISMSAliceService, SMSAliceService>();
        builder.Services.AddScoped<SMSAliceService>();
        builder.Services.AddScoped<IStatusAndamentoService, StatusAndamentoService>();
        builder.Services.AddScoped<StatusAndamentoService>();
        builder.Services.AddScoped<IStatusBiuService, StatusBiuService>();
        builder.Services.AddScoped<StatusBiuService>();
        builder.Services.AddScoped<IStatusHTrabService, StatusHTrabService>();
        builder.Services.AddScoped<StatusHTrabService>();
        builder.Services.AddScoped<IStatusInstanciaService, StatusInstanciaService>();
        builder.Services.AddScoped<StatusInstanciaService>();
        builder.Services.AddScoped<IStatusTarefasService, StatusTarefasService>();
        builder.Services.AddScoped<StatusTarefasService>();
        builder.Services.AddScoped<ITerceirosService, TerceirosService>();
        builder.Services.AddScoped<TerceirosService>();
        builder.Services.AddScoped<ITipoCompromissoService, TipoCompromissoService>();
        builder.Services.AddScoped<TipoCompromissoService>();
        builder.Services.AddScoped<ITipoContatoCRMService, TipoContatoCRMService>();
        builder.Services.AddScoped<TipoContatoCRMService>();
        builder.Services.AddScoped<ITipoEMailService, TipoEMailService>();
        builder.Services.AddScoped<TipoEMailService>();
        builder.Services.AddScoped<ITipoEnderecoService, TipoEnderecoService>();
        builder.Services.AddScoped<TipoEnderecoService>();
        builder.Services.AddScoped<ITipoEnderecoSistemaService, TipoEnderecoSistemaService>();
        builder.Services.AddScoped<TipoEnderecoSistemaService>();
        builder.Services.AddScoped<ITipoModeloDocumentoService, TipoModeloDocumentoService>();
        builder.Services.AddScoped<TipoModeloDocumentoService>();
        builder.Services.AddScoped<ITipoOrigemSucumbenciaService, TipoOrigemSucumbenciaService>();
        builder.Services.AddScoped<TipoOrigemSucumbenciaService>();
        builder.Services.AddScoped<ITipoProDespositoService, TipoProDespositoService>();
        builder.Services.AddScoped<TipoProDespositoService>();
        builder.Services.AddScoped<ITipoRecursoService, TipoRecursoService>();
        builder.Services.AddScoped<TipoRecursoService>();
        builder.Services.AddScoped<ITiposAcaoService, TiposAcaoService>();
        builder.Services.AddScoped<TiposAcaoService>();
        builder.Services.AddScoped<ITipoStatusBiuService, TipoStatusBiuService>();
        builder.Services.AddScoped<TipoStatusBiuService>();
        builder.Services.AddScoped<ITipoValorProcessoService, TipoValorProcessoService>();
        builder.Services.AddScoped<TipoValorProcessoService>();
        builder.Services.AddScoped<ITribEnderecosService, TribEnderecosService>();
        builder.Services.AddScoped<TribEnderecosService>();
        builder.Services.AddScoped<ITribunalService, TribunalService>();
        builder.Services.AddScoped<TribunalService>();
        builder.Services.AddScoped<IUFService, UFService>();
        builder.Services.AddScoped<UFService>();
        builder.Services.AddScoped<IUltimosProcessosService, UltimosProcessosService>();
        builder.Services.AddScoped<UltimosProcessosService>();
        builder.Services.AddScoped<IViaRecebimentoService, ViaRecebimentoService>();
        builder.Services.AddScoped<ViaRecebimentoService>();
        builder.Services.AddScoped<IAgendaRelatorioService, AgendaRelatorioService>();
        builder.Services.AddScoped<AgendaRelatorioService>();
        builder.Services.AddScoped<IAgendaSemanaService, AgendaSemanaService>();
        builder.Services.AddScoped<AgendaSemanaService>();
    }
}