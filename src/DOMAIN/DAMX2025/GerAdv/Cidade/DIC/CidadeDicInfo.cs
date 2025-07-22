using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBCidadeDicInfo
{
    public const string CampoCodigo = "cidCodigo";
    public const string CampoNome = "cidNome";
    public const string TablePrefix = "cid";
    public const string DDD = "cidDDD"; // LOCALIZACAO 170523
    public const string Top = "cidTop"; // LOCALIZACAO 170523
    public const string Comarca = "cidComarca"; // LOCALIZACAO 170523
    public const string Capital = "cidCapital"; // LOCALIZACAO 170523
    public const string Nome = "cidNome"; // LOCALIZACAO 170523
    public const string UF = "cidUF"; // LOCALIZACAO 170523
    public const string Sigla = "cidSigla"; // LOCALIZACAO 170523
    public const string GUID = "cidGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "cidQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "cidDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "cidQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "cidDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "cidVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => DDD,
        2 => Top,
        3 => Comarca,
        4 => Capital,
        5 => Nome,
        6 => UF,
        7 => Sigla,
        8 => GUID,
        9 => QuemCad,
        10 => DtCad,
        11 => QuemAtu,
        12 => DtAtu,
        13 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Cidade";
#region PropriedadesDaTabela
    public static DBInfoSystem CidDDD => new(0, PTabelaNome, CampoCodigo, DDD, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cid"
    };
    public static DBInfoSystem CidTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cid"
    };
    public static DBInfoSystem CidComarca => new(0, PTabelaNome, CampoCodigo, Comarca, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cid"
    };
    public static DBInfoSystem CidCapital => new(0, PTabelaNome, CampoCodigo, Capital, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cid"
    };
    public static DBInfoSystem CidNome => new(0, PTabelaNome, CampoCodigo, Nome, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "cid"
    };
    public static DBInfoSystem CidUF => new(0, PTabelaNome, CampoCodigo, UF, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBUFDicInfo.CampoCodigo, DBUFDicInfo.TabelaNome, new DBUFODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "cid"
    }; // DBI 11 
    public static DBInfoSystem CidSigla => new(0, PTabelaNome, CampoCodigo, Sigla, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cid"
    };
    public static DBInfoSystem CidGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "cid"
    };
    public static DBInfoSystem CidQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "cid"
    }; // DBI 11 
    public static DBInfoSystem CidDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "cid"
    };
    public static DBInfoSystem CidQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "cid"
    }; // DBI 11 
    public static DBInfoSystem CidDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "cid"
    };
    public static DBInfoSystem CidVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "cid"
    };

#endregion
#region SMART_SQLServices 
    public static string DDDSql(string text) => DDD.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string DDDSqlNotIsNull => DDD.SqlCmdNotIsNull() ?? string.Empty;
    public static string DDDSqlIsNull => DDD.SqlCmdIsNull() ?? string.Empty;

    public static string DDDSqlDiff(string text) => DDD.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DDDSqlLike(string text) => DDD.SqlCmdTextLike(text) ?? string.Empty;
    public static string DDDSqlLikeInit(string text) => DDD.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DDDSqlLikeSpaces(string? text) => DDD.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TopSql(bool valueCheck) => Top.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TopSqlSim => Top.SqlCmdBoolSim() ?? string.Empty;
    public static string TopSqlNao => Top.SqlCmdBoolNao() ?? string.Empty;

    public static string ComarcaSql(bool valueCheck) => Comarca.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ComarcaSqlSim => Comarca.SqlCmdBoolSim() ?? string.Empty;
    public static string ComarcaSqlNao => Comarca.SqlCmdBoolNao() ?? string.Empty;

    public static string CapitalSql(bool valueCheck) => Capital.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string CapitalSqlSim => Capital.SqlCmdBoolSim() ?? string.Empty;
    public static string CapitalSqlNao => Capital.SqlCmdBoolNao() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 40) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SiglaSql(string text) => Sigla.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string SiglaSqlNotIsNull => Sigla.SqlCmdNotIsNull() ?? string.Empty;
    public static string SiglaSqlIsNull => Sigla.SqlCmdIsNull() ?? string.Empty;

    public static string SiglaSqlDiff(string text) => Sigla.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SiglaSqlLike(string text) => Sigla.SqlCmdTextLike(text) ?? string.Empty;
    public static string SiglaSqlLikeInit(string text) => Sigla.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SiglaSqlLikeSpaces(string? text) => Sigla.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string DtCadSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtCad}]");
    public static string DtCadSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtCad}]");
    public static string DtCadSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtCad}]");
    public static string DtCadSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtCad}]");
    public static string DtCadIsNull => DtCad.SqlCmdIsNull() ?? string.Empty;
    public static string DtCadNotIsNull => DtCad.SqlCmdNotIsNull() ?? string.Empty;

    public static string DtAtuSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtAtu}]");
    public static string DtAtuSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtAtu}]");
    public static string DtAtuSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtAtu}]");
    public static string DtAtuIsNull => DtAtu.SqlCmdIsNull() ?? string.Empty;
    public static string DtAtuNotIsNull => DtAtu.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        CidDDD = 1,
        CidTop = 2,
        CidComarca = 3,
        CidCapital = 4,
        CidNome = 5,
        CidUF = 6,
        CidSigla = 7,
        CidGUID = 8,
        CidQuemCad = 9,
        CidDtCad = 10,
        CidQuemAtu = 11,
        CidDtAtu = 12,
        CidVisto = 13
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CidDDD => CidDDD,
        NomesCamposTabela.CidTop => CidTop,
        NomesCamposTabela.CidComarca => CidComarca,
        NomesCamposTabela.CidCapital => CidCapital,
        NomesCamposTabela.CidNome => CidNome,
        NomesCamposTabela.CidUF => CidUF,
        NomesCamposTabela.CidSigla => CidSigla,
        NomesCamposTabela.CidGUID => CidGUID,
        NomesCamposTabela.CidQuemCad => CidQuemCad,
        NomesCamposTabela.CidDtCad => CidDtCad,
        NomesCamposTabela.CidQuemAtu => CidQuemAtu,
        NomesCamposTabela.CidDtAtu => CidDtAtu,
        NomesCamposTabela.CidVisto => CidVisto,
        _ => null
    };
}