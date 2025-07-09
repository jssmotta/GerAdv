using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBLivroCaixaDicInfo
{
    public const string CampoCodigo = "livCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "liv";
    public const string IDDes = "livIDDes"; // LOCALIZACAO 170523
    public const string Pessoal = "livPessoal"; // LOCALIZACAO 170523
    public const string Ajuste = "livAjuste"; // LOCALIZACAO 170523
    public const string IDHon = "livIDHon"; // LOCALIZACAO 170523
    public const string IDHonParc = "livIDHonParc"; // LOCALIZACAO 170523
    public const string IDHonSuc = "livIDHonSuc"; // LOCALIZACAO 170523
    public const string Data = "livData"; // LOCALIZACAO 170523
    public const string Processo = "livProcesso"; // LOCALIZACAO 170523
    public const string Valor = "livValor"; // LOCALIZACAO 170523
    public const string Tipo = "livTipo"; // LOCALIZACAO 170523
    public const string Historico = "livHistorico"; // LOCALIZACAO 170523
    public const string Previsto = "livPrevisto"; // LOCALIZACAO 170523
    public const string Grupo = "livGrupo"; // LOCALIZACAO 170523
    public const string QuemCad = "livQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "livDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "livQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "livDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "livVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => IDDes,
        2 => Pessoal,
        3 => Ajuste,
        4 => IDHon,
        5 => IDHonParc,
        6 => IDHonSuc,
        7 => Data,
        8 => Processo,
        9 => Valor,
        10 => Tipo,
        11 => Historico,
        12 => Previsto,
        13 => Grupo,
        14 => QuemCad,
        15 => DtCad,
        16 => QuemAtu,
        17 => DtAtu,
        18 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "LivroCaixa";
#region PropriedadesDaTabela
    public static DBInfoSystem LivIDDes => new(0, PTabelaNome, CampoCodigo, IDDes, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LivPessoal => new(0, PTabelaNome, CampoCodigo, Pessoal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LivAjuste => new(0, PTabelaNome, CampoCodigo, Ajuste, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem LivIDHon => new(0, PTabelaNome, CampoCodigo, IDHon, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LivIDHonParc => new(0, PTabelaNome, CampoCodigo, IDHonParc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LivIDHonSuc => new(0, PTabelaNome, CampoCodigo, IDHonSuc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem LivData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem LivProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem LivValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem LivTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa);
    public static DBInfoSystem LivHistorico => new(0, PTabelaNome, CampoCodigo, Historico, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem LivPrevisto => new(0, PTabelaNome, CampoCodigo, Previsto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem LivGrupo => new(0, PTabelaNome, CampoCodigo, Grupo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem LivQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem LivDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem LivQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem LivDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem LivVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string AjusteSql(bool valueCheck) => Ajuste.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AjusteSqlSim => Ajuste.SqlCmdBoolSim() ?? string.Empty;
    public static string AjusteSqlNao => Ajuste.SqlCmdBoolNao() ?? string.Empty;

    public static string IDHonSucSql(bool valueCheck) => IDHonSuc.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IDHonSucSqlSim => IDHonSuc.SqlCmdBoolSim() ?? string.Empty;
    public static string IDHonSucSqlNao => IDHonSuc.SqlCmdBoolNao() ?? string.Empty;

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

    public static string TipoSql(bool valueCheck) => Tipo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TipoSqlSim => Tipo.SqlCmdBoolSim() ?? string.Empty;
    public static string TipoSqlNao => Tipo.SqlCmdBoolNao() ?? string.Empty;

    public static string HistoricoSql(string text) => Historico.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string HistoricoSqlNotIsNull => Historico.SqlCmdNotIsNull() ?? string.Empty;
    public static string HistoricoSqlIsNull => Historico.SqlCmdIsNull() ?? string.Empty;

    public static string HistoricoSqlDiff(string text) => Historico.SqlCmdTextDiff(text) ?? string.Empty;
    public static string HistoricoSqlLike(string text) => Historico.SqlCmdTextLike(text) ?? string.Empty;
    public static string HistoricoSqlLikeInit(string text) => Historico.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string HistoricoSqlLikeSpaces(string? text) => Historico.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PrevistoSql(bool valueCheck) => Previsto.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string PrevistoSqlSim => Previsto.SqlCmdBoolSim() ?? string.Empty;
    public static string PrevistoSqlNao => Previsto.SqlCmdBoolNao() ?? string.Empty;

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
        LivIDDes = 1,
        LivPessoal = 2,
        LivAjuste = 3,
        LivIDHon = 4,
        LivIDHonParc = 5,
        LivIDHonSuc = 6,
        LivData = 7,
        LivProcesso = 8,
        LivValor = 9,
        LivTipo = 10,
        LivHistorico = 11,
        LivPrevisto = 12,
        LivGrupo = 13,
        LivQuemCad = 14,
        LivDtCad = 15,
        LivQuemAtu = 16,
        LivDtAtu = 17,
        LivVisto = 18
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.LivIDDes => LivIDDes,
        NomesCamposTabela.LivPessoal => LivPessoal,
        NomesCamposTabela.LivAjuste => LivAjuste,
        NomesCamposTabela.LivIDHon => LivIDHon,
        NomesCamposTabela.LivIDHonParc => LivIDHonParc,
        NomesCamposTabela.LivIDHonSuc => LivIDHonSuc,
        NomesCamposTabela.LivData => LivData,
        NomesCamposTabela.LivProcesso => LivProcesso,
        NomesCamposTabela.LivValor => LivValor,
        NomesCamposTabela.LivTipo => LivTipo,
        NomesCamposTabela.LivHistorico => LivHistorico,
        NomesCamposTabela.LivPrevisto => LivPrevisto,
        NomesCamposTabela.LivGrupo => LivGrupo,
        NomesCamposTabela.LivQuemCad => LivQuemCad,
        NomesCamposTabela.LivDtCad => LivDtCad,
        NomesCamposTabela.LivQuemAtu => LivQuemAtu,
        NomesCamposTabela.LivDtAtu => LivDtAtu,
        NomesCamposTabela.LivVisto => LivVisto,
        _ => null
    };
}