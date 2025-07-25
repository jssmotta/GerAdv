using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBEMPClassRiscosDicInfo
{
    public const string CampoCodigo = "ecrCodigo";
    public const string CampoNome = "ecrNome";
    public const string TablePrefix = "ecr";
    public const string Nome = "ecrNome"; // LOCALIZACAO 170523
    public const string Bold = "ecrBold"; // LOCALIZACAO 170523
    public const string GUID = "ecrGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ecrQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ecrDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ecrQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ecrDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ecrVisto"; // LOCALIZACAO 170523
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

    public const string PTabelaNome = "EMPClassRiscos";
#region PropriedadesDaTabela
    public static DBInfoSystem EcrNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "ecr"
    };
    public static DBInfoSystem EcrBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "ecr"
    };
    public static DBInfoSystem EcrGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "ecr"
    };
    public static DBInfoSystem EcrQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ecr"
    }; // DBI 11 
    public static DBInfoSystem EcrDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ecr"
    };
    public static DBInfoSystem EcrQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ecr"
    }; // DBI 11 
    public static DBInfoSystem EcrDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ecr"
    };
    public static DBInfoSystem EcrVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ecr"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        EcrNome = 1,
        EcrBold = 2,
        EcrGUID = 3,
        EcrQuemCad = 4,
        EcrDtCad = 5,
        EcrQuemAtu = 6,
        EcrDtAtu = 7,
        EcrVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.EcrNome => EcrNome,
        NomesCamposTabela.EcrBold => EcrBold,
        NomesCamposTabela.EcrGUID => EcrGUID,
        NomesCamposTabela.EcrQuemCad => EcrQuemCad,
        NomesCamposTabela.EcrDtCad => EcrDtCad,
        NomesCamposTabela.EcrQuemAtu => EcrQuemAtu,
        NomesCamposTabela.EcrDtAtu => EcrDtAtu,
        NomesCamposTabela.EcrVisto => EcrVisto,
        _ => null
    };
}