using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAreaDicInfo
{
    public const string CampoCodigo = "areCodigo";
    public const string CampoNome = "areDescricao";
    public const string TablePrefix = "are";
    public const string Descricao = "areDescricao"; // LOCALIZACAO 170523
    public const string Top = "areTop"; // LOCALIZACAO 170523
    public const string GUID = "areGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "areQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "areDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "areQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "areDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "areVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
        2 => Top,
        3 => GUID,
        4 => QuemCad,
        5 => DtCad,
        6 => QuemAtu,
        7 => DtAtu,
        8 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Area";
#region PropriedadesDaTabela
    public static DBInfoSystem AreDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "are"
    };
    public static DBInfoSystem AreTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "are"
    };
    public static DBInfoSystem AreGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "are"
    };
    public static DBInfoSystem AreQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "are"
    }; // DBI 11 
    public static DBInfoSystem AreDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "are"
    };
    public static DBInfoSystem AreQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "are"
    }; // DBI 11 
    public static DBInfoSystem AreDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "are"
    };
    public static DBInfoSystem AreVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "are"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        AreDescricao = 1,
        AreTop = 2,
        AreGUID = 3,
        AreQuemCad = 4,
        AreDtCad = 5,
        AreQuemAtu = 6,
        AreDtAtu = 7,
        AreVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AreDescricao => AreDescricao,
        NomesCamposTabela.AreTop => AreTop,
        NomesCamposTabela.AreGUID => AreGUID,
        NomesCamposTabela.AreQuemCad => AreQuemCad,
        NomesCamposTabela.AreDtCad => AreDtCad,
        NomesCamposTabela.AreQuemAtu => AreQuemAtu,
        NomesCamposTabela.AreDtAtu => AreDtAtu,
        NomesCamposTabela.AreVisto => AreVisto,
        _ => null
    };
}