using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBEventoPrazoAgendaDicInfo
{
    public const string CampoCodigo = "epaCodigo";
    public const string CampoNome = "epaNome";
    public const string TablePrefix = "epa";
    public const string Nome = "epaNome"; // LOCALIZACAO 170523
    public const string Bold = "epaBold"; // LOCALIZACAO 170523
    public const string QuemCad = "epaQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "epaDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "epaQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "epaDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "epaVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Bold,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "EventoPrazoAgenda";
#region PropriedadesDaTabela
    public static DBInfoSystem EpaNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "epa"
    };
    public static DBInfoSystem EpaBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "epa"
    };
    public static DBInfoSystem EpaQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "epa"
    }; // DBI 11 
    public static DBInfoSystem EpaDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "epa"
    };
    public static DBInfoSystem EpaQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "epa"
    }; // DBI 11 
    public static DBInfoSystem EpaDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "epa"
    };
    public static DBInfoSystem EpaVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "epa"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        EpaNome = 1,
        EpaBold = 2,
        EpaQuemCad = 3,
        EpaDtCad = 4,
        EpaQuemAtu = 5,
        EpaDtAtu = 6,
        EpaVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.EpaNome => EpaNome,
        NomesCamposTabela.EpaBold => EpaBold,
        NomesCamposTabela.EpaQuemCad => EpaQuemCad,
        NomesCamposTabela.EpaDtCad => EpaDtCad,
        NomesCamposTabela.EpaQuemAtu => EpaQuemAtu,
        NomesCamposTabela.EpaDtAtu => EpaDtAtu,
        NomesCamposTabela.EpaVisto => EpaVisto,
        _ => null
    };
}