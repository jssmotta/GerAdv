using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBBensMateriaisDicInfo
{
    public const string CampoCodigo = "bmtCodigo";
    public const string CampoNome = "bmtNome";
    public const string TablePrefix = "bmt";
    public const string Nome = "bmtNome"; // LOCALIZACAO 170523
    public const string BensClassificacao = "bmtBensClassificacao"; // LOCALIZACAO 170523
    public const string DataCompra = "bmtDataCompra"; // LOCALIZACAO 170523
    public const string DataFimDaGarantia = "bmtDataFimDaGarantia"; // LOCALIZACAO 170523
    public const string NFNRO = "bmtNFNRO"; // LOCALIZACAO 170523
    public const string Fornecedor = "bmtFornecedor"; // LOCALIZACAO 170523
    public const string ValorBem = "bmtValorBem"; // LOCALIZACAO 170523
    public const string NroSerieProduto = "bmtNroSerieProduto"; // LOCALIZACAO 170523
    public const string Comprador = "bmtComprador"; // LOCALIZACAO 170523
    public const string Cidade = "bmtCidade"; // LOCALIZACAO 170523
    public const string GarantiaLoja = "bmtGarantiaLoja"; // LOCALIZACAO 170523
    public const string DataTerminoDaGarantiaDaLoja = "bmtDataTerminoDaGarantiaDaLoja"; // LOCALIZACAO 170523
    public const string Observacoes = "bmtObservacoes"; // LOCALIZACAO 170523
    public const string NomeVendedor = "bmtNomeVendedor"; // LOCALIZACAO 170523
    public const string Bold = "bmtBold"; // LOCALIZACAO 170523
    public const string GUID = "bmtGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "bmtQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "bmtDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "bmtQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "bmtDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "bmtVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => BensClassificacao,
        3 => DataCompra,
        4 => DataFimDaGarantia,
        5 => NFNRO,
        6 => Fornecedor,
        7 => ValorBem,
        8 => NroSerieProduto,
        9 => Comprador,
        10 => Cidade,
        11 => GarantiaLoja,
        12 => DataTerminoDaGarantiaDaLoja,
        13 => Observacoes,
        14 => NomeVendedor,
        15 => Bold,
        16 => GUID,
        17 => QuemCad,
        18 => DtCad,
        19 => QuemAtu,
        20 => DtAtu,
        21 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "BensMateriais";
#region PropriedadesDaTabela
    public static DBInfoSystem BmtNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtBensClassificacao => new(0, PTabelaNome, CampoCodigo, BensClassificacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBBensClassificacaoDicInfo.CampoCodigo, DBBensClassificacaoDicInfo.TabelaNome, new DBBensClassificacaoODicInfo(), false)
    {
        Prefixo = "bmt"
    }; // DBI 11 
    public static DBInfoSystem BmtDataCompra => new(0, PTabelaNome, CampoCodigo, DataCompra, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtDataFimDaGarantia => new(0, PTabelaNome, CampoCodigo, DataFimDaGarantia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtNFNRO => new(0, PTabelaNome, CampoCodigo, NFNRO, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtFornecedor => new(0, PTabelaNome, CampoCodigo, Fornecedor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFornecedoresDicInfo.CampoCodigo, DBFornecedoresDicInfo.TabelaNome, new DBFornecedoresODicInfo(), false)
    {
        Prefixo = "bmt"
    }; // DBI 11 
    public static DBInfoSystem BmtValorBem => new(0, PTabelaNome, CampoCodigo, ValorBem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtNroSerieProduto => new(0, PTabelaNome, CampoCodigo, NroSerieProduto, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtComprador => new(0, PTabelaNome, CampoCodigo, Comprador, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "bmt"
    }; // DBI 11 
    public static DBInfoSystem BmtGarantiaLoja => new(0, PTabelaNome, CampoCodigo, GarantiaLoja, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtDataTerminoDaGarantiaDaLoja => new(0, PTabelaNome, CampoCodigo, DataTerminoDaGarantiaDaLoja, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtObservacoes => new(0, PTabelaNome, CampoCodigo, Observacoes, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtNomeVendedor => new(0, PTabelaNome, CampoCodigo, NomeVendedor, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "bmt"
    }; // DBI 11 
    public static DBInfoSystem BmtDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "bmt"
    }; // DBI 11 
    public static DBInfoSystem BmtDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "bmt"
    };
    public static DBInfoSystem BmtVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "bmt"
    };

#endregion
#region SMART_SQLServices 
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DataCompraSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataCompra}]");
    public static string DataCompraSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataCompra}]");
    public static string DataCompraSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataCompra}]");
    public static string DataCompraSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataCompra}]");
    public static string DataCompraSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataCompra}]");
    public static string DataCompraSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataCompra}]");
    public static string DataCompraSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataCompra}]");
    public static string DataCompraSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataCompra}]");
    public static string DataCompraSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataCompra}]");
    public static string DataCompraSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataCompra}]");
    public static string DataCompraSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataCompra}]");
    public static string DataCompraSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataCompra}]");
    public static string DataCompraIsNull => DataCompra.SqlCmdIsNull() ?? string.Empty;
    public static string DataCompraNotIsNull => DataCompra.SqlCmdNotIsNull() ?? string.Empty;

    public static string DataFimDaGarantiaSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataFimDaGarantia}]");
    public static string DataFimDaGarantiaIsNull => DataFimDaGarantia.SqlCmdIsNull() ?? string.Empty;
    public static string DataFimDaGarantiaNotIsNull => DataFimDaGarantia.SqlCmdNotIsNull() ?? string.Empty;

    public static string NFNROSql(string text) => NFNRO.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string NFNROSqlNotIsNull => NFNRO.SqlCmdNotIsNull() ?? string.Empty;
    public static string NFNROSqlIsNull => NFNRO.SqlCmdIsNull() ?? string.Empty;

    public static string NFNROSqlDiff(string text) => NFNRO.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NFNROSqlLike(string text) => NFNRO.SqlCmdTextLike(text) ?? string.Empty;
    public static string NFNROSqlLikeInit(string text) => NFNRO.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NFNROSqlLikeSpaces(string? text) => NFNRO.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NroSerieProdutoSql(string text) => NroSerieProduto.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string NroSerieProdutoSqlNotIsNull => NroSerieProduto.SqlCmdNotIsNull() ?? string.Empty;
    public static string NroSerieProdutoSqlIsNull => NroSerieProduto.SqlCmdIsNull() ?? string.Empty;

    public static string NroSerieProdutoSqlDiff(string text) => NroSerieProduto.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NroSerieProdutoSqlLike(string text) => NroSerieProduto.SqlCmdTextLike(text) ?? string.Empty;
    public static string NroSerieProdutoSqlLikeInit(string text) => NroSerieProduto.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NroSerieProdutoSqlLikeSpaces(string? text) => NroSerieProduto.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CompradorSql(string text) => Comprador.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string CompradorSqlNotIsNull => Comprador.SqlCmdNotIsNull() ?? string.Empty;
    public static string CompradorSqlIsNull => Comprador.SqlCmdIsNull() ?? string.Empty;

    public static string CompradorSqlDiff(string text) => Comprador.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CompradorSqlLike(string text) => Comprador.SqlCmdTextLike(text) ?? string.Empty;
    public static string CompradorSqlLikeInit(string text) => Comprador.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CompradorSqlLikeSpaces(string? text) => Comprador.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string GarantiaLojaSql(bool valueCheck) => GarantiaLoja.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string GarantiaLojaSqlSim => GarantiaLoja.SqlCmdBoolSim() ?? string.Empty;
    public static string GarantiaLojaSqlNao => GarantiaLoja.SqlCmdBoolNao() ?? string.Empty;

    public static string DataTerminoDaGarantiaDaLojaSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataTerminoDaGarantiaDaLoja}]");
    public static string DataTerminoDaGarantiaDaLojaIsNull => DataTerminoDaGarantiaDaLoja.SqlCmdIsNull() ?? string.Empty;
    public static string DataTerminoDaGarantiaDaLojaNotIsNull => DataTerminoDaGarantiaDaLoja.SqlCmdNotIsNull() ?? string.Empty;

    public static string ObservacoesSql(string text) => Observacoes.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacoesSqlNotIsNull => Observacoes.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacoesSqlIsNull => Observacoes.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacoesSqlDiff(string text) => Observacoes.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacoesSqlLike(string text) => Observacoes.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacoesSqlLikeInit(string text) => Observacoes.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacoesSqlLikeSpaces(string? text) => Observacoes.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NomeVendedorSql(string text) => NomeVendedor.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string NomeVendedorSqlNotIsNull => NomeVendedor.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeVendedorSqlIsNull => NomeVendedor.SqlCmdIsNull() ?? string.Empty;

    public static string NomeVendedorSqlDiff(string text) => NomeVendedor.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeVendedorSqlLike(string text) => NomeVendedor.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeVendedorSqlLikeInit(string text) => NomeVendedor.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeVendedorSqlLikeSpaces(string? text) => NomeVendedor.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        BmtNome = 1,
        BmtBensClassificacao = 2,
        BmtDataCompra = 3,
        BmtDataFimDaGarantia = 4,
        BmtNFNRO = 5,
        BmtFornecedor = 6,
        BmtValorBem = 7,
        BmtNroSerieProduto = 8,
        BmtComprador = 9,
        BmtCidade = 10,
        BmtGarantiaLoja = 11,
        BmtDataTerminoDaGarantiaDaLoja = 12,
        BmtObservacoes = 13,
        BmtNomeVendedor = 14,
        BmtBold = 15,
        BmtGUID = 16,
        BmtQuemCad = 17,
        BmtDtCad = 18,
        BmtQuemAtu = 19,
        BmtDtAtu = 20,
        BmtVisto = 21
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.BmtNome => BmtNome,
        NomesCamposTabela.BmtBensClassificacao => BmtBensClassificacao,
        NomesCamposTabela.BmtDataCompra => BmtDataCompra,
        NomesCamposTabela.BmtDataFimDaGarantia => BmtDataFimDaGarantia,
        NomesCamposTabela.BmtNFNRO => BmtNFNRO,
        NomesCamposTabela.BmtFornecedor => BmtFornecedor,
        NomesCamposTabela.BmtValorBem => BmtValorBem,
        NomesCamposTabela.BmtNroSerieProduto => BmtNroSerieProduto,
        NomesCamposTabela.BmtComprador => BmtComprador,
        NomesCamposTabela.BmtCidade => BmtCidade,
        NomesCamposTabela.BmtGarantiaLoja => BmtGarantiaLoja,
        NomesCamposTabela.BmtDataTerminoDaGarantiaDaLoja => BmtDataTerminoDaGarantiaDaLoja,
        NomesCamposTabela.BmtObservacoes => BmtObservacoes,
        NomesCamposTabela.BmtNomeVendedor => BmtNomeVendedor,
        NomesCamposTabela.BmtBold => BmtBold,
        NomesCamposTabela.BmtGUID => BmtGUID,
        NomesCamposTabela.BmtQuemCad => BmtQuemCad,
        NomesCamposTabela.BmtDtCad => BmtDtCad,
        NomesCamposTabela.BmtQuemAtu => BmtQuemAtu,
        NomesCamposTabela.BmtDtAtu => BmtDtAtu,
        NomesCamposTabela.BmtVisto => BmtVisto,
        _ => null
    };
}