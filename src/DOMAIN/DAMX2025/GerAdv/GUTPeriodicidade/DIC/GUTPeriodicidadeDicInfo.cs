using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBGUTPeriodicidadeDicInfo
{
    public const string CampoCodigo = "pcgCodigo";
    public const string CampoNome = "pcgNome";
    public const string TablePrefix = "pcg";
    public const string Nome = "pcgNome"; // LOCALIZACAO 170523
    public const string IntervaloDias = "pcgIntervaloDias"; // LOCALIZACAO 170523
    public const string GUID = "pcgGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "pcgQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "pcgDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "pcgQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "pcgDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "pcgVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => IntervaloDias,
        3 => GUID,
        4 => QuemCad,
        5 => DtCad,
        6 => QuemAtu,
        7 => DtAtu,
        8 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "GUTPeriodicidade";
#region PropriedadesDaTabela
    public static DBInfoSystem PcgNome => new(0, PTabelaNome, CampoCodigo, Nome, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "pcg"
    };
    public static DBInfoSystem PcgIntervaloDias => new(0, PTabelaNome, CampoCodigo, IntervaloDias, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "pcg"
    };
    public static DBInfoSystem PcgGUID => new(0, PTabelaNome, CampoCodigo, GUID, 50, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "pcg"
    };
    public static DBInfoSystem PcgQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "pcg"
    }; // DBI 11 
    public static DBInfoSystem PcgDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "pcg"
    };
    public static DBInfoSystem PcgQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pcg"
    }; // DBI 11 
    public static DBInfoSystem PcgDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "pcg"
    };
    public static DBInfoSystem PcgVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "pcg"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PcgNome = 1,
        PcgIntervaloDias = 2,
        PcgGUID = 3,
        PcgQuemCad = 4,
        PcgDtCad = 5,
        PcgQuemAtu = 6,
        PcgDtAtu = 7,
        PcgVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PcgNome => PcgNome,
        NomesCamposTabela.PcgIntervaloDias => PcgIntervaloDias,
        NomesCamposTabela.PcgGUID => PcgGUID,
        NomesCamposTabela.PcgQuemCad => PcgQuemCad,
        NomesCamposTabela.PcgDtCad => PcgDtCad,
        NomesCamposTabela.PcgQuemAtu => PcgQuemAtu,
        NomesCamposTabela.PcgDtAtu => PcgDtAtu,
        NomesCamposTabela.PcgVisto => PcgVisto,
        _ => null
    };
}