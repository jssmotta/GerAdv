namespace MenphisSI.GerAdv.WarmUp;
/*
    // Quando houver novas tabelas tem que rodar, inclusive para todas as URIs
    // Executar uma única vez no Program.cs:
    // UriBaseTemplateDbo é o DBO modelo da aplicação (PIXBOLWFE, MDS, IBRADV, etc.)
    var appSettingsSection = builder.Configuration.GetSection("AppSettings");
    var appSettingsOptions = Options.Create(appSettingsSection.Get<AppSettings>());
    if (appSettingsOptions != null) awaitMenphisSI.GerAdv.WarmUp.InitializeWarmUp.WarmUpAuditor(appSettingsOptions);

*/
public class InitializeWarmUp
{
    public static async Task WarmUpAuditor(IOptions<AppSettings> appSettings)
    {
        var uri = appSettings.Value.UriBaseTemplateDbo;
        if (string.IsNullOrEmpty(uri))
            return;
        using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
        if (oCnn == null)
            return;
        await new Acao().WarmReadStringAuditor(uri, oCnn);
        await new Advogados().WarmReadStringAuditor(uri, oCnn);
        await new Agenda().WarmReadStringAuditor(uri, oCnn);
        await new Agenda2Agenda().WarmReadStringAuditor(uri, oCnn);
        await new AgendaFinanceiro().WarmReadStringAuditor(uri, oCnn);
        await new AgendaRepetir().WarmReadStringAuditor(uri, oCnn);
        await new AgendaStatus().WarmReadStringAuditor(uri, oCnn);
        await new AlarmSMS().WarmReadStringAuditor(uri, oCnn);
        await new Alertas().WarmReadStringAuditor(uri, oCnn);
        await new AndamentosMD().WarmReadStringAuditor(uri, oCnn);
        await new AnexamentoRegistros().WarmReadStringAuditor(uri, oCnn);
        await new Apenso().WarmReadStringAuditor(uri, oCnn);
        await new Apenso2().WarmReadStringAuditor(uri, oCnn);
        await new Area().WarmReadStringAuditor(uri, oCnn);
        await new Atividades().WarmReadStringAuditor(uri, oCnn);
        await new Auditor4K().WarmReadStringAuditor(uri, oCnn);
        await new BensClassificacao().WarmReadStringAuditor(uri, oCnn);
        await new BensMateriais().WarmReadStringAuditor(uri, oCnn);
        await new Cargos().WarmReadStringAuditor(uri, oCnn);
        await new CargosEsc().WarmReadStringAuditor(uri, oCnn);
        await new CargosEscClass().WarmReadStringAuditor(uri, oCnn);
        await new Cidade().WarmReadStringAuditor(uri, oCnn);
        await new Clientes().WarmReadStringAuditor(uri, oCnn);
        await new ClientesSocios().WarmReadStringAuditor(uri, oCnn);
        await new Colaboradores().WarmReadStringAuditor(uri, oCnn);
        await new ContaCorrente().WarmReadStringAuditor(uri, oCnn);
        await new ContatoCRM().WarmReadStringAuditor(uri, oCnn);
        await new ContatoCRMOperador().WarmReadStringAuditor(uri, oCnn);
        await new Contratos().WarmReadStringAuditor(uri, oCnn);
        await new DadosProcuracao().WarmReadStringAuditor(uri, oCnn);
        await new Diario2().WarmReadStringAuditor(uri, oCnn);
        await new DivisaoTribunal().WarmReadStringAuditor(uri, oCnn);
        await new DocsRecebidosItens().WarmReadStringAuditor(uri, oCnn);
        await new Documentos().WarmReadStringAuditor(uri, oCnn);
        await new EMPClassRiscos().WarmReadStringAuditor(uri, oCnn);
        await new Enderecos().WarmReadStringAuditor(uri, oCnn);
        await new EnderecoSistema().WarmReadStringAuditor(uri, oCnn);
        await new EnquadramentoEmpresa().WarmReadStringAuditor(uri, oCnn);
        await new Escritorios().WarmReadStringAuditor(uri, oCnn);
        await new EventoPrazoAgenda().WarmReadStringAuditor(uri, oCnn);
        await new Fase().WarmReadStringAuditor(uri, oCnn);
        await new Fornecedores().WarmReadStringAuditor(uri, oCnn);
        await new Foro().WarmReadStringAuditor(uri, oCnn);
        await new Funcao().WarmReadStringAuditor(uri, oCnn);
        await new Funcionarios().WarmReadStringAuditor(uri, oCnn);
        await new Graph().WarmReadStringAuditor(uri, oCnn);
        await new GruposEmpresas().WarmReadStringAuditor(uri, oCnn);
        await new GruposEmpresasCli().WarmReadStringAuditor(uri, oCnn);
        await new GUTAtividades().WarmReadStringAuditor(uri, oCnn);
        await new GUTAtividadesMatriz().WarmReadStringAuditor(uri, oCnn);
        await new GUTPeriodicidade().WarmReadStringAuditor(uri, oCnn);
        await new GUTPeriodicidadeStatus().WarmReadStringAuditor(uri, oCnn);
        await new GUTTipo().WarmReadStringAuditor(uri, oCnn);
        await new Historico().WarmReadStringAuditor(uri, oCnn);
        await new HonorariosDadosContrato().WarmReadStringAuditor(uri, oCnn);
        await new HorasTrab().WarmReadStringAuditor(uri, oCnn);
        await new Instancia().WarmReadStringAuditor(uri, oCnn);
        await new Justica().WarmReadStringAuditor(uri, oCnn);
        await new Ligacoes().WarmReadStringAuditor(uri, oCnn);
        await new LivroCaixa().WarmReadStringAuditor(uri, oCnn);
        await new LivroCaixaClientes().WarmReadStringAuditor(uri, oCnn);
        await new ModelosDocumentos().WarmReadStringAuditor(uri, oCnn);
        await new NECompromissos().WarmReadStringAuditor(uri, oCnn);
        await new NENotas().WarmReadStringAuditor(uri, oCnn);
        await new NEPalavrasChaves().WarmReadStringAuditor(uri, oCnn);
        await new Objetos().WarmReadStringAuditor(uri, oCnn);
        await new Operador().WarmReadStringAuditor(uri, oCnn);
        await new OperadorEMailPopup().WarmReadStringAuditor(uri, oCnn);
        await new Operadores().WarmReadStringAuditor(uri, oCnn);
        await new OperadorGrupo().WarmReadStringAuditor(uri, oCnn);
        await new OperadorGrupos().WarmReadStringAuditor(uri, oCnn);
        await new OperadorGruposAgenda().WarmReadStringAuditor(uri, oCnn);
        await new OperadorGruposAgendaOperadores().WarmReadStringAuditor(uri, oCnn);
        await new Oponentes().WarmReadStringAuditor(uri, oCnn);
        await new OponentesRepLegal().WarmReadStringAuditor(uri, oCnn);
        await new OutrasPartesCliente().WarmReadStringAuditor(uri, oCnn);
        await new Paises().WarmReadStringAuditor(uri, oCnn);
        await new ParceriaProc().WarmReadStringAuditor(uri, oCnn);
        await new ParteClienteOutras().WarmReadStringAuditor(uri, oCnn);
        await new Penhora().WarmReadStringAuditor(uri, oCnn);
        await new PenhoraStatus().WarmReadStringAuditor(uri, oCnn);
        await new PoderJudiciarioAssociado().WarmReadStringAuditor(uri, oCnn);
        await new PosicaoOutrasPartes().WarmReadStringAuditor(uri, oCnn);
        await new Precatoria().WarmReadStringAuditor(uri, oCnn);
        await new PreClientes().WarmReadStringAuditor(uri, oCnn);
        await new Prepostos().WarmReadStringAuditor(uri, oCnn);
        await new ProCDA().WarmReadStringAuditor(uri, oCnn);
        await new Processos().WarmReadStringAuditor(uri, oCnn);
        await new ProcessosObsReport().WarmReadStringAuditor(uri, oCnn);
        await new ProcessOutputRequest().WarmReadStringAuditor(uri, oCnn);
        await new ProDepositos().WarmReadStringAuditor(uri, oCnn);
        await new ProDespesas().WarmReadStringAuditor(uri, oCnn);
        await new ProObservacoes().WarmReadStringAuditor(uri, oCnn);
        await new ProProcuradores().WarmReadStringAuditor(uri, oCnn);
        await new ProResumos().WarmReadStringAuditor(uri, oCnn);
        await new ProSucumbencia().WarmReadStringAuditor(uri, oCnn);
        await new ProTipoBaixa().WarmReadStringAuditor(uri, oCnn);
        await new ProValores().WarmReadStringAuditor(uri, oCnn);
        await new Ramal().WarmReadStringAuditor(uri, oCnn);
        await new Recados().WarmReadStringAuditor(uri, oCnn);
        await new RegimeTributacao().WarmReadStringAuditor(uri, oCnn);
        await new Reuniao().WarmReadStringAuditor(uri, oCnn);
        await new ReuniaoPessoas().WarmReadStringAuditor(uri, oCnn);
        await new Rito().WarmReadStringAuditor(uri, oCnn);
        await new Servicos().WarmReadStringAuditor(uri, oCnn);
        await new Setor().WarmReadStringAuditor(uri, oCnn);
        await new Situacao().WarmReadStringAuditor(uri, oCnn);
        await new SMSAlice().WarmReadStringAuditor(uri, oCnn);
        await new StatusAndamento().WarmReadStringAuditor(uri, oCnn);
        await new StatusInstancia().WarmReadStringAuditor(uri, oCnn);
        await new StatusTarefas().WarmReadStringAuditor(uri, oCnn);
        await new Terceiros().WarmReadStringAuditor(uri, oCnn);
        await new TipoCompromisso().WarmReadStringAuditor(uri, oCnn);
        await new TipoContatoCRM().WarmReadStringAuditor(uri, oCnn);
        await new TipoEndereco().WarmReadStringAuditor(uri, oCnn);
        await new TipoEnderecoSistema().WarmReadStringAuditor(uri, oCnn);
        await new TipoModeloDocumento().WarmReadStringAuditor(uri, oCnn);
        await new TipoRecurso().WarmReadStringAuditor(uri, oCnn);
        await new TiposAcao().WarmReadStringAuditor(uri, oCnn);
        await new Tribunal().WarmReadStringAuditor(uri, oCnn);
        await new UF().WarmReadStringAuditor(uri, oCnn);
    }
}