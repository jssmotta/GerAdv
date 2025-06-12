#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AddServices
{
    public static void Add(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IAcaoWhere, Acao>();
        builder.Services.AddSingleton<IAdvogadosWhere, Advogados>();
        builder.Services.AddSingleton<IAlarmSMSWhere, AlarmSMS>();
        builder.Services.AddSingleton<IAlertasWhere, Alertas>();
        builder.Services.AddSingleton<IAndamentosMDWhere, AndamentosMD>();
        builder.Services.AddSingleton<IAreaWhere, Area>();
        builder.Services.AddSingleton<IAtividadesWhere, Atividades>();
        builder.Services.AddSingleton<IAuditor4KWhere, Auditor4K>();
        builder.Services.AddSingleton<IBensClassificacaoWhere, BensClassificacao>();
        builder.Services.AddSingleton<IBensMateriaisWhere, BensMateriais>();
        builder.Services.AddSingleton<ICargosWhere, Cargos>();
        builder.Services.AddSingleton<ICargosEscWhere, CargosEsc>();
        builder.Services.AddSingleton<ICargosEscClassWhere, CargosEscClass>();
        builder.Services.AddSingleton<ICidadeWhere, Cidade>();
        builder.Services.AddSingleton<IClientesWhere, Clientes>();
        builder.Services.AddSingleton<IClientesSociosWhere, ClientesSocios>();
        builder.Services.AddSingleton<IColaboradoresWhere, Colaboradores>();
        builder.Services.AddSingleton<IDiario2Where, Diario2>();
        builder.Services.AddSingleton<IDocsRecebidosItensWhere, DocsRecebidosItens>();
        builder.Services.AddSingleton<IEMPClassRiscosWhere, EMPClassRiscos>();
        builder.Services.AddSingleton<IEnderecosWhere, Enderecos>();
        builder.Services.AddSingleton<IEnquadramentoEmpresaWhere, EnquadramentoEmpresa>();
        builder.Services.AddSingleton<IEscritoriosWhere, Escritorios>();
        builder.Services.AddSingleton<IEventoPrazoAgendaWhere, EventoPrazoAgenda>();
        builder.Services.AddSingleton<IFaseWhere, Fase>();
        builder.Services.AddSingleton<IFornecedoresWhere, Fornecedores>();
        builder.Services.AddSingleton<IForoWhere, Foro>();
        builder.Services.AddSingleton<IFuncaoWhere, Funcao>();
        builder.Services.AddSingleton<IFuncionariosWhere, Funcionarios>();
        builder.Services.AddSingleton<IGruposEmpresasWhere, GruposEmpresas>();
        builder.Services.AddSingleton<IGUTAtividadesWhere, GUTAtividades>();
        builder.Services.AddSingleton<IGUTMatrizWhere, GUTMatriz>();
        builder.Services.AddSingleton<IGUTPeriodicidadeWhere, GUTPeriodicidade>();
        builder.Services.AddSingleton<IGUTTipoWhere, GUTTipo>();
        builder.Services.AddSingleton<IInstanciaWhere, Instancia>();
        builder.Services.AddSingleton<IJusticaWhere, Justica>();
        builder.Services.AddSingleton<ILigacoesWhere, Ligacoes>();
        builder.Services.AddSingleton<IModelosDocumentosWhere, ModelosDocumentos>();
        builder.Services.AddSingleton<INENotasWhere, NENotas>();
        builder.Services.AddSingleton<INEPalavrasChavesWhere, NEPalavrasChaves>();
        builder.Services.AddSingleton<IObjetosWhere, Objetos>();
        builder.Services.AddSingleton<IOperadorWhere, Operador>();
        builder.Services.AddSingleton<IOperadorEMailPopupWhere, OperadorEMailPopup>();
        builder.Services.AddSingleton<IOperadoresWhere, Operadores>();
        builder.Services.AddSingleton<IOperadorGruposWhere, OperadorGrupos>();
        builder.Services.AddSingleton<IOperadorGruposAgendaWhere, OperadorGruposAgenda>();
        builder.Services.AddSingleton<IOponentesWhere, Oponentes>();
        builder.Services.AddSingleton<IOponentesRepLegalWhere, OponentesRepLegal>();
        builder.Services.AddSingleton<IOutrasPartesClienteWhere, OutrasPartesCliente>();
        builder.Services.AddSingleton<IPaisesWhere, Paises>();
        builder.Services.AddSingleton<IPenhoraWhere, Penhora>();
        builder.Services.AddSingleton<IPenhoraStatusWhere, PenhoraStatus>();
        builder.Services.AddSingleton<IPosicaoOutrasPartesWhere, PosicaoOutrasPartes>();
        builder.Services.AddSingleton<IPreClientesWhere, PreClientes>();
        builder.Services.AddSingleton<IPrepostosWhere, Prepostos>();
        builder.Services.AddSingleton<IProCDAWhere, ProCDA>();
        builder.Services.AddSingleton<IProcessosWhere, Processos>();
        builder.Services.AddSingleton<IProcessOutputEngineWhere, ProcessOutputEngine>();
        builder.Services.AddSingleton<IProcessOutPutIDsWhere, ProcessOutPutIDs>();
        builder.Services.AddSingleton<IProcessOutputSourcesWhere, ProcessOutputSources>();
        builder.Services.AddSingleton<IProObservacoesWhere, ProObservacoes>();
        builder.Services.AddSingleton<IProProcuradoresWhere, ProProcuradores>();
        builder.Services.AddSingleton<IProSucumbenciaWhere, ProSucumbencia>();
        builder.Services.AddSingleton<IProTipoBaixaWhere, ProTipoBaixa>();
        builder.Services.AddSingleton<IRamalWhere, Ramal>();
        builder.Services.AddSingleton<IRegimeTributacaoWhere, RegimeTributacao>();
        builder.Services.AddSingleton<IRitoWhere, Rito>();
        builder.Services.AddSingleton<IServicosWhere, Servicos>();
        builder.Services.AddSingleton<ISetorWhere, Setor>();
        builder.Services.AddSingleton<ISMSAliceWhere, SMSAlice>();
        builder.Services.AddSingleton<IStatusAndamentoWhere, StatusAndamento>();
        builder.Services.AddSingleton<IStatusBiuWhere, StatusBiu>();
        builder.Services.AddSingleton<IStatusHTrabWhere, StatusHTrab>();
        builder.Services.AddSingleton<IStatusInstanciaWhere, StatusInstancia>();
        builder.Services.AddSingleton<IStatusTarefasWhere, StatusTarefas>();
        builder.Services.AddSingleton<ITerceirosWhere, Terceiros>();
        builder.Services.AddSingleton<ITipoCompromissoWhere, TipoCompromisso>();
        builder.Services.AddSingleton<ITipoContatoCRMWhere, TipoContatoCRM>();
        builder.Services.AddSingleton<ITipoEMailWhere, TipoEMail>();
        builder.Services.AddSingleton<ITipoEnderecoWhere, TipoEndereco>();
        builder.Services.AddSingleton<ITipoEnderecoSistemaWhere, TipoEnderecoSistema>();
        builder.Services.AddSingleton<ITipoModeloDocumentoWhere, TipoModeloDocumento>();
        builder.Services.AddSingleton<ITipoOrigemSucumbenciaWhere, TipoOrigemSucumbencia>();
        builder.Services.AddSingleton<ITipoProDespositoWhere, TipoProDesposito>();
        builder.Services.AddSingleton<ITipoRecursoWhere, TipoRecurso>();
        builder.Services.AddSingleton<ITiposAcaoWhere, TiposAcao>();
        builder.Services.AddSingleton<ITipoStatusBiuWhere, TipoStatusBiu>();
        builder.Services.AddSingleton<ITipoValorProcessoWhere, TipoValorProcesso>();
        builder.Services.AddSingleton<ITribunalWhere, Tribunal>();
        builder.Services.AddSingleton<IUFWhere, UF>();
        builder.Services.AddSingleton<IViaRecebimentoWhere, ViaRecebimento>();
    }
}