using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBBensClassificacaoDicInfo
{
    public const string CampoCodigo = "bcsCodigo";
    public const string CampoNome = "bcsNome";
    public const string TablePrefix = "bcs";
    public const string Nome = "bcsNome"; // LOCALIZACAO 170523
    public const string Bold = "bcsBold"; // LOCALIZACAO 170523
    public const string GUID = "bcsGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "bcsQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "bcsDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "bcsQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "bcsDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "bcsVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Bold,
        3 => GUID,
        4 => QuemCad,
        5 => DtCad,
        6 => QuemAtu,
        7 => DtAtu,
        8 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "BensClassificacao";
#region PropriedadesDaTabela
    public static DBInfoSystem BcsNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "bcs"
    };
    public static DBInfoSystem BcsBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "bcs"
    };
    public static DBInfoSystem BcsGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "bcs"
    };
    public static DBInfoSystem BcsQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "bcs"
    }; // DBI 11 
    public static DBInfoSystem BcsDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "bcs"
    };
    public static DBInfoSystem BcsQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "bcs"
    }; // DBI 11 
    public static DBInfoSystem BcsDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "bcs"
    };
    public static DBInfoSystem BcsVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "bcs"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        BcsNome = 1,
        BcsBold = 2,
        BcsGUID = 3,
        BcsQuemCad = 4,
        BcsDtCad = 5,
        BcsQuemAtu = 6,
        BcsDtAtu = 7,
        BcsVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.BcsNome => BcsNome,
        NomesCamposTabela.BcsBold => BcsBold,
        NomesCamposTabela.BcsGUID => BcsGUID,
        NomesCamposTabela.BcsQuemCad => BcsQuemCad,
        NomesCamposTabela.BcsDtCad => BcsDtCad,
        NomesCamposTabela.BcsQuemAtu => BcsQuemAtu,
        NomesCamposTabela.BcsDtAtu => BcsDtAtu,
        NomesCamposTabela.BcsVisto => BcsVisto,
        _ => null
    };
}