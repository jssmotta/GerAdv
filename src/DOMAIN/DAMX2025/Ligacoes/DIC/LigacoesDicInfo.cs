using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBLigacoesDicInfo
{
    public const string CampoCodigo = "ligCodigo";
    public const string CampoNome = "ligNome";
    public const string TablePrefix = "lig";
    public const string Assunto = "ligAssunto"; // LOCALIZACAO 170523
    public const string AgeClienteAvisado = "ligAgeClienteAvisado"; // LOCALIZACAO 170523
    public const string Celular = "ligCelular"; // LOCALIZACAO 170523
    public const string Cliente = "ligCliente"; // LOCALIZACAO 170523
    public const string Contato = "ligContato"; // LOCALIZACAO 170523
    public const string DataRealizada = "ligDataRealizada"; // LOCALIZACAO 170523
    public const string QuemID = "ligQuemID"; // LOCALIZACAO 170523
    public const string Telefonista = "ligTelefonista"; // LOCALIZACAO 170523
    public const string UltimoAviso = "ligUltimoAviso"; // LOCALIZACAO 170523
    public const string HoraFinal = "ligHoraFinal"; // LOCALIZACAO 170523
    public const string Nome = "ligNome"; // LOCALIZACAO 170523
    public const string QuemCodigo = "ligQuemCodigo"; // LOCALIZACAO 170523
    public const string Solicitante = "ligSolicitante"; // LOCALIZACAO 170523
    public const string Para = "ligPara"; // LOCALIZACAO 170523
    public const string Fone = "ligFone"; // LOCALIZACAO 170523
    public const string Ramal = "ligRamal"; // LOCALIZACAO 170523
    public const string Particular = "ligParticular"; // LOCALIZACAO 170523
    public const string Realizada = "ligRealizada"; // LOCALIZACAO 170523
    public const string Status = "ligStatus"; // LOCALIZACAO 170523
    public const string Data = "ligData"; // LOCALIZACAO 170523
    public const string Hora = "ligHora"; // LOCALIZACAO 170523
    public const string Urgente = "ligUrgente"; // LOCALIZACAO 170523
    public const string LigarPara = "ligLigarPara"; // LOCALIZACAO 170523
    public const string Processo = "ligProcesso"; // LOCALIZACAO 170523
    public const string StartScreen = "ligStartScreen"; // LOCALIZACAO 170523
    public const string Emotion = "ligEmotion"; // LOCALIZACAO 170523
    public const string Bold = "ligBold"; // LOCALIZACAO 170523
    public const string GUID = "ligGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ligQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ligDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ligQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ligDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ligVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Assunto,
        2 => AgeClienteAvisado,
        3 => Celular,
        4 => Cliente,
        5 => Contato,
        6 => DataRealizada,
        7 => QuemID,
        8 => Telefonista,
        9 => UltimoAviso,
        10 => HoraFinal,
        11 => Nome,
        12 => QuemCodigo,
        13 => Solicitante,
        14 => Para,
        15 => Fone,
        16 => Ramal,
        17 => Particular,
        18 => Realizada,
        19 => Status,
        20 => Data,
        21 => Hora,
        22 => Urgente,
        23 => LigarPara,
        24 => Processo,
        25 => StartScreen,
        26 => Emotion,
        27 => Bold,
        28 => GUID,
        29 => QuemCad,
        30 => DtCad,
        31 => QuemAtu,
        32 => DtAtu,
        33 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Ligacoes";
#region PropriedadesDaTabela
    public static DBInfoSystem LigAssunto => new(0, PTabelaNome, CampoCodigo, Assunto, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem LigAgeClienteAvisado => new(0, PTabelaNome, CampoCodigo, AgeClienteAvisado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LigCelular => new(0, PTabelaNome, CampoCodigo, Celular, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem LigCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem LigContato => new(0, PTabelaNome, CampoCodigo, Contato, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem LigDataRealizada => new(0, PTabelaNome, CampoCodigo, DataRealizada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem LigQuemID => new(0, PTabelaNome, CampoCodigo, QuemID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LigTelefonista => new(0, PTabelaNome, CampoCodigo, Telefonista, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LigUltimoAviso => new(0, PTabelaNome, CampoCodigo, UltimoAviso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem LigHoraFinal => new(0, PTabelaNome, CampoCodigo, HoraFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem LigNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem LigQuemCodigo => new(0, PTabelaNome, CampoCodigo, QuemCodigo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LigSolicitante => new(0, PTabelaNome, CampoCodigo, Solicitante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LigPara => new(0, PTabelaNome, CampoCodigo, Para, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem LigFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false);
    public static DBInfoSystem LigRamal => new(0, PTabelaNome, CampoCodigo, Ramal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBRamalDicInfo.CampoCodigo, DBRamalDicInfo.TabelaNome, new DBRamalODicInfo(), false); // DBI 11 
    public static DBInfoSystem LigParticular => new(0, PTabelaNome, CampoCodigo, Particular, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem LigRealizada => new(0, PTabelaNome, CampoCodigo, Realizada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem LigStatus => new(0, PTabelaNome, CampoCodigo, Status, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem LigData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem LigHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem LigUrgente => new(0, PTabelaNome, CampoCodigo, Urgente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem LigLigarPara => new(0, PTabelaNome, CampoCodigo, LigarPara, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem LigProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem LigStartScreen => new(0, PTabelaNome, CampoCodigo, StartScreen, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem LigEmotion => new(0, PTabelaNome, CampoCodigo, Emotion, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LigBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem LigGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem LigQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem LigDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem LigQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem LigDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem LigVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string AssuntoSql(string text) => Assunto.SqlCmdTextIgual(text, 200) ?? string.Empty;
    public static string AssuntoSqlNotIsNull => Assunto.SqlCmdNotIsNull() ?? string.Empty;
    public static string AssuntoSqlIsNull => Assunto.SqlCmdIsNull() ?? string.Empty;

    public static string AssuntoSqlDiff(string text) => Assunto.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AssuntoSqlLike(string text) => Assunto.SqlCmdTextLike(text) ?? string.Empty;
    public static string AssuntoSqlLikeInit(string text) => Assunto.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AssuntoSqlLikeSpaces(string? text) => Assunto.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AgeClienteAvisadoDiff(int id) => AgeClienteAvisado.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AgeClienteAvisadoSql(int id) => AgeClienteAvisado.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AgeClienteAvisadoIsNull => AgeClienteAvisado.SqlCmdIsNull() ?? string.Empty;
    public static string AgeClienteAvisadoNotIsNull => AgeClienteAvisado.SqlCmdNotIsNull() ?? string.Empty;

    public static string CelularSql(bool valueCheck) => Celular.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string CelularSqlSim => Celular.SqlCmdBoolSim() ?? string.Empty;
    public static string CelularSqlNao => Celular.SqlCmdBoolNao() ?? string.Empty;

    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

    public static string ContatoSql(string text) => Contato.SqlCmdTextIgual(text, 200) ?? string.Empty;
    public static string ContatoSqlNotIsNull => Contato.SqlCmdNotIsNull() ?? string.Empty;
    public static string ContatoSqlIsNull => Contato.SqlCmdIsNull() ?? string.Empty;

    public static string ContatoSqlDiff(string text) => Contato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ContatoSqlLike(string text) => Contato.SqlCmdTextLike(text) ?? string.Empty;
    public static string ContatoSqlLikeInit(string text) => Contato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ContatoSqlLikeSpaces(string? text) => Contato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DataRealizadaSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataRealizada}]");
    public static string DataRealizadaSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataRealizada}]");
    public static string DataRealizadaSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataRealizada}]");
    public static string DataRealizadaSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataRealizada}]");
    public static string DataRealizadaSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataRealizada}]");
    public static string DataRealizadaSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataRealizada}]");
    public static string DataRealizadaSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataRealizada}]");
    public static string DataRealizadaSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataRealizada}]");
    public static string DataRealizadaSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataRealizada}]");
    public static string DataRealizadaSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataRealizada}]");
    public static string DataRealizadaSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataRealizada}]");
    public static string DataRealizadaSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataRealizada}]");
    public static string DataRealizadaIsNull => DataRealizada.SqlCmdIsNull() ?? string.Empty;
    public static string DataRealizadaNotIsNull => DataRealizada.SqlCmdNotIsNull() ?? string.Empty;

    public static string QuemIDDiff(int id) => QuemID.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemIDSql(int id) => QuemID.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemIDIsNull => QuemID.SqlCmdIsNull() ?? string.Empty;
    public static string QuemIDNotIsNull => QuemID.SqlCmdNotIsNull() ?? string.Empty;

    public static string TelefonistaDiff(int id) => Telefonista.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string TelefonistaSql(int id) => Telefonista.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string TelefonistaIsNull => Telefonista.SqlCmdIsNull() ?? string.Empty;
    public static string TelefonistaNotIsNull => Telefonista.SqlCmdNotIsNull() ?? string.Empty;

    public static string UltimoAvisoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{UltimoAviso}]");
    public static string UltimoAvisoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{UltimoAviso}]");
    public static string UltimoAvisoIsNull => UltimoAviso.SqlCmdIsNull() ?? string.Empty;
    public static string UltimoAvisoNotIsNull => UltimoAviso.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string QuemCodigoDiff(int id) => QuemCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemCodigoSql(int id) => QuemCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemCodigoIsNull => QuemCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string QuemCodigoNotIsNull => QuemCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string SolicitanteDiff(int id) => Solicitante.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string SolicitanteSql(int id) => Solicitante.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string SolicitanteIsNull => Solicitante.SqlCmdIsNull() ?? string.Empty;
    public static string SolicitanteNotIsNull => Solicitante.SqlCmdNotIsNull() ?? string.Empty;

    public static string ParaSql(string text) => Para.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string ParaSqlNotIsNull => Para.SqlCmdNotIsNull() ?? string.Empty;
    public static string ParaSqlIsNull => Para.SqlCmdIsNull() ?? string.Empty;

    public static string ParaSqlDiff(string text) => Para.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ParaSqlLike(string text) => Para.SqlCmdTextLike(text) ?? string.Empty;
    public static string ParaSqlLikeInit(string text) => Para.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ParaSqlLikeSpaces(string? text) => Para.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FoneSql(string text) => Fone.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FoneSqlNotIsNull => Fone.SqlCmdNotIsNull() ?? string.Empty;
    public static string FoneSqlIsNull => Fone.SqlCmdIsNull() ?? string.Empty;

    public static string FoneSqlDiff(string text) => Fone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FoneSqlLike(string text) => Fone.SqlCmdTextLike(text) ?? string.Empty;
    public static string FoneSqlLikeInit(string text) => Fone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FoneSqlLikeSpaces(string? text) => Fone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RamalDiff(int id) => Ramal.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string RamalSql(int id) => Ramal.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string RamalIsNull => Ramal.SqlCmdIsNull() ?? string.Empty;
    public static string RamalNotIsNull => Ramal.SqlCmdNotIsNull() ?? string.Empty;

    public static string ParticularSql(bool valueCheck) => Particular.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ParticularSqlSim => Particular.SqlCmdBoolSim() ?? string.Empty;
    public static string ParticularSqlNao => Particular.SqlCmdBoolNao() ?? string.Empty;

    public static string RealizadaSql(bool valueCheck) => Realizada.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string RealizadaSqlSim => Realizada.SqlCmdBoolSim() ?? string.Empty;
    public static string RealizadaSqlNao => Realizada.SqlCmdBoolNao() ?? string.Empty;

    public static string StatusSql(string text) => Status.SqlCmdTextIgual(text) ?? string.Empty;
    public static string StatusSqlNotIsNull => Status.SqlCmdNotIsNull() ?? string.Empty;
    public static string StatusSqlIsNull => Status.SqlCmdIsNull() ?? string.Empty;

    public static string StatusSqlDiff(string text) => Status.SqlCmdTextDiff(text) ?? string.Empty;
    public static string StatusSqlLike(string text) => Status.SqlCmdTextLike(text) ?? string.Empty;
    public static string StatusSqlLikeInit(string text) => Status.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string StatusSqlLikeSpaces(string? text) => Status.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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

    public static string UrgenteSql(bool valueCheck) => Urgente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string UrgenteSqlSim => Urgente.SqlCmdBoolSim() ?? string.Empty;
    public static string UrgenteSqlNao => Urgente.SqlCmdBoolNao() ?? string.Empty;

    public static string LigarParaSql(string text) => LigarPara.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string LigarParaSqlNotIsNull => LigarPara.SqlCmdNotIsNull() ?? string.Empty;
    public static string LigarParaSqlIsNull => LigarPara.SqlCmdIsNull() ?? string.Empty;

    public static string LigarParaSqlDiff(string text) => LigarPara.SqlCmdTextDiff(text) ?? string.Empty;
    public static string LigarParaSqlLike(string text) => LigarPara.SqlCmdTextLike(text) ?? string.Empty;
    public static string LigarParaSqlLikeInit(string text) => LigarPara.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string LigarParaSqlLikeSpaces(string? text) => LigarPara.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string StartScreenSql(bool valueCheck) => StartScreen.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string StartScreenSqlSim => StartScreen.SqlCmdBoolSim() ?? string.Empty;
    public static string StartScreenSqlNao => StartScreen.SqlCmdBoolNao() ?? string.Empty;

    public static string EmotionDiff(int id) => Emotion.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string EmotionSql(int id) => Emotion.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string EmotionIsNull => Emotion.SqlCmdIsNull() ?? string.Empty;
    public static string EmotionNotIsNull => Emotion.SqlCmdNotIsNull() ?? string.Empty;

    public static string BoldSql(bool valueCheck) => Bold.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BoldSqlSim => Bold.SqlCmdBoolSim() ?? string.Empty;
    public static string BoldSqlNao => Bold.SqlCmdBoolNao() ?? string.Empty;

    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string QuemCadDiff(int id) => QuemCad.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemCadSql(int id) => QuemCad.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemCadIsNull => QuemCad.SqlCmdIsNull() ?? string.Empty;
    public static string QuemCadNotIsNull => QuemCad.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string QuemAtuDiff(int id) => QuemAtu.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemAtuSql(int id) => QuemAtu.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemAtuIsNull => QuemAtu.SqlCmdIsNull() ?? string.Empty;
    public static string QuemAtuNotIsNull => QuemAtu.SqlCmdNotIsNull() ?? string.Empty;

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

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        LigAssunto = 1,
        LigAgeClienteAvisado = 2,
        LigCelular = 3,
        LigCliente = 4,
        LigContato = 5,
        LigDataRealizada = 6,
        LigQuemID = 7,
        LigTelefonista = 8,
        LigUltimoAviso = 9,
        LigHoraFinal = 10,
        LigNome = 11,
        LigQuemCodigo = 12,
        LigSolicitante = 13,
        LigPara = 14,
        LigFone = 15,
        LigRamal = 16,
        LigParticular = 17,
        LigRealizada = 18,
        LigStatus = 19,
        LigData = 20,
        LigHora = 21,
        LigUrgente = 22,
        LigLigarPara = 23,
        LigProcesso = 24,
        LigStartScreen = 25,
        LigEmotion = 26,
        LigBold = 27,
        LigGUID = 28,
        LigQuemCad = 29,
        LigDtCad = 30,
        LigQuemAtu = 31,
        LigDtAtu = 32,
        LigVisto = 33
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.LigAssunto => LigAssunto,
        NomesCamposTabela.LigAgeClienteAvisado => LigAgeClienteAvisado,
        NomesCamposTabela.LigCelular => LigCelular,
        NomesCamposTabela.LigCliente => LigCliente,
        NomesCamposTabela.LigContato => LigContato,
        NomesCamposTabela.LigDataRealizada => LigDataRealizada,
        NomesCamposTabela.LigQuemID => LigQuemID,
        NomesCamposTabela.LigTelefonista => LigTelefonista,
        NomesCamposTabela.LigUltimoAviso => LigUltimoAviso,
        NomesCamposTabela.LigHoraFinal => LigHoraFinal,
        NomesCamposTabela.LigNome => LigNome,
        NomesCamposTabela.LigQuemCodigo => LigQuemCodigo,
        NomesCamposTabela.LigSolicitante => LigSolicitante,
        NomesCamposTabela.LigPara => LigPara,
        NomesCamposTabela.LigFone => LigFone,
        NomesCamposTabela.LigRamal => LigRamal,
        NomesCamposTabela.LigParticular => LigParticular,
        NomesCamposTabela.LigRealizada => LigRealizada,
        NomesCamposTabela.LigStatus => LigStatus,
        NomesCamposTabela.LigData => LigData,
        NomesCamposTabela.LigHora => LigHora,
        NomesCamposTabela.LigUrgente => LigUrgente,
        NomesCamposTabela.LigLigarPara => LigLigarPara,
        NomesCamposTabela.LigProcesso => LigProcesso,
        NomesCamposTabela.LigStartScreen => LigStartScreen,
        NomesCamposTabela.LigEmotion => LigEmotion,
        NomesCamposTabela.LigBold => LigBold,
        NomesCamposTabela.LigGUID => LigGUID,
        NomesCamposTabela.LigQuemCad => LigQuemCad,
        NomesCamposTabela.LigDtCad => LigDtCad,
        NomesCamposTabela.LigQuemAtu => LigQuemAtu,
        NomesCamposTabela.LigDtAtu => LigDtAtu,
        NomesCamposTabela.LigVisto => LigVisto,
        _ => null
    };
}