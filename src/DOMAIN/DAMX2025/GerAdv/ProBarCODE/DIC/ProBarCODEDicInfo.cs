using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProBarCODEDicInfo
{
    public const string CampoCodigo = "";
    public const string CampoNome = "";
    public const string TablePrefix = "pbc";
    public const string BarCODE = "pbcBarCODE"; // LOCALIZACAO 170523
    public const string Processo = "pbcProcesso"; // LOCALIZACAO 170523
    public const string QuemCad = "pbcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "pbcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "pbcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "pbcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "pbcVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => BarCODE,
        2 => Processo,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProBarCODE";
#region PropriedadesDaTabela
    public static DBInfoSystem PbcBarCODE => new(0, PTabelaNome, CampoCodigo, BarCODE, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pbc"
    };
    public static DBInfoSystem PbcProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "pbc"
    }; // DBI 11 
    public static DBInfoSystem PbcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pbc"
    }; // DBI 11 
    public static DBInfoSystem PbcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "pbc"
    };
    public static DBInfoSystem PbcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pbc"
    }; // DBI 11 
    public static DBInfoSystem PbcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "pbc"
    };
    public static DBInfoSystem PbcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "pbc"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PbcBarCODE = 1,
        PbcProcesso = 2,
        PbcQuemCad = 3,
        PbcDtCad = 4,
        PbcQuemAtu = 5,
        PbcDtAtu = 6,
        PbcVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PbcBarCODE => PbcBarCODE,
        NomesCamposTabela.PbcProcesso => PbcProcesso,
        NomesCamposTabela.PbcQuemCad => PbcQuemCad,
        NomesCamposTabela.PbcDtCad => PbcDtCad,
        NomesCamposTabela.PbcQuemAtu => PbcQuemAtu,
        NomesCamposTabela.PbcDtAtu => PbcDtAtu,
        NomesCamposTabela.PbcVisto => PbcVisto,
        _ => null
    };
}