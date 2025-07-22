using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOperadorDicInfo
{
    public const string CampoCodigo = "operCodigo";
    public const string CampoNome = "operNome";
    public const string TablePrefix = "oper";
    public const string EMail = "operEMail"; // LOCALIZACAO 170523
    public const string Pasta = "operPasta"; // LOCALIZACAO 170523
    public const string Telefonista = "operTelefonista"; // LOCALIZACAO 170523
    public const string Master = "operMaster"; // LOCALIZACAO 170523
    public const string Nome = "operNome"; // LOCALIZACAO 170523
    public const string Nick = "operNick"; // LOCALIZACAO 170523
    public const string Ramal = "operRamal"; // LOCALIZACAO 170523
    public const string CadID = "operCadID"; // LOCALIZACAO 170523
    public const string CadCod = "operCadCod"; // LOCALIZACAO 170523
    public const string Excluido = "operExcluido"; // LOCALIZACAO 170523
    public const string Situacao = "operSituacao"; // LOCALIZACAO 170523
    public const string Computador = "operComputador"; // LOCALIZACAO 170523
    public const string MinhaDescricao = "operMinhaDescricao"; // LOCALIZACAO 170523
    public const string UltimoLogoff = "operUltimoLogoff"; // LOCALIZACAO 170523
    public const string EMailNet = "operEMailNet"; // LOCALIZACAO 170523
    public const string OnlineIP = "operOnlineIP"; // LOCALIZACAO 170523
    public const string OnLine = "operOnLine"; // LOCALIZACAO 170523
    public const string SysOp = "operSysOp"; // LOCALIZACAO 170523
    public const string StatusId = "operStatusId"; // LOCALIZACAO 170523
    public const string StatusMessage = "operStatusMessage"; // LOCALIZACAO 170523
    public const string IsFinanceiro = "operIsFinanceiro"; // LOCALIZACAO 170523
    public const string Top = "operTop"; // LOCALIZACAO 170523
    public const string Sexo = "operSexo"; // LOCALIZACAO 170523
    public const string Basico = "operBasico"; // LOCALIZACAO 170523
    public const string Externo = "operExterno"; // LOCALIZACAO 170523
    public const string Senha256 = "operSenha256"; // LOCALIZACAO 170523
    public const string EMailConfirmado = "operEMailConfirmado"; // LOCALIZACAO 170523
    public const string DataLimiteReset = "operDataLimiteReset"; // LOCALIZACAO 170523
    public const string SuporteSenha256 = "operSuporteSenha256"; // LOCALIZACAO 170523
    public const string SuporteMaxAge = "operSuporteMaxAge"; // LOCALIZACAO 170523
    public const string SuporteNomeSolicitante = "operSuporteNomeSolicitante"; // LOCALIZACAO 170523
    public const string SuporteUltimoAcesso = "operSuporteUltimoAcesso"; // LOCALIZACAO 170523
    public const string SuporteIpUltimoAcesso = "operSuporteIpUltimoAcesso"; // LOCALIZACAO 170523
    public const string GUID = "operGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "operQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "operDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "operQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "operDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "operVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => EMail,
        2 => Pasta,
        3 => Telefonista,
        4 => Master,
        5 => Nome,
        6 => Nick,
        7 => Ramal,
        8 => CadID,
        9 => CadCod,
        10 => Excluido,
        11 => Situacao,
        12 => Computador,
        13 => MinhaDescricao,
        14 => UltimoLogoff,
        15 => EMailNet,
        16 => OnlineIP,
        17 => OnLine,
        18 => SysOp,
        19 => StatusId,
        20 => StatusMessage,
        21 => IsFinanceiro,
        22 => Top,
        23 => Sexo,
        24 => Basico,
        25 => Externo,
        26 => Senha256,
        27 => EMailConfirmado,
        28 => DataLimiteReset,
        29 => SuporteSenha256,
        30 => SuporteMaxAge,
        31 => SuporteNomeSolicitante,
        32 => SuporteUltimoAcesso,
        33 => SuporteIpUltimoAcesso,
        34 => GUID,
        35 => QuemCad,
        36 => DtCad,
        37 => QuemAtu,
        38 => DtAtu,
        39 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Operador";
#region PropriedadesDaTabela
    public static DBInfoSystem OperEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperPasta => new(0, PTabelaNome, CampoCodigo, Pasta, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperTelefonista => new(0, PTabelaNome, CampoCodigo, Telefonista, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "oper"
    };
    public static DBInfoSystem OperMaster => new(0, PTabelaNome, CampoCodigo, Master, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "oper"
    };
    public static DBInfoSystem OperNome => new(0, PTabelaNome, CampoCodigo, Nome, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperNick => new(0, PTabelaNome, CampoCodigo, Nick, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperRamal => new(0, PTabelaNome, CampoCodigo, Ramal, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperCadID => new(0, PTabelaNome, CampoCodigo, CadID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperCadCod => new(0, PTabelaNome, CampoCodigo, CadCod, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperExcluido => new(0, PTabelaNome, CampoCodigo, Excluido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "oper"
    };
    public static DBInfoSystem OperSituacao => new(0, PTabelaNome, CampoCodigo, Situacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "oper"
    };
    public static DBInfoSystem OperComputador => new(0, PTabelaNome, CampoCodigo, Computador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperMinhaDescricao => new(0, PTabelaNome, CampoCodigo, MinhaDescricao, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperUltimoLogoff => new(0, PTabelaNome, CampoCodigo, UltimoLogoff, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperEMailNet => new(0, PTabelaNome, CampoCodigo, EMailNet, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperOnlineIP => new(0, PTabelaNome, CampoCodigo, OnlineIP, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperOnLine => new(0, PTabelaNome, CampoCodigo, OnLine, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperSysOp => new(0, PTabelaNome, CampoCodigo, SysOp, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperStatusId => new(0, PTabelaNome, CampoCodigo, StatusId, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBStatusBiuDicInfo.CampoCodigo, DBStatusBiuDicInfo.TabelaNome, new DBStatusBiuODicInfo(), false)
    {
        Prefixo = "oper"
    }; // DBI 11 
    public static DBInfoSystem OperStatusMessage => new(0, PTabelaNome, CampoCodigo, StatusMessage, 1024, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperIsFinanceiro => new(0, PTabelaNome, CampoCodigo, IsFinanceiro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperBasico => new(0, PTabelaNome, CampoCodigo, Basico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperExterno => new(0, PTabelaNome, CampoCodigo, Externo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperSenha256 => new(0, PTabelaNome, CampoCodigo, Senha256, 4000, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperEMailConfirmado => new(0, PTabelaNome, CampoCodigo, EMailConfirmado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperDataLimiteReset => new(0, PTabelaNome, CampoCodigo, DataLimiteReset, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperSuporteSenha256 => new(0, PTabelaNome, CampoCodigo, SuporteSenha256, 4000, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperSuporteMaxAge => new(0, PTabelaNome, CampoCodigo, SuporteMaxAge, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperSuporteNomeSolicitante => new(0, PTabelaNome, CampoCodigo, SuporteNomeSolicitante, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperSuporteUltimoAcesso => new(0, PTabelaNome, CampoCodigo, SuporteUltimoAcesso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperSuporteIpUltimoAcesso => new(0, PTabelaNome, CampoCodigo, SuporteIpUltimoAcesso, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperGUID => new(0, PTabelaNome, CampoCodigo, GUID, 50, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "oper"
    };
    public static DBInfoSystem OperVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        Prefixo = "oper"
    };

#endregion
#region SMART_SQLServices 
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PastaSql(string text) => Pasta.SqlCmdTextIgual(text) ?? string.Empty;
    public static string PastaSqlNotIsNull => Pasta.SqlCmdNotIsNull() ?? string.Empty;
    public static string PastaSqlIsNull => Pasta.SqlCmdIsNull() ?? string.Empty;

    public static string PastaSqlDiff(string text) => Pasta.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PastaSqlLike(string text) => Pasta.SqlCmdTextLike(text) ?? string.Empty;
    public static string PastaSqlLikeInit(string text) => Pasta.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PastaSqlLikeSpaces(string? text) => Pasta.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TelefonistaSql(bool valueCheck) => Telefonista.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TelefonistaSqlSim => Telefonista.SqlCmdBoolSim() ?? string.Empty;
    public static string TelefonistaSqlNao => Telefonista.SqlCmdBoolNao() ?? string.Empty;

    public static string MasterSql(bool valueCheck) => Master.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string MasterSqlSim => Master.SqlCmdBoolSim() ?? string.Empty;
    public static string MasterSqlNao => Master.SqlCmdBoolNao() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 40) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NickSql(string text) => Nick.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string NickSqlNotIsNull => Nick.SqlCmdNotIsNull() ?? string.Empty;
    public static string NickSqlIsNull => Nick.SqlCmdIsNull() ?? string.Empty;

    public static string NickSqlDiff(string text) => Nick.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NickSqlLike(string text) => Nick.SqlCmdTextLike(text) ?? string.Empty;
    public static string NickSqlLikeInit(string text) => Nick.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NickSqlLikeSpaces(string? text) => Nick.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RamalSql(string text) => Ramal.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string RamalSqlNotIsNull => Ramal.SqlCmdNotIsNull() ?? string.Empty;
    public static string RamalSqlIsNull => Ramal.SqlCmdIsNull() ?? string.Empty;

    public static string RamalSqlDiff(string text) => Ramal.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RamalSqlLike(string text) => Ramal.SqlCmdTextLike(text) ?? string.Empty;
    public static string RamalSqlLikeInit(string text) => Ramal.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RamalSqlLikeSpaces(string? text) => Ramal.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ExcluidoSql(bool valueCheck) => Excluido.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ExcluidoSqlSim => Excluido.SqlCmdBoolSim() ?? string.Empty;
    public static string ExcluidoSqlNao => Excluido.SqlCmdBoolNao() ?? string.Empty;

    public static string SituacaoSql(bool valueCheck) => Situacao.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SituacaoSqlSim => Situacao.SqlCmdBoolSim() ?? string.Empty;
    public static string SituacaoSqlNao => Situacao.SqlCmdBoolNao() ?? string.Empty;

    public static string MinhaDescricaoSql(string text) => MinhaDescricao.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string MinhaDescricaoSqlNotIsNull => MinhaDescricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string MinhaDescricaoSqlIsNull => MinhaDescricao.SqlCmdIsNull() ?? string.Empty;

    public static string MinhaDescricaoSqlDiff(string text) => MinhaDescricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string MinhaDescricaoSqlLike(string text) => MinhaDescricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string MinhaDescricaoSqlLikeInit(string text) => MinhaDescricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string MinhaDescricaoSqlLikeSpaces(string? text) => MinhaDescricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string UltimoLogoffSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{UltimoLogoff}]");
    public static string UltimoLogoffSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{UltimoLogoff}]");
    public static string UltimoLogoffIsNull => UltimoLogoff.SqlCmdIsNull() ?? string.Empty;
    public static string UltimoLogoffNotIsNull => UltimoLogoff.SqlCmdNotIsNull() ?? string.Empty;

    public static string EMailNetSql(string text) => EMailNet.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string EMailNetSqlNotIsNull => EMailNet.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailNetSqlIsNull => EMailNet.SqlCmdIsNull() ?? string.Empty;

    public static string EMailNetSqlDiff(string text) => EMailNet.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailNetSqlLike(string text) => EMailNet.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailNetSqlLikeInit(string text) => EMailNet.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailNetSqlLikeSpaces(string? text) => EMailNet.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OnlineIPSql(string text) => OnlineIP.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string OnlineIPSqlNotIsNull => OnlineIP.SqlCmdNotIsNull() ?? string.Empty;
    public static string OnlineIPSqlIsNull => OnlineIP.SqlCmdIsNull() ?? string.Empty;

    public static string OnlineIPSqlDiff(string text) => OnlineIP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OnlineIPSqlLike(string text) => OnlineIP.SqlCmdTextLike(text) ?? string.Empty;
    public static string OnlineIPSqlLikeInit(string text) => OnlineIP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OnlineIPSqlLikeSpaces(string? text) => OnlineIP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OnLineSql(bool valueCheck) => OnLine.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string OnLineSqlSim => OnLine.SqlCmdBoolSim() ?? string.Empty;
    public static string OnLineSqlNao => OnLine.SqlCmdBoolNao() ?? string.Empty;

    public static string SysOpSql(bool valueCheck) => SysOp.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SysOpSqlSim => SysOp.SqlCmdBoolSim() ?? string.Empty;
    public static string SysOpSqlNao => SysOp.SqlCmdBoolNao() ?? string.Empty;

    public static string StatusMessageSql(string text) => StatusMessage.SqlCmdTextIgual(text, 1024) ?? string.Empty;
    public static string StatusMessageSqlNotIsNull => StatusMessage.SqlCmdNotIsNull() ?? string.Empty;
    public static string StatusMessageSqlIsNull => StatusMessage.SqlCmdIsNull() ?? string.Empty;

    public static string StatusMessageSqlDiff(string text) => StatusMessage.SqlCmdTextDiff(text) ?? string.Empty;
    public static string StatusMessageSqlLike(string text) => StatusMessage.SqlCmdTextLike(text) ?? string.Empty;
    public static string StatusMessageSqlLikeInit(string text) => StatusMessage.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string StatusMessageSqlLikeSpaces(string? text) => StatusMessage.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string IsFinanceiroSql(bool valueCheck) => IsFinanceiro.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IsFinanceiroSqlSim => IsFinanceiro.SqlCmdBoolSim() ?? string.Empty;
    public static string IsFinanceiroSqlNao => IsFinanceiro.SqlCmdBoolNao() ?? string.Empty;

    public static string TopSql(bool valueCheck) => Top.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TopSqlSim => Top.SqlCmdBoolSim() ?? string.Empty;
    public static string TopSqlNao => Top.SqlCmdBoolNao() ?? string.Empty;

    public static string SexoSql(bool valueCheck) => Sexo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SexoSqlSim => Sexo.SqlCmdBoolSim() ?? string.Empty;
    public static string SexoSqlNao => Sexo.SqlCmdBoolNao() ?? string.Empty;

    public static string BasicoSql(bool valueCheck) => Basico.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BasicoSqlSim => Basico.SqlCmdBoolSim() ?? string.Empty;
    public static string BasicoSqlNao => Basico.SqlCmdBoolNao() ?? string.Empty;

    public static string ExternoSql(bool valueCheck) => Externo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ExternoSqlSim => Externo.SqlCmdBoolSim() ?? string.Empty;
    public static string ExternoSqlNao => Externo.SqlCmdBoolNao() ?? string.Empty;

    public static string Senha256Sql(string text) => Senha256.SqlCmdTextIgual(text, 4000) ?? string.Empty;
    public static string Senha256SqlNotIsNull => Senha256.SqlCmdNotIsNull() ?? string.Empty;
    public static string Senha256SqlIsNull => Senha256.SqlCmdIsNull() ?? string.Empty;

    public static string Senha256SqlDiff(string text) => Senha256.SqlCmdTextDiff(text) ?? string.Empty;
    public static string Senha256SqlLike(string text) => Senha256.SqlCmdTextLike(text) ?? string.Empty;
    public static string Senha256SqlLikeInit(string text) => Senha256.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string Senha256SqlLikeSpaces(string? text) => Senha256.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailConfirmadoSql(bool valueCheck) => EMailConfirmado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string EMailConfirmadoSqlSim => EMailConfirmado.SqlCmdBoolSim() ?? string.Empty;
    public static string EMailConfirmadoSqlNao => EMailConfirmado.SqlCmdBoolNao() ?? string.Empty;

    public static string DataLimiteResetSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataLimiteReset}]");
    public static string DataLimiteResetSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataLimiteReset}]");
    public static string DataLimiteResetIsNull => DataLimiteReset.SqlCmdIsNull() ?? string.Empty;
    public static string DataLimiteResetNotIsNull => DataLimiteReset.SqlCmdNotIsNull() ?? string.Empty;

    public static string SuporteSenha256Sql(string text) => SuporteSenha256.SqlCmdTextIgual(text, 4000) ?? string.Empty;
    public static string SuporteSenha256SqlNotIsNull => SuporteSenha256.SqlCmdNotIsNull() ?? string.Empty;
    public static string SuporteSenha256SqlIsNull => SuporteSenha256.SqlCmdIsNull() ?? string.Empty;

    public static string SuporteSenha256SqlDiff(string text) => SuporteSenha256.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SuporteSenha256SqlLike(string text) => SuporteSenha256.SqlCmdTextLike(text) ?? string.Empty;
    public static string SuporteSenha256SqlLikeInit(string text) => SuporteSenha256.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SuporteSenha256SqlLikeSpaces(string? text) => SuporteSenha256.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SuporteMaxAgeSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeIsNull => SuporteMaxAge.SqlCmdIsNull() ?? string.Empty;
    public static string SuporteMaxAgeNotIsNull => SuporteMaxAge.SqlCmdNotIsNull() ?? string.Empty;

    public static string SuporteNomeSolicitanteSql(string text) => SuporteNomeSolicitante.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string SuporteNomeSolicitanteSqlNotIsNull => SuporteNomeSolicitante.SqlCmdNotIsNull() ?? string.Empty;
    public static string SuporteNomeSolicitanteSqlIsNull => SuporteNomeSolicitante.SqlCmdIsNull() ?? string.Empty;

    public static string SuporteNomeSolicitanteSqlDiff(string text) => SuporteNomeSolicitante.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SuporteNomeSolicitanteSqlLike(string text) => SuporteNomeSolicitante.SqlCmdTextLike(text) ?? string.Empty;
    public static string SuporteNomeSolicitanteSqlLikeInit(string text) => SuporteNomeSolicitante.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SuporteNomeSolicitanteSqlLikeSpaces(string? text) => SuporteNomeSolicitante.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SuporteUltimoAcessoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{SuporteUltimoAcesso}]");
    public static string SuporteUltimoAcessoIsNull => SuporteUltimoAcesso.SqlCmdIsNull() ?? string.Empty;
    public static string SuporteUltimoAcessoNotIsNull => SuporteUltimoAcesso.SqlCmdNotIsNull() ?? string.Empty;

    public static string SuporteIpUltimoAcessoSql(string text) => SuporteIpUltimoAcesso.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string SuporteIpUltimoAcessoSqlNotIsNull => SuporteIpUltimoAcesso.SqlCmdNotIsNull() ?? string.Empty;
    public static string SuporteIpUltimoAcessoSqlIsNull => SuporteIpUltimoAcesso.SqlCmdIsNull() ?? string.Empty;

    public static string SuporteIpUltimoAcessoSqlDiff(string text) => SuporteIpUltimoAcesso.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SuporteIpUltimoAcessoSqlLike(string text) => SuporteIpUltimoAcesso.SqlCmdTextLike(text) ?? string.Empty;
    public static string SuporteIpUltimoAcessoSqlLikeInit(string text) => SuporteIpUltimoAcesso.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SuporteIpUltimoAcessoSqlLikeSpaces(string? text) => SuporteIpUltimoAcesso.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 50) ?? string.Empty;
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
        OperEMail = 1,
        OperPasta = 2,
        OperTelefonista = 3,
        OperMaster = 4,
        OperNome = 5,
        OperNick = 6,
        OperRamal = 7,
        OperCadID = 8,
        OperCadCod = 9,
        OperExcluido = 10,
        OperSituacao = 11,
        OperComputador = 12,
        OperMinhaDescricao = 13,
        OperUltimoLogoff = 14,
        OperEMailNet = 15,
        OperOnlineIP = 16,
        OperOnLine = 17,
        OperSysOp = 18,
        OperStatusId = 19,
        OperStatusMessage = 20,
        OperIsFinanceiro = 21,
        OperTop = 22,
        OperSexo = 23,
        OperBasico = 24,
        OperExterno = 25,
        OperSenha256 = 26,
        OperEMailConfirmado = 27,
        OperDataLimiteReset = 28,
        OperSuporteSenha256 = 29,
        OperSuporteMaxAge = 30,
        OperSuporteNomeSolicitante = 31,
        OperSuporteUltimoAcesso = 32,
        OperSuporteIpUltimoAcesso = 33,
        OperGUID = 34,
        OperQuemCad = 35,
        OperDtCad = 36,
        OperQuemAtu = 37,
        OperDtAtu = 38,
        OperVisto = 39
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OperEMail => OperEMail,
        NomesCamposTabela.OperPasta => OperPasta,
        NomesCamposTabela.OperTelefonista => OperTelefonista,
        NomesCamposTabela.OperMaster => OperMaster,
        NomesCamposTabela.OperNome => OperNome,
        NomesCamposTabela.OperNick => OperNick,
        NomesCamposTabela.OperRamal => OperRamal,
        NomesCamposTabela.OperCadID => OperCadID,
        NomesCamposTabela.OperCadCod => OperCadCod,
        NomesCamposTabela.OperExcluido => OperExcluido,
        NomesCamposTabela.OperSituacao => OperSituacao,
        NomesCamposTabela.OperComputador => OperComputador,
        NomesCamposTabela.OperMinhaDescricao => OperMinhaDescricao,
        NomesCamposTabela.OperUltimoLogoff => OperUltimoLogoff,
        NomesCamposTabela.OperEMailNet => OperEMailNet,
        NomesCamposTabela.OperOnlineIP => OperOnlineIP,
        NomesCamposTabela.OperOnLine => OperOnLine,
        NomesCamposTabela.OperSysOp => OperSysOp,
        NomesCamposTabela.OperStatusId => OperStatusId,
        NomesCamposTabela.OperStatusMessage => OperStatusMessage,
        NomesCamposTabela.OperIsFinanceiro => OperIsFinanceiro,
        NomesCamposTabela.OperTop => OperTop,
        NomesCamposTabela.OperSexo => OperSexo,
        NomesCamposTabela.OperBasico => OperBasico,
        NomesCamposTabela.OperExterno => OperExterno,
        NomesCamposTabela.OperSenha256 => OperSenha256,
        NomesCamposTabela.OperEMailConfirmado => OperEMailConfirmado,
        NomesCamposTabela.OperDataLimiteReset => OperDataLimiteReset,
        NomesCamposTabela.OperSuporteSenha256 => OperSuporteSenha256,
        NomesCamposTabela.OperSuporteMaxAge => OperSuporteMaxAge,
        NomesCamposTabela.OperSuporteNomeSolicitante => OperSuporteNomeSolicitante,
        NomesCamposTabela.OperSuporteUltimoAcesso => OperSuporteUltimoAcesso,
        NomesCamposTabela.OperSuporteIpUltimoAcesso => OperSuporteIpUltimoAcesso,
        NomesCamposTabela.OperGUID => OperGUID,
        NomesCamposTabela.OperQuemCad => OperQuemCad,
        NomesCamposTabela.OperDtCad => OperDtCad,
        NomesCamposTabela.OperQuemAtu => OperQuemAtu,
        NomesCamposTabela.OperDtAtu => OperDtAtu,
        NomesCamposTabela.OperVisto => OperVisto,
        _ => null
    };
}