using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBProDespesasDicInfo
{
    public const string CampoCodigo = "desCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "des";
    public const string LigacaoID = "desLigacaoID"; // LOCALIZACAO 170523
    public const string Cliente = "desCliente"; // LOCALIZACAO 170523
    public const string Corrigido = "desCorrigido"; // LOCALIZACAO 170523
    public const string Data = "desData"; // LOCALIZACAO 170523
    public const string ValorOriginal = "desValorOriginal"; // LOCALIZACAO 170523
    public const string Processo = "desProcesso"; // LOCALIZACAO 170523
    public const string Quitado = "desQuitado"; // LOCALIZACAO 170523
    public const string DataCorrecao = "desDataCorrecao"; // LOCALIZACAO 170523
    public const string Valor = "desValor"; // LOCALIZACAO 170523
    public const string Tipo = "desTipo"; // LOCALIZACAO 170523
    public const string Historico = "desHistorico"; // LOCALIZACAO 170523
    public const string LivroCaixa = "desLivroCaixa"; // LOCALIZACAO 170523
    public const string GUID = "desGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "desQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "desDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "desQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "desDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "desVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => LigacaoID,
        2 => Cliente,
        3 => Corrigido,
        4 => Data,
        5 => ValorOriginal,
        6 => Processo,
        7 => Quitado,
        8 => DataCorrecao,
        9 => Valor,
        10 => Tipo,
        11 => Historico,
        12 => LivroCaixa,
        13 => GUID,
        14 => QuemCad,
        15 => DtCad,
        16 => QuemAtu,
        17 => DtAtu,
        18 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProDespesas";
#region PropriedadesDaTabela
    public static DBInfoSystem DesLigacaoID => new(0, PTabelaNome, CampoCodigo, LigacaoID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem DesCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem DesCorrigido => new(0, PTabelaNome, CampoCodigo, Corrigido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem DesData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem DesValorOriginal => new(0, PTabelaNome, CampoCodigo, ValorOriginal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem DesProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem DesQuitado => new(0, PTabelaNome, CampoCodigo, Quitado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem DesDataCorrecao => new(0, PTabelaNome, CampoCodigo, DataCorrecao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem DesValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem DesTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa);
    public static DBInfoSystem DesHistorico => new(0, PTabelaNome, CampoCodigo, Historico, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem DesLivroCaixa => new(0, PTabelaNome, CampoCodigo, LivroCaixa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem DesGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem DesQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem DesDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem DesQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem DesDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem DesVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string CorrigidoSql(bool valueCheck) => Corrigido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string CorrigidoSqlSim => Corrigido.SqlCmdBoolSim() ?? string.Empty;
    public static string CorrigidoSqlNao => Corrigido.SqlCmdBoolNao() ?? string.Empty;

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

    public static string DataCorrecaoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataCorrecao}]");
    public static string DataCorrecaoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataCorrecao}]");
    public static string DataCorrecaoIsNull => DataCorrecao.SqlCmdIsNull() ?? string.Empty;
    public static string DataCorrecaoNotIsNull => DataCorrecao.SqlCmdNotIsNull() ?? string.Empty;

    public static string TipoSql(bool valueCheck) => Tipo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TipoSqlSim => Tipo.SqlCmdBoolSim() ?? string.Empty;
    public static string TipoSqlNao => Tipo.SqlCmdBoolNao() ?? string.Empty;

    public static string HistoricoSql(string text) => Historico.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string HistoricoSqlNotIsNull => Historico.SqlCmdNotIsNull() ?? string.Empty;
    public static string HistoricoSqlIsNull => Historico.SqlCmdIsNull() ?? string.Empty;

    public static string HistoricoSqlDiff(string text) => Historico.SqlCmdTextDiff(text) ?? string.Empty;
    public static string HistoricoSqlLike(string text) => Historico.SqlCmdTextLike(text) ?? string.Empty;
    public static string HistoricoSqlLikeInit(string text) => Historico.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string HistoricoSqlLikeSpaces(string? text) => Historico.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string LivroCaixaSql(bool valueCheck) => LivroCaixa.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LivroCaixaSqlSim => LivroCaixa.SqlCmdBoolSim() ?? string.Empty;
    public static string LivroCaixaSqlNao => LivroCaixa.SqlCmdBoolNao() ?? string.Empty;

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
        DesLigacaoID = 1,
        DesCliente = 2,
        DesCorrigido = 3,
        DesData = 4,
        DesValorOriginal = 5,
        DesProcesso = 6,
        DesQuitado = 7,
        DesDataCorrecao = 8,
        DesValor = 9,
        DesTipo = 10,
        DesHistorico = 11,
        DesLivroCaixa = 12,
        DesGUID = 13,
        DesQuemCad = 14,
        DesDtCad = 15,
        DesQuemAtu = 16,
        DesDtAtu = 17,
        DesVisto = 18
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.DesLigacaoID => DesLigacaoID,
        NomesCamposTabela.DesCliente => DesCliente,
        NomesCamposTabela.DesCorrigido => DesCorrigido,
        NomesCamposTabela.DesData => DesData,
        NomesCamposTabela.DesValorOriginal => DesValorOriginal,
        NomesCamposTabela.DesProcesso => DesProcesso,
        NomesCamposTabela.DesQuitado => DesQuitado,
        NomesCamposTabela.DesDataCorrecao => DesDataCorrecao,
        NomesCamposTabela.DesValor => DesValor,
        NomesCamposTabela.DesTipo => DesTipo,
        NomesCamposTabela.DesHistorico => DesHistorico,
        NomesCamposTabela.DesLivroCaixa => DesLivroCaixa,
        NomesCamposTabela.DesGUID => DesGUID,
        NomesCamposTabela.DesQuemCad => DesQuemCad,
        NomesCamposTabela.DesDtCad => DesDtCad,
        NomesCamposTabela.DesQuemAtu => DesQuemAtu,
        NomesCamposTabela.DesDtAtu => DesDtAtu,
        NomesCamposTabela.DesVisto => DesVisto,
        _ => null
    };
}