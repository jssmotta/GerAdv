using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBDocsRecebidosItensDicInfo
{
    public const string CampoCodigo = "driCodigo";
    public const string CampoNome = "driNome";
    public const string TablePrefix = "dri";
    public const string ContatoCRM = "driContatoCRM"; // LOCALIZACAO 170523
    public const string Nome = "driNome"; // LOCALIZACAO 170523
    public const string Devolvido = "driDevolvido"; // LOCALIZACAO 170523
    public const string SeraDevolvido = "driSeraDevolvido"; // LOCALIZACAO 170523
    public const string Observacoes = "driObservacoes"; // LOCALIZACAO 170523
    public const string Bold = "driBold"; // LOCALIZACAO 170523
    public const string GUID = "driGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "driQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "driDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "driQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "driDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "driVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => ContatoCRM,
        2 => Nome,
        3 => Devolvido,
        4 => SeraDevolvido,
        5 => Observacoes,
        6 => Bold,
        7 => GUID,
        8 => QuemCad,
        9 => DtCad,
        10 => QuemAtu,
        11 => DtAtu,
        12 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "DocsRecebidosItens";
#region PropriedadesDaTabela
    public static DBInfoSystem DriContatoCRM => new(0, PTabelaNome, CampoCodigo, ContatoCRM, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBContatoCRMDicInfo.CampoCodigo, DBContatoCRMDicInfo.TabelaNome, new DBContatoCRMODicInfo(), false); // DBI 11 
    public static DBInfoSystem DriNome => new(0, PTabelaNome, CampoCodigo, Nome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem DriDevolvido => new(0, PTabelaNome, CampoCodigo, Devolvido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem DriSeraDevolvido => new(0, PTabelaNome, CampoCodigo, SeraDevolvido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem DriObservacoes => new(0, PTabelaNome, CampoCodigo, Observacoes, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem DriBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem DriGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem DriQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem DriDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem DriQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem DriDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem DriVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string ContatoCRMDiff(int id) => ContatoCRM.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ContatoCRMSql(int id) => ContatoCRM.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ContatoCRMIsNull => ContatoCRM.SqlCmdIsNull() ?? string.Empty;
    public static string ContatoCRMNotIsNull => ContatoCRM.SqlCmdNotIsNull() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DevolvidoSql(bool valueCheck) => Devolvido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string DevolvidoSqlSim => Devolvido.SqlCmdBoolSim() ?? string.Empty;
    public static string DevolvidoSqlNao => Devolvido.SqlCmdBoolNao() ?? string.Empty;

    public static string SeraDevolvidoSql(bool valueCheck) => SeraDevolvido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SeraDevolvidoSqlSim => SeraDevolvido.SqlCmdBoolSim() ?? string.Empty;
    public static string SeraDevolvidoSqlNao => SeraDevolvido.SqlCmdBoolNao() ?? string.Empty;

    public static string ObservacoesSql(string text) => Observacoes.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacoesSqlNotIsNull => Observacoes.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacoesSqlIsNull => Observacoes.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacoesSqlDiff(string text) => Observacoes.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacoesSqlLike(string text) => Observacoes.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacoesSqlLikeInit(string text) => Observacoes.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacoesSqlLikeSpaces(string? text) => Observacoes.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        DriContatoCRM = 1,
        DriNome = 2,
        DriDevolvido = 3,
        DriSeraDevolvido = 4,
        DriObservacoes = 5,
        DriBold = 6,
        DriGUID = 7,
        DriQuemCad = 8,
        DriDtCad = 9,
        DriQuemAtu = 10,
        DriDtAtu = 11,
        DriVisto = 12
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.DriContatoCRM => DriContatoCRM,
        NomesCamposTabela.DriNome => DriNome,
        NomesCamposTabela.DriDevolvido => DriDevolvido,
        NomesCamposTabela.DriSeraDevolvido => DriSeraDevolvido,
        NomesCamposTabela.DriObservacoes => DriObservacoes,
        NomesCamposTabela.DriBold => DriBold,
        NomesCamposTabela.DriGUID => DriGUID,
        NomesCamposTabela.DriQuemCad => DriQuemCad,
        NomesCamposTabela.DriDtCad => DriDtCad,
        NomesCamposTabela.DriQuemAtu => DriQuemAtu,
        NomesCamposTabela.DriDtAtu => DriDtAtu,
        NomesCamposTabela.DriVisto => DriVisto,
        _ => null
    };
}