using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBRecadosDicInfo
{
    public const string CampoCodigo = "recCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "rec";
    public const string ClienteNome = "recClienteNome"; // LOCALIZACAO 170523
    public const string De = "recDe"; // LOCALIZACAO 170523
    public const string Para = "recPara"; // LOCALIZACAO 170523
    public const string Assunto = "recAssunto"; // LOCALIZACAO 170523
    public const string Concluido = "recConcluido"; // LOCALIZACAO 170523
    public const string Processo = "recProcesso"; // LOCALIZACAO 170523
    public const string Cliente = "recCliente"; // LOCALIZACAO 170523
    public const string Recado = "recRecado"; // LOCALIZACAO 170523
    public const string Urgente = "recUrgente"; // LOCALIZACAO 170523
    public const string Importante = "recImportante"; // LOCALIZACAO 170523
    public const string Hora = "recHora"; // LOCALIZACAO 170523
    public const string Data = "recData"; // LOCALIZACAO 170523
    public const string Voltara = "recVoltara"; // LOCALIZACAO 170523
    public const string Pessoal = "recPessoal"; // LOCALIZACAO 170523
    public const string Retornar = "recRetornar"; // LOCALIZACAO 170523
    public const string RetornoData = "recRetornoData"; // LOCALIZACAO 170523
    public const string Emotion = "recEmotion"; // LOCALIZACAO 170523
    public const string InternetID = "recInternetID"; // LOCALIZACAO 170523
    public const string Uploaded = "recUploaded"; // LOCALIZACAO 170523
    public const string Natureza = "recNatureza"; // LOCALIZACAO 170523
    public const string BIU = "recBIU"; // LOCALIZACAO 170523
    public const string AguardarRetorno = "recAguardarRetorno"; // LOCALIZACAO 170523
    public const string AguardarRetornoPara = "recAguardarRetornoPara"; // LOCALIZACAO 170523
    public const string AguardarRetornoOK = "recAguardarRetornoOK"; // LOCALIZACAO 170523
    public const string ParaID = "recParaID"; // LOCALIZACAO 170523
    public const string NaoPublicavel = "recNaoPublicavel"; // LOCALIZACAO 170523
    public const string IsContatoCRM = "recIsContatoCRM"; // LOCALIZACAO 170523
    public const string MasterID = "recMasterID"; // LOCALIZACAO 170523
    public const string ListaPara = "recListaPara"; // LOCALIZACAO 170523
    public const string Typed = "recTyped"; // LOCALIZACAO 170523
    public const string AssuntoRecado = "recAssuntoRecado"; // LOCALIZACAO 170523
    public const string Historico = "recHistorico"; // LOCALIZACAO 170523
    public const string ContatoCRM = "recContatoCRM"; // LOCALIZACAO 170523
    public const string Ligacoes = "recLigacoes"; // LOCALIZACAO 170523
    public const string Agenda = "recAgenda"; // LOCALIZACAO 170523
    public const string GUID = "recGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "recQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "recDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "recQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "recDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "recVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => ClienteNome,
        2 => De,
        3 => Para,
        4 => Assunto,
        5 => Concluido,
        6 => Processo,
        7 => Cliente,
        8 => Recado,
        9 => Urgente,
        10 => Importante,
        11 => Hora,
        12 => Data,
        13 => Voltara,
        14 => Pessoal,
        15 => Retornar,
        16 => RetornoData,
        17 => Emotion,
        18 => InternetID,
        19 => Uploaded,
        20 => Natureza,
        21 => BIU,
        22 => AguardarRetorno,
        23 => AguardarRetornoPara,
        24 => AguardarRetornoOK,
        25 => ParaID,
        26 => NaoPublicavel,
        27 => IsContatoCRM,
        28 => MasterID,
        29 => ListaPara,
        30 => Typed,
        31 => AssuntoRecado,
        32 => Historico,
        33 => ContatoCRM,
        34 => Ligacoes,
        35 => Agenda,
        36 => GUID,
        37 => QuemCad,
        38 => DtCad,
        39 => QuemAtu,
        40 => DtAtu,
        41 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Recados";
#region PropriedadesDaTabela
    public static DBInfoSystem RecClienteNome => new(0, PTabelaNome, CampoCodigo, ClienteNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem RecDe => new(0, PTabelaNome, CampoCodigo, De, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem RecPara => new(0, PTabelaNome, CampoCodigo, Para, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem RecAssunto => new(0, PTabelaNome, CampoCodigo, Assunto, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem RecConcluido => new(0, PTabelaNome, CampoCodigo, Concluido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem RecCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem RecRecado => new(0, PTabelaNome, CampoCodigo, Recado, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem RecUrgente => new(0, PTabelaNome, CampoCodigo, Urgente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecImportante => new(0, PTabelaNome, CampoCodigo, Importante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RecData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RecVoltara => new(0, PTabelaNome, CampoCodigo, Voltara, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecPessoal => new(0, PTabelaNome, CampoCodigo, Pessoal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecRetornar => new(0, PTabelaNome, CampoCodigo, Retornar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecRetornoData => new(0, PTabelaNome, CampoCodigo, RetornoData, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RecEmotion => new(0, PTabelaNome, CampoCodigo, Emotion, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RecInternetID => new(0, PTabelaNome, CampoCodigo, InternetID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RecUploaded => new(0, PTabelaNome, CampoCodigo, Uploaded, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecNatureza => new(0, PTabelaNome, CampoCodigo, Natureza, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RecBIU => new(0, PTabelaNome, CampoCodigo, BIU, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecAguardarRetorno => new(0, PTabelaNome, CampoCodigo, AguardarRetorno, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecAguardarRetornoPara => new(0, PTabelaNome, CampoCodigo, AguardarRetornoPara, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem RecAguardarRetornoOK => new(0, PTabelaNome, CampoCodigo, AguardarRetornoOK, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecParaID => new(0, PTabelaNome, CampoCodigo, ParaID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RecNaoPublicavel => new(0, PTabelaNome, CampoCodigo, NaoPublicavel, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecIsContatoCRM => new(0, PTabelaNome, CampoCodigo, IsContatoCRM, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecMasterID => new(0, PTabelaNome, CampoCodigo, MasterID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RecListaPara => new(0, PTabelaNome, CampoCodigo, ListaPara, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem RecTyped => new(0, PTabelaNome, CampoCodigo, Typed, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RecAssuntoRecado => new(0, PTabelaNome, CampoCodigo, AssuntoRecado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RecHistorico => new(0, PTabelaNome, CampoCodigo, Historico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBHistoricoDicInfo.CampoCodigo, DBHistoricoDicInfo.TabelaNome, new DBHistoricoODicInfo(), false); // DBI 11 
    public static DBInfoSystem RecContatoCRM => new(0, PTabelaNome, CampoCodigo, ContatoCRM, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBContatoCRMDicInfo.CampoCodigo, DBContatoCRMDicInfo.TabelaNome, new DBContatoCRMODicInfo(), false); // DBI 11 
    public static DBInfoSystem RecLigacoes => new(0, PTabelaNome, CampoCodigo, Ligacoes, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBLigacoesDicInfo.CampoCodigo, DBLigacoesDicInfo.TabelaNome, new DBLigacoesODicInfo(), false); // DBI 11 
    public static DBInfoSystem RecAgenda => new(0, PTabelaNome, CampoCodigo, Agenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAgendaDicInfo.CampoCodigo, DBAgendaDicInfo.TabelaNome, new DBAgendaODicInfo(), false); // DBI 11 
    public static DBInfoSystem RecGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem RecQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem RecDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem RecQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem RecDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem RecVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string ClienteNomeSql(string text) => ClienteNome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string ClienteNomeSqlNotIsNull => ClienteNome.SqlCmdNotIsNull() ?? string.Empty;
    public static string ClienteNomeSqlIsNull => ClienteNome.SqlCmdIsNull() ?? string.Empty;

    public static string ClienteNomeSqlDiff(string text) => ClienteNome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ClienteNomeSqlLike(string text) => ClienteNome.SqlCmdTextLike(text) ?? string.Empty;
    public static string ClienteNomeSqlLikeInit(string text) => ClienteNome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ClienteNomeSqlLikeSpaces(string? text) => ClienteNome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DeSql(string text) => De.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string DeSqlNotIsNull => De.SqlCmdNotIsNull() ?? string.Empty;
    public static string DeSqlIsNull => De.SqlCmdIsNull() ?? string.Empty;

    public static string DeSqlDiff(string text) => De.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DeSqlLike(string text) => De.SqlCmdTextLike(text) ?? string.Empty;
    public static string DeSqlLikeInit(string text) => De.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DeSqlLikeSpaces(string? text) => De.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ParaSql(string text) => Para.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string ParaSqlNotIsNull => Para.SqlCmdNotIsNull() ?? string.Empty;
    public static string ParaSqlIsNull => Para.SqlCmdIsNull() ?? string.Empty;

    public static string ParaSqlDiff(string text) => Para.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ParaSqlLike(string text) => Para.SqlCmdTextLike(text) ?? string.Empty;
    public static string ParaSqlLikeInit(string text) => Para.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ParaSqlLikeSpaces(string? text) => Para.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AssuntoSql(string text) => Assunto.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string AssuntoSqlNotIsNull => Assunto.SqlCmdNotIsNull() ?? string.Empty;
    public static string AssuntoSqlIsNull => Assunto.SqlCmdIsNull() ?? string.Empty;

    public static string AssuntoSqlDiff(string text) => Assunto.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AssuntoSqlLike(string text) => Assunto.SqlCmdTextLike(text) ?? string.Empty;
    public static string AssuntoSqlLikeInit(string text) => Assunto.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AssuntoSqlLikeSpaces(string? text) => Assunto.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ConcluidoSql(bool valueCheck) => Concluido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ConcluidoSqlSim => Concluido.SqlCmdBoolSim() ?? string.Empty;
    public static string ConcluidoSqlNao => Concluido.SqlCmdBoolNao() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

    public static string RecadoSql(string text) => Recado.SqlCmdTextIgual(text) ?? string.Empty;
    public static string RecadoSqlNotIsNull => Recado.SqlCmdNotIsNull() ?? string.Empty;
    public static string RecadoSqlIsNull => Recado.SqlCmdIsNull() ?? string.Empty;

    public static string RecadoSqlDiff(string text) => Recado.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RecadoSqlLike(string text) => Recado.SqlCmdTextLike(text) ?? string.Empty;
    public static string RecadoSqlLikeInit(string text) => Recado.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RecadoSqlLikeSpaces(string? text) => Recado.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string UrgenteSql(bool valueCheck) => Urgente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string UrgenteSqlSim => Urgente.SqlCmdBoolSim() ?? string.Empty;
    public static string UrgenteSqlNao => Urgente.SqlCmdBoolNao() ?? string.Empty;

    public static string ImportanteSql(bool valueCheck) => Importante.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ImportanteSqlSim => Importante.SqlCmdBoolSim() ?? string.Empty;
    public static string ImportanteSqlNao => Importante.SqlCmdBoolNao() ?? string.Empty;

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

    public static string VoltaraSql(bool valueCheck) => Voltara.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string VoltaraSqlSim => Voltara.SqlCmdBoolSim() ?? string.Empty;
    public static string VoltaraSqlNao => Voltara.SqlCmdBoolNao() ?? string.Empty;

    public static string PessoalSql(bool valueCheck) => Pessoal.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string PessoalSqlSim => Pessoal.SqlCmdBoolSim() ?? string.Empty;
    public static string PessoalSqlNao => Pessoal.SqlCmdBoolNao() ?? string.Empty;

    public static string RetornarSql(bool valueCheck) => Retornar.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string RetornarSqlSim => Retornar.SqlCmdBoolSim() ?? string.Empty;
    public static string RetornarSqlNao => Retornar.SqlCmdBoolNao() ?? string.Empty;

    public static string RetornoDataSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{RetornoData}]");
    public static string RetornoDataSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{RetornoData}]");
    public static string RetornoDataSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{RetornoData}]");
    public static string RetornoDataSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{RetornoData}]");
    public static string RetornoDataSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{RetornoData}]");
    public static string RetornoDataSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{RetornoData}]");
    public static string RetornoDataSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{RetornoData}]");
    public static string RetornoDataSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{RetornoData}]");
    public static string RetornoDataSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{RetornoData}]");
    public static string RetornoDataSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{RetornoData}]");
    public static string RetornoDataSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{RetornoData}]");
    public static string RetornoDataSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{RetornoData}]");
    public static string RetornoDataIsNull => RetornoData.SqlCmdIsNull() ?? string.Empty;
    public static string RetornoDataNotIsNull => RetornoData.SqlCmdNotIsNull() ?? string.Empty;

    public static string EmotionDiff(int id) => Emotion.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string EmotionSql(int id) => Emotion.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string EmotionIsNull => Emotion.SqlCmdIsNull() ?? string.Empty;
    public static string EmotionNotIsNull => Emotion.SqlCmdNotIsNull() ?? string.Empty;

    public static string InternetIDDiff(int id) => InternetID.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string InternetIDSql(int id) => InternetID.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string InternetIDIsNull => InternetID.SqlCmdIsNull() ?? string.Empty;
    public static string InternetIDNotIsNull => InternetID.SqlCmdNotIsNull() ?? string.Empty;

    public static string UploadedSql(bool valueCheck) => Uploaded.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string UploadedSqlSim => Uploaded.SqlCmdBoolSim() ?? string.Empty;
    public static string UploadedSqlNao => Uploaded.SqlCmdBoolNao() ?? string.Empty;

    public static string NaturezaDiff(int id) => Natureza.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string NaturezaSql(int id) => Natureza.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string NaturezaIsNull => Natureza.SqlCmdIsNull() ?? string.Empty;
    public static string NaturezaNotIsNull => Natureza.SqlCmdNotIsNull() ?? string.Empty;

    public static string BIUSql(bool valueCheck) => BIU.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BIUSqlSim => BIU.SqlCmdBoolSim() ?? string.Empty;
    public static string BIUSqlNao => BIU.SqlCmdBoolNao() ?? string.Empty;

    public static string AguardarRetornoSql(bool valueCheck) => AguardarRetorno.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AguardarRetornoSqlSim => AguardarRetorno.SqlCmdBoolSim() ?? string.Empty;
    public static string AguardarRetornoSqlNao => AguardarRetorno.SqlCmdBoolNao() ?? string.Empty;

    public static string AguardarRetornoParaSql(string text) => AguardarRetornoPara.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string AguardarRetornoParaSqlNotIsNull => AguardarRetornoPara.SqlCmdNotIsNull() ?? string.Empty;
    public static string AguardarRetornoParaSqlIsNull => AguardarRetornoPara.SqlCmdIsNull() ?? string.Empty;

    public static string AguardarRetornoParaSqlDiff(string text) => AguardarRetornoPara.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AguardarRetornoParaSqlLike(string text) => AguardarRetornoPara.SqlCmdTextLike(text) ?? string.Empty;
    public static string AguardarRetornoParaSqlLikeInit(string text) => AguardarRetornoPara.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AguardarRetornoParaSqlLikeSpaces(string? text) => AguardarRetornoPara.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AguardarRetornoOKSql(bool valueCheck) => AguardarRetornoOK.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AguardarRetornoOKSqlSim => AguardarRetornoOK.SqlCmdBoolSim() ?? string.Empty;
    public static string AguardarRetornoOKSqlNao => AguardarRetornoOK.SqlCmdBoolNao() ?? string.Empty;

    public static string ParaIDDiff(int id) => ParaID.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ParaIDSql(int id) => ParaID.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ParaIDIsNull => ParaID.SqlCmdIsNull() ?? string.Empty;
    public static string ParaIDNotIsNull => ParaID.SqlCmdNotIsNull() ?? string.Empty;

    public static string NaoPublicavelSql(bool valueCheck) => NaoPublicavel.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string NaoPublicavelSqlSim => NaoPublicavel.SqlCmdBoolSim() ?? string.Empty;
    public static string NaoPublicavelSqlNao => NaoPublicavel.SqlCmdBoolNao() ?? string.Empty;

    public static string IsContatoCRMSql(bool valueCheck) => IsContatoCRM.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IsContatoCRMSqlSim => IsContatoCRM.SqlCmdBoolSim() ?? string.Empty;
    public static string IsContatoCRMSqlNao => IsContatoCRM.SqlCmdBoolNao() ?? string.Empty;

    public static string MasterIDDiff(int id) => MasterID.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string MasterIDSql(int id) => MasterID.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string MasterIDIsNull => MasterID.SqlCmdIsNull() ?? string.Empty;
    public static string MasterIDNotIsNull => MasterID.SqlCmdNotIsNull() ?? string.Empty;

    public static string ListaParaSql(string text) => ListaPara.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ListaParaSqlNotIsNull => ListaPara.SqlCmdNotIsNull() ?? string.Empty;
    public static string ListaParaSqlIsNull => ListaPara.SqlCmdIsNull() ?? string.Empty;

    public static string ListaParaSqlDiff(string text) => ListaPara.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ListaParaSqlLike(string text) => ListaPara.SqlCmdTextLike(text) ?? string.Empty;
    public static string ListaParaSqlLikeInit(string text) => ListaPara.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ListaParaSqlLikeSpaces(string? text) => ListaPara.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TypedSql(bool valueCheck) => Typed.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TypedSqlSim => Typed.SqlCmdBoolSim() ?? string.Empty;
    public static string TypedSqlNao => Typed.SqlCmdBoolNao() ?? string.Empty;

    public static string AssuntoRecadoDiff(int id) => AssuntoRecado.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AssuntoRecadoSql(int id) => AssuntoRecado.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AssuntoRecadoIsNull => AssuntoRecado.SqlCmdIsNull() ?? string.Empty;
    public static string AssuntoRecadoNotIsNull => AssuntoRecado.SqlCmdNotIsNull() ?? string.Empty;

    public static string HistoricoDiff(int id) => Historico.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string HistoricoSql(int id) => Historico.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string HistoricoIsNull => Historico.SqlCmdIsNull() ?? string.Empty;
    public static string HistoricoNotIsNull => Historico.SqlCmdNotIsNull() ?? string.Empty;

    public static string ContatoCRMDiff(int id) => ContatoCRM.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ContatoCRMSql(int id) => ContatoCRM.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ContatoCRMIsNull => ContatoCRM.SqlCmdIsNull() ?? string.Empty;
    public static string ContatoCRMNotIsNull => ContatoCRM.SqlCmdNotIsNull() ?? string.Empty;

    public static string LigacoesDiff(int id) => Ligacoes.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string LigacoesSql(int id) => Ligacoes.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string LigacoesIsNull => Ligacoes.SqlCmdIsNull() ?? string.Empty;
    public static string LigacoesNotIsNull => Ligacoes.SqlCmdNotIsNull() ?? string.Empty;

    public static string AgendaDiff(int id) => Agenda.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AgendaSql(int id) => Agenda.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AgendaIsNull => Agenda.SqlCmdIsNull() ?? string.Empty;
    public static string AgendaNotIsNull => Agenda.SqlCmdNotIsNull() ?? string.Empty;

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
        RecClienteNome = 1,
        RecDe = 2,
        RecPara = 3,
        RecAssunto = 4,
        RecConcluido = 5,
        RecProcesso = 6,
        RecCliente = 7,
        RecRecado = 8,
        RecUrgente = 9,
        RecImportante = 10,
        RecHora = 11,
        RecData = 12,
        RecVoltara = 13,
        RecPessoal = 14,
        RecRetornar = 15,
        RecRetornoData = 16,
        RecEmotion = 17,
        RecInternetID = 18,
        RecUploaded = 19,
        RecNatureza = 20,
        RecBIU = 21,
        RecAguardarRetorno = 22,
        RecAguardarRetornoPara = 23,
        RecAguardarRetornoOK = 24,
        RecParaID = 25,
        RecNaoPublicavel = 26,
        RecIsContatoCRM = 27,
        RecMasterID = 28,
        RecListaPara = 29,
        RecTyped = 30,
        RecAssuntoRecado = 31,
        RecHistorico = 32,
        RecContatoCRM = 33,
        RecLigacoes = 34,
        RecAgenda = 35,
        RecGUID = 36,
        RecQuemCad = 37,
        RecDtCad = 38,
        RecQuemAtu = 39,
        RecDtAtu = 40,
        RecVisto = 41
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RecClienteNome => RecClienteNome,
        NomesCamposTabela.RecDe => RecDe,
        NomesCamposTabela.RecPara => RecPara,
        NomesCamposTabela.RecAssunto => RecAssunto,
        NomesCamposTabela.RecConcluido => RecConcluido,
        NomesCamposTabela.RecProcesso => RecProcesso,
        NomesCamposTabela.RecCliente => RecCliente,
        NomesCamposTabela.RecRecado => RecRecado,
        NomesCamposTabela.RecUrgente => RecUrgente,
        NomesCamposTabela.RecImportante => RecImportante,
        NomesCamposTabela.RecHora => RecHora,
        NomesCamposTabela.RecData => RecData,
        NomesCamposTabela.RecVoltara => RecVoltara,
        NomesCamposTabela.RecPessoal => RecPessoal,
        NomesCamposTabela.RecRetornar => RecRetornar,
        NomesCamposTabela.RecRetornoData => RecRetornoData,
        NomesCamposTabela.RecEmotion => RecEmotion,
        NomesCamposTabela.RecInternetID => RecInternetID,
        NomesCamposTabela.RecUploaded => RecUploaded,
        NomesCamposTabela.RecNatureza => RecNatureza,
        NomesCamposTabela.RecBIU => RecBIU,
        NomesCamposTabela.RecAguardarRetorno => RecAguardarRetorno,
        NomesCamposTabela.RecAguardarRetornoPara => RecAguardarRetornoPara,
        NomesCamposTabela.RecAguardarRetornoOK => RecAguardarRetornoOK,
        NomesCamposTabela.RecParaID => RecParaID,
        NomesCamposTabela.RecNaoPublicavel => RecNaoPublicavel,
        NomesCamposTabela.RecIsContatoCRM => RecIsContatoCRM,
        NomesCamposTabela.RecMasterID => RecMasterID,
        NomesCamposTabela.RecListaPara => RecListaPara,
        NomesCamposTabela.RecTyped => RecTyped,
        NomesCamposTabela.RecAssuntoRecado => RecAssuntoRecado,
        NomesCamposTabela.RecHistorico => RecHistorico,
        NomesCamposTabela.RecContatoCRM => RecContatoCRM,
        NomesCamposTabela.RecLigacoes => RecLigacoes,
        NomesCamposTabela.RecAgenda => RecAgenda,
        NomesCamposTabela.RecGUID => RecGUID,
        NomesCamposTabela.RecQuemCad => RecQuemCad,
        NomesCamposTabela.RecDtCad => RecDtCad,
        NomesCamposTabela.RecQuemAtu => RecQuemAtu,
        NomesCamposTabela.RecDtAtu => RecDtAtu,
        NomesCamposTabela.RecVisto => RecVisto,
        _ => null
    };
}