using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBJusticaDicInfo
{
    public const string CampoCodigo = "jusCodigo";
    public const string CampoNome = "jusNome";
    public const string TablePrefix = "jus";
    public const string Nome = "jusNome"; // LOCALIZACAO 170523
    public const string Bold = "jusBold"; // LOCALIZACAO 170523
    public const string GUID = "jusGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "jusQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "jusDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "jusQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "jusDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "jusVisto"; // LOCALIZACAO 170523
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

    public const string PTabelaNome = "Justica";
#region PropriedadesDaTabela
    public static DBInfoSystem JusNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "jus"
    };
    public static DBInfoSystem JusBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "jus"
    };
    public static DBInfoSystem JusGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "jus"
    };
    public static DBInfoSystem JusQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "jus"
    }; // DBI 11 
    public static DBInfoSystem JusDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "jus"
    };
    public static DBInfoSystem JusQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "jus"
    }; // DBI 11 
    public static DBInfoSystem JusDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "jus"
    };
    public static DBInfoSystem JusVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "jus"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        JusNome = 1,
        JusBold = 2,
        JusGUID = 3,
        JusQuemCad = 4,
        JusDtCad = 5,
        JusQuemAtu = 6,
        JusDtAtu = 7,
        JusVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.JusNome => JusNome,
        NomesCamposTabela.JusBold => JusBold,
        NomesCamposTabela.JusGUID => JusGUID,
        NomesCamposTabela.JusQuemCad => JusQuemCad,
        NomesCamposTabela.JusDtCad => JusDtCad,
        NomesCamposTabela.JusQuemAtu => JusQuemAtu,
        NomesCamposTabela.JusDtAtu => JusDtAtu,
        NomesCamposTabela.JusVisto => JusVisto,
        _ => null
    };
}