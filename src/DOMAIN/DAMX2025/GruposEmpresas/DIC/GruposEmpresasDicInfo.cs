using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBGruposEmpresasDicInfo
{
    public const string CampoCodigo = "grpCodigo";
    public const string CampoNome = "grpDescricao";
    public const string TablePrefix = "grp";
    public const string EMail = "grpEMail"; // LOCALIZACAO 170523
    public const string Inativo = "grpInativo"; // LOCALIZACAO 170523
    public const string Oponente = "grpOponente"; // LOCALIZACAO 170523
    public const string Descricao = "grpDescricao"; // LOCALIZACAO 170523
    public const string Observacoes = "grpObservacoes"; // LOCALIZACAO 170523
    public const string Cliente = "grpCliente"; // LOCALIZACAO 170523
    public const string Icone = "grpIcone"; // LOCALIZACAO 170523
    public const string DespesaUnificada = "grpDespesaUnificada"; // LOCALIZACAO 170523
    public const string GUID = "grpGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "grpQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "grpDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "grpQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "grpDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "grpVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => EMail,
        2 => Inativo,
        3 => Oponente,
        4 => Descricao,
        5 => Observacoes,
        6 => Cliente,
        7 => Icone,
        8 => DespesaUnificada,
        9 => GUID,
        10 => QuemCad,
        11 => DtCad,
        12 => QuemAtu,
        13 => DtAtu,
        14 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "GruposEmpresas";
#region PropriedadesDaTabela
    public static DBInfoSystem GrpEMail => new(0, PTabelaNome, CampoCodigo, EMail, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem GrpInativo => new(0, PTabelaNome, CampoCodigo, Inativo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem GrpOponente => new(0, PTabelaNome, CampoCodigo, Oponente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOponentesDicInfo.CampoCodigo, DBOponentesDicInfo.TabelaNome, new DBOponentesODicInfo(), false); // DBI 11 
    public static DBInfoSystem GrpDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem GrpObservacoes => new(0, PTabelaNome, CampoCodigo, Observacoes, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem GrpCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem GrpIcone => new(0, PTabelaNome, CampoCodigo, Icone, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem GrpDespesaUnificada => new(0, PTabelaNome, CampoCodigo, DespesaUnificada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem GrpGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem GrpQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem GrpDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem GrpQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem GrpDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem GrpVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string InativoSql(bool valueCheck) => Inativo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string InativoSqlSim => Inativo.SqlCmdBoolSim() ?? string.Empty;
    public static string InativoSqlNao => Inativo.SqlCmdBoolNao() ?? string.Empty;

    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObservacoesSql(string text) => Observacoes.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacoesSqlNotIsNull => Observacoes.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacoesSqlIsNull => Observacoes.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacoesSqlDiff(string text) => Observacoes.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacoesSqlLike(string text) => Observacoes.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacoesSqlLikeInit(string text) => Observacoes.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacoesSqlLikeSpaces(string? text) => Observacoes.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string IconeSql(string text) => Icone.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string IconeSqlNotIsNull => Icone.SqlCmdNotIsNull() ?? string.Empty;
    public static string IconeSqlIsNull => Icone.SqlCmdIsNull() ?? string.Empty;

    public static string IconeSqlDiff(string text) => Icone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string IconeSqlLike(string text) => Icone.SqlCmdTextLike(text) ?? string.Empty;
    public static string IconeSqlLikeInit(string text) => Icone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string IconeSqlLikeSpaces(string? text) => Icone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DespesaUnificadaSql(bool valueCheck) => DespesaUnificada.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string DespesaUnificadaSqlSim => DespesaUnificada.SqlCmdBoolSim() ?? string.Empty;
    public static string DespesaUnificadaSqlNao => DespesaUnificada.SqlCmdBoolNao() ?? string.Empty;

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
        GrpEMail = 1,
        GrpInativo = 2,
        GrpOponente = 3,
        GrpDescricao = 4,
        GrpObservacoes = 5,
        GrpCliente = 6,
        GrpIcone = 7,
        GrpDespesaUnificada = 8,
        GrpGUID = 9,
        GrpQuemCad = 10,
        GrpDtCad = 11,
        GrpQuemAtu = 12,
        GrpDtAtu = 13,
        GrpVisto = 14
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.GrpEMail => GrpEMail,
        NomesCamposTabela.GrpInativo => GrpInativo,
        NomesCamposTabela.GrpOponente => GrpOponente,
        NomesCamposTabela.GrpDescricao => GrpDescricao,
        NomesCamposTabela.GrpObservacoes => GrpObservacoes,
        NomesCamposTabela.GrpCliente => GrpCliente,
        NomesCamposTabela.GrpIcone => GrpIcone,
        NomesCamposTabela.GrpDespesaUnificada => GrpDespesaUnificada,
        NomesCamposTabela.GrpGUID => GrpGUID,
        NomesCamposTabela.GrpQuemCad => GrpQuemCad,
        NomesCamposTabela.GrpDtCad => GrpDtCad,
        NomesCamposTabela.GrpQuemAtu => GrpQuemAtu,
        NomesCamposTabela.GrpDtAtu => GrpDtAtu,
        NomesCamposTabela.GrpVisto => GrpVisto,
        _ => null
    };
}