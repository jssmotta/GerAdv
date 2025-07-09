using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAgendaRepetirDiasDicInfo
{
    public const string CampoCodigo = "rpdCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "rpd";
    public const string HoraFinal = "rpdHoraFinal"; // LOCALIZACAO 170523
    public const string Master = "rpdMaster"; // LOCALIZACAO 170523
    public const string Dia = "rpdDia"; // LOCALIZACAO 170523
    public const string Hora = "rpdHora"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => HoraFinal,
        2 => Master,
        3 => Dia,
        4 => Hora,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaRepetirDias";
#region PropriedadesDaTabela
    public static DBInfoSystem RpdHoraFinal => new(0, PTabelaNome, CampoCodigo, HoraFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RpdMaster => new(0, PTabelaNome, CampoCodigo, Master, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RpdDia => new(0, PTabelaNome, CampoCodigo, Dia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RpdHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);

#endregion
#region SMART_SQLServices 
    public static string HoraFinalSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{HoraFinal}]");
    public static string HoraFinalSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{HoraFinal}]");
    public static string HoraFinalSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{HoraFinal}]");
    public static string HoraFinalSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{HoraFinal}]");
    public static string HoraFinalSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{HoraFinal}]");
    public static string HoraFinalSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{HoraFinal}]");
    public static string HoraFinalSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{HoraFinal}]");
    public static string HoraFinalSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{HoraFinal}]");
    public static string HoraFinalSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{HoraFinal}]");
    public static string HoraFinalSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{HoraFinal}]");
    public static string HoraFinalSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{HoraFinal}]");
    public static string HoraFinalSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{HoraFinal}]");
    public static string HoraFinalIsNull => HoraFinal.SqlCmdIsNull() ?? string.Empty;
    public static string HoraFinalNotIsNull => HoraFinal.SqlCmdNotIsNull() ?? string.Empty;

    public static string HoraSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Hora}]");
    public static string HoraSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Hora}]");
    public static string HoraSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Hora}]");
    public static string HoraSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Hora}]");
    public static string HoraSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Hora}]");
    public static string HoraSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Hora}]");
    public static string HoraSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Hora}]");
    public static string HoraSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Hora}]");
    public static string HoraSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Hora}]");
    public static string HoraSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Hora}]");
    public static string HoraSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Hora}]");
    public static string HoraSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Hora}]");
    public static string HoraIsNull => Hora.SqlCmdIsNull() ?? string.Empty;
    public static string HoraNotIsNull => Hora.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        RpdHoraFinal = 1,
        RpdMaster = 2,
        RpdDia = 3,
        RpdHora = 4
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RpdHoraFinal => RpdHoraFinal,
        NomesCamposTabela.RpdMaster => RpdMaster,
        NomesCamposTabela.RpdDia => RpdDia,
        NomesCamposTabela.RpdHora => RpdHora,
        _ => null
    };
}