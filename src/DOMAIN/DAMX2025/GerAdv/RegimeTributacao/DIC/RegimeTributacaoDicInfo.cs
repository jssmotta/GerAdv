using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBRegimeTributacaoDicInfo
{
    public const string CampoCodigo = "rdtCodigo";
    public const string CampoNome = "rdtNome";
    public const string TablePrefix = "rdt";
    public const string Nome = "rdtNome"; // LOCALIZACAO 170523
    public const string GUID = "rdtGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "rdtQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "rdtDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "rdtQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "rdtDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "rdtVisto"; // LOCALIZACAO 170523
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

    public const string PTabelaNome = "RegimeTributacao";
#region PropriedadesDaTabela
    public static DBInfoSystem RdtNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "rdt"
    };
    public static DBInfoSystem RdtGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "rdt"
    };
    public static DBInfoSystem RdtQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "rdt"
    }; // DBI 11 
    public static DBInfoSystem RdtDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "rdt"
    };
    public static DBInfoSystem RdtQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "rdt"
    }; // DBI 11 
    public static DBInfoSystem RdtDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "rdt"
    };
    public static DBInfoSystem RdtVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        Prefixo = "rdt"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        RdtNome = 1,
        RdtGUID = 2,
        RdtQuemCad = 3,
        RdtDtCad = 4,
        RdtQuemAtu = 5,
        RdtDtAtu = 6,
        RdtVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RdtNome => RdtNome,
        NomesCamposTabela.RdtGUID => RdtGUID,
        NomesCamposTabela.RdtQuemCad => RdtQuemCad,
        NomesCamposTabela.RdtDtCad => RdtDtCad,
        NomesCamposTabela.RdtQuemAtu => RdtQuemAtu,
        NomesCamposTabela.RdtDtAtu => RdtDtAtu,
        NomesCamposTabela.RdtVisto => RdtVisto,
        _ => null
    };
}