using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBHistoricoDicInfo
{
    public const string CampoCodigo = "hisCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "his";
    public const string ExtraID = "hisExtraID"; // LOCALIZACAO 170523
    public const string IDNE = "hisIDNE"; // LOCALIZACAO 170523
    public const string ExtraGUID = "hisExtraGUID"; // LOCALIZACAO 170523
    public const string LiminarOrigem = "hisLiminarOrigem"; // LOCALIZACAO 170523
    public const string NaoPublicavel = "hisNaoPublicavel"; // LOCALIZACAO 170523
    public const string Processo = "hisProcesso"; // LOCALIZACAO 170523
    public const string Precatoria = "hisPrecatoria"; // LOCALIZACAO 170523
    public const string Apenso = "hisApenso"; // LOCALIZACAO 170523
    public const string IDInstProcesso = "hisIDInstProcesso"; // LOCALIZACAO 170523
    public const string Fase = "hisFase"; // LOCALIZACAO 170523
    public const string Data = "hisData"; // LOCALIZACAO 170523
    public const string Observacao = "hisObservacao"; // LOCALIZACAO 170523
    public const string Agendado = "hisAgendado"; // LOCALIZACAO 170523
    public const string Concluido = "hisConcluido"; // LOCALIZACAO 170523
    public const string MesmaAgenda = "hisMesmaAgenda"; // LOCALIZACAO 170523
    public const string SAD = "hisSAD"; // LOCALIZACAO 170523
    public const string Resumido = "hisResumido"; // LOCALIZACAO 170523
    public const string StatusAndamento = "hisStatusAndamento"; // LOCALIZACAO 170523
    public const string Top = "hisTop"; // LOCALIZACAO 170523
    public const string GUID = "hisGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "hisQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "hisDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "hisQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "hisDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "hisVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => ExtraID,
        2 => IDNE,
        3 => ExtraGUID,
        4 => LiminarOrigem,
        5 => NaoPublicavel,
        6 => Processo,
        7 => Precatoria,
        8 => Apenso,
        9 => IDInstProcesso,
        10 => Fase,
        11 => Data,
        12 => Observacao,
        13 => Agendado,
        14 => Concluido,
        15 => MesmaAgenda,
        16 => SAD,
        17 => Resumido,
        18 => StatusAndamento,
        19 => Top,
        20 => GUID,
        21 => QuemCad,
        22 => DtCad,
        23 => QuemAtu,
        24 => DtAtu,
        25 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Historico";
#region PropriedadesDaTabela
    public static DBInfoSystem HisExtraID => new(0, PTabelaNome, CampoCodigo, ExtraID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem HisIDNE => new(0, PTabelaNome, CampoCodigo, IDNE, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem HisExtraGUID => new(0, PTabelaNome, CampoCodigo, ExtraGUID, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem HisLiminarOrigem => new(0, PTabelaNome, CampoCodigo, LiminarOrigem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem HisNaoPublicavel => new(0, PTabelaNome, CampoCodigo, NaoPublicavel, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem HisProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem HisPrecatoria => new(0, PTabelaNome, CampoCodigo, Precatoria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPrecatoriaDicInfo.CampoCodigo, DBPrecatoriaDicInfo.TabelaNome, new DBPrecatoriaODicInfo(), false); // DBI 11 
    public static DBInfoSystem HisApenso => new(0, PTabelaNome, CampoCodigo, Apenso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBApensoDicInfo.CampoCodigo, DBApensoDicInfo.TabelaNome, new DBApensoODicInfo(), false); // DBI 11 
    public static DBInfoSystem HisIDInstProcesso => new(0, PTabelaNome, CampoCodigo, IDInstProcesso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem HisFase => new(0, PTabelaNome, CampoCodigo, Fase, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFaseDicInfo.CampoCodigo, DBFaseDicInfo.TabelaNome, new DBFaseODicInfo(), false); // DBI 11 
    public static DBInfoSystem HisData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem HisObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem HisAgendado => new(0, PTabelaNome, CampoCodigo, Agendado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem HisConcluido => new(0, PTabelaNome, CampoCodigo, Concluido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem HisMesmaAgenda => new(0, PTabelaNome, CampoCodigo, MesmaAgenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem HisSAD => new(0, PTabelaNome, CampoCodigo, SAD, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem HisResumido => new(0, PTabelaNome, CampoCodigo, Resumido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem HisStatusAndamento => new(0, PTabelaNome, CampoCodigo, StatusAndamento, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBStatusAndamentoDicInfo.CampoCodigo, DBStatusAndamentoDicInfo.TabelaNome, new DBStatusAndamentoODicInfo(), false); // DBI 11 
    public static DBInfoSystem HisTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem HisGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem HisQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem HisDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem HisQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem HisDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem HisVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string ExtraGUIDSql(string text) => ExtraGUID.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string ExtraGUIDSqlNotIsNull => ExtraGUID.SqlCmdNotIsNull() ?? string.Empty;
    public static string ExtraGUIDSqlIsNull => ExtraGUID.SqlCmdIsNull() ?? string.Empty;

    public static string ExtraGUIDSqlDiff(string text) => ExtraGUID.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ExtraGUIDSqlLike(string text) => ExtraGUID.SqlCmdTextLike(text) ?? string.Empty;
    public static string ExtraGUIDSqlLikeInit(string text) => ExtraGUID.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ExtraGUIDSqlLikeSpaces(string? text) => ExtraGUID.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NaoPublicavelSql(bool valueCheck) => NaoPublicavel.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string NaoPublicavelSqlSim => NaoPublicavel.SqlCmdBoolSim() ?? string.Empty;
    public static string NaoPublicavelSqlNao => NaoPublicavel.SqlCmdBoolNao() ?? string.Empty;

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

    public static string ObservacaoSql(string text) => Observacao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacaoSqlNotIsNull => Observacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacaoSqlIsNull => Observacao.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacaoSqlDiff(string text) => Observacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacaoSqlLike(string text) => Observacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacaoSqlLikeInit(string text) => Observacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacaoSqlLikeSpaces(string? text) => Observacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AgendadoSql(bool valueCheck) => Agendado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AgendadoSqlSim => Agendado.SqlCmdBoolSim() ?? string.Empty;
    public static string AgendadoSqlNao => Agendado.SqlCmdBoolNao() ?? string.Empty;

    public static string ConcluidoSql(bool valueCheck) => Concluido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ConcluidoSqlSim => Concluido.SqlCmdBoolSim() ?? string.Empty;
    public static string ConcluidoSqlNao => Concluido.SqlCmdBoolNao() ?? string.Empty;

    public static string MesmaAgendaSql(bool valueCheck) => MesmaAgenda.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string MesmaAgendaSqlSim => MesmaAgenda.SqlCmdBoolSim() ?? string.Empty;
    public static string MesmaAgendaSqlNao => MesmaAgenda.SqlCmdBoolNao() ?? string.Empty;

    public static string ResumidoSql(bool valueCheck) => Resumido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ResumidoSqlSim => Resumido.SqlCmdBoolSim() ?? string.Empty;
    public static string ResumidoSqlNao => Resumido.SqlCmdBoolNao() ?? string.Empty;

    public static string TopSql(bool valueCheck) => Top.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TopSqlSim => Top.SqlCmdBoolSim() ?? string.Empty;
    public static string TopSqlNao => Top.SqlCmdBoolNao() ?? string.Empty;

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
        HisExtraID = 1,
        HisIDNE = 2,
        HisExtraGUID = 3,
        HisLiminarOrigem = 4,
        HisNaoPublicavel = 5,
        HisProcesso = 6,
        HisPrecatoria = 7,
        HisApenso = 8,
        HisIDInstProcesso = 9,
        HisFase = 10,
        HisData = 11,
        HisObservacao = 12,
        HisAgendado = 13,
        HisConcluido = 14,
        HisMesmaAgenda = 15,
        HisSAD = 16,
        HisResumido = 17,
        HisStatusAndamento = 18,
        HisTop = 19,
        HisGUID = 20,
        HisQuemCad = 21,
        HisDtCad = 22,
        HisQuemAtu = 23,
        HisDtAtu = 24,
        HisVisto = 25
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.HisExtraID => HisExtraID,
        NomesCamposTabela.HisIDNE => HisIDNE,
        NomesCamposTabela.HisExtraGUID => HisExtraGUID,
        NomesCamposTabela.HisLiminarOrigem => HisLiminarOrigem,
        NomesCamposTabela.HisNaoPublicavel => HisNaoPublicavel,
        NomesCamposTabela.HisProcesso => HisProcesso,
        NomesCamposTabela.HisPrecatoria => HisPrecatoria,
        NomesCamposTabela.HisApenso => HisApenso,
        NomesCamposTabela.HisIDInstProcesso => HisIDInstProcesso,
        NomesCamposTabela.HisFase => HisFase,
        NomesCamposTabela.HisData => HisData,
        NomesCamposTabela.HisObservacao => HisObservacao,
        NomesCamposTabela.HisAgendado => HisAgendado,
        NomesCamposTabela.HisConcluido => HisConcluido,
        NomesCamposTabela.HisMesmaAgenda => HisMesmaAgenda,
        NomesCamposTabela.HisSAD => HisSAD,
        NomesCamposTabela.HisResumido => HisResumido,
        NomesCamposTabela.HisStatusAndamento => HisStatusAndamento,
        NomesCamposTabela.HisTop => HisTop,
        NomesCamposTabela.HisGUID => HisGUID,
        NomesCamposTabela.HisQuemCad => HisQuemCad,
        NomesCamposTabela.HisDtCad => HisDtCad,
        NomesCamposTabela.HisQuemAtu => HisQuemAtu,
        NomesCamposTabela.HisDtAtu => HisDtAtu,
        NomesCamposTabela.HisVisto => HisVisto,
        _ => null
    };
}