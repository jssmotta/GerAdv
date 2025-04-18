using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBProcessosDicInfo
{
    public const string CampoCodigo = "proCodigo";
    public const string CampoNome = "proNroPasta";
    public const string TablePrefix = "pro";
    public const string AdvParc = "proAdvParc"; // LOCALIZACAO 170523
    public const string AJGPedidoNegado = "proAJGPedidoNegado"; // LOCALIZACAO 170523
    public const string AJGCliente = "proAJGCliente"; // LOCALIZACAO 170523
    public const string AJGPedidoNegadoOPO = "proAJGPedidoNegadoOPO"; // LOCALIZACAO 170523
    public const string NotificarPOE = "proNotificarPOE"; // LOCALIZACAO 170523
    public const string ValorProvisionado = "proValorProvisionado"; // LOCALIZACAO 170523
    public const string AJGOponente = "proAJGOponente"; // LOCALIZACAO 170523
    public const string ValorCacheCalculo = "proValorCacheCalculo"; // LOCALIZACAO 170523
    public const string AJGPedidoOPO = "proAJGPedidoOPO"; // LOCALIZACAO 170523
    public const string ValorCacheCalculoProv = "proValorCacheCalculoProv"; // LOCALIZACAO 170523
    public const string ConsiderarParado = "proConsiderarParado"; // LOCALIZACAO 170523
    public const string ValorCalculado = "proValorCalculado"; // LOCALIZACAO 170523
    public const string AJGConcedidoOPO = "proAJGConcedidoOPO"; // LOCALIZACAO 170523
    public const string Cobranca = "proCobranca"; // LOCALIZACAO 170523
    public const string DataEntrada = "proDataEntrada"; // LOCALIZACAO 170523
    public const string Penhora = "proPenhora"; // LOCALIZACAO 170523
    public const string AJGPedido = "proAJGPedido"; // LOCALIZACAO 170523
    public const string TipoBaixa = "proTipoBaixa"; // LOCALIZACAO 170523
    public const string ClassRisco = "proClassRisco"; // LOCALIZACAO 170523
    public const string IsApenso = "proIsApenso"; // LOCALIZACAO 170523
    public const string ValorCausaInicial = "proValorCausaInicial"; // LOCALIZACAO 170523
    public const string AJGConcedido = "proAJGConcedido"; // LOCALIZACAO 170523
    public const string ObsBCX = "proObsBCX"; // LOCALIZACAO 170523
    public const string ValorCausaDefinitivo = "proValorCausaDefinitivo"; // LOCALIZACAO 170523
    public const string PercProbExito = "proPercProbExito"; // LOCALIZACAO 170523
    public const string MNA = "proMNA"; // LOCALIZACAO 170523
    public const string PercExito = "proPercExito"; // LOCALIZACAO 170523
    public const string NroExtra = "proNroExtra"; // LOCALIZACAO 170523
    public const string AdvOpo = "proAdvOpo"; // LOCALIZACAO 170523
    public const string Extra = "proExtra"; // LOCALIZACAO 170523
    public const string Justica = "proJustica"; // LOCALIZACAO 170523
    public const string Advogado = "proAdvogado"; // LOCALIZACAO 170523
    public const string NroCaixa = "proNroCaixa"; // LOCALIZACAO 170523
    public const string Preposto = "proPreposto"; // LOCALIZACAO 170523
    public const string Cliente = "proCliente"; // LOCALIZACAO 170523
    public const string Oponente = "proOponente"; // LOCALIZACAO 170523
    public const string Area = "proArea"; // LOCALIZACAO 170523
    public const string Cidade = "proCidade"; // LOCALIZACAO 170523
    public const string Situacao = "proSituacao"; // LOCALIZACAO 170523
    public const string IDSituacao = "proIDSituacao"; // LOCALIZACAO 170523
    public const string Valor = "proValor"; // LOCALIZACAO 170523
    public const string Rito = "proRito"; // LOCALIZACAO 170523
    public const string Fato = "proFato"; // LOCALIZACAO 170523
    public const string NroPasta = "proNroPasta"; // LOCALIZACAO 170523
    public const string Atividade = "proAtividade"; // LOCALIZACAO 170523
    public const string CaixaMorto = "proCaixaMorto"; // LOCALIZACAO 170523
    public const string Baixado = "proBaixado"; // LOCALIZACAO 170523
    public const string DtBaixa = "proDtBaixa"; // LOCALIZACAO 170523
    public const string MotivoBaixa = "proMotivoBaixa"; // LOCALIZACAO 170523
    public const string OBS = "proOBS"; // LOCALIZACAO 170523
    public const string Printed = "proPrinted"; // LOCALIZACAO 170523
    public const string ZKey = "proZKey"; // LOCALIZACAO 170523
    public const string ZKeyQuem = "proZKeyQuem"; // LOCALIZACAO 170523
    public const string ZKeyQuando = "proZKeyQuando"; // LOCALIZACAO 170523
    public const string Resumo = "proResumo"; // LOCALIZACAO 170523
    public const string NaoImprimir = "proNaoImprimir"; // LOCALIZACAO 170523
    public const string Eletronico = "proEletronico"; // LOCALIZACAO 170523
    public const string NroContrato = "proNroContrato"; // LOCALIZACAO 170523
    public const string PercProbExitoJustificativa = "proPercProbExitoJustificativa"; // LOCALIZACAO 170523
    public const string HonorarioValor = "proHonorarioValor"; // LOCALIZACAO 170523
    public const string HonorarioPercentual = "proHonorarioPercentual"; // LOCALIZACAO 170523
    public const string HonorarioSucumbencia = "proHonorarioSucumbencia"; // LOCALIZACAO 170523
    public const string FaseAuditoria = "proFaseAuditoria"; // LOCALIZACAO 170523
    public const string ValorCondenacao = "proValorCondenacao"; // LOCALIZACAO 170523
    public const string ValorCondenacaoCalculado = "proValorCondenacaoCalculado"; // LOCALIZACAO 170523
    public const string ValorCondenacaoProvisorio = "proValorCondenacaoProvisorio"; // LOCALIZACAO 170523
    public const string GUID = "proGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "proQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "proDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "proQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "proDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "proVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => AdvParc,
        2 => AJGPedidoNegado,
        3 => AJGCliente,
        4 => AJGPedidoNegadoOPO,
        5 => NotificarPOE,
        6 => ValorProvisionado,
        7 => AJGOponente,
        8 => ValorCacheCalculo,
        9 => AJGPedidoOPO,
        10 => ValorCacheCalculoProv,
        11 => ConsiderarParado,
        12 => ValorCalculado,
        13 => AJGConcedidoOPO,
        14 => Cobranca,
        15 => DataEntrada,
        16 => Penhora,
        17 => AJGPedido,
        18 => TipoBaixa,
        19 => ClassRisco,
        20 => IsApenso,
        21 => ValorCausaInicial,
        22 => AJGConcedido,
        23 => ObsBCX,
        24 => ValorCausaDefinitivo,
        25 => PercProbExito,
        26 => MNA,
        27 => PercExito,
        28 => NroExtra,
        29 => AdvOpo,
        30 => Extra,
        31 => Justica,
        32 => Advogado,
        33 => NroCaixa,
        34 => Preposto,
        35 => Cliente,
        36 => Oponente,
        37 => Area,
        38 => Cidade,
        39 => Situacao,
        40 => IDSituacao,
        41 => Valor,
        42 => Rito,
        43 => Fato,
        44 => NroPasta,
        45 => Atividade,
        46 => CaixaMorto,
        47 => Baixado,
        48 => DtBaixa,
        49 => MotivoBaixa,
        50 => OBS,
        51 => Printed,
        52 => ZKey,
        53 => ZKeyQuem,
        54 => ZKeyQuando,
        55 => Resumo,
        56 => NaoImprimir,
        57 => Eletronico,
        58 => NroContrato,
        59 => PercProbExitoJustificativa,
        60 => HonorarioValor,
        61 => HonorarioPercentual,
        62 => HonorarioSucumbencia,
        63 => FaseAuditoria,
        64 => ValorCondenacao,
        65 => ValorCondenacaoCalculado,
        66 => ValorCondenacaoProvisorio,
        67 => GUID,
        68 => QuemCad,
        69 => DtCad,
        70 => QuemAtu,
        71 => DtAtu,
        72 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Processos";
#region PropriedadesDaTabela
    public static DBInfoSystem ProAdvParc => new(0, PTabelaNome, CampoCodigo, AdvParc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem ProAJGPedidoNegado => new(0, PTabelaNome, CampoCodigo, AJGPedidoNegado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProAJGCliente => new(0, PTabelaNome, CampoCodigo, AJGCliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProAJGPedidoNegadoOPO => new(0, PTabelaNome, CampoCodigo, AJGPedidoNegadoOPO, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProNotificarPOE => new(0, PTabelaNome, CampoCodigo, NotificarPOE, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProValorProvisionado => new(0, PTabelaNome, CampoCodigo, ValorProvisionado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProAJGOponente => new(0, PTabelaNome, CampoCodigo, AJGOponente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProValorCacheCalculo => new(0, PTabelaNome, CampoCodigo, ValorCacheCalculo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProAJGPedidoOPO => new(0, PTabelaNome, CampoCodigo, AJGPedidoOPO, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProValorCacheCalculoProv => new(0, PTabelaNome, CampoCodigo, ValorCacheCalculoProv, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProConsiderarParado => new(0, PTabelaNome, CampoCodigo, ConsiderarParado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProValorCalculado => new(0, PTabelaNome, CampoCodigo, ValorCalculado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProAJGConcedidoOPO => new(0, PTabelaNome, CampoCodigo, AJGConcedidoOPO, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProCobranca => new(0, PTabelaNome, CampoCodigo, Cobranca, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProDataEntrada => new(0, PTabelaNome, CampoCodigo, DataEntrada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem ProPenhora => new(0, PTabelaNome, CampoCodigo, Penhora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProAJGPedido => new(0, PTabelaNome, CampoCodigo, AJGPedido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProTipoBaixa => new(0, PTabelaNome, CampoCodigo, TipoBaixa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem ProClassRisco => new(0, PTabelaNome, CampoCodigo, ClassRisco, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem ProIsApenso => new(0, PTabelaNome, CampoCodigo, IsApenso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProValorCausaInicial => new(0, PTabelaNome, CampoCodigo, ValorCausaInicial, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProAJGConcedido => new(0, PTabelaNome, CampoCodigo, AJGConcedido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProObsBCX => new(0, PTabelaNome, CampoCodigo, ObsBCX, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem ProValorCausaDefinitivo => new(0, PTabelaNome, CampoCodigo, ValorCausaDefinitivo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProPercProbExito => new(0, PTabelaNome, CampoCodigo, PercProbExito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProMNA => new(0, PTabelaNome, CampoCodigo, MNA, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProPercExito => new(0, PTabelaNome, CampoCodigo, PercExito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProNroExtra => new(0, PTabelaNome, CampoCodigo, NroExtra, 35, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem ProAdvOpo => new(0, PTabelaNome, CampoCodigo, AdvOpo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProExtra => new(0, PTabelaNome, CampoCodigo, Extra, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProNroCaixa => new(0, PTabelaNome, CampoCodigo, NroCaixa, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem ProPreposto => new(0, PTabelaNome, CampoCodigo, Preposto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPrepostosDicInfo.CampoCodigo, DBPrepostosDicInfo.TabelaNome, new DBPrepostosODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProOponente => new(0, PTabelaNome, CampoCodigo, Oponente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOponentesDicInfo.CampoCodigo, DBOponentesDicInfo.TabelaNome, new DBOponentesODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProCidade => new(0, PTabelaNome, CampoCodigo, Cidade, Captions.PCaption_Cidade, Captions.PCaption_CidadeUFPais, ETipoDadosSysteminfo.SysteminfoForeingkeyCidade, "cidCodigo", "Cidade", new DBCidadeODicInfo(), false);
    public static DBInfoSystem ProSituacao => new(0, PTabelaNome, CampoCodigo, Situacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBSituacaoDicInfo.CampoCodigo, DBSituacaoDicInfo.TabelaNome, new DBSituacaoODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProIDSituacao => new(0, PTabelaNome, CampoCodigo, IDSituacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProRito => new(0, PTabelaNome, CampoCodigo, Rito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBRitoDicInfo.CampoCodigo, DBRitoDicInfo.TabelaNome, new DBRitoODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProFato => new(0, PTabelaNome, CampoCodigo, Fato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem ProNroPasta => new(0, PTabelaNome, CampoCodigo, NroPasta, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem ProAtividade => new(0, PTabelaNome, CampoCodigo, Atividade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAtividadesDicInfo.CampoCodigo, DBAtividadesDicInfo.TabelaNome, new DBAtividadesODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProCaixaMorto => new(0, PTabelaNome, CampoCodigo, CaixaMorto, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem ProBaixado => new(0, PTabelaNome, CampoCodigo, Baixado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProDtBaixa => new(0, PTabelaNome, CampoCodigo, DtBaixa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem ProMotivoBaixa => new(0, PTabelaNome, CampoCodigo, MotivoBaixa, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem ProOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem ProPrinted => new(0, PTabelaNome, CampoCodigo, Printed, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProZKey => new(0, PTabelaNome, CampoCodigo, ZKey, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem ProZKeyQuem => new(0, PTabelaNome, CampoCodigo, ZKeyQuem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem ProZKeyQuando => new(0, PTabelaNome, CampoCodigo, ZKeyQuando, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem ProResumo => new(0, PTabelaNome, CampoCodigo, Resumo, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem ProNaoImprimir => new(0, PTabelaNome, CampoCodigo, NaoImprimir, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProEletronico => new(0, PTabelaNome, CampoCodigo, Eletronico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem ProNroContrato => new(0, PTabelaNome, CampoCodigo, NroContrato, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem ProPercProbExitoJustificativa => new(0, PTabelaNome, CampoCodigo, PercProbExitoJustificativa, 1024, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem ProHonorarioValor => new(0, PTabelaNome, CampoCodigo, HonorarioValor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProHonorarioPercentual => new(0, PTabelaNome, CampoCodigo, HonorarioPercentual, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProHonorarioSucumbencia => new(0, PTabelaNome, CampoCodigo, HonorarioSucumbencia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProFaseAuditoria => new(0, PTabelaNome, CampoCodigo, FaseAuditoria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem ProValorCondenacao => new(0, PTabelaNome, CampoCodigo, ValorCondenacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProValorCondenacaoCalculado => new(0, PTabelaNome, CampoCodigo, ValorCondenacaoCalculado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem ProValorCondenacaoProvisorio => new(0, PTabelaNome, CampoCodigo, ValorCondenacaoProvisorio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem ProGUID => new(0, PTabelaNome, CampoCodigo, GUID, 120, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem ProQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem ProQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem ProDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem ProVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string AdvParcDiff(int id) => AdvParc.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AdvParcSql(int id) => AdvParc.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AdvParcIsNull => AdvParc.SqlCmdIsNull() ?? string.Empty;
    public static string AdvParcNotIsNull => AdvParc.SqlCmdNotIsNull() ?? string.Empty;

    public static string AJGPedidoNegadoSql(bool valueCheck) => AJGPedidoNegado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AJGPedidoNegadoSqlSim => AJGPedidoNegado.SqlCmdBoolSim() ?? string.Empty;
    public static string AJGPedidoNegadoSqlNao => AJGPedidoNegado.SqlCmdBoolNao() ?? string.Empty;

    public static string AJGClienteSql(bool valueCheck) => AJGCliente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AJGClienteSqlSim => AJGCliente.SqlCmdBoolSim() ?? string.Empty;
    public static string AJGClienteSqlNao => AJGCliente.SqlCmdBoolNao() ?? string.Empty;

    public static string AJGPedidoNegadoOPOSql(bool valueCheck) => AJGPedidoNegadoOPO.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AJGPedidoNegadoOPOSqlSim => AJGPedidoNegadoOPO.SqlCmdBoolSim() ?? string.Empty;
    public static string AJGPedidoNegadoOPOSqlNao => AJGPedidoNegadoOPO.SqlCmdBoolNao() ?? string.Empty;

    public static string NotificarPOESql(bool valueCheck) => NotificarPOE.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string NotificarPOESqlSim => NotificarPOE.SqlCmdBoolSim() ?? string.Empty;
    public static string NotificarPOESqlNao => NotificarPOE.SqlCmdBoolNao() ?? string.Empty;

    public static string AJGOponenteSql(bool valueCheck) => AJGOponente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AJGOponenteSqlSim => AJGOponente.SqlCmdBoolSim() ?? string.Empty;
    public static string AJGOponenteSqlNao => AJGOponente.SqlCmdBoolNao() ?? string.Empty;

    public static string AJGPedidoOPOSql(bool valueCheck) => AJGPedidoOPO.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AJGPedidoOPOSqlSim => AJGPedidoOPO.SqlCmdBoolSim() ?? string.Empty;
    public static string AJGPedidoOPOSqlNao => AJGPedidoOPO.SqlCmdBoolNao() ?? string.Empty;

    public static string ConsiderarParadoSql(bool valueCheck) => ConsiderarParado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ConsiderarParadoSqlSim => ConsiderarParado.SqlCmdBoolSim() ?? string.Empty;
    public static string ConsiderarParadoSqlNao => ConsiderarParado.SqlCmdBoolNao() ?? string.Empty;

    public static string ValorCalculadoSql(bool valueCheck) => ValorCalculado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ValorCalculadoSqlSim => ValorCalculado.SqlCmdBoolSim() ?? string.Empty;
    public static string ValorCalculadoSqlNao => ValorCalculado.SqlCmdBoolNao() ?? string.Empty;

    public static string AJGConcedidoOPOSql(bool valueCheck) => AJGConcedidoOPO.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AJGConcedidoOPOSqlSim => AJGConcedidoOPO.SqlCmdBoolSim() ?? string.Empty;
    public static string AJGConcedidoOPOSqlNao => AJGConcedidoOPO.SqlCmdBoolNao() ?? string.Empty;

    public static string CobrancaSql(bool valueCheck) => Cobranca.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string CobrancaSqlSim => Cobranca.SqlCmdBoolSim() ?? string.Empty;
    public static string CobrancaSqlNao => Cobranca.SqlCmdBoolNao() ?? string.Empty;

    public static string DataEntradaSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataEntrada}]");
    public static string DataEntradaSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataEntrada}]");
    public static string DataEntradaSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataEntrada}]");
    public static string DataEntradaSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataEntrada}]");
    public static string DataEntradaSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataEntrada}]");
    public static string DataEntradaSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataEntrada}]");
    public static string DataEntradaSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataEntrada}]");
    public static string DataEntradaSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataEntrada}]");
    public static string DataEntradaSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataEntrada}]");
    public static string DataEntradaSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataEntrada}]");
    public static string DataEntradaSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataEntrada}]");
    public static string DataEntradaSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataEntrada}]");
    public static string DataEntradaIsNull => DataEntrada.SqlCmdIsNull() ?? string.Empty;
    public static string DataEntradaNotIsNull => DataEntrada.SqlCmdNotIsNull() ?? string.Empty;

    public static string PenhoraSql(bool valueCheck) => Penhora.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string PenhoraSqlSim => Penhora.SqlCmdBoolSim() ?? string.Empty;
    public static string PenhoraSqlNao => Penhora.SqlCmdBoolNao() ?? string.Empty;

    public static string AJGPedidoSql(bool valueCheck) => AJGPedido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AJGPedidoSqlSim => AJGPedido.SqlCmdBoolSim() ?? string.Empty;
    public static string AJGPedidoSqlNao => AJGPedido.SqlCmdBoolNao() ?? string.Empty;

    public static string TipoBaixaDiff(int id) => TipoBaixa.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string TipoBaixaSql(int id) => TipoBaixa.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string TipoBaixaIsNull => TipoBaixa.SqlCmdIsNull() ?? string.Empty;
    public static string TipoBaixaNotIsNull => TipoBaixa.SqlCmdNotIsNull() ?? string.Empty;

    public static string ClassRiscoDiff(int id) => ClassRisco.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClassRiscoSql(int id) => ClassRisco.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClassRiscoIsNull => ClassRisco.SqlCmdIsNull() ?? string.Empty;
    public static string ClassRiscoNotIsNull => ClassRisco.SqlCmdNotIsNull() ?? string.Empty;

    public static string IsApensoSql(bool valueCheck) => IsApenso.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IsApensoSqlSim => IsApenso.SqlCmdBoolSim() ?? string.Empty;
    public static string IsApensoSqlNao => IsApenso.SqlCmdBoolNao() ?? string.Empty;

    public static string AJGConcedidoSql(bool valueCheck) => AJGConcedido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AJGConcedidoSqlSim => AJGConcedido.SqlCmdBoolSim() ?? string.Empty;
    public static string AJGConcedidoSqlNao => AJGConcedido.SqlCmdBoolNao() ?? string.Empty;

    public static string ObsBCXSql(string text) => ObsBCX.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObsBCXSqlNotIsNull => ObsBCX.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObsBCXSqlIsNull => ObsBCX.SqlCmdIsNull() ?? string.Empty;

    public static string ObsBCXSqlDiff(string text) => ObsBCX.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObsBCXSqlLike(string text) => ObsBCX.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObsBCXSqlLikeInit(string text) => ObsBCX.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObsBCXSqlLikeSpaces(string? text) => ObsBCX.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string MNASql(bool valueCheck) => MNA.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string MNASqlSim => MNA.SqlCmdBoolSim() ?? string.Empty;
    public static string MNASqlNao => MNA.SqlCmdBoolNao() ?? string.Empty;

    public static string NroExtraSql(string text) => NroExtra.SqlCmdTextIgual(text, 35) ?? string.Empty;
    public static string NroExtraSqlNotIsNull => NroExtra.SqlCmdNotIsNull() ?? string.Empty;
    public static string NroExtraSqlIsNull => NroExtra.SqlCmdIsNull() ?? string.Empty;

    public static string NroExtraSqlDiff(string text) => NroExtra.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NroExtraSqlLike(string text) => NroExtra.SqlCmdTextLike(text) ?? string.Empty;
    public static string NroExtraSqlLikeInit(string text) => NroExtra.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NroExtraSqlLikeSpaces(string? text) => NroExtra.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AdvOpoDiff(int id) => AdvOpo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AdvOpoSql(int id) => AdvOpo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AdvOpoIsNull => AdvOpo.SqlCmdIsNull() ?? string.Empty;
    public static string AdvOpoNotIsNull => AdvOpo.SqlCmdNotIsNull() ?? string.Empty;

    public static string ExtraSql(bool valueCheck) => Extra.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ExtraSqlSim => Extra.SqlCmdBoolSim() ?? string.Empty;
    public static string ExtraSqlNao => Extra.SqlCmdBoolNao() ?? string.Empty;

    public static string JusticaDiff(int id) => Justica.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string JusticaSql(int id) => Justica.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string JusticaIsNull => Justica.SqlCmdIsNull() ?? string.Empty;
    public static string JusticaNotIsNull => Justica.SqlCmdNotIsNull() ?? string.Empty;

    public static string AdvogadoDiff(int id) => Advogado.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AdvogadoSql(int id) => Advogado.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AdvogadoIsNull => Advogado.SqlCmdIsNull() ?? string.Empty;
    public static string AdvogadoNotIsNull => Advogado.SqlCmdNotIsNull() ?? string.Empty;

    public static string NroCaixaSql(string text) => NroCaixa.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string NroCaixaSqlNotIsNull => NroCaixa.SqlCmdNotIsNull() ?? string.Empty;
    public static string NroCaixaSqlIsNull => NroCaixa.SqlCmdIsNull() ?? string.Empty;

    public static string NroCaixaSqlDiff(string text) => NroCaixa.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NroCaixaSqlLike(string text) => NroCaixa.SqlCmdTextLike(text) ?? string.Empty;
    public static string NroCaixaSqlLikeInit(string text) => NroCaixa.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NroCaixaSqlLikeSpaces(string? text) => NroCaixa.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PrepostoDiff(int id) => Preposto.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string PrepostoSql(int id) => Preposto.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string PrepostoIsNull => Preposto.SqlCmdIsNull() ?? string.Empty;
    public static string PrepostoNotIsNull => Preposto.SqlCmdNotIsNull() ?? string.Empty;

    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

    public static string OponenteDiff(int id) => Oponente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string OponenteSql(int id) => Oponente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string OponenteIsNull => Oponente.SqlCmdIsNull() ?? string.Empty;
    public static string OponenteNotIsNull => Oponente.SqlCmdNotIsNull() ?? string.Empty;

    public static string AreaDiff(int id) => Area.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AreaSql(int id) => Area.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AreaIsNull => Area.SqlCmdIsNull() ?? string.Empty;
    public static string AreaNotIsNull => Area.SqlCmdNotIsNull() ?? string.Empty;

    public static string CidadeDiff(int id) => Cidade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CidadeSql(int id) => Cidade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CidadeIsNull => Cidade.SqlCmdIsNull() ?? string.Empty;
    public static string CidadeNotIsNull => Cidade.SqlCmdNotIsNull() ?? string.Empty;

    public static string SituacaoDiff(int id) => Situacao.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string SituacaoSql(int id) => Situacao.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string SituacaoIsNull => Situacao.SqlCmdIsNull() ?? string.Empty;
    public static string SituacaoNotIsNull => Situacao.SqlCmdNotIsNull() ?? string.Empty;

    public static string IDSituacaoSql(bool valueCheck) => IDSituacao.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IDSituacaoSqlSim => IDSituacao.SqlCmdBoolSim() ?? string.Empty;
    public static string IDSituacaoSqlNao => IDSituacao.SqlCmdBoolNao() ?? string.Empty;

    public static string RitoDiff(int id) => Rito.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string RitoSql(int id) => Rito.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string RitoIsNull => Rito.SqlCmdIsNull() ?? string.Empty;
    public static string RitoNotIsNull => Rito.SqlCmdNotIsNull() ?? string.Empty;

    public static string FatoSql(string text) => Fato.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FatoSqlNotIsNull => Fato.SqlCmdNotIsNull() ?? string.Empty;
    public static string FatoSqlIsNull => Fato.SqlCmdIsNull() ?? string.Empty;

    public static string FatoSqlDiff(string text) => Fato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FatoSqlLike(string text) => Fato.SqlCmdTextLike(text) ?? string.Empty;
    public static string FatoSqlLikeInit(string text) => Fato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FatoSqlLikeSpaces(string? text) => Fato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NroPastaSql(string text) => NroPasta.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string NroPastaSqlNotIsNull => NroPasta.SqlCmdNotIsNull() ?? string.Empty;
    public static string NroPastaSqlIsNull => NroPasta.SqlCmdIsNull() ?? string.Empty;

    public static string NroPastaSqlDiff(string text) => NroPasta.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NroPastaSqlLike(string text) => NroPasta.SqlCmdTextLike(text) ?? string.Empty;
    public static string NroPastaSqlLikeInit(string text) => NroPasta.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NroPastaSqlLikeSpaces(string? text) => NroPasta.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AtividadeDiff(int id) => Atividade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AtividadeSql(int id) => Atividade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AtividadeIsNull => Atividade.SqlCmdIsNull() ?? string.Empty;
    public static string AtividadeNotIsNull => Atividade.SqlCmdNotIsNull() ?? string.Empty;

    public static string CaixaMortoSql(string text) => CaixaMorto.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CaixaMortoSqlNotIsNull => CaixaMorto.SqlCmdNotIsNull() ?? string.Empty;
    public static string CaixaMortoSqlIsNull => CaixaMorto.SqlCmdIsNull() ?? string.Empty;

    public static string CaixaMortoSqlDiff(string text) => CaixaMorto.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CaixaMortoSqlLike(string text) => CaixaMorto.SqlCmdTextLike(text) ?? string.Empty;
    public static string CaixaMortoSqlLikeInit(string text) => CaixaMorto.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CaixaMortoSqlLikeSpaces(string? text) => CaixaMorto.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string BaixadoSql(bool valueCheck) => Baixado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BaixadoSqlSim => Baixado.SqlCmdBoolSim() ?? string.Empty;
    public static string BaixadoSqlNao => Baixado.SqlCmdBoolNao() ?? string.Empty;

    public static string DtBaixaSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtBaixa}]");
    public static string DtBaixaSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtBaixa}]");
    public static string DtBaixaSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtBaixa}]");
    public static string DtBaixaSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtBaixa}]");
    public static string DtBaixaSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtBaixa}]");
    public static string DtBaixaSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtBaixa}]");
    public static string DtBaixaSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtBaixa}]");
    public static string DtBaixaSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtBaixa}]");
    public static string DtBaixaSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtBaixa}]");
    public static string DtBaixaSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtBaixa}]");
    public static string DtBaixaSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtBaixa}]");
    public static string DtBaixaSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtBaixa}]");
    public static string DtBaixaIsNull => DtBaixa.SqlCmdIsNull() ?? string.Empty;
    public static string DtBaixaNotIsNull => DtBaixa.SqlCmdNotIsNull() ?? string.Empty;

    public static string MotivoBaixaSql(string text) => MotivoBaixa.SqlCmdTextIgual(text) ?? string.Empty;
    public static string MotivoBaixaSqlNotIsNull => MotivoBaixa.SqlCmdNotIsNull() ?? string.Empty;
    public static string MotivoBaixaSqlIsNull => MotivoBaixa.SqlCmdIsNull() ?? string.Empty;

    public static string MotivoBaixaSqlDiff(string text) => MotivoBaixa.SqlCmdTextDiff(text) ?? string.Empty;
    public static string MotivoBaixaSqlLike(string text) => MotivoBaixa.SqlCmdTextLike(text) ?? string.Empty;
    public static string MotivoBaixaSqlLikeInit(string text) => MotivoBaixa.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string MotivoBaixaSqlLikeSpaces(string? text) => MotivoBaixa.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OBSSql(string text) => OBS.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OBSSqlNotIsNull => OBS.SqlCmdNotIsNull() ?? string.Empty;
    public static string OBSSqlIsNull => OBS.SqlCmdIsNull() ?? string.Empty;

    public static string OBSSqlDiff(string text) => OBS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OBSSqlLike(string text) => OBS.SqlCmdTextLike(text) ?? string.Empty;
    public static string OBSSqlLikeInit(string text) => OBS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OBSSqlLikeSpaces(string? text) => OBS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PrintedSql(bool valueCheck) => Printed.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string PrintedSqlSim => Printed.SqlCmdBoolSim() ?? string.Empty;
    public static string PrintedSqlNao => Printed.SqlCmdBoolNao() ?? string.Empty;

    public static string ZKeySql(string text) => ZKey.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string ZKeySqlNotIsNull => ZKey.SqlCmdNotIsNull() ?? string.Empty;
    public static string ZKeySqlIsNull => ZKey.SqlCmdIsNull() ?? string.Empty;

    public static string ZKeySqlDiff(string text) => ZKey.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ZKeySqlLike(string text) => ZKey.SqlCmdTextLike(text) ?? string.Empty;
    public static string ZKeySqlLikeInit(string text) => ZKey.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ZKeySqlLikeSpaces(string? text) => ZKey.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ZKeyQuemDiff(int id) => ZKeyQuem.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ZKeyQuemSql(int id) => ZKeyQuem.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ZKeyQuemIsNull => ZKeyQuem.SqlCmdIsNull() ?? string.Empty;
    public static string ZKeyQuemNotIsNull => ZKeyQuem.SqlCmdNotIsNull() ?? string.Empty;

    public static string ZKeyQuandoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoIsNull => ZKeyQuando.SqlCmdIsNull() ?? string.Empty;
    public static string ZKeyQuandoNotIsNull => ZKeyQuando.SqlCmdNotIsNull() ?? string.Empty;

    public static string ResumoSql(string text) => Resumo.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ResumoSqlNotIsNull => Resumo.SqlCmdNotIsNull() ?? string.Empty;
    public static string ResumoSqlIsNull => Resumo.SqlCmdIsNull() ?? string.Empty;

    public static string ResumoSqlDiff(string text) => Resumo.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ResumoSqlLike(string text) => Resumo.SqlCmdTextLike(text) ?? string.Empty;
    public static string ResumoSqlLikeInit(string text) => Resumo.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ResumoSqlLikeSpaces(string? text) => Resumo.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NaoImprimirSql(bool valueCheck) => NaoImprimir.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string NaoImprimirSqlSim => NaoImprimir.SqlCmdBoolSim() ?? string.Empty;
    public static string NaoImprimirSqlNao => NaoImprimir.SqlCmdBoolNao() ?? string.Empty;

    public static string EletronicoSql(bool valueCheck) => Eletronico.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string EletronicoSqlSim => Eletronico.SqlCmdBoolSim() ?? string.Empty;
    public static string EletronicoSqlNao => Eletronico.SqlCmdBoolNao() ?? string.Empty;

    public static string NroContratoSql(string text) => NroContrato.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string NroContratoSqlNotIsNull => NroContrato.SqlCmdNotIsNull() ?? string.Empty;
    public static string NroContratoSqlIsNull => NroContrato.SqlCmdIsNull() ?? string.Empty;

    public static string NroContratoSqlDiff(string text) => NroContrato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NroContratoSqlLike(string text) => NroContrato.SqlCmdTextLike(text) ?? string.Empty;
    public static string NroContratoSqlLikeInit(string text) => NroContrato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NroContratoSqlLikeSpaces(string? text) => NroContrato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PercProbExitoJustificativaSql(string text) => PercProbExitoJustificativa.SqlCmdTextIgual(text, 1024) ?? string.Empty;
    public static string PercProbExitoJustificativaSqlNotIsNull => PercProbExitoJustificativa.SqlCmdNotIsNull() ?? string.Empty;
    public static string PercProbExitoJustificativaSqlIsNull => PercProbExitoJustificativa.SqlCmdIsNull() ?? string.Empty;

    public static string PercProbExitoJustificativaSqlDiff(string text) => PercProbExitoJustificativa.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PercProbExitoJustificativaSqlLike(string text) => PercProbExitoJustificativa.SqlCmdTextLike(text) ?? string.Empty;
    public static string PercProbExitoJustificativaSqlLikeInit(string text) => PercProbExitoJustificativa.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PercProbExitoJustificativaSqlLikeSpaces(string? text) => PercProbExitoJustificativa.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FaseAuditoriaDiff(int id) => FaseAuditoria.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string FaseAuditoriaSql(int id) => FaseAuditoria.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string FaseAuditoriaIsNull => FaseAuditoria.SqlCmdIsNull() ?? string.Empty;
    public static string FaseAuditoriaNotIsNull => FaseAuditoria.SqlCmdNotIsNull() ?? string.Empty;

    public static string ValorCondenacaoProvisorioDiff(int id) => ValorCondenacaoProvisorio.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ValorCondenacaoProvisorioSql(int id) => ValorCondenacaoProvisorio.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ValorCondenacaoProvisorioIsNull => ValorCondenacaoProvisorio.SqlCmdIsNull() ?? string.Empty;
    public static string ValorCondenacaoProvisorioNotIsNull => ValorCondenacaoProvisorio.SqlCmdNotIsNull() ?? string.Empty;

    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 120) ?? string.Empty;
    public static string QuemCadDiff(int id) => QuemCad.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemCadSql(int id) => QuemCad.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemCadIsNull => QuemCad.SqlCmdIsNull() ?? string.Empty;
    public static string QuemCadNotIsNull => QuemCad.SqlCmdNotIsNull() ?? string.Empty;

    public static string DtCadSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtCad}]");
    public static string DtCadSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtCad}]");
    public static string DtCadSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtCad}]");
    public static string DtCadSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtCad}]");
    public static string DtCadIsNull => DtCad.SqlCmdIsNull() ?? string.Empty;
    public static string DtCadNotIsNull => DtCad.SqlCmdNotIsNull() ?? string.Empty;

    public static string QuemAtuDiff(int id) => QuemAtu.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemAtuSql(int id) => QuemAtu.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemAtuIsNull => QuemAtu.SqlCmdIsNull() ?? string.Empty;
    public static string QuemAtuNotIsNull => QuemAtu.SqlCmdNotIsNull() ?? string.Empty;

    public static string DtAtuSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtAtu}]");
    public static string DtAtuSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtAtu}]");
    public static string DtAtuSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtAtu}]");
    public static string DtAtuIsNull => DtAtu.SqlCmdIsNull() ?? string.Empty;
    public static string DtAtuNotIsNull => DtAtu.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        ProAdvParc = 1,
        ProAJGPedidoNegado = 2,
        ProAJGCliente = 3,
        ProAJGPedidoNegadoOPO = 4,
        ProNotificarPOE = 5,
        ProValorProvisionado = 6,
        ProAJGOponente = 7,
        ProValorCacheCalculo = 8,
        ProAJGPedidoOPO = 9,
        ProValorCacheCalculoProv = 10,
        ProConsiderarParado = 11,
        ProValorCalculado = 12,
        ProAJGConcedidoOPO = 13,
        ProCobranca = 14,
        ProDataEntrada = 15,
        ProPenhora = 16,
        ProAJGPedido = 17,
        ProTipoBaixa = 18,
        ProClassRisco = 19,
        ProIsApenso = 20,
        ProValorCausaInicial = 21,
        ProAJGConcedido = 22,
        ProObsBCX = 23,
        ProValorCausaDefinitivo = 24,
        ProPercProbExito = 25,
        ProMNA = 26,
        ProPercExito = 27,
        ProNroExtra = 28,
        ProAdvOpo = 29,
        ProExtra = 30,
        ProJustica = 31,
        ProAdvogado = 32,
        ProNroCaixa = 33,
        ProPreposto = 34,
        ProCliente = 35,
        ProOponente = 36,
        ProArea = 37,
        ProCidade = 38,
        ProSituacao = 39,
        ProIDSituacao = 40,
        ProValor = 41,
        ProRito = 42,
        ProFato = 43,
        ProNroPasta = 44,
        ProAtividade = 45,
        ProCaixaMorto = 46,
        ProBaixado = 47,
        ProDtBaixa = 48,
        ProMotivoBaixa = 49,
        ProOBS = 50,
        ProPrinted = 51,
        ProZKey = 52,
        ProZKeyQuem = 53,
        ProZKeyQuando = 54,
        ProResumo = 55,
        ProNaoImprimir = 56,
        ProEletronico = 57,
        ProNroContrato = 58,
        ProPercProbExitoJustificativa = 59,
        ProHonorarioValor = 60,
        ProHonorarioPercentual = 61,
        ProHonorarioSucumbencia = 62,
        ProFaseAuditoria = 63,
        ProValorCondenacao = 64,
        ProValorCondenacaoCalculado = 65,
        ProValorCondenacaoProvisorio = 66,
        ProGUID = 67,
        ProQuemCad = 68,
        ProDtCad = 69,
        ProQuemAtu = 70,
        ProDtAtu = 71,
        ProVisto = 72
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.ProAdvParc => ProAdvParc,
        NomesCamposTabela.ProAJGPedidoNegado => ProAJGPedidoNegado,
        NomesCamposTabela.ProAJGCliente => ProAJGCliente,
        NomesCamposTabela.ProAJGPedidoNegadoOPO => ProAJGPedidoNegadoOPO,
        NomesCamposTabela.ProNotificarPOE => ProNotificarPOE,
        NomesCamposTabela.ProValorProvisionado => ProValorProvisionado,
        NomesCamposTabela.ProAJGOponente => ProAJGOponente,
        NomesCamposTabela.ProValorCacheCalculo => ProValorCacheCalculo,
        NomesCamposTabela.ProAJGPedidoOPO => ProAJGPedidoOPO,
        NomesCamposTabela.ProValorCacheCalculoProv => ProValorCacheCalculoProv,
        NomesCamposTabela.ProConsiderarParado => ProConsiderarParado,
        NomesCamposTabela.ProValorCalculado => ProValorCalculado,
        NomesCamposTabela.ProAJGConcedidoOPO => ProAJGConcedidoOPO,
        NomesCamposTabela.ProCobranca => ProCobranca,
        NomesCamposTabela.ProDataEntrada => ProDataEntrada,
        NomesCamposTabela.ProPenhora => ProPenhora,
        NomesCamposTabela.ProAJGPedido => ProAJGPedido,
        NomesCamposTabela.ProTipoBaixa => ProTipoBaixa,
        NomesCamposTabela.ProClassRisco => ProClassRisco,
        NomesCamposTabela.ProIsApenso => ProIsApenso,
        NomesCamposTabela.ProValorCausaInicial => ProValorCausaInicial,
        NomesCamposTabela.ProAJGConcedido => ProAJGConcedido,
        NomesCamposTabela.ProObsBCX => ProObsBCX,
        NomesCamposTabela.ProValorCausaDefinitivo => ProValorCausaDefinitivo,
        NomesCamposTabela.ProPercProbExito => ProPercProbExito,
        NomesCamposTabela.ProMNA => ProMNA,
        NomesCamposTabela.ProPercExito => ProPercExito,
        NomesCamposTabela.ProNroExtra => ProNroExtra,
        NomesCamposTabela.ProAdvOpo => ProAdvOpo,
        NomesCamposTabela.ProExtra => ProExtra,
        NomesCamposTabela.ProJustica => ProJustica,
        NomesCamposTabela.ProAdvogado => ProAdvogado,
        NomesCamposTabela.ProNroCaixa => ProNroCaixa,
        NomesCamposTabela.ProPreposto => ProPreposto,
        NomesCamposTabela.ProCliente => ProCliente,
        NomesCamposTabela.ProOponente => ProOponente,
        NomesCamposTabela.ProArea => ProArea,
        NomesCamposTabela.ProCidade => ProCidade,
        NomesCamposTabela.ProSituacao => ProSituacao,
        NomesCamposTabela.ProIDSituacao => ProIDSituacao,
        NomesCamposTabela.ProValor => ProValor,
        NomesCamposTabela.ProRito => ProRito,
        NomesCamposTabela.ProFato => ProFato,
        NomesCamposTabela.ProNroPasta => ProNroPasta,
        NomesCamposTabela.ProAtividade => ProAtividade,
        NomesCamposTabela.ProCaixaMorto => ProCaixaMorto,
        NomesCamposTabela.ProBaixado => ProBaixado,
        NomesCamposTabela.ProDtBaixa => ProDtBaixa,
        NomesCamposTabela.ProMotivoBaixa => ProMotivoBaixa,
        NomesCamposTabela.ProOBS => ProOBS,
        NomesCamposTabela.ProPrinted => ProPrinted,
        NomesCamposTabela.ProZKey => ProZKey,
        NomesCamposTabela.ProZKeyQuem => ProZKeyQuem,
        NomesCamposTabela.ProZKeyQuando => ProZKeyQuando,
        NomesCamposTabela.ProResumo => ProResumo,
        NomesCamposTabela.ProNaoImprimir => ProNaoImprimir,
        NomesCamposTabela.ProEletronico => ProEletronico,
        NomesCamposTabela.ProNroContrato => ProNroContrato,
        NomesCamposTabela.ProPercProbExitoJustificativa => ProPercProbExitoJustificativa,
        NomesCamposTabela.ProHonorarioValor => ProHonorarioValor,
        NomesCamposTabela.ProHonorarioPercentual => ProHonorarioPercentual,
        NomesCamposTabela.ProHonorarioSucumbencia => ProHonorarioSucumbencia,
        NomesCamposTabela.ProFaseAuditoria => ProFaseAuditoria,
        NomesCamposTabela.ProValorCondenacao => ProValorCondenacao,
        NomesCamposTabela.ProValorCondenacaoCalculado => ProValorCondenacaoCalculado,
        NomesCamposTabela.ProValorCondenacaoProvisorio => ProValorCondenacaoProvisorio,
        NomesCamposTabela.ProGUID => ProGUID,
        NomesCamposTabela.ProQuemCad => ProQuemCad,
        NomesCamposTabela.ProDtCad => ProDtCad,
        NomesCamposTabela.ProQuemAtu => ProQuemAtu,
        NomesCamposTabela.ProDtAtu => ProDtAtu,
        NomesCamposTabela.ProVisto => ProVisto,
        _ => null
    };
}