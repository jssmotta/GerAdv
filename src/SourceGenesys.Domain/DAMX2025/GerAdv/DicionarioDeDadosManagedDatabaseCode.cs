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
        BensClassificacao = 15,
        BensMateriais = 16,
        Cargos = 17,
        CargosEsc = 18,
        CargosEscClass = 19,
        Cidade = 20,
        Clientes = 21,
        ClientesSocios = 22,
        Colaboradores = 23,
        ContaCorrente = 24,
        ContatoCRMView = 25,
        Contratos = 26,
        DadosProcuracao = 27,
        Diario2 = 28,
        DivisaoTribunal = 29,
        Documentos = 30,
        EMPClassRiscos = 31,
        Enderecos = 32,
        EnderecoSistema = 33,
        EndTit = 34,
        EnquadramentoEmpresa = 35,
        Escritorios = 36,
        EventoPrazoAgenda = 37,
        Fase = 38,
        Fornecedores = 39,
        Foro = 40,
        Funcao = 41,
        Funcionarios = 42,
        Graph = 43,
        GruposEmpresas = 44,
        GruposEmpresasCli = 45,
        GUTAtividades = 46,
        GUTAtividadesMatriz = 47,
        GUTMatriz = 48,
        GUTPeriodicidade = 49,
        GUTPeriodicidadeStatus = 50,
        GUTTipo = 51,
        HonorariosDadosContrato = 52,
        HorasTrab = 53,
        Instancia = 54,
        Justica = 55,
        Ligacoes = 56,
        LivroCaixa = 57,
        ModelosDocumentos = 58,
        NECompromissos = 59,
        NENotas = 60,
        NEPalavrasChaves = 61,
        Objetos = 62,
        Operador = 63,
        OperadorEMailPopup = 64,
        Operadores = 65,
        OperadorGrupo = 66,
        OperadorGrupos = 67,
        OperadorGruposAgenda = 68,
        Oponentes = 69,
        OponentesRepLegal = 70,
        OutrasPartesCliente = 71,
        Paises = 72,
        ParceriaProc = 73,
        ParteCliente = 74,
        ParteClienteOutras = 75,
        ParteOponente = 76,
        Penhora = 77,
        PenhoraStatus = 78,
        PoderJudiciarioAssociado = 79,
        PontoVirtual = 80,
        PontoVirtualAcessos = 81,
        PosicaoOutrasPartes = 82,
        PreClientes = 83,
        Prepostos = 84,
        ProBarCODE = 85,
        ProCDA = 86,
        ProcessosObsReport = 87,
        ProcessosParados = 88,
        ProcessOutputEngine = 89,
        ProcessOutPutIDs = 90,
        ProcessOutputRequest = 91,
        ProcessOutputSources = 92,
        ProDepositos = 93,
        ProDespesas = 94,
        ProObservacoes = 95,
        ProPartes = 96,
        ProProcuradores = 97,
        ProResumos = 98,
        ProSucumbencia = 99,
        ProTipoBaixa = 100,
        ProValores = 101,
        Ramal = 102,
        RegimeTributacao = 103,
        Reuniao = 104,
        Rito = 105,
        Servicos = 106,
        Setor = 107,
        Situacao = 108,
        SMSAlice = 109,
        StatusAndamento = 110,
        StatusHTrab = 111,
        StatusInstancia = 112,
        StatusTarefas = 113,
        Terceiros = 114,
        TipoCompromisso = 115,
        TipoContatoCRM = 116,
        TipoEMail = 117,
        TipoEndereco = 118,
        TipoEnderecoSistema = 119,
        TipoModeloDocumento = 120,
        TipoOrigemSucumbencia = 121,
        TipoProDesposito = 122,
        TipoRecurso = 123,
        TiposAcao = 124,
        TipoStatusBiu = 125,
        TipoValorProcesso = 126,
        TribEnderecos = 127,
        Tribunal = 128,
        UF = 129,
        UltimosProcessos = 130,
        ViaRecebimento = 131,
        AgendaRelatorio = 132,
        AgendaSemana = 133
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
        DBBensClassificacao.PTabelaNome => 15,
        DBBensMateriais.PTabelaNome => 16,
        DBCargos.PTabelaNome => 17,
        DBCargosEsc.PTabelaNome => 18,
        DBCargosEscClass.PTabelaNome => 19,
        DBCidade.PTabelaNome => 20,
        DBClientes.PTabelaNome => 21,
        DBClientesSocios.PTabelaNome => 22,
        DBColaboradores.PTabelaNome => 23,
        DBContaCorrente.PTabelaNome => 24,
        DBContatoCRMView.PTabelaNome => 25,
        DBContratos.PTabelaNome => 26,
        DBDadosProcuracao.PTabelaNome => 27,
        DBDiario2.PTabelaNome => 28,
        DBDivisaoTribunal.PTabelaNome => 29,
        DBDocumentos.PTabelaNome => 30,
        DBEMPClassRiscos.PTabelaNome => 31,
        DBEnderecos.PTabelaNome => 32,
        DBEnderecoSistema.PTabelaNome => 33,
        DBEndTit.PTabelaNome => 34,
        DBEnquadramentoEmpresa.PTabelaNome => 35,
        DBEscritorios.PTabelaNome => 36,
        DBEventoPrazoAgenda.PTabelaNome => 37,
        DBFase.PTabelaNome => 38,
        DBFornecedores.PTabelaNome => 39,
        DBForo.PTabelaNome => 40,
        DBFuncao.PTabelaNome => 41,
        DBFuncionarios.PTabelaNome => 42,
        DBGraph.PTabelaNome => 43,
        DBGruposEmpresas.PTabelaNome => 44,
        DBGruposEmpresasCli.PTabelaNome => 45,
        DBGUTAtividades.PTabelaNome => 46,
        DBGUTAtividadesMatriz.PTabelaNome => 47,
        DBGUTMatriz.PTabelaNome => 48,
        DBGUTPeriodicidade.PTabelaNome => 49,
        DBGUTPeriodicidadeStatus.PTabelaNome => 50,
        DBGUTTipo.PTabelaNome => 51,
        DBHonorariosDadosContrato.PTabelaNome => 52,
        DBHorasTrab.PTabelaNome => 53,
        DBInstancia.PTabelaNome => 54,
        DBJustica.PTabelaNome => 55,
        DBLigacoes.PTabelaNome => 56,
        DBLivroCaixa.PTabelaNome => 57,
        DBModelosDocumentos.PTabelaNome => 58,
        DBNECompromissos.PTabelaNome => 59,
        DBNENotas.PTabelaNome => 60,
        DBNEPalavrasChaves.PTabelaNome => 61,
        DBObjetos.PTabelaNome => 62,
        DBOperador.PTabelaNome => 63,
        DBOperadorEMailPopup.PTabelaNome => 64,
        DBOperadores.PTabelaNome => 65,
        DBOperadorGrupo.PTabelaNome => 66,
        DBOperadorGrupos.PTabelaNome => 67,
        DBOperadorGruposAgenda.PTabelaNome => 68,
        DBOponentes.PTabelaNome => 69,
        DBOponentesRepLegal.PTabelaNome => 70,
        DBOutrasPartesCliente.PTabelaNome => 71,
        DBPaises.PTabelaNome => 72,
        DBParceriaProc.PTabelaNome => 73,
        DBParteCliente.PTabelaNome => 74,
        DBParteClienteOutras.PTabelaNome => 75,
        DBParteOponente.PTabelaNome => 76,
        DBPenhora.PTabelaNome => 77,
        DBPenhoraStatus.PTabelaNome => 78,
        DBPoderJudiciarioAssociado.PTabelaNome => 79,
        DBPontoVirtual.PTabelaNome => 80,
        DBPontoVirtualAcessos.PTabelaNome => 81,
        DBPosicaoOutrasPartes.PTabelaNome => 82,
        DBPreClientes.PTabelaNome => 83,
        DBPrepostos.PTabelaNome => 84,
        DBProBarCODE.PTabelaNome => 85,
        DBProCDA.PTabelaNome => 86,
        DBProcessosObsReport.PTabelaNome => 87,
        DBProcessosParados.PTabelaNome => 88,
        DBProcessOutputEngine.PTabelaNome => 89,
        DBProcessOutPutIDs.PTabelaNome => 90,
        DBProcessOutputRequest.PTabelaNome => 91,
        DBProcessOutputSources.PTabelaNome => 92,
        DBProDepositos.PTabelaNome => 93,
        DBProDespesas.PTabelaNome => 94,
        DBProObservacoes.PTabelaNome => 95,
        DBProPartes.PTabelaNome => 96,
        DBProProcuradores.PTabelaNome => 97,
        DBProResumos.PTabelaNome => 98,
        DBProSucumbencia.PTabelaNome => 99,
        DBProTipoBaixa.PTabelaNome => 100,
        DBProValores.PTabelaNome => 101,
        DBRamal.PTabelaNome => 102,
        DBRegimeTributacao.PTabelaNome => 103,
        DBReuniao.PTabelaNome => 104,
        DBRito.PTabelaNome => 105,
        DBServicos.PTabelaNome => 106,
        DBSetor.PTabelaNome => 107,
        DBSituacao.PTabelaNome => 108,
        DBSMSAlice.PTabelaNome => 109,
        DBStatusAndamento.PTabelaNome => 110,
        DBStatusHTrab.PTabelaNome => 111,
        DBStatusInstancia.PTabelaNome => 112,
        DBStatusTarefas.PTabelaNome => 113,
        DBTerceiros.PTabelaNome => 114,
        DBTipoCompromisso.PTabelaNome => 115,
        DBTipoContatoCRM.PTabelaNome => 116,
        DBTipoEMail.PTabelaNome => 117,
        DBTipoEndereco.PTabelaNome => 118,
        DBTipoEnderecoSistema.PTabelaNome => 119,
        DBTipoModeloDocumento.PTabelaNome => 120,
        DBTipoOrigemSucumbencia.PTabelaNome => 121,
        DBTipoProDesposito.PTabelaNome => 122,
        DBTipoRecurso.PTabelaNome => 123,
        DBTiposAcao.PTabelaNome => 124,
        DBTipoStatusBiu.PTabelaNome => 125,
        DBTipoValorProcesso.PTabelaNome => 126,
        DBTribEnderecos.PTabelaNome => 127,
        DBTribunal.PTabelaNome => 128,
        DBUF.PTabelaNome => 129,
        DBUltimosProcessos.PTabelaNome => 130,
        DBViaRecebimento.PTabelaNome => 131,
        DBAgendaRelatorio.PTabelaNome => 132,
        DBAgendaSemana.PTabelaNome => 133,
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
        15 => DBBensClassificacao.PTabelaNome,
        16 => DBBensMateriais.PTabelaNome,
        17 => DBCargos.PTabelaNome,
        18 => DBCargosEsc.PTabelaNome,
        19 => DBCargosEscClass.PTabelaNome,
        20 => DBCidade.PTabelaNome,
        21 => DBClientes.PTabelaNome,
        22 => DBClientesSocios.PTabelaNome,
        23 => DBColaboradores.PTabelaNome,
        24 => DBContaCorrente.PTabelaNome,
        25 => DBContatoCRMView.PTabelaNome,
        26 => DBContratos.PTabelaNome,
        27 => DBDadosProcuracao.PTabelaNome,
        28 => DBDiario2.PTabelaNome,
        29 => DBDivisaoTribunal.PTabelaNome,
        30 => DBDocumentos.PTabelaNome,
        31 => DBEMPClassRiscos.PTabelaNome,
        32 => DBEnderecos.PTabelaNome,
        33 => DBEnderecoSistema.PTabelaNome,
        34 => DBEndTit.PTabelaNome,
        35 => DBEnquadramentoEmpresa.PTabelaNome,
        36 => DBEscritorios.PTabelaNome,
        37 => DBEventoPrazoAgenda.PTabelaNome,
        38 => DBFase.PTabelaNome,
        39 => DBFornecedores.PTabelaNome,
        40 => DBForo.PTabelaNome,
        41 => DBFuncao.PTabelaNome,
        42 => DBFuncionarios.PTabelaNome,
        43 => DBGraph.PTabelaNome,
        44 => DBGruposEmpresas.PTabelaNome,
        45 => DBGruposEmpresasCli.PTabelaNome,
        46 => DBGUTAtividades.PTabelaNome,
        47 => DBGUTAtividadesMatriz.PTabelaNome,
        48 => DBGUTMatriz.PTabelaNome,
        49 => DBGUTPeriodicidade.PTabelaNome,
        50 => DBGUTPeriodicidadeStatus.PTabelaNome,
        51 => DBGUTTipo.PTabelaNome,
        52 => DBHonorariosDadosContrato.PTabelaNome,
        53 => DBHorasTrab.PTabelaNome,
        54 => DBInstancia.PTabelaNome,
        55 => DBJustica.PTabelaNome,
        56 => DBLigacoes.PTabelaNome,
        57 => DBLivroCaixa.PTabelaNome,
        58 => DBModelosDocumentos.PTabelaNome,
        59 => DBNECompromissos.PTabelaNome,
        60 => DBNENotas.PTabelaNome,
        61 => DBNEPalavrasChaves.PTabelaNome,
        62 => DBObjetos.PTabelaNome,
        63 => DBOperador.PTabelaNome,
        64 => DBOperadorEMailPopup.PTabelaNome,
        65 => DBOperadores.PTabelaNome,
        66 => DBOperadorGrupo.PTabelaNome,
        67 => DBOperadorGrupos.PTabelaNome,
        68 => DBOperadorGruposAgenda.PTabelaNome,
        69 => DBOponentes.PTabelaNome,
        70 => DBOponentesRepLegal.PTabelaNome,
        71 => DBOutrasPartesCliente.PTabelaNome,
        72 => DBPaises.PTabelaNome,
        73 => DBParceriaProc.PTabelaNome,
        74 => DBParteCliente.PTabelaNome,
        75 => DBParteClienteOutras.PTabelaNome,
        76 => DBParteOponente.PTabelaNome,
        77 => DBPenhora.PTabelaNome,
        78 => DBPenhoraStatus.PTabelaNome,
        79 => DBPoderJudiciarioAssociado.PTabelaNome,
        80 => DBPontoVirtual.PTabelaNome,
        81 => DBPontoVirtualAcessos.PTabelaNome,
        82 => DBPosicaoOutrasPartes.PTabelaNome,
        83 => DBPreClientes.PTabelaNome,
        84 => DBPrepostos.PTabelaNome,
        85 => DBProBarCODE.PTabelaNome,
        86 => DBProCDA.PTabelaNome,
        87 => DBProcessosObsReport.PTabelaNome,
        88 => DBProcessosParados.PTabelaNome,
        89 => DBProcessOutputEngine.PTabelaNome,
        90 => DBProcessOutPutIDs.PTabelaNome,
        91 => DBProcessOutputRequest.PTabelaNome,
        92 => DBProcessOutputSources.PTabelaNome,
        93 => DBProDepositos.PTabelaNome,
        94 => DBProDespesas.PTabelaNome,
        95 => DBProObservacoes.PTabelaNome,
        96 => DBProPartes.PTabelaNome,
        97 => DBProProcuradores.PTabelaNome,
        98 => DBProResumos.PTabelaNome,
        99 => DBProSucumbencia.PTabelaNome,
        100 => DBProTipoBaixa.PTabelaNome,
        101 => DBProValores.PTabelaNome,
        102 => DBRamal.PTabelaNome,
        103 => DBRegimeTributacao.PTabelaNome,
        104 => DBReuniao.PTabelaNome,
        105 => DBRito.PTabelaNome,
        106 => DBServicos.PTabelaNome,
        107 => DBSetor.PTabelaNome,
        108 => DBSituacao.PTabelaNome,
        109 => DBSMSAlice.PTabelaNome,
        110 => DBStatusAndamento.PTabelaNome,
        111 => DBStatusHTrab.PTabelaNome,
        112 => DBStatusInstancia.PTabelaNome,
        113 => DBStatusTarefas.PTabelaNome,
        114 => DBTerceiros.PTabelaNome,
        115 => DBTipoCompromisso.PTabelaNome,
        116 => DBTipoContatoCRM.PTabelaNome,
        117 => DBTipoEMail.PTabelaNome,
        118 => DBTipoEndereco.PTabelaNome,
        119 => DBTipoEnderecoSistema.PTabelaNome,
        120 => DBTipoModeloDocumento.PTabelaNome,
        121 => DBTipoOrigemSucumbencia.PTabelaNome,
        122 => DBTipoProDesposito.PTabelaNome,
        123 => DBTipoRecurso.PTabelaNome,
        124 => DBTiposAcao.PTabelaNome,
        125 => DBTipoStatusBiu.PTabelaNome,
        126 => DBTipoValorProcesso.PTabelaNome,
        127 => DBTribEnderecos.PTabelaNome,
        128 => DBTribunal.PTabelaNome,
        129 => DBUF.PTabelaNome,
        130 => DBUltimosProcessos.PTabelaNome,
        131 => DBViaRecebimento.PTabelaNome,
        132 => DBAgendaRelatorio.PTabelaNome,
        133 => DBAgendaSemana.PTabelaNome,
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
        "15" => new DBBensClassificacaoODicInfo(),
        DBBensClassificacao.PTabelaNome => new DBBensClassificacaoODicInfo(),
        "BENSCLASSIFICACAO" => new DBBensClassificacaoODicInfo(),
        "16" => new DBBensMateriaisODicInfo(),
        DBBensMateriais.PTabelaNome => new DBBensMateriaisODicInfo(),
        "BENSMATERIAIS" => new DBBensMateriaisODicInfo(),
        "17" => new DBCargosODicInfo(),
        DBCargos.PTabelaNome => new DBCargosODicInfo(),
        "CARGOS" => new DBCargosODicInfo(),
        "18" => new DBCargosEscODicInfo(),
        DBCargosEsc.PTabelaNome => new DBCargosEscODicInfo(),
        "CARGOSESC" => new DBCargosEscODicInfo(),
        "19" => new DBCargosEscClassODicInfo(),
        DBCargosEscClass.PTabelaNome => new DBCargosEscClassODicInfo(),
        "CARGOSESCCLASS" => new DBCargosEscClassODicInfo(),
        "20" => new DBCidadeODicInfo(),
        DBCidade.PTabelaNome => new DBCidadeODicInfo(),
        "CIDADE" => new DBCidadeODicInfo(),
        "21" => new DBClientesODicInfo(),
        DBClientes.PTabelaNome => new DBClientesODicInfo(),
        "CLIENTES" => new DBClientesODicInfo(),
        "22" => new DBClientesSociosODicInfo(),
        DBClientesSocios.PTabelaNome => new DBClientesSociosODicInfo(),
        "CLIENTESSOCIOS" => new DBClientesSociosODicInfo(),
        "23" => new DBColaboradoresODicInfo(),
        DBColaboradores.PTabelaNome => new DBColaboradoresODicInfo(),
        "COLABORADORES" => new DBColaboradoresODicInfo(),
        "24" => new DBContaCorrenteODicInfo(),
        DBContaCorrente.PTabelaNome => new DBContaCorrenteODicInfo(),
        "CONTACORRENTE" => new DBContaCorrenteODicInfo(),
        "25" => new DBContatoCRMViewODicInfo(),
        DBContatoCRMView.PTabelaNome => new DBContatoCRMViewODicInfo(),
        "CONTATOCRMVIEW" => new DBContatoCRMViewODicInfo(),
        "26" => new DBContratosODicInfo(),
        DBContratos.PTabelaNome => new DBContratosODicInfo(),
        "CONTRATOS" => new DBContratosODicInfo(),
        "27" => new DBDadosProcuracaoODicInfo(),
        DBDadosProcuracao.PTabelaNome => new DBDadosProcuracaoODicInfo(),
        "DADOSPROCURACAO" => new DBDadosProcuracaoODicInfo(),
        "28" => new DBDiario2ODicInfo(),
        DBDiario2.PTabelaNome => new DBDiario2ODicInfo(),
        "DIARIO2" => new DBDiario2ODicInfo(),
        "29" => new DBDivisaoTribunalODicInfo(),
        DBDivisaoTribunal.PTabelaNome => new DBDivisaoTribunalODicInfo(),
        "DIVISAOTRIBUNAL" => new DBDivisaoTribunalODicInfo(),
        "30" => new DBDocumentosODicInfo(),
        DBDocumentos.PTabelaNome => new DBDocumentosODicInfo(),
        "DOCUMENTOS" => new DBDocumentosODicInfo(),
        "31" => new DBEMPClassRiscosODicInfo(),
        DBEMPClassRiscos.PTabelaNome => new DBEMPClassRiscosODicInfo(),
        "EMPCLASSRISCOS" => new DBEMPClassRiscosODicInfo(),
        "32" => new DBEnderecosODicInfo(),
        DBEnderecos.PTabelaNome => new DBEnderecosODicInfo(),
        "ENDERECOS" => new DBEnderecosODicInfo(),
        "33" => new DBEnderecoSistemaODicInfo(),
        DBEnderecoSistema.PTabelaNome => new DBEnderecoSistemaODicInfo(),
        "ENDERECOSISTEMA" => new DBEnderecoSistemaODicInfo(),
        "34" => new DBEndTitODicInfo(),
        DBEndTit.PTabelaNome => new DBEndTitODicInfo(),
        "ENDTIT" => new DBEndTitODicInfo(),
        "35" => new DBEnquadramentoEmpresaODicInfo(),
        DBEnquadramentoEmpresa.PTabelaNome => new DBEnquadramentoEmpresaODicInfo(),
        "ENQUADRAMENTOEMPRESA" => new DBEnquadramentoEmpresaODicInfo(),
        "36" => new DBEscritoriosODicInfo(),
        DBEscritorios.PTabelaNome => new DBEscritoriosODicInfo(),
        "ESCRITORIOS" => new DBEscritoriosODicInfo(),
        "37" => new DBEventoPrazoAgendaODicInfo(),
        DBEventoPrazoAgenda.PTabelaNome => new DBEventoPrazoAgendaODicInfo(),
        "EVENTOPRAZOAGENDA" => new DBEventoPrazoAgendaODicInfo(),
        "38" => new DBFaseODicInfo(),
        DBFase.PTabelaNome => new DBFaseODicInfo(),
        "FASE" => new DBFaseODicInfo(),
        "39" => new DBFornecedoresODicInfo(),
        DBFornecedores.PTabelaNome => new DBFornecedoresODicInfo(),
        "FORNECEDORES" => new DBFornecedoresODicInfo(),
        "40" => new DBForoODicInfo(),
        DBForo.PTabelaNome => new DBForoODicInfo(),
        "FORO" => new DBForoODicInfo(),
        "41" => new DBFuncaoODicInfo(),
        DBFuncao.PTabelaNome => new DBFuncaoODicInfo(),
        "FUNCAO" => new DBFuncaoODicInfo(),
        "42" => new DBFuncionariosODicInfo(),
        DBFuncionarios.PTabelaNome => new DBFuncionariosODicInfo(),
        "FUNCIONARIOS" => new DBFuncionariosODicInfo(),
        "43" => new DBGraphODicInfo(),
        DBGraph.PTabelaNome => new DBGraphODicInfo(),
        "GRAPH" => new DBGraphODicInfo(),
        "44" => new DBGruposEmpresasODicInfo(),
        DBGruposEmpresas.PTabelaNome => new DBGruposEmpresasODicInfo(),
        "GRUPOSEMPRESAS" => new DBGruposEmpresasODicInfo(),
        "45" => new DBGruposEmpresasCliODicInfo(),
        DBGruposEmpresasCli.PTabelaNome => new DBGruposEmpresasCliODicInfo(),
        "GRUPOSEMPRESASCLI" => new DBGruposEmpresasCliODicInfo(),
        "46" => new DBGUTAtividadesODicInfo(),
        DBGUTAtividades.PTabelaNome => new DBGUTAtividadesODicInfo(),
        "GUTATIVIDADES" => new DBGUTAtividadesODicInfo(),
        "47" => new DBGUTAtividadesMatrizODicInfo(),
        DBGUTAtividadesMatriz.PTabelaNome => new DBGUTAtividadesMatrizODicInfo(),
        "GUTATIVIDADESMATRIZ" => new DBGUTAtividadesMatrizODicInfo(),
        "48" => new DBGUTMatrizODicInfo(),
        DBGUTMatriz.PTabelaNome => new DBGUTMatrizODicInfo(),
        "GUTMATRIZ" => new DBGUTMatrizODicInfo(),
        "49" => new DBGUTPeriodicidadeODicInfo(),
        DBGUTPeriodicidade.PTabelaNome => new DBGUTPeriodicidadeODicInfo(),
        "GUTPERIODICIDADE" => new DBGUTPeriodicidadeODicInfo(),
        "50" => new DBGUTPeriodicidadeStatusODicInfo(),
        DBGUTPeriodicidadeStatus.PTabelaNome => new DBGUTPeriodicidadeStatusODicInfo(),
        "GUTPERIODICIDADESTATUS" => new DBGUTPeriodicidadeStatusODicInfo(),
        "51" => new DBGUTTipoODicInfo(),
        DBGUTTipo.PTabelaNome => new DBGUTTipoODicInfo(),
        "GUTTIPO" => new DBGUTTipoODicInfo(),
        "52" => new DBHonorariosDadosContratoODicInfo(),
        DBHonorariosDadosContrato.PTabelaNome => new DBHonorariosDadosContratoODicInfo(),
        "HONORARIOSDADOSCONTRATO" => new DBHonorariosDadosContratoODicInfo(),
        "53" => new DBHorasTrabODicInfo(),
        DBHorasTrab.PTabelaNome => new DBHorasTrabODicInfo(),
        "HORASTRAB" => new DBHorasTrabODicInfo(),
        "54" => new DBInstanciaODicInfo(),
        DBInstancia.PTabelaNome => new DBInstanciaODicInfo(),
        "INSTANCIA" => new DBInstanciaODicInfo(),
        "55" => new DBJusticaODicInfo(),
        DBJustica.PTabelaNome => new DBJusticaODicInfo(),
        "JUSTICA" => new DBJusticaODicInfo(),
        "56" => new DBLigacoesODicInfo(),
        DBLigacoes.PTabelaNome => new DBLigacoesODicInfo(),
        "LIGACOES" => new DBLigacoesODicInfo(),
        "57" => new DBLivroCaixaODicInfo(),
        DBLivroCaixa.PTabelaNome => new DBLivroCaixaODicInfo(),
        "LIVROCAIXA" => new DBLivroCaixaODicInfo(),
        "58" => new DBModelosDocumentosODicInfo(),
        DBModelosDocumentos.PTabelaNome => new DBModelosDocumentosODicInfo(),
        "MODELOSDOCUMENTOS" => new DBModelosDocumentosODicInfo(),
        "59" => new DBNECompromissosODicInfo(),
        DBNECompromissos.PTabelaNome => new DBNECompromissosODicInfo(),
        "NECOMPROMISSOS" => new DBNECompromissosODicInfo(),
        "60" => new DBNENotasODicInfo(),
        DBNENotas.PTabelaNome => new DBNENotasODicInfo(),
        "NENOTAS" => new DBNENotasODicInfo(),
        "61" => new DBNEPalavrasChavesODicInfo(),
        DBNEPalavrasChaves.PTabelaNome => new DBNEPalavrasChavesODicInfo(),
        "NEPALAVRASCHAVES" => new DBNEPalavrasChavesODicInfo(),
        "62" => new DBObjetosODicInfo(),
        DBObjetos.PTabelaNome => new DBObjetosODicInfo(),
        "OBJETOS" => new DBObjetosODicInfo(),
        "63" => new DBOperadorODicInfo(),
        DBOperador.PTabelaNome => new DBOperadorODicInfo(),
        "OPERADOR" => new DBOperadorODicInfo(),
        "64" => new DBOperadorEMailPopupODicInfo(),
        DBOperadorEMailPopup.PTabelaNome => new DBOperadorEMailPopupODicInfo(),
        "OPERADOREMAILPOPUP" => new DBOperadorEMailPopupODicInfo(),
        "65" => new DBOperadoresODicInfo(),
        DBOperadores.PTabelaNome => new DBOperadoresODicInfo(),
        "OPERADORES" => new DBOperadoresODicInfo(),
        "66" => new DBOperadorGrupoODicInfo(),
        DBOperadorGrupo.PTabelaNome => new DBOperadorGrupoODicInfo(),
        "OPERADORGRUPO" => new DBOperadorGrupoODicInfo(),
        "67" => new DBOperadorGruposODicInfo(),
        DBOperadorGrupos.PTabelaNome => new DBOperadorGruposODicInfo(),
        "OPERADORGRUPOS" => new DBOperadorGruposODicInfo(),
        "68" => new DBOperadorGruposAgendaODicInfo(),
        DBOperadorGruposAgenda.PTabelaNome => new DBOperadorGruposAgendaODicInfo(),
        "OPERADORGRUPOSAGENDA" => new DBOperadorGruposAgendaODicInfo(),
        "69" => new DBOponentesODicInfo(),
        DBOponentes.PTabelaNome => new DBOponentesODicInfo(),
        "OPONENTES" => new DBOponentesODicInfo(),
        "70" => new DBOponentesRepLegalODicInfo(),
        DBOponentesRepLegal.PTabelaNome => new DBOponentesRepLegalODicInfo(),
        "OPONENTESREPLEGAL" => new DBOponentesRepLegalODicInfo(),
        "71" => new DBOutrasPartesClienteODicInfo(),
        DBOutrasPartesCliente.PTabelaNome => new DBOutrasPartesClienteODicInfo(),
        "OUTRASPARTESCLIENTE" => new DBOutrasPartesClienteODicInfo(),
        "72" => new DBPaisesODicInfo(),
        DBPaises.PTabelaNome => new DBPaisesODicInfo(),
        "PAISES" => new DBPaisesODicInfo(),
        "73" => new DBParceriaProcODicInfo(),
        DBParceriaProc.PTabelaNome => new DBParceriaProcODicInfo(),
        "PARCERIAPROC" => new DBParceriaProcODicInfo(),
        "74" => new DBParteClienteODicInfo(),
        DBParteCliente.PTabelaNome => new DBParteClienteODicInfo(),
        "PARTECLIENTE" => new DBParteClienteODicInfo(),
        "75" => new DBParteClienteOutrasODicInfo(),
        DBParteClienteOutras.PTabelaNome => new DBParteClienteOutrasODicInfo(),
        "PARTECLIENTEOUTRAS" => new DBParteClienteOutrasODicInfo(),
        "76" => new DBParteOponenteODicInfo(),
        DBParteOponente.PTabelaNome => new DBParteOponenteODicInfo(),
        "PARTEOPONENTE" => new DBParteOponenteODicInfo(),
        "77" => new DBPenhoraODicInfo(),
        DBPenhora.PTabelaNome => new DBPenhoraODicInfo(),
        "PENHORA" => new DBPenhoraODicInfo(),
        "78" => new DBPenhoraStatusODicInfo(),
        DBPenhoraStatus.PTabelaNome => new DBPenhoraStatusODicInfo(),
        "PENHORASTATUS" => new DBPenhoraStatusODicInfo(),
        "79" => new DBPoderJudiciarioAssociadoODicInfo(),
        DBPoderJudiciarioAssociado.PTabelaNome => new DBPoderJudiciarioAssociadoODicInfo(),
        "PODERJUDICIARIOASSOCIADO" => new DBPoderJudiciarioAssociadoODicInfo(),
        "80" => new DBPontoVirtualODicInfo(),
        DBPontoVirtual.PTabelaNome => new DBPontoVirtualODicInfo(),
        "PONTOVIRTUAL" => new DBPontoVirtualODicInfo(),
        "81" => new DBPontoVirtualAcessosODicInfo(),
        DBPontoVirtualAcessos.PTabelaNome => new DBPontoVirtualAcessosODicInfo(),
        "PONTOVIRTUALACESSOS" => new DBPontoVirtualAcessosODicInfo(),
        "82" => new DBPosicaoOutrasPartesODicInfo(),
        DBPosicaoOutrasPartes.PTabelaNome => new DBPosicaoOutrasPartesODicInfo(),
        "POSICAOOUTRASPARTES" => new DBPosicaoOutrasPartesODicInfo(),
        "83" => new DBPreClientesODicInfo(),
        DBPreClientes.PTabelaNome => new DBPreClientesODicInfo(),
        "PRECLIENTES" => new DBPreClientesODicInfo(),
        "84" => new DBPrepostosODicInfo(),
        DBPrepostos.PTabelaNome => new DBPrepostosODicInfo(),
        "PREPOSTOS" => new DBPrepostosODicInfo(),
        "85" => new DBProBarCODEODicInfo(),
        DBProBarCODE.PTabelaNome => new DBProBarCODEODicInfo(),
        "PROBARCODE" => new DBProBarCODEODicInfo(),
        "86" => new DBProCDAODicInfo(),
        DBProCDA.PTabelaNome => new DBProCDAODicInfo(),
        "PROCDA" => new DBProCDAODicInfo(),
        "87" => new DBProcessosObsReportODicInfo(),
        DBProcessosObsReport.PTabelaNome => new DBProcessosObsReportODicInfo(),
        "PROCESSOSOBSREPORT" => new DBProcessosObsReportODicInfo(),
        "88" => new DBProcessosParadosODicInfo(),
        DBProcessosParados.PTabelaNome => new DBProcessosParadosODicInfo(),
        "PROCESSOSPARADOS" => new DBProcessosParadosODicInfo(),
        "89" => new DBProcessOutputEngineODicInfo(),
        DBProcessOutputEngine.PTabelaNome => new DBProcessOutputEngineODicInfo(),
        "PROCESSOUTPUTENGINE" => new DBProcessOutputEngineODicInfo(),
        "90" => new DBProcessOutPutIDsODicInfo(),
        DBProcessOutPutIDs.PTabelaNome => new DBProcessOutPutIDsODicInfo(),
        "PROCESSOUTPUTIDS" => new DBProcessOutPutIDsODicInfo(),
        "91" => new DBProcessOutputRequestODicInfo(),
        DBProcessOutputRequest.PTabelaNome => new DBProcessOutputRequestODicInfo(),
        "PROCESSOUTPUTREQUEST" => new DBProcessOutputRequestODicInfo(),
        "92" => new DBProcessOutputSourcesODicInfo(),
        DBProcessOutputSources.PTabelaNome => new DBProcessOutputSourcesODicInfo(),
        "PROCESSOUTPUTSOURCES" => new DBProcessOutputSourcesODicInfo(),
        "93" => new DBProDepositosODicInfo(),
        DBProDepositos.PTabelaNome => new DBProDepositosODicInfo(),
        "PRODEPOSITOS" => new DBProDepositosODicInfo(),
        "94" => new DBProDespesasODicInfo(),
        DBProDespesas.PTabelaNome => new DBProDespesasODicInfo(),
        "PRODESPESAS" => new DBProDespesasODicInfo(),
        "95" => new DBProObservacoesODicInfo(),
        DBProObservacoes.PTabelaNome => new DBProObservacoesODicInfo(),
        "PROOBSERVACOES" => new DBProObservacoesODicInfo(),
        "96" => new DBProPartesODicInfo(),
        DBProPartes.PTabelaNome => new DBProPartesODicInfo(),
        "PROPARTES" => new DBProPartesODicInfo(),
        "97" => new DBProProcuradoresODicInfo(),
        DBProProcuradores.PTabelaNome => new DBProProcuradoresODicInfo(),
        "PROPROCURADORES" => new DBProProcuradoresODicInfo(),
        "98" => new DBProResumosODicInfo(),
        DBProResumos.PTabelaNome => new DBProResumosODicInfo(),
        "PRORESUMOS" => new DBProResumosODicInfo(),
        "99" => new DBProSucumbenciaODicInfo(),
        DBProSucumbencia.PTabelaNome => new DBProSucumbenciaODicInfo(),
        "PROSUCUMBENCIA" => new DBProSucumbenciaODicInfo(),
        "100" => new DBProTipoBaixaODicInfo(),
        DBProTipoBaixa.PTabelaNome => new DBProTipoBaixaODicInfo(),
        "PROTIPOBAIXA" => new DBProTipoBaixaODicInfo(),
        "101" => new DBProValoresODicInfo(),
        DBProValores.PTabelaNome => new DBProValoresODicInfo(),
        "PROVALORES" => new DBProValoresODicInfo(),
        "102" => new DBRamalODicInfo(),
        DBRamal.PTabelaNome => new DBRamalODicInfo(),
        "RAMAL" => new DBRamalODicInfo(),
        "103" => new DBRegimeTributacaoODicInfo(),
        DBRegimeTributacao.PTabelaNome => new DBRegimeTributacaoODicInfo(),
        "REGIMETRIBUTACAO" => new DBRegimeTributacaoODicInfo(),
        "104" => new DBReuniaoODicInfo(),
        DBReuniao.PTabelaNome => new DBReuniaoODicInfo(),
        "REUNIAO" => new DBReuniaoODicInfo(),
        "105" => new DBRitoODicInfo(),
        DBRito.PTabelaNome => new DBRitoODicInfo(),
        "RITO" => new DBRitoODicInfo(),
        "106" => new DBServicosODicInfo(),
        DBServicos.PTabelaNome => new DBServicosODicInfo(),
        "SERVICOS" => new DBServicosODicInfo(),
        "107" => new DBSetorODicInfo(),
        DBSetor.PTabelaNome => new DBSetorODicInfo(),
        "SETOR" => new DBSetorODicInfo(),
        "108" => new DBSituacaoODicInfo(),
        DBSituacao.PTabelaNome => new DBSituacaoODicInfo(),
        "SITUACAO" => new DBSituacaoODicInfo(),
        "109" => new DBSMSAliceODicInfo(),
        DBSMSAlice.PTabelaNome => new DBSMSAliceODicInfo(),
        "SMSALICE" => new DBSMSAliceODicInfo(),
        "110" => new DBStatusAndamentoODicInfo(),
        DBStatusAndamento.PTabelaNome => new DBStatusAndamentoODicInfo(),
        "STATUSANDAMENTO" => new DBStatusAndamentoODicInfo(),
        "111" => new DBStatusHTrabODicInfo(),
        DBStatusHTrab.PTabelaNome => new DBStatusHTrabODicInfo(),
        "STATUSHTRAB" => new DBStatusHTrabODicInfo(),
        "112" => new DBStatusInstanciaODicInfo(),
        DBStatusInstancia.PTabelaNome => new DBStatusInstanciaODicInfo(),
        "STATUSINSTANCIA" => new DBStatusInstanciaODicInfo(),
        "113" => new DBStatusTarefasODicInfo(),
        DBStatusTarefas.PTabelaNome => new DBStatusTarefasODicInfo(),
        "STATUSTAREFAS" => new DBStatusTarefasODicInfo(),
        "114" => new DBTerceirosODicInfo(),
        DBTerceiros.PTabelaNome => new DBTerceirosODicInfo(),
        "TERCEIROS" => new DBTerceirosODicInfo(),
        "115" => new DBTipoCompromissoODicInfo(),
        DBTipoCompromisso.PTabelaNome => new DBTipoCompromissoODicInfo(),
        "TIPOCOMPROMISSO" => new DBTipoCompromissoODicInfo(),
        "116" => new DBTipoContatoCRMODicInfo(),
        DBTipoContatoCRM.PTabelaNome => new DBTipoContatoCRMODicInfo(),
        "TIPOCONTATOCRM" => new DBTipoContatoCRMODicInfo(),
        "117" => new DBTipoEMailODicInfo(),
        DBTipoEMail.PTabelaNome => new DBTipoEMailODicInfo(),
        "TIPOEMAIL" => new DBTipoEMailODicInfo(),
        "118" => new DBTipoEnderecoODicInfo(),
        DBTipoEndereco.PTabelaNome => new DBTipoEnderecoODicInfo(),
        "TIPOENDERECO" => new DBTipoEnderecoODicInfo(),
        "119" => new DBTipoEnderecoSistemaODicInfo(),
        DBTipoEnderecoSistema.PTabelaNome => new DBTipoEnderecoSistemaODicInfo(),
        "TIPOENDERECOSISTEMA" => new DBTipoEnderecoSistemaODicInfo(),
        "120" => new DBTipoModeloDocumentoODicInfo(),
        DBTipoModeloDocumento.PTabelaNome => new DBTipoModeloDocumentoODicInfo(),
        "TIPOMODELODOCUMENTO" => new DBTipoModeloDocumentoODicInfo(),
        "121" => new DBTipoOrigemSucumbenciaODicInfo(),
        DBTipoOrigemSucumbencia.PTabelaNome => new DBTipoOrigemSucumbenciaODicInfo(),
        "TIPOORIGEMSUCUMBENCIA" => new DBTipoOrigemSucumbenciaODicInfo(),
        "122" => new DBTipoProDespositoODicInfo(),
        DBTipoProDesposito.PTabelaNome => new DBTipoProDespositoODicInfo(),
        "TIPOPRODESPOSITO" => new DBTipoProDespositoODicInfo(),
        "123" => new DBTipoRecursoODicInfo(),
        DBTipoRecurso.PTabelaNome => new DBTipoRecursoODicInfo(),
        "TIPORECURSO" => new DBTipoRecursoODicInfo(),
        "124" => new DBTiposAcaoODicInfo(),
        DBTiposAcao.PTabelaNome => new DBTiposAcaoODicInfo(),
        "TIPOSACAO" => new DBTiposAcaoODicInfo(),
        "125" => new DBTipoStatusBiuODicInfo(),
        DBTipoStatusBiu.PTabelaNome => new DBTipoStatusBiuODicInfo(),
        "TIPOSTATUSBIU" => new DBTipoStatusBiuODicInfo(),
        "126" => new DBTipoValorProcessoODicInfo(),
        DBTipoValorProcesso.PTabelaNome => new DBTipoValorProcessoODicInfo(),
        "TIPOVALORPROCESSO" => new DBTipoValorProcessoODicInfo(),
        "127" => new DBTribEnderecosODicInfo(),
        DBTribEnderecos.PTabelaNome => new DBTribEnderecosODicInfo(),
        "TRIBENDERECOS" => new DBTribEnderecosODicInfo(),
        "128" => new DBTribunalODicInfo(),
        DBTribunal.PTabelaNome => new DBTribunalODicInfo(),
        "TRIBUNAL" => new DBTribunalODicInfo(),
        "129" => new DBUFODicInfo(),
        DBUF.PTabelaNome => new DBUFODicInfo(),
        "130" => new DBUltimosProcessosODicInfo(),
        DBUltimosProcessos.PTabelaNome => new DBUltimosProcessosODicInfo(),
        "ULTIMOSPROCESSOS" => new DBUltimosProcessosODicInfo(),
        "131" => new DBViaRecebimentoODicInfo(),
        DBViaRecebimento.PTabelaNome => new DBViaRecebimentoODicInfo(),
        "VIARECEBIMENTO" => new DBViaRecebimentoODicInfo(),
        "132" => new DBAgendaRelatorioODicInfo(),
        DBAgendaRelatorio.PTabelaNome => new DBAgendaRelatorioODicInfo(),
        "AGENDARELATORIO" => new DBAgendaRelatorioODicInfo(),
        "133" => new DBAgendaSemanaODicInfo(),
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

    public List<IODicInfo> ListaSecureSearchableDicInfo => [new DBAdvogadosODicInfo(), new DBAlertasODicInfo(), new DBAlertasEnviadosODicInfo(), new DBAndCompODicInfo(), new DBApenso2ODicInfo(), new DBClientesODicInfo(), new DBClientesSociosODicInfo(), new DBColaboradoresODicInfo(), new DBDiario2ODicInfo(), new DBEnderecosODicInfo(), new DBEnderecoSistemaODicInfo(), new DBEscritoriosODicInfo(), new DBFornecedoresODicInfo(), new DBForoODicInfo(), new DBFuncionariosODicInfo(), new DBGraphODicInfo(), new DBHonorariosDadosContratoODicInfo(), new DBHorasTrabODicInfo(), new DBInstanciaODicInfo(), new DBLigacoesODicInfo(), new DBNENotasODicInfo(), new DBOponentesODicInfo(), new DBOponentesRepLegalODicInfo(), new DBOutrasPartesClienteODicInfo(), new DBParceriaProcODicInfo(), new DBParteClienteODicInfo(), new DBParteClienteOutrasODicInfo(), new DBParteOponenteODicInfo(), new DBPenhoraODicInfo(), new DBPontoVirtualODicInfo(), new DBPontoVirtualAcessosODicInfo(), new DBPreClientesODicInfo(), new DBPrepostosODicInfo(), new DBProCDAODicInfo(), new DBProcessosObsReportODicInfo(), new DBProcessosParadosODicInfo(), new DBProcessOutputEngineODicInfo(), new DBProcessOutPutIDsODicInfo(), new DBProcessOutputRequestODicInfo(), new DBProcessOutputSourcesODicInfo(), new DBProDepositosODicInfo(), new DBProDespesasODicInfo(), new DBProObservacoesODicInfo(), new DBProPartesODicInfo(), new DBProProcuradoresODicInfo(), new DBProResumosODicInfo(), new DBProSucumbenciaODicInfo(), new DBProValoresODicInfo(), new DBReuniaoODicInfo(), new DBTerceirosODicInfo()];

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
