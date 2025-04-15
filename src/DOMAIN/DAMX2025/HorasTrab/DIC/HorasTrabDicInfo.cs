using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBHorasTrabDicInfo
{
    public const string CampoCodigo = "htbCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "htb";
    public const string IDContatoCRM = "htbIDContatoCRM"; // LOCALIZACAO 170523
    public const string Honorario = "htbHonorario"; // LOCALIZACAO 170523
    public const string IDAgenda = "htbIDAgenda"; // LOCALIZACAO 170523
    public const string Data = "htbData"; // LOCALIZACAO 170523
    public const string Cliente = "htbCliente"; // LOCALIZACAO 170523
    public const string Status = "htbStatus"; // LOCALIZACAO 170523
    public const string Processo = "htbProcesso"; // LOCALIZACAO 170523
    public const string Advogado = "htbAdvogado"; // LOCALIZACAO 170523
    public const string Funcionario = "htbFuncionario"; // LOCALIZACAO 170523
    public const string HrIni = "htbHrIni"; // LOCALIZACAO 170523
    public const string HrFim = "htbHrFim"; // LOCALIZACAO 170523
    public const string Tempo = "htbTempo"; // LOCALIZACAO 170523
    public const string Valor = "htbValor"; // LOCALIZACAO 170523
    public const string OBS = "htbOBS"; // LOCALIZACAO 170523
    public const string Anexo = "htbAnexo"; // LOCALIZACAO 170523
    public const string AnexoComp = "htbAnexoComp"; // LOCALIZACAO 170523
    public const string AnexoUNC = "htbAnexoUNC"; // LOCALIZACAO 170523
    public const string Servico = "htbServico"; // LOCALIZACAO 170523
    public const string GUID = "htbGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "htbQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "htbDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "htbQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "htbDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "htbVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => IDContatoCRM,
        2 => Honorario,
        3 => IDAgenda,
        4 => Data,
        5 => Cliente,
        6 => Status,
        7 => Processo,
        8 => Advogado,
        9 => Funcionario,
        10 => HrIni,
        11 => HrFim,
        12 => Tempo,
        13 => Valor,
        14 => OBS,
        15 => Anexo,
        16 => AnexoComp,
        17 => AnexoUNC,
        18 => Servico,
        19 => GUID,
        20 => QuemCad,
        21 => DtCad,
        22 => QuemAtu,
        23 => DtAtu,
        24 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "HorasTrab";
#region PropriedadesDaTabela
    public static DBInfoSystem HtbIDContatoCRM => new(0, PTabelaNome, CampoCodigo, IDContatoCRM, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem HtbHonorario => new(0, PTabelaNome, CampoCodigo, Honorario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem HtbIDAgenda => new(0, PTabelaNome, CampoCodigo, IDAgenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem HtbData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem HtbCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem HtbStatus => new(0, PTabelaNome, CampoCodigo, Status, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem HtbProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem HtbAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false); // DBI 11 
    public static DBInfoSystem HtbFuncionario => new(0, PTabelaNome, CampoCodigo, Funcionario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncionariosDicInfo.CampoCodigo, DBFuncionariosDicInfo.TabelaNome, new DBFuncionariosODicInfo(), false); // DBI 11 
    public static DBInfoSystem HtbHrIni => new(0, PTabelaNome, CampoCodigo, HrIni, 5, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem HtbHrFim => new(0, PTabelaNome, CampoCodigo, HrFim, 5, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem HtbTempo => new(0, PTabelaNome, CampoCodigo, Tempo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem HtbValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble);
    public static DBInfoSystem HtbOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem HtbAnexo => new(0, PTabelaNome, CampoCodigo, Anexo, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem HtbAnexoComp => new(0, PTabelaNome, CampoCodigo, AnexoComp, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem HtbAnexoUNC => new(0, PTabelaNome, CampoCodigo, AnexoUNC, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem HtbServico => new(0, PTabelaNome, CampoCodigo, Servico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBServicosDicInfo.CampoCodigo, DBServicosDicInfo.TabelaNome, new DBServicosODicInfo(), false); // DBI 11 
    public static DBInfoSystem HtbGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem HtbQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem HtbDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem HtbQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem HtbDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem HtbVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string IDContatoCRMDiff(int id) => IDContatoCRM.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IDContatoCRMSql(int id) => IDContatoCRM.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IDContatoCRMIsNull => IDContatoCRM.SqlCmdIsNull() ?? string.Empty;
    public static string IDContatoCRMNotIsNull => IDContatoCRM.SqlCmdNotIsNull() ?? string.Empty;

    public static string HonorarioSql(bool valueCheck) => Honorario.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string HonorarioSqlSim => Honorario.SqlCmdBoolSim() ?? string.Empty;
    public static string HonorarioSqlNao => Honorario.SqlCmdBoolNao() ?? string.Empty;

    public static string IDAgendaDiff(int id) => IDAgenda.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IDAgendaSql(int id) => IDAgenda.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IDAgendaIsNull => IDAgenda.SqlCmdIsNull() ?? string.Empty;
    public static string IDAgendaNotIsNull => IDAgenda.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

    public static string StatusDiff(int id) => Status.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string StatusSql(int id) => Status.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string StatusIsNull => Status.SqlCmdIsNull() ?? string.Empty;
    public static string StatusNotIsNull => Status.SqlCmdNotIsNull() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string AdvogadoDiff(int id) => Advogado.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AdvogadoSql(int id) => Advogado.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AdvogadoIsNull => Advogado.SqlCmdIsNull() ?? string.Empty;
    public static string AdvogadoNotIsNull => Advogado.SqlCmdNotIsNull() ?? string.Empty;

    public static string FuncionarioDiff(int id) => Funcionario.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string FuncionarioSql(int id) => Funcionario.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string FuncionarioIsNull => Funcionario.SqlCmdIsNull() ?? string.Empty;
    public static string FuncionarioNotIsNull => Funcionario.SqlCmdNotIsNull() ?? string.Empty;

    public static string HrIniSql(string text) => HrIni.SqlCmdTextIgual(text, 5) ?? string.Empty;
    public static string HrIniSqlNotIsNull => HrIni.SqlCmdNotIsNull() ?? string.Empty;
    public static string HrIniSqlIsNull => HrIni.SqlCmdIsNull() ?? string.Empty;

    public static string HrIniSqlDiff(string text) => HrIni.SqlCmdTextDiff(text) ?? string.Empty;
    public static string HrIniSqlLike(string text) => HrIni.SqlCmdTextLike(text) ?? string.Empty;
    public static string HrIniSqlLikeInit(string text) => HrIni.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string HrIniSqlLikeSpaces(string? text) => HrIni.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string HrFimSql(string text) => HrFim.SqlCmdTextIgual(text, 5) ?? string.Empty;
    public static string HrFimSqlNotIsNull => HrFim.SqlCmdNotIsNull() ?? string.Empty;
    public static string HrFimSqlIsNull => HrFim.SqlCmdIsNull() ?? string.Empty;

    public static string HrFimSqlDiff(string text) => HrFim.SqlCmdTextDiff(text) ?? string.Empty;
    public static string HrFimSqlLike(string text) => HrFim.SqlCmdTextLike(text) ?? string.Empty;
    public static string HrFimSqlLikeInit(string text) => HrFim.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string HrFimSqlLikeSpaces(string? text) => HrFim.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OBSSql(string text) => OBS.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OBSSqlNotIsNull => OBS.SqlCmdNotIsNull() ?? string.Empty;
    public static string OBSSqlIsNull => OBS.SqlCmdIsNull() ?? string.Empty;

    public static string OBSSqlDiff(string text) => OBS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OBSSqlLike(string text) => OBS.SqlCmdTextLike(text) ?? string.Empty;
    public static string OBSSqlLikeInit(string text) => OBS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OBSSqlLikeSpaces(string? text) => OBS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AnexoSql(string text) => Anexo.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string AnexoSqlNotIsNull => Anexo.SqlCmdNotIsNull() ?? string.Empty;
    public static string AnexoSqlIsNull => Anexo.SqlCmdIsNull() ?? string.Empty;

    public static string AnexoSqlDiff(string text) => Anexo.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AnexoSqlLike(string text) => Anexo.SqlCmdTextLike(text) ?? string.Empty;
    public static string AnexoSqlLikeInit(string text) => Anexo.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AnexoSqlLikeSpaces(string? text) => Anexo.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AnexoCompSql(string text) => AnexoComp.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string AnexoCompSqlNotIsNull => AnexoComp.SqlCmdNotIsNull() ?? string.Empty;
    public static string AnexoCompSqlIsNull => AnexoComp.SqlCmdIsNull() ?? string.Empty;

    public static string AnexoCompSqlDiff(string text) => AnexoComp.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AnexoCompSqlLike(string text) => AnexoComp.SqlCmdTextLike(text) ?? string.Empty;
    public static string AnexoCompSqlLikeInit(string text) => AnexoComp.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AnexoCompSqlLikeSpaces(string? text) => AnexoComp.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AnexoUNCSql(string text) => AnexoUNC.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string AnexoUNCSqlNotIsNull => AnexoUNC.SqlCmdNotIsNull() ?? string.Empty;
    public static string AnexoUNCSqlIsNull => AnexoUNC.SqlCmdIsNull() ?? string.Empty;

    public static string AnexoUNCSqlDiff(string text) => AnexoUNC.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AnexoUNCSqlLike(string text) => AnexoUNC.SqlCmdTextLike(text) ?? string.Empty;
    public static string AnexoUNCSqlLikeInit(string text) => AnexoUNC.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AnexoUNCSqlLikeSpaces(string? text) => AnexoUNC.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ServicoDiff(int id) => Servico.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ServicoSql(int id) => Servico.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ServicoIsNull => Servico.SqlCmdIsNull() ?? string.Empty;
    public static string ServicoNotIsNull => Servico.SqlCmdNotIsNull() ?? string.Empty;

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
        HtbIDContatoCRM = 1,
        HtbHonorario = 2,
        HtbIDAgenda = 3,
        HtbData = 4,
        HtbCliente = 5,
        HtbStatus = 6,
        HtbProcesso = 7,
        HtbAdvogado = 8,
        HtbFuncionario = 9,
        HtbHrIni = 10,
        HtbHrFim = 11,
        HtbTempo = 12,
        HtbValor = 13,
        HtbOBS = 14,
        HtbAnexo = 15,
        HtbAnexoComp = 16,
        HtbAnexoUNC = 17,
        HtbServico = 18,
        HtbGUID = 19,
        HtbQuemCad = 20,
        HtbDtCad = 21,
        HtbQuemAtu = 22,
        HtbDtAtu = 23,
        HtbVisto = 24
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.HtbIDContatoCRM => HtbIDContatoCRM,
        NomesCamposTabela.HtbHonorario => HtbHonorario,
        NomesCamposTabela.HtbIDAgenda => HtbIDAgenda,
        NomesCamposTabela.HtbData => HtbData,
        NomesCamposTabela.HtbCliente => HtbCliente,
        NomesCamposTabela.HtbStatus => HtbStatus,
        NomesCamposTabela.HtbProcesso => HtbProcesso,
        NomesCamposTabela.HtbAdvogado => HtbAdvogado,
        NomesCamposTabela.HtbFuncionario => HtbFuncionario,
        NomesCamposTabela.HtbHrIni => HtbHrIni,
        NomesCamposTabela.HtbHrFim => HtbHrFim,
        NomesCamposTabela.HtbTempo => HtbTempo,
        NomesCamposTabela.HtbValor => HtbValor,
        NomesCamposTabela.HtbOBS => HtbOBS,
        NomesCamposTabela.HtbAnexo => HtbAnexo,
        NomesCamposTabela.HtbAnexoComp => HtbAnexoComp,
        NomesCamposTabela.HtbAnexoUNC => HtbAnexoUNC,
        NomesCamposTabela.HtbServico => HtbServico,
        NomesCamposTabela.HtbGUID => HtbGUID,
        NomesCamposTabela.HtbQuemCad => HtbQuemCad,
        NomesCamposTabela.HtbDtCad => HtbDtCad,
        NomesCamposTabela.HtbQuemAtu => HtbQuemAtu,
        NomesCamposTabela.HtbDtAtu => HtbDtAtu,
        NomesCamposTabela.HtbVisto => HtbVisto,
        _ => null
    };
}