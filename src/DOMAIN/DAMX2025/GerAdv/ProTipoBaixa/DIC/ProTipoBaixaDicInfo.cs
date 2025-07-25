using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProTipoBaixaDicInfo
{
    public const string CampoCodigo = "ptxCodigo";
    public const string CampoNome = "ptxNome";
    public const string TablePrefix = "ptx";
    public const string Nome = "ptxNome"; // LOCALIZACAO 170523
    public const string Bold = "ptxBold"; // LOCALIZACAO 170523
    public const string GUID = "ptxGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ptxQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ptxDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ptxQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ptxDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ptxVisto"; // LOCALIZACAO 170523
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

    public const string PTabelaNome = "ProTipoBaixa";
#region PropriedadesDaTabela
    public static DBInfoSystem PtxNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "ptx"
    };
    public static DBInfoSystem PtxBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "ptx"
    };
    public static DBInfoSystem PtxGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "ptx"
    };
    public static DBInfoSystem PtxQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ptx"
    }; // DBI 11 
    public static DBInfoSystem PtxDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ptx"
    };
    public static DBInfoSystem PtxQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ptx"
    }; // DBI 11 
    public static DBInfoSystem PtxDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ptx"
    };
    public static DBInfoSystem PtxVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ptx"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PtxNome = 1,
        PtxBold = 2,
        PtxGUID = 3,
        PtxQuemCad = 4,
        PtxDtCad = 5,
        PtxQuemAtu = 6,
        PtxDtAtu = 7,
        PtxVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PtxNome => PtxNome,
        NomesCamposTabela.PtxBold => PtxBold,
        NomesCamposTabela.PtxGUID => PtxGUID,
        NomesCamposTabela.PtxQuemCad => PtxQuemCad,
        NomesCamposTabela.PtxDtCad => PtxDtCad,
        NomesCamposTabela.PtxQuemAtu => PtxQuemAtu,
        NomesCamposTabela.PtxDtAtu => PtxDtAtu,
        NomesCamposTabela.PtxVisto => PtxVisto,
        _ => null
    };
}