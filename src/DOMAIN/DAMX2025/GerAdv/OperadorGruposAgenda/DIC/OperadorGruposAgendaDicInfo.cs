using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOperadorGruposAgendaDicInfo
{
    public const string CampoCodigo = "groCodigo";
    public const string CampoNome = "groNome";
    public const string TablePrefix = "gro";
    public const string SQLWhere = "groSQLWhere"; // LOCALIZACAO 170523
    public const string Nome = "groNome"; // LOCALIZACAO 170523
    public const string Operador = "groOperador"; // LOCALIZACAO 170523
    public const string GUID = "groGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "groQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "groDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "groQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "groDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "groVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => SQLWhere,
        2 => Nome,
        3 => Operador,
        4 => GUID,
        5 => QuemCad,
        6 => DtCad,
        7 => QuemAtu,
        8 => DtAtu,
        9 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "OperadorGruposAgenda";
#region PropriedadesDaTabela
    public static DBInfoSystem GroSQLWhere => new(0, PTabelaNome, CampoCodigo, SQLWhere, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        IsRequired = true,
        Prefixo = "gro"
    };
    public static DBInfoSystem GroNome => new(0, PTabelaNome, CampoCodigo, Nome, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "gro"
    };
    public static DBInfoSystem GroOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "gro"
    }; // DBI 11 
    public static DBInfoSystem GroGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "gro"
    };
    public static DBInfoSystem GroQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "gro"
    }; // DBI 11 
    public static DBInfoSystem GroDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "gro"
    };
    public static DBInfoSystem GroQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "gro"
    }; // DBI 11 
    public static DBInfoSystem GroDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "gro"
    };
    public static DBInfoSystem GroVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "gro"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        GroSQLWhere = 1,
        GroNome = 2,
        GroOperador = 3,
        GroGUID = 4,
        GroQuemCad = 5,
        GroDtCad = 6,
        GroQuemAtu = 7,
        GroDtAtu = 8,
        GroVisto = 9
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.GroSQLWhere => GroSQLWhere,
        NomesCamposTabela.GroNome => GroNome,
        NomesCamposTabela.GroOperador => GroOperador,
        NomesCamposTabela.GroGUID => GroGUID,
        NomesCamposTabela.GroQuemCad => GroQuemCad,
        NomesCamposTabela.GroDtCad => GroDtCad,
        NomesCamposTabela.GroQuemAtu => GroQuemAtu,
        NomesCamposTabela.GroDtAtu => GroDtAtu,
        NomesCamposTabela.GroVisto => GroVisto,
        _ => null
    };
}