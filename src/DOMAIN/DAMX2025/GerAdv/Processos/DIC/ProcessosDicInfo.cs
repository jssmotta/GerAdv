using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
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
    public static DBInfoSystem ProAdvParc => new(0, PTabelaNome, CampoCodigo, AdvParc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAJGPedidoNegado => new(0, PTabelaNome, CampoCodigo, AJGPedidoNegado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAJGCliente => new(0, PTabelaNome, CampoCodigo, AJGCliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAJGPedidoNegadoOPO => new(0, PTabelaNome, CampoCodigo, AJGPedidoNegadoOPO, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProNotificarPOE => new(0, PTabelaNome, CampoCodigo, NotificarPOE, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValorProvisionado => new(0, PTabelaNome, CampoCodigo, ValorProvisionado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAJGOponente => new(0, PTabelaNome, CampoCodigo, AJGOponente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValorCacheCalculo => new(0, PTabelaNome, CampoCodigo, ValorCacheCalculo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAJGPedidoOPO => new(0, PTabelaNome, CampoCodigo, AJGPedidoOPO, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValorCacheCalculoProv => new(0, PTabelaNome, CampoCodigo, ValorCacheCalculoProv, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProConsiderarParado => new(0, PTabelaNome, CampoCodigo, ConsiderarParado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValorCalculado => new(0, PTabelaNome, CampoCodigo, ValorCalculado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAJGConcedidoOPO => new(0, PTabelaNome, CampoCodigo, AJGConcedidoOPO, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProCobranca => new(0, PTabelaNome, CampoCodigo, Cobranca, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProDataEntrada => new(0, PTabelaNome, CampoCodigo, DataEntrada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProPenhora => new(0, PTabelaNome, CampoCodigo, Penhora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAJGPedido => new(0, PTabelaNome, CampoCodigo, AJGPedido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProTipoBaixa => new(0, PTabelaNome, CampoCodigo, TipoBaixa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProClassRisco => new(0, PTabelaNome, CampoCodigo, ClassRisco, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProIsApenso => new(0, PTabelaNome, CampoCodigo, IsApenso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValorCausaInicial => new(0, PTabelaNome, CampoCodigo, ValorCausaInicial, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAJGConcedido => new(0, PTabelaNome, CampoCodigo, AJGConcedido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProObsBCX => new(0, PTabelaNome, CampoCodigo, ObsBCX, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValorCausaDefinitivo => new(0, PTabelaNome, CampoCodigo, ValorCausaDefinitivo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProPercProbExito => new(0, PTabelaNome, CampoCodigo, PercProbExito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProMNA => new(0, PTabelaNome, CampoCodigo, MNA, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProPercExito => new(0, PTabelaNome, CampoCodigo, PercExito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProNroExtra => new(0, PTabelaNome, CampoCodigo, NroExtra, 35, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAdvOpo => new(0, PTabelaNome, CampoCodigo, AdvOpo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProExtra => new(0, PTabelaNome, CampoCodigo, Extra, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProNroCaixa => new(0, PTabelaNome, CampoCodigo, NroCaixa, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProPreposto => new(0, PTabelaNome, CampoCodigo, Preposto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPrepostosDicInfo.CampoCodigo, DBPrepostosDicInfo.TabelaNome, new DBPrepostosODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProOponente => new(0, PTabelaNome, CampoCodigo, Oponente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOponentesDicInfo.CampoCodigo, DBOponentesDicInfo.TabelaNome, new DBOponentesODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProSituacao => new(0, PTabelaNome, CampoCodigo, Situacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBSituacaoDicInfo.CampoCodigo, DBSituacaoDicInfo.TabelaNome, new DBSituacaoODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProIDSituacao => new(0, PTabelaNome, CampoCodigo, IDSituacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProRito => new(0, PTabelaNome, CampoCodigo, Rito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBRitoDicInfo.CampoCodigo, DBRitoDicInfo.TabelaNome, new DBRitoODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProFato => new(0, PTabelaNome, CampoCodigo, Fato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProNroPasta => new(0, PTabelaNome, CampoCodigo, NroPasta, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProAtividade => new(0, PTabelaNome, CampoCodigo, Atividade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAtividadesDicInfo.CampoCodigo, DBAtividadesDicInfo.TabelaNome, new DBAtividadesODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProCaixaMorto => new(0, PTabelaNome, CampoCodigo, CaixaMorto, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProBaixado => new(0, PTabelaNome, CampoCodigo, Baixado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProDtBaixa => new(0, PTabelaNome, CampoCodigo, DtBaixa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProMotivoBaixa => new(0, PTabelaNome, CampoCodigo, MotivoBaixa, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProPrinted => new(0, PTabelaNome, CampoCodigo, Printed, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProZKey => new(0, PTabelaNome, CampoCodigo, ZKey, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProZKeyQuem => new(0, PTabelaNome, CampoCodigo, ZKeyQuem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProZKeyQuando => new(0, PTabelaNome, CampoCodigo, ZKeyQuando, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProResumo => new(0, PTabelaNome, CampoCodigo, Resumo, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProNaoImprimir => new(0, PTabelaNome, CampoCodigo, NaoImprimir, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pro"
    };
    public static DBInfoSystem ProEletronico => new(0, PTabelaNome, CampoCodigo, Eletronico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProNroContrato => new(0, PTabelaNome, CampoCodigo, NroContrato, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProPercProbExitoJustificativa => new(0, PTabelaNome, CampoCodigo, PercProbExitoJustificativa, 1024, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProHonorarioValor => new(0, PTabelaNome, CampoCodigo, HonorarioValor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProHonorarioPercentual => new(0, PTabelaNome, CampoCodigo, HonorarioPercentual, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProHonorarioSucumbencia => new(0, PTabelaNome, CampoCodigo, HonorarioSucumbencia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProFaseAuditoria => new(0, PTabelaNome, CampoCodigo, FaseAuditoria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValorCondenacao => new(0, PTabelaNome, CampoCodigo, ValorCondenacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValorCondenacaoCalculado => new(0, PTabelaNome, CampoCodigo, ValorCondenacaoCalculado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProValorCondenacaoProvisorio => new(0, PTabelaNome, CampoCodigo, ValorCondenacaoProvisorio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProGUID => new(0, PTabelaNome, CampoCodigo, GUID, 120, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pro"
    }; // DBI 11 
    public static DBInfoSystem ProDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "pro"
    };
    public static DBInfoSystem ProVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "pro"
    };

#endregion
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