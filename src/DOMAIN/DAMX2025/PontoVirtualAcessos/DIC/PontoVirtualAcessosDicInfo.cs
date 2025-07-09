using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBPontoVirtualAcessosDicInfo
{
    public const string CampoCodigo = "pvaCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "pva";
    public const string Operador = "pvaOperador"; // LOCALIZACAO 170523
    public const string DataHora = "pvaDataHora"; // LOCALIZACAO 170523
    public const string Tipo = "pvaTipo"; // LOCALIZACAO 170523
    public const string Origem = "pvaOrigem"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Operador,
        2 => DataHora,
        3 => Tipo,
        4 => Origem,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "PontoVirtualAcessos";
#region PropriedadesDaTabela
    public static DBInfoSystem PvaOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PvaDataHora => new(0, PTabelaNome, CampoCodigo, DataHora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem PvaTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa);
    public static DBInfoSystem PvaOrigem => new(0, PTabelaNome, CampoCodigo, Origem, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);

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

    public static string TipoSql(bool valueCheck) => Tipo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TipoSqlSim => Tipo.SqlCmdBoolSim() ?? string.Empty;
    public static string TipoSqlNao => Tipo.SqlCmdBoolNao() ?? string.Empty;

    public static string OrigemSql(string text) => Origem.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string OrigemSqlNotIsNull => Origem.SqlCmdNotIsNull() ?? string.Empty;
    public static string OrigemSqlIsNull => Origem.SqlCmdIsNull() ?? string.Empty;

    public static string OrigemSqlDiff(string text) => Origem.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OrigemSqlLike(string text) => Origem.SqlCmdTextLike(text) ?? string.Empty;
    public static string OrigemSqlLikeInit(string text) => Origem.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OrigemSqlLikeSpaces(string? text) => Origem.SqlCmdTextLikeSpaces(text) ?? string.Empty;
#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        PvaOperador = 1,
        PvaDataHora = 2,
        PvaTipo = 3,
        PvaOrigem = 4
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PvaOperador => PvaOperador,
        NomesCamposTabela.PvaDataHora => PvaDataHora,
        NomesCamposTabela.PvaTipo => PvaTipo,
        NomesCamposTabela.PvaOrigem => PvaOrigem,
        _ => null
    };
}