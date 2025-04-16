using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAndamentosMDDicInfo
{
    public const string CampoCodigo = "amdCodigo";
    public const string CampoNome = "amdNome";
    public const string TablePrefix = "amd";
    public const string Nome = "amdNome"; // LOCALIZACAO 170523
    public const string Processo = "amdProcesso"; // LOCALIZACAO 170523
    public const string Andamento = "amdAndamento"; // LOCALIZACAO 170523
    public const string PathFull = "amdPathFull"; // LOCALIZACAO 170523
    public const string UNC = "amdUNC"; // LOCALIZACAO 170523
    public const string GUID = "amdGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "amdQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "amdDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "amdQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "amdDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "amdVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Processo,
        3 => Andamento,
        4 => PathFull,
        5 => UNC,
        6 => GUID,
        7 => QuemCad,
        8 => DtCad,
        9 => QuemAtu,
        10 => DtAtu,
        11 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AndamentosMD";
#region PropriedadesDaTabela
    public static DBInfoSystem AmdNome => new(0, PTabelaNome, CampoCodigo, Nome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem AmdProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AmdAndamento => new(0, PTabelaNome, CampoCodigo, Andamento, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AmdPathFull => new(0, PTabelaNome, CampoCodigo, PathFull, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem AmdUNC => new(0, PTabelaNome, CampoCodigo, UNC, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem AmdGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem AmdQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AmdDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem AmdQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AmdDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem AmdVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string AndamentoDiff(int id) => Andamento.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AndamentoSql(int id) => Andamento.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AndamentoIsNull => Andamento.SqlCmdIsNull() ?? string.Empty;
    public static string AndamentoNotIsNull => Andamento.SqlCmdNotIsNull() ?? string.Empty;

    public static string PathFullSql(string text) => PathFull.SqlCmdTextIgual(text) ?? string.Empty;
    public static string PathFullSqlNotIsNull => PathFull.SqlCmdNotIsNull() ?? string.Empty;
    public static string PathFullSqlIsNull => PathFull.SqlCmdIsNull() ?? string.Empty;

    public static string PathFullSqlDiff(string text) => PathFull.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PathFullSqlLike(string text) => PathFull.SqlCmdTextLike(text) ?? string.Empty;
    public static string PathFullSqlLikeInit(string text) => PathFull.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PathFullSqlLikeSpaces(string? text) => PathFull.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string UNCSql(string text) => UNC.SqlCmdTextIgual(text) ?? string.Empty;
    public static string UNCSqlNotIsNull => UNC.SqlCmdNotIsNull() ?? string.Empty;
    public static string UNCSqlIsNull => UNC.SqlCmdIsNull() ?? string.Empty;

    public static string UNCSqlDiff(string text) => UNC.SqlCmdTextDiff(text) ?? string.Empty;
    public static string UNCSqlLike(string text) => UNC.SqlCmdTextLike(text) ?? string.Empty;
    public static string UNCSqlLikeInit(string text) => UNC.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string UNCSqlLikeSpaces(string? text) => UNC.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        AmdNome = 1,
        AmdProcesso = 2,
        AmdAndamento = 3,
        AmdPathFull = 4,
        AmdUNC = 5,
        AmdGUID = 6,
        AmdQuemCad = 7,
        AmdDtCad = 8,
        AmdQuemAtu = 9,
        AmdDtAtu = 10,
        AmdVisto = 11
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AmdNome => AmdNome,
        NomesCamposTabela.AmdProcesso => AmdProcesso,
        NomesCamposTabela.AmdAndamento => AmdAndamento,
        NomesCamposTabela.AmdPathFull => AmdPathFull,
        NomesCamposTabela.AmdUNC => AmdUNC,
        NomesCamposTabela.AmdGUID => AmdGUID,
        NomesCamposTabela.AmdQuemCad => AmdQuemCad,
        NomesCamposTabela.AmdDtCad => AmdDtCad,
        NomesCamposTabela.AmdQuemAtu => AmdQuemAtu,
        NomesCamposTabela.AmdDtAtu => AmdDtAtu,
        NomesCamposTabela.AmdVisto => AmdVisto,
        _ => null
    };
}