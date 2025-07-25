using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProResumosDicInfo
{
    public const string CampoCodigo = "prsCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "prs";
    public const string Processo = "prsProcesso"; // LOCALIZACAO 170523
    public const string Data = "prsData"; // LOCALIZACAO 170523
    public const string Resumo = "prsResumo"; // LOCALIZACAO 170523
    public const string TipoResumo = "prsTipoResumo"; // LOCALIZACAO 170523
    public const string Bold = "prsBold"; // LOCALIZACAO 170523
    public const string GUID = "prsGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "prsQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "prsDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "prsQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "prsDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "prsVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Data,
        3 => Resumo,
        4 => TipoResumo,
        5 => Bold,
        6 => GUID,
        7 => QuemCad,
        8 => DtCad,
        9 => QuemAtu,
        10 => DtAtu,
        11 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProResumos";
#region PropriedadesDaTabela
    public static DBInfoSystem PrsProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "prs"
    }; // DBI 11 
    public static DBInfoSystem PrsData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "prs"
    };
    public static DBInfoSystem PrsResumo => new(0, PTabelaNome, CampoCodigo, Resumo, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "prs"
    };
    public static DBInfoSystem PrsTipoResumo => new(0, PTabelaNome, CampoCodigo, TipoResumo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "prs"
    };
    public static DBInfoSystem PrsBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "prs"
    };
    public static DBInfoSystem PrsGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "prs"
    };
    public static DBInfoSystem PrsQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "prs"
    }; // DBI 11 
    public static DBInfoSystem PrsDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "prs"
    };
    public static DBInfoSystem PrsQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "prs"
    }; // DBI 11 
    public static DBInfoSystem PrsDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "prs"
    };
    public static DBInfoSystem PrsVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "prs"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PrsProcesso = 1,
        PrsData = 2,
        PrsResumo = 3,
        PrsTipoResumo = 4,
        PrsBold = 5,
        PrsGUID = 6,
        PrsQuemCad = 7,
        PrsDtCad = 8,
        PrsQuemAtu = 9,
        PrsDtAtu = 10,
        PrsVisto = 11
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PrsProcesso => PrsProcesso,
        NomesCamposTabela.PrsData => PrsData,
        NomesCamposTabela.PrsResumo => PrsResumo,
        NomesCamposTabela.PrsTipoResumo => PrsTipoResumo,
        NomesCamposTabela.PrsBold => PrsBold,
        NomesCamposTabela.PrsGUID => PrsGUID,
        NomesCamposTabela.PrsQuemCad => PrsQuemCad,
        NomesCamposTabela.PrsDtCad => PrsDtCad,
        NomesCamposTabela.PrsQuemAtu => PrsQuemAtu,
        NomesCamposTabela.PrsDtAtu => PrsDtAtu,
        NomesCamposTabela.PrsVisto => PrsVisto,
        _ => null
    };
}