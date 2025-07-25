using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBRamalDicInfo
{
    public const string CampoCodigo = "ramCodigo";
    public const string CampoNome = "ramNome";
    public const string TablePrefix = "ram";
    public const string Nome = "ramNome"; // LOCALIZACAO 170523
    public const string Obs = "ramObs"; // LOCALIZACAO 170523
    public const string QuemCad = "ramQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ramDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ramQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ramDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ramVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Obs,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Ramal";
#region PropriedadesDaTabela
    public static DBInfoSystem RamNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "ram"
    };
    public static DBInfoSystem RamObs => new(0, PTabelaNome, CampoCodigo, Obs, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "ram"
    };
    public static DBInfoSystem RamQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ram"
    }; // DBI 11 
    public static DBInfoSystem RamDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ram"
    };
    public static DBInfoSystem RamQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ram"
    }; // DBI 11 
    public static DBInfoSystem RamDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ram"
    };
    public static DBInfoSystem RamVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ram"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        RamNome = 1,
        RamObs = 2,
        RamQuemCad = 3,
        RamDtCad = 4,
        RamQuemAtu = 5,
        RamDtAtu = 6,
        RamVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RamNome => RamNome,
        NomesCamposTabela.RamObs => RamObs,
        NomesCamposTabela.RamQuemCad => RamQuemCad,
        NomesCamposTabela.RamDtCad => RamDtCad,
        NomesCamposTabela.RamQuemAtu => RamQuemAtu,
        NomesCamposTabela.RamDtAtu => RamDtAtu,
        NomesCamposTabela.RamVisto => RamVisto,
        _ => null
    };
}