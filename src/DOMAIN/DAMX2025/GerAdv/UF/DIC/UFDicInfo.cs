using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBUFDicInfo
{
    public const string CampoCodigo = "ufCodigo";
    public const string CampoNome = "ufID";
    public const string TablePrefix = "uf";
    public const string DDD = "ufDDD"; // LOCALIZACAO 170523
    public const string ID = "ufID"; // LOCALIZACAO 170523
    public const string Pais = "ufPais"; // LOCALIZACAO 170523
    public const string Top = "ufTop"; // LOCALIZACAO 170523
    public const string Descricao = "ufDescricao"; // LOCALIZACAO 170523
    public const string GUID = "ufGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ufQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ufDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ufQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ufDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ufVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => DDD,
        2 => ID,
        3 => Pais,
        4 => Top,
        5 => Descricao,
        6 => GUID,
        7 => QuemCad,
        8 => DtCad,
        9 => QuemAtu,
        10 => DtAtu,
        11 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "UF";
#region PropriedadesDaTabela
    public static DBInfoSystem UfDDD => new(0, PTabelaNome, CampoCodigo, DDD, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfID => new(0, PTabelaNome, CampoCodigo, ID, 4, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfPais => new(0, PTabelaNome, CampoCodigo, Pais, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPaisesDicInfo.CampoCodigo, DBPaisesDicInfo.TabelaNome, new DBPaisesODicInfo(), false)
    {
        Prefixo = "uf"
    }; // DBI 11 
    public static DBInfoSystem UfTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "uf"
    };
    public static DBInfoSystem UfDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "uf"
    }; // DBI 11 
    public static DBInfoSystem UfDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "uf"
    }; // DBI 11 
    public static DBInfoSystem UfDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "uf"
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
    public static string IDSql(string text) => ID.SqlCmdTextIgual(text, 4) ?? string.Empty;
    public static string IDSqlNotIsNull => ID.SqlCmdNotIsNull() ?? string.Empty;
    public static string IDSqlIsNull => ID.SqlCmdIsNull() ?? string.Empty;

    public static string IDSqlDiff(string text) => ID.SqlCmdTextDiff(text) ?? string.Empty;
    public static string IDSqlLike(string text) => ID.SqlCmdTextLike(text) ?? string.Empty;
    public static string IDSqlLikeInit(string text) => ID.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string IDSqlLikeSpaces(string? text) => ID.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TopSql(bool valueCheck) => Top.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TopSqlSim => Top.SqlCmdBoolSim() ?? string.Empty;
    public static string TopSqlNao => Top.SqlCmdBoolNao() ?? string.Empty;

    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text, 40) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        UfDDD = 1,
        UfID = 2,
        UfPais = 3,
        UfTop = 4,
        UfDescricao = 5,
        UfGUID = 6,
        UfQuemCad = 7,
        UfDtCad = 8,
        UfQuemAtu = 9,
        UfDtAtu = 10,
        UfVisto = 11
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.UfDDD => UfDDD,
        NomesCamposTabela.UfID => UfID,
        NomesCamposTabela.UfPais => UfPais,
        NomesCamposTabela.UfTop => UfTop,
        NomesCamposTabela.UfDescricao => UfDescricao,
        NomesCamposTabela.UfGUID => UfGUID,
        NomesCamposTabela.UfQuemCad => UfQuemCad,
        NomesCamposTabela.UfDtCad => UfDtCad,
        NomesCamposTabela.UfQuemAtu => UfQuemAtu,
        NomesCamposTabela.UfDtAtu => UfDtAtu,
        NomesCamposTabela.UfVisto => UfVisto,
        _ => null
    };
}