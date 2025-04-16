using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBProValoresDicInfo
{
    public const string CampoCodigo = "prvCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "prv";
    public const string Processo = "prvProcesso"; // LOCALIZACAO 170523
    public const string TipoValorProcesso = "prvTipoValorProcesso"; // LOCALIZACAO 170523
    public const string Indice = "prvIndice"; // LOCALIZACAO 170523
    public const string Ignorar = "prvIgnorar"; // LOCALIZACAO 170523
    public const string Data = "prvData"; // LOCALIZACAO 170523
    public const string ValorOriginal = "prvValorOriginal"; // LOCALIZACAO 170523
    public const string PercMulta = "prvPercMulta"; // LOCALIZACAO 170523
    public const string ValorMulta = "prvValorMulta"; // LOCALIZACAO 170523
    public const string PercJuros = "prvPercJuros"; // LOCALIZACAO 170523
    public const string ValorOriginalCorrigidoIndice = "prvValorOriginalCorrigidoIndice"; // LOCALIZACAO 170523
    public const string ValorMultaCorrigido = "prvValorMultaCorrigido"; // LOCALIZACAO 170523
    public const string ValorJurosCorrigido = "prvValorJurosCorrigido"; // LOCALIZACAO 170523
    public const string ValorFinal = "prvValorFinal"; // LOCALIZACAO 170523
    public const string DataUltimaCorrecao = "prvDataUltimaCorrecao"; // LOCALIZACAO 170523
    public const string GUID = "prvGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "prvQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "prvDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "prvQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "prvDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "prvVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => TipoValorProcesso,
        3 => Indice,
        4 => Ignorar,
        5 => Data,
        6 => ValorOriginal,
        7 => PercMulta,
        8 => ValorMulta,
        9 => PercJuros,
        10 => ValorOriginalCorrigidoIndice,
        11 => ValorMultaCorrigido,
        12 => ValorJurosCorrigido,
        13 => ValorFinal,
        14 => DataUltimaCorrecao,
        15 => GUID,
        16 => QuemCad,
        17 => DtCad,
        18 => QuemAtu,
        19 => DtAtu,
        20 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProValores";
#region PropriedadesDaTabela
    public static DBInfoSystem PrvProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem PrvTipoValorProcesso => new(0, PTabelaNome, CampoCodigo, TipoValorProcesso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoValorProcessoDicInfo.CampoCodigo, DBTipoValorProcessoDicInfo.TabelaNome, new DBTipoValorProcessoODicInfo(), false); // DBI 11 
    public static DBInfoSystem PrvIndice => new(0, PTabelaNome, CampoCodigo, Indice, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PrvIgnorar => new(0, PTabelaNome, CampoCodigo, Ignorar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem PrvData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem PrvValorOriginal => new(0, PTabelaNome, CampoCodigo, ValorOriginal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem PrvPercMulta => new(0, PTabelaNome, CampoCodigo, PercMulta, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem PrvValorMulta => new(0, PTabelaNome, CampoCodigo, ValorMulta, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem PrvPercJuros => new(0, PTabelaNome, CampoCodigo, PercJuros, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem PrvValorOriginalCorrigidoIndice => new(0, PTabelaNome, CampoCodigo, ValorOriginalCorrigidoIndice, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem PrvValorMultaCorrigido => new(0, PTabelaNome, CampoCodigo, ValorMultaCorrigido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem PrvValorJurosCorrigido => new(0, PTabelaNome, CampoCodigo, ValorJurosCorrigido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem PrvValorFinal => new(0, PTabelaNome, CampoCodigo, ValorFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem PrvDataUltimaCorrecao => new(0, PTabelaNome, CampoCodigo, DataUltimaCorrecao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem PrvGUID => new(0, PTabelaNome, CampoCodigo, GUID, 50, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem PrvQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PrvDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem PrvQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PrvDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem PrvVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string TipoValorProcessoDiff(int id) => TipoValorProcesso.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string TipoValorProcessoSql(int id) => TipoValorProcesso.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string TipoValorProcessoIsNull => TipoValorProcesso.SqlCmdIsNull() ?? string.Empty;
    public static string TipoValorProcessoNotIsNull => TipoValorProcesso.SqlCmdNotIsNull() ?? string.Empty;

    public static string IndiceSql(string text) => Indice.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string IndiceSqlNotIsNull => Indice.SqlCmdNotIsNull() ?? string.Empty;
    public static string IndiceSqlIsNull => Indice.SqlCmdIsNull() ?? string.Empty;

    public static string IndiceSqlDiff(string text) => Indice.SqlCmdTextDiff(text) ?? string.Empty;
    public static string IndiceSqlLike(string text) => Indice.SqlCmdTextLike(text) ?? string.Empty;
    public static string IndiceSqlLikeInit(string text) => Indice.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string IndiceSqlLikeSpaces(string? text) => Indice.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string IgnorarSql(bool valueCheck) => Ignorar.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IgnorarSqlSim => Ignorar.SqlCmdBoolSim() ?? string.Empty;
    public static string IgnorarSqlNao => Ignorar.SqlCmdBoolNao() ?? string.Empty;

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

    public static string DataUltimaCorrecaoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataUltimaCorrecao}]");
    public static string DataUltimaCorrecaoIsNull => DataUltimaCorrecao.SqlCmdIsNull() ?? string.Empty;
    public static string DataUltimaCorrecaoNotIsNull => DataUltimaCorrecao.SqlCmdNotIsNull() ?? string.Empty;

    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 50) ?? string.Empty;
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
        PrvProcesso = 1,
        PrvTipoValorProcesso = 2,
        PrvIndice = 3,
        PrvIgnorar = 4,
        PrvData = 5,
        PrvValorOriginal = 6,
        PrvPercMulta = 7,
        PrvValorMulta = 8,
        PrvPercJuros = 9,
        PrvValorOriginalCorrigidoIndice = 10,
        PrvValorMultaCorrigido = 11,
        PrvValorJurosCorrigido = 12,
        PrvValorFinal = 13,
        PrvDataUltimaCorrecao = 14,
        PrvGUID = 15,
        PrvQuemCad = 16,
        PrvDtCad = 17,
        PrvQuemAtu = 18,
        PrvDtAtu = 19,
        PrvVisto = 20
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PrvProcesso => PrvProcesso,
        NomesCamposTabela.PrvTipoValorProcesso => PrvTipoValorProcesso,
        NomesCamposTabela.PrvIndice => PrvIndice,
        NomesCamposTabela.PrvIgnorar => PrvIgnorar,
        NomesCamposTabela.PrvData => PrvData,
        NomesCamposTabela.PrvValorOriginal => PrvValorOriginal,
        NomesCamposTabela.PrvPercMulta => PrvPercMulta,
        NomesCamposTabela.PrvValorMulta => PrvValorMulta,
        NomesCamposTabela.PrvPercJuros => PrvPercJuros,
        NomesCamposTabela.PrvValorOriginalCorrigidoIndice => PrvValorOriginalCorrigidoIndice,
        NomesCamposTabela.PrvValorMultaCorrigido => PrvValorMultaCorrigido,
        NomesCamposTabela.PrvValorJurosCorrigido => PrvValorJurosCorrigido,
        NomesCamposTabela.PrvValorFinal => PrvValorFinal,
        NomesCamposTabela.PrvDataUltimaCorrecao => PrvDataUltimaCorrecao,
        NomesCamposTabela.PrvGUID => PrvGUID,
        NomesCamposTabela.PrvQuemCad => PrvQuemCad,
        NomesCamposTabela.PrvDtCad => PrvDtCad,
        NomesCamposTabela.PrvQuemAtu => PrvQuemAtu,
        NomesCamposTabela.PrvDtAtu => PrvDtAtu,
        NomesCamposTabela.PrvVisto => PrvVisto,
        _ => null
    };
}