using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBReuniaoDicInfo
{
    public const string CampoCodigo = "renCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ren";
    public const string Cliente = "renCliente"; // LOCALIZACAO 170523
    public const string IDAgenda = "renIDAgenda"; // LOCALIZACAO 170523
    public const string Data = "renData"; // LOCALIZACAO 170523
    public const string Pauta = "renPauta"; // LOCALIZACAO 170523
    public const string ATA = "renATA"; // LOCALIZACAO 170523
    public const string HoraInicial = "renHoraInicial"; // LOCALIZACAO 170523
    public const string HoraFinal = "renHoraFinal"; // LOCALIZACAO 170523
    public const string Externa = "renExterna"; // LOCALIZACAO 170523
    public const string HoraSaida = "renHoraSaida"; // LOCALIZACAO 170523
    public const string HoraRetorno = "renHoraRetorno"; // LOCALIZACAO 170523
    public const string PrincipaisDecisoes = "renPrincipaisDecisoes"; // LOCALIZACAO 170523
    public const string Bold = "renBold"; // LOCALIZACAO 170523
    public const string GUID = "renGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "renQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "renDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "renQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "renDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "renVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cliente,
        2 => IDAgenda,
        3 => Data,
        4 => Pauta,
        5 => ATA,
        6 => HoraInicial,
        7 => HoraFinal,
        8 => Externa,
        9 => HoraSaida,
        10 => HoraRetorno,
        11 => PrincipaisDecisoes,
        12 => Bold,
        13 => GUID,
        14 => QuemCad,
        15 => DtCad,
        16 => QuemAtu,
        17 => DtAtu,
        18 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Reuniao";
#region PropriedadesDaTabela
    public static DBInfoSystem RenCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem RenIDAgenda => new(0, PTabelaNome, CampoCodigo, IDAgenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem RenData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RenPauta => new(0, PTabelaNome, CampoCodigo, Pauta, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem RenATA => new(0, PTabelaNome, CampoCodigo, ATA, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem RenHoraInicial => new(0, PTabelaNome, CampoCodigo, HoraInicial, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RenHoraFinal => new(0, PTabelaNome, CampoCodigo, HoraFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RenExterna => new(0, PTabelaNome, CampoCodigo, Externa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem RenHoraSaida => new(0, PTabelaNome, CampoCodigo, HoraSaida, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RenHoraRetorno => new(0, PTabelaNome, CampoCodigo, HoraRetorno, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem RenPrincipaisDecisoes => new(0, PTabelaNome, CampoCodigo, PrincipaisDecisoes, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem RenBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem RenGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem RenQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem RenDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem RenQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem RenDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem RenVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
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

    public static string PautaSql(string text) => Pauta.SqlCmdTextIgual(text) ?? string.Empty;
    public static string PautaSqlNotIsNull => Pauta.SqlCmdNotIsNull() ?? string.Empty;
    public static string PautaSqlIsNull => Pauta.SqlCmdIsNull() ?? string.Empty;

    public static string PautaSqlDiff(string text) => Pauta.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PautaSqlLike(string text) => Pauta.SqlCmdTextLike(text) ?? string.Empty;
    public static string PautaSqlLikeInit(string text) => Pauta.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PautaSqlLikeSpaces(string? text) => Pauta.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ATASql(string text) => ATA.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ATASqlNotIsNull => ATA.SqlCmdNotIsNull() ?? string.Empty;
    public static string ATASqlIsNull => ATA.SqlCmdIsNull() ?? string.Empty;

    public static string ATASqlDiff(string text) => ATA.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ATASqlLike(string text) => ATA.SqlCmdTextLike(text) ?? string.Empty;
    public static string ATASqlLikeInit(string text) => ATA.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ATASqlLikeSpaces(string? text) => ATA.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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

    public static string ExternaSql(bool valueCheck) => Externa.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ExternaSqlSim => Externa.SqlCmdBoolSim() ?? string.Empty;
    public static string ExternaSqlNao => Externa.SqlCmdBoolNao() ?? string.Empty;

    public static string HoraSaidaSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{HoraSaida}]");
    public static string HoraSaidaSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{HoraSaida}]");
    public static string HoraSaidaSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{HoraSaida}]");
    public static string HoraSaidaSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{HoraSaida}]");
    public static string HoraSaidaIsNull => HoraSaida.SqlCmdIsNull() ?? string.Empty;
    public static string HoraSaidaNotIsNull => HoraSaida.SqlCmdNotIsNull() ?? string.Empty;

    public static string HoraRetornoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{HoraRetorno}]");
    public static string HoraRetornoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{HoraRetorno}]");
    public static string HoraRetornoIsNull => HoraRetorno.SqlCmdIsNull() ?? string.Empty;
    public static string HoraRetornoNotIsNull => HoraRetorno.SqlCmdNotIsNull() ?? string.Empty;

    public static string PrincipaisDecisoesSql(string text) => PrincipaisDecisoes.SqlCmdTextIgual(text) ?? string.Empty;
    public static string PrincipaisDecisoesSqlNotIsNull => PrincipaisDecisoes.SqlCmdNotIsNull() ?? string.Empty;
    public static string PrincipaisDecisoesSqlIsNull => PrincipaisDecisoes.SqlCmdIsNull() ?? string.Empty;

    public static string PrincipaisDecisoesSqlDiff(string text) => PrincipaisDecisoes.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PrincipaisDecisoesSqlLike(string text) => PrincipaisDecisoes.SqlCmdTextLike(text) ?? string.Empty;
    public static string PrincipaisDecisoesSqlLikeInit(string text) => PrincipaisDecisoes.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PrincipaisDecisoesSqlLikeSpaces(string? text) => PrincipaisDecisoes.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        RenCliente = 1,
        RenIDAgenda = 2,
        RenData = 3,
        RenPauta = 4,
        RenATA = 5,
        RenHoraInicial = 6,
        RenHoraFinal = 7,
        RenExterna = 8,
        RenHoraSaida = 9,
        RenHoraRetorno = 10,
        RenPrincipaisDecisoes = 11,
        RenBold = 12,
        RenGUID = 13,
        RenQuemCad = 14,
        RenDtCad = 15,
        RenQuemAtu = 16,
        RenDtAtu = 17,
        RenVisto = 18
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RenCliente => RenCliente,
        NomesCamposTabela.RenIDAgenda => RenIDAgenda,
        NomesCamposTabela.RenData => RenData,
        NomesCamposTabela.RenPauta => RenPauta,
        NomesCamposTabela.RenATA => RenATA,
        NomesCamposTabela.RenHoraInicial => RenHoraInicial,
        NomesCamposTabela.RenHoraFinal => RenHoraFinal,
        NomesCamposTabela.RenExterna => RenExterna,
        NomesCamposTabela.RenHoraSaida => RenHoraSaida,
        NomesCamposTabela.RenHoraRetorno => RenHoraRetorno,
        NomesCamposTabela.RenPrincipaisDecisoes => RenPrincipaisDecisoes,
        NomesCamposTabela.RenBold => RenBold,
        NomesCamposTabela.RenGUID => RenGUID,
        NomesCamposTabela.RenQuemCad => RenQuemCad,
        NomesCamposTabela.RenDtCad => RenDtCad,
        NomesCamposTabela.RenQuemAtu => RenQuemAtu,
        NomesCamposTabela.RenDtAtu => RenDtAtu,
        NomesCamposTabela.RenVisto => RenVisto,
        _ => null
    };
}