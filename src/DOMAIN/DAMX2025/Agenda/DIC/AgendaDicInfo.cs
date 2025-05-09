using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAgendaDicInfo
{
    public const string CampoCodigo = "ageCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "age";
    public const string IDCOB = "ageIDCOB"; // LOCALIZACAO 170523
    public const string ClienteAvisado = "ageClienteAvisado"; // LOCALIZACAO 170523
    public const string RevisarP2 = "ageRevisarP2"; // LOCALIZACAO 170523
    public const string IDNE = "ageIDNE"; // LOCALIZACAO 170523
    public const string Cidade = "ageCidade"; // LOCALIZACAO 170523
    public const string Oculto = "ageOculto"; // LOCALIZACAO 170523
    public const string CartaPrecatoria = "ageCartaPrecatoria"; // LOCALIZACAO 170523
    public const string Revisar = "ageRevisar"; // LOCALIZACAO 170523
    public const string HrFinal = "ageHrFinal"; // LOCALIZACAO 170523
    public const string Advogado = "ageAdvogado"; // LOCALIZACAO 170523
    public const string EventoGerador = "ageEventoGerador"; // LOCALIZACAO 170523
    public const string EventoData = "ageEventoData"; // LOCALIZACAO 170523
    public const string Funcionario = "ageFuncionario"; // LOCALIZACAO 170523
    public const string Data = "ageData"; // LOCALIZACAO 170523
    public const string EventoPrazo = "ageEventoPrazo"; // LOCALIZACAO 170523
    public const string Hora = "ageHora"; // LOCALIZACAO 170523
    public const string Compromisso = "ageCompromisso"; // LOCALIZACAO 170523
    public const string TipoCompromisso = "ageTipoCompromisso"; // LOCALIZACAO 170523
    public const string Cliente = "ageCliente"; // LOCALIZACAO 170523
    public const string Liberado = "ageLiberado"; // LOCALIZACAO 170523
    public const string Importante = "ageImportante"; // LOCALIZACAO 170523
    public const string Concluido = "ageConcluido"; // LOCALIZACAO 170523
    public const string Area = "ageArea"; // LOCALIZACAO 170523
    public const string Justica = "ageJustica"; // LOCALIZACAO 170523
    public const string Processo = "ageProcesso"; // LOCALIZACAO 170523
    public const string IDHistorico = "ageIDHistorico"; // LOCALIZACAO 170523
    public const string IDInsProcesso = "ageIDInsProcesso"; // LOCALIZACAO 170523
    public const string Usuario = "ageUsuario"; // LOCALIZACAO 170523
    public const string Preposto = "agePreposto"; // LOCALIZACAO 170523
    public const string QuemID = "ageQuemID"; // LOCALIZACAO 170523
    public const string QuemCodigo = "ageQuemCodigo"; // LOCALIZACAO 170523
    public const string Status = "ageStatus"; // LOCALIZACAO 170523
    public const string Valor = "ageValor"; // LOCALIZACAO 170523
    public const string Decisao = "ageDecisao"; // LOCALIZACAO 170523
    public const string Sempre = "ageSempre"; // LOCALIZACAO 170523
    public const string PrazoDias = "agePrazoDias"; // LOCALIZACAO 170523
    public const string ProtocoloIntegrado = "ageProtocoloIntegrado"; // LOCALIZACAO 170523
    public const string DataInicioPrazo = "ageDataInicioPrazo"; // LOCALIZACAO 170523
    public const string UsuarioCiente = "ageUsuarioCiente"; // LOCALIZACAO 170523
    public const string GUID = "ageGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ageQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ageDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ageQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ageDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ageVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => IDCOB,
        2 => ClienteAvisado,
        3 => RevisarP2,
        4 => IDNE,
        5 => Cidade,
        6 => Oculto,
        7 => CartaPrecatoria,
        8 => Revisar,
        9 => HrFinal,
        10 => Advogado,
        11 => EventoGerador,
        12 => EventoData,
        13 => Funcionario,
        14 => Data,
        15 => EventoPrazo,
        16 => Hora,
        17 => Compromisso,
        18 => TipoCompromisso,
        19 => Cliente,
        20 => Liberado,
        21 => Importante,
        22 => Concluido,
        23 => Area,
        24 => Justica,
        25 => Processo,
        26 => IDHistorico,
        27 => IDInsProcesso,
        28 => Usuario,
        29 => Preposto,
        30 => QuemID,
        31 => QuemCodigo,
        32 => Status,
        33 => Valor,
        34 => Decisao,
        35 => Sempre,
        36 => PrazoDias,
        37 => ProtocoloIntegrado,
        38 => DataInicioPrazo,
        39 => UsuarioCiente,
        40 => GUID,
        41 => QuemCad,
        42 => DtCad,
        43 => QuemAtu,
        44 => DtAtu,
        45 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Agenda";
#region PropriedadesDaTabela
    public static DBInfoSystem AgeIDCOB => new(0, PTabelaNome, CampoCodigo, IDCOB, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeClienteAvisado => new(0, PTabelaNome, CampoCodigo, ClienteAvisado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AgeRevisarP2 => new(0, PTabelaNome, CampoCodigo, RevisarP2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AgeIDNE => new(0, PTabelaNome, CampoCodigo, IDNE, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeCidade => new(0, PTabelaNome, CampoCodigo, Cidade, Captions.PCaption_Cidade, Captions.PCaption_CidadeUFPais, ETipoDadosSysteminfo.SysteminfoForeingkeyCidade, "cidCodigo", "Cidade", new DBCidadeODicInfo(), false);
    public static DBInfoSystem AgeOculto => new(0, PTabelaNome, CampoCodigo, Oculto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeCartaPrecatoria => new(0, PTabelaNome, CampoCodigo, CartaPrecatoria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeRevisar => new(0, PTabelaNome, CampoCodigo, Revisar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AgeHrFinal => new(0, PTabelaNome, CampoCodigo, HrFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem AgeAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeEventoGerador => new(0, PTabelaNome, CampoCodigo, EventoGerador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeEventoData => new(0, PTabelaNome, CampoCodigo, EventoData, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem AgeFuncionario => new(0, PTabelaNome, CampoCodigo, Funcionario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncionariosDicInfo.CampoCodigo, DBFuncionariosDicInfo.TabelaNome, new DBFuncionariosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem AgeEventoPrazo => new(0, PTabelaNome, CampoCodigo, EventoPrazo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem AgeCompromisso => new(0, PTabelaNome, CampoCodigo, Compromisso, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem AgeTipoCompromisso => new(0, PTabelaNome, CampoCodigo, TipoCompromisso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoCompromissoDicInfo.CampoCodigo, DBTipoCompromissoDicInfo.TabelaNome, new DBTipoCompromissoODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeLiberado => new(0, PTabelaNome, CampoCodigo, Liberado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AgeImportante => new(0, PTabelaNome, CampoCodigo, Importante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AgeConcluido => new(0, PTabelaNome, CampoCodigo, Concluido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AgeArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeIDHistorico => new(0, PTabelaNome, CampoCodigo, IDHistorico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeIDInsProcesso => new(0, PTabelaNome, CampoCodigo, IDInsProcesso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeUsuario => new(0, PTabelaNome, CampoCodigo, Usuario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgePreposto => new(0, PTabelaNome, CampoCodigo, Preposto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPrepostosDicInfo.CampoCodigo, DBPrepostosDicInfo.TabelaNome, new DBPrepostosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeQuemID => new(0, PTabelaNome, CampoCodigo, QuemID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeQuemCodigo => new(0, PTabelaNome, CampoCodigo, QuemCodigo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeStatus => new(0, PTabelaNome, CampoCodigo, Status, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem AgeValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem AgeDecisao => new(0, PTabelaNome, CampoCodigo, Decisao, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem AgeSempre => new(0, PTabelaNome, CampoCodigo, Sempre, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgePrazoDias => new(0, PTabelaNome, CampoCodigo, PrazoDias, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeProtocoloIntegrado => new(0, PTabelaNome, CampoCodigo, ProtocoloIntegrado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgeDataInicioPrazo => new(0, PTabelaNome, CampoCodigo, DataInicioPrazo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem AgeUsuarioCiente => new(0, PTabelaNome, CampoCodigo, UsuarioCiente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AgeGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem AgeQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem AgeQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgeDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem AgeVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string IDCOBDiff(int id) => IDCOB.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IDCOBSql(int id) => IDCOB.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IDCOBIsNull => IDCOB.SqlCmdIsNull() ?? string.Empty;
    public static string IDCOBNotIsNull => IDCOB.SqlCmdNotIsNull() ?? string.Empty;

    public static string ClienteAvisadoSql(bool valueCheck) => ClienteAvisado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ClienteAvisadoSqlSim => ClienteAvisado.SqlCmdBoolSim() ?? string.Empty;
    public static string ClienteAvisadoSqlNao => ClienteAvisado.SqlCmdBoolNao() ?? string.Empty;

    public static string RevisarP2Sql(bool valueCheck) => RevisarP2.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string RevisarP2SqlSim => RevisarP2.SqlCmdBoolSim() ?? string.Empty;
    public static string RevisarP2SqlNao => RevisarP2.SqlCmdBoolNao() ?? string.Empty;

    public static string IDNEDiff(int id) => IDNE.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IDNESql(int id) => IDNE.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IDNEIsNull => IDNE.SqlCmdIsNull() ?? string.Empty;
    public static string IDNENotIsNull => IDNE.SqlCmdNotIsNull() ?? string.Empty;

    public static string CidadeDiff(int id) => Cidade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CidadeSql(int id) => Cidade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CidadeIsNull => Cidade.SqlCmdIsNull() ?? string.Empty;
    public static string CidadeNotIsNull => Cidade.SqlCmdNotIsNull() ?? string.Empty;

    public static string OcultoDiff(int id) => Oculto.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string OcultoSql(int id) => Oculto.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string OcultoIsNull => Oculto.SqlCmdIsNull() ?? string.Empty;
    public static string OcultoNotIsNull => Oculto.SqlCmdNotIsNull() ?? string.Empty;

    public static string CartaPrecatoriaDiff(int id) => CartaPrecatoria.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CartaPrecatoriaSql(int id) => CartaPrecatoria.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CartaPrecatoriaIsNull => CartaPrecatoria.SqlCmdIsNull() ?? string.Empty;
    public static string CartaPrecatoriaNotIsNull => CartaPrecatoria.SqlCmdNotIsNull() ?? string.Empty;

    public static string RevisarSql(bool valueCheck) => Revisar.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string RevisarSqlSim => Revisar.SqlCmdBoolSim() ?? string.Empty;
    public static string RevisarSqlNao => Revisar.SqlCmdBoolNao() ?? string.Empty;

    public static string HrFinalSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{HrFinal}]");
    public static string HrFinalSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{HrFinal}]");
    public static string HrFinalSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{HrFinal}]");
    public static string HrFinalSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{HrFinal}]");
    public static string HrFinalSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{HrFinal}]");
    public static string HrFinalSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{HrFinal}]");
    public static string HrFinalSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{HrFinal}]");
    public static string HrFinalSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{HrFinal}]");
    public static string HrFinalSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{HrFinal}]");
    public static string HrFinalSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{HrFinal}]");
    public static string HrFinalSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{HrFinal}]");
    public static string HrFinalSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{HrFinal}]");
    public static string HrFinalIsNull => HrFinal.SqlCmdIsNull() ?? string.Empty;
    public static string HrFinalNotIsNull => HrFinal.SqlCmdNotIsNull() ?? string.Empty;

    public static string AdvogadoDiff(int id) => Advogado.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AdvogadoSql(int id) => Advogado.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AdvogadoIsNull => Advogado.SqlCmdIsNull() ?? string.Empty;
    public static string AdvogadoNotIsNull => Advogado.SqlCmdNotIsNull() ?? string.Empty;

    public static string EventoGeradorDiff(int id) => EventoGerador.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string EventoGeradorSql(int id) => EventoGerador.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string EventoGeradorIsNull => EventoGerador.SqlCmdIsNull() ?? string.Empty;
    public static string EventoGeradorNotIsNull => EventoGerador.SqlCmdNotIsNull() ?? string.Empty;

    public static string EventoDataSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{EventoData}]");
    public static string EventoDataSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{EventoData}]");
    public static string EventoDataSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{EventoData}]");
    public static string EventoDataSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{EventoData}]");
    public static string EventoDataSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{EventoData}]");
    public static string EventoDataSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{EventoData}]");
    public static string EventoDataSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{EventoData}]");
    public static string EventoDataSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{EventoData}]");
    public static string EventoDataSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{EventoData}]");
    public static string EventoDataSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{EventoData}]");
    public static string EventoDataSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{EventoData}]");
    public static string EventoDataSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{EventoData}]");
    public static string EventoDataIsNull => EventoData.SqlCmdIsNull() ?? string.Empty;
    public static string EventoDataNotIsNull => EventoData.SqlCmdNotIsNull() ?? string.Empty;

    public static string FuncionarioDiff(int id) => Funcionario.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string FuncionarioSql(int id) => Funcionario.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string FuncionarioIsNull => Funcionario.SqlCmdIsNull() ?? string.Empty;
    public static string FuncionarioNotIsNull => Funcionario.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string EventoPrazoDiff(int id) => EventoPrazo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string EventoPrazoSql(int id) => EventoPrazo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string EventoPrazoIsNull => EventoPrazo.SqlCmdIsNull() ?? string.Empty;
    public static string EventoPrazoNotIsNull => EventoPrazo.SqlCmdNotIsNull() ?? string.Empty;

    public static string HoraSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Hora}]");
    public static string HoraSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Hora}]");
    public static string HoraSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Hora}]");
    public static string HoraSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Hora}]");
    public static string HoraSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Hora}]");
    public static string HoraSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Hora}]");
    public static string HoraSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Hora}]");
    public static string HoraSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Hora}]");
    public static string HoraSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Hora}]");
    public static string HoraSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Hora}]");
    public static string HoraSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Hora}]");
    public static string HoraSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Hora}]");
    public static string HoraIsNull => Hora.SqlCmdIsNull() ?? string.Empty;
    public static string HoraNotIsNull => Hora.SqlCmdNotIsNull() ?? string.Empty;

    public static string CompromissoSql(string text) => Compromisso.SqlCmdTextIgual(text) ?? string.Empty;
    public static string CompromissoSqlNotIsNull => Compromisso.SqlCmdNotIsNull() ?? string.Empty;
    public static string CompromissoSqlIsNull => Compromisso.SqlCmdIsNull() ?? string.Empty;

    public static string CompromissoSqlDiff(string text) => Compromisso.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CompromissoSqlLike(string text) => Compromisso.SqlCmdTextLike(text) ?? string.Empty;
    public static string CompromissoSqlLikeInit(string text) => Compromisso.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CompromissoSqlLikeSpaces(string? text) => Compromisso.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TipoCompromissoDiff(int id) => TipoCompromisso.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string TipoCompromissoSql(int id) => TipoCompromisso.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string TipoCompromissoIsNull => TipoCompromisso.SqlCmdIsNull() ?? string.Empty;
    public static string TipoCompromissoNotIsNull => TipoCompromisso.SqlCmdNotIsNull() ?? string.Empty;

    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

    public static string LiberadoSql(bool valueCheck) => Liberado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LiberadoSqlSim => Liberado.SqlCmdBoolSim() ?? string.Empty;
    public static string LiberadoSqlNao => Liberado.SqlCmdBoolNao() ?? string.Empty;

    public static string ImportanteSql(bool valueCheck) => Importante.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ImportanteSqlSim => Importante.SqlCmdBoolSim() ?? string.Empty;
    public static string ImportanteSqlNao => Importante.SqlCmdBoolNao() ?? string.Empty;

    public static string ConcluidoSql(bool valueCheck) => Concluido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ConcluidoSqlSim => Concluido.SqlCmdBoolSim() ?? string.Empty;
    public static string ConcluidoSqlNao => Concluido.SqlCmdBoolNao() ?? string.Empty;

    public static string AreaDiff(int id) => Area.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AreaSql(int id) => Area.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AreaIsNull => Area.SqlCmdIsNull() ?? string.Empty;
    public static string AreaNotIsNull => Area.SqlCmdNotIsNull() ?? string.Empty;

    public static string JusticaDiff(int id) => Justica.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string JusticaSql(int id) => Justica.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string JusticaIsNull => Justica.SqlCmdIsNull() ?? string.Empty;
    public static string JusticaNotIsNull => Justica.SqlCmdNotIsNull() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string IDHistoricoDiff(int id) => IDHistorico.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IDHistoricoSql(int id) => IDHistorico.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IDHistoricoIsNull => IDHistorico.SqlCmdIsNull() ?? string.Empty;
    public static string IDHistoricoNotIsNull => IDHistorico.SqlCmdNotIsNull() ?? string.Empty;

    public static string IDInsProcessoDiff(int id) => IDInsProcesso.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IDInsProcessoSql(int id) => IDInsProcesso.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IDInsProcessoIsNull => IDInsProcesso.SqlCmdIsNull() ?? string.Empty;
    public static string IDInsProcessoNotIsNull => IDInsProcesso.SqlCmdNotIsNull() ?? string.Empty;

    public static string UsuarioDiff(int id) => Usuario.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string UsuarioSql(int id) => Usuario.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string UsuarioIsNull => Usuario.SqlCmdIsNull() ?? string.Empty;
    public static string UsuarioNotIsNull => Usuario.SqlCmdNotIsNull() ?? string.Empty;

    public static string PrepostoDiff(int id) => Preposto.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string PrepostoSql(int id) => Preposto.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string PrepostoIsNull => Preposto.SqlCmdIsNull() ?? string.Empty;
    public static string PrepostoNotIsNull => Preposto.SqlCmdNotIsNull() ?? string.Empty;

    public static string QuemIDDiff(int id) => QuemID.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemIDSql(int id) => QuemID.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemIDIsNull => QuemID.SqlCmdIsNull() ?? string.Empty;
    public static string QuemIDNotIsNull => QuemID.SqlCmdNotIsNull() ?? string.Empty;

    public static string QuemCodigoDiff(int id) => QuemCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemCodigoSql(int id) => QuemCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemCodigoIsNull => QuemCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string QuemCodigoNotIsNull => QuemCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string StatusSql(string text) => Status.SqlCmdTextIgual(text) ?? string.Empty;
    public static string StatusSqlNotIsNull => Status.SqlCmdNotIsNull() ?? string.Empty;
    public static string StatusSqlIsNull => Status.SqlCmdIsNull() ?? string.Empty;

    public static string StatusSqlDiff(string text) => Status.SqlCmdTextDiff(text) ?? string.Empty;
    public static string StatusSqlLike(string text) => Status.SqlCmdTextLike(text) ?? string.Empty;
    public static string StatusSqlLikeInit(string text) => Status.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string StatusSqlLikeSpaces(string? text) => Status.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DecisaoSql(string text) => Decisao.SqlCmdTextIgual(text, 2048) ?? string.Empty;
    public static string DecisaoSqlNotIsNull => Decisao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DecisaoSqlIsNull => Decisao.SqlCmdIsNull() ?? string.Empty;

    public static string DecisaoSqlDiff(string text) => Decisao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DecisaoSqlLike(string text) => Decisao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DecisaoSqlLikeInit(string text) => Decisao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DecisaoSqlLikeSpaces(string? text) => Decisao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SempreDiff(int id) => Sempre.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string SempreSql(int id) => Sempre.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string SempreIsNull => Sempre.SqlCmdIsNull() ?? string.Empty;
    public static string SempreNotIsNull => Sempre.SqlCmdNotIsNull() ?? string.Empty;

    public static string PrazoDiasDiff(int id) => PrazoDias.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string PrazoDiasSql(int id) => PrazoDias.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string PrazoDiasIsNull => PrazoDias.SqlCmdIsNull() ?? string.Empty;
    public static string PrazoDiasNotIsNull => PrazoDias.SqlCmdNotIsNull() ?? string.Empty;

    public static string ProtocoloIntegradoDiff(int id) => ProtocoloIntegrado.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProtocoloIntegradoSql(int id) => ProtocoloIntegrado.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProtocoloIntegradoIsNull => ProtocoloIntegrado.SqlCmdIsNull() ?? string.Empty;
    public static string ProtocoloIntegradoNotIsNull => ProtocoloIntegrado.SqlCmdNotIsNull() ?? string.Empty;

    public static string DataInicioPrazoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataInicioPrazo}]");
    public static string DataInicioPrazoIsNull => DataInicioPrazo.SqlCmdIsNull() ?? string.Empty;
    public static string DataInicioPrazoNotIsNull => DataInicioPrazo.SqlCmdNotIsNull() ?? string.Empty;

    public static string UsuarioCienteSql(bool valueCheck) => UsuarioCiente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string UsuarioCienteSqlSim => UsuarioCiente.SqlCmdBoolSim() ?? string.Empty;
    public static string UsuarioCienteSqlNao => UsuarioCiente.SqlCmdBoolNao() ?? string.Empty;

    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 100) ?? string.Empty;
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
        AgeIDCOB = 1,
        AgeClienteAvisado = 2,
        AgeRevisarP2 = 3,
        AgeIDNE = 4,
        AgeCidade = 5,
        AgeOculto = 6,
        AgeCartaPrecatoria = 7,
        AgeRevisar = 8,
        AgeHrFinal = 9,
        AgeAdvogado = 10,
        AgeEventoGerador = 11,
        AgeEventoData = 12,
        AgeFuncionario = 13,
        AgeData = 14,
        AgeEventoPrazo = 15,
        AgeHora = 16,
        AgeCompromisso = 17,
        AgeTipoCompromisso = 18,
        AgeCliente = 19,
        AgeLiberado = 20,
        AgeImportante = 21,
        AgeConcluido = 22,
        AgeArea = 23,
        AgeJustica = 24,
        AgeProcesso = 25,
        AgeIDHistorico = 26,
        AgeIDInsProcesso = 27,
        AgeUsuario = 28,
        AgePreposto = 29,
        AgeQuemID = 30,
        AgeQuemCodigo = 31,
        AgeStatus = 32,
        AgeValor = 33,
        AgeDecisao = 34,
        AgeSempre = 35,
        AgePrazoDias = 36,
        AgeProtocoloIntegrado = 37,
        AgeDataInicioPrazo = 38,
        AgeUsuarioCiente = 39,
        AgeGUID = 40,
        AgeQuemCad = 41,
        AgeDtCad = 42,
        AgeQuemAtu = 43,
        AgeDtAtu = 44,
        AgeVisto = 45
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AgeIDCOB => AgeIDCOB,
        NomesCamposTabela.AgeClienteAvisado => AgeClienteAvisado,
        NomesCamposTabela.AgeRevisarP2 => AgeRevisarP2,
        NomesCamposTabela.AgeIDNE => AgeIDNE,
        NomesCamposTabela.AgeCidade => AgeCidade,
        NomesCamposTabela.AgeOculto => AgeOculto,
        NomesCamposTabela.AgeCartaPrecatoria => AgeCartaPrecatoria,
        NomesCamposTabela.AgeRevisar => AgeRevisar,
        NomesCamposTabela.AgeHrFinal => AgeHrFinal,
        NomesCamposTabela.AgeAdvogado => AgeAdvogado,
        NomesCamposTabela.AgeEventoGerador => AgeEventoGerador,
        NomesCamposTabela.AgeEventoData => AgeEventoData,
        NomesCamposTabela.AgeFuncionario => AgeFuncionario,
        NomesCamposTabela.AgeData => AgeData,
        NomesCamposTabela.AgeEventoPrazo => AgeEventoPrazo,
        NomesCamposTabela.AgeHora => AgeHora,
        NomesCamposTabela.AgeCompromisso => AgeCompromisso,
        NomesCamposTabela.AgeTipoCompromisso => AgeTipoCompromisso,
        NomesCamposTabela.AgeCliente => AgeCliente,
        NomesCamposTabela.AgeLiberado => AgeLiberado,
        NomesCamposTabela.AgeImportante => AgeImportante,
        NomesCamposTabela.AgeConcluido => AgeConcluido,
        NomesCamposTabela.AgeArea => AgeArea,
        NomesCamposTabela.AgeJustica => AgeJustica,
        NomesCamposTabela.AgeProcesso => AgeProcesso,
        NomesCamposTabela.AgeIDHistorico => AgeIDHistorico,
        NomesCamposTabela.AgeIDInsProcesso => AgeIDInsProcesso,
        NomesCamposTabela.AgeUsuario => AgeUsuario,
        NomesCamposTabela.AgePreposto => AgePreposto,
        NomesCamposTabela.AgeQuemID => AgeQuemID,
        NomesCamposTabela.AgeQuemCodigo => AgeQuemCodigo,
        NomesCamposTabela.AgeStatus => AgeStatus,
        NomesCamposTabela.AgeValor => AgeValor,
        NomesCamposTabela.AgeDecisao => AgeDecisao,
        NomesCamposTabela.AgeSempre => AgeSempre,
        NomesCamposTabela.AgePrazoDias => AgePrazoDias,
        NomesCamposTabela.AgeProtocoloIntegrado => AgeProtocoloIntegrado,
        NomesCamposTabela.AgeDataInicioPrazo => AgeDataInicioPrazo,
        NomesCamposTabela.AgeUsuarioCiente => AgeUsuarioCiente,
        NomesCamposTabela.AgeGUID => AgeGUID,
        NomesCamposTabela.AgeQuemCad => AgeQuemCad,
        NomesCamposTabela.AgeDtCad => AgeDtCad,
        NomesCamposTabela.AgeQuemAtu => AgeQuemAtu,
        NomesCamposTabela.AgeDtAtu => AgeDtAtu,
        NomesCamposTabela.AgeVisto => AgeVisto,
        _ => null
    };
}