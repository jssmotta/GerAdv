using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAgendaRecordsDicInfo
{
    public const string CampoCodigo = "ragCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "rag";
    public const string Agenda = "ragAgenda"; // LOCALIZACAO 170523
    public const string Julgador = "ragJulgador"; // LOCALIZACAO 170523
    public const string ClientesSocios = "ragClientesSocios"; // LOCALIZACAO 170523
    public const string Perito = "ragPerito"; // LOCALIZACAO 170523
    public const string Colaborador = "ragColaborador"; // LOCALIZACAO 170523
    public const string Foro = "ragForo"; // LOCALIZACAO 170523
    public const string Aviso1 = "ragAviso1"; // LOCALIZACAO 170523
    public const string Aviso2 = "ragAviso2"; // LOCALIZACAO 170523
    public const string Aviso3 = "ragAviso3"; // LOCALIZACAO 170523
    public const string CrmAviso1 = "ragCrmAviso1"; // LOCALIZACAO 170523
    public const string CrmAviso2 = "ragCrmAviso2"; // LOCALIZACAO 170523
    public const string CrmAviso3 = "ragCrmAviso3"; // LOCALIZACAO 170523
    public const string DataAviso1 = "ragDataAviso1"; // LOCALIZACAO 170523
    public const string DataAviso2 = "ragDataAviso2"; // LOCALIZACAO 170523
    public const string DataAviso3 = "ragDataAviso3"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Agenda,
        2 => Julgador,
        3 => ClientesSocios,
        4 => Perito,
        5 => Colaborador,
        6 => Foro,
        7 => Aviso1,
        8 => Aviso2,
        9 => Aviso3,
        10 => CrmAviso1,
        11 => CrmAviso2,
        12 => CrmAviso3,
        13 => DataAviso1,
        14 => DataAviso2,
        15 => DataAviso3,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaRecords";
#region PropriedadesDaTabela
    public static DBInfoSystem RagAgenda => new(0, PTabelaNome, CampoCodigo, Agenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAgendaDicInfo.CampoCodigo, DBAgendaDicInfo.TabelaNome, new DBAgendaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "rag"
    }; // DBI 11 
    public static DBInfoSystem RagJulgador => new(0, PTabelaNome, CampoCodigo, Julgador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagClientesSocios => new(0, PTabelaNome, CampoCodigo, ClientesSocios, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesSociosDicInfo.CampoCodigo, DBClientesSociosDicInfo.TabelaNome, new DBClientesSociosODicInfo(), false)
    {
        Prefixo = "rag"
    }; // DBI 11 
    public static DBInfoSystem RagPerito => new(0, PTabelaNome, CampoCodigo, Perito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagColaborador => new(0, PTabelaNome, CampoCodigo, Colaborador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBColaboradoresDicInfo.CampoCodigo, DBColaboradoresDicInfo.TabelaNome, new DBColaboradoresODicInfo(), false)
    {
        Prefixo = "rag"
    }; // DBI 11 
    public static DBInfoSystem RagForo => new(0, PTabelaNome, CampoCodigo, Foro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBForoDicInfo.CampoCodigo, DBForoDicInfo.TabelaNome, new DBForoODicInfo(), false)
    {
        Prefixo = "rag"
    }; // DBI 11 
    public static DBInfoSystem RagAviso1 => new(0, PTabelaNome, CampoCodigo, Aviso1, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagAviso2 => new(0, PTabelaNome, CampoCodigo, Aviso2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagAviso3 => new(0, PTabelaNome, CampoCodigo, Aviso3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagCrmAviso1 => new(0, PTabelaNome, CampoCodigo, CrmAviso1, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagCrmAviso2 => new(0, PTabelaNome, CampoCodigo, CrmAviso2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagCrmAviso3 => new(0, PTabelaNome, CampoCodigo, CrmAviso3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagDataAviso1 => new(0, PTabelaNome, CampoCodigo, DataAviso1, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagDataAviso2 => new(0, PTabelaNome, CampoCodigo, DataAviso2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagDataAviso3 => new(0, PTabelaNome, CampoCodigo, DataAviso3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "rag"
    };

#endregion
#region SMART_SQLServices 
    public static string Aviso1Sql(bool valueCheck) => Aviso1.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string Aviso1SqlSim => Aviso1.SqlCmdBoolSim() ?? string.Empty;
    public static string Aviso1SqlNao => Aviso1.SqlCmdBoolNao() ?? string.Empty;

    public static string Aviso2Sql(bool valueCheck) => Aviso2.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string Aviso2SqlSim => Aviso2.SqlCmdBoolSim() ?? string.Empty;
    public static string Aviso2SqlNao => Aviso2.SqlCmdBoolNao() ?? string.Empty;

    public static string Aviso3Sql(bool valueCheck) => Aviso3.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string Aviso3SqlSim => Aviso3.SqlCmdBoolSim() ?? string.Empty;
    public static string Aviso3SqlNao => Aviso3.SqlCmdBoolNao() ?? string.Empty;

    public static string DataAviso1SqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataAviso1}]");
    public static string DataAviso1SqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataAviso1}]");
    public static string DataAviso1SqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataAviso1}]");
    public static string DataAviso1SqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataAviso1}]");
    public static string DataAviso1SqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataAviso1}]");
    public static string DataAviso1SqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataAviso1}]");
    public static string DataAviso1SqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataAviso1}]");
    public static string DataAviso1SqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataAviso1}]");
    public static string DataAviso1SqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataAviso1}]");
    public static string DataAviso1SqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataAviso1}]");
    public static string DataAviso1SqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataAviso1}]");
    public static string DataAviso1SqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataAviso1}]");
    public static string DataAviso1IsNull => DataAviso1.SqlCmdIsNull() ?? string.Empty;
    public static string DataAviso1NotIsNull => DataAviso1.SqlCmdNotIsNull() ?? string.Empty;

    public static string DataAviso2SqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataAviso2}]");
    public static string DataAviso2SqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataAviso2}]");
    public static string DataAviso2SqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataAviso2}]");
    public static string DataAviso2SqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataAviso2}]");
    public static string DataAviso2SqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataAviso2}]");
    public static string DataAviso2SqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataAviso2}]");
    public static string DataAviso2SqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataAviso2}]");
    public static string DataAviso2SqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataAviso2}]");
    public static string DataAviso2SqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataAviso2}]");
    public static string DataAviso2SqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataAviso2}]");
    public static string DataAviso2SqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataAviso2}]");
    public static string DataAviso2SqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataAviso2}]");
    public static string DataAviso2IsNull => DataAviso2.SqlCmdIsNull() ?? string.Empty;
    public static string DataAviso2NotIsNull => DataAviso2.SqlCmdNotIsNull() ?? string.Empty;

    public static string DataAviso3SqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataAviso3}]");
    public static string DataAviso3SqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataAviso3}]");
    public static string DataAviso3SqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataAviso3}]");
    public static string DataAviso3SqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataAviso3}]");
    public static string DataAviso3SqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataAviso3}]");
    public static string DataAviso3SqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataAviso3}]");
    public static string DataAviso3SqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataAviso3}]");
    public static string DataAviso3SqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataAviso3}]");
    public static string DataAviso3SqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataAviso3}]");
    public static string DataAviso3SqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataAviso3}]");
    public static string DataAviso3SqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataAviso3}]");
    public static string DataAviso3SqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataAviso3}]");
    public static string DataAviso3IsNull => DataAviso3.SqlCmdIsNull() ?? string.Empty;
    public static string DataAviso3NotIsNull => DataAviso3.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        RagAgenda = 1,
        RagJulgador = 2,
        RagClientesSocios = 3,
        RagPerito = 4,
        RagColaborador = 5,
        RagForo = 6,
        RagAviso1 = 7,
        RagAviso2 = 8,
        RagAviso3 = 9,
        RagCrmAviso1 = 10,
        RagCrmAviso2 = 11,
        RagCrmAviso3 = 12,
        RagDataAviso1 = 13,
        RagDataAviso2 = 14,
        RagDataAviso3 = 15
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RagAgenda => RagAgenda,
        NomesCamposTabela.RagJulgador => RagJulgador,
        NomesCamposTabela.RagClientesSocios => RagClientesSocios,
        NomesCamposTabela.RagPerito => RagPerito,
        NomesCamposTabela.RagColaborador => RagColaborador,
        NomesCamposTabela.RagForo => RagForo,
        NomesCamposTabela.RagAviso1 => RagAviso1,
        NomesCamposTabela.RagAviso2 => RagAviso2,
        NomesCamposTabela.RagAviso3 => RagAviso3,
        NomesCamposTabela.RagCrmAviso1 => RagCrmAviso1,
        NomesCamposTabela.RagCrmAviso2 => RagCrmAviso2,
        NomesCamposTabela.RagCrmAviso3 => RagCrmAviso3,
        NomesCamposTabela.RagDataAviso1 => RagDataAviso1,
        NomesCamposTabela.RagDataAviso2 => RagDataAviso2,
        NomesCamposTabela.RagDataAviso3 => RagDataAviso3,
        _ => null
    };
}