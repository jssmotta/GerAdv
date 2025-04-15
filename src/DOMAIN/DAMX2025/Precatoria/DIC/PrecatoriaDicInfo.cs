using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBPrecatoriaDicInfo
{
    public const string CampoCodigo = "preCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "pre";
    public const string DtDist = "preDtDist"; // LOCALIZACAO 170523
    public const string Processo = "preProcesso"; // LOCALIZACAO 170523
    public const string Precatoria = "prePrecatoria"; // LOCALIZACAO 170523
    public const string Deprecante = "preDeprecante"; // LOCALIZACAO 170523
    public const string Deprecado = "preDeprecado"; // LOCALIZACAO 170523
    public const string OBS = "preOBS"; // LOCALIZACAO 170523
    public const string Bold = "preBold"; // LOCALIZACAO 170523
    public const string GUID = "preGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "preQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "preDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "preQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "preDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "preVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => DtDist,
        2 => Processo,
        3 => Precatoria,
        4 => Deprecante,
        5 => Deprecado,
        6 => OBS,
        7 => Bold,
        8 => GUID,
        9 => QuemCad,
        10 => DtCad,
        11 => QuemAtu,
        12 => DtAtu,
        13 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Precatoria";
#region PropriedadesDaTabela
    public static DBInfoSystem PreDtDist => new(0, PTabelaNome, CampoCodigo, DtDist, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem PreProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem PrePrecatoria => new(0, PTabelaNome, CampoCodigo, Precatoria, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PreDeprecante => new(0, PTabelaNome, CampoCodigo, Deprecante, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PreDeprecado => new(0, PTabelaNome, CampoCodigo, Deprecado, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PreOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem PreBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem PreGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem PreQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PreDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem PreQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PreDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem PreVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string DtDistSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtDist}]");
    public static string DtDistSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtDist}]");
    public static string DtDistSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtDist}]");
    public static string DtDistSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtDist}]");
    public static string DtDistSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtDist}]");
    public static string DtDistSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtDist}]");
    public static string DtDistSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtDist}]");
    public static string DtDistSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtDist}]");
    public static string DtDistSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtDist}]");
    public static string DtDistSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtDist}]");
    public static string DtDistSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtDist}]");
    public static string DtDistSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtDist}]");
    public static string DtDistIsNull => DtDist.SqlCmdIsNull() ?? string.Empty;
    public static string DtDistNotIsNull => DtDist.SqlCmdNotIsNull() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string PrecatoriaSql(string text) => Precatoria.SqlCmdTextIgual(text, 25) ?? string.Empty;
    public static string PrecatoriaSqlNotIsNull => Precatoria.SqlCmdNotIsNull() ?? string.Empty;
    public static string PrecatoriaSqlIsNull => Precatoria.SqlCmdIsNull() ?? string.Empty;

    public static string PrecatoriaSqlDiff(string text) => Precatoria.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PrecatoriaSqlLike(string text) => Precatoria.SqlCmdTextLike(text) ?? string.Empty;
    public static string PrecatoriaSqlLikeInit(string text) => Precatoria.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PrecatoriaSqlLikeSpaces(string? text) => Precatoria.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DeprecanteSql(string text) => Deprecante.SqlCmdTextIgual(text, 60) ?? string.Empty;
    public static string DeprecanteSqlNotIsNull => Deprecante.SqlCmdNotIsNull() ?? string.Empty;
    public static string DeprecanteSqlIsNull => Deprecante.SqlCmdIsNull() ?? string.Empty;

    public static string DeprecanteSqlDiff(string text) => Deprecante.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DeprecanteSqlLike(string text) => Deprecante.SqlCmdTextLike(text) ?? string.Empty;
    public static string DeprecanteSqlLikeInit(string text) => Deprecante.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DeprecanteSqlLikeSpaces(string? text) => Deprecante.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DeprecadoSql(string text) => Deprecado.SqlCmdTextIgual(text, 60) ?? string.Empty;
    public static string DeprecadoSqlNotIsNull => Deprecado.SqlCmdNotIsNull() ?? string.Empty;
    public static string DeprecadoSqlIsNull => Deprecado.SqlCmdIsNull() ?? string.Empty;

    public static string DeprecadoSqlDiff(string text) => Deprecado.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DeprecadoSqlLike(string text) => Deprecado.SqlCmdTextLike(text) ?? string.Empty;
    public static string DeprecadoSqlLikeInit(string text) => Deprecado.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DeprecadoSqlLikeSpaces(string? text) => Deprecado.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OBSSql(string text) => OBS.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OBSSqlNotIsNull => OBS.SqlCmdNotIsNull() ?? string.Empty;
    public static string OBSSqlIsNull => OBS.SqlCmdIsNull() ?? string.Empty;

    public static string OBSSqlDiff(string text) => OBS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OBSSqlLike(string text) => OBS.SqlCmdTextLike(text) ?? string.Empty;
    public static string OBSSqlLikeInit(string text) => OBS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OBSSqlLikeSpaces(string? text) => OBS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        PreDtDist = 1,
        PreProcesso = 2,
        PrePrecatoria = 3,
        PreDeprecante = 4,
        PreDeprecado = 5,
        PreOBS = 6,
        PreBold = 7,
        PreGUID = 8,
        PreQuemCad = 9,
        PreDtCad = 10,
        PreQuemAtu = 11,
        PreDtAtu = 12,
        PreVisto = 13
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PreDtDist => PreDtDist,
        NomesCamposTabela.PreProcesso => PreProcesso,
        NomesCamposTabela.PrePrecatoria => PrePrecatoria,
        NomesCamposTabela.PreDeprecante => PreDeprecante,
        NomesCamposTabela.PreDeprecado => PreDeprecado,
        NomesCamposTabela.PreOBS => PreOBS,
        NomesCamposTabela.PreBold => PreBold,
        NomesCamposTabela.PreGUID => PreGUID,
        NomesCamposTabela.PreQuemCad => PreQuemCad,
        NomesCamposTabela.PreDtCad => PreDtCad,
        NomesCamposTabela.PreQuemAtu => PreQuemAtu,
        NomesCamposTabela.PreDtAtu => PreDtAtu,
        NomesCamposTabela.PreVisto => PreVisto,
        _ => null
    };
}