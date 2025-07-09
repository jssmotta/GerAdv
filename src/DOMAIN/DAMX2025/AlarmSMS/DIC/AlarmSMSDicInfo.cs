using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAlarmSMSDicInfo
{
    public const string CampoCodigo = "alrCodigo";
    public const string CampoNome = "alrDescricao";
    public const string TablePrefix = "alr";
    public const string Descricao = "alrDescricao"; // LOCALIZACAO 170523
    public const string Hora = "alrHora"; // LOCALIZACAO 170523
    public const string Minuto = "alrMinuto"; // LOCALIZACAO 170523
    public const string D1 = "alrD1"; // LOCALIZACAO 170523
    public const string D2 = "alrD2"; // LOCALIZACAO 170523
    public const string D3 = "alrD3"; // LOCALIZACAO 170523
    public const string D4 = "alrD4"; // LOCALIZACAO 170523
    public const string D5 = "alrD5"; // LOCALIZACAO 170523
    public const string D6 = "alrD6"; // LOCALIZACAO 170523
    public const string D7 = "alrD7"; // LOCALIZACAO 170523
    public const string EMail = "alrEMail"; // LOCALIZACAO 170523
    public const string Desativar = "alrDesativar"; // LOCALIZACAO 170523
    public const string Today = "alrToday"; // LOCALIZACAO 170523
    public const string ExcetoDiasFelizes = "alrExcetoDiasFelizes"; // LOCALIZACAO 170523
    public const string Desktop = "alrDesktop"; // LOCALIZACAO 170523
    public const string AlertarDataHora = "alrAlertarDataHora"; // LOCALIZACAO 170523
    public const string Operador = "alrOperador"; // LOCALIZACAO 170523
    public const string GuidExo = "alrGuidExo"; // LOCALIZACAO 170523
    public const string Agenda = "alrAgenda"; // LOCALIZACAO 170523
    public const string Recado = "alrRecado"; // LOCALIZACAO 170523
    public const string Emocao = "alrEmocao"; // LOCALIZACAO 170523
    public const string GUID = "alrGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "alrQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "alrDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "alrQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "alrDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "alrVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
        2 => Hora,
        3 => Minuto,
        4 => D1,
        5 => D2,
        6 => D3,
        7 => D4,
        8 => D5,
        9 => D6,
        10 => D7,
        11 => EMail,
        12 => Desativar,
        13 => Today,
        14 => ExcetoDiasFelizes,
        15 => Desktop,
        16 => AlertarDataHora,
        17 => Operador,
        18 => GuidExo,
        19 => Agenda,
        20 => Recado,
        21 => Emocao,
        22 => GUID,
        23 => QuemCad,
        24 => DtCad,
        25 => QuemAtu,
        26 => DtAtu,
        27 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AlarmSMS";
#region PropriedadesDaTabela
    public static DBInfoSystem AlrDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem AlrHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AlrMinuto => new(0, PTabelaNome, CampoCodigo, Minuto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AlrD1 => new(0, PTabelaNome, CampoCodigo, D1, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrD2 => new(0, PTabelaNome, CampoCodigo, D2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrD3 => new(0, PTabelaNome, CampoCodigo, D3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrD4 => new(0, PTabelaNome, CampoCodigo, D4, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrD5 => new(0, PTabelaNome, CampoCodigo, D5, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrD6 => new(0, PTabelaNome, CampoCodigo, D6, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrD7 => new(0, PTabelaNome, CampoCodigo, D7, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrEMail => new(0, PTabelaNome, CampoCodigo, EMail, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem AlrDesativar => new(0, PTabelaNome, CampoCodigo, Desativar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrToday => new(0, PTabelaNome, CampoCodigo, Today, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem AlrExcetoDiasFelizes => new(0, PTabelaNome, CampoCodigo, ExcetoDiasFelizes, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrDesktop => new(0, PTabelaNome, CampoCodigo, Desktop, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AlrAlertarDataHora => new(0, PTabelaNome, CampoCodigo, AlertarDataHora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem AlrOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AlrGuidExo => new(0, PTabelaNome, CampoCodigo, GuidExo, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem AlrAgenda => new(0, PTabelaNome, CampoCodigo, Agenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAgendaDicInfo.CampoCodigo, DBAgendaDicInfo.TabelaNome, new DBAgendaODicInfo(), false); // DBI 11 
    public static DBInfoSystem AlrRecado => new(0, PTabelaNome, CampoCodigo, Recado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBRecadosDicInfo.CampoCodigo, DBRecadosDicInfo.TabelaNome, new DBRecadosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AlrEmocao => new(0, PTabelaNome, CampoCodigo, Emocao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AlrGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem AlrQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AlrDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem AlrQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AlrDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem AlrVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string D1Sql(bool valueCheck) => D1.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string D1SqlSim => D1.SqlCmdBoolSim() ?? string.Empty;
    public static string D1SqlNao => D1.SqlCmdBoolNao() ?? string.Empty;

    public static string D2Sql(bool valueCheck) => D2.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string D2SqlSim => D2.SqlCmdBoolSim() ?? string.Empty;
    public static string D2SqlNao => D2.SqlCmdBoolNao() ?? string.Empty;

    public static string D3Sql(bool valueCheck) => D3.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string D3SqlSim => D3.SqlCmdBoolSim() ?? string.Empty;
    public static string D3SqlNao => D3.SqlCmdBoolNao() ?? string.Empty;

    public static string D4Sql(bool valueCheck) => D4.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string D4SqlSim => D4.SqlCmdBoolSim() ?? string.Empty;
    public static string D4SqlNao => D4.SqlCmdBoolNao() ?? string.Empty;

    public static string D5Sql(bool valueCheck) => D5.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string D5SqlSim => D5.SqlCmdBoolSim() ?? string.Empty;
    public static string D5SqlNao => D5.SqlCmdBoolNao() ?? string.Empty;

    public static string D6Sql(bool valueCheck) => D6.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string D6SqlSim => D6.SqlCmdBoolSim() ?? string.Empty;
    public static string D6SqlNao => D6.SqlCmdBoolNao() ?? string.Empty;

    public static string D7Sql(bool valueCheck) => D7.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string D7SqlSim => D7.SqlCmdBoolSim() ?? string.Empty;
    public static string D7SqlNao => D7.SqlCmdBoolNao() ?? string.Empty;

    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DesativarSql(bool valueCheck) => Desativar.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string DesativarSqlSim => Desativar.SqlCmdBoolSim() ?? string.Empty;
    public static string DesativarSqlNao => Desativar.SqlCmdBoolNao() ?? string.Empty;

    public static string TodaySqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Today}]");
    public static string TodaySqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Today}]");
    public static string TodaySqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Today}]");
    public static string TodaySqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Today}]");
    public static string TodaySqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Today}]");
    public static string TodaySqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Today}]");
    public static string TodaySqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Today}]");
    public static string TodaySqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Today}]");
    public static string TodaySqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Today}]");
    public static string TodaySqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Today}]");
    public static string TodaySqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Today}]");
    public static string TodaySqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Today}]");
    public static string TodayIsNull => Today.SqlCmdIsNull() ?? string.Empty;
    public static string TodayNotIsNull => Today.SqlCmdNotIsNull() ?? string.Empty;

    public static string ExcetoDiasFelizesSql(bool valueCheck) => ExcetoDiasFelizes.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ExcetoDiasFelizesSqlSim => ExcetoDiasFelizes.SqlCmdBoolSim() ?? string.Empty;
    public static string ExcetoDiasFelizesSqlNao => ExcetoDiasFelizes.SqlCmdBoolNao() ?? string.Empty;

    public static string DesktopSql(bool valueCheck) => Desktop.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string DesktopSqlSim => Desktop.SqlCmdBoolSim() ?? string.Empty;
    public static string DesktopSqlNao => Desktop.SqlCmdBoolNao() ?? string.Empty;

    public static string AlertarDataHoraSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{AlertarDataHora}]");
    public static string AlertarDataHoraIsNull => AlertarDataHora.SqlCmdIsNull() ?? string.Empty;
    public static string AlertarDataHoraNotIsNull => AlertarDataHora.SqlCmdNotIsNull() ?? string.Empty;

    public static string GuidExoSql(string text) => GuidExo.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string GuidExoSqlNotIsNull => GuidExo.SqlCmdNotIsNull() ?? string.Empty;
    public static string GuidExoSqlIsNull => GuidExo.SqlCmdIsNull() ?? string.Empty;

    public static string GuidExoSqlDiff(string text) => GuidExo.SqlCmdTextDiff(text) ?? string.Empty;
    public static string GuidExoSqlLike(string text) => GuidExo.SqlCmdTextLike(text) ?? string.Empty;
    public static string GuidExoSqlLikeInit(string text) => GuidExo.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string GuidExoSqlLikeSpaces(string? text) => GuidExo.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        AlrDescricao = 1,
        AlrHora = 2,
        AlrMinuto = 3,
        AlrD1 = 4,
        AlrD2 = 5,
        AlrD3 = 6,
        AlrD4 = 7,
        AlrD5 = 8,
        AlrD6 = 9,
        AlrD7 = 10,
        AlrEMail = 11,
        AlrDesativar = 12,
        AlrToday = 13,
        AlrExcetoDiasFelizes = 14,
        AlrDesktop = 15,
        AlrAlertarDataHora = 16,
        AlrOperador = 17,
        AlrGuidExo = 18,
        AlrAgenda = 19,
        AlrRecado = 20,
        AlrEmocao = 21,
        AlrGUID = 22,
        AlrQuemCad = 23,
        AlrDtCad = 24,
        AlrQuemAtu = 25,
        AlrDtAtu = 26,
        AlrVisto = 27
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AlrDescricao => AlrDescricao,
        NomesCamposTabela.AlrHora => AlrHora,
        NomesCamposTabela.AlrMinuto => AlrMinuto,
        NomesCamposTabela.AlrD1 => AlrD1,
        NomesCamposTabela.AlrD2 => AlrD2,
        NomesCamposTabela.AlrD3 => AlrD3,
        NomesCamposTabela.AlrD4 => AlrD4,
        NomesCamposTabela.AlrD5 => AlrD5,
        NomesCamposTabela.AlrD6 => AlrD6,
        NomesCamposTabela.AlrD7 => AlrD7,
        NomesCamposTabela.AlrEMail => AlrEMail,
        NomesCamposTabela.AlrDesativar => AlrDesativar,
        NomesCamposTabela.AlrToday => AlrToday,
        NomesCamposTabela.AlrExcetoDiasFelizes => AlrExcetoDiasFelizes,
        NomesCamposTabela.AlrDesktop => AlrDesktop,
        NomesCamposTabela.AlrAlertarDataHora => AlrAlertarDataHora,
        NomesCamposTabela.AlrOperador => AlrOperador,
        NomesCamposTabela.AlrGuidExo => AlrGuidExo,
        NomesCamposTabela.AlrAgenda => AlrAgenda,
        NomesCamposTabela.AlrRecado => AlrRecado,
        NomesCamposTabela.AlrEmocao => AlrEmocao,
        NomesCamposTabela.AlrGUID => AlrGUID,
        NomesCamposTabela.AlrQuemCad => AlrQuemCad,
        NomesCamposTabela.AlrDtCad => AlrDtCad,
        NomesCamposTabela.AlrQuemAtu => AlrQuemAtu,
        NomesCamposTabela.AlrDtAtu => AlrDtAtu,
        NomesCamposTabela.AlrVisto => AlrVisto,
        _ => null
    };
}