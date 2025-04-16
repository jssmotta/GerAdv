using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBPenhoraDicInfo
{
    public const string CampoCodigo = "phrCodigo";
    public const string CampoNome = "phrNome";
    public const string TablePrefix = "phr";
    public const string Processo = "phrProcesso"; // LOCALIZACAO 170523
    public const string Nome = "phrNome"; // LOCALIZACAO 170523
    public const string Descricao = "phrDescricao"; // LOCALIZACAO 170523
    public const string DataPenhora = "phrDataPenhora"; // LOCALIZACAO 170523
    public const string PenhoraStatus = "phrPenhoraStatus"; // LOCALIZACAO 170523
    public const string Master = "phrMaster"; // LOCALIZACAO 170523
    public const string GUID = "phrGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "phrQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "phrDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "phrQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "phrDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "phrVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Nome,
        3 => Descricao,
        4 => DataPenhora,
        5 => PenhoraStatus,
        6 => Master,
        7 => GUID,
        8 => QuemCad,
        9 => DtCad,
        10 => QuemAtu,
        11 => DtAtu,
        12 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Penhora";
#region PropriedadesDaTabela
    public static DBInfoSystem PhrProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem PhrNome => new(0, PTabelaNome, CampoCodigo, Nome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem PhrDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem PhrDataPenhora => new(0, PTabelaNome, CampoCodigo, DataPenhora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem PhrPenhoraStatus => new(0, PTabelaNome, CampoCodigo, PenhoraStatus, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPenhoraStatusDicInfo.CampoCodigo, DBPenhoraStatusDicInfo.TabelaNome, new DBPenhoraStatusODicInfo(), false); // DBI 11 
    public static DBInfoSystem PhrMaster => new(0, PTabelaNome, CampoCodigo, Master, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem PhrGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem PhrQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PhrDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem PhrQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PhrDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem PhrVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DataPenhoraSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataPenhora}]");
    public static string DataPenhoraSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataPenhora}]");
    public static string DataPenhoraSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataPenhora}]");
    public static string DataPenhoraSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataPenhora}]");
    public static string DataPenhoraSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataPenhora}]");
    public static string DataPenhoraSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataPenhora}]");
    public static string DataPenhoraSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataPenhora}]");
    public static string DataPenhoraSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataPenhora}]");
    public static string DataPenhoraSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataPenhora}]");
    public static string DataPenhoraSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataPenhora}]");
    public static string DataPenhoraSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataPenhora}]");
    public static string DataPenhoraSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataPenhora}]");
    public static string DataPenhoraIsNull => DataPenhora.SqlCmdIsNull() ?? string.Empty;
    public static string DataPenhoraNotIsNull => DataPenhora.SqlCmdNotIsNull() ?? string.Empty;

    public static string PenhoraStatusDiff(int id) => PenhoraStatus.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string PenhoraStatusSql(int id) => PenhoraStatus.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string PenhoraStatusIsNull => PenhoraStatus.SqlCmdIsNull() ?? string.Empty;
    public static string PenhoraStatusNotIsNull => PenhoraStatus.SqlCmdNotIsNull() ?? string.Empty;

    public static string MasterDiff(int id) => Master.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string MasterSql(int id) => Master.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string MasterIsNull => Master.SqlCmdIsNull() ?? string.Empty;
    public static string MasterNotIsNull => Master.SqlCmdNotIsNull() ?? string.Empty;

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
        PhrProcesso = 1,
        PhrNome = 2,
        PhrDescricao = 3,
        PhrDataPenhora = 4,
        PhrPenhoraStatus = 5,
        PhrMaster = 6,
        PhrGUID = 7,
        PhrQuemCad = 8,
        PhrDtCad = 9,
        PhrQuemAtu = 10,
        PhrDtAtu = 11,
        PhrVisto = 12
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PhrProcesso => PhrProcesso,
        NomesCamposTabela.PhrNome => PhrNome,
        NomesCamposTabela.PhrDescricao => PhrDescricao,
        NomesCamposTabela.PhrDataPenhora => PhrDataPenhora,
        NomesCamposTabela.PhrPenhoraStatus => PhrPenhoraStatus,
        NomesCamposTabela.PhrMaster => PhrMaster,
        NomesCamposTabela.PhrGUID => PhrGUID,
        NomesCamposTabela.PhrQuemCad => PhrQuemCad,
        NomesCamposTabela.PhrDtCad => PhrDtCad,
        NomesCamposTabela.PhrQuemAtu => PhrQuemAtu,
        NomesCamposTabela.PhrDtAtu => PhrDtAtu,
        NomesCamposTabela.PhrVisto => PhrVisto,
        _ => null
    };
}