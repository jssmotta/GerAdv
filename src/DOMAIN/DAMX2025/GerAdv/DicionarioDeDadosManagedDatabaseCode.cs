#if (!MenphisSI_SG_GerAdv_DicOff)
/*
[Menphis - Sistemas Inteligentes]
Menphis Developer Family
Manager Structure
Dicionário de dados gerado automaticamente pelo DEVOURER

[Family Information]
MPTRKID=Menphis_CS_CSTGenDataAccesClass
Copyright©= 2000-PARA SEMPRE - Menphis - Sistemas Inteligentes
*/
using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public class DicionarioDeDadosManagedDatabaseCode : IDicManager
{
    public string NameSpace() => nameof(GerAdv);
    public string DevourerBuildID => "2024";

    [Serializable]
    public enum DicionarioDeDadosTabelas
    {
        Acao = 1,
        Advogados = 2,
        Agenda = 3,
        Agenda2Agenda = 4,
        AgendaFinanceiro = 5,
        AgendaQuem = 6,
        AgendaRecords = 7,
        AgendaRepetir = 8,
        AgendaRepetirDias = 9,
        AgendaStatus = 10,
        AlarmSMS = 11,
        Alertas = 12,
        AlertasEnviados = 13,
        AndamentosMD = 14,
        AndComp = 15,
        AnexamentoRegistros = 16,
        Apenso = 17,
        Apenso2 = 18,
        Area = 19,
        AreasJustica = 20,
        Atividades = 21,
        Auditor4K = 22,
        BensClassificacao = 23,
        BensMateriais = 24,
        Cargos = 25,
        CargosEsc = 26,
        CargosEscClass = 27,
        Cidade = 28,
        Clientes = 29,
        ClientesSocios = 30,
        Colaboradores = 31,
        ContaCorrente = 32,
        ContatoCRM = 33,
        ContatoCRMOperador = 34,
        ContatoCRMView = 35,
        Contratos = 36,
        DadosProcuracao = 37,
        Diario2 = 38,
        DivisaoTribunal = 39,
        DocsRecebidosItens = 40,
        Documentos = 41,
        EMPClassRiscos = 42,
        Enderecos = 43,
        EnderecoSistema = 44,
        EndTit = 45,
        EnquadramentoEmpresa = 46,
        Escritorios = 47,
        EventoPrazoAgenda = 48,
        Fase = 49,
        Fornecedores = 50,
        Foro = 51,
        Funcao = 52,
        Funcionarios = 53,
        Graph = 54,
        GruposEmpresas = 55,
        GruposEmpresasCli = 56,
        GUTAtividades = 57,
        GUTAtividadesMatriz = 58,
        GUTMatriz = 59,
        GUTPeriodicidade = 60,
        GUTPeriodicidadeStatus = 61,
        GUTTipo = 62,
        Historico = 63,
        HonorariosDadosContrato = 64,
        HorasTrab = 65,
        Instancia = 66,
        Justica = 67,
        Ligacoes = 68,
        LivroCaixa = 69,
        LivroCaixaClientes = 70,
        ModelosDocumentos = 71,
        NECompromissos = 72,
        NENotas = 73,
        NEPalavrasChaves = 74,
        Objetos = 75,
        Operador = 76,
        OperadorEMailPopup = 77,
        Operadores = 78,
        OperadorGrupo = 79,
        OperadorGrupos = 80,
        OperadorGruposAgenda = 81,
        OperadorGruposAgendaOperadores = 82,
        Oponentes = 83,
        OponentesRepLegal = 84,
        OutrasPartesCliente = 85,
        Paises = 86,
        ParceriaProc = 87,
        ParteCliente = 88,
        ParteClienteOutras = 89,
        ParteOponente = 90,
        Penhora = 91,
        PenhoraStatus = 92,
        PoderJudiciarioAssociado = 93,
        PontoVirtual = 94,
        PontoVirtualAcessos = 95,
        PosicaoOutrasPartes = 96,
        Precatoria = 97,
        PreClientes = 98,
        Prepostos = 99,
        ProBarCODE = 100,
        ProCDA = 101,
        Processos = 102,
        ProcessosObsReport = 103,
        ProcessosParados = 104,
        ProcessOutputEngine = 105,
        ProcessOutPutIDs = 106,
        ProcessOutputRequest = 107,
        ProcessOutputSources = 108,
        ProDepositos = 109,
        ProDespesas = 110,
        ProObservacoes = 111,
        ProPartes = 112,
        ProProcuradores = 113,
        ProResumos = 114,
        ProSucumbencia = 115,
        ProTipoBaixa = 116,
        ProValores = 117,
        Ramal = 118,
        Recados = 119,
        RegimeTributacao = 120,
        Reuniao = 121,
        ReuniaoPessoas = 122,
        Rito = 123,
        Servicos = 124,
        Setor = 125,
        Situacao = 126,
        SMSAlice = 127,
        StatusAndamento = 128,
        StatusBiu = 129,
        StatusHTrab = 130,
        StatusInstancia = 131,
        StatusTarefas = 132,
        Terceiros = 133,
        TipoCompromisso = 134,
        TipoContatoCRM = 135,
        TipoEMail = 136,
        TipoEndereco = 137,
        TipoEnderecoSistema = 138,
        TipoModeloDocumento = 139,
        TipoOrigemSucumbencia = 140,
        TipoProDesposito = 141,
        TipoRecurso = 142,
        TiposAcao = 143,
        TipoStatusBiu = 144,
        TipoValorProcesso = 145,
        TribEnderecos = 146,
        Tribunal = 147,
        UF = 148,
        UltimosProcessos = 149,
        ViaRecebimento = 150,
        AgendaRelatorio = 151,
        AgendaSemana = 152
    }

    public int IdTabelaByNome(string nome) => nome switch
    {
        DBAcao.PTabelaNome => 1,
        DBAdvogados.PTabelaNome => 2,
        DBAgenda.PTabelaNome => 3,
        DBAgenda2Agenda.PTabelaNome => 4,
        DBAgendaFinanceiro.PTabelaNome => 5,
        DBAgendaQuem.PTabelaNome => 6,
        DBAgendaRecords.PTabelaNome => 7,
        DBAgendaRepetir.PTabelaNome => 8,
        DBAgendaRepetirDias.PTabelaNome => 9,
        DBAgendaStatus.PTabelaNome => 10,
        DBAlarmSMS.PTabelaNome => 11,
        DBAlertas.PTabelaNome => 12,
        DBAlertasEnviados.PTabelaNome => 13,
        DBAndamentosMD.PTabelaNome => 14,
        DBAndComp.PTabelaNome => 15,
        DBAnexamentoRegistros.PTabelaNome => 16,
        DBApenso.PTabelaNome => 17,
        DBApenso2.PTabelaNome => 18,
        DBArea.PTabelaNome => 19,
        DBAreasJustica.PTabelaNome => 20,
        DBAtividades.PTabelaNome => 21,
        DBAuditor4K.PTabelaNome => 22,
        DBBensClassificacao.PTabelaNome => 23,
        DBBensMateriais.PTabelaNome => 24,
        DBCargos.PTabelaNome => 25,
        DBCargosEsc.PTabelaNome => 26,
        DBCargosEscClass.PTabelaNome => 27,
        DBCidade.PTabelaNome => 28,
        DBClientes.PTabelaNome => 29,
        DBClientesSocios.PTabelaNome => 30,
        DBColaboradores.PTabelaNome => 31,
        DBContaCorrente.PTabelaNome => 32,
        DBContatoCRM.PTabelaNome => 33,
        DBContatoCRMOperador.PTabelaNome => 34,
        DBContatoCRMView.PTabelaNome => 35,
        DBContratos.PTabelaNome => 36,
        DBDadosProcuracao.PTabelaNome => 37,
        DBDiario2.PTabelaNome => 38,
        DBDivisaoTribunal.PTabelaNome => 39,
        DBDocsRecebidosItens.PTabelaNome => 40,
        DBDocumentos.PTabelaNome => 41,
        DBEMPClassRiscos.PTabelaNome => 42,
        DBEnderecos.PTabelaNome => 43,
        DBEnderecoSistema.PTabelaNome => 44,
        DBEndTit.PTabelaNome => 45,
        DBEnquadramentoEmpresa.PTabelaNome => 46,
        DBEscritorios.PTabelaNome => 47,
        DBEventoPrazoAgenda.PTabelaNome => 48,
        DBFase.PTabelaNome => 49,
        DBFornecedores.PTabelaNome => 50,
        DBForo.PTabelaNome => 51,
        DBFuncao.PTabelaNome => 52,
        DBFuncionarios.PTabelaNome => 53,
        DBGraph.PTabelaNome => 54,
        DBGruposEmpresas.PTabelaNome => 55,
        DBGruposEmpresasCli.PTabelaNome => 56,
        DBGUTAtividades.PTabelaNome => 57,
        DBGUTAtividadesMatriz.PTabelaNome => 58,
        DBGUTMatriz.PTabelaNome => 59,
        DBGUTPeriodicidade.PTabelaNome => 60,
        DBGUTPeriodicidadeStatus.PTabelaNome => 61,
        DBGUTTipo.PTabelaNome => 62,
        DBHistorico.PTabelaNome => 63,
        DBHonorariosDadosContrato.PTabelaNome => 64,
        DBHorasTrab.PTabelaNome => 65,
        DBInstancia.PTabelaNome => 66,
        DBJustica.PTabelaNome => 67,
        DBLigacoes.PTabelaNome => 68,
        DBLivroCaixa.PTabelaNome => 69,
        DBLivroCaixaClientes.PTabelaNome => 70,
        DBModelosDocumentos.PTabelaNome => 71,
        DBNECompromissos.PTabelaNome => 72,
        DBNENotas.PTabelaNome => 73,
        DBNEPalavrasChaves.PTabelaNome => 74,
        DBObjetos.PTabelaNome => 75,
        DBOperador.PTabelaNome => 76,
        DBOperadorEMailPopup.PTabelaNome => 77,
        DBOperadores.PTabelaNome => 78,
        DBOperadorGrupo.PTabelaNome => 79,
        DBOperadorGrupos.PTabelaNome => 80,
        DBOperadorGruposAgenda.PTabelaNome => 81,
        DBOperadorGruposAgendaOperadores.PTabelaNome => 82,
        DBOponentes.PTabelaNome => 83,
        DBOponentesRepLegal.PTabelaNome => 84,
        DBOutrasPartesCliente.PTabelaNome => 85,
        DBPaises.PTabelaNome => 86,
        DBParceriaProc.PTabelaNome => 87,
        DBParteCliente.PTabelaNome => 88,
        DBParteClienteOutras.PTabelaNome => 89,
        DBParteOponente.PTabelaNome => 90,
        DBPenhora.PTabelaNome => 91,
        DBPenhoraStatus.PTabelaNome => 92,
        DBPoderJudiciarioAssociado.PTabelaNome => 93,
        DBPontoVirtual.PTabelaNome => 94,
        DBPontoVirtualAcessos.PTabelaNome => 95,
        DBPosicaoOutrasPartes.PTabelaNome => 96,
        DBPrecatoria.PTabelaNome => 97,
        DBPreClientes.PTabelaNome => 98,
        DBPrepostos.PTabelaNome => 99,
        DBProBarCODE.PTabelaNome => 100,
        DBProCDA.PTabelaNome => 101,
        DBProcessos.PTabelaNome => 102,
        DBProcessosObsReport.PTabelaNome => 103,
        DBProcessosParados.PTabelaNome => 104,
        DBProcessOutputEngine.PTabelaNome => 105,
        DBProcessOutPutIDs.PTabelaNome => 106,
        DBProcessOutputRequest.PTabelaNome => 107,
        DBProcessOutputSources.PTabelaNome => 108,
        DBProDepositos.PTabelaNome => 109,
        DBProDespesas.PTabelaNome => 110,
        DBProObservacoes.PTabelaNome => 111,
        DBProPartes.PTabelaNome => 112,
        DBProProcuradores.PTabelaNome => 113,
        DBProResumos.PTabelaNome => 114,
        DBProSucumbencia.PTabelaNome => 115,
        DBProTipoBaixa.PTabelaNome => 116,
        DBProValores.PTabelaNome => 117,
        DBRamal.PTabelaNome => 118,
        DBRecados.PTabelaNome => 119,
        DBRegimeTributacao.PTabelaNome => 120,
        DBReuniao.PTabelaNome => 121,
        DBReuniaoPessoas.PTabelaNome => 122,
        DBRito.PTabelaNome => 123,
        DBServicos.PTabelaNome => 124,
        DBSetor.PTabelaNome => 125,
        DBSituacao.PTabelaNome => 126,
        DBSMSAlice.PTabelaNome => 127,
        DBStatusAndamento.PTabelaNome => 128,
        DBStatusBiu.PTabelaNome => 129,
        DBStatusHTrab.PTabelaNome => 130,
        DBStatusInstancia.PTabelaNome => 131,
        DBStatusTarefas.PTabelaNome => 132,
        DBTerceiros.PTabelaNome => 133,
        DBTipoCompromisso.PTabelaNome => 134,
        DBTipoContatoCRM.PTabelaNome => 135,
        DBTipoEMail.PTabelaNome => 136,
        DBTipoEndereco.PTabelaNome => 137,
        DBTipoEnderecoSistema.PTabelaNome => 138,
        DBTipoModeloDocumento.PTabelaNome => 139,
        DBTipoOrigemSucumbencia.PTabelaNome => 140,
        DBTipoProDesposito.PTabelaNome => 141,
        DBTipoRecurso.PTabelaNome => 142,
        DBTiposAcao.PTabelaNome => 143,
        DBTipoStatusBiu.PTabelaNome => 144,
        DBTipoValorProcesso.PTabelaNome => 145,
        DBTribEnderecos.PTabelaNome => 146,
        DBTribunal.PTabelaNome => 147,
        DBUF.PTabelaNome => 148,
        DBUltimosProcessos.PTabelaNome => 149,
        DBViaRecebimento.PTabelaNome => 150,
        DBAgendaRelatorio.PTabelaNome => 151,
        DBAgendaSemana.PTabelaNome => 152,
        _ => 0
    };
    public string NomeTabelaByEnum(int idTable) => idTable switch
    {
        1 => DBAcao.PTabelaNome,
        2 => DBAdvogados.PTabelaNome,
        3 => DBAgenda.PTabelaNome,
        4 => DBAgenda2Agenda.PTabelaNome,
        5 => DBAgendaFinanceiro.PTabelaNome,
        6 => DBAgendaQuem.PTabelaNome,
        7 => DBAgendaRecords.PTabelaNome,
        8 => DBAgendaRepetir.PTabelaNome,
        9 => DBAgendaRepetirDias.PTabelaNome,
        10 => DBAgendaStatus.PTabelaNome,
        11 => DBAlarmSMS.PTabelaNome,
        12 => DBAlertas.PTabelaNome,
        13 => DBAlertasEnviados.PTabelaNome,
        14 => DBAndamentosMD.PTabelaNome,
        15 => DBAndComp.PTabelaNome,
        16 => DBAnexamentoRegistros.PTabelaNome,
        17 => DBApenso.PTabelaNome,
        18 => DBApenso2.PTabelaNome,
        19 => DBArea.PTabelaNome,
        20 => DBAreasJustica.PTabelaNome,
        21 => DBAtividades.PTabelaNome,
        22 => DBAuditor4K.PTabelaNome,
        23 => DBBensClassificacao.PTabelaNome,
        24 => DBBensMateriais.PTabelaNome,
        25 => DBCargos.PTabelaNome,
        26 => DBCargosEsc.PTabelaNome,
        27 => DBCargosEscClass.PTabelaNome,
        28 => DBCidade.PTabelaNome,
        29 => DBClientes.PTabelaNome,
        30 => DBClientesSocios.PTabelaNome,
        31 => DBColaboradores.PTabelaNome,
        32 => DBContaCorrente.PTabelaNome,
        33 => DBContatoCRM.PTabelaNome,
        34 => DBContatoCRMOperador.PTabelaNome,
        35 => DBContatoCRMView.PTabelaNome,
        36 => DBContratos.PTabelaNome,
        37 => DBDadosProcuracao.PTabelaNome,
        38 => DBDiario2.PTabelaNome,
        39 => DBDivisaoTribunal.PTabelaNome,
        40 => DBDocsRecebidosItens.PTabelaNome,
        41 => DBDocumentos.PTabelaNome,
        42 => DBEMPClassRiscos.PTabelaNome,
        43 => DBEnderecos.PTabelaNome,
        44 => DBEnderecoSistema.PTabelaNome,
        45 => DBEndTit.PTabelaNome,
        46 => DBEnquadramentoEmpresa.PTabelaNome,
        47 => DBEscritorios.PTabelaNome,
        48 => DBEventoPrazoAgenda.PTabelaNome,
        49 => DBFase.PTabelaNome,
        50 => DBFornecedores.PTabelaNome,
        51 => DBForo.PTabelaNome,
        52 => DBFuncao.PTabelaNome,
        53 => DBFuncionarios.PTabelaNome,
        54 => DBGraph.PTabelaNome,
        55 => DBGruposEmpresas.PTabelaNome,
        56 => DBGruposEmpresasCli.PTabelaNome,
        57 => DBGUTAtividades.PTabelaNome,
        58 => DBGUTAtividadesMatriz.PTabelaNome,
        59 => DBGUTMatriz.PTabelaNome,
        60 => DBGUTPeriodicidade.PTabelaNome,
        61 => DBGUTPeriodicidadeStatus.PTabelaNome,
        62 => DBGUTTipo.PTabelaNome,
        63 => DBHistorico.PTabelaNome,
        64 => DBHonorariosDadosContrato.PTabelaNome,
        65 => DBHorasTrab.PTabelaNome,
        66 => DBInstancia.PTabelaNome,
        67 => DBJustica.PTabelaNome,
        68 => DBLigacoes.PTabelaNome,
        69 => DBLivroCaixa.PTabelaNome,
        70 => DBLivroCaixaClientes.PTabelaNome,
        71 => DBModelosDocumentos.PTabelaNome,
        72 => DBNECompromissos.PTabelaNome,
        73 => DBNENotas.PTabelaNome,
        74 => DBNEPalavrasChaves.PTabelaNome,
        75 => DBObjetos.PTabelaNome,
        76 => DBOperador.PTabelaNome,
        77 => DBOperadorEMailPopup.PTabelaNome,
        78 => DBOperadores.PTabelaNome,
        79 => DBOperadorGrupo.PTabelaNome,
        80 => DBOperadorGrupos.PTabelaNome,
        81 => DBOperadorGruposAgenda.PTabelaNome,
        82 => DBOperadorGruposAgendaOperadores.PTabelaNome,
        83 => DBOponentes.PTabelaNome,
        84 => DBOponentesRepLegal.PTabelaNome,
        85 => DBOutrasPartesCliente.PTabelaNome,
        86 => DBPaises.PTabelaNome,
        87 => DBParceriaProc.PTabelaNome,
        88 => DBParteCliente.PTabelaNome,
        89 => DBParteClienteOutras.PTabelaNome,
        90 => DBParteOponente.PTabelaNome,
        91 => DBPenhora.PTabelaNome,
        92 => DBPenhoraStatus.PTabelaNome,
        93 => DBPoderJudiciarioAssociado.PTabelaNome,
        94 => DBPontoVirtual.PTabelaNome,
        95 => DBPontoVirtualAcessos.PTabelaNome,
        96 => DBPosicaoOutrasPartes.PTabelaNome,
        97 => DBPrecatoria.PTabelaNome,
        98 => DBPreClientes.PTabelaNome,
        99 => DBPrepostos.PTabelaNome,
        100 => DBProBarCODE.PTabelaNome,
        101 => DBProCDA.PTabelaNome,
        102 => DBProcessos.PTabelaNome,
        103 => DBProcessosObsReport.PTabelaNome,
        104 => DBProcessosParados.PTabelaNome,
        105 => DBProcessOutputEngine.PTabelaNome,
        106 => DBProcessOutPutIDs.PTabelaNome,
        107 => DBProcessOutputRequest.PTabelaNome,
        108 => DBProcessOutputSources.PTabelaNome,
        109 => DBProDepositos.PTabelaNome,
        110 => DBProDespesas.PTabelaNome,
        111 => DBProObservacoes.PTabelaNome,
        112 => DBProPartes.PTabelaNome,
        113 => DBProProcuradores.PTabelaNome,
        114 => DBProResumos.PTabelaNome,
        115 => DBProSucumbencia.PTabelaNome,
        116 => DBProTipoBaixa.PTabelaNome,
        117 => DBProValores.PTabelaNome,
        118 => DBRamal.PTabelaNome,
        119 => DBRecados.PTabelaNome,
        120 => DBRegimeTributacao.PTabelaNome,
        121 => DBReuniao.PTabelaNome,
        122 => DBReuniaoPessoas.PTabelaNome,
        123 => DBRito.PTabelaNome,
        124 => DBServicos.PTabelaNome,
        125 => DBSetor.PTabelaNome,
        126 => DBSituacao.PTabelaNome,
        127 => DBSMSAlice.PTabelaNome,
        128 => DBStatusAndamento.PTabelaNome,
        129 => DBStatusBiu.PTabelaNome,
        130 => DBStatusHTrab.PTabelaNome,
        131 => DBStatusInstancia.PTabelaNome,
        132 => DBStatusTarefas.PTabelaNome,
        133 => DBTerceiros.PTabelaNome,
        134 => DBTipoCompromisso.PTabelaNome,
        135 => DBTipoContatoCRM.PTabelaNome,
        136 => DBTipoEMail.PTabelaNome,
        137 => DBTipoEndereco.PTabelaNome,
        138 => DBTipoEnderecoSistema.PTabelaNome,
        139 => DBTipoModeloDocumento.PTabelaNome,
        140 => DBTipoOrigemSucumbencia.PTabelaNome,
        141 => DBTipoProDesposito.PTabelaNome,
        142 => DBTipoRecurso.PTabelaNome,
        143 => DBTiposAcao.PTabelaNome,
        144 => DBTipoStatusBiu.PTabelaNome,
        145 => DBTipoValorProcesso.PTabelaNome,
        146 => DBTribEnderecos.PTabelaNome,
        147 => DBTribunal.PTabelaNome,
        148 => DBUF.PTabelaNome,
        149 => DBUltimosProcessos.PTabelaNome,
        150 => DBViaRecebimento.PTabelaNome,
        151 => DBAgendaRelatorio.PTabelaNome,
        152 => DBAgendaSemana.PTabelaNome,
        _ => string.Empty
    };
    public IODicInfo IGlobalObjectDicInfo(string tabelaOrIdOrPrefix) => GlobalObjectDicInfo(tabelaOrIdOrPrefix);
    public IODicInfo? GlobalObjectDicInfo(string tabelaOrIdOrPrefix) => tabelaOrIdOrPrefix switch
    {
        "1" => new DBAcaoODicInfo(),
        DBAcao.PTabelaNome => new DBAcaoODicInfo(),
        "ACAO" => new DBAcaoODicInfo(),
        "2" => new DBAdvogadosODicInfo(),
        DBAdvogados.PTabelaNome => new DBAdvogadosODicInfo(),
        "ADVOGADOS" => new DBAdvogadosODicInfo(),
        "3" => new DBAgendaODicInfo(),
        DBAgenda.PTabelaNome => new DBAgendaODicInfo(),
        "AGENDA" => new DBAgendaODicInfo(),
        "4" => new DBAgenda2AgendaODicInfo(),
        DBAgenda2Agenda.PTabelaNome => new DBAgenda2AgendaODicInfo(),
        "AGENDA2AGENDA" => new DBAgenda2AgendaODicInfo(),
        "5" => new DBAgendaFinanceiroODicInfo(),
        DBAgendaFinanceiro.PTabelaNome => new DBAgendaFinanceiroODicInfo(),
        "AGENDAFINANCEIRO" => new DBAgendaFinanceiroODicInfo(),
        "6" => new DBAgendaQuemODicInfo(),
        DBAgendaQuem.PTabelaNome => new DBAgendaQuemODicInfo(),
        "AGENDAQUEM" => new DBAgendaQuemODicInfo(),
        "7" => new DBAgendaRecordsODicInfo(),
        DBAgendaRecords.PTabelaNome => new DBAgendaRecordsODicInfo(),
        "AGENDARECORDS" => new DBAgendaRecordsODicInfo(),
        "8" => new DBAgendaRepetirODicInfo(),
        DBAgendaRepetir.PTabelaNome => new DBAgendaRepetirODicInfo(),
        "AGENDAREPETIR" => new DBAgendaRepetirODicInfo(),
        "9" => new DBAgendaRepetirDiasODicInfo(),
        DBAgendaRepetirDias.PTabelaNome => new DBAgendaRepetirDiasODicInfo(),
        "AGENDAREPETIRDIAS" => new DBAgendaRepetirDiasODicInfo(),
        "10" => new DBAgendaStatusODicInfo(),
        DBAgendaStatus.PTabelaNome => new DBAgendaStatusODicInfo(),
        "AGENDASTATUS" => new DBAgendaStatusODicInfo(),
        "11" => new DBAlarmSMSODicInfo(),
        DBAlarmSMS.PTabelaNome => new DBAlarmSMSODicInfo(),
        "ALARMSMS" => new DBAlarmSMSODicInfo(),
        "12" => new DBAlertasODicInfo(),
        DBAlertas.PTabelaNome => new DBAlertasODicInfo(),
        "ALERTAS" => new DBAlertasODicInfo(),
        "13" => new DBAlertasEnviadosODicInfo(),
        DBAlertasEnviados.PTabelaNome => new DBAlertasEnviadosODicInfo(),
        "ALERTASENVIADOS" => new DBAlertasEnviadosODicInfo(),
        "14" => new DBAndamentosMDODicInfo(),
        DBAndamentosMD.PTabelaNome => new DBAndamentosMDODicInfo(),
        "ANDAMENTOSMD" => new DBAndamentosMDODicInfo(),
        "15" => new DBAndCompODicInfo(),
        DBAndComp.PTabelaNome => new DBAndCompODicInfo(),
        "ANDCOMP" => new DBAndCompODicInfo(),
        "16" => new DBAnexamentoRegistrosODicInfo(),
        DBAnexamentoRegistros.PTabelaNome => new DBAnexamentoRegistrosODicInfo(),
        "ANEXAMENTOREGISTROS" => new DBAnexamentoRegistrosODicInfo(),
        "17" => new DBApensoODicInfo(),
        DBApenso.PTabelaNome => new DBApensoODicInfo(),
        "APENSO" => new DBApensoODicInfo(),
        "18" => new DBApenso2ODicInfo(),
        DBApenso2.PTabelaNome => new DBApenso2ODicInfo(),
        "APENSO2" => new DBApenso2ODicInfo(),
        "19" => new DBAreaODicInfo(),
        DBArea.PTabelaNome => new DBAreaODicInfo(),
        "AREA" => new DBAreaODicInfo(),
        "20" => new DBAreasJusticaODicInfo(),
        DBAreasJustica.PTabelaNome => new DBAreasJusticaODicInfo(),
        "AREASJUSTICA" => new DBAreasJusticaODicInfo(),
        "21" => new DBAtividadesODicInfo(),
        DBAtividades.PTabelaNome => new DBAtividadesODicInfo(),
        "ATIVIDADES" => new DBAtividadesODicInfo(),
        "22" => new DBAuditor4KODicInfo(),
        DBAuditor4K.PTabelaNome => new DBAuditor4KODicInfo(),
        "AUDITOR4K" => new DBAuditor4KODicInfo(),
        "23" => new DBBensClassificacaoODicInfo(),
        DBBensClassificacao.PTabelaNome => new DBBensClassificacaoODicInfo(),
        "BENSCLASSIFICACAO" => new DBBensClassificacaoODicInfo(),
        "24" => new DBBensMateriaisODicInfo(),
        DBBensMateriais.PTabelaNome => new DBBensMateriaisODicInfo(),
        "BENSMATERIAIS" => new DBBensMateriaisODicInfo(),
        "25" => new DBCargosODicInfo(),
        DBCargos.PTabelaNome => new DBCargosODicInfo(),
        "CARGOS" => new DBCargosODicInfo(),
        "26" => new DBCargosEscODicInfo(),
        DBCargosEsc.PTabelaNome => new DBCargosEscODicInfo(),
        "CARGOSESC" => new DBCargosEscODicInfo(),
        "27" => new DBCargosEscClassODicInfo(),
        DBCargosEscClass.PTabelaNome => new DBCargosEscClassODicInfo(),
        "CARGOSESCCLASS" => new DBCargosEscClassODicInfo(),
        "28" => new DBCidadeODicInfo(),
        DBCidade.PTabelaNome => new DBCidadeODicInfo(),
        "CIDADE" => new DBCidadeODicInfo(),
        "29" => new DBClientesODicInfo(),
        DBClientes.PTabelaNome => new DBClientesODicInfo(),
        "CLIENTES" => new DBClientesODicInfo(),
        "30" => new DBClientesSociosODicInfo(),
        DBClientesSocios.PTabelaNome => new DBClientesSociosODicInfo(),
        "CLIENTESSOCIOS" => new DBClientesSociosODicInfo(),
        "31" => new DBColaboradoresODicInfo(),
        DBColaboradores.PTabelaNome => new DBColaboradoresODicInfo(),
        "COLABORADORES" => new DBColaboradoresODicInfo(),
        "32" => new DBContaCorrenteODicInfo(),
        DBContaCorrente.PTabelaNome => new DBContaCorrenteODicInfo(),
        "CONTACORRENTE" => new DBContaCorrenteODicInfo(),
        "33" => new DBContatoCRMODicInfo(),
        DBContatoCRM.PTabelaNome => new DBContatoCRMODicInfo(),
        "CONTATOCRM" => new DBContatoCRMODicInfo(),
        "34" => new DBContatoCRMOperadorODicInfo(),
        DBContatoCRMOperador.PTabelaNome => new DBContatoCRMOperadorODicInfo(),
        "CONTATOCRMOPERADOR" => new DBContatoCRMOperadorODicInfo(),
        "35" => new DBContatoCRMViewODicInfo(),
        DBContatoCRMView.PTabelaNome => new DBContatoCRMViewODicInfo(),
        "CONTATOCRMVIEW" => new DBContatoCRMViewODicInfo(),
        "36" => new DBContratosODicInfo(),
        DBContratos.PTabelaNome => new DBContratosODicInfo(),
        "CONTRATOS" => new DBContratosODicInfo(),
        "37" => new DBDadosProcuracaoODicInfo(),
        DBDadosProcuracao.PTabelaNome => new DBDadosProcuracaoODicInfo(),
        "DADOSPROCURACAO" => new DBDadosProcuracaoODicInfo(),
        "38" => new DBDiario2ODicInfo(),
        DBDiario2.PTabelaNome => new DBDiario2ODicInfo(),
        "DIARIO2" => new DBDiario2ODicInfo(),
        "39" => new DBDivisaoTribunalODicInfo(),
        DBDivisaoTribunal.PTabelaNome => new DBDivisaoTribunalODicInfo(),
        "DIVISAOTRIBUNAL" => new DBDivisaoTribunalODicInfo(),
        "40" => new DBDocsRecebidosItensODicInfo(),
        DBDocsRecebidosItens.PTabelaNome => new DBDocsRecebidosItensODicInfo(),
        "DOCSRECEBIDOSITENS" => new DBDocsRecebidosItensODicInfo(),
        "41" => new DBDocumentosODicInfo(),
        DBDocumentos.PTabelaNome => new DBDocumentosODicInfo(),
        "DOCUMENTOS" => new DBDocumentosODicInfo(),
        "42" => new DBEMPClassRiscosODicInfo(),
        DBEMPClassRiscos.PTabelaNome => new DBEMPClassRiscosODicInfo(),
        "EMPCLASSRISCOS" => new DBEMPClassRiscosODicInfo(),
        "43" => new DBEnderecosODicInfo(),
        DBEnderecos.PTabelaNome => new DBEnderecosODicInfo(),
        "ENDERECOS" => new DBEnderecosODicInfo(),
        "44" => new DBEnderecoSistemaODicInfo(),
        DBEnderecoSistema.PTabelaNome => new DBEnderecoSistemaODicInfo(),
        "ENDERECOSISTEMA" => new DBEnderecoSistemaODicInfo(),
        "45" => new DBEndTitODicInfo(),
        DBEndTit.PTabelaNome => new DBEndTitODicInfo(),
        "ENDTIT" => new DBEndTitODicInfo(),
        "46" => new DBEnquadramentoEmpresaODicInfo(),
        DBEnquadramentoEmpresa.PTabelaNome => new DBEnquadramentoEmpresaODicInfo(),
        "ENQUADRAMENTOEMPRESA" => new DBEnquadramentoEmpresaODicInfo(),
        "47" => new DBEscritoriosODicInfo(),
        DBEscritorios.PTabelaNome => new DBEscritoriosODicInfo(),
        "ESCRITORIOS" => new DBEscritoriosODicInfo(),
        "48" => new DBEventoPrazoAgendaODicInfo(),
        DBEventoPrazoAgenda.PTabelaNome => new DBEventoPrazoAgendaODicInfo(),
        "EVENTOPRAZOAGENDA" => new DBEventoPrazoAgendaODicInfo(),
        "49" => new DBFaseODicInfo(),
        DBFase.PTabelaNome => new DBFaseODicInfo(),
        "FASE" => new DBFaseODicInfo(),
        "50" => new DBFornecedoresODicInfo(),
        DBFornecedores.PTabelaNome => new DBFornecedoresODicInfo(),
        "FORNECEDORES" => new DBFornecedoresODicInfo(),
        "51" => new DBForoODicInfo(),
        DBForo.PTabelaNome => new DBForoODicInfo(),
        "FORO" => new DBForoODicInfo(),
        "52" => new DBFuncaoODicInfo(),
        DBFuncao.PTabelaNome => new DBFuncaoODicInfo(),
        "FUNCAO" => new DBFuncaoODicInfo(),
        "53" => new DBFuncionariosODicInfo(),
        DBFuncionarios.PTabelaNome => new DBFuncionariosODicInfo(),
        "FUNCIONARIOS" => new DBFuncionariosODicInfo(),
        "54" => new DBGraphODicInfo(),
        DBGraph.PTabelaNome => new DBGraphODicInfo(),
        "GRAPH" => new DBGraphODicInfo(),
        "55" => new DBGruposEmpresasODicInfo(),
        DBGruposEmpresas.PTabelaNome => new DBGruposEmpresasODicInfo(),
        "GRUPOSEMPRESAS" => new DBGruposEmpresasODicInfo(),
        "56" => new DBGruposEmpresasCliODicInfo(),
        DBGruposEmpresasCli.PTabelaNome => new DBGruposEmpresasCliODicInfo(),
        "GRUPOSEMPRESASCLI" => new DBGruposEmpresasCliODicInfo(),
        "57" => new DBGUTAtividadesODicInfo(),
        DBGUTAtividades.PTabelaNome => new DBGUTAtividadesODicInfo(),
        "GUTATIVIDADES" => new DBGUTAtividadesODicInfo(),
        "58" => new DBGUTAtividadesMatrizODicInfo(),
        DBGUTAtividadesMatriz.PTabelaNome => new DBGUTAtividadesMatrizODicInfo(),
        "GUTATIVIDADESMATRIZ" => new DBGUTAtividadesMatrizODicInfo(),
        "59" => new DBGUTMatrizODicInfo(),
        DBGUTMatriz.PTabelaNome => new DBGUTMatrizODicInfo(),
        "GUTMATRIZ" => new DBGUTMatrizODicInfo(),
        "60" => new DBGUTPeriodicidadeODicInfo(),
        DBGUTPeriodicidade.PTabelaNome => new DBGUTPeriodicidadeODicInfo(),
        "GUTPERIODICIDADE" => new DBGUTPeriodicidadeODicInfo(),
        "61" => new DBGUTPeriodicidadeStatusODicInfo(),
        DBGUTPeriodicidadeStatus.PTabelaNome => new DBGUTPeriodicidadeStatusODicInfo(),
        "GUTPERIODICIDADESTATUS" => new DBGUTPeriodicidadeStatusODicInfo(),
        "62" => new DBGUTTipoODicInfo(),
        DBGUTTipo.PTabelaNome => new DBGUTTipoODicInfo(),
        "GUTTIPO" => new DBGUTTipoODicInfo(),
        "63" => new DBHistoricoODicInfo(),
        DBHistorico.PTabelaNome => new DBHistoricoODicInfo(),
        "HISTORICO" => new DBHistoricoODicInfo(),
        "64" => new DBHonorariosDadosContratoODicInfo(),
        DBHonorariosDadosContrato.PTabelaNome => new DBHonorariosDadosContratoODicInfo(),
        "HONORARIOSDADOSCONTRATO" => new DBHonorariosDadosContratoODicInfo(),
        "65" => new DBHorasTrabODicInfo(),
        DBHorasTrab.PTabelaNome => new DBHorasTrabODicInfo(),
        "HORASTRAB" => new DBHorasTrabODicInfo(),
        "66" => new DBInstanciaODicInfo(),
        DBInstancia.PTabelaNome => new DBInstanciaODicInfo(),
        "INSTANCIA" => new DBInstanciaODicInfo(),
        "67" => new DBJusticaODicInfo(),
        DBJustica.PTabelaNome => new DBJusticaODicInfo(),
        "JUSTICA" => new DBJusticaODicInfo(),
        "68" => new DBLigacoesODicInfo(),
        DBLigacoes.PTabelaNome => new DBLigacoesODicInfo(),
        "LIGACOES" => new DBLigacoesODicInfo(),
        "69" => new DBLivroCaixaODicInfo(),
        DBLivroCaixa.PTabelaNome => new DBLivroCaixaODicInfo(),
        "LIVROCAIXA" => new DBLivroCaixaODicInfo(),
        "70" => new DBLivroCaixaClientesODicInfo(),
        DBLivroCaixaClientes.PTabelaNome => new DBLivroCaixaClientesODicInfo(),
        "LIVROCAIXACLIENTES" => new DBLivroCaixaClientesODicInfo(),
        "71" => new DBModelosDocumentosODicInfo(),
        DBModelosDocumentos.PTabelaNome => new DBModelosDocumentosODicInfo(),
        "MODELOSDOCUMENTOS" => new DBModelosDocumentosODicInfo(),
        "72" => new DBNECompromissosODicInfo(),
        DBNECompromissos.PTabelaNome => new DBNECompromissosODicInfo(),
        "NECOMPROMISSOS" => new DBNECompromissosODicInfo(),
        "73" => new DBNENotasODicInfo(),
        DBNENotas.PTabelaNome => new DBNENotasODicInfo(),
        "NENOTAS" => new DBNENotasODicInfo(),
        "74" => new DBNEPalavrasChavesODicInfo(),
        DBNEPalavrasChaves.PTabelaNome => new DBNEPalavrasChavesODicInfo(),
        "NEPALAVRASCHAVES" => new DBNEPalavrasChavesODicInfo(),
        "75" => new DBObjetosODicInfo(),
        DBObjetos.PTabelaNome => new DBObjetosODicInfo(),
        "OBJETOS" => new DBObjetosODicInfo(),
        "76" => new DBOperadorODicInfo(),
        DBOperador.PTabelaNome => new DBOperadorODicInfo(),
        "OPERADOR" => new DBOperadorODicInfo(),
        "77" => new DBOperadorEMailPopupODicInfo(),
        DBOperadorEMailPopup.PTabelaNome => new DBOperadorEMailPopupODicInfo(),
        "OPERADOREMAILPOPUP" => new DBOperadorEMailPopupODicInfo(),
        "78" => new DBOperadoresODicInfo(),
        DBOperadores.PTabelaNome => new DBOperadoresODicInfo(),
        "OPERADORES" => new DBOperadoresODicInfo(),
        "79" => new DBOperadorGrupoODicInfo(),
        DBOperadorGrupo.PTabelaNome => new DBOperadorGrupoODicInfo(),
        "OPERADORGRUPO" => new DBOperadorGrupoODicInfo(),
        "80" => new DBOperadorGruposODicInfo(),
        DBOperadorGrupos.PTabelaNome => new DBOperadorGruposODicInfo(),
        "OPERADORGRUPOS" => new DBOperadorGruposODicInfo(),
        "81" => new DBOperadorGruposAgendaODicInfo(),
        DBOperadorGruposAgenda.PTabelaNome => new DBOperadorGruposAgendaODicInfo(),
        "OPERADORGRUPOSAGENDA" => new DBOperadorGruposAgendaODicInfo(),
        "82" => new DBOperadorGruposAgendaOperadoresODicInfo(),
        DBOperadorGruposAgendaOperadores.PTabelaNome => new DBOperadorGruposAgendaOperadoresODicInfo(),
        "OPERADORGRUPOSAGENDAOPERADORES" => new DBOperadorGruposAgendaOperadoresODicInfo(),
        "83" => new DBOponentesODicInfo(),
        DBOponentes.PTabelaNome => new DBOponentesODicInfo(),
        "OPONENTES" => new DBOponentesODicInfo(),
        "84" => new DBOponentesRepLegalODicInfo(),
        DBOponentesRepLegal.PTabelaNome => new DBOponentesRepLegalODicInfo(),
        "OPONENTESREPLEGAL" => new DBOponentesRepLegalODicInfo(),
        "85" => new DBOutrasPartesClienteODicInfo(),
        DBOutrasPartesCliente.PTabelaNome => new DBOutrasPartesClienteODicInfo(),
        "OUTRASPARTESCLIENTE" => new DBOutrasPartesClienteODicInfo(),
        "86" => new DBPaisesODicInfo(),
        DBPaises.PTabelaNome => new DBPaisesODicInfo(),
        "PAISES" => new DBPaisesODicInfo(),
        "87" => new DBParceriaProcODicInfo(),
        DBParceriaProc.PTabelaNome => new DBParceriaProcODicInfo(),
        "PARCERIAPROC" => new DBParceriaProcODicInfo(),
        "88" => new DBParteClienteODicInfo(),
        DBParteCliente.PTabelaNome => new DBParteClienteODicInfo(),
        "PARTECLIENTE" => new DBParteClienteODicInfo(),
        "89" => new DBParteClienteOutrasODicInfo(),
        DBParteClienteOutras.PTabelaNome => new DBParteClienteOutrasODicInfo(),
        "PARTECLIENTEOUTRAS" => new DBParteClienteOutrasODicInfo(),
        "90" => new DBParteOponenteODicInfo(),
        DBParteOponente.PTabelaNome => new DBParteOponenteODicInfo(),
        "PARTEOPONENTE" => new DBParteOponenteODicInfo(),
        "91" => new DBPenhoraODicInfo(),
        DBPenhora.PTabelaNome => new DBPenhoraODicInfo(),
        "PENHORA" => new DBPenhoraODicInfo(),
        "92" => new DBPenhoraStatusODicInfo(),
        DBPenhoraStatus.PTabelaNome => new DBPenhoraStatusODicInfo(),
        "PENHORASTATUS" => new DBPenhoraStatusODicInfo(),
        "93" => new DBPoderJudiciarioAssociadoODicInfo(),
        DBPoderJudiciarioAssociado.PTabelaNome => new DBPoderJudiciarioAssociadoODicInfo(),
        "PODERJUDICIARIOASSOCIADO" => new DBPoderJudiciarioAssociadoODicInfo(),
        "94" => new DBPontoVirtualODicInfo(),
        DBPontoVirtual.PTabelaNome => new DBPontoVirtualODicInfo(),
        "PONTOVIRTUAL" => new DBPontoVirtualODicInfo(),
        "95" => new DBPontoVirtualAcessosODicInfo(),
        DBPontoVirtualAcessos.PTabelaNome => new DBPontoVirtualAcessosODicInfo(),
        "PONTOVIRTUALACESSOS" => new DBPontoVirtualAcessosODicInfo(),
        "96" => new DBPosicaoOutrasPartesODicInfo(),
        DBPosicaoOutrasPartes.PTabelaNome => new DBPosicaoOutrasPartesODicInfo(),
        "POSICAOOUTRASPARTES" => new DBPosicaoOutrasPartesODicInfo(),
        "97" => new DBPrecatoriaODicInfo(),
        DBPrecatoria.PTabelaNome => new DBPrecatoriaODicInfo(),
        "PRECATORIA" => new DBPrecatoriaODicInfo(),
        "98" => new DBPreClientesODicInfo(),
        DBPreClientes.PTabelaNome => new DBPreClientesODicInfo(),
        "PRECLIENTES" => new DBPreClientesODicInfo(),
        "99" => new DBPrepostosODicInfo(),
        DBPrepostos.PTabelaNome => new DBPrepostosODicInfo(),
        "PREPOSTOS" => new DBPrepostosODicInfo(),
        "100" => new DBProBarCODEODicInfo(),
        DBProBarCODE.PTabelaNome => new DBProBarCODEODicInfo(),
        "PROBARCODE" => new DBProBarCODEODicInfo(),
        "101" => new DBProCDAODicInfo(),
        DBProCDA.PTabelaNome => new DBProCDAODicInfo(),
        "PROCDA" => new DBProCDAODicInfo(),
        "102" => new DBProcessosODicInfo(),
        DBProcessos.PTabelaNome => new DBProcessosODicInfo(),
        "PROCESSOS" => new DBProcessosODicInfo(),
        "103" => new DBProcessosObsReportODicInfo(),
        DBProcessosObsReport.PTabelaNome => new DBProcessosObsReportODicInfo(),
        "PROCESSOSOBSREPORT" => new DBProcessosObsReportODicInfo(),
        "104" => new DBProcessosParadosODicInfo(),
        DBProcessosParados.PTabelaNome => new DBProcessosParadosODicInfo(),
        "PROCESSOSPARADOS" => new DBProcessosParadosODicInfo(),
        "105" => new DBProcessOutputEngineODicInfo(),
        DBProcessOutputEngine.PTabelaNome => new DBProcessOutputEngineODicInfo(),
        "PROCESSOUTPUTENGINE" => new DBProcessOutputEngineODicInfo(),
        "106" => new DBProcessOutPutIDsODicInfo(),
        DBProcessOutPutIDs.PTabelaNome => new DBProcessOutPutIDsODicInfo(),
        "PROCESSOUTPUTIDS" => new DBProcessOutPutIDsODicInfo(),
        "107" => new DBProcessOutputRequestODicInfo(),
        DBProcessOutputRequest.PTabelaNome => new DBProcessOutputRequestODicInfo(),
        "PROCESSOUTPUTREQUEST" => new DBProcessOutputRequestODicInfo(),
        "108" => new DBProcessOutputSourcesODicInfo(),
        DBProcessOutputSources.PTabelaNome => new DBProcessOutputSourcesODicInfo(),
        "PROCESSOUTPUTSOURCES" => new DBProcessOutputSourcesODicInfo(),
        "109" => new DBProDepositosODicInfo(),
        DBProDepositos.PTabelaNome => new DBProDepositosODicInfo(),
        "PRODEPOSITOS" => new DBProDepositosODicInfo(),
        "110" => new DBProDespesasODicInfo(),
        DBProDespesas.PTabelaNome => new DBProDespesasODicInfo(),
        "PRODESPESAS" => new DBProDespesasODicInfo(),
        "111" => new DBProObservacoesODicInfo(),
        DBProObservacoes.PTabelaNome => new DBProObservacoesODicInfo(),
        "PROOBSERVACOES" => new DBProObservacoesODicInfo(),
        "112" => new DBProPartesODicInfo(),
        DBProPartes.PTabelaNome => new DBProPartesODicInfo(),
        "PROPARTES" => new DBProPartesODicInfo(),
        "113" => new DBProProcuradoresODicInfo(),
        DBProProcuradores.PTabelaNome => new DBProProcuradoresODicInfo(),
        "PROPROCURADORES" => new DBProProcuradoresODicInfo(),
        "114" => new DBProResumosODicInfo(),
        DBProResumos.PTabelaNome => new DBProResumosODicInfo(),
        "PRORESUMOS" => new DBProResumosODicInfo(),
        "115" => new DBProSucumbenciaODicInfo(),
        DBProSucumbencia.PTabelaNome => new DBProSucumbenciaODicInfo(),
        "PROSUCUMBENCIA" => new DBProSucumbenciaODicInfo(),
        "116" => new DBProTipoBaixaODicInfo(),
        DBProTipoBaixa.PTabelaNome => new DBProTipoBaixaODicInfo(),
        "PROTIPOBAIXA" => new DBProTipoBaixaODicInfo(),
        "117" => new DBProValoresODicInfo(),
        DBProValores.PTabelaNome => new DBProValoresODicInfo(),
        "PROVALORES" => new DBProValoresODicInfo(),
        "118" => new DBRamalODicInfo(),
        DBRamal.PTabelaNome => new DBRamalODicInfo(),
        "RAMAL" => new DBRamalODicInfo(),
        "119" => new DBRecadosODicInfo(),
        DBRecados.PTabelaNome => new DBRecadosODicInfo(),
        "RECADOS" => new DBRecadosODicInfo(),
        "120" => new DBRegimeTributacaoODicInfo(),
        DBRegimeTributacao.PTabelaNome => new DBRegimeTributacaoODicInfo(),
        "REGIMETRIBUTACAO" => new DBRegimeTributacaoODicInfo(),
        "121" => new DBReuniaoODicInfo(),
        DBReuniao.PTabelaNome => new DBReuniaoODicInfo(),
        "REUNIAO" => new DBReuniaoODicInfo(),
        "122" => new DBReuniaoPessoasODicInfo(),
        DBReuniaoPessoas.PTabelaNome => new DBReuniaoPessoasODicInfo(),
        "REUNIAOPESSOAS" => new DBReuniaoPessoasODicInfo(),
        "123" => new DBRitoODicInfo(),
        DBRito.PTabelaNome => new DBRitoODicInfo(),
        "RITO" => new DBRitoODicInfo(),
        "124" => new DBServicosODicInfo(),
        DBServicos.PTabelaNome => new DBServicosODicInfo(),
        "SERVICOS" => new DBServicosODicInfo(),
        "125" => new DBSetorODicInfo(),
        DBSetor.PTabelaNome => new DBSetorODicInfo(),
        "SETOR" => new DBSetorODicInfo(),
        "126" => new DBSituacaoODicInfo(),
        DBSituacao.PTabelaNome => new DBSituacaoODicInfo(),
        "SITUACAO" => new DBSituacaoODicInfo(),
        "127" => new DBSMSAliceODicInfo(),
        DBSMSAlice.PTabelaNome => new DBSMSAliceODicInfo(),
        "SMSALICE" => new DBSMSAliceODicInfo(),
        "128" => new DBStatusAndamentoODicInfo(),
        DBStatusAndamento.PTabelaNome => new DBStatusAndamentoODicInfo(),
        "STATUSANDAMENTO" => new DBStatusAndamentoODicInfo(),
        "129" => new DBStatusBiuODicInfo(),
        DBStatusBiu.PTabelaNome => new DBStatusBiuODicInfo(),
        "STATUSBIU" => new DBStatusBiuODicInfo(),
        "130" => new DBStatusHTrabODicInfo(),
        DBStatusHTrab.PTabelaNome => new DBStatusHTrabODicInfo(),
        "STATUSHTRAB" => new DBStatusHTrabODicInfo(),
        "131" => new DBStatusInstanciaODicInfo(),
        DBStatusInstancia.PTabelaNome => new DBStatusInstanciaODicInfo(),
        "STATUSINSTANCIA" => new DBStatusInstanciaODicInfo(),
        "132" => new DBStatusTarefasODicInfo(),
        DBStatusTarefas.PTabelaNome => new DBStatusTarefasODicInfo(),
        "STATUSTAREFAS" => new DBStatusTarefasODicInfo(),
        "133" => new DBTerceirosODicInfo(),
        DBTerceiros.PTabelaNome => new DBTerceirosODicInfo(),
        "TERCEIROS" => new DBTerceirosODicInfo(),
        "134" => new DBTipoCompromissoODicInfo(),
        DBTipoCompromisso.PTabelaNome => new DBTipoCompromissoODicInfo(),
        "TIPOCOMPROMISSO" => new DBTipoCompromissoODicInfo(),
        "135" => new DBTipoContatoCRMODicInfo(),
        DBTipoContatoCRM.PTabelaNome => new DBTipoContatoCRMODicInfo(),
        "TIPOCONTATOCRM" => new DBTipoContatoCRMODicInfo(),
        "136" => new DBTipoEMailODicInfo(),
        DBTipoEMail.PTabelaNome => new DBTipoEMailODicInfo(),
        "TIPOEMAIL" => new DBTipoEMailODicInfo(),
        "137" => new DBTipoEnderecoODicInfo(),
        DBTipoEndereco.PTabelaNome => new DBTipoEnderecoODicInfo(),
        "TIPOENDERECO" => new DBTipoEnderecoODicInfo(),
        "138" => new DBTipoEnderecoSistemaODicInfo(),
        DBTipoEnderecoSistema.PTabelaNome => new DBTipoEnderecoSistemaODicInfo(),
        "TIPOENDERECOSISTEMA" => new DBTipoEnderecoSistemaODicInfo(),
        "139" => new DBTipoModeloDocumentoODicInfo(),
        DBTipoModeloDocumento.PTabelaNome => new DBTipoModeloDocumentoODicInfo(),
        "TIPOMODELODOCUMENTO" => new DBTipoModeloDocumentoODicInfo(),
        "140" => new DBTipoOrigemSucumbenciaODicInfo(),
        DBTipoOrigemSucumbencia.PTabelaNome => new DBTipoOrigemSucumbenciaODicInfo(),
        "TIPOORIGEMSUCUMBENCIA" => new DBTipoOrigemSucumbenciaODicInfo(),
        "141" => new DBTipoProDespositoODicInfo(),
        DBTipoProDesposito.PTabelaNome => new DBTipoProDespositoODicInfo(),
        "TIPOPRODESPOSITO" => new DBTipoProDespositoODicInfo(),
        "142" => new DBTipoRecursoODicInfo(),
        DBTipoRecurso.PTabelaNome => new DBTipoRecursoODicInfo(),
        "TIPORECURSO" => new DBTipoRecursoODicInfo(),
        "143" => new DBTiposAcaoODicInfo(),
        DBTiposAcao.PTabelaNome => new DBTiposAcaoODicInfo(),
        "TIPOSACAO" => new DBTiposAcaoODicInfo(),
        "144" => new DBTipoStatusBiuODicInfo(),
        DBTipoStatusBiu.PTabelaNome => new DBTipoStatusBiuODicInfo(),
        "TIPOSTATUSBIU" => new DBTipoStatusBiuODicInfo(),
        "145" => new DBTipoValorProcessoODicInfo(),
        DBTipoValorProcesso.PTabelaNome => new DBTipoValorProcessoODicInfo(),
        "TIPOVALORPROCESSO" => new DBTipoValorProcessoODicInfo(),
        "146" => new DBTribEnderecosODicInfo(),
        DBTribEnderecos.PTabelaNome => new DBTribEnderecosODicInfo(),
        "TRIBENDERECOS" => new DBTribEnderecosODicInfo(),
        "147" => new DBTribunalODicInfo(),
        DBTribunal.PTabelaNome => new DBTribunalODicInfo(),
        "TRIBUNAL" => new DBTribunalODicInfo(),
        "148" => new DBUFODicInfo(),
        DBUF.PTabelaNome => new DBUFODicInfo(),
        "149" => new DBUltimosProcessosODicInfo(),
        DBUltimosProcessos.PTabelaNome => new DBUltimosProcessosODicInfo(),
        "ULTIMOSPROCESSOS" => new DBUltimosProcessosODicInfo(),
        "150" => new DBViaRecebimentoODicInfo(),
        DBViaRecebimento.PTabelaNome => new DBViaRecebimentoODicInfo(),
        "VIARECEBIMENTO" => new DBViaRecebimentoODicInfo(),
        "151" => new DBAgendaRelatorioODicInfo(),
        DBAgendaRelatorio.PTabelaNome => new DBAgendaRelatorioODicInfo(),
        "AGENDARELATORIO" => new DBAgendaRelatorioODicInfo(),
        "152" => new DBAgendaSemanaODicInfo(),
        DBAgendaSemana.PTabelaNome => new DBAgendaSemanaODicInfo(),
        "AGENDASEMANA" => new DBAgendaSemanaODicInfo(),
        _ => null
    };
    public ICadastros IGlobalObjectLoad(string tabela, string cWhere, MsiSqlConnection? oCnn) => GlobalObjectLoad(tabela, cWhere, oCnn);
    public ICadastros GlobalObjectLoad(string tabela, string cWhere, MsiSqlConnection? oCnn) => tabela switch
    {
        DBAcao.PTabelaNome => new DBAcao(sqlWhere: cWhere, oCnn: oCnn),
        DBAdvogados.PTabelaNome => new DBAdvogados(sqlWhere: cWhere, oCnn: oCnn),
        DBAlarmSMS.PTabelaNome => new DBAlarmSMS(sqlWhere: cWhere, oCnn: oCnn),
        DBAlertas.PTabelaNome => new DBAlertas(sqlWhere: cWhere, oCnn: oCnn),
        DBAndamentosMD.PTabelaNome => new DBAndamentosMD(sqlWhere: cWhere, oCnn: oCnn),
        DBArea.PTabelaNome => new DBArea(sqlWhere: cWhere, oCnn: oCnn),
        DBAtividades.PTabelaNome => new DBAtividades(sqlWhere: cWhere, oCnn: oCnn),
        DBAuditor4K.PTabelaNome => new DBAuditor4K(sqlWhere: cWhere, oCnn: oCnn),
        DBBensClassificacao.PTabelaNome => new DBBensClassificacao(sqlWhere: cWhere, oCnn: oCnn),
        DBBensMateriais.PTabelaNome => new DBBensMateriais(sqlWhere: cWhere, oCnn: oCnn),
        DBCargos.PTabelaNome => new DBCargos(sqlWhere: cWhere, oCnn: oCnn),
        DBCargosEsc.PTabelaNome => new DBCargosEsc(sqlWhere: cWhere, oCnn: oCnn),
        DBCargosEscClass.PTabelaNome => new DBCargosEscClass(sqlWhere: cWhere, oCnn: oCnn),
        DBCidade.PTabelaNome => new DBCidade(sqlWhere: cWhere, oCnn: oCnn),
        DBClientes.PTabelaNome => new DBClientes(sqlWhere: cWhere, oCnn: oCnn),
        DBClientesSocios.PTabelaNome => new DBClientesSocios(sqlWhere: cWhere, oCnn: oCnn),
        DBColaboradores.PTabelaNome => new DBColaboradores(sqlWhere: cWhere, oCnn: oCnn),
        DBDiario2.PTabelaNome => new DBDiario2(sqlWhere: cWhere, oCnn: oCnn),
        DBDocsRecebidosItens.PTabelaNome => new DBDocsRecebidosItens(sqlWhere: cWhere, oCnn: oCnn),
        DBEMPClassRiscos.PTabelaNome => new DBEMPClassRiscos(sqlWhere: cWhere, oCnn: oCnn),
        DBEnderecos.PTabelaNome => new DBEnderecos(sqlWhere: cWhere, oCnn: oCnn),
        DBEnquadramentoEmpresa.PTabelaNome => new DBEnquadramentoEmpresa(sqlWhere: cWhere, oCnn: oCnn),
        DBEscritorios.PTabelaNome => new DBEscritorios(sqlWhere: cWhere, oCnn: oCnn),
        DBEventoPrazoAgenda.PTabelaNome => new DBEventoPrazoAgenda(sqlWhere: cWhere, oCnn: oCnn),
        DBFase.PTabelaNome => new DBFase(sqlWhere: cWhere, oCnn: oCnn),
        DBFornecedores.PTabelaNome => new DBFornecedores(sqlWhere: cWhere, oCnn: oCnn),
        DBForo.PTabelaNome => new DBForo(sqlWhere: cWhere, oCnn: oCnn),
        DBFuncao.PTabelaNome => new DBFuncao(sqlWhere: cWhere, oCnn: oCnn),
        DBFuncionarios.PTabelaNome => new DBFuncionarios(sqlWhere: cWhere, oCnn: oCnn),
        DBGruposEmpresas.PTabelaNome => new DBGruposEmpresas(sqlWhere: cWhere, oCnn: oCnn),
        DBGUTAtividades.PTabelaNome => new DBGUTAtividades(sqlWhere: cWhere, oCnn: oCnn),
        DBGUTMatriz.PTabelaNome => new DBGUTMatriz(sqlWhere: cWhere, oCnn: oCnn),
        DBGUTPeriodicidade.PTabelaNome => new DBGUTPeriodicidade(sqlWhere: cWhere, oCnn: oCnn),
        DBGUTTipo.PTabelaNome => new DBGUTTipo(sqlWhere: cWhere, oCnn: oCnn),
        DBInstancia.PTabelaNome => new DBInstancia(sqlWhere: cWhere, oCnn: oCnn),
        DBJustica.PTabelaNome => new DBJustica(sqlWhere: cWhere, oCnn: oCnn),
        DBLigacoes.PTabelaNome => new DBLigacoes(sqlWhere: cWhere, oCnn: oCnn),
        DBModelosDocumentos.PTabelaNome => new DBModelosDocumentos(sqlWhere: cWhere, oCnn: oCnn),
        DBNENotas.PTabelaNome => new DBNENotas(sqlWhere: cWhere, oCnn: oCnn),
        DBNEPalavrasChaves.PTabelaNome => new DBNEPalavrasChaves(sqlWhere: cWhere, oCnn: oCnn),
        DBObjetos.PTabelaNome => new DBObjetos(sqlWhere: cWhere, oCnn: oCnn),
        DBOperador.PTabelaNome => new DBOperador(sqlWhere: cWhere, oCnn: oCnn),
        DBOperadorEMailPopup.PTabelaNome => new DBOperadorEMailPopup(sqlWhere: cWhere, oCnn: oCnn),
        DBOperadores.PTabelaNome => new DBOperadores(sqlWhere: cWhere, oCnn: oCnn),
        DBOperadorGrupos.PTabelaNome => new DBOperadorGrupos(sqlWhere: cWhere, oCnn: oCnn),
        DBOperadorGruposAgenda.PTabelaNome => new DBOperadorGruposAgenda(sqlWhere: cWhere, oCnn: oCnn),
        DBOponentes.PTabelaNome => new DBOponentes(sqlWhere: cWhere, oCnn: oCnn),
        DBOponentesRepLegal.PTabelaNome => new DBOponentesRepLegal(sqlWhere: cWhere, oCnn: oCnn),
        DBOutrasPartesCliente.PTabelaNome => new DBOutrasPartesCliente(sqlWhere: cWhere, oCnn: oCnn),
        DBPaises.PTabelaNome => new DBPaises(sqlWhere: cWhere, oCnn: oCnn),
        DBPenhora.PTabelaNome => new DBPenhora(sqlWhere: cWhere, oCnn: oCnn),
        DBPenhoraStatus.PTabelaNome => new DBPenhoraStatus(sqlWhere: cWhere, oCnn: oCnn),
        DBPosicaoOutrasPartes.PTabelaNome => new DBPosicaoOutrasPartes(sqlWhere: cWhere, oCnn: oCnn),
        DBPreClientes.PTabelaNome => new DBPreClientes(sqlWhere: cWhere, oCnn: oCnn),
        DBPrepostos.PTabelaNome => new DBPrepostos(sqlWhere: cWhere, oCnn: oCnn),
        DBProCDA.PTabelaNome => new DBProCDA(sqlWhere: cWhere, oCnn: oCnn),
        DBProcessos.PTabelaNome => new DBProcessos(sqlWhere: cWhere, oCnn: oCnn),
        DBProcessOutputEngine.PTabelaNome => new DBProcessOutputEngine(sqlWhere: cWhere, oCnn: oCnn),
        DBProcessOutPutIDs.PTabelaNome => new DBProcessOutPutIDs(sqlWhere: cWhere, oCnn: oCnn),
        DBProcessOutputSources.PTabelaNome => new DBProcessOutputSources(sqlWhere: cWhere, oCnn: oCnn),
        DBProObservacoes.PTabelaNome => new DBProObservacoes(sqlWhere: cWhere, oCnn: oCnn),
        DBProProcuradores.PTabelaNome => new DBProProcuradores(sqlWhere: cWhere, oCnn: oCnn),
        DBProSucumbencia.PTabelaNome => new DBProSucumbencia(sqlWhere: cWhere, oCnn: oCnn),
        DBProTipoBaixa.PTabelaNome => new DBProTipoBaixa(sqlWhere: cWhere, oCnn: oCnn),
        DBRamal.PTabelaNome => new DBRamal(sqlWhere: cWhere, oCnn: oCnn),
        DBRegimeTributacao.PTabelaNome => new DBRegimeTributacao(sqlWhere: cWhere, oCnn: oCnn),
        DBRito.PTabelaNome => new DBRito(sqlWhere: cWhere, oCnn: oCnn),
        DBServicos.PTabelaNome => new DBServicos(sqlWhere: cWhere, oCnn: oCnn),
        DBSetor.PTabelaNome => new DBSetor(sqlWhere: cWhere, oCnn: oCnn),
        DBSMSAlice.PTabelaNome => new DBSMSAlice(sqlWhere: cWhere, oCnn: oCnn),
        DBStatusAndamento.PTabelaNome => new DBStatusAndamento(sqlWhere: cWhere, oCnn: oCnn),
        DBStatusBiu.PTabelaNome => new DBStatusBiu(sqlWhere: cWhere, oCnn: oCnn),
        DBStatusHTrab.PTabelaNome => new DBStatusHTrab(sqlWhere: cWhere, oCnn: oCnn),
        DBStatusInstancia.PTabelaNome => new DBStatusInstancia(sqlWhere: cWhere, oCnn: oCnn),
        DBStatusTarefas.PTabelaNome => new DBStatusTarefas(sqlWhere: cWhere, oCnn: oCnn),
        DBTerceiros.PTabelaNome => new DBTerceiros(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoCompromisso.PTabelaNome => new DBTipoCompromisso(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoContatoCRM.PTabelaNome => new DBTipoContatoCRM(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoEMail.PTabelaNome => new DBTipoEMail(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoEndereco.PTabelaNome => new DBTipoEndereco(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoEnderecoSistema.PTabelaNome => new DBTipoEnderecoSistema(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoModeloDocumento.PTabelaNome => new DBTipoModeloDocumento(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoOrigemSucumbencia.PTabelaNome => new DBTipoOrigemSucumbencia(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoProDesposito.PTabelaNome => new DBTipoProDesposito(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoRecurso.PTabelaNome => new DBTipoRecurso(sqlWhere: cWhere, oCnn: oCnn),
        DBTiposAcao.PTabelaNome => new DBTiposAcao(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoStatusBiu.PTabelaNome => new DBTipoStatusBiu(sqlWhere: cWhere, oCnn: oCnn),
        DBTipoValorProcesso.PTabelaNome => new DBTipoValorProcesso(sqlWhere: cWhere, oCnn: oCnn),
        DBTribunal.PTabelaNome => new DBTribunal(sqlWhere: cWhere, oCnn: oCnn),
        DBUF.PTabelaNome => new DBUF(sqlWhere: cWhere, oCnn: oCnn),
        DBViaRecebimento.PTabelaNome => new DBViaRecebimento(sqlWhere: cWhere, oCnn: oCnn),
        _ => throw new Exception(tabela)};
    public ICadastros IGlobalObjectLoad(string tabela, int id, MsiSqlConnection? oCnn) => GlobalObjectLoad(tabela, id, oCnn);
    public ICadastros GlobalObjectLoad(string tabela, int id, MsiSqlConnection? oCnn) => tabela switch
    {
        DBAcao.PTabelaNome => new DBAcao(id, oCnn), // Acao
        DBAdvogados.PTabelaNome => new DBAdvogados(id, oCnn), // Advogados
        DBAgenda.PTabelaNome => new DBAgenda(id, oCnn), // Agenda
        DBAgenda2Agenda.PTabelaNome => new DBAgenda2Agenda(id, oCnn), // Agenda2Agenda
        DBAgendaFinanceiro.PTabelaNome => new DBAgendaFinanceiro(id, oCnn), // AgendaFinanceiro
        DBAgendaQuem.PTabelaNome => new DBAgendaQuem(id, oCnn), // AgendaQuem
        DBAgendaRecords.PTabelaNome => new DBAgendaRecords(id, oCnn), // AgendaRecords
        DBAgendaRepetir.PTabelaNome => new DBAgendaRepetir(id, oCnn), // AgendaRepetir
        DBAgendaRepetirDias.PTabelaNome => new DBAgendaRepetirDias(id, oCnn), // AgendaRepetirDias
        DBAgendaStatus.PTabelaNome => new DBAgendaStatus(id, oCnn), // AgendaStatus
        DBAlarmSMS.PTabelaNome => new DBAlarmSMS(id, oCnn), // AlarmSMS
        DBAlertas.PTabelaNome => new DBAlertas(id, oCnn), // Alertas
        DBAlertasEnviados.PTabelaNome => new DBAlertasEnviados(id, oCnn), // AlertasEnviados
        DBAndamentosMD.PTabelaNome => new DBAndamentosMD(id, oCnn), // AndamentosMD
        DBAndComp.PTabelaNome => new DBAndComp(id, oCnn), // AndComp
        DBAnexamentoRegistros.PTabelaNome => new DBAnexamentoRegistros(id, oCnn), // AnexamentoRegistros
        DBApenso.PTabelaNome => new DBApenso(id, oCnn), // Apenso
        DBApenso2.PTabelaNome => new DBApenso2(id, oCnn), // Apenso2
        DBArea.PTabelaNome => new DBArea(id, oCnn), // Area
        DBAreasJustica.PTabelaNome => new DBAreasJustica(id, oCnn), // AreasJustica
        DBAtividades.PTabelaNome => new DBAtividades(id, oCnn), // Atividades
        DBAuditor4K.PTabelaNome => new DBAuditor4K(id, oCnn), // Auditor4K
        DBBensClassificacao.PTabelaNome => new DBBensClassificacao(id, oCnn), // BensClassificacao
        DBBensMateriais.PTabelaNome => new DBBensMateriais(id, oCnn), // BensMateriais
        DBCargos.PTabelaNome => new DBCargos(id, oCnn), // Cargos
        DBCargosEsc.PTabelaNome => new DBCargosEsc(id, oCnn), // CargosEsc
        DBCargosEscClass.PTabelaNome => new DBCargosEscClass(id, oCnn), // CargosEscClass
        DBCidade.PTabelaNome => new DBCidade(id, oCnn), // Cidade
        DBClientes.PTabelaNome => new DBClientes(id, oCnn), // Clientes
        DBClientesSocios.PTabelaNome => new DBClientesSocios(id, oCnn), // ClientesSocios
        DBColaboradores.PTabelaNome => new DBColaboradores(id, oCnn), // Colaboradores
        DBContaCorrente.PTabelaNome => new DBContaCorrente(id, oCnn), // ContaCorrente
        DBContatoCRM.PTabelaNome => new DBContatoCRM(id, oCnn), // ContatoCRM
        DBContatoCRMOperador.PTabelaNome => new DBContatoCRMOperador(id, oCnn), // ContatoCRMOperador
        DBContatoCRMView.PTabelaNome => new DBContatoCRMView(id, oCnn), // ContatoCRMView
        DBContratos.PTabelaNome => new DBContratos(id, oCnn), // Contratos
        DBDadosProcuracao.PTabelaNome => new DBDadosProcuracao(id, oCnn), // DadosProcuracao
        DBDiario2.PTabelaNome => new DBDiario2(id, oCnn), // Diario2
        DBDivisaoTribunal.PTabelaNome => new DBDivisaoTribunal(id, oCnn), // DivisaoTribunal
        DBDocsRecebidosItens.PTabelaNome => new DBDocsRecebidosItens(id, oCnn), // DocsRecebidosItens
        DBDocumentos.PTabelaNome => new DBDocumentos(id, oCnn), // Documentos
        DBEMPClassRiscos.PTabelaNome => new DBEMPClassRiscos(id, oCnn), // EMPClassRiscos
        DBEnderecos.PTabelaNome => new DBEnderecos(id, oCnn), // Enderecos
        DBEnderecoSistema.PTabelaNome => new DBEnderecoSistema(id, oCnn), // EnderecoSistema
        DBEndTit.PTabelaNome => new DBEndTit(id, oCnn), // EndTit
        DBEnquadramentoEmpresa.PTabelaNome => new DBEnquadramentoEmpresa(id, oCnn), // EnquadramentoEmpresa
        DBEscritorios.PTabelaNome => new DBEscritorios(id, oCnn), // Escritorios
        DBEventoPrazoAgenda.PTabelaNome => new DBEventoPrazoAgenda(id, oCnn), // EventoPrazoAgenda
        DBFase.PTabelaNome => new DBFase(id, oCnn), // Fase
        DBFornecedores.PTabelaNome => new DBFornecedores(id, oCnn), // Fornecedores
        DBForo.PTabelaNome => new DBForo(id, oCnn), // Foro
        DBFuncao.PTabelaNome => new DBFuncao(id, oCnn), // Funcao
        DBFuncionarios.PTabelaNome => new DBFuncionarios(id, oCnn), // Funcionarios
        DBGraph.PTabelaNome => new DBGraph(id, oCnn), // Graph
        DBGruposEmpresas.PTabelaNome => new DBGruposEmpresas(id, oCnn), // GruposEmpresas
        DBGruposEmpresasCli.PTabelaNome => new DBGruposEmpresasCli(id, oCnn), // GruposEmpresasCli
        DBGUTAtividades.PTabelaNome => new DBGUTAtividades(id, oCnn), // GUTAtividades
        DBGUTAtividadesMatriz.PTabelaNome => new DBGUTAtividadesMatriz(id, oCnn), // GUTAtividadesMatriz
        DBGUTMatriz.PTabelaNome => new DBGUTMatriz(id, oCnn), // GUTMatriz
        DBGUTPeriodicidade.PTabelaNome => new DBGUTPeriodicidade(id, oCnn), // GUTPeriodicidade
        DBGUTPeriodicidadeStatus.PTabelaNome => new DBGUTPeriodicidadeStatus(id, oCnn), // GUTPeriodicidadeStatus
        DBGUTTipo.PTabelaNome => new DBGUTTipo(id, oCnn), // GUTTipo
        DBHistorico.PTabelaNome => new DBHistorico(id, oCnn), // Historico
        DBHonorariosDadosContrato.PTabelaNome => new DBHonorariosDadosContrato(id, oCnn), // HonorariosDadosContrato
        DBHorasTrab.PTabelaNome => new DBHorasTrab(id, oCnn), // HorasTrab
        DBInstancia.PTabelaNome => new DBInstancia(id, oCnn), // Instancia
        DBJustica.PTabelaNome => new DBJustica(id, oCnn), // Justica
        DBLigacoes.PTabelaNome => new DBLigacoes(id, oCnn), // Ligacoes
        DBLivroCaixa.PTabelaNome => new DBLivroCaixa(id, oCnn), // LivroCaixa
        DBLivroCaixaClientes.PTabelaNome => new DBLivroCaixaClientes(id, oCnn), // LivroCaixaClientes
        DBModelosDocumentos.PTabelaNome => new DBModelosDocumentos(id, oCnn), // ModelosDocumentos
        DBNECompromissos.PTabelaNome => new DBNECompromissos(id, oCnn), // NECompromissos
        DBNENotas.PTabelaNome => new DBNENotas(id, oCnn), // NENotas
        DBNEPalavrasChaves.PTabelaNome => new DBNEPalavrasChaves(id, oCnn), // NEPalavrasChaves
        DBObjetos.PTabelaNome => new DBObjetos(id, oCnn), // Objetos
        DBOperador.PTabelaNome => new DBOperador(id, oCnn), // Operador
        DBOperadorEMailPopup.PTabelaNome => new DBOperadorEMailPopup(id, oCnn), // OperadorEMailPopup
        DBOperadores.PTabelaNome => new DBOperadores(id, oCnn), // Operadores
        DBOperadorGrupo.PTabelaNome => new DBOperadorGrupo(id, oCnn), // OperadorGrupo
        DBOperadorGrupos.PTabelaNome => new DBOperadorGrupos(id, oCnn), // OperadorGrupos
        DBOperadorGruposAgenda.PTabelaNome => new DBOperadorGruposAgenda(id, oCnn), // OperadorGruposAgenda
        DBOperadorGruposAgendaOperadores.PTabelaNome => new DBOperadorGruposAgendaOperadores(id, oCnn), // OperadorGruposAgendaOperadores
        DBOponentes.PTabelaNome => new DBOponentes(id, oCnn), // Oponentes
        DBOponentesRepLegal.PTabelaNome => new DBOponentesRepLegal(id, oCnn), // OponentesRepLegal
        DBOutrasPartesCliente.PTabelaNome => new DBOutrasPartesCliente(id, oCnn), // OutrasPartesCliente
        DBPaises.PTabelaNome => new DBPaises(id, oCnn), // Paises
        DBParceriaProc.PTabelaNome => new DBParceriaProc(id, oCnn), // ParceriaProc
        DBParteClienteOutras.PTabelaNome => new DBParteClienteOutras(id, oCnn), // ParteClienteOutras
        DBPenhora.PTabelaNome => new DBPenhora(id, oCnn), // Penhora
        DBPenhoraStatus.PTabelaNome => new DBPenhoraStatus(id, oCnn), // PenhoraStatus
        DBPoderJudiciarioAssociado.PTabelaNome => new DBPoderJudiciarioAssociado(id, oCnn), // PoderJudiciarioAssociado
        DBPontoVirtual.PTabelaNome => new DBPontoVirtual(id, oCnn), // PontoVirtual
        DBPontoVirtualAcessos.PTabelaNome => new DBPontoVirtualAcessos(id, oCnn), // PontoVirtualAcessos
        DBPosicaoOutrasPartes.PTabelaNome => new DBPosicaoOutrasPartes(id, oCnn), // PosicaoOutrasPartes
        DBPrecatoria.PTabelaNome => new DBPrecatoria(id, oCnn), // Precatoria
        DBPreClientes.PTabelaNome => new DBPreClientes(id, oCnn), // PreClientes
        DBPrepostos.PTabelaNome => new DBPrepostos(id, oCnn), // Prepostos
        DBProCDA.PTabelaNome => new DBProCDA(id, oCnn), // ProCDA
        DBProcessos.PTabelaNome => new DBProcessos(id, oCnn), // Processos
        DBProcessosObsReport.PTabelaNome => new DBProcessosObsReport(id, oCnn), // ProcessosObsReport
        DBProcessosParados.PTabelaNome => new DBProcessosParados(id, oCnn), // ProcessosParados
        DBProcessOutputEngine.PTabelaNome => new DBProcessOutputEngine(id, oCnn), // ProcessOutputEngine
        DBProcessOutPutIDs.PTabelaNome => new DBProcessOutPutIDs(id, oCnn), // ProcessOutPutIDs
        DBProcessOutputRequest.PTabelaNome => new DBProcessOutputRequest(id, oCnn), // ProcessOutputRequest
        DBProcessOutputSources.PTabelaNome => new DBProcessOutputSources(id, oCnn), // ProcessOutputSources
        DBProDepositos.PTabelaNome => new DBProDepositos(id, oCnn), // ProDepositos
        DBProDespesas.PTabelaNome => new DBProDespesas(id, oCnn), // ProDespesas
        DBProObservacoes.PTabelaNome => new DBProObservacoes(id, oCnn), // ProObservacoes
        DBProPartes.PTabelaNome => new DBProPartes(id, oCnn), // ProPartes
        DBProProcuradores.PTabelaNome => new DBProProcuradores(id, oCnn), // ProProcuradores
        DBProResumos.PTabelaNome => new DBProResumos(id, oCnn), // ProResumos
        DBProSucumbencia.PTabelaNome => new DBProSucumbencia(id, oCnn), // ProSucumbencia
        DBProTipoBaixa.PTabelaNome => new DBProTipoBaixa(id, oCnn), // ProTipoBaixa
        DBProValores.PTabelaNome => new DBProValores(id, oCnn), // ProValores
        DBRamal.PTabelaNome => new DBRamal(id, oCnn), // Ramal
        DBRecados.PTabelaNome => new DBRecados(id, oCnn), // Recados
        DBRegimeTributacao.PTabelaNome => new DBRegimeTributacao(id, oCnn), // RegimeTributacao
        DBReuniao.PTabelaNome => new DBReuniao(id, oCnn), // Reuniao
        DBReuniaoPessoas.PTabelaNome => new DBReuniaoPessoas(id, oCnn), // ReuniaoPessoas
        DBRito.PTabelaNome => new DBRito(id, oCnn), // Rito
        DBServicos.PTabelaNome => new DBServicos(id, oCnn), // Servicos
        DBSetor.PTabelaNome => new DBSetor(id, oCnn), // Setor
        DBSituacao.PTabelaNome => new DBSituacao(id, oCnn), // Situacao
        DBSMSAlice.PTabelaNome => new DBSMSAlice(id, oCnn), // SMSAlice
        DBStatusAndamento.PTabelaNome => new DBStatusAndamento(id, oCnn), // StatusAndamento
        DBStatusBiu.PTabelaNome => new DBStatusBiu(id, oCnn), // StatusBiu
        DBStatusHTrab.PTabelaNome => new DBStatusHTrab(id, oCnn), // StatusHTrab
        DBStatusInstancia.PTabelaNome => new DBStatusInstancia(id, oCnn), // StatusInstancia
        DBStatusTarefas.PTabelaNome => new DBStatusTarefas(id, oCnn), // StatusTarefas
        DBTerceiros.PTabelaNome => new DBTerceiros(id, oCnn), // Terceiros
        DBTipoCompromisso.PTabelaNome => new DBTipoCompromisso(id, oCnn), // TipoCompromisso
        DBTipoContatoCRM.PTabelaNome => new DBTipoContatoCRM(id, oCnn), // TipoContatoCRM
        DBTipoEMail.PTabelaNome => new DBTipoEMail(id, oCnn), // TipoEMail
        DBTipoEndereco.PTabelaNome => new DBTipoEndereco(id, oCnn), // TipoEndereco
        DBTipoEnderecoSistema.PTabelaNome => new DBTipoEnderecoSistema(id, oCnn), // TipoEnderecoSistema
        DBTipoModeloDocumento.PTabelaNome => new DBTipoModeloDocumento(id, oCnn), // TipoModeloDocumento
        DBTipoOrigemSucumbencia.PTabelaNome => new DBTipoOrigemSucumbencia(id, oCnn), // TipoOrigemSucumbencia
        DBTipoProDesposito.PTabelaNome => new DBTipoProDesposito(id, oCnn), // TipoProDesposito
        DBTipoRecurso.PTabelaNome => new DBTipoRecurso(id, oCnn), // TipoRecurso
        DBTiposAcao.PTabelaNome => new DBTiposAcao(id, oCnn), // TiposAcao
        DBTipoStatusBiu.PTabelaNome => new DBTipoStatusBiu(id, oCnn), // TipoStatusBiu
        DBTipoValorProcesso.PTabelaNome => new DBTipoValorProcesso(id, oCnn), // TipoValorProcesso
        DBTribEnderecos.PTabelaNome => new DBTribEnderecos(id, oCnn), // TribEnderecos
        DBTribunal.PTabelaNome => new DBTribunal(id, oCnn), // Tribunal
        DBUF.PTabelaNome => new DBUF(id, oCnn), // UF
        DBUltimosProcessos.PTabelaNome => new DBUltimosProcessos(id, oCnn), // UltimosProcessos
        DBViaRecebimento.PTabelaNome => new DBViaRecebimento(id, oCnn), // ViaRecebimento
        _ => throw new Exception($"GlobalObjectLoad {tabela}")};
    public List<DBInfoSystem> ListaSecureSearchable
    {
        get
        {
            var mRet = new List<DBInfoSystem>();
            mRet.AddRange(DBAdvogadosODicInfo.List);
            mRet.AddRange(DBAlertasODicInfo.List);
            mRet.AddRange(DBAlertasEnviadosODicInfo.List);
            mRet.AddRange(DBAndCompODicInfo.List);
            mRet.AddRange(DBApensoODicInfo.List);
            mRet.AddRange(DBApenso2ODicInfo.List);
            mRet.AddRange(DBAuditor4KODicInfo.List);
            mRet.AddRange(DBClientesODicInfo.List);
            mRet.AddRange(DBClientesSociosODicInfo.List);
            mRet.AddRange(DBColaboradoresODicInfo.List);
            mRet.AddRange(DBContatoCRMODicInfo.List);
            mRet.AddRange(DBDiario2ODicInfo.List);
            mRet.AddRange(DBEnderecosODicInfo.List);
            mRet.AddRange(DBEnderecoSistemaODicInfo.List);
            mRet.AddRange(DBEscritoriosODicInfo.List);
            mRet.AddRange(DBFornecedoresODicInfo.List);
            mRet.AddRange(DBForoODicInfo.List);
            mRet.AddRange(DBFuncionariosODicInfo.List);
            mRet.AddRange(DBGraphODicInfo.List);
            mRet.AddRange(DBHistoricoODicInfo.List);
            mRet.AddRange(DBHonorariosDadosContratoODicInfo.List);
            mRet.AddRange(DBHorasTrabODicInfo.List);
            mRet.AddRange(DBInstanciaODicInfo.List);
            mRet.AddRange(DBLigacoesODicInfo.List);
            mRet.AddRange(DBNENotasODicInfo.List);
            mRet.AddRange(DBOponentesODicInfo.List);
            mRet.AddRange(DBOponentesRepLegalODicInfo.List);
            mRet.AddRange(DBOutrasPartesClienteODicInfo.List);
            mRet.AddRange(DBParceriaProcODicInfo.List);
            mRet.AddRange(DBParteClienteODicInfo.List);
            mRet.AddRange(DBParteClienteOutrasODicInfo.List);
            mRet.AddRange(DBParteOponenteODicInfo.List);
            mRet.AddRange(DBPenhoraODicInfo.List);
            mRet.AddRange(DBPontoVirtualODicInfo.List);
            mRet.AddRange(DBPontoVirtualAcessosODicInfo.List);
            mRet.AddRange(DBPrecatoriaODicInfo.List);
            mRet.AddRange(DBPreClientesODicInfo.List);
            mRet.AddRange(DBPrepostosODicInfo.List);
            mRet.AddRange(DBProCDAODicInfo.List);
            mRet.AddRange(DBProcessosODicInfo.List);
            mRet.AddRange(DBProcessosObsReportODicInfo.List);
            mRet.AddRange(DBProcessosParadosODicInfo.List);
            mRet.AddRange(DBProcessOutputEngineODicInfo.List);
            mRet.AddRange(DBProcessOutPutIDsODicInfo.List);
            mRet.AddRange(DBProcessOutputRequestODicInfo.List);
            mRet.AddRange(DBProcessOutputSourcesODicInfo.List);
            mRet.AddRange(DBProDepositosODicInfo.List);
            mRet.AddRange(DBProDespesasODicInfo.List);
            mRet.AddRange(DBProObservacoesODicInfo.List);
            mRet.AddRange(DBProPartesODicInfo.List);
            mRet.AddRange(DBProProcuradoresODicInfo.List);
            mRet.AddRange(DBProResumosODicInfo.List);
            mRet.AddRange(DBProSucumbenciaODicInfo.List);
            mRet.AddRange(DBProValoresODicInfo.List);
            mRet.AddRange(DBReuniaoODicInfo.List);
            mRet.AddRange(DBReuniaoPessoasODicInfo.List);
            mRet.AddRange(DBTerceirosODicInfo.List);
            return mRet;
        }
    }

    public List<IODicInfo> ListaSecureSearchableDicInfo => [new DBAdvogadosODicInfo(), new DBAlertasODicInfo(), new DBAlertasEnviadosODicInfo(), new DBAndCompODicInfo(), new DBApensoODicInfo(), new DBApenso2ODicInfo(), new DBAuditor4KODicInfo(), new DBClientesODicInfo(), new DBClientesSociosODicInfo(), new DBColaboradoresODicInfo(), new DBContatoCRMODicInfo(), new DBDiario2ODicInfo(), new DBEnderecosODicInfo(), new DBEnderecoSistemaODicInfo(), new DBEscritoriosODicInfo(), new DBFornecedoresODicInfo(), new DBForoODicInfo(), new DBFuncionariosODicInfo(), new DBGraphODicInfo(), new DBHistoricoODicInfo(), new DBHonorariosDadosContratoODicInfo(), new DBHorasTrabODicInfo(), new DBInstanciaODicInfo(), new DBLigacoesODicInfo(), new DBNENotasODicInfo(), new DBOponentesODicInfo(), new DBOponentesRepLegalODicInfo(), new DBOutrasPartesClienteODicInfo(), new DBParceriaProcODicInfo(), new DBParteClienteODicInfo(), new DBParteClienteOutrasODicInfo(), new DBParteOponenteODicInfo(), new DBPenhoraODicInfo(), new DBPontoVirtualODicInfo(), new DBPontoVirtualAcessosODicInfo(), new DBPrecatoriaODicInfo(), new DBPreClientesODicInfo(), new DBPrepostosODicInfo(), new DBProCDAODicInfo(), new DBProcessosODicInfo(), new DBProcessosObsReportODicInfo(), new DBProcessosParadosODicInfo(), new DBProcessOutputEngineODicInfo(), new DBProcessOutPutIDsODicInfo(), new DBProcessOutputRequestODicInfo(), new DBProcessOutputSourcesODicInfo(), new DBProDepositosODicInfo(), new DBProDespesasODicInfo(), new DBProObservacoesODicInfo(), new DBProPartesODicInfo(), new DBProProcuradoresODicInfo(), new DBProResumosODicInfo(), new DBProSucumbenciaODicInfo(), new DBProValoresODicInfo(), new DBReuniaoODicInfo(), new DBReuniaoPessoasODicInfo(), new DBTerceirosODicInfo()];

#pragma warning disable CA1822 // Mark members as 

    public List<DBInfoSystem> Lista
#pragma warning restore CA1822 // Mark members as 

    {
        get
        {
            var mRet = new List<DBInfoSystem>();
            mRet.AddRange(DBAcaoODicInfo.List);
            mRet.AddRange(DBAdvogadosODicInfo.List);
            mRet.AddRange(DBAgendaODicInfo.List);
            mRet.AddRange(DBAgenda2AgendaODicInfo.List);
            mRet.AddRange(DBAgendaFinanceiroODicInfo.List);
            mRet.AddRange(DBAgendaQuemODicInfo.List);
            mRet.AddRange(DBAgendaRecordsODicInfo.List);
            mRet.AddRange(DBAgendaRepetirODicInfo.List);
            mRet.AddRange(DBAgendaRepetirDiasODicInfo.List);
            mRet.AddRange(DBAgendaStatusODicInfo.List);
            mRet.AddRange(DBAlarmSMSODicInfo.List);
            mRet.AddRange(DBAlertasODicInfo.List);
            mRet.AddRange(DBAlertasEnviadosODicInfo.List);
            mRet.AddRange(DBAndamentosMDODicInfo.List);
            mRet.AddRange(DBAndCompODicInfo.List);
            mRet.AddRange(DBAnexamentoRegistrosODicInfo.List);
            mRet.AddRange(DBApensoODicInfo.List);
            mRet.AddRange(DBApenso2ODicInfo.List);
            mRet.AddRange(DBAreaODicInfo.List);
            mRet.AddRange(DBAreasJusticaODicInfo.List);
            mRet.AddRange(DBAtividadesODicInfo.List);
            mRet.AddRange(DBAuditor4KODicInfo.List);
            mRet.AddRange(DBBensClassificacaoODicInfo.List);
            mRet.AddRange(DBBensMateriaisODicInfo.List);
            mRet.AddRange(DBCargosODicInfo.List);
            mRet.AddRange(DBCargosEscODicInfo.List);
            mRet.AddRange(DBCargosEscClassODicInfo.List);
            mRet.AddRange(DBCidadeODicInfo.List);
            mRet.AddRange(DBClientesODicInfo.List);
            mRet.AddRange(DBClientesSociosODicInfo.List);
            mRet.AddRange(DBColaboradoresODicInfo.List);
            mRet.AddRange(DBContaCorrenteODicInfo.List);
            mRet.AddRange(DBContatoCRMODicInfo.List);
            mRet.AddRange(DBContatoCRMOperadorODicInfo.List);
            mRet.AddRange(DBContatoCRMViewODicInfo.List);
            mRet.AddRange(DBContratosODicInfo.List);
            mRet.AddRange(DBDadosProcuracaoODicInfo.List);
            mRet.AddRange(DBDiario2ODicInfo.List);
            mRet.AddRange(DBDivisaoTribunalODicInfo.List);
            mRet.AddRange(DBDocsRecebidosItensODicInfo.List);
            mRet.AddRange(DBDocumentosODicInfo.List);
            mRet.AddRange(DBEMPClassRiscosODicInfo.List);
            mRet.AddRange(DBEnderecosODicInfo.List);
            mRet.AddRange(DBEnderecoSistemaODicInfo.List);
            mRet.AddRange(DBEndTitODicInfo.List);
            mRet.AddRange(DBEnquadramentoEmpresaODicInfo.List);
            mRet.AddRange(DBEscritoriosODicInfo.List);
            mRet.AddRange(DBEventoPrazoAgendaODicInfo.List);
            mRet.AddRange(DBFaseODicInfo.List);
            mRet.AddRange(DBFornecedoresODicInfo.List);
            mRet.AddRange(DBForoODicInfo.List);
            mRet.AddRange(DBFuncaoODicInfo.List);
            mRet.AddRange(DBFuncionariosODicInfo.List);
            mRet.AddRange(DBGraphODicInfo.List);
            mRet.AddRange(DBGruposEmpresasODicInfo.List);
            mRet.AddRange(DBGruposEmpresasCliODicInfo.List);
            mRet.AddRange(DBGUTAtividadesODicInfo.List);
            mRet.AddRange(DBGUTAtividadesMatrizODicInfo.List);
            mRet.AddRange(DBGUTMatrizODicInfo.List);
            mRet.AddRange(DBGUTPeriodicidadeODicInfo.List);
            mRet.AddRange(DBGUTPeriodicidadeStatusODicInfo.List);
            mRet.AddRange(DBGUTTipoODicInfo.List);
            mRet.AddRange(DBHistoricoODicInfo.List);
            mRet.AddRange(DBHonorariosDadosContratoODicInfo.List);
            mRet.AddRange(DBHorasTrabODicInfo.List);
            mRet.AddRange(DBInstanciaODicInfo.List);
            mRet.AddRange(DBJusticaODicInfo.List);
            mRet.AddRange(DBLigacoesODicInfo.List);
            mRet.AddRange(DBLivroCaixaODicInfo.List);
            mRet.AddRange(DBLivroCaixaClientesODicInfo.List);
            mRet.AddRange(DBModelosDocumentosODicInfo.List);
            mRet.AddRange(DBNECompromissosODicInfo.List);
            mRet.AddRange(DBNENotasODicInfo.List);
            mRet.AddRange(DBNEPalavrasChavesODicInfo.List);
            mRet.AddRange(DBObjetosODicInfo.List);
            mRet.AddRange(DBOperadorODicInfo.List);
            mRet.AddRange(DBOperadorEMailPopupODicInfo.List);
            mRet.AddRange(DBOperadoresODicInfo.List);
            mRet.AddRange(DBOperadorGrupoODicInfo.List);
            mRet.AddRange(DBOperadorGruposODicInfo.List);
            mRet.AddRange(DBOperadorGruposAgendaODicInfo.List);
            mRet.AddRange(DBOperadorGruposAgendaOperadoresODicInfo.List);
            mRet.AddRange(DBOponentesODicInfo.List);
            mRet.AddRange(DBOponentesRepLegalODicInfo.List);
            mRet.AddRange(DBOutrasPartesClienteODicInfo.List);
            mRet.AddRange(DBPaisesODicInfo.List);
            mRet.AddRange(DBParceriaProcODicInfo.List);
            mRet.AddRange(DBParteClienteODicInfo.List);
            mRet.AddRange(DBParteClienteOutrasODicInfo.List);
            mRet.AddRange(DBParteOponenteODicInfo.List);
            mRet.AddRange(DBPenhoraODicInfo.List);
            mRet.AddRange(DBPenhoraStatusODicInfo.List);
            mRet.AddRange(DBPoderJudiciarioAssociadoODicInfo.List);
            mRet.AddRange(DBPontoVirtualODicInfo.List);
            mRet.AddRange(DBPontoVirtualAcessosODicInfo.List);
            mRet.AddRange(DBPosicaoOutrasPartesODicInfo.List);
            mRet.AddRange(DBPrecatoriaODicInfo.List);
            mRet.AddRange(DBPreClientesODicInfo.List);
            mRet.AddRange(DBPrepostosODicInfo.List);
            mRet.AddRange(DBProBarCODEODicInfo.List);
            mRet.AddRange(DBProCDAODicInfo.List);
            mRet.AddRange(DBProcessosODicInfo.List);
            mRet.AddRange(DBProcessosObsReportODicInfo.List);
            mRet.AddRange(DBProcessosParadosODicInfo.List);
            mRet.AddRange(DBProcessOutputEngineODicInfo.List);
            mRet.AddRange(DBProcessOutPutIDsODicInfo.List);
            mRet.AddRange(DBProcessOutputRequestODicInfo.List);
            mRet.AddRange(DBProcessOutputSourcesODicInfo.List);
            mRet.AddRange(DBProDepositosODicInfo.List);
            mRet.AddRange(DBProDespesasODicInfo.List);
            mRet.AddRange(DBProObservacoesODicInfo.List);
            mRet.AddRange(DBProPartesODicInfo.List);
            mRet.AddRange(DBProProcuradoresODicInfo.List);
            mRet.AddRange(DBProResumosODicInfo.List);
            mRet.AddRange(DBProSucumbenciaODicInfo.List);
            mRet.AddRange(DBProTipoBaixaODicInfo.List);
            mRet.AddRange(DBProValoresODicInfo.List);
            mRet.AddRange(DBRamalODicInfo.List);
            mRet.AddRange(DBRecadosODicInfo.List);
            mRet.AddRange(DBRegimeTributacaoODicInfo.List);
            mRet.AddRange(DBReuniaoODicInfo.List);
            mRet.AddRange(DBReuniaoPessoasODicInfo.List);
            mRet.AddRange(DBRitoODicInfo.List);
            mRet.AddRange(DBServicosODicInfo.List);
            mRet.AddRange(DBSetorODicInfo.List);
            mRet.AddRange(DBSituacaoODicInfo.List);
            mRet.AddRange(DBSMSAliceODicInfo.List);
            mRet.AddRange(DBStatusAndamentoODicInfo.List);
            mRet.AddRange(DBStatusBiuODicInfo.List);
            mRet.AddRange(DBStatusHTrabODicInfo.List);
            mRet.AddRange(DBStatusInstanciaODicInfo.List);
            mRet.AddRange(DBStatusTarefasODicInfo.List);
            mRet.AddRange(DBTerceirosODicInfo.List);
            mRet.AddRange(DBTipoCompromissoODicInfo.List);
            mRet.AddRange(DBTipoContatoCRMODicInfo.List);
            mRet.AddRange(DBTipoEMailODicInfo.List);
            mRet.AddRange(DBTipoEnderecoODicInfo.List);
            mRet.AddRange(DBTipoEnderecoSistemaODicInfo.List);
            mRet.AddRange(DBTipoModeloDocumentoODicInfo.List);
            mRet.AddRange(DBTipoOrigemSucumbenciaODicInfo.List);
            mRet.AddRange(DBTipoProDespositoODicInfo.List);
            mRet.AddRange(DBTipoRecursoODicInfo.List);
            mRet.AddRange(DBTiposAcaoODicInfo.List);
            mRet.AddRange(DBTipoStatusBiuODicInfo.List);
            mRet.AddRange(DBTipoValorProcessoODicInfo.List);
            mRet.AddRange(DBTribEnderecosODicInfo.List);
            mRet.AddRange(DBTribunalODicInfo.List);
            mRet.AddRange(DBUFODicInfo.List);
            mRet.AddRange(DBUltimosProcessosODicInfo.List);
            mRet.AddRange(DBViaRecebimentoODicInfo.List);
            mRet.AddRange(DBAgendaRelatorioODicInfo.List);
            mRet.AddRange(DBAgendaSemanaODicInfo.List);
            return mRet;
        }
    }
#if (DEBUG)
#region CERT_TABLES

/// <returns></returns>
public  bool CodeSigntature_DBAcao() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAdvogados() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgenda() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgenda2Agenda() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgendaFinanceiro() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgendaQuem() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgendaRecords() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgendaRepetir() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgendaRepetirDias() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgendaStatus() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAlarmSMS() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAlertas() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAlertasEnviados() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAndamentosMD() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAndComp() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAnexamentoRegistros() => true;


/// <returns></returns>
public  bool CodeSigntature_DBApenso() => true;


/// <returns></returns>
public  bool CodeSigntature_DBApenso2() => true;


/// <returns></returns>
public  bool CodeSigntature_DBArea() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAreasJustica() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAtividades() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAuditor4K() => true;


/// <returns></returns>
public  bool CodeSigntature_DBBensClassificacao() => true;


/// <returns></returns>
public  bool CodeSigntature_DBBensMateriais() => true;


/// <returns></returns>
public  bool CodeSigntature_DBCargos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBCargosEsc() => true;


/// <returns></returns>
public  bool CodeSigntature_DBCargosEscClass() => true;


/// <returns></returns>
public  bool CodeSigntature_DBCidade() => true;


/// <returns></returns>
public  bool CodeSigntature_DBClientes() => true;


/// <returns></returns>
public  bool CodeSigntature_DBClientesSocios() => true;


/// <returns></returns>
public  bool CodeSigntature_DBColaboradores() => true;


/// <returns></returns>
public  bool CodeSigntature_DBContaCorrente() => true;


/// <returns></returns>
public  bool CodeSigntature_DBContatoCRM() => true;


/// <returns></returns>
public  bool CodeSigntature_DBContatoCRMOperador() => true;


/// <returns></returns>
public  bool CodeSigntature_DBContatoCRMView() => true;


/// <returns></returns>
public  bool CodeSigntature_DBContratos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBDadosProcuracao() => true;


/// <returns></returns>
public  bool CodeSigntature_DBDiario2() => true;


/// <returns></returns>
public  bool CodeSigntature_DBDivisaoTribunal() => true;


/// <returns></returns>
public  bool CodeSigntature_DBDocsRecebidosItens() => true;


/// <returns></returns>
public  bool CodeSigntature_DBDocumentos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBEMPClassRiscos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBEnderecos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBEnderecoSistema() => true;


/// <returns></returns>
public  bool CodeSigntature_DBEndTit() => true;


/// <returns></returns>
public  bool CodeSigntature_DBEnquadramentoEmpresa() => true;


/// <returns></returns>
public  bool CodeSigntature_DBEscritorios() => true;


/// <returns></returns>
public  bool CodeSigntature_DBEventoPrazoAgenda() => true;


/// <returns></returns>
public  bool CodeSigntature_DBFase() => true;


/// <returns></returns>
public  bool CodeSigntature_DBFornecedores() => true;


/// <returns></returns>
public  bool CodeSigntature_DBForo() => true;


/// <returns></returns>
public  bool CodeSigntature_DBFuncao() => true;


/// <returns></returns>
public  bool CodeSigntature_DBFuncionarios() => true;


/// <returns></returns>
public  bool CodeSigntature_DBGraph() => true;


/// <returns></returns>
public  bool CodeSigntature_DBGruposEmpresas() => true;


/// <returns></returns>
public  bool CodeSigntature_DBGruposEmpresasCli() => true;


/// <returns></returns>
public  bool CodeSigntature_DBGUTAtividades() => true;


/// <returns></returns>
public  bool CodeSigntature_DBGUTAtividadesMatriz() => true;


/// <returns></returns>
public  bool CodeSigntature_DBGUTMatriz() => true;


/// <returns></returns>
public  bool CodeSigntature_DBGUTPeriodicidade() => true;


/// <returns></returns>
public  bool CodeSigntature_DBGUTPeriodicidadeStatus() => true;


/// <returns></returns>
public  bool CodeSigntature_DBGUTTipo() => true;


/// <returns></returns>
public  bool CodeSigntature_DBHistorico() => true;


/// <returns></returns>
public  bool CodeSigntature_DBHonorariosDadosContrato() => true;


/// <returns></returns>
public  bool CodeSigntature_DBHorasTrab() => true;


/// <returns></returns>
public  bool CodeSigntature_DBInstancia() => true;


/// <returns></returns>
public  bool CodeSigntature_DBJustica() => true;


/// <returns></returns>
public  bool CodeSigntature_DBLigacoes() => true;


/// <returns></returns>
public  bool CodeSigntature_DBLivroCaixa() => true;


/// <returns></returns>
public  bool CodeSigntature_DBLivroCaixaClientes() => true;


/// <returns></returns>
public  bool CodeSigntature_DBModelosDocumentos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBNECompromissos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBNENotas() => true;


/// <returns></returns>
public  bool CodeSigntature_DBNEPalavrasChaves() => true;


/// <returns></returns>
public  bool CodeSigntature_DBObjetos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOperador() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOperadorEMailPopup() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOperadores() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOperadorGrupo() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOperadorGrupos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOperadorGruposAgenda() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOperadorGruposAgendaOperadores() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOponentes() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOponentesRepLegal() => true;


/// <returns></returns>
public  bool CodeSigntature_DBOutrasPartesCliente() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPaises() => true;


/// <returns></returns>
public  bool CodeSigntature_DBParceriaProc() => true;


/// <returns></returns>
public  bool CodeSigntature_DBParteCliente() => true;


/// <returns></returns>
public  bool CodeSigntature_DBParteClienteOutras() => true;


/// <returns></returns>
public  bool CodeSigntature_DBParteOponente() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPenhora() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPenhoraStatus() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPoderJudiciarioAssociado() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPontoVirtual() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPontoVirtualAcessos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPosicaoOutrasPartes() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPrecatoria() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPreClientes() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPrepostos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProBarCODE() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProCDA() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProcessos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProcessosObsReport() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProcessosParados() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProcessOutputEngine() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProcessOutPutIDs() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProcessOutputRequest() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProcessOutputSources() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProDepositos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProDespesas() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProObservacoes() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProPartes() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProProcuradores() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProResumos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProSucumbencia() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProTipoBaixa() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProValores() => true;


/// <returns></returns>
public  bool CodeSigntature_DBRamal() => true;


/// <returns></returns>
public  bool CodeSigntature_DBRecados() => true;


/// <returns></returns>
public  bool CodeSigntature_DBRegimeTributacao() => true;


/// <returns></returns>
public  bool CodeSigntature_DBReuniao() => true;


/// <returns></returns>
public  bool CodeSigntature_DBReuniaoPessoas() => true;


/// <returns></returns>
public  bool CodeSigntature_DBRito() => true;


/// <returns></returns>
public  bool CodeSigntature_DBServicos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBSetor() => true;


/// <returns></returns>
public  bool CodeSigntature_DBSituacao() => true;


/// <returns></returns>
public  bool CodeSigntature_DBSMSAlice() => true;


/// <returns></returns>
public  bool CodeSigntature_DBStatusAndamento() => true;


/// <returns></returns>
public  bool CodeSigntature_DBStatusBiu() => true;


/// <returns></returns>
public  bool CodeSigntature_DBStatusHTrab() => true;


/// <returns></returns>
public  bool CodeSigntature_DBStatusInstancia() => true;


/// <returns></returns>
public  bool CodeSigntature_DBStatusTarefas() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTerceiros() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoCompromisso() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoContatoCRM() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoEMail() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoEndereco() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoEnderecoSistema() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoModeloDocumento() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoOrigemSucumbencia() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoProDesposito() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoRecurso() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTiposAcao() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoStatusBiu() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTipoValorProcesso() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTribEnderecos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBTribunal() => true;


/// <returns></returns>
public  bool CodeSigntature_DBUF() => true;


/// <returns></returns>
public  bool CodeSigntature_DBUltimosProcessos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBViaRecebimento() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgendaRelatorio() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgendaSemana() => true;

#endregion
#endif
}
#endif
