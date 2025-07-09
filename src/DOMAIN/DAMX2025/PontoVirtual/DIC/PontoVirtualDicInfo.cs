using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBPontoVirtualDicInfo
{
    public const string CampoCodigo = "pvtCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "pvt";
    public const string HoraEntrada = "pvtHoraEntrada"; // LOCALIZACAO 170523
    public const string HoraSaida = "pvtHoraSaida"; // LOCALIZACAO 170523
    public const string Operador = "pvtOperador"; // LOCALIZACAO 170523
    public const string Key = "pvtKey"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => HoraEntrada,
        2 => HoraSaida,
        3 => Operador,
        4 => Key,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "PontoVirtual";
#region PropriedadesDaTabela
    public static DBInfoSystem PvtHoraEntrada => new(0, PTabelaNome, CampoCodigo, HoraEntrada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem PvtHoraSaida => new(0, PTabelaNome, CampoCodigo, HoraSaida, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem PvtOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PvtKey => new(0, PTabelaNome, CampoCodigo, Key, 23, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);

#endregion
#region SMART_SQLServices 
    public static string HoraEntradaSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{HoraEntrada}]");
    public static string HoraEntradaSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{HoraEntrada}]");
    public static string HoraEntradaIsNull => HoraEntrada.SqlCmdIsNull() ?? string.Empty;
    public static string HoraEntradaNotIsNull => HoraEntrada.SqlCmdNotIsNull() ?? string.Empty;

    public static string HoraSaidaSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{HoraSaida}]");
    public static string HoraSaidaSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{HoraSaida}]");
    public static string HoraSaidaSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaIsNull => HoraSaida.SqlCmdIsNull() ?? string.Empty;
    public static string HoraSaidaNotIsNull => HoraSaida.SqlCmdNotIsNull() ?? string.Empty;

    public static string KeySql(string text) => Key.SqlCmdTextIgual(text, 23) ?? string.Empty;
    public static string KeySqlNotIsNull => Key.SqlCmdNotIsNull() ?? string.Empty;
    public static string KeySqlIsNull => Key.SqlCmdIsNull() ?? string.Empty;

    public static string KeySqlDiff(string text) => Key.SqlCmdTextDiff(text) ?? string.Empty;
    public static string KeySqlLike(string text) => Key.SqlCmdTextLike(text) ?? string.Empty;
    public static string KeySqlLikeInit(string text) => Key.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string KeySqlLikeSpaces(string? text) => Key.SqlCmdTextLikeSpaces(text) ?? string.Empty;
#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        PvtHoraEntrada = 1,
        PvtHoraSaida = 2,
        PvtOperador = 3,
        PvtKey = 4
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PvtHoraEntrada => PvtHoraEntrada,
        NomesCamposTabela.PvtHoraSaida => PvtHoraSaida,
        NomesCamposTabela.PvtOperador => PvtOperador,
        NomesCamposTabela.PvtKey => PvtKey,
        _ => null
    };
}