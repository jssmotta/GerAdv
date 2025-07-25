using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBPosicaoOutrasPartesDicInfo
{
    public const string CampoCodigo = "posCodigo";
    public const string CampoNome = "posDescricao";
    public const string TablePrefix = "pos";
    public const string Descricao = "posDescricao"; // LOCALIZACAO 170523
    public const string Bold = "posBold"; // LOCALIZACAO 170523
    public const string GUID = "posGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "posQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "posDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "posQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "posDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "posVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
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

    public const string PTabelaNome = "PosicaoOutrasPartes";
#region PropriedadesDaTabela
    public static DBInfoSystem PosDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 30, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        IsRequired = true,
        Prefixo = "pos"
    };
    public static DBInfoSystem PosBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "pos"
    };
    public static DBInfoSystem PosGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "pos"
    };
    public static DBInfoSystem PosQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pos"
    }; // DBI 11 
    public static DBInfoSystem PosDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "pos"
    };
    public static DBInfoSystem PosQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pos"
    }; // DBI 11 
    public static DBInfoSystem PosDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "pos"
    };
    public static DBInfoSystem PosVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "pos"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PosDescricao = 1,
        PosBold = 2,
        PosGUID = 3,
        PosQuemCad = 4,
        PosDtCad = 5,
        PosQuemAtu = 6,
        PosDtAtu = 7,
        PosVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PosDescricao => PosDescricao,
        NomesCamposTabela.PosBold => PosBold,
        NomesCamposTabela.PosGUID => PosGUID,
        NomesCamposTabela.PosQuemCad => PosQuemCad,
        NomesCamposTabela.PosDtCad => PosDtCad,
        NomesCamposTabela.PosQuemAtu => PosQuemAtu,
        NomesCamposTabela.PosDtAtu => PosDtAtu,
        NomesCamposTabela.PosVisto => PosVisto,
        _ => null
    };
}