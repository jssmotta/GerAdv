using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBCargosEscDicInfo
{
    public const string CampoCodigo = "cgeCodigo";
    public const string CampoNome = "cgeNome";
    public const string TablePrefix = "cge";
    public const string Percentual = "cgePercentual"; // LOCALIZACAO 170523
    public const string Nome = "cgeNome"; // LOCALIZACAO 170523
    public const string Classificacao = "cgeClassificacao"; // LOCALIZACAO 170523
    public const string GUID = "cgeGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "cgeQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "cgeDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "cgeQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "cgeDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "cgeVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Percentual,
        2 => Nome,
        3 => Classificacao,
        4 => GUID,
        5 => QuemCad,
        6 => DtCad,
        7 => QuemAtu,
        8 => DtAtu,
        9 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "CargosEsc";
#region PropriedadesDaTabela
    public static DBInfoSystem CgePercentual => new(0, PTabelaNome, CampoCodigo, Percentual, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "cge"
    };
    public static DBInfoSystem CgeNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "cge"
    };
    public static DBInfoSystem CgeClassificacao => new(0, PTabelaNome, CampoCodigo, Classificacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cge"
    };
    public static DBInfoSystem CgeGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "cge"
    };
    public static DBInfoSystem CgeQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "cge"
    }; // DBI 11 
    public static DBInfoSystem CgeDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "cge"
    };
    public static DBInfoSystem CgeQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "cge"
    }; // DBI 11 
    public static DBInfoSystem CgeDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "cge"
    };
    public static DBInfoSystem CgeVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "cge"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        CgePercentual = 1,
        CgeNome = 2,
        CgeClassificacao = 3,
        CgeGUID = 4,
        CgeQuemCad = 5,
        CgeDtCad = 6,
        CgeQuemAtu = 7,
        CgeDtAtu = 8,
        CgeVisto = 9
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CgePercentual => CgePercentual,
        NomesCamposTabela.CgeNome => CgeNome,
        NomesCamposTabela.CgeClassificacao => CgeClassificacao,
        NomesCamposTabela.CgeGUID => CgeGUID,
        NomesCamposTabela.CgeQuemCad => CgeQuemCad,
        NomesCamposTabela.CgeDtCad => CgeDtCad,
        NomesCamposTabela.CgeQuemAtu => CgeQuemAtu,
        NomesCamposTabela.CgeDtAtu => CgeDtAtu,
        NomesCamposTabela.CgeVisto => CgeVisto,
        _ => null
    };
}