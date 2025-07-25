using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBStatusInstanciaDicInfo
{
    public const string CampoCodigo = "istCodigo";
    public const string CampoNome = "istNome";
    public const string TablePrefix = "ist";
    public const string Nome = "istNome"; // LOCALIZACAO 170523
    public const string Bold = "istBold"; // LOCALIZACAO 170523
    public const string GUID = "istGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "istQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "istDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "istQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "istDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "istVisto"; // LOCALIZACAO 170523
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

    public const string PTabelaNome = "StatusInstancia";
#region PropriedadesDaTabela
    public static DBInfoSystem IstNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "ist"
    };
    public static DBInfoSystem IstBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "ist"
    };
    public static DBInfoSystem IstGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "ist"
    };
    public static DBInfoSystem IstQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ist"
    }; // DBI 11 
    public static DBInfoSystem IstDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ist"
    };
    public static DBInfoSystem IstQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ist"
    }; // DBI 11 
    public static DBInfoSystem IstDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ist"
    };
    public static DBInfoSystem IstVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ist"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        IstNome = 1,
        IstBold = 2,
        IstGUID = 3,
        IstQuemCad = 4,
        IstDtCad = 5,
        IstQuemAtu = 6,
        IstDtAtu = 7,
        IstVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.IstNome => IstNome,
        NomesCamposTabela.IstBold => IstBold,
        NomesCamposTabela.IstGUID => IstGUID,
        NomesCamposTabela.IstQuemCad => IstQuemCad,
        NomesCamposTabela.IstDtCad => IstDtCad,
        NomesCamposTabela.IstQuemAtu => IstQuemAtu,
        NomesCamposTabela.IstDtAtu => IstDtAtu,
        NomesCamposTabela.IstVisto => IstVisto,
        _ => null
    };
}