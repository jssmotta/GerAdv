using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBRitoDicInfo
{
    public const string CampoCodigo = "ritCodigo";
    public const string CampoNome = "ritDescricao";
    public const string TablePrefix = "rit";
    public const string Descricao = "ritDescricao"; // LOCALIZACAO 170523
    public const string Top = "ritTop"; // LOCALIZACAO 170523
    public const string Bold = "ritBold"; // LOCALIZACAO 170523
    public const string GUID = "ritGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ritQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ritDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ritQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ritDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ritVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
        2 => Top,
        3 => Bold,
        4 => GUID,
        5 => QuemCad,
        6 => DtCad,
        7 => QuemAtu,
        8 => DtAtu,
        9 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Rito";
#region PropriedadesDaTabela
    public static DBInfoSystem RitDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "rit"
    };
    public static DBInfoSystem RitTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "rit"
    };
    public static DBInfoSystem RitBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "rit"
    };
    public static DBInfoSystem RitGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "rit"
    };
    public static DBInfoSystem RitQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "rit"
    }; // DBI 11 
    public static DBInfoSystem RitDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "rit"
    };
    public static DBInfoSystem RitQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "rit"
    }; // DBI 11 
    public static DBInfoSystem RitDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "rit"
    };
    public static DBInfoSystem RitVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "rit"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        RitDescricao = 1,
        RitTop = 2,
        RitBold = 3,
        RitGUID = 4,
        RitQuemCad = 5,
        RitDtCad = 6,
        RitQuemAtu = 7,
        RitDtAtu = 8,
        RitVisto = 9
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RitDescricao => RitDescricao,
        NomesCamposTabela.RitTop => RitTop,
        NomesCamposTabela.RitBold => RitBold,
        NomesCamposTabela.RitGUID => RitGUID,
        NomesCamposTabela.RitQuemCad => RitQuemCad,
        NomesCamposTabela.RitDtCad => RitDtCad,
        NomesCamposTabela.RitQuemAtu => RitQuemAtu,
        NomesCamposTabela.RitDtAtu => RitDtAtu,
        NomesCamposTabela.RitVisto => RitVisto,
        _ => null
    };
}