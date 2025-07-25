using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBPoderJudiciarioAssociadoDicInfo
{
    public const string CampoCodigo = "pjaCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "pja";
    public const string Justica = "pjaJustica"; // LOCALIZACAO 170523
    public const string JusticaNome = "pjaJusticaNome"; // LOCALIZACAO 170523
    public const string Area = "pjaArea"; // LOCALIZACAO 170523
    public const string AreaNome = "pjaAreaNome"; // LOCALIZACAO 170523
    public const string Tribunal = "pjaTribunal"; // LOCALIZACAO 170523
    public const string TribunalNome = "pjaTribunalNome"; // LOCALIZACAO 170523
    public const string Foro = "pjaForo"; // LOCALIZACAO 170523
    public const string ForoNome = "pjaForoNome"; // LOCALIZACAO 170523
    public const string Cidade = "pjaCidade"; // LOCALIZACAO 170523
    public const string SubDivisaoNome = "pjaSubDivisaoNome"; // LOCALIZACAO 170523
    public const string CidadeNome = "pjaCidadeNome"; // LOCALIZACAO 170523
    public const string SubDivisao = "pjaSubDivisao"; // LOCALIZACAO 170523
    public const string Tipo = "pjaTipo"; // LOCALIZACAO 170523
    public const string GUID = "pjaGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "pjaQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "pjaDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "pjaQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "pjaDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "pjaVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Justica,
        2 => JusticaNome,
        3 => Area,
        4 => AreaNome,
        5 => Tribunal,
        6 => TribunalNome,
        7 => Foro,
        8 => ForoNome,
        9 => Cidade,
        10 => SubDivisaoNome,
        11 => CidadeNome,
        12 => SubDivisao,
        13 => Tipo,
        14 => GUID,
        15 => QuemCad,
        16 => DtCad,
        17 => QuemAtu,
        18 => DtAtu,
        19 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "PoderJudiciarioAssociado";
#region PropriedadesDaTabela
    public static DBInfoSystem PjaJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false)
    {
        Prefixo = "pja"
    }; // DBI 11 
    public static DBInfoSystem PjaJusticaNome => new(0, PTabelaNome, CampoCodigo, JusticaNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false)
    {
        Prefixo = "pja"
    }; // DBI 11 
    public static DBInfoSystem PjaAreaNome => new(0, PTabelaNome, CampoCodigo, AreaNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaTribunal => new(0, PTabelaNome, CampoCodigo, Tribunal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTribunalDicInfo.CampoCodigo, DBTribunalDicInfo.TabelaNome, new DBTribunalODicInfo(), false)
    {
        Prefixo = "pja"
    }; // DBI 11 
    public static DBInfoSystem PjaTribunalNome => new(0, PTabelaNome, CampoCodigo, TribunalNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaForo => new(0, PTabelaNome, CampoCodigo, Foro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBForoDicInfo.CampoCodigo, DBForoDicInfo.TabelaNome, new DBForoODicInfo(), false)
    {
        Prefixo = "pja"
    }; // DBI 11 
    public static DBInfoSystem PjaForoNome => new(0, PTabelaNome, CampoCodigo, ForoNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "pja"
    }; // DBI 11 
    public static DBInfoSystem PjaSubDivisaoNome => new(0, PTabelaNome, CampoCodigo, SubDivisaoNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaCidadeNome => new(0, PTabelaNome, CampoCodigo, CidadeNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaSubDivisao => new(0, PTabelaNome, CampoCodigo, SubDivisao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pja"
    }; // DBI 11 
    public static DBInfoSystem PjaDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pja"
    }; // DBI 11 
    public static DBInfoSystem PjaDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "pja"
    };
    public static DBInfoSystem PjaVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "pja"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PjaJustica = 1,
        PjaJusticaNome = 2,
        PjaArea = 3,
        PjaAreaNome = 4,
        PjaTribunal = 5,
        PjaTribunalNome = 6,
        PjaForo = 7,
        PjaForoNome = 8,
        PjaCidade = 9,
        PjaSubDivisaoNome = 10,
        PjaCidadeNome = 11,
        PjaSubDivisao = 12,
        PjaTipo = 13,
        PjaGUID = 14,
        PjaQuemCad = 15,
        PjaDtCad = 16,
        PjaQuemAtu = 17,
        PjaDtAtu = 18,
        PjaVisto = 19
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PjaJustica => PjaJustica,
        NomesCamposTabela.PjaJusticaNome => PjaJusticaNome,
        NomesCamposTabela.PjaArea => PjaArea,
        NomesCamposTabela.PjaAreaNome => PjaAreaNome,
        NomesCamposTabela.PjaTribunal => PjaTribunal,
        NomesCamposTabela.PjaTribunalNome => PjaTribunalNome,
        NomesCamposTabela.PjaForo => PjaForo,
        NomesCamposTabela.PjaForoNome => PjaForoNome,
        NomesCamposTabela.PjaCidade => PjaCidade,
        NomesCamposTabela.PjaSubDivisaoNome => PjaSubDivisaoNome,
        NomesCamposTabela.PjaCidadeNome => PjaCidadeNome,
        NomesCamposTabela.PjaSubDivisao => PjaSubDivisao,
        NomesCamposTabela.PjaTipo => PjaTipo,
        NomesCamposTabela.PjaGUID => PjaGUID,
        NomesCamposTabela.PjaQuemCad => PjaQuemCad,
        NomesCamposTabela.PjaDtCad => PjaDtCad,
        NomesCamposTabela.PjaQuemAtu => PjaQuemAtu,
        NomesCamposTabela.PjaDtAtu => PjaDtAtu,
        NomesCamposTabela.PjaVisto => PjaVisto,
        _ => null
    };
}