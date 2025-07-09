using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBHonorariosDadosContratoDicInfo
{
    public const string CampoCodigo = "hdcCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "hdc";
    public const string Cliente = "hdcCliente"; // LOCALIZACAO 170523
    public const string Fixo = "hdcFixo"; // LOCALIZACAO 170523
    public const string Variavel = "hdcVariavel"; // LOCALIZACAO 170523
    public const string PercSucesso = "hdcPercSucesso"; // LOCALIZACAO 170523
    public const string Processo = "hdcProcesso"; // LOCALIZACAO 170523
    public const string ArquivoContrato = "hdcArquivoContrato"; // LOCALIZACAO 170523
    public const string TextoContrato = "hdcTextoContrato"; // LOCALIZACAO 170523
    public const string ValorFixo = "hdcValorFixo"; // LOCALIZACAO 170523
    public const string Observacao = "hdcObservacao"; // LOCALIZACAO 170523
    public const string DataContrato = "hdcDataContrato"; // LOCALIZACAO 170523
    public const string GUID = "hdcGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "hdcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "hdcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "hdcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "hdcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "hdcVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cliente,
        2 => Fixo,
        3 => Variavel,
        4 => PercSucesso,
        5 => Processo,
        6 => ArquivoContrato,
        7 => TextoContrato,
        8 => ValorFixo,
        9 => Observacao,
        10 => DataContrato,
        11 => GUID,
        12 => QuemCad,
        13 => DtCad,
        14 => QuemAtu,
        15 => DtAtu,
        16 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "HonorariosDadosContrato";
#region PropriedadesDaTabela
    public static DBInfoSystem HdcCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem HdcFixo => new(0, PTabelaNome, CampoCodigo, Fixo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem HdcVariavel => new(0, PTabelaNome, CampoCodigo, Variavel, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem HdcPercSucesso => new(0, PTabelaNome, CampoCodigo, PercSucesso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem HdcProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem HdcArquivoContrato => new(0, PTabelaNome, CampoCodigo, ArquivoContrato, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem HdcTextoContrato => new(0, PTabelaNome, CampoCodigo, TextoContrato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem HdcValorFixo => new(0, PTabelaNome, CampoCodigo, ValorFixo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem HdcObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem HdcDataContrato => new(0, PTabelaNome, CampoCodigo, DataContrato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem HdcGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem HdcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem HdcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem HdcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem HdcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem HdcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string FixoSql(bool valueCheck) => Fixo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string FixoSqlSim => Fixo.SqlCmdBoolSim() ?? string.Empty;
    public static string FixoSqlNao => Fixo.SqlCmdBoolNao() ?? string.Empty;

    public static string VariavelSql(bool valueCheck) => Variavel.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string VariavelSqlSim => Variavel.SqlCmdBoolSim() ?? string.Empty;
    public static string VariavelSqlNao => Variavel.SqlCmdBoolNao() ?? string.Empty;

    public static string ArquivoContratoSql(string text) => ArquivoContrato.SqlCmdTextIgual(text, 2048) ?? string.Empty;
    public static string ArquivoContratoSqlNotIsNull => ArquivoContrato.SqlCmdNotIsNull() ?? string.Empty;
    public static string ArquivoContratoSqlIsNull => ArquivoContrato.SqlCmdIsNull() ?? string.Empty;

    public static string ArquivoContratoSqlDiff(string text) => ArquivoContrato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ArquivoContratoSqlLike(string text) => ArquivoContrato.SqlCmdTextLike(text) ?? string.Empty;
    public static string ArquivoContratoSqlLikeInit(string text) => ArquivoContrato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ArquivoContratoSqlLikeSpaces(string? text) => ArquivoContrato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TextoContratoSql(string text) => TextoContrato.SqlCmdTextIgual(text) ?? string.Empty;
    public static string TextoContratoSqlNotIsNull => TextoContrato.SqlCmdNotIsNull() ?? string.Empty;
    public static string TextoContratoSqlIsNull => TextoContrato.SqlCmdIsNull() ?? string.Empty;

    public static string TextoContratoSqlDiff(string text) => TextoContrato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string TextoContratoSqlLike(string text) => TextoContrato.SqlCmdTextLike(text) ?? string.Empty;
    public static string TextoContratoSqlLikeInit(string text) => TextoContrato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string TextoContratoSqlLikeSpaces(string? text) => TextoContrato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObservacaoSql(string text) => Observacao.SqlCmdTextIgual(text, 2048) ?? string.Empty;
    public static string ObservacaoSqlNotIsNull => Observacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacaoSqlIsNull => Observacao.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacaoSqlDiff(string text) => Observacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacaoSqlLike(string text) => Observacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacaoSqlLikeInit(string text) => Observacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacaoSqlLikeSpaces(string? text) => Observacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DataContratoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataContrato}]");
    public static string DataContratoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataContrato}]");
    public static string DataContratoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataContrato}]");
    public static string DataContratoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataContrato}]");
    public static string DataContratoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataContrato}]");
    public static string DataContratoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataContrato}]");
    public static string DataContratoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataContrato}]");
    public static string DataContratoIsNull => DataContrato.SqlCmdIsNull() ?? string.Empty;
    public static string DataContratoNotIsNull => DataContrato.SqlCmdNotIsNull() ?? string.Empty;

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
        HdcCliente = 1,
        HdcFixo = 2,
        HdcVariavel = 3,
        HdcPercSucesso = 4,
        HdcProcesso = 5,
        HdcArquivoContrato = 6,
        HdcTextoContrato = 7,
        HdcValorFixo = 8,
        HdcObservacao = 9,
        HdcDataContrato = 10,
        HdcGUID = 11,
        HdcQuemCad = 12,
        HdcDtCad = 13,
        HdcQuemAtu = 14,
        HdcDtAtu = 15,
        HdcVisto = 16
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.HdcCliente => HdcCliente,
        NomesCamposTabela.HdcFixo => HdcFixo,
        NomesCamposTabela.HdcVariavel => HdcVariavel,
        NomesCamposTabela.HdcPercSucesso => HdcPercSucesso,
        NomesCamposTabela.HdcProcesso => HdcProcesso,
        NomesCamposTabela.HdcArquivoContrato => HdcArquivoContrato,
        NomesCamposTabela.HdcTextoContrato => HdcTextoContrato,
        NomesCamposTabela.HdcValorFixo => HdcValorFixo,
        NomesCamposTabela.HdcObservacao => HdcObservacao,
        NomesCamposTabela.HdcDataContrato => HdcDataContrato,
        NomesCamposTabela.HdcGUID => HdcGUID,
        NomesCamposTabela.HdcQuemCad => HdcQuemCad,
        NomesCamposTabela.HdcDtCad => HdcDtCad,
        NomesCamposTabela.HdcQuemAtu => HdcQuemAtu,
        NomesCamposTabela.HdcDtAtu => HdcDtAtu,
        NomesCamposTabela.HdcVisto => HdcVisto,
        _ => null
    };
}