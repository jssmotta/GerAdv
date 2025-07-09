using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBContatoCRMViewDicInfo
{
    public const string CampoCodigo = "ccwCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ccw";
    public const string CGUID = "ccwCGUID"; // LOCALIZACAO 170523
    public const string Data = "ccwData"; // LOCALIZACAO 170523
    public const string IP = "ccwIP"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => CGUID,
        2 => Data,
        3 => IP,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ContatoCRMView";
#region PropriedadesDaTabela
    public static DBInfoSystem CcwCGUID => new(0, PTabelaNome, CampoCodigo, CGUID, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CcwData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CcwIP => new(0, PTabelaNome, CampoCodigo, IP, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);

#endregion
#region SMART_SQLServices 
    public static string CGUIDSql(string text) => CGUID.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string CGUIDSqlNotIsNull => CGUID.SqlCmdNotIsNull() ?? string.Empty;
    public static string CGUIDSqlIsNull => CGUID.SqlCmdIsNull() ?? string.Empty;

    public static string CGUIDSqlDiff(string text) => CGUID.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CGUIDSqlLike(string text) => CGUID.SqlCmdTextLike(text) ?? string.Empty;
    public static string CGUIDSqlLikeInit(string text) => CGUID.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CGUIDSqlLikeSpaces(string? text) => CGUID.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DataSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Data}]");
    public static string DataSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Data}]");
    public static string DataSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Data}]");
    public static string DataSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Data}]");
    public static string DataSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Data}]");
    public static string DataSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Data}]");
    public static string DataSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Data}]");
    public static string DataSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Data}]");
    public static string DataSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Data}]");
    public static string DataSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Data}]");
    public static string DataSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Data}]");
    public static string DataSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Data}]");
    public static string DataIsNull => Data.SqlCmdIsNull() ?? string.Empty;
    public static string DataNotIsNull => Data.SqlCmdNotIsNull() ?? string.Empty;

    public static string IPSql(string text) => IP.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string IPSqlNotIsNull => IP.SqlCmdNotIsNull() ?? string.Empty;
    public static string IPSqlIsNull => IP.SqlCmdIsNull() ?? string.Empty;

    public static string IPSqlDiff(string text) => IP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string IPSqlLike(string text) => IP.SqlCmdTextLike(text) ?? string.Empty;
    public static string IPSqlLikeInit(string text) => IP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string IPSqlLikeSpaces(string? text) => IP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        CcwCGUID = 1,
        CcwData = 2,
        CcwIP = 3
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CcwCGUID => CcwCGUID,
        NomesCamposTabela.CcwData => CcwData,
        NomesCamposTabela.CcwIP => CcwIP,
        _ => null
    };
}