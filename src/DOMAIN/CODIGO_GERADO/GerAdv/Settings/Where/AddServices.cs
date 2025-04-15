#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AddServices
{
    public static void Add(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAcaoWhere, Acao>();
        builder.Services.AddScoped<IAdvogadosWhere, Advogados>();
        builder.Services.AddScoped<IAlarmSMSWhere, AlarmSMS>();
        builder.Services.AddScoped<IAlertasWhere, Alertas>();
        builder.Services.AddScoped<IAndamentosMDWhere, AndamentosMD>();
        builder.Services.AddScoped<IAreaWhere, Area>();
        builder.Services.AddScoped<IAtividadesWhere, Atividades>();
        builder.Services.AddScoped<IAuditor4KWhere, Auditor4K>();
        builder.Services.AddScoped<IBensClassificacaoWhere, BensClassificacao>();
        builder.Services.AddScoped<IBensMateriaisWhere, BensMateriais>();
        builder.Services.AddScoped<ICargosWhere, Cargos>();
        builder.Services.AddScoped<ICargosEscWhere, CargosEsc>();
        builder.Services.AddScoped<ICargosEscClassWhere, CargosEscClass>();
        builder.Services.AddScoped<ICidadeWhere, Cidade>();
        builder.Services.AddScoped<IClientesWhere, Clientes>();
        builder.Services.AddScoped<IClientesSociosWhere, ClientesSocios>();
        builder.Services.AddScoped<IColaboradoresWhere, Colaboradores>();
        builder.Services.AddScoped<IDiario2Where, Diario2>();
        builder.Services.AddScoped<IDocsRecebidosItensWhere, DocsRecebidosItens>();
        builder.Services.AddScoped<IEMPClassRiscosWhere, EMPClassRiscos>();
        builder.Services.AddScoped<IEnderecosWhere, Enderecos>();
        builder.Services.AddScoped<IEnquadramentoEmpresaWhere, EnquadramentoEmpresa>();
        builder.Services.AddScoped<IEscritoriosWhere, Escritorios>();
        builder.Services.AddScoped<IEventoPrazoAgendaWhere, EventoPrazoAgenda>();
        builder.Services.AddScoped<IFaseWhere, Fase>();
        builder.Services.AddScoped<IFornecedoresWhere, Fornecedores>();
        builder.Services.AddScoped<IForoWhere, Foro>();
        builder.Services.AddScoped<IFuncaoWhere, Funcao>();
        builder.Services.AddScoped<IFuncionariosWhere, Funcionarios>();
        builder.Services.AddScoped<IGruposEmpresasWhere, GruposEmpresas>();
        builder.Services.AddScoped<IGUTAtividadesWhere, GUTAtividades>();
        builder.Services.AddScoped<IGUTMatrizWhere, GUTMatriz>();
        builder.Services.AddScoped<IGUTPeriodicidadeWhere, GUTPeriodicidade>();
        builder.Services.AddScoped<IGUTTipoWhere, GUTTipo>();
        builder.Services.AddScoped<IInstanciaWhere, Instancia>();
        builder.Services.AddScoped<IJusticaWhere, Justica>();
        builder.Services.AddScoped<ILigacoesWhere, Ligacoes>();
        builder.Services.AddScoped<IModelosDocumentosWhere, ModelosDocumentos>();
        builder.Services.AddScoped<INENotasWhere, NENotas>();
        builder.Services.AddScoped<INEPalavrasChavesWhere, NEPalavrasChaves>();
        builder.Services.AddScoped<IObjetosWhere, Objetos>();
        builder.Services.AddScoped<IOperadorWhere, Operador>();
        builder.Services.AddScoped<IOperadorEMailPopupWhere, OperadorEMailPopup>();
        builder.Services.AddScoped<IOperadoresWhere, Operadores>();
        builder.Services.AddScoped<IOperadorGruposWhere, OperadorGrupos>();
        builder.Services.AddScoped<IOperadorGruposAgendaWhere, OperadorGruposAgenda>();
        builder.Services.AddScoped<IOponentesWhere, Oponentes>();
        builder.Services.AddScoped<IOponentesRepLegalWhere, OponentesRepLegal>();
        builder.Services.AddScoped<IOutrasPartesClienteWhere, OutrasPartesCliente>();
        builder.Services.AddScoped<IPaisesWhere, Paises>();
        builder.Services.AddScoped<IPenhoraWhere, Penhora>();
        builder.Services.AddScoped<IPenhoraStatusWhere, PenhoraStatus>();
        builder.Services.AddScoped<IPosicaoOutrasPartesWhere, PosicaoOutrasPartes>();
        builder.Services.AddScoped<IPreClientesWhere, PreClientes>();
        builder.Services.AddScoped<IPrepostosWhere, Prepostos>();
        builder.Services.AddScoped<IProCDAWhere, ProCDA>();
        builder.Services.AddScoped<IProcessosWhere, Processos>();
        builder.Services.AddScoped<IProcessOutputEngineWhere, ProcessOutputEngine>();
        builder.Services.AddScoped<IProcessOutPutIDsWhere, ProcessOutPutIDs>();
        builder.Services.AddScoped<IProcessOutputSourcesWhere, ProcessOutputSources>();
        builder.Services.AddScoped<IProObservacoesWhere, ProObservacoes>();
        builder.Services.AddScoped<IProProcuradoresWhere, ProProcuradores>();
        builder.Services.AddScoped<IProSucumbenciaWhere, ProSucumbencia>();
        builder.Services.AddScoped<IProTipoBaixaWhere, ProTipoBaixa>();
        builder.Services.AddScoped<IRamalWhere, Ramal>();
        builder.Services.AddScoped<IRegimeTributacaoWhere, RegimeTributacao>();
        builder.Services.AddScoped<IRitoWhere, Rito>();
        builder.Services.AddScoped<IServicosWhere, Servicos>();
        builder.Services.AddScoped<ISetorWhere, Setor>();
        builder.Services.AddScoped<ISMSAliceWhere, SMSAlice>();
        builder.Services.AddScoped<IStatusAndamentoWhere, StatusAndamento>();
        builder.Services.AddScoped<IStatusBiuWhere, StatusBiu>();
        builder.Services.AddScoped<IStatusHTrabWhere, StatusHTrab>();
        builder.Services.AddScoped<IStatusInstanciaWhere, StatusInstancia>();
        builder.Services.AddScoped<IStatusTarefasWhere, StatusTarefas>();
        builder.Services.AddScoped<ITerceirosWhere, Terceiros>();
        builder.Services.AddScoped<ITipoCompromissoWhere, TipoCompromisso>();
        builder.Services.AddScoped<ITipoContatoCRMWhere, TipoContatoCRM>();
        builder.Services.AddScoped<ITipoEMailWhere, TipoEMail>();
        builder.Services.AddScoped<ITipoEnderecoWhere, TipoEndereco>();
        builder.Services.AddScoped<ITipoEnderecoSistemaWhere, TipoEnderecoSistema>();
        builder.Services.AddScoped<ITipoModeloDocumentoWhere, TipoModeloDocumento>();
        builder.Services.AddScoped<ITipoOrigemSucumbenciaWhere, TipoOrigemSucumbencia>();
        builder.Services.AddScoped<ITipoProDespositoWhere, TipoProDesposito>();
        builder.Services.AddScoped<ITipoRecursoWhere, TipoRecurso>();
        builder.Services.AddScoped<ITiposAcaoWhere, TiposAcao>();
        builder.Services.AddScoped<ITipoStatusBiuWhere, TipoStatusBiu>();
        builder.Services.AddScoped<ITipoValorProcessoWhere, TipoValorProcesso>();
        builder.Services.AddScoped<ITribunalWhere, Tribunal>();
        builder.Services.AddScoped<IUFWhere, UF>();
        builder.Services.AddScoped<IViaRecebimentoWhere, ViaRecebimento>();
    }
}