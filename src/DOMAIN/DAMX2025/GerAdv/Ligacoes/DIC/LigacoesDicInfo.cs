using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBLigacoesDicInfo
{
    public const string CampoCodigo = "ligCodigo";
    public const string CampoNome = "ligNome";
    public const string TablePrefix = "lig";
    public const string Assunto = "ligAssunto"; // LOCALIZACAO 170523
    public const string AgeClienteAvisado = "ligAgeClienteAvisado"; // LOCALIZACAO 170523
    public const string Celular = "ligCelular"; // LOCALIZACAO 170523
    public const string Cliente = "ligCliente"; // LOCALIZACAO 170523
    public const string Contato = "ligContato"; // LOCALIZACAO 170523
    public const string DataRealizada = "ligDataRealizada"; // LOCALIZACAO 170523
    public const string QuemID = "ligQuemID"; // LOCALIZACAO 170523
    public const string Telefonista = "ligTelefonista"; // LOCALIZACAO 170523
    public const string UltimoAviso = "ligUltimoAviso"; // LOCALIZACAO 170523
    public const string HoraFinal = "ligHoraFinal"; // LOCALIZACAO 170523
    public const string Nome = "ligNome"; // LOCALIZACAO 170523
    public const string QuemCodigo = "ligQuemCodigo"; // LOCALIZACAO 170523
    public const string Solicitante = "ligSolicitante"; // LOCALIZACAO 170523
    public const string Para = "ligPara"; // LOCALIZACAO 170523
    public const string Fone = "ligFone"; // LOCALIZACAO 170523
    public const string Ramal = "ligRamal"; // LOCALIZACAO 170523
    public const string Particular = "ligParticular"; // LOCALIZACAO 170523
    public const string Realizada = "ligRealizada"; // LOCALIZACAO 170523
    public const string Status = "ligStatus"; // LOCALIZACAO 170523
    public const string Data = "ligData"; // LOCALIZACAO 170523
    public const string Hora = "ligHora"; // LOCALIZACAO 170523
    public const string Urgente = "ligUrgente"; // LOCALIZACAO 170523
    public const string LigarPara = "ligLigarPara"; // LOCALIZACAO 170523
    public const string Processo = "ligProcesso"; // LOCALIZACAO 170523
    public const string StartScreen = "ligStartScreen"; // LOCALIZACAO 170523
    public const string Emotion = "ligEmotion"; // LOCALIZACAO 170523
    public const string Bold = "ligBold"; // LOCALIZACAO 170523
    public const string GUID = "ligGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ligQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ligDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ligQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ligDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ligVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Assunto,
        2 => AgeClienteAvisado,
        3 => Celular,
        4 => Cliente,
        5 => Contato,
        6 => DataRealizada,
        7 => QuemID,
        8 => Telefonista,
        9 => UltimoAviso,
        10 => HoraFinal,
        11 => Nome,
        12 => QuemCodigo,
        13 => Solicitante,
        14 => Para,
        15 => Fone,
        16 => Ramal,
        17 => Particular,
        18 => Realizada,
        19 => Status,
        20 => Data,
        21 => Hora,
        22 => Urgente,
        23 => LigarPara,
        24 => Processo,
        25 => StartScreen,
        26 => Emotion,
        27 => Bold,
        28 => GUID,
        29 => QuemCad,
        30 => DtCad,
        31 => QuemAtu,
        32 => DtAtu,
        33 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Ligacoes";
#region PropriedadesDaTabela
    public static DBInfoSystem LigAssunto => new(0, PTabelaNome, CampoCodigo, Assunto, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigAgeClienteAvisado => new(0, PTabelaNome, CampoCodigo, AgeClienteAvisado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigCelular => new(0, PTabelaNome, CampoCodigo, Celular, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "lig"
    };
    public static DBInfoSystem LigCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "lig"
    }; // DBI 11 
    public static DBInfoSystem LigContato => new(0, PTabelaNome, CampoCodigo, Contato, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigDataRealizada => new(0, PTabelaNome, CampoCodigo, DataRealizada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigQuemID => new(0, PTabelaNome, CampoCodigo, QuemID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigTelefonista => new(0, PTabelaNome, CampoCodigo, Telefonista, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigUltimoAviso => new(0, PTabelaNome, CampoCodigo, UltimoAviso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigHoraFinal => new(0, PTabelaNome, CampoCodigo, HoraFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigQuemCodigo => new(0, PTabelaNome, CampoCodigo, QuemCodigo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigSolicitante => new(0, PTabelaNome, CampoCodigo, Solicitante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigPara => new(0, PTabelaNome, CampoCodigo, Para, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigRamal => new(0, PTabelaNome, CampoCodigo, Ramal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBRamalDicInfo.CampoCodigo, DBRamalDicInfo.TabelaNome, new DBRamalODicInfo(), false)
    {
        Prefixo = "lig"
    }; // DBI 11 
    public static DBInfoSystem LigParticular => new(0, PTabelaNome, CampoCodigo, Particular, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "lig"
    };
    public static DBInfoSystem LigRealizada => new(0, PTabelaNome, CampoCodigo, Realizada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "lig"
    };
    public static DBInfoSystem LigStatus => new(0, PTabelaNome, CampoCodigo, Status, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigUrgente => new(0, PTabelaNome, CampoCodigo, Urgente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "lig"
    };
    public static DBInfoSystem LigLigarPara => new(0, PTabelaNome, CampoCodigo, LigarPara, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "lig"
    }; // DBI 11 
    public static DBInfoSystem LigStartScreen => new(0, PTabelaNome, CampoCodigo, StartScreen, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigEmotion => new(0, PTabelaNome, CampoCodigo, Emotion, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "lig"
    };
    public static DBInfoSystem LigGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "lig"
    }; // DBI 11 
    public static DBInfoSystem LigDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "lig"
    }; // DBI 11 
    public static DBInfoSystem LigDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "lig"
    };
    public static DBInfoSystem LigVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "lig"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        LigAssunto = 1,
        LigAgeClienteAvisado = 2,
        LigCelular = 3,
        LigCliente = 4,
        LigContato = 5,
        LigDataRealizada = 6,
        LigQuemID = 7,
        LigTelefonista = 8,
        LigUltimoAviso = 9,
        LigHoraFinal = 10,
        LigNome = 11,
        LigQuemCodigo = 12,
        LigSolicitante = 13,
        LigPara = 14,
        LigFone = 15,
        LigRamal = 16,
        LigParticular = 17,
        LigRealizada = 18,
        LigStatus = 19,
        LigData = 20,
        LigHora = 21,
        LigUrgente = 22,
        LigLigarPara = 23,
        LigProcesso = 24,
        LigStartScreen = 25,
        LigEmotion = 26,
        LigBold = 27,
        LigGUID = 28,
        LigQuemCad = 29,
        LigDtCad = 30,
        LigQuemAtu = 31,
        LigDtAtu = 32,
        LigVisto = 33
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.LigAssunto => LigAssunto,
        NomesCamposTabela.LigAgeClienteAvisado => LigAgeClienteAvisado,
        NomesCamposTabela.LigCelular => LigCelular,
        NomesCamposTabela.LigCliente => LigCliente,
        NomesCamposTabela.LigContato => LigContato,
        NomesCamposTabela.LigDataRealizada => LigDataRealizada,
        NomesCamposTabela.LigQuemID => LigQuemID,
        NomesCamposTabela.LigTelefonista => LigTelefonista,
        NomesCamposTabela.LigUltimoAviso => LigUltimoAviso,
        NomesCamposTabela.LigHoraFinal => LigHoraFinal,
        NomesCamposTabela.LigNome => LigNome,
        NomesCamposTabela.LigQuemCodigo => LigQuemCodigo,
        NomesCamposTabela.LigSolicitante => LigSolicitante,
        NomesCamposTabela.LigPara => LigPara,
        NomesCamposTabela.LigFone => LigFone,
        NomesCamposTabela.LigRamal => LigRamal,
        NomesCamposTabela.LigParticular => LigParticular,
        NomesCamposTabela.LigRealizada => LigRealizada,
        NomesCamposTabela.LigStatus => LigStatus,
        NomesCamposTabela.LigData => LigData,
        NomesCamposTabela.LigHora => LigHora,
        NomesCamposTabela.LigUrgente => LigUrgente,
        NomesCamposTabela.LigLigarPara => LigLigarPara,
        NomesCamposTabela.LigProcesso => LigProcesso,
        NomesCamposTabela.LigStartScreen => LigStartScreen,
        NomesCamposTabela.LigEmotion => LigEmotion,
        NomesCamposTabela.LigBold => LigBold,
        NomesCamposTabela.LigGUID => LigGUID,
        NomesCamposTabela.LigQuemCad => LigQuemCad,
        NomesCamposTabela.LigDtCad => LigDtCad,
        NomesCamposTabela.LigQuemAtu => LigQuemAtu,
        NomesCamposTabela.LigDtAtu => LigDtAtu,
        NomesCamposTabela.LigVisto => LigVisto,
        _ => null
    };
}