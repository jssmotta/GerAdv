using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOperadorGruposAgendaOperadoresDicInfo
{
    public const string CampoCodigo = "ogpCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ogp";
    public const string OperadorGruposAgenda = "ogpOperadorGruposAgenda"; // LOCALIZACAO 170523
    public const string Operador = "ogpOperador"; // LOCALIZACAO 170523
    public const string GUID = "ogpGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ogpQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ogpDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ogpQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ogpDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ogpVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => OperadorGruposAgenda,
        2 => Operador,
        3 => GUID,
        4 => QuemCad,
        5 => DtCad,
        6 => QuemAtu,
        7 => DtAtu,
        8 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "OperadorGruposAgendaOperadores";
#region PropriedadesDaTabela
    public static DBInfoSystem OgpOperadorGruposAgenda => new(0, PTabelaNome, CampoCodigo, OperadorGruposAgenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorGruposAgendaDicInfo.CampoCodigo, DBOperadorGruposAgendaDicInfo.TabelaNome, new DBOperadorGruposAgendaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "ogp"
    }; // DBI 11 
    public static DBInfoSystem OgpOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "ogp"
    }; // DBI 11 
    public static DBInfoSystem OgpGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "ogp"
    };
    public static DBInfoSystem OgpQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "ogp"
    }; // DBI 11 
    public static DBInfoSystem OgpDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "ogp"
    };
    public static DBInfoSystem OgpQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ogp"
    }; // DBI 11 
    public static DBInfoSystem OgpDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ogp"
    };
    public static DBInfoSystem OgpVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ogp"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        OgpOperadorGruposAgenda = 1,
        OgpOperador = 2,
        OgpGUID = 3,
        OgpQuemCad = 4,
        OgpDtCad = 5,
        OgpQuemAtu = 6,
        OgpDtAtu = 7,
        OgpVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OgpOperadorGruposAgenda => OgpOperadorGruposAgenda,
        NomesCamposTabela.OgpOperador => OgpOperador,
        NomesCamposTabela.OgpGUID => OgpGUID,
        NomesCamposTabela.OgpQuemCad => OgpQuemCad,
        NomesCamposTabela.OgpDtCad => OgpDtCad,
        NomesCamposTabela.OgpQuemAtu => OgpQuemAtu,
        NomesCamposTabela.OgpDtAtu => OgpDtAtu,
        NomesCamposTabela.OgpVisto => OgpVisto,
        _ => null
    };
}