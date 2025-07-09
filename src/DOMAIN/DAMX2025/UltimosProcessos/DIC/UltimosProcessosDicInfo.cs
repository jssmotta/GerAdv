using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBUltimosProcessosDicInfo
{
    public const string CampoCodigo = "ultCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ult";
    public const string Processo = "ultProcesso"; // LOCALIZACAO 170523
    public const string Quando = "ultQuando"; // LOCALIZACAO 170523
    public const string Quem = "ultQuem"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Quando,
        3 => Quem,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "UltimosProcessos";
#region PropriedadesDaTabela
    public static DBInfoSystem UltProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem UltQuando => new(0, PTabelaNome, CampoCodigo, Quando, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem UltQuem => new(0, PTabelaNome, CampoCodigo, Quem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);

#endregion
#region SMART_SQLServices 
    public static string QuandoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Quando}]");
    public static string QuandoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Quando}]");
    public static string QuandoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Quando}]");
    public static string QuandoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Quando}]");
    public static string QuandoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Quando}]");
    public static string QuandoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Quando}]");
    public static string QuandoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Quando}]");
    public static string QuandoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Quando}]");
    public static string QuandoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Quando}]");
    public static string QuandoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Quando}]");
    public static string QuandoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Quando}]");
    public static string QuandoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Quando}]");
    public static string QuandoIsNull => Quando.SqlCmdIsNull() ?? string.Empty;
    public static string QuandoNotIsNull => Quando.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        UltProcesso = 1,
        UltQuando = 2,
        UltQuem = 3
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.UltProcesso => UltProcesso,
        NomesCamposTabela.UltQuando => UltQuando,
        NomesCamposTabela.UltQuem => UltQuem,
        _ => null
    };
}