using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBContaCorrenteDicInfo
{
    public const string CampoCodigo = "ctoCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "cto";
    public const string CIAcordo = "ctoCIAcordo"; // LOCALIZACAO 170523
    public const string Quitado = "ctoQuitado"; // LOCALIZACAO 170523
    public const string IDContrato = "ctoIDContrato"; // LOCALIZACAO 170523
    public const string QuitadoID = "ctoQuitadoID"; // LOCALIZACAO 170523
    public const string DebitoID = "ctoDebitoID"; // LOCALIZACAO 170523
    public const string LivroCaixaID = "ctoLivroCaixaID"; // LOCALIZACAO 170523
    public const string Sucumbencia = "ctoSucumbencia"; // LOCALIZACAO 170523
    public const string DistRegra = "ctoDistRegra"; // LOCALIZACAO 170523
    public const string DtOriginal = "ctoDtOriginal"; // LOCALIZACAO 170523
    public const string Processo = "ctoProcesso"; // LOCALIZACAO 170523
    public const string ParcelaX = "ctoParcelaX"; // LOCALIZACAO 170523
    public const string Valor = "ctoValor"; // LOCALIZACAO 170523
    public const string Data = "ctoData"; // LOCALIZACAO 170523
    public const string Cliente = "ctoCliente"; // LOCALIZACAO 170523
    public const string Historico = "ctoHistorico"; // LOCALIZACAO 170523
    public const string Contrato = "ctoContrato"; // LOCALIZACAO 170523
    public const string Pago = "ctoPago"; // LOCALIZACAO 170523
    public const string Distribuir = "ctoDistribuir"; // LOCALIZACAO 170523
    public const string LC = "ctoLC"; // LOCALIZACAO 170523
    public const string IDHTrab = "ctoIDHTrab"; // LOCALIZACAO 170523
    public const string NroParcelas = "ctoNroParcelas"; // LOCALIZACAO 170523
    public const string ValorPrincipal = "ctoValorPrincipal"; // LOCALIZACAO 170523
    public const string ParcelaPrincipalID = "ctoParcelaPrincipalID"; // LOCALIZACAO 170523
    public const string Hide = "ctoHide"; // LOCALIZACAO 170523
    public const string DataPgto = "ctoDataPgto"; // LOCALIZACAO 170523
    public const string GUID = "ctoGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ctoQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ctoDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ctoQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ctoDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ctoVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => CIAcordo,
        2 => Quitado,
        3 => IDContrato,
        4 => QuitadoID,
        5 => DebitoID,
        6 => LivroCaixaID,
        7 => Sucumbencia,
        8 => DistRegra,
        9 => DtOriginal,
        10 => Processo,
        11 => ParcelaX,
        12 => Valor,
        13 => Data,
        14 => Cliente,
        15 => Historico,
        16 => Contrato,
        17 => Pago,
        18 => Distribuir,
        19 => LC,
        20 => IDHTrab,
        21 => NroParcelas,
        22 => ValorPrincipal,
        23 => ParcelaPrincipalID,
        24 => Hide,
        25 => DataPgto,
        26 => GUID,
        27 => QuemCad,
        28 => DtCad,
        29 => QuemAtu,
        30 => DtAtu,
        31 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ContaCorrente";
#region PropriedadesDaTabela
    public static DBInfoSystem CtoCIAcordo => new(0, PTabelaNome, CampoCodigo, CIAcordo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoQuitado => new(0, PTabelaNome, CampoCodigo, Quitado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoIDContrato => new(0, PTabelaNome, CampoCodigo, IDContrato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoQuitadoID => new(0, PTabelaNome, CampoCodigo, QuitadoID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoDebitoID => new(0, PTabelaNome, CampoCodigo, DebitoID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoLivroCaixaID => new(0, PTabelaNome, CampoCodigo, LivroCaixaID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoSucumbencia => new(0, PTabelaNome, CampoCodigo, Sucumbencia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoDistRegra => new(0, PTabelaNome, CampoCodigo, DistRegra, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoDtOriginal => new(0, PTabelaNome, CampoCodigo, DtOriginal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "cto"
    }; // DBI 11 
    public static DBInfoSystem CtoParcelaX => new(0, PTabelaNome, CampoCodigo, ParcelaX, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "cto"
    }; // DBI 11 
    public static DBInfoSystem CtoHistorico => new(0, PTabelaNome, CampoCodigo, Historico, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoContrato => new(0, PTabelaNome, CampoCodigo, Contrato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoPago => new(0, PTabelaNome, CampoCodigo, Pago, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoDistribuir => new(0, PTabelaNome, CampoCodigo, Distribuir, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoLC => new(0, PTabelaNome, CampoCodigo, LC, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoIDHTrab => new(0, PTabelaNome, CampoCodigo, IDHTrab, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoNroParcelas => new(0, PTabelaNome, CampoCodigo, NroParcelas, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoValorPrincipal => new(0, PTabelaNome, CampoCodigo, ValorPrincipal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoParcelaPrincipalID => new(0, PTabelaNome, CampoCodigo, ParcelaPrincipalID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoHide => new(0, PTabelaNome, CampoCodigo, Hide, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoDataPgto => new(0, PTabelaNome, CampoCodigo, DataPgto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "cto"
    }; // DBI 11 
    public static DBInfoSystem CtoDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "cto"
    }; // DBI 11 
    public static DBInfoSystem CtoDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "cto"
    };
    public static DBInfoSystem CtoVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "cto"
    };

#endregion
#region SMART_SQLServices 
    public static string QuitadoSql(bool valueCheck) => Quitado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string QuitadoSqlSim => Quitado.SqlCmdBoolSim() ?? string.Empty;
    public static string QuitadoSqlNao => Quitado.SqlCmdBoolNao() ?? string.Empty;

    public static string SucumbenciaSql(bool valueCheck) => Sucumbencia.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SucumbenciaSqlSim => Sucumbencia.SqlCmdBoolSim() ?? string.Empty;
    public static string SucumbenciaSqlNao => Sucumbencia.SqlCmdBoolNao() ?? string.Empty;

    public static string DistRegraSql(bool valueCheck) => DistRegra.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string DistRegraSqlSim => DistRegra.SqlCmdBoolSim() ?? string.Empty;
    public static string DistRegraSqlNao => DistRegra.SqlCmdBoolNao() ?? string.Empty;

    public static string DtOriginalSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtOriginal}]");
    public static string DtOriginalSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtOriginal}]");
    public static string DtOriginalSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtOriginal}]");
    public static string DtOriginalSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtOriginal}]");
    public static string DtOriginalSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtOriginal}]");
    public static string DtOriginalSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtOriginal}]");
    public static string DtOriginalSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtOriginal}]");
    public static string DtOriginalSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtOriginal}]");
    public static string DtOriginalSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtOriginal}]");
    public static string DtOriginalSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtOriginal}]");
    public static string DtOriginalSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtOriginal}]");
    public static string DtOriginalSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtOriginal}]");
    public static string DtOriginalIsNull => DtOriginal.SqlCmdIsNull() ?? string.Empty;
    public static string DtOriginalNotIsNull => DtOriginal.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string HistoricoSql(string text) => Historico.SqlCmdTextIgual(text) ?? string.Empty;
    public static string HistoricoSqlNotIsNull => Historico.SqlCmdNotIsNull() ?? string.Empty;
    public static string HistoricoSqlIsNull => Historico.SqlCmdIsNull() ?? string.Empty;

    public static string HistoricoSqlDiff(string text) => Historico.SqlCmdTextDiff(text) ?? string.Empty;
    public static string HistoricoSqlLike(string text) => Historico.SqlCmdTextLike(text) ?? string.Empty;
    public static string HistoricoSqlLikeInit(string text) => Historico.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string HistoricoSqlLikeSpaces(string? text) => Historico.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ContratoSql(bool valueCheck) => Contrato.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ContratoSqlSim => Contrato.SqlCmdBoolSim() ?? string.Empty;
    public static string ContratoSqlNao => Contrato.SqlCmdBoolNao() ?? string.Empty;

    public static string PagoSql(bool valueCheck) => Pago.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string PagoSqlSim => Pago.SqlCmdBoolSim() ?? string.Empty;
    public static string PagoSqlNao => Pago.SqlCmdBoolNao() ?? string.Empty;

    public static string DistribuirSql(bool valueCheck) => Distribuir.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string DistribuirSqlSim => Distribuir.SqlCmdBoolSim() ?? string.Empty;
    public static string DistribuirSqlNao => Distribuir.SqlCmdBoolNao() ?? string.Empty;

    public static string LCSql(bool valueCheck) => LC.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LCSqlSim => LC.SqlCmdBoolSim() ?? string.Empty;
    public static string LCSqlNao => LC.SqlCmdBoolNao() ?? string.Empty;

    public static string HideSql(bool valueCheck) => Hide.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string HideSqlSim => Hide.SqlCmdBoolSim() ?? string.Empty;
    public static string HideSqlNao => Hide.SqlCmdBoolNao() ?? string.Empty;

    public static string DataPgtoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataPgto}]");
    public static string DataPgtoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataPgto}]");
    public static string DataPgtoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataPgto}]");
    public static string DataPgtoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataPgto}]");
    public static string DataPgtoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataPgto}]");
    public static string DataPgtoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataPgto}]");
    public static string DataPgtoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataPgto}]");
    public static string DataPgtoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataPgto}]");
    public static string DataPgtoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataPgto}]");
    public static string DataPgtoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataPgto}]");
    public static string DataPgtoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataPgto}]");
    public static string DataPgtoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataPgto}]");
    public static string DataPgtoIsNull => DataPgto.SqlCmdIsNull() ?? string.Empty;
    public static string DataPgtoNotIsNull => DataPgto.SqlCmdNotIsNull() ?? string.Empty;

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
        CtoCIAcordo = 1,
        CtoQuitado = 2,
        CtoIDContrato = 3,
        CtoQuitadoID = 4,
        CtoDebitoID = 5,
        CtoLivroCaixaID = 6,
        CtoSucumbencia = 7,
        CtoDistRegra = 8,
        CtoDtOriginal = 9,
        CtoProcesso = 10,
        CtoParcelaX = 11,
        CtoValor = 12,
        CtoData = 13,
        CtoCliente = 14,
        CtoHistorico = 15,
        CtoContrato = 16,
        CtoPago = 17,
        CtoDistribuir = 18,
        CtoLC = 19,
        CtoIDHTrab = 20,
        CtoNroParcelas = 21,
        CtoValorPrincipal = 22,
        CtoParcelaPrincipalID = 23,
        CtoHide = 24,
        CtoDataPgto = 25,
        CtoGUID = 26,
        CtoQuemCad = 27,
        CtoDtCad = 28,
        CtoQuemAtu = 29,
        CtoDtAtu = 30,
        CtoVisto = 31
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CtoCIAcordo => CtoCIAcordo,
        NomesCamposTabela.CtoQuitado => CtoQuitado,
        NomesCamposTabela.CtoIDContrato => CtoIDContrato,
        NomesCamposTabela.CtoQuitadoID => CtoQuitadoID,
        NomesCamposTabela.CtoDebitoID => CtoDebitoID,
        NomesCamposTabela.CtoLivroCaixaID => CtoLivroCaixaID,
        NomesCamposTabela.CtoSucumbencia => CtoSucumbencia,
        NomesCamposTabela.CtoDistRegra => CtoDistRegra,
        NomesCamposTabela.CtoDtOriginal => CtoDtOriginal,
        NomesCamposTabela.CtoProcesso => CtoProcesso,
        NomesCamposTabela.CtoParcelaX => CtoParcelaX,
        NomesCamposTabela.CtoValor => CtoValor,
        NomesCamposTabela.CtoData => CtoData,
        NomesCamposTabela.CtoCliente => CtoCliente,
        NomesCamposTabela.CtoHistorico => CtoHistorico,
        NomesCamposTabela.CtoContrato => CtoContrato,
        NomesCamposTabela.CtoPago => CtoPago,
        NomesCamposTabela.CtoDistribuir => CtoDistribuir,
        NomesCamposTabela.CtoLC => CtoLC,
        NomesCamposTabela.CtoIDHTrab => CtoIDHTrab,
        NomesCamposTabela.CtoNroParcelas => CtoNroParcelas,
        NomesCamposTabela.CtoValorPrincipal => CtoValorPrincipal,
        NomesCamposTabela.CtoParcelaPrincipalID => CtoParcelaPrincipalID,
        NomesCamposTabela.CtoHide => CtoHide,
        NomesCamposTabela.CtoDataPgto => CtoDataPgto,
        NomesCamposTabela.CtoGUID => CtoGUID,
        NomesCamposTabela.CtoQuemCad => CtoQuemCad,
        NomesCamposTabela.CtoDtCad => CtoDtCad,
        NomesCamposTabela.CtoQuemAtu => CtoQuemAtu,
        NomesCamposTabela.CtoDtAtu => CtoDtAtu,
        NomesCamposTabela.CtoVisto => CtoVisto,
        _ => null
    };
}