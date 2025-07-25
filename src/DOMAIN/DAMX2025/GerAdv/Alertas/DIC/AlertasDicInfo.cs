using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAlertasDicInfo
{
    public const string CampoCodigo = "altCodigo";
    public const string CampoNome = "altNome";
    public const string TablePrefix = "alt";
    public const string Nome = "altNome"; // LOCALIZACAO 170523
    public const string Data = "altData"; // LOCALIZACAO 170523
    public const string Operador = "altOperador"; // LOCALIZACAO 170523
    public const string DataAte = "altDataAte"; // LOCALIZACAO 170523
    public const string QuemCad = "altQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "altDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "altQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "altDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "altVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Data,
        3 => Operador,
        4 => DataAte,
        5 => QuemCad,
        6 => DtCad,
        7 => QuemAtu,
        8 => DtAtu,
        9 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Alertas";
#region PropriedadesDaTabela
    public static DBInfoSystem AltNome => new(0, PTabelaNome, CampoCodigo, Nome, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "alt"
    };
    public static DBInfoSystem AltData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "alt"
    };
    public static DBInfoSystem AltOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "alt"
    }; // DBI 11 
    public static DBInfoSystem AltDataAte => new(0, PTabelaNome, CampoCodigo, DataAte, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "alt"
    };
    public static DBInfoSystem AltQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "alt"
    }; // DBI 11 
    public static DBInfoSystem AltDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "alt"
    };
    public static DBInfoSystem AltQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "alt"
    }; // DBI 11 
    public static DBInfoSystem AltDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "alt"
    };
    public static DBInfoSystem AltVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "alt"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        AltNome = 1,
        AltData = 2,
        AltOperador = 3,
        AltDataAte = 4,
        AltQuemCad = 5,
        AltDtCad = 6,
        AltQuemAtu = 7,
        AltDtAtu = 8,
        AltVisto = 9
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AltNome => AltNome,
        NomesCamposTabela.AltData => AltData,
        NomesCamposTabela.AltOperador => AltOperador,
        NomesCamposTabela.AltDataAte => AltDataAte,
        NomesCamposTabela.AltQuemCad => AltQuemCad,
        NomesCamposTabela.AltDtCad => AltDtCad,
        NomesCamposTabela.AltQuemAtu => AltQuemAtu,
        NomesCamposTabela.AltDtAtu => AltDtAtu,
        NomesCamposTabela.AltVisto => AltVisto,
        _ => null
    };
}