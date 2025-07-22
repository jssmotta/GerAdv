using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBNECompromissosDicInfo
{
    public const string CampoCodigo = "ncpCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ncp";
    public const string PalavraChave = "ncpPalavraChave"; // LOCALIZACAO 170523
    public const string Provisionar = "ncpProvisionar"; // LOCALIZACAO 170523
    public const string TipoCompromisso = "ncpTipoCompromisso"; // LOCALIZACAO 170523
    public const string TextoCompromisso = "ncpTextoCompromisso"; // LOCALIZACAO 170523
    public const string Bold = "ncpBold"; // LOCALIZACAO 170523
    public const string QuemCad = "ncpQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ncpDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ncpQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ncpDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ncpVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => PalavraChave,
        2 => Provisionar,
        3 => TipoCompromisso,
        4 => TextoCompromisso,
        5 => Bold,
        6 => QuemCad,
        7 => DtCad,
        8 => QuemAtu,
        9 => DtAtu,
        10 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "NECompromissos";
#region PropriedadesDaTabela
    public static DBInfoSystem NcpPalavraChave => new(0, PTabelaNome, CampoCodigo, PalavraChave, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpProvisionar => new(0, PTabelaNome, CampoCodigo, Provisionar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpTipoCompromisso => new(0, PTabelaNome, CampoCodigo, TipoCompromisso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoCompromissoDicInfo.CampoCodigo, DBTipoCompromissoDicInfo.TabelaNome, new DBTipoCompromissoODicInfo(), false)
    {
        Prefixo = "ncp"
    }; // DBI 11 
    public static DBInfoSystem NcpTextoCompromisso => new(0, PTabelaNome, CampoCodigo, TextoCompromisso, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ncp"
    }; // DBI 11 
    public static DBInfoSystem NcpDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ncp"
    }; // DBI 11 
    public static DBInfoSystem NcpDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ncp"
    };

#endregion
#region SMART_SQLServices 
    public static string ProvisionarSql(bool valueCheck) => Provisionar.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ProvisionarSqlSim => Provisionar.SqlCmdBoolSim() ?? string.Empty;
    public static string ProvisionarSqlNao => Provisionar.SqlCmdBoolNao() ?? string.Empty;

    public static string TextoCompromissoSql(string text) => TextoCompromisso.SqlCmdTextIgual(text) ?? string.Empty;
    public static string TextoCompromissoSqlNotIsNull => TextoCompromisso.SqlCmdNotIsNull() ?? string.Empty;
    public static string TextoCompromissoSqlIsNull => TextoCompromisso.SqlCmdIsNull() ?? string.Empty;

    public static string TextoCompromissoSqlDiff(string text) => TextoCompromisso.SqlCmdTextDiff(text) ?? string.Empty;
    public static string TextoCompromissoSqlLike(string text) => TextoCompromisso.SqlCmdTextLike(text) ?? string.Empty;
    public static string TextoCompromissoSqlLikeInit(string text) => TextoCompromisso.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string TextoCompromissoSqlLikeSpaces(string? text) => TextoCompromisso.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string BoldSql(bool valueCheck) => Bold.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BoldSqlSim => Bold.SqlCmdBoolSim() ?? string.Empty;
    public static string BoldSqlNao => Bold.SqlCmdBoolNao() ?? string.Empty;

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
        NcpPalavraChave = 1,
        NcpProvisionar = 2,
        NcpTipoCompromisso = 3,
        NcpTextoCompromisso = 4,
        NcpBold = 5,
        NcpQuemCad = 6,
        NcpDtCad = 7,
        NcpQuemAtu = 8,
        NcpDtAtu = 9,
        NcpVisto = 10
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.NcpPalavraChave => NcpPalavraChave,
        NomesCamposTabela.NcpProvisionar => NcpProvisionar,
        NomesCamposTabela.NcpTipoCompromisso => NcpTipoCompromisso,
        NomesCamposTabela.NcpTextoCompromisso => NcpTextoCompromisso,
        NomesCamposTabela.NcpBold => NcpBold,
        NomesCamposTabela.NcpQuemCad => NcpQuemCad,
        NomesCamposTabela.NcpDtCad => NcpDtCad,
        NomesCamposTabela.NcpQuemAtu => NcpQuemAtu,
        NomesCamposTabela.NcpDtAtu => NcpDtAtu,
        NomesCamposTabela.NcpVisto => NcpVisto,
        _ => null
    };
}