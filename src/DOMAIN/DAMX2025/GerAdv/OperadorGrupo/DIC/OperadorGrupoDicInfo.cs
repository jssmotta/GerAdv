using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOperadorGrupoDicInfo
{
    public const string CampoCodigo = "ogrCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ogr";
    public const string Operador = "ogrOperador"; // LOCALIZACAO 170523
    public const string Grupo = "ogrGrupo"; // LOCALIZACAO 170523
    public const string Inativo = "ogrInativo"; // LOCALIZACAO 170523
    public const string QuemCad = "ogrQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ogrDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ogrQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ogrDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ogrVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Operador,
        2 => Grupo,
        3 => Inativo,
        4 => QuemCad,
        5 => DtCad,
        6 => QuemAtu,
        7 => DtAtu,
        8 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "OperadorGrupo";
#region PropriedadesDaTabela
    public static DBInfoSystem OgrOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ogr"
    }; // DBI 11 
    public static DBInfoSystem OgrGrupo => new(0, PTabelaNome, CampoCodigo, Grupo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ogr"
    };
    public static DBInfoSystem OgrInativo => new(0, PTabelaNome, CampoCodigo, Inativo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ogr"
    };
    public static DBInfoSystem OgrQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ogr"
    }; // DBI 11 
    public static DBInfoSystem OgrDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ogr"
    };
    public static DBInfoSystem OgrQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ogr"
    }; // DBI 11 
    public static DBInfoSystem OgrDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ogr"
    };
    public static DBInfoSystem OgrVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ogr"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        OgrOperador = 1,
        OgrGrupo = 2,
        OgrInativo = 3,
        OgrQuemCad = 4,
        OgrDtCad = 5,
        OgrQuemAtu = 6,
        OgrDtAtu = 7,
        OgrVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OgrOperador => OgrOperador,
        NomesCamposTabela.OgrGrupo => OgrGrupo,
        NomesCamposTabela.OgrInativo => OgrInativo,
        NomesCamposTabela.OgrQuemCad => OgrQuemCad,
        NomesCamposTabela.OgrDtCad => OgrDtCad,
        NomesCamposTabela.OgrQuemAtu => OgrQuemAtu,
        NomesCamposTabela.OgrDtAtu => OgrDtAtu,
        NomesCamposTabela.OgrVisto => OgrVisto,
        _ => null
    };
}