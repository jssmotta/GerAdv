using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTipoEnderecoSistemaDicInfo
{
    public const string CampoCodigo = "tesCodigo";
    public const string CampoNome = "tesNome";
    public const string TablePrefix = "tes";
    public const string Nome = "tesNome"; // LOCALIZACAO 170523
    public const string GUID = "tesGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "tesQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "tesDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "tesQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "tesDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "tesVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => GUID,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TipoEnderecoSistema";
#region PropriedadesDaTabela
    public static DBInfoSystem TesNome => new(0, PTabelaNome, CampoCodigo, Nome, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "tes"
    };
    public static DBInfoSystem TesGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "tes"
    };
    public static DBInfoSystem TesQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "tes"
    }; // DBI 11 
    public static DBInfoSystem TesDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "tes"
    };
    public static DBInfoSystem TesQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tes"
    }; // DBI 11 
    public static DBInfoSystem TesDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "tes"
    };
    public static DBInfoSystem TesVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "tes"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TesNome = 1,
        TesGUID = 2,
        TesQuemCad = 3,
        TesDtCad = 4,
        TesQuemAtu = 5,
        TesDtAtu = 6,
        TesVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TesNome => TesNome,
        NomesCamposTabela.TesGUID => TesGUID,
        NomesCamposTabela.TesQuemCad => TesQuemCad,
        NomesCamposTabela.TesDtCad => TesDtCad,
        NomesCamposTabela.TesQuemAtu => TesQuemAtu,
        NomesCamposTabela.TesDtAtu => TesDtAtu,
        NomesCamposTabela.TesVisto => TesVisto,
        _ => null
    };
}