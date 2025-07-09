using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBContatoCRMDicInfo
{
    public const string CampoCodigo = "ctcCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ctc";
    public const string AgeClienteAvisado = "ctcAgeClienteAvisado"; // LOCALIZACAO 170523
    public const string DocsViaRecebimento = "ctcDocsViaRecebimento"; // LOCALIZACAO 170523
    public const string NaoPublicavel = "ctcNaoPublicavel"; // LOCALIZACAO 170523
    public const string Notificar = "ctcNotificar"; // LOCALIZACAO 170523
    public const string Ocultar = "ctcOcultar"; // LOCALIZACAO 170523
    public const string Assunto = "ctcAssunto"; // LOCALIZACAO 170523
    public const string IsDocsRecebidos = "ctcIsDocsRecebidos"; // LOCALIZACAO 170523
    public const string QuemNotificou = "ctcQuemNotificou"; // LOCALIZACAO 170523
    public const string DataNotificou = "ctcDataNotificou"; // LOCALIZACAO 170523
    public const string Operador = "ctcOperador"; // LOCALIZACAO 170523
    public const string Cliente = "ctcCliente"; // LOCALIZACAO 170523
    public const string HoraNotificou = "ctcHoraNotificou"; // LOCALIZACAO 170523
    public const string ObjetoNotificou = "ctcObjetoNotificou"; // LOCALIZACAO 170523
    public const string PessoaContato = "ctcPessoaContato"; // LOCALIZACAO 170523
    public const string Data = "ctcData"; // LOCALIZACAO 170523
    public const string Tempo = "ctcTempo"; // LOCALIZACAO 170523
    public const string HoraInicial = "ctcHoraInicial"; // LOCALIZACAO 170523
    public const string HoraFinal = "ctcHoraFinal"; // LOCALIZACAO 170523
    public const string Processo = "ctcProcesso"; // LOCALIZACAO 170523
    public const string Importante = "ctcImportante"; // LOCALIZACAO 170523
    public const string Urgente = "ctcUrgente"; // LOCALIZACAO 170523
    public const string GerarHoraTrabalhada = "ctcGerarHoraTrabalhada"; // LOCALIZACAO 170523
    public const string ExibirNoTopo = "ctcExibirNoTopo"; // LOCALIZACAO 170523
    public const string TipoContatoCRM = "ctcTipoContatoCRM"; // LOCALIZACAO 170523
    public const string Contato = "ctcContato"; // LOCALIZACAO 170523
    public const string Emocao = "ctcEmocao"; // LOCALIZACAO 170523
    public const string Continuar = "ctcContinuar"; // LOCALIZACAO 170523
    public const string Bold = "ctcBold"; // LOCALIZACAO 170523
    public const string GUID = "ctcGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ctcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ctcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ctcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ctcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ctcVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => AgeClienteAvisado,
        2 => DocsViaRecebimento,
        3 => NaoPublicavel,
        4 => Notificar,
        5 => Ocultar,
        6 => Assunto,
        7 => IsDocsRecebidos,
        8 => QuemNotificou,
        9 => DataNotificou,
        10 => Operador,
        11 => Cliente,
        12 => HoraNotificou,
        13 => ObjetoNotificou,
        14 => PessoaContato,
        15 => Data,
        16 => Tempo,
        17 => HoraInicial,
        18 => HoraFinal,
        19 => Processo,
        20 => Importante,
        21 => Urgente,
        22 => GerarHoraTrabalhada,
        23 => ExibirNoTopo,
        24 => TipoContatoCRM,
        25 => Contato,
        26 => Emocao,
        27 => Continuar,
        28 => Bold,
        29 => GUID,
        30 => QuemCad,
        31 => DtCad,
        32 => QuemAtu,
        33 => DtAtu,
        34 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ContatoCRM";
#region PropriedadesDaTabela
    public static DBInfoSystem CtcAgeClienteAvisado => new(0, PTabelaNome, CampoCodigo, AgeClienteAvisado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CtcDocsViaRecebimento => new(0, PTabelaNome, CampoCodigo, DocsViaRecebimento, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CtcNaoPublicavel => new(0, PTabelaNome, CampoCodigo, NaoPublicavel, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CtcNotificar => new(0, PTabelaNome, CampoCodigo, Notificar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CtcOcultar => new(0, PTabelaNome, CampoCodigo, Ocultar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CtcAssunto => new(0, PTabelaNome, CampoCodigo, Assunto, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CtcIsDocsRecebidos => new(0, PTabelaNome, CampoCodigo, IsDocsRecebidos, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CtcQuemNotificou => new(0, PTabelaNome, CampoCodigo, QuemNotificou, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CtcDataNotificou => new(0, PTabelaNome, CampoCodigo, DataNotificou, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CtcOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem CtcCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem CtcHoraNotificou => new(0, PTabelaNome, CampoCodigo, HoraNotificou, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CtcObjetoNotificou => new(0, PTabelaNome, CampoCodigo, ObjetoNotificou, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CtcPessoaContato => new(0, PTabelaNome, CampoCodigo, PessoaContato, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CtcData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CtcTempo => new(0, PTabelaNome, CampoCodigo, Tempo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem CtcHoraInicial => new(0, PTabelaNome, CampoCodigo, HoraInicial, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CtcHoraFinal => new(0, PTabelaNome, CampoCodigo, HoraFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CtcProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem CtcImportante => new(0, PTabelaNome, CampoCodigo, Importante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CtcUrgente => new(0, PTabelaNome, CampoCodigo, Urgente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CtcGerarHoraTrabalhada => new(0, PTabelaNome, CampoCodigo, GerarHoraTrabalhada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CtcExibirNoTopo => new(0, PTabelaNome, CampoCodigo, ExibirNoTopo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CtcTipoContatoCRM => new(0, PTabelaNome, CampoCodigo, TipoContatoCRM, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoContatoCRMDicInfo.CampoCodigo, DBTipoContatoCRMDicInfo.TabelaNome, new DBTipoContatoCRMODicInfo(), false); // DBI 11 
    public static DBInfoSystem CtcContato => new(0, PTabelaNome, CampoCodigo, Contato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem CtcEmocao => new(0, PTabelaNome, CampoCodigo, Emocao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CtcContinuar => new(0, PTabelaNome, CampoCodigo, Continuar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CtcBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem CtcGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem CtcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem CtcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem CtcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem CtcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem CtcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string NaoPublicavelSql(bool valueCheck) => NaoPublicavel.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string NaoPublicavelSqlSim => NaoPublicavel.SqlCmdBoolSim() ?? string.Empty;
    public static string NaoPublicavelSqlNao => NaoPublicavel.SqlCmdBoolNao() ?? string.Empty;

    public static string NotificarSql(bool valueCheck) => Notificar.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string NotificarSqlSim => Notificar.SqlCmdBoolSim() ?? string.Empty;
    public static string NotificarSqlNao => Notificar.SqlCmdBoolNao() ?? string.Empty;

    public static string OcultarSql(bool valueCheck) => Ocultar.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string OcultarSqlSim => Ocultar.SqlCmdBoolSim() ?? string.Empty;
    public static string OcultarSqlNao => Ocultar.SqlCmdBoolNao() ?? string.Empty;

    public static string AssuntoSql(string text) => Assunto.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string AssuntoSqlNotIsNull => Assunto.SqlCmdNotIsNull() ?? string.Empty;
    public static string AssuntoSqlIsNull => Assunto.SqlCmdIsNull() ?? string.Empty;

    public static string AssuntoSqlDiff(string text) => Assunto.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AssuntoSqlLike(string text) => Assunto.SqlCmdTextLike(text) ?? string.Empty;
    public static string AssuntoSqlLikeInit(string text) => Assunto.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AssuntoSqlLikeSpaces(string? text) => Assunto.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string IsDocsRecebidosSql(bool valueCheck) => IsDocsRecebidos.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IsDocsRecebidosSqlSim => IsDocsRecebidos.SqlCmdBoolSim() ?? string.Empty;
    public static string IsDocsRecebidosSqlNao => IsDocsRecebidos.SqlCmdBoolNao() ?? string.Empty;

    public static string DataNotificouSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataNotificou}]");
    public static string DataNotificouSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataNotificou}]");
    public static string DataNotificouSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataNotificou}]");
    public static string DataNotificouSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataNotificou}]");
    public static string DataNotificouSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataNotificou}]");
    public static string DataNotificouSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataNotificou}]");
    public static string DataNotificouSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataNotificou}]");
    public static string DataNotificouSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataNotificou}]");
    public static string DataNotificouSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataNotificou}]");
    public static string DataNotificouSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataNotificou}]");
    public static string DataNotificouSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataNotificou}]");
    public static string DataNotificouSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataNotificou}]");
    public static string DataNotificouIsNull => DataNotificou.SqlCmdIsNull() ?? string.Empty;
    public static string DataNotificouNotIsNull => DataNotificou.SqlCmdNotIsNull() ?? string.Empty;

    public static string HoraNotificouSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{HoraNotificou}]");
    public static string HoraNotificouSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{HoraNotificou}]");
    public static string HoraNotificouIsNull => HoraNotificou.SqlCmdIsNull() ?? string.Empty;
    public static string HoraNotificouNotIsNull => HoraNotificou.SqlCmdNotIsNull() ?? string.Empty;

    public static string PessoaContatoSql(string text) => PessoaContato.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string PessoaContatoSqlNotIsNull => PessoaContato.SqlCmdNotIsNull() ?? string.Empty;
    public static string PessoaContatoSqlIsNull => PessoaContato.SqlCmdIsNull() ?? string.Empty;

    public static string PessoaContatoSqlDiff(string text) => PessoaContato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PessoaContatoSqlLike(string text) => PessoaContato.SqlCmdTextLike(text) ?? string.Empty;
    public static string PessoaContatoSqlLikeInit(string text) => PessoaContato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PessoaContatoSqlLikeSpaces(string? text) => PessoaContato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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

    public static string HoraInicialSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{HoraInicial}]");
    public static string HoraInicialSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{HoraInicial}]");
    public static string HoraInicialSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{HoraInicial}]");
    public static string HoraInicialSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{HoraInicial}]");
    public static string HoraInicialSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{HoraInicial}]");
    public static string HoraInicialSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{HoraInicial}]");
    public static string HoraInicialSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{HoraInicial}]");
    public static string HoraInicialSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{HoraInicial}]");
    public static string HoraInicialSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{HoraInicial}]");
    public static string HoraInicialSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{HoraInicial}]");
    public static string HoraInicialSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{HoraInicial}]");
    public static string HoraInicialSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{HoraInicial}]");
    public static string HoraInicialIsNull => HoraInicial.SqlCmdIsNull() ?? string.Empty;
    public static string HoraInicialNotIsNull => HoraInicial.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string ImportanteSql(bool valueCheck) => Importante.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ImportanteSqlSim => Importante.SqlCmdBoolSim() ?? string.Empty;
    public static string ImportanteSqlNao => Importante.SqlCmdBoolNao() ?? string.Empty;

    public static string UrgenteSql(bool valueCheck) => Urgente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string UrgenteSqlSim => Urgente.SqlCmdBoolSim() ?? string.Empty;
    public static string UrgenteSqlNao => Urgente.SqlCmdBoolNao() ?? string.Empty;

    public static string GerarHoraTrabalhadaSql(bool valueCheck) => GerarHoraTrabalhada.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string GerarHoraTrabalhadaSqlSim => GerarHoraTrabalhada.SqlCmdBoolSim() ?? string.Empty;
    public static string GerarHoraTrabalhadaSqlNao => GerarHoraTrabalhada.SqlCmdBoolNao() ?? string.Empty;

    public static string ExibirNoTopoSql(bool valueCheck) => ExibirNoTopo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ExibirNoTopoSqlSim => ExibirNoTopo.SqlCmdBoolSim() ?? string.Empty;
    public static string ExibirNoTopoSqlNao => ExibirNoTopo.SqlCmdBoolNao() ?? string.Empty;

    public static string ContatoSql(string text) => Contato.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ContatoSqlNotIsNull => Contato.SqlCmdNotIsNull() ?? string.Empty;
    public static string ContatoSqlIsNull => Contato.SqlCmdIsNull() ?? string.Empty;

    public static string ContatoSqlDiff(string text) => Contato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ContatoSqlLike(string text) => Contato.SqlCmdTextLike(text) ?? string.Empty;
    public static string ContatoSqlLikeInit(string text) => Contato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ContatoSqlLikeSpaces(string? text) => Contato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ContinuarSql(bool valueCheck) => Continuar.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ContinuarSqlSim => Continuar.SqlCmdBoolSim() ?? string.Empty;
    public static string ContinuarSqlNao => Continuar.SqlCmdBoolNao() ?? string.Empty;

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
        CtcAgeClienteAvisado = 1,
        CtcDocsViaRecebimento = 2,
        CtcNaoPublicavel = 3,
        CtcNotificar = 4,
        CtcOcultar = 5,
        CtcAssunto = 6,
        CtcIsDocsRecebidos = 7,
        CtcQuemNotificou = 8,
        CtcDataNotificou = 9,
        CtcOperador = 10,
        CtcCliente = 11,
        CtcHoraNotificou = 12,
        CtcObjetoNotificou = 13,
        CtcPessoaContato = 14,
        CtcData = 15,
        CtcTempo = 16,
        CtcHoraInicial = 17,
        CtcHoraFinal = 18,
        CtcProcesso = 19,
        CtcImportante = 20,
        CtcUrgente = 21,
        CtcGerarHoraTrabalhada = 22,
        CtcExibirNoTopo = 23,
        CtcTipoContatoCRM = 24,
        CtcContato = 25,
        CtcEmocao = 26,
        CtcContinuar = 27,
        CtcBold = 28,
        CtcGUID = 29,
        CtcQuemCad = 30,
        CtcDtCad = 31,
        CtcQuemAtu = 32,
        CtcDtAtu = 33,
        CtcVisto = 34
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CtcAgeClienteAvisado => CtcAgeClienteAvisado,
        NomesCamposTabela.CtcDocsViaRecebimento => CtcDocsViaRecebimento,
        NomesCamposTabela.CtcNaoPublicavel => CtcNaoPublicavel,
        NomesCamposTabela.CtcNotificar => CtcNotificar,
        NomesCamposTabela.CtcOcultar => CtcOcultar,
        NomesCamposTabela.CtcAssunto => CtcAssunto,
        NomesCamposTabela.CtcIsDocsRecebidos => CtcIsDocsRecebidos,
        NomesCamposTabela.CtcQuemNotificou => CtcQuemNotificou,
        NomesCamposTabela.CtcDataNotificou => CtcDataNotificou,
        NomesCamposTabela.CtcOperador => CtcOperador,
        NomesCamposTabela.CtcCliente => CtcCliente,
        NomesCamposTabela.CtcHoraNotificou => CtcHoraNotificou,
        NomesCamposTabela.CtcObjetoNotificou => CtcObjetoNotificou,
        NomesCamposTabela.CtcPessoaContato => CtcPessoaContato,
        NomesCamposTabela.CtcData => CtcData,
        NomesCamposTabela.CtcTempo => CtcTempo,
        NomesCamposTabela.CtcHoraInicial => CtcHoraInicial,
        NomesCamposTabela.CtcHoraFinal => CtcHoraFinal,
        NomesCamposTabela.CtcProcesso => CtcProcesso,
        NomesCamposTabela.CtcImportante => CtcImportante,
        NomesCamposTabela.CtcUrgente => CtcUrgente,
        NomesCamposTabela.CtcGerarHoraTrabalhada => CtcGerarHoraTrabalhada,
        NomesCamposTabela.CtcExibirNoTopo => CtcExibirNoTopo,
        NomesCamposTabela.CtcTipoContatoCRM => CtcTipoContatoCRM,
        NomesCamposTabela.CtcContato => CtcContato,
        NomesCamposTabela.CtcEmocao => CtcEmocao,
        NomesCamposTabela.CtcContinuar => CtcContinuar,
        NomesCamposTabela.CtcBold => CtcBold,
        NomesCamposTabela.CtcGUID => CtcGUID,
        NomesCamposTabela.CtcQuemCad => CtcQuemCad,
        NomesCamposTabela.CtcDtCad => CtcDtCad,
        NomesCamposTabela.CtcQuemAtu => CtcQuemAtu,
        NomesCamposTabela.CtcDtAtu => CtcDtAtu,
        NomesCamposTabela.CtcVisto => CtcVisto,
        _ => null
    };
}