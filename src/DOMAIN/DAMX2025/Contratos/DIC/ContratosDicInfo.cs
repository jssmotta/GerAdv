using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBContratosDicInfo
{
    public const string CampoCodigo = "cttCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ctt";
    public const string Processo = "cttProcesso"; // LOCALIZACAO 170523
    public const string Cliente = "cttCliente"; // LOCALIZACAO 170523
    public const string Advogado = "cttAdvogado"; // LOCALIZACAO 170523
    public const string Dia = "cttDia"; // LOCALIZACAO 170523
    public const string Valor = "cttValor"; // LOCALIZACAO 170523
    public const string DataInicio = "cttDataInicio"; // LOCALIZACAO 170523
    public const string DataTermino = "cttDataTermino"; // LOCALIZACAO 170523
    public const string OcultarRelatorio = "cttOcultarRelatorio"; // LOCALIZACAO 170523
    public const string PercEscritorio = "cttPercEscritorio"; // LOCALIZACAO 170523
    public const string ValorConsultoria = "cttValorConsultoria"; // LOCALIZACAO 170523
    public const string TipoCobranca = "cttTipoCobranca"; // LOCALIZACAO 170523
    public const string Protestar = "cttProtestar"; // LOCALIZACAO 170523
    public const string Juros = "cttJuros"; // LOCALIZACAO 170523
    public const string ValorRealizavel = "cttValorRealizavel"; // LOCALIZACAO 170523
    public const string DOCUMENTO = "cttDOCUMENTO"; // LOCALIZACAO 170523
    public const string EMail1 = "cttEMail1"; // LOCALIZACAO 170523
    public const string EMail2 = "cttEMail2"; // LOCALIZACAO 170523
    public const string EMail3 = "cttEMail3"; // LOCALIZACAO 170523
    public const string Pessoa1 = "cttPessoa1"; // LOCALIZACAO 170523
    public const string Pessoa2 = "cttPessoa2"; // LOCALIZACAO 170523
    public const string Pessoa3 = "cttPessoa3"; // LOCALIZACAO 170523
    public const string OBS = "cttOBS"; // LOCALIZACAO 170523
    public const string ClienteContrato = "cttClienteContrato"; // LOCALIZACAO 170523
    public const string IdExtrangeiro = "cttIdExtrangeiro"; // LOCALIZACAO 170523
    public const string ChaveContrato = "cttChaveContrato"; // LOCALIZACAO 170523
    public const string Avulso = "cttAvulso"; // LOCALIZACAO 170523
    public const string Suspenso = "cttSuspenso"; // LOCALIZACAO 170523
    public const string Multa = "cttMulta"; // LOCALIZACAO 170523
    public const string Bold = "cttBold"; // LOCALIZACAO 170523
    public const string GUID = "cttGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "cttQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "cttDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "cttQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "cttDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "cttVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Cliente,
        3 => Advogado,
        4 => Dia,
        5 => Valor,
        6 => DataInicio,
        7 => DataTermino,
        8 => OcultarRelatorio,
        9 => PercEscritorio,
        10 => ValorConsultoria,
        11 => TipoCobranca,
        12 => Protestar,
        13 => Juros,
        14 => ValorRealizavel,
        15 => DOCUMENTO,
        16 => EMail1,
        17 => EMail2,
        18 => EMail3,
        19 => Pessoa1,
        20 => Pessoa2,
        21 => Pessoa3,
        22 => OBS,
        23 => ClienteContrato,
        24 => IdExtrangeiro,
        25 => ChaveContrato,
        26 => Avulso,
        27 => Suspenso,
        28 => Multa,
        29 => Bold,
        30 => GUID,
        31 => QuemCad,
        32 => DtCad,
        33 => QuemAtu,
        34 => DtAtu,
        35 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Contratos";
#region PropriedadesDaTabela
    public static DBInfoSystem CttProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem CttCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem CttAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false); // DBI 11 
    public static DBInfoSystem CttDia => new(0, PTabelaNome, CampoCodigo, Dia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CttValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem CttDataInicio => new(0, PTabelaNome, CampoCodigo, DataInicio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CttDataTermino => new(0, PTabelaNome, CampoCodigo, DataTermino, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CttOcultarRelatorio => new(0, PTabelaNome, CampoCodigo, OcultarRelatorio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CttPercEscritorio => new(0, PTabelaNome, CampoCodigo, PercEscritorio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem CttValorConsultoria => new(0, PTabelaNome, CampoCodigo, ValorConsultoria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem CttTipoCobranca => new(0, PTabelaNome, CampoCodigo, TipoCobranca, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CttProtestar => new(0, PTabelaNome, CampoCodigo, Protestar, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CttJuros => new(0, PTabelaNome, CampoCodigo, Juros, 5, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CttValorRealizavel => new(0, PTabelaNome, CampoCodigo, ValorRealizavel, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem CttDOCUMENTO => new(0, PTabelaNome, CampoCodigo, DOCUMENTO, 15, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CttEMail1 => new(0, PTabelaNome, CampoCodigo, EMail1, 300, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem CttEMail2 => new(0, PTabelaNome, CampoCodigo, EMail2, 300, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem CttEMail3 => new(0, PTabelaNome, CampoCodigo, EMail3, 300, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem CttPessoa1 => new(0, PTabelaNome, CampoCodigo, Pessoa1, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CttPessoa2 => new(0, PTabelaNome, CampoCodigo, Pessoa2, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CttPessoa3 => new(0, PTabelaNome, CampoCodigo, Pessoa3, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CttOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem CttClienteContrato => new(0, PTabelaNome, CampoCodigo, ClienteContrato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CttIdExtrangeiro => new(0, PTabelaNome, CampoCodigo, IdExtrangeiro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CttChaveContrato => new(0, PTabelaNome, CampoCodigo, ChaveContrato, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CttAvulso => new(0, PTabelaNome, CampoCodigo, Avulso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CttSuspenso => new(0, PTabelaNome, CampoCodigo, Suspenso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CttMulta => new(0, PTabelaNome, CampoCodigo, Multa, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CttBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem CttGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem CttQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem CttDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem CttQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem CttDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem CttVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string DataInicioSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataInicio}]");
    public static string DataInicioSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataInicio}]");
    public static string DataInicioSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataInicio}]");
    public static string DataInicioSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataInicio}]");
    public static string DataInicioSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataInicio}]");
    public static string DataInicioSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataInicio}]");
    public static string DataInicioSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataInicio}]");
    public static string DataInicioSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataInicio}]");
    public static string DataInicioSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataInicio}]");
    public static string DataInicioSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataInicio}]");
    public static string DataInicioSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataInicio}]");
    public static string DataInicioSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataInicio}]");
    public static string DataInicioIsNull => DataInicio.SqlCmdIsNull() ?? string.Empty;
    public static string DataInicioNotIsNull => DataInicio.SqlCmdNotIsNull() ?? string.Empty;

    public static string DataTerminoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataTermino}]");
    public static string DataTerminoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataTermino}]");
    public static string DataTerminoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataTermino}]");
    public static string DataTerminoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataTermino}]");
    public static string DataTerminoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataTermino}]");
    public static string DataTerminoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataTermino}]");
    public static string DataTerminoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataTermino}]");
    public static string DataTerminoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataTermino}]");
    public static string DataTerminoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataTermino}]");
    public static string DataTerminoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataTermino}]");
    public static string DataTerminoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataTermino}]");
    public static string DataTerminoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataTermino}]");
    public static string DataTerminoIsNull => DataTermino.SqlCmdIsNull() ?? string.Empty;
    public static string DataTerminoNotIsNull => DataTermino.SqlCmdNotIsNull() ?? string.Empty;

    public static string OcultarRelatorioSql(bool valueCheck) => OcultarRelatorio.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string OcultarRelatorioSqlSim => OcultarRelatorio.SqlCmdBoolSim() ?? string.Empty;
    public static string OcultarRelatorioSqlNao => OcultarRelatorio.SqlCmdBoolNao() ?? string.Empty;

    public static string ProtestarSql(string text) => Protestar.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string ProtestarSqlNotIsNull => Protestar.SqlCmdNotIsNull() ?? string.Empty;
    public static string ProtestarSqlIsNull => Protestar.SqlCmdIsNull() ?? string.Empty;

    public static string ProtestarSqlDiff(string text) => Protestar.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ProtestarSqlLike(string text) => Protestar.SqlCmdTextLike(text) ?? string.Empty;
    public static string ProtestarSqlLikeInit(string text) => Protestar.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ProtestarSqlLikeSpaces(string? text) => Protestar.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string JurosSql(string text) => Juros.SqlCmdTextIgual(text, 5) ?? string.Empty;
    public static string JurosSqlNotIsNull => Juros.SqlCmdNotIsNull() ?? string.Empty;
    public static string JurosSqlIsNull => Juros.SqlCmdIsNull() ?? string.Empty;

    public static string JurosSqlDiff(string text) => Juros.SqlCmdTextDiff(text) ?? string.Empty;
    public static string JurosSqlLike(string text) => Juros.SqlCmdTextLike(text) ?? string.Empty;
    public static string JurosSqlLikeInit(string text) => Juros.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string JurosSqlLikeSpaces(string? text) => Juros.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DOCUMENTOSql(string text) => DOCUMENTO.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string DOCUMENTOSqlNotIsNull => DOCUMENTO.SqlCmdNotIsNull() ?? string.Empty;
    public static string DOCUMENTOSqlIsNull => DOCUMENTO.SqlCmdIsNull() ?? string.Empty;

    public static string DOCUMENTOSqlDiff(string text) => DOCUMENTO.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DOCUMENTOSqlLike(string text) => DOCUMENTO.SqlCmdTextLike(text) ?? string.Empty;
    public static string DOCUMENTOSqlLikeInit(string text) => DOCUMENTO.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DOCUMENTOSqlLikeSpaces(string? text) => DOCUMENTO.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMail1Sql(string text) => EMail1.SqlCmdTextIgual(text, 300) ?? string.Empty;
    public static string EMail1SqlNotIsNull => EMail1.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMail1SqlIsNull => EMail1.SqlCmdIsNull() ?? string.Empty;

    public static string EMail1SqlDiff(string text) => EMail1.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMail1SqlLike(string text) => EMail1.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMail1SqlLikeInit(string text) => EMail1.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMail1SqlLikeSpaces(string? text) => EMail1.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMail2Sql(string text) => EMail2.SqlCmdTextIgual(text, 300) ?? string.Empty;
    public static string EMail2SqlNotIsNull => EMail2.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMail2SqlIsNull => EMail2.SqlCmdIsNull() ?? string.Empty;

    public static string EMail2SqlDiff(string text) => EMail2.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMail2SqlLike(string text) => EMail2.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMail2SqlLikeInit(string text) => EMail2.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMail2SqlLikeSpaces(string? text) => EMail2.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMail3Sql(string text) => EMail3.SqlCmdTextIgual(text, 300) ?? string.Empty;
    public static string EMail3SqlNotIsNull => EMail3.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMail3SqlIsNull => EMail3.SqlCmdIsNull() ?? string.Empty;

    public static string EMail3SqlDiff(string text) => EMail3.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMail3SqlLike(string text) => EMail3.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMail3SqlLikeInit(string text) => EMail3.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMail3SqlLikeSpaces(string? text) => EMail3.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string Pessoa1Sql(string text) => Pessoa1.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string Pessoa1SqlNotIsNull => Pessoa1.SqlCmdNotIsNull() ?? string.Empty;
    public static string Pessoa1SqlIsNull => Pessoa1.SqlCmdIsNull() ?? string.Empty;

    public static string Pessoa1SqlDiff(string text) => Pessoa1.SqlCmdTextDiff(text) ?? string.Empty;
    public static string Pessoa1SqlLike(string text) => Pessoa1.SqlCmdTextLike(text) ?? string.Empty;
    public static string Pessoa1SqlLikeInit(string text) => Pessoa1.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string Pessoa1SqlLikeSpaces(string? text) => Pessoa1.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string Pessoa2Sql(string text) => Pessoa2.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string Pessoa2SqlNotIsNull => Pessoa2.SqlCmdNotIsNull() ?? string.Empty;
    public static string Pessoa2SqlIsNull => Pessoa2.SqlCmdIsNull() ?? string.Empty;

    public static string Pessoa2SqlDiff(string text) => Pessoa2.SqlCmdTextDiff(text) ?? string.Empty;
    public static string Pessoa2SqlLike(string text) => Pessoa2.SqlCmdTextLike(text) ?? string.Empty;
    public static string Pessoa2SqlLikeInit(string text) => Pessoa2.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string Pessoa2SqlLikeSpaces(string? text) => Pessoa2.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string Pessoa3Sql(string text) => Pessoa3.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string Pessoa3SqlNotIsNull => Pessoa3.SqlCmdNotIsNull() ?? string.Empty;
    public static string Pessoa3SqlIsNull => Pessoa3.SqlCmdIsNull() ?? string.Empty;

    public static string Pessoa3SqlDiff(string text) => Pessoa3.SqlCmdTextDiff(text) ?? string.Empty;
    public static string Pessoa3SqlLike(string text) => Pessoa3.SqlCmdTextLike(text) ?? string.Empty;
    public static string Pessoa3SqlLikeInit(string text) => Pessoa3.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string Pessoa3SqlLikeSpaces(string? text) => Pessoa3.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OBSSql(string text) => OBS.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OBSSqlNotIsNull => OBS.SqlCmdNotIsNull() ?? string.Empty;
    public static string OBSSqlIsNull => OBS.SqlCmdIsNull() ?? string.Empty;

    public static string OBSSqlDiff(string text) => OBS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OBSSqlLike(string text) => OBS.SqlCmdTextLike(text) ?? string.Empty;
    public static string OBSSqlLikeInit(string text) => OBS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OBSSqlLikeSpaces(string? text) => OBS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ChaveContratoSql(string text) => ChaveContrato.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string ChaveContratoSqlNotIsNull => ChaveContrato.SqlCmdNotIsNull() ?? string.Empty;
    public static string ChaveContratoSqlIsNull => ChaveContrato.SqlCmdIsNull() ?? string.Empty;

    public static string ChaveContratoSqlDiff(string text) => ChaveContrato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ChaveContratoSqlLike(string text) => ChaveContrato.SqlCmdTextLike(text) ?? string.Empty;
    public static string ChaveContratoSqlLikeInit(string text) => ChaveContrato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ChaveContratoSqlLikeSpaces(string? text) => ChaveContrato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AvulsoSql(bool valueCheck) => Avulso.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AvulsoSqlSim => Avulso.SqlCmdBoolSim() ?? string.Empty;
    public static string AvulsoSqlNao => Avulso.SqlCmdBoolNao() ?? string.Empty;

    public static string SuspensoSql(bool valueCheck) => Suspenso.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SuspensoSqlSim => Suspenso.SqlCmdBoolSim() ?? string.Empty;
    public static string SuspensoSqlNao => Suspenso.SqlCmdBoolNao() ?? string.Empty;

    public static string MultaSql(string text) => Multa.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string MultaSqlNotIsNull => Multa.SqlCmdNotIsNull() ?? string.Empty;
    public static string MultaSqlIsNull => Multa.SqlCmdIsNull() ?? string.Empty;

    public static string MultaSqlDiff(string text) => Multa.SqlCmdTextDiff(text) ?? string.Empty;
    public static string MultaSqlLike(string text) => Multa.SqlCmdTextLike(text) ?? string.Empty;
    public static string MultaSqlLikeInit(string text) => Multa.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string MultaSqlLikeSpaces(string? text) => Multa.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string BoldSql(bool valueCheck) => Bold.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BoldSqlSim => Bold.SqlCmdBoolSim() ?? string.Empty;
    public static string BoldSqlNao => Bold.SqlCmdBoolNao() ?? string.Empty;

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
        CttProcesso = 1,
        CttCliente = 2,
        CttAdvogado = 3,
        CttDia = 4,
        CttValor = 5,
        CttDataInicio = 6,
        CttDataTermino = 7,
        CttOcultarRelatorio = 8,
        CttPercEscritorio = 9,
        CttValorConsultoria = 10,
        CttTipoCobranca = 11,
        CttProtestar = 12,
        CttJuros = 13,
        CttValorRealizavel = 14,
        CttDOCUMENTO = 15,
        CttEMail1 = 16,
        CttEMail2 = 17,
        CttEMail3 = 18,
        CttPessoa1 = 19,
        CttPessoa2 = 20,
        CttPessoa3 = 21,
        CttOBS = 22,
        CttClienteContrato = 23,
        CttIdExtrangeiro = 24,
        CttChaveContrato = 25,
        CttAvulso = 26,
        CttSuspenso = 27,
        CttMulta = 28,
        CttBold = 29,
        CttGUID = 30,
        CttQuemCad = 31,
        CttDtCad = 32,
        CttQuemAtu = 33,
        CttDtAtu = 34,
        CttVisto = 35
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CttProcesso => CttProcesso,
        NomesCamposTabela.CttCliente => CttCliente,
        NomesCamposTabela.CttAdvogado => CttAdvogado,
        NomesCamposTabela.CttDia => CttDia,
        NomesCamposTabela.CttValor => CttValor,
        NomesCamposTabela.CttDataInicio => CttDataInicio,
        NomesCamposTabela.CttDataTermino => CttDataTermino,
        NomesCamposTabela.CttOcultarRelatorio => CttOcultarRelatorio,
        NomesCamposTabela.CttPercEscritorio => CttPercEscritorio,
        NomesCamposTabela.CttValorConsultoria => CttValorConsultoria,
        NomesCamposTabela.CttTipoCobranca => CttTipoCobranca,
        NomesCamposTabela.CttProtestar => CttProtestar,
        NomesCamposTabela.CttJuros => CttJuros,
        NomesCamposTabela.CttValorRealizavel => CttValorRealizavel,
        NomesCamposTabela.CttDOCUMENTO => CttDOCUMENTO,
        NomesCamposTabela.CttEMail1 => CttEMail1,
        NomesCamposTabela.CttEMail2 => CttEMail2,
        NomesCamposTabela.CttEMail3 => CttEMail3,
        NomesCamposTabela.CttPessoa1 => CttPessoa1,
        NomesCamposTabela.CttPessoa2 => CttPessoa2,
        NomesCamposTabela.CttPessoa3 => CttPessoa3,
        NomesCamposTabela.CttOBS => CttOBS,
        NomesCamposTabela.CttClienteContrato => CttClienteContrato,
        NomesCamposTabela.CttIdExtrangeiro => CttIdExtrangeiro,
        NomesCamposTabela.CttChaveContrato => CttChaveContrato,
        NomesCamposTabela.CttAvulso => CttAvulso,
        NomesCamposTabela.CttSuspenso => CttSuspenso,
        NomesCamposTabela.CttMulta => CttMulta,
        NomesCamposTabela.CttBold => CttBold,
        NomesCamposTabela.CttGUID => CttGUID,
        NomesCamposTabela.CttQuemCad => CttQuemCad,
        NomesCamposTabela.CttDtCad => CttDtCad,
        NomesCamposTabela.CttQuemAtu => CttQuemAtu,
        NomesCamposTabela.CttDtAtu => CttDtAtu,
        NomesCamposTabela.CttVisto => CttVisto,
        _ => null
    };
}