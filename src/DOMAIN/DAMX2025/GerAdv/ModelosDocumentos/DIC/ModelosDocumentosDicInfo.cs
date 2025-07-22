using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBModelosDocumentosDicInfo
{
    public const string CampoCodigo = "mdcCodigo";
    public const string CampoNome = "mdcNome";
    public const string TablePrefix = "mdc";
    public const string Nome = "mdcNome"; // LOCALIZACAO 170523
    public const string Remuneracao = "mdcRemuneracao"; // LOCALIZACAO 170523
    public const string Assinatura = "mdcAssinatura"; // LOCALIZACAO 170523
    public const string Header = "mdcHeader"; // LOCALIZACAO 170523
    public const string Footer = "mdcFooter"; // LOCALIZACAO 170523
    public const string Extra1 = "mdcExtra1"; // LOCALIZACAO 170523
    public const string Extra2 = "mdcExtra2"; // LOCALIZACAO 170523
    public const string Extra3 = "mdcExtra3"; // LOCALIZACAO 170523
    public const string Outorgante = "mdcOutorgante"; // LOCALIZACAO 170523
    public const string Outorgados = "mdcOutorgados"; // LOCALIZACAO 170523
    public const string Poderes = "mdcPoderes"; // LOCALIZACAO 170523
    public const string Objeto = "mdcObjeto"; // LOCALIZACAO 170523
    public const string Titulo = "mdcTitulo"; // LOCALIZACAO 170523
    public const string Testemunhas = "mdcTestemunhas"; // LOCALIZACAO 170523
    public const string TipoModeloDocumento = "mdcTipoModeloDocumento"; // LOCALIZACAO 170523
    public const string CSS = "mdcCSS"; // LOCALIZACAO 170523
    public const string GUID = "mdcGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "mdcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "mdcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "mdcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "mdcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "mdcVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Remuneracao,
        3 => Assinatura,
        4 => Header,
        5 => Footer,
        6 => Extra1,
        7 => Extra2,
        8 => Extra3,
        9 => Outorgante,
        10 => Outorgados,
        11 => Poderes,
        12 => Objeto,
        13 => Titulo,
        14 => Testemunhas,
        15 => TipoModeloDocumento,
        16 => CSS,
        17 => GUID,
        18 => QuemCad,
        19 => DtCad,
        20 => QuemAtu,
        21 => DtAtu,
        22 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ModelosDocumentos";
#region PropriedadesDaTabela
    public static DBInfoSystem MdcNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcRemuneracao => new(0, PTabelaNome, CampoCodigo, Remuneracao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcAssinatura => new(0, PTabelaNome, CampoCodigo, Assinatura, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcHeader => new(0, PTabelaNome, CampoCodigo, Header, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcFooter => new(0, PTabelaNome, CampoCodigo, Footer, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcExtra1 => new(0, PTabelaNome, CampoCodigo, Extra1, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcExtra2 => new(0, PTabelaNome, CampoCodigo, Extra2, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcExtra3 => new(0, PTabelaNome, CampoCodigo, Extra3, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcOutorgante => new(0, PTabelaNome, CampoCodigo, Outorgante, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcOutorgados => new(0, PTabelaNome, CampoCodigo, Outorgados, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcPoderes => new(0, PTabelaNome, CampoCodigo, Poderes, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcObjeto => new(0, PTabelaNome, CampoCodigo, Objeto, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcTitulo => new(0, PTabelaNome, CampoCodigo, Titulo, 2000, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcTestemunhas => new(0, PTabelaNome, CampoCodigo, Testemunhas, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcTipoModeloDocumento => new(0, PTabelaNome, CampoCodigo, TipoModeloDocumento, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoModeloDocumentoDicInfo.CampoCodigo, DBTipoModeloDocumentoDicInfo.TabelaNome, new DBTipoModeloDocumentoODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "mdc"
    }; // DBI 11 
    public static DBInfoSystem MdcCSS => new(0, PTabelaNome, CampoCodigo, CSS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "mdc"
    }; // DBI 11 
    public static DBInfoSystem MdcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "mdc"
    }; // DBI 11 
    public static DBInfoSystem MdcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "mdc"
    };
    public static DBInfoSystem MdcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "mdc"
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
    public static string RemuneracaoSql(string text) => Remuneracao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string RemuneracaoSqlNotIsNull => Remuneracao.SqlCmdNotIsNull() ?? string.Empty;
    public static string RemuneracaoSqlIsNull => Remuneracao.SqlCmdIsNull() ?? string.Empty;

    public static string RemuneracaoSqlDiff(string text) => Remuneracao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RemuneracaoSqlLike(string text) => Remuneracao.SqlCmdTextLike(text) ?? string.Empty;
    public static string RemuneracaoSqlLikeInit(string text) => Remuneracao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RemuneracaoSqlLikeSpaces(string? text) => Remuneracao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AssinaturaSql(string text) => Assinatura.SqlCmdTextIgual(text) ?? string.Empty;
    public static string AssinaturaSqlNotIsNull => Assinatura.SqlCmdNotIsNull() ?? string.Empty;
    public static string AssinaturaSqlIsNull => Assinatura.SqlCmdIsNull() ?? string.Empty;

    public static string AssinaturaSqlDiff(string text) => Assinatura.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AssinaturaSqlLike(string text) => Assinatura.SqlCmdTextLike(text) ?? string.Empty;
    public static string AssinaturaSqlLikeInit(string text) => Assinatura.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AssinaturaSqlLikeSpaces(string? text) => Assinatura.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string HeaderSql(string text) => Header.SqlCmdTextIgual(text) ?? string.Empty;
    public static string HeaderSqlNotIsNull => Header.SqlCmdNotIsNull() ?? string.Empty;
    public static string HeaderSqlIsNull => Header.SqlCmdIsNull() ?? string.Empty;

    public static string HeaderSqlDiff(string text) => Header.SqlCmdTextDiff(text) ?? string.Empty;
    public static string HeaderSqlLike(string text) => Header.SqlCmdTextLike(text) ?? string.Empty;
    public static string HeaderSqlLikeInit(string text) => Header.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string HeaderSqlLikeSpaces(string? text) => Header.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FooterSql(string text) => Footer.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FooterSqlNotIsNull => Footer.SqlCmdNotIsNull() ?? string.Empty;
    public static string FooterSqlIsNull => Footer.SqlCmdIsNull() ?? string.Empty;

    public static string FooterSqlDiff(string text) => Footer.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FooterSqlLike(string text) => Footer.SqlCmdTextLike(text) ?? string.Empty;
    public static string FooterSqlLikeInit(string text) => Footer.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FooterSqlLikeSpaces(string? text) => Footer.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string Extra1Sql(string text) => Extra1.SqlCmdTextIgual(text) ?? string.Empty;
    public static string Extra1SqlNotIsNull => Extra1.SqlCmdNotIsNull() ?? string.Empty;
    public static string Extra1SqlIsNull => Extra1.SqlCmdIsNull() ?? string.Empty;

    public static string Extra1SqlDiff(string text) => Extra1.SqlCmdTextDiff(text) ?? string.Empty;
    public static string Extra1SqlLike(string text) => Extra1.SqlCmdTextLike(text) ?? string.Empty;
    public static string Extra1SqlLikeInit(string text) => Extra1.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string Extra1SqlLikeSpaces(string? text) => Extra1.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string Extra2Sql(string text) => Extra2.SqlCmdTextIgual(text) ?? string.Empty;
    public static string Extra2SqlNotIsNull => Extra2.SqlCmdNotIsNull() ?? string.Empty;
    public static string Extra2SqlIsNull => Extra2.SqlCmdIsNull() ?? string.Empty;

    public static string Extra2SqlDiff(string text) => Extra2.SqlCmdTextDiff(text) ?? string.Empty;
    public static string Extra2SqlLike(string text) => Extra2.SqlCmdTextLike(text) ?? string.Empty;
    public static string Extra2SqlLikeInit(string text) => Extra2.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string Extra2SqlLikeSpaces(string? text) => Extra2.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string Extra3Sql(string text) => Extra3.SqlCmdTextIgual(text) ?? string.Empty;
    public static string Extra3SqlNotIsNull => Extra3.SqlCmdNotIsNull() ?? string.Empty;
    public static string Extra3SqlIsNull => Extra3.SqlCmdIsNull() ?? string.Empty;

    public static string Extra3SqlDiff(string text) => Extra3.SqlCmdTextDiff(text) ?? string.Empty;
    public static string Extra3SqlLike(string text) => Extra3.SqlCmdTextLike(text) ?? string.Empty;
    public static string Extra3SqlLikeInit(string text) => Extra3.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string Extra3SqlLikeSpaces(string? text) => Extra3.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OutorganteSql(string text) => Outorgante.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OutorganteSqlNotIsNull => Outorgante.SqlCmdNotIsNull() ?? string.Empty;
    public static string OutorganteSqlIsNull => Outorgante.SqlCmdIsNull() ?? string.Empty;

    public static string OutorganteSqlDiff(string text) => Outorgante.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OutorganteSqlLike(string text) => Outorgante.SqlCmdTextLike(text) ?? string.Empty;
    public static string OutorganteSqlLikeInit(string text) => Outorgante.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OutorganteSqlLikeSpaces(string? text) => Outorgante.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OutorgadosSql(string text) => Outorgados.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OutorgadosSqlNotIsNull => Outorgados.SqlCmdNotIsNull() ?? string.Empty;
    public static string OutorgadosSqlIsNull => Outorgados.SqlCmdIsNull() ?? string.Empty;

    public static string OutorgadosSqlDiff(string text) => Outorgados.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OutorgadosSqlLike(string text) => Outorgados.SqlCmdTextLike(text) ?? string.Empty;
    public static string OutorgadosSqlLikeInit(string text) => Outorgados.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OutorgadosSqlLikeSpaces(string? text) => Outorgados.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PoderesSql(string text) => Poderes.SqlCmdTextIgual(text) ?? string.Empty;
    public static string PoderesSqlNotIsNull => Poderes.SqlCmdNotIsNull() ?? string.Empty;
    public static string PoderesSqlIsNull => Poderes.SqlCmdIsNull() ?? string.Empty;

    public static string PoderesSqlDiff(string text) => Poderes.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PoderesSqlLike(string text) => Poderes.SqlCmdTextLike(text) ?? string.Empty;
    public static string PoderesSqlLikeInit(string text) => Poderes.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PoderesSqlLikeSpaces(string? text) => Poderes.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObjetoSql(string text) => Objeto.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObjetoSqlNotIsNull => Objeto.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObjetoSqlIsNull => Objeto.SqlCmdIsNull() ?? string.Empty;

    public static string ObjetoSqlDiff(string text) => Objeto.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObjetoSqlLike(string text) => Objeto.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObjetoSqlLikeInit(string text) => Objeto.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObjetoSqlLikeSpaces(string? text) => Objeto.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TituloSql(string text) => Titulo.SqlCmdTextIgual(text, 2000) ?? string.Empty;
    public static string TituloSqlNotIsNull => Titulo.SqlCmdNotIsNull() ?? string.Empty;
    public static string TituloSqlIsNull => Titulo.SqlCmdIsNull() ?? string.Empty;

    public static string TituloSqlDiff(string text) => Titulo.SqlCmdTextDiff(text) ?? string.Empty;
    public static string TituloSqlLike(string text) => Titulo.SqlCmdTextLike(text) ?? string.Empty;
    public static string TituloSqlLikeInit(string text) => Titulo.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string TituloSqlLikeSpaces(string? text) => Titulo.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TestemunhasSql(string text) => Testemunhas.SqlCmdTextIgual(text) ?? string.Empty;
    public static string TestemunhasSqlNotIsNull => Testemunhas.SqlCmdNotIsNull() ?? string.Empty;
    public static string TestemunhasSqlIsNull => Testemunhas.SqlCmdIsNull() ?? string.Empty;

    public static string TestemunhasSqlDiff(string text) => Testemunhas.SqlCmdTextDiff(text) ?? string.Empty;
    public static string TestemunhasSqlLike(string text) => Testemunhas.SqlCmdTextLike(text) ?? string.Empty;
    public static string TestemunhasSqlLikeInit(string text) => Testemunhas.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string TestemunhasSqlLikeSpaces(string? text) => Testemunhas.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CSSSql(string text) => CSS.SqlCmdTextIgual(text) ?? string.Empty;
    public static string CSSSqlNotIsNull => CSS.SqlCmdNotIsNull() ?? string.Empty;
    public static string CSSSqlIsNull => CSS.SqlCmdIsNull() ?? string.Empty;

    public static string CSSSqlDiff(string text) => CSS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CSSSqlLike(string text) => CSS.SqlCmdTextLike(text) ?? string.Empty;
    public static string CSSSqlLikeInit(string text) => CSS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CSSSqlLikeSpaces(string? text) => CSS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        MdcNome = 1,
        MdcRemuneracao = 2,
        MdcAssinatura = 3,
        MdcHeader = 4,
        MdcFooter = 5,
        MdcExtra1 = 6,
        MdcExtra2 = 7,
        MdcExtra3 = 8,
        MdcOutorgante = 9,
        MdcOutorgados = 10,
        MdcPoderes = 11,
        MdcObjeto = 12,
        MdcTitulo = 13,
        MdcTestemunhas = 14,
        MdcTipoModeloDocumento = 15,
        MdcCSS = 16,
        MdcGUID = 17,
        MdcQuemCad = 18,
        MdcDtCad = 19,
        MdcQuemAtu = 20,
        MdcDtAtu = 21,
        MdcVisto = 22
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.MdcNome => MdcNome,
        NomesCamposTabela.MdcRemuneracao => MdcRemuneracao,
        NomesCamposTabela.MdcAssinatura => MdcAssinatura,
        NomesCamposTabela.MdcHeader => MdcHeader,
        NomesCamposTabela.MdcFooter => MdcFooter,
        NomesCamposTabela.MdcExtra1 => MdcExtra1,
        NomesCamposTabela.MdcExtra2 => MdcExtra2,
        NomesCamposTabela.MdcExtra3 => MdcExtra3,
        NomesCamposTabela.MdcOutorgante => MdcOutorgante,
        NomesCamposTabela.MdcOutorgados => MdcOutorgados,
        NomesCamposTabela.MdcPoderes => MdcPoderes,
        NomesCamposTabela.MdcObjeto => MdcObjeto,
        NomesCamposTabela.MdcTitulo => MdcTitulo,
        NomesCamposTabela.MdcTestemunhas => MdcTestemunhas,
        NomesCamposTabela.MdcTipoModeloDocumento => MdcTipoModeloDocumento,
        NomesCamposTabela.MdcCSS => MdcCSS,
        NomesCamposTabela.MdcGUID => MdcGUID,
        NomesCamposTabela.MdcQuemCad => MdcQuemCad,
        NomesCamposTabela.MdcDtCad => MdcDtCad,
        NomesCamposTabela.MdcQuemAtu => MdcQuemAtu,
        NomesCamposTabela.MdcDtAtu => MdcDtAtu,
        NomesCamposTabela.MdcVisto => MdcVisto,
        _ => null
    };
}