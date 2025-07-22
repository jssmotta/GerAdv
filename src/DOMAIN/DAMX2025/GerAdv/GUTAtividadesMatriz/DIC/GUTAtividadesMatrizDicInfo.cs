using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBGUTAtividadesMatrizDicInfo
{
    public const string CampoCodigo = "amgCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "amg";
    public const string GUTMatriz = "amgGUTMatriz"; // LOCALIZACAO 170523
    public const string GUTAtividade = "amgGUTAtividade"; // LOCALIZACAO 170523
    public const string GUID = "amgGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "amgQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "amgDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "amgQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "amgDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "amgVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => GUTMatriz,
        2 => GUTAtividade,
        3 => GUID,
        4 => QuemCad,
        5 => DtCad,
        6 => QuemAtu,
        7 => DtAtu,
        8 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "GUTAtividadesMatriz";
#region PropriedadesDaTabela
    public static DBInfoSystem AmgGUTMatriz => new(0, PTabelaNome, CampoCodigo, GUTMatriz, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBGUTMatrizDicInfo.CampoCodigo, DBGUTMatrizDicInfo.TabelaNome, new DBGUTMatrizODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "amg"
    }; // DBI 11 
    public static DBInfoSystem AmgGUTAtividade => new(0, PTabelaNome, CampoCodigo, GUTAtividade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBGUTAtividadesDicInfo.CampoCodigo, DBGUTAtividadesDicInfo.TabelaNome, new DBGUTAtividadesODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "amg"
    }; // DBI 11 
    public static DBInfoSystem AmgGUID => new(0, PTabelaNome, CampoCodigo, GUID, 50, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "amg"
    };
    public static DBInfoSystem AmgQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "amg"
    }; // DBI 11 
    public static DBInfoSystem AmgDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "amg"
    };
    public static DBInfoSystem AmgQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "amg"
    }; // DBI 11 
    public static DBInfoSystem AmgDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "amg"
    };
    public static DBInfoSystem AmgVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "amg"
    };

#endregion
#region SMART_SQLServices 
    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 50) ?? string.Empty;
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
        AmgGUTMatriz = 1,
        AmgGUTAtividade = 2,
        AmgGUID = 3,
        AmgQuemCad = 4,
        AmgDtCad = 5,
        AmgQuemAtu = 6,
        AmgDtAtu = 7,
        AmgVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AmgGUTMatriz => AmgGUTMatriz,
        NomesCamposTabela.AmgGUTAtividade => AmgGUTAtividade,
        NomesCamposTabela.AmgGUID => AmgGUID,
        NomesCamposTabela.AmgQuemCad => AmgQuemCad,
        NomesCamposTabela.AmgDtCad => AmgDtCad,
        NomesCamposTabela.AmgQuemAtu => AmgQuemAtu,
        NomesCamposTabela.AmgDtAtu => AmgDtAtu,
        NomesCamposTabela.AmgVisto => AmgVisto,
        _ => null
    };
}