using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTipoRecursoDicInfo
{
    public const string CampoCodigo = "trcCodigo";
    public const string CampoNome = "trcDescricao";
    public const string TablePrefix = "trc";
    public const string Justica = "trcJustica"; // LOCALIZACAO 170523
    public const string Area = "trcArea"; // LOCALIZACAO 170523
    public const string Descricao = "trcDescricao"; // LOCALIZACAO 170523
    public const string GUID = "trcGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "trcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "trcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "trcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "trcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "trcVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Justica,
        2 => Area,
        3 => Descricao,
        4 => GUID,
        5 => QuemCad,
        6 => DtCad,
        7 => QuemAtu,
        8 => DtAtu,
        9 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TipoRecurso";
#region PropriedadesDaTabela
    public static DBInfoSystem TrcJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false)
    {
        Prefixo = "trc"
    }; // DBI 11 
    public static DBInfoSystem TrcArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false)
    {
        Prefixo = "trc"
    }; // DBI 11 
    public static DBInfoSystem TrcDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "trc"
    };
    public static DBInfoSystem TrcGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "trc"
    };
    public static DBInfoSystem TrcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "trc"
    }; // DBI 11 
    public static DBInfoSystem TrcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "trc"
    };
    public static DBInfoSystem TrcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "trc"
    }; // DBI 11 
    public static DBInfoSystem TrcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "trc"
    };
    public static DBInfoSystem TrcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "trc"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TrcJustica = 1,
        TrcArea = 2,
        TrcDescricao = 3,
        TrcGUID = 4,
        TrcQuemCad = 5,
        TrcDtCad = 6,
        TrcQuemAtu = 7,
        TrcDtAtu = 8,
        TrcVisto = 9
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TrcJustica => TrcJustica,
        NomesCamposTabela.TrcArea => TrcArea,
        NomesCamposTabela.TrcDescricao => TrcDescricao,
        NomesCamposTabela.TrcGUID => TrcGUID,
        NomesCamposTabela.TrcQuemCad => TrcQuemCad,
        NomesCamposTabela.TrcDtCad => TrcDtCad,
        NomesCamposTabela.TrcQuemAtu => TrcQuemAtu,
        NomesCamposTabela.TrcDtAtu => TrcDtAtu,
        NomesCamposTabela.TrcVisto => TrcVisto,
        _ => null
    };
}