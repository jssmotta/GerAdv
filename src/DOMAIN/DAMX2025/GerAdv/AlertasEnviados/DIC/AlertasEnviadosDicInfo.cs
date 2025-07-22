using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAlertasEnviadosDicInfo
{
    public const string CampoCodigo = "aloCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "alo";
    public const string Operador = "aloOperador"; // LOCALIZACAO 170523
    public const string Alerta = "aloAlerta"; // LOCALIZACAO 170523
    public const string DataAlertado = "aloDataAlertado"; // LOCALIZACAO 170523
    public const string Visualizado = "aloVisualizado"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Operador,
        2 => Alerta,
        3 => DataAlertado,
        4 => Visualizado,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AlertasEnviados";
#region PropriedadesDaTabela
    public static DBInfoSystem AloOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "alo"
    }; // DBI 11 
    public static DBInfoSystem AloAlerta => new(0, PTabelaNome, CampoCodigo, Alerta, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAlertasDicInfo.CampoCodigo, DBAlertasDicInfo.TabelaNome, new DBAlertasODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "alo"
    }; // DBI 11 
    public static DBInfoSystem AloDataAlertado => new(0, PTabelaNome, CampoCodigo, DataAlertado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "alo"
    };
    public static DBInfoSystem AloVisualizado => new(0, PTabelaNome, CampoCodigo, Visualizado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "alo"
    };

#endregion
#region SMART_SQLServices 
    public static string DataAlertadoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataAlertado}]");
    public static string DataAlertadoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataAlertado}]");
    public static string DataAlertadoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataAlertado}]");
    public static string DataAlertadoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataAlertado}]");
    public static string DataAlertadoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataAlertado}]");
    public static string DataAlertadoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataAlertado}]");
    public static string DataAlertadoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataAlertado}]");
    public static string DataAlertadoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataAlertado}]");
    public static string DataAlertadoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataAlertado}]");
    public static string DataAlertadoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataAlertado}]");
    public static string DataAlertadoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataAlertado}]");
    public static string DataAlertadoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataAlertado}]");
    public static string DataAlertadoIsNull => DataAlertado.SqlCmdIsNull() ?? string.Empty;
    public static string DataAlertadoNotIsNull => DataAlertado.SqlCmdNotIsNull() ?? string.Empty;

    public static string VisualizadoSql(bool valueCheck) => Visualizado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string VisualizadoSqlSim => Visualizado.SqlCmdBoolSim() ?? string.Empty;
    public static string VisualizadoSqlNao => Visualizado.SqlCmdBoolNao() ?? string.Empty;

#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        AloOperador = 1,
        AloAlerta = 2,
        AloDataAlertado = 3,
        AloVisualizado = 4
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AloOperador => AloOperador,
        NomesCamposTabela.AloAlerta => AloAlerta,
        NomesCamposTabela.AloDataAlertado => AloDataAlertado,
        NomesCamposTabela.AloVisualizado => AloVisualizado,
        _ => null
    };
}