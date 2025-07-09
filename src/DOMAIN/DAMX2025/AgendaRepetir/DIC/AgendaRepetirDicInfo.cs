using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAgendaRepetirDicInfo
{
    public const string CampoCodigo = "rptCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "rpt";
    public const string Advogado = "rptAdvogado"; // LOCALIZACAO 170523
    public const string Cliente = "rptCliente"; // LOCALIZACAO 170523
    public const string DataFinal = "rptDataFinal"; // LOCALIZACAO 170523
    public const string Funcionario = "rptFuncionario"; // LOCALIZACAO 170523
    public const string HoraFinal = "rptHoraFinal"; // LOCALIZACAO 170523
    public const string Processo = "rptProcesso"; // LOCALIZACAO 170523
    public const string Pessoal = "rptPessoal"; // LOCALIZACAO 170523
    public const string Frequencia = "rptFrequencia"; // LOCALIZACAO 170523
    public const string Dia = "rptDia"; // LOCALIZACAO 170523
    public const string Mes = "rptMes"; // LOCALIZACAO 170523
    public const string Hora = "rptHora"; // LOCALIZACAO 170523
    public const string IDQuem = "rptIDQuem"; // LOCALIZACAO 170523
    public const string IDQuem2 = "rptIDQuem2"; // LOCALIZACAO 170523
    public const string Mensagem = "rptMensagem"; // LOCALIZACAO 170523
    public const string IDTipo = "rptIDTipo"; // LOCALIZACAO 170523
    public const string ID1 = "rptID1"; // LOCALIZACAO 170523
    public const string ID2 = "rptID2"; // LOCALIZACAO 170523
    public const string ID3 = "rptID3"; // LOCALIZACAO 170523
    public const string ID4 = "rptID4"; // LOCALIZACAO 170523
    public const string Segunda = "rptSegunda"; // LOCALIZACAO 170523
    public const string Quarta = "rptQuarta"; // LOCALIZACAO 170523
    public const string Quinta = "rptQuinta"; // LOCALIZACAO 170523
    public const string Sexta = "rptSexta"; // LOCALIZACAO 170523
    public const string Sabado = "rptSabado"; // LOCALIZACAO 170523
    public const string Domingo = "rptDomingo"; // LOCALIZACAO 170523
    public const string Terca = "rptTerca"; // LOCALIZACAO 170523
    public const string QuemCad = "rptQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "rptDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "rptQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "rptDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "rptVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Advogado,
        2 => Cliente,
        3 => DataFinal,
        4 => Funcionario,
        5 => HoraFinal,
        6 => Processo,
        7 => Pessoal,
        8 => Frequencia,
        9 => Dia,
        10 => Mes,
        11 => Hora,
        12 => IDQuem,
        13 => IDQuem2,
        14 => Mensagem,
        15 => IDTipo,
        16 => ID1,
        17 => ID2,
        18 => ID3,
        19 => ID4,
        20 => Segunda,
        21 => Quarta,
        22 => Quinta,
        23 => Sexta,
        24 => Sabado,
        25 => Domingo,
        26 => Terca,
        27 => QuemCad,
        28 => DtCad,
        29 => QuemAtu,
        30 => DtAtu,
        31 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaRepetir";
#region PropriedadesDaTabela
    public static DBInfoSystem RptAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false); // DBI 11 
    public static DBInfoSystem RptCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem RptDataFinal => new(0, PTabelaNome, CampoCodigo, DataFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RptFuncionario => new(0, PTabelaNome, CampoCodigo, Funcionario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncionariosDicInfo.CampoCodigo, DBFuncionariosDicInfo.TabelaNome, new DBFuncionariosODicInfo(), false); // DBI 11 
    public static DBInfoSystem RptHoraFinal => new(0, PTabelaNome, CampoCodigo, HoraFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RptProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem RptPessoal => new(0, PTabelaNome, CampoCodigo, Pessoal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RptFrequencia => new(0, PTabelaNome, CampoCodigo, Frequencia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptDia => new(0, PTabelaNome, CampoCodigo, Dia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptMes => new(0, PTabelaNome, CampoCodigo, Mes, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RptIDQuem => new(0, PTabelaNome, CampoCodigo, IDQuem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptIDQuem2 => new(0, PTabelaNome, CampoCodigo, IDQuem2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptMensagem => new(0, PTabelaNome, CampoCodigo, Mensagem, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem RptIDTipo => new(0, PTabelaNome, CampoCodigo, IDTipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptID1 => new(0, PTabelaNome, CampoCodigo, ID1, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptID2 => new(0, PTabelaNome, CampoCodigo, ID2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptID3 => new(0, PTabelaNome, CampoCodigo, ID3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptID4 => new(0, PTabelaNome, CampoCodigo, ID4, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RptSegunda => new(0, PTabelaNome, CampoCodigo, Segunda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RptQuarta => new(0, PTabelaNome, CampoCodigo, Quarta, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RptQuinta => new(0, PTabelaNome, CampoCodigo, Quinta, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RptSexta => new(0, PTabelaNome, CampoCodigo, Sexta, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RptSabado => new(0, PTabelaNome, CampoCodigo, Sabado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RptDomingo => new(0, PTabelaNome, CampoCodigo, Domingo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RptTerca => new(0, PTabelaNome, CampoCodigo, Terca, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RptQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem RptDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem RptQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem RptDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem RptVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string DataFinalSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataFinal}]");
    public static string DataFinalSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataFinal}]");
    public static string DataFinalSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataFinal}]");
    public static string DataFinalSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataFinal}]");
    public static string DataFinalSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataFinal}]");
    public static string DataFinalSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataFinal}]");
    public static string DataFinalSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataFinal}]");
    public static string DataFinalSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataFinal}]");
    public static string DataFinalSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataFinal}]");
    public static string DataFinalSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataFinal}]");
    public static string DataFinalSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataFinal}]");
    public static string DataFinalSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataFinal}]");
    public static string DataFinalIsNull => DataFinal.SqlCmdIsNull() ?? string.Empty;
    public static string DataFinalNotIsNull => DataFinal.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string PessoalSql(bool valueCheck) => Pessoal.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string PessoalSqlSim => Pessoal.SqlCmdBoolSim() ?? string.Empty;
    public static string PessoalSqlNao => Pessoal.SqlCmdBoolNao() ?? string.Empty;

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

    public static string MensagemSql(string text) => Mensagem.SqlCmdTextIgual(text) ?? string.Empty;
    public static string MensagemSqlNotIsNull => Mensagem.SqlCmdNotIsNull() ?? string.Empty;
    public static string MensagemSqlIsNull => Mensagem.SqlCmdIsNull() ?? string.Empty;

    public static string MensagemSqlDiff(string text) => Mensagem.SqlCmdTextDiff(text) ?? string.Empty;
    public static string MensagemSqlLike(string text) => Mensagem.SqlCmdTextLike(text) ?? string.Empty;
    public static string MensagemSqlLikeInit(string text) => Mensagem.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string MensagemSqlLikeSpaces(string? text) => Mensagem.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SegundaSql(bool valueCheck) => Segunda.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SegundaSqlSim => Segunda.SqlCmdBoolSim() ?? string.Empty;
    public static string SegundaSqlNao => Segunda.SqlCmdBoolNao() ?? string.Empty;

    public static string QuartaSql(bool valueCheck) => Quarta.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string QuartaSqlSim => Quarta.SqlCmdBoolSim() ?? string.Empty;
    public static string QuartaSqlNao => Quarta.SqlCmdBoolNao() ?? string.Empty;

    public static string QuintaSql(bool valueCheck) => Quinta.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string QuintaSqlSim => Quinta.SqlCmdBoolSim() ?? string.Empty;
    public static string QuintaSqlNao => Quinta.SqlCmdBoolNao() ?? string.Empty;

    public static string SextaSql(bool valueCheck) => Sexta.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SextaSqlSim => Sexta.SqlCmdBoolSim() ?? string.Empty;
    public static string SextaSqlNao => Sexta.SqlCmdBoolNao() ?? string.Empty;

    public static string SabadoSql(bool valueCheck) => Sabado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SabadoSqlSim => Sabado.SqlCmdBoolSim() ?? string.Empty;
    public static string SabadoSqlNao => Sabado.SqlCmdBoolNao() ?? string.Empty;

    public static string DomingoSql(bool valueCheck) => Domingo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string DomingoSqlSim => Domingo.SqlCmdBoolSim() ?? string.Empty;
    public static string DomingoSqlNao => Domingo.SqlCmdBoolNao() ?? string.Empty;

    public static string TercaSql(bool valueCheck) => Terca.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TercaSqlSim => Terca.SqlCmdBoolSim() ?? string.Empty;
    public static string TercaSqlNao => Terca.SqlCmdBoolNao() ?? string.Empty;

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
        RptAdvogado = 1,
        RptCliente = 2,
        RptDataFinal = 3,
        RptFuncionario = 4,
        RptHoraFinal = 5,
        RptProcesso = 6,
        RptPessoal = 7,
        RptFrequencia = 8,
        RptDia = 9,
        RptMes = 10,
        RptHora = 11,
        RptIDQuem = 12,
        RptIDQuem2 = 13,
        RptMensagem = 14,
        RptIDTipo = 15,
        RptID1 = 16,
        RptID2 = 17,
        RptID3 = 18,
        RptID4 = 19,
        RptSegunda = 20,
        RptQuarta = 21,
        RptQuinta = 22,
        RptSexta = 23,
        RptSabado = 24,
        RptDomingo = 25,
        RptTerca = 26,
        RptQuemCad = 27,
        RptDtCad = 28,
        RptQuemAtu = 29,
        RptDtAtu = 30,
        RptVisto = 31
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RptAdvogado => RptAdvogado,
        NomesCamposTabela.RptCliente => RptCliente,
        NomesCamposTabela.RptDataFinal => RptDataFinal,
        NomesCamposTabela.RptFuncionario => RptFuncionario,
        NomesCamposTabela.RptHoraFinal => RptHoraFinal,
        NomesCamposTabela.RptProcesso => RptProcesso,
        NomesCamposTabela.RptPessoal => RptPessoal,
        NomesCamposTabela.RptFrequencia => RptFrequencia,
        NomesCamposTabela.RptDia => RptDia,
        NomesCamposTabela.RptMes => RptMes,
        NomesCamposTabela.RptHora => RptHora,
        NomesCamposTabela.RptIDQuem => RptIDQuem,
        NomesCamposTabela.RptIDQuem2 => RptIDQuem2,
        NomesCamposTabela.RptMensagem => RptMensagem,
        NomesCamposTabela.RptIDTipo => RptIDTipo,
        NomesCamposTabela.RptID1 => RptID1,
        NomesCamposTabela.RptID2 => RptID2,
        NomesCamposTabela.RptID3 => RptID3,
        NomesCamposTabela.RptID4 => RptID4,
        NomesCamposTabela.RptSegunda => RptSegunda,
        NomesCamposTabela.RptQuarta => RptQuarta,
        NomesCamposTabela.RptQuinta => RptQuinta,
        NomesCamposTabela.RptSexta => RptSexta,
        NomesCamposTabela.RptSabado => RptSabado,
        NomesCamposTabela.RptDomingo => RptDomingo,
        NomesCamposTabela.RptTerca => RptTerca,
        NomesCamposTabela.RptQuemCad => RptQuemCad,
        NomesCamposTabela.RptDtCad => RptDtCad,
        NomesCamposTabela.RptQuemAtu => RptQuemAtu,
        NomesCamposTabela.RptDtAtu => RptDtAtu,
        NomesCamposTabela.RptVisto => RptVisto,
        _ => null
    };
}