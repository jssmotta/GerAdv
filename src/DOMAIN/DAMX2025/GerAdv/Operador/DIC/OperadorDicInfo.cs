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