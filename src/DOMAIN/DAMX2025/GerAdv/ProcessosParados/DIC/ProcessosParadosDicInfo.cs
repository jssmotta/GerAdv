using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProcessosParadosDicInfo
{
    public const string CampoCodigo = "pprCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ppr";
    public const string Processo = "pprProcesso"; // LOCALIZACAO 170523
    public const string Semana = "pprSemana"; // LOCALIZACAO 170523
    public const string Ano = "pprAno"; // LOCALIZACAO 170523
    public const string DataHora = "pprDataHora"; // LOCALIZACAO 170523
    public const string Operador = "pprOperador"; // LOCALIZACAO 170523
    public const string DataHistorico = "pprDataHistorico"; // LOCALIZACAO 170523
    public const string DataNENotas = "pprDataNENotas"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Semana,
        3 => Ano,
        4 => DataHora,
        5 => Operador,
        6 => DataHistorico,
        7 => DataNENotas,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProcessosParados";
#region PropriedadesDaTabela
    public static DBInfoSystem PprProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "ppr"
    }; // DBI 11 
    public static DBInfoSystem PprSemana => new(0, PTabelaNome, CampoCodigo, Semana, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        IsRequired = true,
        Prefixo = "ppr"
    };
    public static DBInfoSystem PprAno => new(0, PTabelaNome, CampoCodigo, Ano, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        IsRequired = true,
        Prefixo = "ppr"
    };
    public static DBInfoSystem PprDataHora => new(0, PTabelaNome, CampoCodigo, DataHora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ppr"
    };
    public static DBInfoSystem PprOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ppr"
    }; // DBI 11 
    public static DBInfoSystem PprDataHistorico => new(0, PTabelaNome, CampoCodigo, DataHistorico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ppr"
    };
    public static DBInfoSystem PprDataNENotas => new(0, PTabelaNome, CampoCodigo, DataNENotas, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ppr"
    };

#endregion
#region SMART_SQLServices 
    public static string DataHoraSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataHora}]");
    public static string DataHoraSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataHora}]");
    public static string DataHoraSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataHora}]");
    public static string DataHoraSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataHora}]");
    public static string DataHoraSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataHora}]");
    public static string DataHoraSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataHora}]");
    public static string DataHoraSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataHora}]");
    public static string DataHoraSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataHora}]");
    public static string DataHoraSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataHora}]");
    public static string DataHoraSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataHora}]");
    public static string DataHoraSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataHora}]");
    public static string DataHoraSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataHora}]");
    public static string DataHoraIsNull => DataHora.SqlCmdIsNull() ?? string.Empty;
    public static string DataHoraNotIsNull => DataHora.SqlCmdNotIsNull() ?? string.Empty;

    public static string DataHistoricoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataHistorico}]");
    public static string DataHistoricoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataHistorico}]");
    public static string DataHistoricoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataHistorico}]");
    public static string DataHistoricoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataHistorico}]");
    public static string DataHistoricoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataHistorico}]");
    public static string DataHistoricoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataHistorico}]");
    public static string DataHistoricoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataHistorico}]");
    public static string DataHistoricoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataHistorico}]");
    public static string DataHistoricoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataHistorico}]");
    public static string DataHistoricoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataHistorico}]");
    public static string DataHistoricoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataHistorico}]");
    public static string DataHistoricoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataHistorico}]");
    public static string DataHistoricoIsNull => DataHistorico.SqlCmdIsNull() ?? string.Empty;
    public static string DataHistoricoNotIsNull => DataHistorico.SqlCmdNotIsNull() ?? string.Empty;

    public static string DataNENotasSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataNENotas}]");
    public static string DataNENotasSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataNENotas}]");
    public static string DataNENotasSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataNENotas}]");
    public static string DataNENotasSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataNENotas}]");
    public static string DataNENotasSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataNENotas}]");
    public static string DataNENotasSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataNENotas}]");
    public static string DataNENotasSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataNENotas}]");
    public static string DataNENotasSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataNENotas}]");
    public static string DataNENotasSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataNENotas}]");
    public static string DataNENotasSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataNENotas}]");
    public static string DataNENotasSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataNENotas}]");
    public static string DataNENotasSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataNENotas}]");
    public static string DataNENotasIsNull => DataNENotas.SqlCmdIsNull() ?? string.Empty;
    public static string DataNENotasNotIsNull => DataNENotas.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        PprProcesso = 1,
        PprSemana = 2,
        PprAno = 3,
        PprDataHora = 4,
        PprOperador = 5,
        PprDataHistorico = 6,
        PprDataNENotas = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PprProcesso => PprProcesso,
        NomesCamposTabela.PprSemana => PprSemana,
        NomesCamposTabela.PprAno => PprAno,
        NomesCamposTabela.PprDataHora => PprDataHora,
        NomesCamposTabela.PprOperador => PprOperador,
        NomesCamposTabela.PprDataHistorico => PprDataHistorico,
        NomesCamposTabela.PprDataNENotas => PprDataNENotas,
        _ => null
    };
}