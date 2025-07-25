using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOperadorEMailPopupDicInfo
{
    public const string CampoCodigo = "oepCodigo";
    public const string CampoNome = "oepNome";
    public const string TablePrefix = "oep";
    public const string Operador = "oepOperador"; // LOCALIZACAO 170523
    public const string Nome = "oepNome"; // LOCALIZACAO 170523
    public const string Senha = "oepSenha"; // LOCALIZACAO 170523
    public const string SMTP = "oepSMTP"; // LOCALIZACAO 170523
    public const string POP3 = "oepPOP3"; // LOCALIZACAO 170523
    public const string Autenticacao = "oepAutenticacao"; // LOCALIZACAO 170523
    public const string Descricao = "oepDescricao"; // LOCALIZACAO 170523
    public const string Usuario = "oepUsuario"; // LOCALIZACAO 170523
    public const string PortaSmtp = "oepPortaSmtp"; // LOCALIZACAO 170523
    public const string PortaPop3 = "oepPortaPop3"; // LOCALIZACAO 170523
    public const string Assinatura = "oepAssinatura"; // LOCALIZACAO 170523
    public const string Senha256 = "oepSenha256"; // LOCALIZACAO 170523
    public const string GUID = "oepGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "oepQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "oepDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "oepQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "oepDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "oepVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Operador,
        2 => Nome,
        3 => Senha,
        4 => SMTP,
        5 => POP3,
        6 => Autenticacao,
        7 => Descricao,
        8 => Usuario,
        9 => PortaSmtp,
        10 => PortaPop3,
        11 => Assinatura,
        12 => Senha256,
        13 => GUID,
        14 => QuemCad,
        15 => DtCad,
        16 => QuemAtu,
        17 => DtAtu,
        18 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "OperadorEMailPopup";
#region PropriedadesDaTabela
    public static DBInfoSystem OepOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "oep"
    }; // DBI 11 
    public static DBInfoSystem OepNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepSenha => new(0, PTabelaNome, CampoCodigo, Senha, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepSMTP => new(0, PTabelaNome, CampoCodigo, SMTP, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepPOP3 => new(0, PTabelaNome, CampoCodigo, POP3, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepAutenticacao => new(0, PTabelaNome, CampoCodigo, Autenticacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "oep"
    };
    public static DBInfoSystem OepDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepUsuario => new(0, PTabelaNome, CampoCodigo, Usuario, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepPortaSmtp => new(0, PTabelaNome, CampoCodigo, PortaSmtp, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepPortaPop3 => new(0, PTabelaNome, CampoCodigo, PortaPop3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepAssinatura => new(0, PTabelaNome, CampoCodigo, Assinatura, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepSenha256 => new(0, PTabelaNome, CampoCodigo, Senha256, 4000, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "oep"
    }; // DBI 11 
    public static DBInfoSystem OepDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "oep"
    }; // DBI 11 
    public static DBInfoSystem OepDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "oep"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        OepOperador = 1,
        OepNome = 2,
        OepSenha = 3,
        OepSMTP = 4,
        OepPOP3 = 5,
        OepAutenticacao = 6,
        OepDescricao = 7,
        OepUsuario = 8,
        OepPortaSmtp = 9,
        OepPortaPop3 = 10,
        OepAssinatura = 11,
        OepSenha256 = 12,
        OepGUID = 13,
        OepQuemCad = 14,
        OepDtCad = 15,
        OepQuemAtu = 16,
        OepDtAtu = 17,
        OepVisto = 18
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OepOperador => OepOperador,
        NomesCamposTabela.OepNome => OepNome,
        NomesCamposTabela.OepSenha => OepSenha,
        NomesCamposTabela.OepSMTP => OepSMTP,
        NomesCamposTabela.OepPOP3 => OepPOP3,
        NomesCamposTabela.OepAutenticacao => OepAutenticacao,
        NomesCamposTabela.OepDescricao => OepDescricao,
        NomesCamposTabela.OepUsuario => OepUsuario,
        NomesCamposTabela.OepPortaSmtp => OepPortaSmtp,
        NomesCamposTabela.OepPortaPop3 => OepPortaPop3,
        NomesCamposTabela.OepAssinatura => OepAssinatura,
        NomesCamposTabela.OepSenha256 => OepSenha256,
        NomesCamposTabela.OepGUID => OepGUID,
        NomesCamposTabela.OepQuemCad => OepQuemCad,
        NomesCamposTabela.OepDtCad => OepDtCad,
        NomesCamposTabela.OepQuemAtu => OepQuemAtu,
        NomesCamposTabela.OepDtAtu => OepDtAtu,
        NomesCamposTabela.OepVisto => OepVisto,
        _ => null
    };
}