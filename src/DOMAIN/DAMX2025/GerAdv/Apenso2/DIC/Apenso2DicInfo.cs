using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBApenso2DicInfo
{
    public const string CampoCodigo = "ap2Codigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ap2";
    public const string Processo = "ap2Processo"; // LOCALIZACAO 170523
    public const string Apensado = "ap2Apensado"; // LOCALIZACAO 170523
    public const string QuemCad = "ap2QuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ap2DtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ap2QuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ap2DtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ap2Visto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Apensado,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Apenso2";
#region PropriedadesDaTabela
    public static DBInfoSystem Ap2Processo => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "ap2"
    }; // DBI 11 
    public static DBInfoSystem Ap2Apensado => new(0, PTabelaNome, CampoCodigo, Apensado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ap2"
    };
    public static DBInfoSystem Ap2QuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ap2"
    }; // DBI 11 
    public static DBInfoSystem Ap2DtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ap2"
    };
    public static DBInfoSystem Ap2QuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ap2"
    }; // DBI 11 
    public static DBInfoSystem Ap2DtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ap2"
    };
    public static DBInfoSystem Ap2Visto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ap2"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        Ap2Processo = 1,
        Ap2Apensado = 2,
        Ap2QuemCad = 3,
        Ap2DtCad = 4,
        Ap2QuemAtu = 5,
        Ap2DtAtu = 6,
        Ap2Visto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.Ap2Processo => Ap2Processo,
        NomesCamposTabela.Ap2Apensado => Ap2Apensado,
        NomesCamposTabela.Ap2QuemCad => Ap2QuemCad,
        NomesCamposTabela.Ap2DtCad => Ap2DtCad,
        NomesCamposTabela.Ap2QuemAtu => Ap2QuemAtu,
        NomesCamposTabela.Ap2DtAtu => Ap2DtAtu,
        NomesCamposTabela.Ap2Visto => Ap2Visto,
        _ => null
    };
}