using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProSucumbenciaDicInfo
{
    public const string CampoCodigo = "scbCodigo";
    public const string CampoNome = "scbNome";
    public const string TablePrefix = "scb";
    public const string Processo = "scbProcesso"; // LOCALIZACAO 170523
    public const string Instancia = "scbInstancia"; // LOCALIZACAO 170523
    public const string Data = "scbData"; // LOCALIZACAO 170523
    public const string Nome = "scbNome"; // LOCALIZACAO 170523
    public const string TipoOrigemSucumbencia = "scbTipoOrigemSucumbencia"; // LOCALIZACAO 170523
    public const string Valor = "scbValor"; // LOCALIZACAO 170523
    public const string Percentual = "scbPercentual"; // LOCALIZACAO 170523
    public const string GUID = "scbGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "scbQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "scbDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "scbQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "scbDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "scbVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Instancia,
        3 => Data,
        4 => Nome,
        5 => TipoOrigemSucumbencia,
        6 => Valor,
        7 => Percentual,
        8 => GUID,
        9 => QuemCad,
        10 => DtCad,
        11 => QuemAtu,
        12 => DtAtu,
        13 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProSucumbencia";
#region PropriedadesDaTabela
    public static DBInfoSystem ScbProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "scb"
    }; // DBI 11 
    public static DBInfoSystem ScbInstancia => new(0, PTabelaNome, CampoCodigo, Instancia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBInstanciaDicInfo.CampoCodigo, DBInstanciaDicInfo.TabelaNome, new DBInstanciaODicInfo(), false)
    {
        Prefixo = "scb"
    }; // DBI 11 
    public static DBInfoSystem ScbData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "scb"
    };
    public static DBInfoSystem ScbNome => new(0, PTabelaNome, CampoCodigo, Nome, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "scb"
    };
    public static DBInfoSystem ScbTipoOrigemSucumbencia => new(0, PTabelaNome, CampoCodigo, TipoOrigemSucumbencia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoOrigemSucumbenciaDicInfo.CampoCodigo, DBTipoOrigemSucumbenciaDicInfo.TabelaNome, new DBTipoOrigemSucumbenciaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "scb"
    }; // DBI 11 
    public static DBInfoSystem ScbValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "scb"
    };
    public static DBInfoSystem ScbPercentual => new(0, PTabelaNome, CampoCodigo, Percentual, 5, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "scb"
    };
    public static DBInfoSystem ScbGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "scb"
    };
    public static DBInfoSystem ScbQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "scb"
    }; // DBI 11 
    public static DBInfoSystem ScbDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "scb"
    };
    public static DBInfoSystem ScbQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "scb"
    }; // DBI 11 
    public static DBInfoSystem ScbDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "scb"
    };
    public static DBInfoSystem ScbVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "scb"
    };

#endregion
#region SMART_SQLServices 
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

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 2048) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PercentualSql(string text) => Percentual.SqlCmdTextIgual(text, 5) ?? string.Empty;
    public static string PercentualSqlNotIsNull => Percentual.SqlCmdNotIsNull() ?? string.Empty;
    public static string PercentualSqlIsNull => Percentual.SqlCmdIsNull() ?? string.Empty;

    public static string PercentualSqlDiff(string text) => Percentual.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PercentualSqlLike(string text) => Percentual.SqlCmdTextLike(text) ?? string.Empty;
    public static string PercentualSqlLikeInit(string text) => Percentual.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PercentualSqlLikeSpaces(string? text) => Percentual.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 150) ?? string.Empty;
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
        ScbProcesso = 1,
        ScbInstancia = 2,
        ScbData = 3,
        ScbNome = 4,
        ScbTipoOrigemSucumbencia = 5,
        ScbValor = 6,
        ScbPercentual = 7,
        ScbGUID = 8,
        ScbQuemCad = 9,
        ScbDtCad = 10,
        ScbQuemAtu = 11,
        ScbDtAtu = 12,
        ScbVisto = 13
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.ScbProcesso => ScbProcesso,
        NomesCamposTabela.ScbInstancia => ScbInstancia,
        NomesCamposTabela.ScbData => ScbData,
        NomesCamposTabela.ScbNome => ScbNome,
        NomesCamposTabela.ScbTipoOrigemSucumbencia => ScbTipoOrigemSucumbencia,
        NomesCamposTabela.ScbValor => ScbValor,
        NomesCamposTabela.ScbPercentual => ScbPercentual,
        NomesCamposTabela.ScbGUID => ScbGUID,
        NomesCamposTabela.ScbQuemCad => ScbQuemCad,
        NomesCamposTabela.ScbDtCad => ScbDtCad,
        NomesCamposTabela.ScbQuemAtu => ScbQuemAtu,
        NomesCamposTabela.ScbDtAtu => ScbDtAtu,
        NomesCamposTabela.ScbVisto => ScbVisto,
        _ => null
    };
}