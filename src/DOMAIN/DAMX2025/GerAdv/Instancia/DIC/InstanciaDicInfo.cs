using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBInstanciaDicInfo
{
    public const string CampoCodigo = "insCodigo";
    public const string CampoNome = "insNroProcesso";
    public const string TablePrefix = "ins";
    public const string LiminarPedida = "insLiminarPedida"; // LOCALIZACAO 170523
    public const string Objeto = "insObjeto"; // LOCALIZACAO 170523
    public const string StatusResultado = "insStatusResultado"; // LOCALIZACAO 170523
    public const string LiminarPendente = "insLiminarPendente"; // LOCALIZACAO 170523
    public const string InterpusemosRecurso = "insInterpusemosRecurso"; // LOCALIZACAO 170523
    public const string LiminarConcedida = "insLiminarConcedida"; // LOCALIZACAO 170523
    public const string LiminarNegada = "insLiminarNegada"; // LOCALIZACAO 170523
    public const string Processo = "insProcesso"; // LOCALIZACAO 170523
    public const string Data = "insData"; // LOCALIZACAO 170523
    public const string LiminarParcial = "insLiminarParcial"; // LOCALIZACAO 170523
    public const string LiminarResultado = "insLiminarResultado"; // LOCALIZACAO 170523
    public const string NroProcesso = "insNroProcesso"; // LOCALIZACAO 170523
    public const string Divisao = "insDivisao"; // LOCALIZACAO 170523
    public const string LiminarCliente = "insLiminarCliente"; // LOCALIZACAO 170523
    public const string Comarca = "insComarca"; // LOCALIZACAO 170523
    public const string SubDivisao = "insSubDivisao"; // LOCALIZACAO 170523
    public const string Principal = "insPrincipal"; // LOCALIZACAO 170523
    public const string Acao = "insAcao"; // LOCALIZACAO 170523
    public const string Foro = "insForo"; // LOCALIZACAO 170523
    public const string TipoRecurso = "insTipoRecurso"; // LOCALIZACAO 170523
    public const string ZKey = "insZKey"; // LOCALIZACAO 170523
    public const string ZKeyQuem = "insZKeyQuem"; // LOCALIZACAO 170523
    public const string ZKeyQuando = "insZKeyQuando"; // LOCALIZACAO 170523
    public const string NroAntigo = "insNroAntigo"; // LOCALIZACAO 170523
    public const string AccessCode = "insAccessCode"; // LOCALIZACAO 170523
    public const string Julgador = "insJulgador"; // LOCALIZACAO 170523
    public const string ZKeyIA = "insZKeyIA"; // LOCALIZACAO 170523
    public const string GUID = "insGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "insQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "insDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "insQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "insDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "insVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => LiminarPedida,
        2 => Objeto,
        3 => StatusResultado,
        4 => LiminarPendente,
        5 => InterpusemosRecurso,
        6 => LiminarConcedida,
        7 => LiminarNegada,
        8 => Processo,
        9 => Data,
        10 => LiminarParcial,
        11 => LiminarResultado,
        12 => NroProcesso,
        13 => Divisao,
        14 => LiminarCliente,
        15 => Comarca,
        16 => SubDivisao,
        17 => Principal,
        18 => Acao,
        19 => Foro,
        20 => TipoRecurso,
        21 => ZKey,
        22 => ZKeyQuem,
        23 => ZKeyQuando,
        24 => NroAntigo,
        25 => AccessCode,
        26 => Julgador,
        27 => ZKeyIA,
        28 => GUID,
        29 => QuemCad,
        30 => DtCad,
        31 => QuemAtu,
        32 => DtAtu,
        33 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Instancia";
#region PropriedadesDaTabela
    public static DBInfoSystem InsLiminarPedida => new(0, PTabelaNome, CampoCodigo, LiminarPedida, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsObjeto => new(0, PTabelaNome, CampoCodigo, Objeto, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsStatusResultado => new(0, PTabelaNome, CampoCodigo, StatusResultado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsLiminarPendente => new(0, PTabelaNome, CampoCodigo, LiminarPendente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ins"
    };
    public static DBInfoSystem InsInterpusemosRecurso => new(0, PTabelaNome, CampoCodigo, InterpusemosRecurso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ins"
    };
    public static DBInfoSystem InsLiminarConcedida => new(0, PTabelaNome, CampoCodigo, LiminarConcedida, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ins"
    };
    public static DBInfoSystem InsLiminarNegada => new(0, PTabelaNome, CampoCodigo, LiminarNegada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ins"
    };
    public static DBInfoSystem InsProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "ins"
    }; // DBI 11 
    public static DBInfoSystem InsData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsLiminarParcial => new(0, PTabelaNome, CampoCodigo, LiminarParcial, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ins"
    };
    public static DBInfoSystem InsLiminarResultado => new(0, PTabelaNome, CampoCodigo, LiminarResultado, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsNroProcesso => new(0, PTabelaNome, CampoCodigo, NroProcesso, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsDivisao => new(0, PTabelaNome, CampoCodigo, Divisao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsLiminarCliente => new(0, PTabelaNome, CampoCodigo, LiminarCliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ins"
    };
    public static DBInfoSystem InsComarca => new(0, PTabelaNome, CampoCodigo, Comarca, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsSubDivisao => new(0, PTabelaNome, CampoCodigo, SubDivisao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsPrincipal => new(0, PTabelaNome, CampoCodigo, Principal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ins"
    };
    public static DBInfoSystem InsAcao => new(0, PTabelaNome, CampoCodigo, Acao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAcaoDicInfo.CampoCodigo, DBAcaoDicInfo.TabelaNome, new DBAcaoODicInfo(), false)
    {
        Prefixo = "ins"
    }; // DBI 11 
    public static DBInfoSystem InsForo => new(0, PTabelaNome, CampoCodigo, Foro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBForoDicInfo.CampoCodigo, DBForoDicInfo.TabelaNome, new DBForoODicInfo(), false)
    {
        Prefixo = "ins"
    }; // DBI 11 
    public static DBInfoSystem InsTipoRecurso => new(0, PTabelaNome, CampoCodigo, TipoRecurso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoRecursoDicInfo.CampoCodigo, DBTipoRecursoDicInfo.TabelaNome, new DBTipoRecursoODicInfo(), false)
    {
        Prefixo = "ins"
    }; // DBI 11 
    public static DBInfoSystem InsZKey => new(0, PTabelaNome, CampoCodigo, ZKey, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsZKeyQuem => new(0, PTabelaNome, CampoCodigo, ZKeyQuem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsZKeyQuando => new(0, PTabelaNome, CampoCodigo, ZKeyQuando, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsNroAntigo => new(0, PTabelaNome, CampoCodigo, NroAntigo, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsAccessCode => new(0, PTabelaNome, CampoCodigo, AccessCode, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsJulgador => new(0, PTabelaNome, CampoCodigo, Julgador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsZKeyIA => new(0, PTabelaNome, CampoCodigo, ZKeyIA, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ins"
    }; // DBI 11 
    public static DBInfoSystem InsDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ins"
    }; // DBI 11 
    public static DBInfoSystem InsDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ins"
    };
    public static DBInfoSystem InsVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ins"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        InsLiminarPedida = 1,
        InsObjeto = 2,
        InsStatusResultado = 3,
        InsLiminarPendente = 4,
        InsInterpusemosRecurso = 5,
        InsLiminarConcedida = 6,
        InsLiminarNegada = 7,
        InsProcesso = 8,
        InsData = 9,
        InsLiminarParcial = 10,
        InsLiminarResultado = 11,
        InsNroProcesso = 12,
        InsDivisao = 13,
        InsLiminarCliente = 14,
        InsComarca = 15,
        InsSubDivisao = 16,
        InsPrincipal = 17,
        InsAcao = 18,
        InsForo = 19,
        InsTipoRecurso = 20,
        InsZKey = 21,
        InsZKeyQuem = 22,
        InsZKeyQuando = 23,
        InsNroAntigo = 24,
        InsAccessCode = 25,
        InsJulgador = 26,
        InsZKeyIA = 27,
        InsGUID = 28,
        InsQuemCad = 29,
        InsDtCad = 30,
        InsQuemAtu = 31,
        InsDtAtu = 32,
        InsVisto = 33
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.InsLiminarPedida => InsLiminarPedida,
        NomesCamposTabela.InsObjeto => InsObjeto,
        NomesCamposTabela.InsStatusResultado => InsStatusResultado,
        NomesCamposTabela.InsLiminarPendente => InsLiminarPendente,
        NomesCamposTabela.InsInterpusemosRecurso => InsInterpusemosRecurso,
        NomesCamposTabela.InsLiminarConcedida => InsLiminarConcedida,
        NomesCamposTabela.InsLiminarNegada => InsLiminarNegada,
        NomesCamposTabela.InsProcesso => InsProcesso,
        NomesCamposTabela.InsData => InsData,
        NomesCamposTabela.InsLiminarParcial => InsLiminarParcial,
        NomesCamposTabela.InsLiminarResultado => InsLiminarResultado,
        NomesCamposTabela.InsNroProcesso => InsNroProcesso,
        NomesCamposTabela.InsDivisao => InsDivisao,
        NomesCamposTabela.InsLiminarCliente => InsLiminarCliente,
        NomesCamposTabela.InsComarca => InsComarca,
        NomesCamposTabela.InsSubDivisao => InsSubDivisao,
        NomesCamposTabela.InsPrincipal => InsPrincipal,
        NomesCamposTabela.InsAcao => InsAcao,
        NomesCamposTabela.InsForo => InsForo,
        NomesCamposTabela.InsTipoRecurso => InsTipoRecurso,
        NomesCamposTabela.InsZKey => InsZKey,
        NomesCamposTabela.InsZKeyQuem => InsZKeyQuem,
        NomesCamposTabela.InsZKeyQuando => InsZKeyQuando,
        NomesCamposTabela.InsNroAntigo => InsNroAntigo,
        NomesCamposTabela.InsAccessCode => InsAccessCode,
        NomesCamposTabela.InsJulgador => InsJulgador,
        NomesCamposTabela.InsZKeyIA => InsZKeyIA,
        NomesCamposTabela.InsGUID => InsGUID,
        NomesCamposTabela.InsQuemCad => InsQuemCad,
        NomesCamposTabela.InsDtCad => InsDtCad,
        NomesCamposTabela.InsQuemAtu => InsQuemAtu,
        NomesCamposTabela.InsDtAtu => InsDtAtu,
        NomesCamposTabela.InsVisto => InsVisto,
        _ => null
    };
}