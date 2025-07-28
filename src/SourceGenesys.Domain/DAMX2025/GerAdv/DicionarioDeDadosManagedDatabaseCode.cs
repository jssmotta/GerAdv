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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    public string DevourerBuildID => "2024";

    [Serializable]
    public enum DicionarioDeDadosTabelas
    {
        Acao = 1,
        Advogados = 2,
        Agenda = 3,
        AgendaQuem = 4,
        AgendaRepetirDias = 5,
        Alertas = 6,
        AlertasEnviados = 7,
        AndamentosMD = 8,
        AndComp = 9,
        AnexamentoRegistros = 10,
        Apenso2 = 11,
        Area = 12,
        AreasJustica = 13,
        Atividades = 14,
        Auditor4K = 15,
        BensClassificacao = 16,
        BensMateriais = 17,
        Cargos = 18,
        CargosEsc = 19,
        CargosEscClass = 20,
        Cidade = 21,
        Clientes = 22,
        ClientesSocios = 23,
        Colaboradores = 24,
        ContaCorrente = 25,
        ContatoCRMView = 26,
        Contratos = 27,
        DadosProcuracao = 28,
        Diario2 = 29,
        DivisaoTribunal = 30,
        Documentos = 31,
        EMPClassRiscos = 32,
        Enderecos = 33,
        EnderecoSistema = 34,
        EndTit = 35,
        EnquadramentoEmpresa = 36,
        Escritorios = 37,
        EventoPrazoAgenda = 38,
        Fase = 39,
        Fornecedores = 40,
        Foro = 41,
        Funcao = 42,
        Funcionarios = 43,
        Graph = 44,
        GruposEmpresas = 45,
        GruposEmpresasCli = 46,
        GUTAtividades = 47,
        GUTAtividadesMatriz = 48,
        GUTMatriz = 49,
        GUTPeriodicidade = 50,
        GUTPeriodicidadeStatus = 51,
        GUTTipo = 52,
        HonorariosDadosContrato = 53,
        HorasTrab = 54,
        Instancia = 55,
        Justica = 56,
        Ligacoes = 57,
        LivroCaixa = 58,
        ModelosDocumentos = 59,
        NECompromissos = 60,
        NENotas = 61,
        NEPalavrasChaves = 62,
        Objetos = 63,
        Operador = 64,
        OperadorEMailPopup = 65,
        Operadores = 66,
        OperadorGrupo = 67,
        OperadorGrupos = 68,
        OperadorGruposAgenda = 69,
        Oponentes = 70,
        OponentesRepLegal = 71,
        OutrasPartesCliente = 72,
        Paises = 73,
        ParceriaProc = 74,
        ParteCliente = 75,
        ParteClienteOutras = 76,
        ParteOponente = 77,
        Penhora = 78,
        PenhoraStatus = 79,
        PoderJudiciarioAssociado = 80,
        PontoVirtual = 81,
        PontoVirtualAcessos = 82,
        PosicaoOutrasPartes = 83,
        PreClientes = 84,
        Prepostos = 85,
        ProBarCODE = 86,
        ProCDA = 87,
        ProcessosObsReport = 88,
        ProcessosParados = 89,
        ProcessOutputEngine = 90,
        ProcessOutPutIDs = 91,
        ProcessOutputRequest = 92,
        ProcessOutputSources = 93,
        ProDepositos = 94,
        ProDespesas = 95,
        ProObservacoes = 96,
        ProPartes = 97,
        ProProcuradores = 98,
        ProResumos = 99,
        ProSucumbencia = 100,
        ProTipoBaixa = 101,
        ProValores = 102,
        Ramal = 103,
        RegimeTributacao = 104,
        Reuniao = 105,
        Rito = 106,
        Servicos = 107,
        Setor = 108,
        Situacao = 109,
        SMSAlice = 110,
        StatusAndamento = 111,
        StatusBiu = 112,
        StatusHTrab = 113,
        StatusInstancia = 114,
        StatusTarefas = 115,
        Terceiros = 116,
        TipoCompromisso = 117,
        TipoContatoCRM = 118,
        TipoEMail = 119,
        TipoEndereco = 120,
        TipoEnderecoSistema = 121,
        TipoModeloDocumento = 122,
        TipoOrigemSucumbencia = 123,
        TipoProDesposito = 124,
        TipoRecurso = 125,
        TiposAcao = 126,
        TipoStatusBiu = 127,
        TipoValorProcesso = 128,
        TribEnderecos = 129,
        Tribunal = 130,
        UF = 131,
        UltimosProcessos = 132,
        ViaRecebimento = 133,
        AgendaRelatorio = 134,
        AgendaSemana = 135
    }

    public int IdTabelaByNome(string nome) => nome switch
    {
        DBAcao.PTabelaNome => 1,
        DBAdvogados.PTabelaNome => 2,
        DBAgenda.PTabelaNome => 3,
        DBAgendaQuem.PTabelaNome => 4,
        DBAgendaRepetirDias.PTabelaNome => 5,
        DBAlertas.PTabelaNome => 6,
        DBAlertasEnviados.PTabelaNome => 7,
        DBAndamentosMD.PTabelaNome => 8,
        DBAndComp.PTabelaNome => 9,
        DBAnexamentoRegistros.PTabelaNome => 10,
        DBApenso2.PTabelaNome => 11,
        DBArea.PTabelaNome => 12,
        DBAreasJustica.PTabelaNome => 13,
        DBAtividades.PTabelaNome => 14,
        DBAuditor4K.PTabelaNome => 15,
        DBBensClassificacao.PTabelaNome => 16,
        DBBensMateriais.PTabelaNome => 17,
        DBCargos.PTabelaNome => 18,
        DBCargosEsc.PTabelaNome => 19,
        DBCargosEscClass.PTabelaNome => 20,
        DBCidade.PTabelaNome => 21,
        DBClientes.PTabelaNome => 22,
        DBClientesSocios.PTabelaNome => 23,
        DBColaboradores.PTabelaNome => 24,
        DBContaCorrente.PTabelaNome => 25,
        DBContatoCRMView.PTabelaNome => 26,
        DBContratos.PTabelaNome => 27,
        DBDadosProcuracao.PTabelaNome => 28,
        DBDiario2.PTabelaNome => 29,
        DBDivisaoTribunal.PTabelaNome => 30,
        DBDocumentos.PTabelaNome => 31,
        DBEMPClassRiscos.PTabelaNome => 32,
        DBEnderecos.PTabelaNome => 33,
        DBEnderecoSistema.PTabelaNome => 34,
        DBEndTit.PTabelaNome => 35,
        DBEnquadramentoEmpresa.PTabelaNome => 36,
        DBEscritorios.PTabelaNome => 37,
        DBEventoPrazoAgenda.PTabelaNome => 38,
        DBFase.PTabelaNome => 39,
        DBFornecedores.PTabelaNome => 40,
        DBForo.PTabelaNome => 41,
        DBFuncao.PTabelaNome => 42,
        DBFuncionarios.PTabelaNome => 43,
        DBGraph.PTabelaNome => 44,
        DBGruposEmpresas.PTabelaNome => 45,
        DBGruposEmpresasCli.PTabelaNome => 46,
        DBGUTAtividades.PTabelaNome => 47,
        DBGUTAtividadesMatriz.PTabelaNome => 48,
        DBGUTMatriz.PTabelaNome => 49,
        DBGUTPeriodicidade.PTabelaNome => 50,
        DBGUTPeriodicidadeStatus.PTabelaNome => 51,
        DBGUTTipo.PTabelaNome => 52,
        DBHonorariosDadosContrato.PTabelaNome => 53,
        DBHorasTrab.PTabelaNome => 54,
        DBInstancia.PTabelaNome => 55,
        DBJustica.PTabelaNome => 56,
        DBLigacoes.PTabelaNome => 57,
        DBLivroCaixa.PTabelaNome => 58,
        DBModelosDocumentos.PTabelaNome => 59,
        DBNECompromissos.PTabelaNome => 60,
        DBNENotas.PTabelaNome => 61,
        DBNEPalavrasChaves.PTabelaNome => 62,
        DBObjetos.PTabelaNome => 63,
        DBOperador.PTabelaNome => 64,
        DBOperadorEMailPopup.PTabelaNome => 65,
        DBOperadores.PTabelaNome => 66,
        DBOperadorGrupo.PTabelaNome => 67,
        DBOperadorGrupos.PTabelaNome => 68,
        DBOperadorGruposAgenda.PTabelaNome => 69,
        DBOponentes.PTabelaNome => 70,
        DBOponentesRepLegal.PTabelaNome => 71,
        DBOutrasPartesCliente.PTabelaNome => 72,
        DBPaises.PTabelaNome => 73,
        DBParceriaProc.PTabelaNome => 74,
        DBParteCliente.PTabelaNome => 75,
        DBParteClienteOutras.PTabelaNome => 76,
        DBParteOponente.PTabelaNome => 77,
        DBPenhora.PTabelaNome => 78,
        DBPenhoraStatus.PTabelaNome => 79,
        DBPoderJudiciarioAssociado.PTabelaNome => 80,
        DBPontoVirtual.PTabelaNome => 81,
        DBPontoVirtualAcessos.PTabelaNome => 82,
        DBPosicaoOutrasPartes.PTabelaNome => 83,
        DBPreClientes.PTabelaNome => 84,
        DBPrepostos.PTabelaNome => 85,
        DBProBarCODE.PTabelaNome => 86,
        DBProCDA.PTabelaNome => 87,
        DBProcessosObsReport.PTabelaNome => 88,
        DBProcessosParados.PTabelaNome => 89,
        DBProcessOutputEngine.PTabelaNome => 90,
        DBProcessOutPutIDs.PTabelaNome => 91,
        DBProcessOutputRequest.PTabelaNome => 92,
        DBProcessOutputSources.PTabelaNome => 93,
        DBProDepositos.PTabelaNome => 94,
        DBProDespesas.PTabelaNome => 95,
        DBProObservacoes.PTabelaNome => 96,
        DBProPartes.PTabelaNome => 97,
        DBProProcuradores.PTabelaNome => 98,
        DBProResumos.PTabelaNome => 99,
        DBProSucumbencia.PTabelaNome => 100,
        DBProTipoBaixa.PTabelaNome => 101,
        DBProValores.PTabelaNome => 102,
        DBRamal.PTabelaNome => 103,
        DBRegimeTributacao.PTabelaNome => 104,
        DBReuniao.PTabelaNome => 105,
        DBRito.PTabelaNome => 106,
        DBServicos.PTabelaNome => 107,
        DBSetor.PTabelaNome => 108,
        DBSituacao.PTabelaNome => 109,
        DBSMSAlice.PTabelaNome => 110,
        DBStatusAndamento.PTabelaNome => 111,
        DBStatusBiu.PTabelaNome => 112,
        DBStatusHTrab.PTabelaNome => 113,
        DBStatusInstancia.PTabelaNome => 114,
        DBStatusTarefas.PTabelaNome => 115,
        DBTerceiros.PTabelaNome => 116,
        DBTipoCompromisso.PTabelaNome => 117,
        DBTipoContatoCRM.PTabelaNome => 118,
        DBTipoEMail.PTabelaNome => 119,
        DBTipoEndereco.PTabelaNome => 120,
        DBTipoEnderecoSistema.PTabelaNome => 121,
        DBTipoModeloDocumento.PTabelaNome => 122,
        DBTipoOrigemSucumbencia.PTabelaNome => 123,
        DBTipoProDesposito.PTabelaNome => 124,
        DBTipoRecurso.PTabelaNome => 125,
        DBTiposAcao.PTabelaNome => 126,
        DBTipoStatusBiu.PTabelaNome => 127,
        DBTipoValorProcesso.PTabelaNome => 128,
        DBTribEnderecos.PTabelaNome => 129,
        DBTribunal.PTabelaNome => 130,
        DBUF.PTabelaNome => 131,
        DBUltimosProcessos.PTabelaNome => 132,
        DBViaRecebimento.PTabelaNome => 133,
        DBAgendaRelatorio.PTabelaNome => 134,
        DBAgendaSemana.PTabelaNome => 135,
        _ => 0
    };
    public string NomeTabelaByEnum(int idTable) => idTable switch
    {
        1 => DBAcao.PTabelaNome,
        2 => DBAdvogados.PTabelaNome,
        3 => DBAgenda.PTabelaNome,
        4 => DBAgendaQuem.PTabelaNome,
        5 => DBAgendaRepetirDias.PTabelaNome,
        6 => DBAlertas.PTabelaNome,
        7 => DBAlertasEnviados.PTabelaNome,
        8 => DBAndamentosMD.PTabelaNome,
        9 => DBAndComp.PTabelaNome,
        10 => DBAnexamentoRegistros.PTabelaNome,
        11 => DBApenso2.PTabelaNome,
        12 => DBArea.PTabelaNome,
        13 => DBAreasJustica.PTabelaNome,
        14 => DBAtividades.PTabelaNome,
        15 => DBAuditor4K.PTabelaNome,
        16 => DBBensClassificacao.PTabelaNome,
        17 => DBBensMateriais.PTabelaNome,
        18 => DBCargos.PTabelaNome,
        19 => DBCargosEsc.PTabelaNome,
        20 => DBCargosEscClass.PTabelaNome,
        21 => DBCidade.PTabelaNome,
        22 => DBClientes.PTabelaNome,
        23 => DBClientesSocios.PTabelaNome,
        24 => DBColaboradores.PTabelaNome,
        25 => DBContaCorrente.PTabelaNome,
        26 => DBContatoCRMView.PTabelaNome,
        27 => DBContratos.PTabelaNome,
        28 => DBDadosProcuracao.PTabelaNome,
        29 => DBDiario2.PTabelaNome,
        30 => DBDivisaoTribunal.PTabelaNome,
        31 => DBDocumentos.PTabelaNome,
        32 => DBEMPClassRiscos.PTabelaNome,
        33 => DBEnderecos.PTabelaNome,
        34 => DBEnderecoSistema.PTabelaNome,
        35 => DBEndTit.PTabelaNome,
        36 => DBEnquadramentoEmpresa.PTabelaNome,
        37 => DBEscritorios.PTabelaNome,
        38 => DBEventoPrazoAgenda.PTabelaNome,
        39 => DBFase.PTabelaNome,
        40 => DBFornecedores.PTabelaNome,
        41 => DBForo.PTabelaNome,
        42 => DBFuncao.PTabelaNome,
        43 => DBFuncionarios.PTabelaNome,
        44 => DBGraph.PTabelaNome,
        45 => DBGruposEmpresas.PTabelaNome,
        46 => DBGruposEmpresasCli.PTabelaNome,
        47 => DBGUTAtividades.PTabelaNome,
        48 => DBGUTAtividadesMatriz.PTabelaNome,
        49 => DBGUTMatriz.PTabelaNome,
        50 => DBGUTPeriodicidade.PTabelaNome,
        51 => DBGUTPeriodicidadeStatus.PTabelaNome,
        52 => DBGUTTipo.PTabelaNome,
        53 => DBHonorariosDadosContrato.PTabelaNome,
        54 => DBHorasTrab.PTabelaNome,
        55 => DBInstancia.PTabelaNome,
        56 => DBJustica.PTabelaNome,
        57 => DBLigacoes.PTabelaNome,
        58 => DBLivroCaixa.PTabelaNome,
        59 => DBModelosDocumentos.PTabelaNome,
        60 => DBNECompromissos.PTabelaNome,
        61 => DBNENotas.PTabelaNome,
        62 => DBNEPalavrasChaves.PTabelaNome,
        63 => DBObjetos.PTabelaNome,
        64 => DBOperador.PTabelaNome,
        65 => DBOperadorEMailPopup.PTabelaNome,
        66 => DBOperadores.PTabelaNome,
        67 => DBOperadorGrupo.PTabelaNome,
        68 => DBOperadorGrupos.PTabelaNome,
        69 => DBOperadorGruposAgenda.PTabelaNome,
        70 => DBOponentes.PTabelaNome,
        71 => DBOponentesRepLegal.PTabelaNome,
        72 => DBOutrasPartesCliente.PTabelaNome,
        73 => DBPaises.PTabelaNome,
        74 => DBParceriaProc.PTabelaNome,
        75 => DBParteCliente.PTabelaNome,
        76 => DBParteClienteOutras.PTabelaNome,
        77 => DBParteOponente.PTabelaNome,
        78 => DBPenhora.PTabelaNome,
        79 => DBPenhoraStatus.PTabelaNome,
        80 => DBPoderJudiciarioAssociado.PTabelaNome,
        81 => DBPontoVirtual.PTabelaNome,
        82 => DBPontoVirtualAcessos.PTabelaNome,
        83 => DBPosicaoOutrasPartes.PTabelaNome,
        84 => DBPreClientes.PTabelaNome,
        85 => DBPrepostos.PTabelaNome,
        86 => DBProBarCODE.PTabelaNome,
        87 => DBProCDA.PTabelaNome,
        88 => DBProcessosObsReport.PTabelaNome,
        89 => DBProcessosParados.PTabelaNome,
        90 => DBProcessOutputEngine.PTabelaNome,
        91 => DBProcessOutPutIDs.PTabelaNome,
        92 => DBProcessOutputRequest.PTabelaNome,
        93 => DBProcessOutputSources.PTabelaNome,
        94 => DBProDepositos.PTabelaNome,
        95 => DBProDespesas.PTabelaNome,
        96 => DBProObservacoes.PTabelaNome,
        97 => DBProPartes.PTabelaNome,
        98 => DBProProcuradores.PTabelaNome,
        99 => DBProResumos.PTabelaNome,
        100 => DBProSucumbencia.PTabelaNome,
        101 => DBProTipoBaixa.PTabelaNome,
        102 => DBProValores.PTabelaNome,
        103 => DBRamal.PTabelaNome,
        104 => DBRegimeTributacao.PTabelaNome,
        105 => DBReuniao.PTabelaNome,
        106 => DBRito.PTabelaNome,
        107 => DBServicos.PTabelaNome,
        108 => DBSetor.PTabelaNome,
        109 => DBSituacao.PTabelaNome,
        110 => DBSMSAlice.PTabelaNome,
        111 => DBStatusAndamento.PTabelaNome,
        112 => DBStatusBiu.PTabelaNome,
        113 => DBStatusHTrab.PTabelaNome,
        114 => DBStatusInstancia.PTabelaNome,
        115 => DBStatusTarefas.PTabelaNome,
        116 => DBTerceiros.PTabelaNome,
        117 => DBTipoCompromisso.PTabelaNome,
        118 => DBTipoContatoCRM.PTabelaNome,
        119 => DBTipoEMail.PTabelaNome,
        120 => DBTipoEndereco.PTabelaNome,
        121 => DBTipoEnderecoSistema.PTabelaNome,
        122 => DBTipoModeloDocumento.PTabelaNome,
        123 => DBTipoOrigemSucumbencia.PTabelaNome,
        124 => DBTipoProDesposito.PTabelaNome,
        125 => DBTipoRecurso.PTabelaNome,
        126 => DBTiposAcao.PTabelaNome,
        127 => DBTipoStatusBiu.PTabelaNome,
        128 => DBTipoValorProcesso.PTabelaNome,
        129 => DBTribEnderecos.PTabelaNome,
        130 => DBTribunal.PTabelaNome,
        131 => DBUF.PTabelaNome,
        132 => DBUltimosProcessos.PTabelaNome,
        133 => DBViaRecebimento.PTabelaNome,
        134 => DBAgendaRelatorio.PTabelaNome,
        135 => DBAgendaSemana.PTabelaNome,
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
        "4" => new DBAgendaQuemODicInfo(),
        DBAgendaQuem.PTabelaNome => new DBAgendaQuemODicInfo(),
        "AGENDAQUEM" => new DBAgendaQuemODicInfo(),
        "5" => new DBAgendaRepetirDiasODicInfo(),
        DBAgendaRepetirDias.PTabelaNome => new DBAgendaRepetirDiasODicInfo(),
        "AGENDAREPETIRDIAS" => new DBAgendaRepetirDiasODicInfo(),
        "6" => new DBAlertasODicInfo(),
        DBAlertas.PTabelaNome => new DBAlertasODicInfo(),
        "ALERTAS" => new DBAlertasODicInfo(),
        "7" => new DBAlertasEnviadosODicInfo(),
        DBAlertasEnviados.PTabelaNome => new DBAlertasEnviadosODicInfo(),
        "ALERTASENVIADOS" => new DBAlertasEnviadosODicInfo(),
        "8" => new DBAndamentosMDODicInfo(),
        DBAndamentosMD.PTabelaNome => new DBAndamentosMDODicInfo(),
        "ANDAMENTOSMD" => new DBAndamentosMDODicInfo(),
        "9" => new DBAndCompODicInfo(),
        DBAndComp.PTabelaNome => new DBAndCompODicInfo(),
        "ANDCOMP" => new DBAndCompODicInfo(),
        "10" => new DBAnexamentoRegistrosODicInfo(),
        DBAnexamentoRegistros.PTabelaNome => new DBAnexamentoRegistrosODicInfo(),
        "ANEXAMENTOREGISTROS" => new DBAnexamentoRegistrosODicInfo(),
        "11" => new DBApenso2ODicInfo(),
        DBApenso2.PTabelaNome => new DBApenso2ODicInfo(),
        "APENSO2" => new DBApenso2ODicInfo(),
        "12" => new DBAreaODicInfo(),
        DBArea.PTabelaNome => new DBAreaODicInfo(),
        "AREA" => new DBAreaODicInfo(),
        "13" => new DBAreasJusticaODicInfo(),
        DBAreasJustica.PTabelaNome => new DBAreasJusticaODicInfo(),
        "AREASJUSTICA" => new DBAreasJusticaODicInfo(),
        "14" => new DBAtividadesODicInfo(),
        DBAtividades.PTabelaNome => new DBAtividadesODicInfo(),
        "ATIVIDADES" => new DBAtividadesODicInfo(),
        "15" => new DBAuditor4KODicInfo(),
        DBAuditor4K.PTabelaNome => new DBAuditor4KODicInfo(),
        "AUDITOR4K" => new DBAuditor4KODicInfo(),
        "16" => new DBBensClassificacaoODicInfo(),
        DBBensClassificacao.PTabelaNome => new DBBensClassificacaoODicInfo(),
        "BENSCLASSIFICACAO" => new DBBensClassificacaoODicInfo(),
        "17" => new DBBensMateriaisODicInfo(),
        DBBensMateriais.PTabelaNome => new DBBensMateriaisODicInfo(),
        "BENSMATERIAIS" => new DBBensMateriaisODicInfo(),
        "18" => new DBCargosODicInfo(),
        DBCargos.PTabelaNome => new DBCargosODicInfo(),
        "CARGOS" => new DBCargosODicInfo(),
        "19" => new DBCargosEscODicInfo(),
        DBCargosEsc.PTabelaNome => new DBCargosEscODicInfo(),
        "CARGOSESC" => new DBCargosEscODicInfo(),
        "20" => new DBCargosEscClassODicInfo(),
        DBCargosEscClass.PTabelaNome => new DBCargosEscClassODicInfo(),
        "CARGOSESCCLASS" => new DBCargosEscClassODicInfo(),
        "21" => new DBCidadeODicInfo(),
        DBCidade.PTabelaNome => new DBCidadeODicInfo(),
        "CIDADE" => new DBCidadeODicInfo(),
        "22" => new DBClientesODicInfo(),
        DBClientes.PTabelaNome => new DBClientesODicInfo(),
        "CLIENTES" => new DBClientesODicInfo(),
        "23" => new DBClientesSociosODicInfo(),
        DBClientesSocios.PTabelaNome => new DBClientesSociosODicInfo(),
        "CLIENTESSOCIOS" => new DBClientesSociosODicInfo(),
        "24" => new DBColaboradoresODicInfo(),
        DBColaboradores.PTabelaNome => new DBColaboradoresODicInfo(),
        "COLABORADORES" => new DBColaboradoresODicInfo(),
        "25" => new DBContaCorrenteODicInfo(),
        DBContaCorrente.PTabelaNome => new DBContaCorrenteODicInfo(),
        "CONTACORRENTE" => new DBContaCorrenteODicInfo(),
        "26" => new DBContatoCRMViewODicInfo(),
        DBContatoCRMView.PTabelaNome => new DBContatoCRMViewODicInfo(),
        "CONTATOCRMVIEW" => new DBContatoCRMViewODicInfo(),
        "27" => new DBContratosODicInfo(),
        DBContratos.PTabelaNome => new DBContratosODicInfo(),
        "CONTRATOS" => new DBContratosODicInfo(),
        "28" => new DBDadosProcuracaoODicInfo(),
        DBDadosProcuracao.PTabelaNome => new DBDadosProcuracaoODicInfo(),
        "DADOSPROCURACAO" => new DBDadosProcuracaoODicInfo(),
        "29" => new DBDiario2ODicInfo(),
        DBDiario2.PTabelaNome => new DBDiario2ODicInfo(),
        "DIARIO2" => new DBDiario2ODicInfo(),
        "30" => new DBDivisaoTribunalODicInfo(),
        DBDivisaoTribunal.PTabelaNome => new DBDivisaoTribunalODicInfo(),
        "DIVISAOTRIBUNAL" => new DBDivisaoTribunalODicInfo(),
        "31" => new DBDocumentosODicInfo(),
        DBDocumentos.PTabelaNome => new DBDocumentosODicInfo(),
        "DOCUMENTOS" => new DBDocumentosODicInfo(),
        "32" => new DBEMPClassRiscosODicInfo(),
        DBEMPClassRiscos.PTabelaNome => new DBEMPClassRiscosODicInfo(),
        "EMPCLASSRISCOS" => new DBEMPClassRiscosODicInfo(),
        "33" => new DBEnderecosODicInfo(),
        DBEnderecos.PTabelaNome => new DBEnderecosODicInfo(),
        "ENDERECOS" => new DBEnderecosODicInfo(),
        "34" => new DBEnderecoSistemaODicInfo(),
        DBEnderecoSistema.PTabelaNome => new DBEnderecoSistemaODicInfo(),
        "ENDERECOSISTEMA" => new DBEnderecoSistemaODicInfo(),
        "35" => new DBEndTitODicInfo(),
        DBEndTit.PTabelaNome => new DBEndTitODicInfo(),
        "ENDTIT" => new DBEndTitODicInfo(),
        "36" => new DBEnquadramentoEmpresaODicInfo(),
        DBEnquadramentoEmpresa.PTabelaNome => new DBEnquadramentoEmpresaODicInfo(),
        "ENQUADRAMENTOEMPRESA" => new DBEnquadramentoEmpresaODicInfo(),
        "37" => new DBEscritoriosODicInfo(),
        DBEscritorios.PTabelaNome => new DBEscritoriosODicInfo(),
        "ESCRITORIOS" => new DBEscritoriosODicInfo(),
        "38" => new DBEventoPrazoAgendaODicInfo(),
        DBEventoPrazoAgenda.PTabelaNome => new DBEventoPrazoAgendaODicInfo(),
        "EVENTOPRAZOAGENDA" => new DBEventoPrazoAgendaODicInfo(),
        "39" => new DBFaseODicInfo(),
        DBFase.PTabelaNome => new DBFaseODicInfo(),
        "FASE" => new DBFaseODicInfo(),
        "40" => new DBFornecedoresODicInfo(),
        DBFornecedores.PTabelaNome => new DBFornecedoresODicInfo(),
        "FORNECEDORES" => new DBFornecedoresODicInfo(),
        "41" => new DBForoODicInfo(),
        DBForo.PTabelaNome => new DBForoODicInfo(),
        "FORO" => new DBForoODicInfo(),
        "42" => new DBFuncaoODicInfo(),
        DBFuncao.PTabelaNome => new DBFuncaoODicInfo(),
        "FUNCAO" => new DBFuncaoODicInfo(),
        "43" => new DBFuncionariosODicInfo(),
        DBFuncionarios.PTabelaNome => new DBFuncionariosODicInfo(),
        "FUNCIONARIOS" => new DBFuncionariosODicInfo(),
        "44" => new DBGraphODicInfo(),
        DBGraph.PTabelaNome => new DBGraphODicInfo(),
        "GRAPH" => new DBGraphODicInfo(),
        "45" => new DBGruposEmpresasODicInfo(),
        DBGruposEmpresas.PTabelaNome => new DBGruposEmpresasODicInfo(),
        "GRUPOSEMPRESAS" => new DBGruposEmpresasODicInfo(),
        "46" => new DBGruposEmpresasCliODicInfo(),
        DBGruposEmpresasCli.PTabelaNome => new DBGruposEmpresasCliODicInfo(),
        "GRUPOSEMPRESASCLI" => new DBGruposEmpresasCliODicInfo(),
        "47" => new DBGUTAtividadesODicInfo(),
        DBGUTAtividades.PTabelaNome => new DBGUTAtividadesODicInfo(),
        "GUTATIVIDADES" => new DBGUTAtividadesODicInfo(),
        "48" => new DBGUTAtividadesMatrizODicInfo(),
        DBGUTAtividadesMatriz.PTabelaNome => new DBGUTAtividadesMatrizODicInfo(),
        "GUTATIVIDADESMATRIZ" => new DBGUTAtividadesMatrizODicInfo(),
        "49" => new DBGUTMatrizODicInfo(),
        DBGUTMatriz.PTabelaNome => new DBGUTMatrizODicInfo(),
        "GUTMATRIZ" => new DBGUTMatrizODicInfo(),
        "50" => new DBGUTPeriodicidadeODicInfo(),
        DBGUTPeriodicidade.PTabelaNome => new DBGUTPeriodicidadeODicInfo(),
        "GUTPERIODICIDADE" => new DBGUTPeriodicidadeODicInfo(),
        "51" => new DBGUTPeriodicidadeStatusODicInfo(),
        DBGUTPeriodicidadeStatus.PTabelaNome => new DBGUTPeriodicidadeStatusODicInfo(),
        "GUTPERIODICIDADESTATUS" => new DBGUTPeriodicidadeStatusODicInfo(),
        "52" => new DBGUTTipoODicInfo(),
        DBGUTTipo.PTabelaNome => new DBGUTTipoODicInfo(),
        "GUTTIPO" => new DBGUTTipoODicInfo(),
        "53" => new DBHonorariosDadosContratoODicInfo(),
        DBHonorariosDadosContrato.PTabelaNome => new DBHonorariosDadosContratoODicInfo(),
        "HONORARIOSDADOSCONTRATO" => new DBHonorariosDadosContratoODicInfo(),
        "54" => new DBHorasTrabODicInfo(),
        DBHorasTrab.PTabelaNome => new DBHorasTrabODicInfo(),
        "HORASTRAB" => new DBHorasTrabODicInfo(),
        "55" => new DBInstanciaODicInfo(),
        DBInstancia.PTabelaNome => new DBInstanciaODicInfo(),
        "INSTANCIA" => new DBInstanciaODicInfo(),
        "56" => new DBJusticaODicInfo(),
        DBJustica.PTabelaNome => new DBJusticaODicInfo(),
        "JUSTICA" => new DBJusticaODicInfo(),
        "57" => new DBLigacoesODicInfo(),
        DBLigacoes.PTabelaNome => new DBLigacoesODicInfo(),
        "LIGACOES" => new DBLigacoesODicInfo(),
        "58" => new DBLivroCaixaODicInfo(),
        DBLivroCaixa.PTabelaNome => new DBLivroCaixaODicInfo(),
        "LIVROCAIXA" => new DBLivroCaixaODicInfo(),
        "59" => new DBModelosDocumentosODicInfo(),
        DBModelosDocumentos.PTabelaNome => new DBModelosDocumentosODicInfo(),
        "MODELOSDOCUMENTOS" => new DBModelosDocumentosODicInfo(),
        "60" => new DBNECompromissosODicInfo(),
        DBNECompromissos.PTabelaNome => new DBNECompromissosODicInfo(),
        "NECOMPROMISSOS" => new DBNECompromissosODicInfo(),
        "61" => new DBNENotasODicInfo(),
        DBNENotas.PTabelaNome => new DBNENotasODicInfo(),
        "NENOTAS" => new DBNENotasODicInfo(),
        "62" => new DBNEPalavrasChavesODicInfo(),
        DBNEPalavrasChaves.PTabelaNome => new DBNEPalavrasChavesODicInfo(),
        "NEPALAVRASCHAVES" => new DBNEPalavrasChavesODicInfo(),
        "63" => new DBObjetosODicInfo(),
        DBObjetos.PTabelaNome => new DBObjetosODicInfo(),
        "OBJETOS" => new DBObjetosODicInfo(),
        "64" => new DBOperadorODicInfo(),
        DBOperador.PTabelaNome => new DBOperadorODicInfo(),
        "OPERADOR" => new DBOperadorODicInfo(),
        "65" => new DBOperadorEMailPopupODicInfo(),
        DBOperadorEMailPopup.PTabelaNome => new DBOperadorEMailPopupODicInfo(),
        "OPERADOREMAILPOPUP" => new DBOperadorEMailPopupODicInfo(),
        "66" => new DBOperadoresODicInfo(),
        DBOperadores.PTabelaNome => new DBOperadoresODicInfo(),
        "OPERADORES" => new DBOperadoresODicInfo(),
        "67" => new DBOperadorGrupoODicInfo(),
        DBOperadorGrupo.PTabelaNome => new DBOperadorGrupoODicInfo(),
        "OPERADORGRUPO" => new DBOperadorGrupoODicInfo(),
        "68" => new DBOperadorGruposODicInfo(),
        DBOperadorGrupos.PTabelaNome => new DBOperadorGruposODicInfo(),
        "OPERADORGRUPOS" => new DBOperadorGruposODicInfo(),
        "69" => new DBOperadorGruposAgendaODicInfo(),
        DBOperadorGruposAgenda.PTabelaNome => new DBOperadorGruposAgendaODicInfo(),
        "OPERADORGRUPOSAGENDA" => new DBOperadorGruposAgendaODicInfo(),
        "70" => new DBOponentesODicInfo(),
        DBOponentes.PTabelaNome => new DBOponentesODicInfo(),
        "OPONENTES" => new DBOponentesODicInfo(),
        "71" => new DBOponentesRepLegalODicInfo(),
        DBOponentesRepLegal.PTabelaNome => new DBOponentesRepLegalODicInfo(),
        "OPONENTESREPLEGAL" => new DBOponentesRepLegalODicInfo(),
        "72" => new DBOutrasPartesClienteODicInfo(),
        DBOutrasPartesCliente.PTabelaNome => new DBOutrasPartesClienteODicInfo(),
        "OUTRASPARTESCLIENTE" => new DBOutrasPartesClienteODicInfo(),
        "73" => new DBPaisesODicInfo(),
        DBPaises.PTabelaNome => new DBPaisesODicInfo(),
        "PAISES" => new DBPaisesODicInfo(),
        "74" => new DBParceriaProcODicInfo(),
        DBParceriaProc.PTabelaNome => new DBParceriaProcODicInfo(),
        "PARCERIAPROC" => new DBParceriaProcODicInfo(),
        "75" => new DBParteClienteODicInfo(),
        DBParteCliente.PTabelaNome => new DBParteClienteODicInfo(),
        "PARTECLIENTE" => new DBParteClienteODicInfo(),
        "76" => new DBParteClienteOutrasODicInfo(),
        DBParteClienteOutras.PTabelaNome => new DBParteClienteOutrasODicInfo(),
        "PARTECLIENTEOUTRAS" => new DBParteClienteOutrasODicInfo(),
        "77" => new DBParteOponenteODicInfo(),
        DBParteOponente.PTabelaNome => new DBParteOponenteODicInfo(),
        "PARTEOPONENTE" => new DBParteOponenteODicInfo(),
        "78" => new DBPenhoraODicInfo(),
        DBPenhora.PTabelaNome => new DBPenhoraODicInfo(),
        "PENHORA" => new DBPenhoraODicInfo(),
        "79" => new DBPenhoraStatusODicInfo(),
        DBPenhoraStatus.PTabelaNome => new DBPenhoraStatusODicInfo(),
        "PENHORASTATUS" => new DBPenhoraStatusODicInfo(),
        "80" => new DBPoderJudiciarioAssociadoODicInfo(),
        DBPoderJudiciarioAssociado.PTabelaNome => new DBPoderJudiciarioAssociadoODicInfo(),
        "PODERJUDICIARIOASSOCIADO" => new DBPoderJudiciarioAssociadoODicInfo(),
        "81" => new DBPontoVirtualODicInfo(),
        DBPontoVirtual.PTabelaNome => new DBPontoVirtualODicInfo(),
        "PONTOVIRTUAL" => new DBPontoVirtualODicInfo(),
        "82" => new DBPontoVirtualAcessosODicInfo(),
        DBPontoVirtualAcessos.PTabelaNome => new DBPontoVirtualAcessosODicInfo(),
        "PONTOVIRTUALACESSOS" => new DBPontoVirtualAcessosODicInfo(),
        "83" => new DBPosicaoOutrasPartesODicInfo(),
        DBPosicaoOutrasPartes.PTabelaNome => new DBPosicaoOutrasPartesODicInfo(),
        "POSICAOOUTRASPARTES" => new DBPosicaoOutrasPartesODicInfo(),
        "84" => new DBPreClientesODicInfo(),
        DBPreClientes.PTabelaNome => new DBPreClientesODicInfo(),
        "PRECLIENTES" => new DBPreClientesODicInfo(),
        "85" => new DBPrepostosODicInfo(),
        DBPrepostos.PTabelaNome => new DBPrepostosODicInfo(),
        "PREPOSTOS" => new DBPrepostosODicInfo(),
        "86" => new DBProBarCODEODicInfo(),
        DBProBarCODE.PTabelaNome => new DBProBarCODEODicInfo(),
        "PROBARCODE" => new DBProBarCODEODicInfo(),
        "87" => new DBProCDAODicInfo(),
        DBProCDA.PTabelaNome => new DBProCDAODicInfo(),
        "PROCDA" => new DBProCDAODicInfo(),
        "88" => new DBProcessosObsReportODicInfo(),
        DBProcessosObsReport.PTabelaNome => new DBProcessosObsReportODicInfo(),
        "PROCESSOSOBSREPORT" => new DBProcessosObsReportODicInfo(),
        "89" => new DBProcessosParadosODicInfo(),
        DBProcessosParados.PTabelaNome => new DBProcessosParadosODicInfo(),
        "PROCESSOSPARADOS" => new DBProcessosParadosODicInfo(),
        "90" => new DBProcessOutputEngineODicInfo(),
        DBProcessOutputEngine.PTabelaNome => new DBProcessOutputEngineODicInfo(),
        "PROCESSOUTPUTENGINE" => new DBProcessOutputEngineODicInfo(),
        "91" => new DBProcessOutPutIDsODicInfo(),
        DBProcessOutPutIDs.PTabelaNome => new DBProcessOutPutIDsODicInfo(),
        "PROCESSOUTPUTIDS" => new DBProcessOutPutIDsODicInfo(),
        "92" => new DBProcessOutputRequestODicInfo(),
        DBProcessOutputRequest.PTabelaNome => new DBProcessOutputRequestODicInfo(),
        "PROCESSOUTPUTREQUEST" => new DBProcessOutputRequestODicInfo(),
        "93" => new DBProcessOutputSourcesODicInfo(),
        DBProcessOutputSources.PTabelaNome => new DBProcessOutputSourcesODicInfo(),
        "PROCESSOUTPUTSOURCES" => new DBProcessOutputSourcesODicInfo(),
        "94" => new DBProDepositosODicInfo(),
        DBProDepositos.PTabelaNome => new DBProDepositosODicInfo(),
        "PRODEPOSITOS" => new DBProDepositosODicInfo(),
        "95" => new DBProDespesasODicInfo(),
        DBProDespesas.PTabelaNome => new DBProDespesasODicInfo(),
        "PRODESPESAS" => new DBProDespesasODicInfo(),
        "96" => new DBProObservacoesODicInfo(),
        DBProObservacoes.PTabelaNome => new DBProObservacoesODicInfo(),
        "PROOBSERVACOES" => new DBProObservacoesODicInfo(),
        "97" => new DBProPartesODicInfo(),
        DBProPartes.PTabelaNome => new DBProPartesODicInfo(),
        "PROPARTES" => new DBProPartesODicInfo(),
        "98" => new DBProProcuradoresODicInfo(),
        DBProProcuradores.PTabelaNome => new DBProProcuradoresODicInfo(),
        "PROPROCURADORES" => new DBProProcuradoresODicInfo(),
        "99" => new DBProResumosODicInfo(),
        DBProResumos.PTabelaNome => new DBProResumosODicInfo(),
        "PRORESUMOS" => new DBProResumosODicInfo(),
        "100" => new DBProSucumbenciaODicInfo(),
        DBProSucumbencia.PTabelaNome => new DBProSucumbenciaODicInfo(),
        "PROSUCUMBENCIA" => new DBProSucumbenciaODicInfo(),
        "101" => new DBProTipoBaixaODicInfo(),
        DBProTipoBaixa.PTabelaNome => new DBProTipoBaixaODicInfo(),
        "PROTIPOBAIXA" => new DBProTipoBaixaODicInfo(),
        "102" => new DBProValoresODicInfo(),
        DBProValores.PTabelaNome => new DBProValoresODicInfo(),
        "PROVALORES" => new DBProValoresODicInfo(),
        "103" => new DBRamalODicInfo(),
        DBRamal.PTabelaNome => new DBRamalODicInfo(),
        "RAMAL" => new DBRamalODicInfo(),
        "104" => new DBRegimeTributacaoODicInfo(),
        DBRegimeTributacao.PTabelaNome => new DBRegimeTributacaoODicInfo(),
        "REGIMETRIBUTACAO" => new DBRegimeTributacaoODicInfo(),
        "105" => new DBReuniaoODicInfo(),
        DBReuniao.PTabelaNome => new DBReuniaoODicInfo(),
        "REUNIAO" => new DBReuniaoODicInfo(),
        "106" => new DBRitoODicInfo(),
        DBRito.PTabelaNome => new DBRitoODicInfo(),
        "RITO" => new DBRitoODicInfo(),
        "107" => new DBServicosODicInfo(),
        DBServicos.PTabelaNome => new DBServicosODicInfo(),
        "SERVICOS" => new DBServicosODicInfo(),
        "108" => new DBSetorODicInfo(),
        DBSetor.PTabelaNome => new DBSetorODicInfo(),
        "SETOR" => new DBSetorODicInfo(),
        "109" => new DBSituacaoODicInfo(),
        DBSituacao.PTabelaNome => new DBSituacaoODicInfo(),
        "SITUACAO" => new DBSituacaoODicInfo(),
        "110" => new DBSMSAliceODicInfo(),
        DBSMSAlice.PTabelaNome => new DBSMSAliceODicInfo(),
        "SMSALICE" => new DBSMSAliceODicInfo(),
        "111" => new DBStatusAndamentoODicInfo(),
        DBStatusAndamento.PTabelaNome => new DBStatusAndamentoODicInfo(),
        "STATUSANDAMENTO" => new DBStatusAndamentoODicInfo(),
        "112" => new DBStatusBiuODicInfo(),
        DBStatusBiu.PTabelaNome => new DBStatusBiuODicInfo(),
        "STATUSBIU" => new DBStatusBiuODicInfo(),
        "113" => new DBStatusHTrabODicInfo(),
        DBStatusHTrab.PTabelaNome => new DBStatusHTrabODicInfo(),
        "STATUSHTRAB" => new DBStatusHTrabODicInfo(),
        "114" => new DBStatusInstanciaODicInfo(),
        DBStatusInstancia.PTabelaNome => new DBStatusInstanciaODicInfo(),
        "STATUSINSTANCIA" => new DBStatusInstanciaODicInfo(),
        "115" => new DBStatusTarefasODicInfo(),
        DBStatusTarefas.PTabelaNome => new DBStatusTarefasODicInfo(),
        "STATUSTAREFAS" => new DBStatusTarefasODicInfo(),
        "116" => new DBTerceirosODicInfo(),
        DBTerceiros.PTabelaNome => new DBTerceirosODicInfo(),
        "TERCEIROS" => new DBTerceirosODicInfo(),
        "117" => new DBTipoCompromissoODicInfo(),
        DBTipoCompromisso.PTabelaNome => new DBTipoCompromissoODicInfo(),
        "TIPOCOMPROMISSO" => new DBTipoCompromissoODicInfo(),
        "118" => new DBTipoContatoCRMODicInfo(),
        DBTipoContatoCRM.PTabelaNome => new DBTipoContatoCRMODicInfo(),
        "TIPOCONTATOCRM" => new DBTipoContatoCRMODicInfo(),
        "119" => new DBTipoEMailODicInfo(),
        DBTipoEMail.PTabelaNome => new DBTipoEMailODicInfo(),
        "TIPOEMAIL" => new DBTipoEMailODicInfo(),
        "120" => new DBTipoEnderecoODicInfo(),
        DBTipoEndereco.PTabelaNome => new DBTipoEnderecoODicInfo(),
        "TIPOENDERECO" => new DBTipoEnderecoODicInfo(),
        "121" => new DBTipoEnderecoSistemaODicInfo(),
        DBTipoEnderecoSistema.PTabelaNome => new DBTipoEnderecoSistemaODicInfo(),
        "TIPOENDERECOSISTEMA" => new DBTipoEnderecoSistemaODicInfo(),
        "122" => new DBTipoModeloDocumentoODicInfo(),
        DBTipoModeloDocumento.PTabelaNome => new DBTipoModeloDocumentoODicInfo(),
        "TIPOMODELODOCUMENTO" => new DBTipoModeloDocumentoODicInfo(),
        "123" => new DBTipoOrigemSucumbenciaODicInfo(),
        DBTipoOrigemSucumbencia.PTabelaNome => new DBTipoOrigemSucumbenciaODicInfo(),
        "TIPOORIGEMSUCUMBENCIA" => new DBTipoOrigemSucumbenciaODicInfo(),
        "124" => new DBTipoProDespositoODicInfo(),
        DBTipoProDesposito.PTabelaNome => new DBTipoProDespositoODicInfo(),
        "TIPOPRODESPOSITO" => new DBTipoProDespositoODicInfo(),
        "125" => new DBTipoRecursoODicInfo(),
        DBTipoRecurso.PTabelaNome => new DBTipoRecursoODicInfo(),
        "TIPORECURSO" => new DBTipoRecursoODicInfo(),
        "126" => new DBTiposAcaoODicInfo(),
        DBTiposAcao.PTabelaNome => new DBTiposAcaoODicInfo(),
        "TIPOSACAO" => new DBTiposAcaoODicInfo(),
        "127" => new DBTipoStatusBiuODicInfo(),
        DBTipoStatusBiu.PTabelaNome => new DBTipoStatusBiuODicInfo(),
        "TIPOSTATUSBIU" => new DBTipoStatusBiuODicInfo(),
        "128" => new DBTipoValorProcessoODicInfo(),
        DBTipoValorProcesso.PTabelaNome => new DBTipoValorProcessoODicInfo(),
        "TIPOVALORPROCESSO" => new DBTipoValorProcessoODicInfo(),
        "129" => new DBTribEnderecosODicInfo(),
        DBTribEnderecos.PTabelaNome => new DBTribEnderecosODicInfo(),
        "TRIBENDERECOS" => new DBTribEnderecosODicInfo(),
        "130" => new DBTribunalODicInfo(),
        DBTribunal.PTabelaNome => new DBTribunalODicInfo(),
        "TRIBUNAL" => new DBTribunalODicInfo(),
        "131" => new DBUFODicInfo(),
        DBUF.PTabelaNome => new DBUFODicInfo(),
        "132" => new DBUltimosProcessosODicInfo(),
        DBUltimosProcessos.PTabelaNome => new DBUltimosProcessosODicInfo(),
        "ULTIMOSPROCESSOS" => new DBUltimosProcessosODicInfo(),
        "133" => new DBViaRecebimentoODicInfo(),
        DBViaRecebimento.PTabelaNome => new DBViaRecebimentoODicInfo(),
        "VIARECEBIMENTO" => new DBViaRecebimentoODicInfo(),
        "134" => new DBAgendaRelatorioODicInfo(),
        DBAgendaRelatorio.PTabelaNome => new DBAgendaRelatorioODicInfo(),
        "AGENDARELATORIO" => new DBAgendaRelatorioODicInfo(),
        "135" => new DBAgendaSemanaODicInfo(),
        DBAgendaSemana.PTabelaNome => new DBAgendaSemanaODicInfo(),
        "AGENDASEMANA" => new DBAgendaSemanaODicInfo(),
        _ => null
    };
    public List<DBInfoSystem> ListaSecureSearchable
    {
        get
        {
            var mRet = new List<DBInfoSystem>();
            mRet.AddRange(DBAdvogadosODicInfo.List);
            mRet.AddRange(DBAlertasODicInfo.List);
            mRet.AddRange(DBAlertasEnviadosODicInfo.List);
            mRet.AddRange(DBAndCompODicInfo.List);
            mRet.AddRange(DBApenso2ODicInfo.List);
            mRet.AddRange(DBAuditor4KODicInfo.List);
            mRet.AddRange(DBClientesODicInfo.List);
            mRet.AddRange(DBClientesSociosODicInfo.List);
            mRet.AddRange(DBColaboradoresODicInfo.List);
            mRet.AddRange(DBDiario2ODicInfo.List);
            mRet.AddRange(DBEnderecosODicInfo.List);
            mRet.AddRange(DBEnderecoSistemaODicInfo.List);
            mRet.AddRange(DBEscritoriosODicInfo.List);
            mRet.AddRange(DBFornecedoresODicInfo.List);
            mRet.AddRange(DBForoODicInfo.List);
            mRet.AddRange(DBFuncionariosODicInfo.List);
            mRet.AddRange(DBGraphODicInfo.List);
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
            mRet.AddRange(DBPreClientesODicInfo.List);
            mRet.AddRange(DBPrepostosODicInfo.List);
            mRet.AddRange(DBProCDAODicInfo.List);
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
            mRet.AddRange(DBTerceirosODicInfo.List);
            return mRet;
        }
    }

    public List<IODicInfo> ListaSecureSearchableDicInfo => [new DBAdvogadosODicInfo(), new DBAlertasODicInfo(), new DBAlertasEnviadosODicInfo(), new DBAndCompODicInfo(), new DBApenso2ODicInfo(), new DBAuditor4KODicInfo(), new DBClientesODicInfo(), new DBClientesSociosODicInfo(), new DBColaboradoresODicInfo(), new DBDiario2ODicInfo(), new DBEnderecosODicInfo(), new DBEnderecoSistemaODicInfo(), new DBEscritoriosODicInfo(), new DBFornecedoresODicInfo(), new DBForoODicInfo(), new DBFuncionariosODicInfo(), new DBGraphODicInfo(), new DBHonorariosDadosContratoODicInfo(), new DBHorasTrabODicInfo(), new DBInstanciaODicInfo(), new DBLigacoesODicInfo(), new DBNENotasODicInfo(), new DBOponentesODicInfo(), new DBOponentesRepLegalODicInfo(), new DBOutrasPartesClienteODicInfo(), new DBParceriaProcODicInfo(), new DBParteClienteODicInfo(), new DBParteClienteOutrasODicInfo(), new DBParteOponenteODicInfo(), new DBPenhoraODicInfo(), new DBPontoVirtualODicInfo(), new DBPontoVirtualAcessosODicInfo(), new DBPreClientesODicInfo(), new DBPrepostosODicInfo(), new DBProCDAODicInfo(), new DBProcessosObsReportODicInfo(), new DBProcessosParadosODicInfo(), new DBProcessOutputEngineODicInfo(), new DBProcessOutPutIDsODicInfo(), new DBProcessOutputRequestODicInfo(), new DBProcessOutputSourcesODicInfo(), new DBProDepositosODicInfo(), new DBProDespesasODicInfo(), new DBProObservacoesODicInfo(), new DBProPartesODicInfo(), new DBProProcuradoresODicInfo(), new DBProResumosODicInfo(), new DBProSucumbenciaODicInfo(), new DBProValoresODicInfo(), new DBReuniaoODicInfo(), new DBTerceirosODicInfo()];

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
            mRet.AddRange(DBAgendaQuemODicInfo.List);
            mRet.AddRange(DBAgendaRepetirDiasODicInfo.List);
            mRet.AddRange(DBAlertasODicInfo.List);
            mRet.AddRange(DBAlertasEnviadosODicInfo.List);
            mRet.AddRange(DBAndamentosMDODicInfo.List);
            mRet.AddRange(DBAndCompODicInfo.List);
            mRet.AddRange(DBAnexamentoRegistrosODicInfo.List);
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
            mRet.AddRange(DBContatoCRMViewODicInfo.List);
            mRet.AddRange(DBContratosODicInfo.List);
            mRet.AddRange(DBDadosProcuracaoODicInfo.List);
            mRet.AddRange(DBDiario2ODicInfo.List);
            mRet.AddRange(DBDivisaoTribunalODicInfo.List);
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
            mRet.AddRange(DBHonorariosDadosContratoODicInfo.List);
            mRet.AddRange(DBHorasTrabODicInfo.List);
            mRet.AddRange(DBInstanciaODicInfo.List);
            mRet.AddRange(DBJusticaODicInfo.List);
            mRet.AddRange(DBLigacoesODicInfo.List);
            mRet.AddRange(DBLivroCaixaODicInfo.List);
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
            mRet.AddRange(DBPreClientesODicInfo.List);
            mRet.AddRange(DBPrepostosODicInfo.List);
            mRet.AddRange(DBProBarCODEODicInfo.List);
            mRet.AddRange(DBProCDAODicInfo.List);
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
            mRet.AddRange(DBRegimeTributacaoODicInfo.List);
            mRet.AddRange(DBReuniaoODicInfo.List);
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
public  bool CodeSigntature_DBAgendaQuem() => true;


/// <returns></returns>
public  bool CodeSigntature_DBAgendaRepetirDias() => true;


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
public  bool CodeSigntature_DBPreClientes() => true;


/// <returns></returns>
public  bool CodeSigntature_DBPrepostos() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProBarCODE() => true;


/// <returns></returns>
public  bool CodeSigntature_DBProCDA() => true;


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
public  bool CodeSigntature_DBRegimeTributacao() => true;


/// <returns></returns>
public  bool CodeSigntature_DBReuniao() => true;


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
