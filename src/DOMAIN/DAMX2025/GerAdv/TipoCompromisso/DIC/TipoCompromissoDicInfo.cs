using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTipoCompromissoDicInfo
{
    public const string CampoCodigo = "tipCodigo";
    public const string CampoNome = "tipDescricao";
    public const string TablePrefix = "tip";
    public const string Icone = "tipIcone"; // LOCALIZACAO 170523
    public const string Descricao = "tipDescricao"; // LOCALIZACAO 170523
    public const string Financeiro = "tipFinanceiro"; // LOCALIZACAO 170523
    public const string Bold = "tipBold"; // LOCALIZACAO 170523
    public const string GUID = "tipGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "tipQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "tipDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "tipQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "tipDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "tipVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Icone,
        2 => Descricao,
        3 => Financeiro,
        4 => Bold,
        5 => GUID,
        6 => QuemCad,
        7 => DtCad,
        8 => QuemAtu,
        9 => DtAtu,
        10 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TipoCompromisso";
#region PropriedadesDaTabela
    public static DBInfoSystem TipIcone => new(0, PTabelaNome, CampoCodigo, Icone, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipFinanceiro => new(0, PTabelaNome, CampoCodigo, Financeiro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "tip"
    };
    public static DBInfoSystem TipGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tip"
    }; // DBI 11 
    public static DBInfoSystem TipDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tip"
    }; // DBI 11 
    public static DBInfoSystem TipDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "tip"
    };

#endregion
#region SMART_SQLServices 
    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FinanceiroSql(bool valueCheck) => Financeiro.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string FinanceiroSqlSim => Financeiro.SqlCmdBoolSim() ?? string.Empty;
    public static string FinanceiroSqlNao => Financeiro.SqlCmdBoolNao() ?? string.Empty;

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
        TipIcone = 1,
        TipDescricao = 2,
        TipFinanceiro = 3,
        TipBold = 4,
        TipGUID = 5,
        TipQuemCad = 6,
        TipDtCad = 7,
        TipQuemAtu = 8,
        TipDtAtu = 9,
        TipVisto = 10
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TipIcone => TipIcone,
        NomesCamposTabela.TipDescricao => TipDescricao,
        NomesCamposTabela.TipFinanceiro => TipFinanceiro,
        NomesCamposTabela.TipBold => TipBold,
        NomesCamposTabela.TipGUID => TipGUID,
        NomesCamposTabela.TipQuemCad => TipQuemCad,
        NomesCamposTabela.TipDtCad => TipDtCad,
        NomesCamposTabela.TipQuemAtu => TipQuemAtu,
        NomesCamposTabela.TipDtAtu => TipDtAtu,
        NomesCamposTabela.TipVisto => TipVisto,
        _ => null
    };
}