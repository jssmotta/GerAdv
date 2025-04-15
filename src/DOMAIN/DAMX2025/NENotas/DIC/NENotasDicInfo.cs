using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBNENotasDicInfo
{
    public const string CampoCodigo = "nepCodigo";
    public const string CampoNome = "nepNome";
    public const string TablePrefix = "nep";
    public const string Apenso = "nepApenso"; // LOCALIZACAO 170523
    public const string Precatoria = "nepPrecatoria"; // LOCALIZACAO 170523
    public const string Instancia = "nepInstancia"; // LOCALIZACAO 170523
    public const string MovPro = "nepMovPro"; // LOCALIZACAO 170523
    public const string Nome = "nepNome"; // LOCALIZACAO 170523
    public const string NotaExpedida = "nepNotaExpedida"; // LOCALIZACAO 170523
    public const string Revisada = "nepRevisada"; // LOCALIZACAO 170523
    public const string Processo = "nepProcesso"; // LOCALIZACAO 170523
    public const string PalavraChave = "nepPalavraChave"; // LOCALIZACAO 170523
    public const string Data = "nepData"; // LOCALIZACAO 170523
    public const string NotaPublicada = "nepNotaPublicada"; // LOCALIZACAO 170523
    public const string QuemCad = "nepQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "nepDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "nepQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "nepDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "nepVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Apenso,
        2 => Precatoria,
        3 => Instancia,
        4 => MovPro,
        5 => Nome,
        6 => NotaExpedida,
        7 => Revisada,
        8 => Processo,
        9 => PalavraChave,
        10 => Data,
        11 => NotaPublicada,
        12 => QuemCad,
        13 => DtCad,
        14 => QuemAtu,
        15 => DtAtu,
        16 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "NENotas";
#region PropriedadesDaTabela
    public static DBInfoSystem NepApenso => new(0, PTabelaNome, CampoCodigo, Apenso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBApensoDicInfo.CampoCodigo, DBApensoDicInfo.TabelaNome, new DBApensoODicInfo(), false); // DBI 11 
    public static DBInfoSystem NepPrecatoria => new(0, PTabelaNome, CampoCodigo, Precatoria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPrecatoriaDicInfo.CampoCodigo, DBPrecatoriaDicInfo.TabelaNome, new DBPrecatoriaODicInfo(), false); // DBI 11 
    public static DBInfoSystem NepInstancia => new(0, PTabelaNome, CampoCodigo, Instancia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBInstanciaDicInfo.CampoCodigo, DBInstanciaDicInfo.TabelaNome, new DBInstanciaODicInfo(), false); // DBI 11 
    public static DBInfoSystem NepMovPro => new(0, PTabelaNome, CampoCodigo, MovPro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem NepNome => new(0, PTabelaNome, CampoCodigo, Nome, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem NepNotaExpedida => new(0, PTabelaNome, CampoCodigo, NotaExpedida, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem NepRevisada => new(0, PTabelaNome, CampoCodigo, Revisada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem NepProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem NepPalavraChave => new(0, PTabelaNome, CampoCodigo, PalavraChave, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem NepData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem NepNotaPublicada => new(0, PTabelaNome, CampoCodigo, NotaPublicada, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem NepQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem NepDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem NepQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem NepDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem NepVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string ApensoDiff(int id) => Apenso.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ApensoSql(int id) => Apenso.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ApensoIsNull => Apenso.SqlCmdIsNull() ?? string.Empty;
    public static string ApensoNotIsNull => Apenso.SqlCmdNotIsNull() ?? string.Empty;

    public static string PrecatoriaDiff(int id) => Precatoria.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string PrecatoriaSql(int id) => Precatoria.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string PrecatoriaIsNull => Precatoria.SqlCmdIsNull() ?? string.Empty;
    public static string PrecatoriaNotIsNull => Precatoria.SqlCmdNotIsNull() ?? string.Empty;

    public static string InstanciaDiff(int id) => Instancia.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string InstanciaSql(int id) => Instancia.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string InstanciaIsNull => Instancia.SqlCmdIsNull() ?? string.Empty;
    public static string InstanciaNotIsNull => Instancia.SqlCmdNotIsNull() ?? string.Empty;

    public static string MovProSql(bool valueCheck) => MovPro.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string MovProSqlSim => MovPro.SqlCmdBoolSim() ?? string.Empty;
    public static string MovProSqlNao => MovPro.SqlCmdBoolNao() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NotaExpedidaSql(bool valueCheck) => NotaExpedida.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string NotaExpedidaSqlSim => NotaExpedida.SqlCmdBoolSim() ?? string.Empty;
    public static string NotaExpedidaSqlNao => NotaExpedida.SqlCmdBoolNao() ?? string.Empty;

    public static string RevisadaSql(bool valueCheck) => Revisada.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string RevisadaSqlSim => Revisada.SqlCmdBoolSim() ?? string.Empty;
    public static string RevisadaSqlNao => Revisada.SqlCmdBoolNao() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string PalavraChaveDiff(int id) => PalavraChave.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string PalavraChaveSql(int id) => PalavraChave.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string PalavraChaveIsNull => PalavraChave.SqlCmdIsNull() ?? string.Empty;
    public static string PalavraChaveNotIsNull => PalavraChave.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string NotaPublicadaSql(string text) => NotaPublicada.SqlCmdTextIgual(text) ?? string.Empty;
    public static string NotaPublicadaSqlNotIsNull => NotaPublicada.SqlCmdNotIsNull() ?? string.Empty;
    public static string NotaPublicadaSqlIsNull => NotaPublicada.SqlCmdIsNull() ?? string.Empty;

    public static string NotaPublicadaSqlDiff(string text) => NotaPublicada.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NotaPublicadaSqlLike(string text) => NotaPublicada.SqlCmdTextLike(text) ?? string.Empty;
    public static string NotaPublicadaSqlLikeInit(string text) => NotaPublicada.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NotaPublicadaSqlLikeSpaces(string? text) => NotaPublicada.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        NepApenso = 1,
        NepPrecatoria = 2,
        NepInstancia = 3,
        NepMovPro = 4,
        NepNome = 5,
        NepNotaExpedida = 6,
        NepRevisada = 7,
        NepProcesso = 8,
        NepPalavraChave = 9,
        NepData = 10,
        NepNotaPublicada = 11,
        NepQuemCad = 12,
        NepDtCad = 13,
        NepQuemAtu = 14,
        NepDtAtu = 15,
        NepVisto = 16
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.NepApenso => NepApenso,
        NomesCamposTabela.NepPrecatoria => NepPrecatoria,
        NomesCamposTabela.NepInstancia => NepInstancia,
        NomesCamposTabela.NepMovPro => NepMovPro,
        NomesCamposTabela.NepNome => NepNome,
        NomesCamposTabela.NepNotaExpedida => NepNotaExpedida,
        NomesCamposTabela.NepRevisada => NepRevisada,
        NomesCamposTabela.NepProcesso => NepProcesso,
        NomesCamposTabela.NepPalavraChave => NepPalavraChave,
        NomesCamposTabela.NepData => NepData,
        NomesCamposTabela.NepNotaPublicada => NepNotaPublicada,
        NomesCamposTabela.NepQuemCad => NepQuemCad,
        NomesCamposTabela.NepDtCad => NepDtCad,
        NomesCamposTabela.NepQuemAtu => NepQuemAtu,
        NomesCamposTabela.NepDtAtu => NepDtAtu,
        NomesCamposTabela.NepVisto => NepVisto,
        _ => null
    };
}