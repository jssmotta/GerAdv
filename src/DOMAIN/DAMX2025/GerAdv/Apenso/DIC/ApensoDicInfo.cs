using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBApensoDicInfo
{
    public const string CampoCodigo = "apeCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ape";
    public const string Processo = "apeProcesso"; // LOCALIZACAO 170523
    public const string Apenso = "apeApenso"; // LOCALIZACAO 170523
    public const string Acao = "apeAcao"; // LOCALIZACAO 170523
    public const string DtDist = "apeDtDist"; // LOCALIZACAO 170523
    public const string OBS = "apeOBS"; // LOCALIZACAO 170523
    public const string ValorCausa = "apeValorCausa"; // LOCALIZACAO 170523
    public const string QuemCad = "apeQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "apeDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "apeQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "apeDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "apeVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Apenso,
        3 => Acao,
        4 => DtDist,
        5 => OBS,
        6 => ValorCausa,
        7 => QuemCad,
        8 => DtCad,
        9 => QuemAtu,
        10 => DtAtu,
        11 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Apenso";
#region PropriedadesDaTabela
    public static DBInfoSystem ApeProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "ape"
    }; // DBI 11 
    public static DBInfoSystem ApeApenso => new(0, PTabelaNome, CampoCodigo, Apenso, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ape"
    };
    public static DBInfoSystem ApeAcao => new(0, PTabelaNome, CampoCodigo, Acao, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ape"
    };
    public static DBInfoSystem ApeDtDist => new(0, PTabelaNome, CampoCodigo, DtDist, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ape"
    };
    public static DBInfoSystem ApeOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "ape"
    };
    public static DBInfoSystem ApeValorCausa => new(0, PTabelaNome, CampoCodigo, ValorCausa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "ape"
    };
    public static DBInfoSystem ApeQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ape"
    }; // DBI 11 
    public static DBInfoSystem ApeDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ape"
    };
    public static DBInfoSystem ApeQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ape"
    }; // DBI 11 
    public static DBInfoSystem ApeDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ape"
    };
    public static DBInfoSystem ApeVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ape"
    };

#endregion
#region SMART_SQLServices 
    public static string ApensoSql(string text) => Apenso.SqlCmdTextIgual(text, 25) ?? string.Empty;
    public static string ApensoSqlNotIsNull => Apenso.SqlCmdNotIsNull() ?? string.Empty;
    public static string ApensoSqlIsNull => Apenso.SqlCmdIsNull() ?? string.Empty;

    public static string ApensoSqlDiff(string text) => Apenso.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ApensoSqlLike(string text) => Apenso.SqlCmdTextLike(text) ?? string.Empty;
    public static string ApensoSqlLikeInit(string text) => Apenso.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ApensoSqlLikeSpaces(string? text) => Apenso.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AcaoSql(string text) => Acao.SqlCmdTextIgual(text, 25) ?? string.Empty;
    public static string AcaoSqlNotIsNull => Acao.SqlCmdNotIsNull() ?? string.Empty;
    public static string AcaoSqlIsNull => Acao.SqlCmdIsNull() ?? string.Empty;

    public static string AcaoSqlDiff(string text) => Acao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AcaoSqlLike(string text) => Acao.SqlCmdTextLike(text) ?? string.Empty;
    public static string AcaoSqlLikeInit(string text) => Acao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AcaoSqlLikeSpaces(string? text) => Acao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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

    public static string OBSSql(string text) => OBS.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OBSSqlNotIsNull => OBS.SqlCmdNotIsNull() ?? string.Empty;
    public static string OBSSqlIsNull => OBS.SqlCmdIsNull() ?? string.Empty;

    public static string OBSSqlDiff(string text) => OBS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OBSSqlLike(string text) => OBS.SqlCmdTextLike(text) ?? string.Empty;
    public static string OBSSqlLikeInit(string text) => OBS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OBSSqlLikeSpaces(string? text) => OBS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        ApeProcesso = 1,
        ApeApenso = 2,
        ApeAcao = 3,
        ApeDtDist = 4,
        ApeOBS = 5,
        ApeValorCausa = 6,
        ApeQuemCad = 7,
        ApeDtCad = 8,
        ApeQuemAtu = 9,
        ApeDtAtu = 10,
        ApeVisto = 11
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.ApeProcesso => ApeProcesso,
        NomesCamposTabela.ApeApenso => ApeApenso,
        NomesCamposTabela.ApeAcao => ApeAcao,
        NomesCamposTabela.ApeDtDist => ApeDtDist,
        NomesCamposTabela.ApeOBS => ApeOBS,
        NomesCamposTabela.ApeValorCausa => ApeValorCausa,
        NomesCamposTabela.ApeQuemCad => ApeQuemCad,
        NomesCamposTabela.ApeDtCad => ApeDtCad,
        NomesCamposTabela.ApeQuemAtu => ApeQuemAtu,
        NomesCamposTabela.ApeDtAtu => ApeDtAtu,
        NomesCamposTabela.ApeVisto => ApeVisto,
        _ => null
    };
}