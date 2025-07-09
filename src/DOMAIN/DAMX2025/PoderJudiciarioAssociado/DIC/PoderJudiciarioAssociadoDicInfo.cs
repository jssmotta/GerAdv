using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBPoderJudiciarioAssociadoDicInfo
{
    public const string CampoCodigo = "pjaCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "pja";
    public const string Justica = "pjaJustica"; // LOCALIZACAO 170523
    public const string JusticaNome = "pjaJusticaNome"; // LOCALIZACAO 170523
    public const string Area = "pjaArea"; // LOCALIZACAO 170523
    public const string AreaNome = "pjaAreaNome"; // LOCALIZACAO 170523
    public const string Tribunal = "pjaTribunal"; // LOCALIZACAO 170523
    public const string TribunalNome = "pjaTribunalNome"; // LOCALIZACAO 170523
    public const string Foro = "pjaForo"; // LOCALIZACAO 170523
    public const string ForoNome = "pjaForoNome"; // LOCALIZACAO 170523
    public const string Cidade = "pjaCidade"; // LOCALIZACAO 170523
    public const string SubDivisaoNome = "pjaSubDivisaoNome"; // LOCALIZACAO 170523
    public const string CidadeNome = "pjaCidadeNome"; // LOCALIZACAO 170523
    public const string SubDivisao = "pjaSubDivisao"; // LOCALIZACAO 170523
    public const string Tipo = "pjaTipo"; // LOCALIZACAO 170523
    public const string GUID = "pjaGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "pjaQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "pjaDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "pjaQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "pjaDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "pjaVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Justica,
        2 => JusticaNome,
        3 => Area,
        4 => AreaNome,
        5 => Tribunal,
        6 => TribunalNome,
        7 => Foro,
        8 => ForoNome,
        9 => Cidade,
        10 => SubDivisaoNome,
        11 => CidadeNome,
        12 => SubDivisao,
        13 => Tipo,
        14 => GUID,
        15 => QuemCad,
        16 => DtCad,
        17 => QuemAtu,
        18 => DtAtu,
        19 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "PoderJudiciarioAssociado";
#region PropriedadesDaTabela
    public static DBInfoSystem PjaJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false); // DBI 11 
    public static DBInfoSystem PjaJusticaNome => new(0, PTabelaNome, CampoCodigo, JusticaNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PjaArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false); // DBI 11 
    public static DBInfoSystem PjaAreaNome => new(0, PTabelaNome, CampoCodigo, AreaNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PjaTribunal => new(0, PTabelaNome, CampoCodigo, Tribunal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTribunalDicInfo.CampoCodigo, DBTribunalDicInfo.TabelaNome, new DBTribunalODicInfo(), false); // DBI 11 
    public static DBInfoSystem PjaTribunalNome => new(0, PTabelaNome, CampoCodigo, TribunalNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PjaForo => new(0, PTabelaNome, CampoCodigo, Foro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBForoDicInfo.CampoCodigo, DBForoDicInfo.TabelaNome, new DBForoODicInfo(), false); // DBI 11 
    public static DBInfoSystem PjaForoNome => new(0, PTabelaNome, CampoCodigo, ForoNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PjaCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false); // DBI 11 
    public static DBInfoSystem PjaSubDivisaoNome => new(0, PTabelaNome, CampoCodigo, SubDivisaoNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PjaCidadeNome => new(0, PTabelaNome, CampoCodigo, CidadeNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PjaSubDivisao => new(0, PTabelaNome, CampoCodigo, SubDivisao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem PjaTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem PjaGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem PjaQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PjaDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem PjaQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PjaDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem PjaVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string JusticaNomeSql(string text) => JusticaNome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string JusticaNomeSqlNotIsNull => JusticaNome.SqlCmdNotIsNull() ?? string.Empty;
    public static string JusticaNomeSqlIsNull => JusticaNome.SqlCmdIsNull() ?? string.Empty;

    public static string JusticaNomeSqlDiff(string text) => JusticaNome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string JusticaNomeSqlLike(string text) => JusticaNome.SqlCmdTextLike(text) ?? string.Empty;
    public static string JusticaNomeSqlLikeInit(string text) => JusticaNome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string JusticaNomeSqlLikeSpaces(string? text) => JusticaNome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AreaNomeSql(string text) => AreaNome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string AreaNomeSqlNotIsNull => AreaNome.SqlCmdNotIsNull() ?? string.Empty;
    public static string AreaNomeSqlIsNull => AreaNome.SqlCmdIsNull() ?? string.Empty;

    public static string AreaNomeSqlDiff(string text) => AreaNome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AreaNomeSqlLike(string text) => AreaNome.SqlCmdTextLike(text) ?? string.Empty;
    public static string AreaNomeSqlLikeInit(string text) => AreaNome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AreaNomeSqlLikeSpaces(string? text) => AreaNome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TribunalNomeSql(string text) => TribunalNome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string TribunalNomeSqlNotIsNull => TribunalNome.SqlCmdNotIsNull() ?? string.Empty;
    public static string TribunalNomeSqlIsNull => TribunalNome.SqlCmdIsNull() ?? string.Empty;

    public static string TribunalNomeSqlDiff(string text) => TribunalNome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string TribunalNomeSqlLike(string text) => TribunalNome.SqlCmdTextLike(text) ?? string.Empty;
    public static string TribunalNomeSqlLikeInit(string text) => TribunalNome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string TribunalNomeSqlLikeSpaces(string? text) => TribunalNome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ForoNomeSql(string text) => ForoNome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string ForoNomeSqlNotIsNull => ForoNome.SqlCmdNotIsNull() ?? string.Empty;
    public static string ForoNomeSqlIsNull => ForoNome.SqlCmdIsNull() ?? string.Empty;

    public static string ForoNomeSqlDiff(string text) => ForoNome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ForoNomeSqlLike(string text) => ForoNome.SqlCmdTextLike(text) ?? string.Empty;
    public static string ForoNomeSqlLikeInit(string text) => ForoNome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ForoNomeSqlLikeSpaces(string? text) => ForoNome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SubDivisaoNomeSql(string text) => SubDivisaoNome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string SubDivisaoNomeSqlNotIsNull => SubDivisaoNome.SqlCmdNotIsNull() ?? string.Empty;
    public static string SubDivisaoNomeSqlIsNull => SubDivisaoNome.SqlCmdIsNull() ?? string.Empty;

    public static string SubDivisaoNomeSqlDiff(string text) => SubDivisaoNome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SubDivisaoNomeSqlLike(string text) => SubDivisaoNome.SqlCmdTextLike(text) ?? string.Empty;
    public static string SubDivisaoNomeSqlLikeInit(string text) => SubDivisaoNome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SubDivisaoNomeSqlLikeSpaces(string? text) => SubDivisaoNome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CidadeNomeSql(string text) => CidadeNome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string CidadeNomeSqlNotIsNull => CidadeNome.SqlCmdNotIsNull() ?? string.Empty;
    public static string CidadeNomeSqlIsNull => CidadeNome.SqlCmdIsNull() ?? string.Empty;

    public static string CidadeNomeSqlDiff(string text) => CidadeNome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CidadeNomeSqlLike(string text) => CidadeNome.SqlCmdTextLike(text) ?? string.Empty;
    public static string CidadeNomeSqlLikeInit(string text) => CidadeNome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CidadeNomeSqlLikeSpaces(string? text) => CidadeNome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        PjaJustica = 1,
        PjaJusticaNome = 2,
        PjaArea = 3,
        PjaAreaNome = 4,
        PjaTribunal = 5,
        PjaTribunalNome = 6,
        PjaForo = 7,
        PjaForoNome = 8,
        PjaCidade = 9,
        PjaSubDivisaoNome = 10,
        PjaCidadeNome = 11,
        PjaSubDivisao = 12,
        PjaTipo = 13,
        PjaGUID = 14,
        PjaQuemCad = 15,
        PjaDtCad = 16,
        PjaQuemAtu = 17,
        PjaDtAtu = 18,
        PjaVisto = 19
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PjaJustica => PjaJustica,
        NomesCamposTabela.PjaJusticaNome => PjaJusticaNome,
        NomesCamposTabela.PjaArea => PjaArea,
        NomesCamposTabela.PjaAreaNome => PjaAreaNome,
        NomesCamposTabela.PjaTribunal => PjaTribunal,
        NomesCamposTabela.PjaTribunalNome => PjaTribunalNome,
        NomesCamposTabela.PjaForo => PjaForo,
        NomesCamposTabela.PjaForoNome => PjaForoNome,
        NomesCamposTabela.PjaCidade => PjaCidade,
        NomesCamposTabela.PjaSubDivisaoNome => PjaSubDivisaoNome,
        NomesCamposTabela.PjaCidadeNome => PjaCidadeNome,
        NomesCamposTabela.PjaSubDivisao => PjaSubDivisao,
        NomesCamposTabela.PjaTipo => PjaTipo,
        NomesCamposTabela.PjaGUID => PjaGUID,
        NomesCamposTabela.PjaQuemCad => PjaQuemCad,
        NomesCamposTabela.PjaDtCad => PjaDtCad,
        NomesCamposTabela.PjaQuemAtu => PjaQuemAtu,
        NomesCamposTabela.PjaDtAtu => PjaDtAtu,
        NomesCamposTabela.PjaVisto => PjaVisto,
        _ => null
    };
}