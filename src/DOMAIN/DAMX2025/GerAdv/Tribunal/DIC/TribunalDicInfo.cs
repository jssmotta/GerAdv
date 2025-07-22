using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTribunalDicInfo
{
    public const string CampoCodigo = "triCodigo";
    public const string CampoNome = "triNome";
    public const string TablePrefix = "tri";
    public const string Nome = "triNome"; // LOCALIZACAO 170523
    public const string Area = "triArea"; // LOCALIZACAO 170523
    public const string Justica = "triJustica"; // LOCALIZACAO 170523
    public const string Descricao = "triDescricao"; // LOCALIZACAO 170523
    public const string Instancia = "triInstancia"; // LOCALIZACAO 170523
    public const string Sigla = "triSigla"; // LOCALIZACAO 170523
    public const string Web = "triWeb"; // LOCALIZACAO 170523
    public const string Etiqueta = "triEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "triBold"; // LOCALIZACAO 170523
    public const string GUID = "triGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "triQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "triDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "triQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "triDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "triVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Area,
        3 => Justica,
        4 => Descricao,
        5 => Instancia,
        6 => Sigla,
        7 => Web,
        8 => Etiqueta,
        9 => Bold,
        10 => GUID,
        11 => QuemCad,
        12 => DtCad,
        13 => QuemAtu,
        14 => DtAtu,
        15 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Tribunal";
#region PropriedadesDaTabela
    public static DBInfoSystem TriNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false)
    {
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriInstancia => new(0, PTabelaNome, CampoCodigo, Instancia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBInstanciaDicInfo.CampoCodigo, DBInstanciaDicInfo.TabelaNome, new DBInstanciaODicInfo(), false)
    {
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriSigla => new(0, PTabelaNome, CampoCodigo, Sigla, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriWeb => new(0, PTabelaNome, CampoCodigo, Web, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "tri"
    };
    public static DBInfoSystem TriBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "tri"
    };
    public static DBInfoSystem TriGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "tri"
    };

#endregion
#region SMART_SQLServices 
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SiglaSql(string text) => Sigla.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string SiglaSqlNotIsNull => Sigla.SqlCmdNotIsNull() ?? string.Empty;
    public static string SiglaSqlIsNull => Sigla.SqlCmdIsNull() ?? string.Empty;

    public static string SiglaSqlDiff(string text) => Sigla.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SiglaSqlLike(string text) => Sigla.SqlCmdTextLike(text) ?? string.Empty;
    public static string SiglaSqlLikeInit(string text) => Sigla.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SiglaSqlLikeSpaces(string? text) => Sigla.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string WebSql(string text) => Web.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string WebSqlNotIsNull => Web.SqlCmdNotIsNull() ?? string.Empty;
    public static string WebSqlIsNull => Web.SqlCmdIsNull() ?? string.Empty;

    public static string WebSqlDiff(string text) => Web.SqlCmdTextDiff(text) ?? string.Empty;
    public static string WebSqlLike(string text) => Web.SqlCmdTextLike(text) ?? string.Empty;
    public static string WebSqlLikeInit(string text) => Web.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string WebSqlLikeSpaces(string? text) => Web.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EtiquetaSql(bool valueCheck) => Etiqueta.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string EtiquetaSqlSim => Etiqueta.SqlCmdBoolSim() ?? string.Empty;
    public static string EtiquetaSqlNao => Etiqueta.SqlCmdBoolNao() ?? string.Empty;

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
        TriNome = 1,
        TriArea = 2,
        TriJustica = 3,
        TriDescricao = 4,
        TriInstancia = 5,
        TriSigla = 6,
        TriWeb = 7,
        TriEtiqueta = 8,
        TriBold = 9,
        TriGUID = 10,
        TriQuemCad = 11,
        TriDtCad = 12,
        TriQuemAtu = 13,
        TriDtAtu = 14,
        TriVisto = 15
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TriNome => TriNome,
        NomesCamposTabela.TriArea => TriArea,
        NomesCamposTabela.TriJustica => TriJustica,
        NomesCamposTabela.TriDescricao => TriDescricao,
        NomesCamposTabela.TriInstancia => TriInstancia,
        NomesCamposTabela.TriSigla => TriSigla,
        NomesCamposTabela.TriWeb => TriWeb,
        NomesCamposTabela.TriEtiqueta => TriEtiqueta,
        NomesCamposTabela.TriBold => TriBold,
        NomesCamposTabela.TriGUID => TriGUID,
        NomesCamposTabela.TriQuemCad => TriQuemCad,
        NomesCamposTabela.TriDtCad => TriDtCad,
        NomesCamposTabela.TriQuemAtu => TriQuemAtu,
        NomesCamposTabela.TriDtAtu => TriDtAtu,
        NomesCamposTabela.TriVisto => TriVisto,
        _ => null
    };
}