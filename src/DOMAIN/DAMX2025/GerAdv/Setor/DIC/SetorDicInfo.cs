using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBSetorDicInfo
{
    public const string CampoCodigo = "setCodigo";
    public const string CampoNome = "setDescricao";
    public const string TablePrefix = "set";
    public const string Descricao = "setDescricao"; // LOCALIZACAO 170523
    public const string GUID = "setGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "setQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "setDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "setQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "setDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "setVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
        2 => GUID,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Setor";
#region PropriedadesDaTabela
    public static DBInfoSystem SetDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "set"
    };
    public static DBInfoSystem SetGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "set"
    };
    public static DBInfoSystem SetQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "set"
    }; // DBI 11 
    public static DBInfoSystem SetDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "set"
    };
    public static DBInfoSystem SetQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "set"
    }; // DBI 11 
    public static DBInfoSystem SetDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "set"
    };
    public static DBInfoSystem SetVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "set"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        SetDescricao = 1,
        SetGUID = 2,
        SetQuemCad = 3,
        SetDtCad = 4,
        SetQuemAtu = 5,
        SetDtAtu = 6,
        SetVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.SetDescricao => SetDescricao,
        NomesCamposTabela.SetGUID => SetGUID,
        NomesCamposTabela.SetQuemCad => SetQuemCad,
        NomesCamposTabela.SetDtCad => SetDtCad,
        NomesCamposTabela.SetQuemAtu => SetQuemAtu,
        NomesCamposTabela.SetDtAtu => SetDtAtu,
        NomesCamposTabela.SetVisto => SetVisto,
        _ => null
    };
}