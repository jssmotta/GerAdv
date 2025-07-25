using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBRecadosDicInfo
{
    public const string CampoCodigo = "recCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "rec";
    public const string ClienteNome = "recClienteNome"; // LOCALIZACAO 170523
    public const string De = "recDe"; // LOCALIZACAO 170523
    public const string Para = "recPara"; // LOCALIZACAO 170523
    public const string Assunto = "recAssunto"; // LOCALIZACAO 170523
    public const string Concluido = "recConcluido"; // LOCALIZACAO 170523
    public const string Processo = "recProcesso"; // LOCALIZACAO 170523
    public const string Cliente = "recCliente"; // LOCALIZACAO 170523
    public const string Recado = "recRecado"; // LOCALIZACAO 170523
    public const string Urgente = "recUrgente"; // LOCALIZACAO 170523
    public const string Importante = "recImportante"; // LOCALIZACAO 170523
    public const string Hora = "recHora"; // LOCALIZACAO 170523
    public const string Data = "recData"; // LOCALIZACAO 170523
    public const string Voltara = "recVoltara"; // LOCALIZACAO 170523
    public const string Pessoal = "recPessoal"; // LOCALIZACAO 170523
    public const string Retornar = "recRetornar"; // LOCALIZACAO 170523
    public const string RetornoData = "recRetornoData"; // LOCALIZACAO 170523
    public const string Emotion = "recEmotion"; // LOCALIZACAO 170523
    public const string InternetID = "recInternetID"; // LOCALIZACAO 170523
    public const string Uploaded = "recUploaded"; // LOCALIZACAO 170523
    public const string Natureza = "recNatureza"; // LOCALIZACAO 170523
    public const string BIU = "recBIU"; // LOCALIZACAO 170523
    public const string AguardarRetorno = "recAguardarRetorno"; // LOCALIZACAO 170523
    public const string AguardarRetornoPara = "recAguardarRetornoPara"; // LOCALIZACAO 170523
    public const string AguardarRetornoOK = "recAguardarRetornoOK"; // LOCALIZACAO 170523
    public const string ParaID = "recParaID"; // LOCALIZACAO 170523
    public const string NaoPublicavel = "recNaoPublicavel"; // LOCALIZACAO 170523
    public const string IsContatoCRM = "recIsContatoCRM"; // LOCALIZACAO 170523
    public const string MasterID = "recMasterID"; // LOCALIZACAO 170523
    public const string ListaPara = "recListaPara"; // LOCALIZACAO 170523
    public const string Typed = "recTyped"; // LOCALIZACAO 170523
    public const string AssuntoRecado = "recAssuntoRecado"; // LOCALIZACAO 170523
    public const string Historico = "recHistorico"; // LOCALIZACAO 170523
    public const string ContatoCRM = "recContatoCRM"; // LOCALIZACAO 170523
    public const string Ligacoes = "recLigacoes"; // LOCALIZACAO 170523
    public const string Agenda = "recAgenda"; // LOCALIZACAO 170523
    public const string GUID = "recGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "recQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "recDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "recQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "recDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "recVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => ClienteNome,
        2 => De,
        3 => Para,
        4 => Assunto,
        5 => Concluido,
        6 => Processo,
        7 => Cliente,
        8 => Recado,
        9 => Urgente,
        10 => Importante,
        11 => Hora,
        12 => Data,
        13 => Voltara,
        14 => Pessoal,
        15 => Retornar,
        16 => RetornoData,
        17 => Emotion,
        18 => InternetID,
        19 => Uploaded,
        20 => Natureza,
        21 => BIU,
        22 => AguardarRetorno,
        23 => AguardarRetornoPara,
        24 => AguardarRetornoOK,
        25 => ParaID,
        26 => NaoPublicavel,
        27 => IsContatoCRM,
        28 => MasterID,
        29 => ListaPara,
        30 => Typed,
        31 => AssuntoRecado,
        32 => Historico,
        33 => ContatoCRM,
        34 => Ligacoes,
        35 => Agenda,
        36 => GUID,
        37 => QuemCad,
        38 => DtCad,
        39 => QuemAtu,
        40 => DtAtu,
        41 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Recados";
#region PropriedadesDaTabela
    public static DBInfoSystem RecClienteNome => new(0, PTabelaNome, CampoCodigo, ClienteNome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecDe => new(0, PTabelaNome, CampoCodigo, De, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecPara => new(0, PTabelaNome, CampoCodigo, Para, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecAssunto => new(0, PTabelaNome, CampoCodigo, Assunto, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecConcluido => new(0, PTabelaNome, CampoCodigo, Concluido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "rec"
    }; // DBI 11 
    public static DBInfoSystem RecCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "rec"
    }; // DBI 11 
    public static DBInfoSystem RecRecado => new(0, PTabelaNome, CampoCodigo, Recado, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecUrgente => new(0, PTabelaNome, CampoCodigo, Urgente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecImportante => new(0, PTabelaNome, CampoCodigo, Importante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecVoltara => new(0, PTabelaNome, CampoCodigo, Voltara, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecPessoal => new(0, PTabelaNome, CampoCodigo, Pessoal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecRetornar => new(0, PTabelaNome, CampoCodigo, Retornar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecRetornoData => new(0, PTabelaNome, CampoCodigo, RetornoData, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecEmotion => new(0, PTabelaNome, CampoCodigo, Emotion, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecInternetID => new(0, PTabelaNome, CampoCodigo, InternetID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecUploaded => new(0, PTabelaNome, CampoCodigo, Uploaded, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecNatureza => new(0, PTabelaNome, CampoCodigo, Natureza, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecBIU => new(0, PTabelaNome, CampoCodigo, BIU, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecAguardarRetorno => new(0, PTabelaNome, CampoCodigo, AguardarRetorno, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecAguardarRetornoPara => new(0, PTabelaNome, CampoCodigo, AguardarRetornoPara, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecAguardarRetornoOK => new(0, PTabelaNome, CampoCodigo, AguardarRetornoOK, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecParaID => new(0, PTabelaNome, CampoCodigo, ParaID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecNaoPublicavel => new(0, PTabelaNome, CampoCodigo, NaoPublicavel, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecIsContatoCRM => new(0, PTabelaNome, CampoCodigo, IsContatoCRM, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecMasterID => new(0, PTabelaNome, CampoCodigo, MasterID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecListaPara => new(0, PTabelaNome, CampoCodigo, ListaPara, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecTyped => new(0, PTabelaNome, CampoCodigo, Typed, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "rec"
    };
    public static DBInfoSystem RecAssuntoRecado => new(0, PTabelaNome, CampoCodigo, AssuntoRecado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecHistorico => new(0, PTabelaNome, CampoCodigo, Historico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBHistoricoDicInfo.CampoCodigo, DBHistoricoDicInfo.TabelaNome, new DBHistoricoODicInfo(), false)
    {
        Prefixo = "rec"
    }; // DBI 11 
    public static DBInfoSystem RecContatoCRM => new(0, PTabelaNome, CampoCodigo, ContatoCRM, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBContatoCRMDicInfo.CampoCodigo, DBContatoCRMDicInfo.TabelaNome, new DBContatoCRMODicInfo(), false)
    {
        Prefixo = "rec"
    }; // DBI 11 
    public static DBInfoSystem RecLigacoes => new(0, PTabelaNome, CampoCodigo, Ligacoes, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBLigacoesDicInfo.CampoCodigo, DBLigacoesDicInfo.TabelaNome, new DBLigacoesODicInfo(), false)
    {
        Prefixo = "rec"
    }; // DBI 11 
    public static DBInfoSystem RecAgenda => new(0, PTabelaNome, CampoCodigo, Agenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAgendaDicInfo.CampoCodigo, DBAgendaDicInfo.TabelaNome, new DBAgendaODicInfo(), false)
    {
        Prefixo = "rec"
    }; // DBI 11 
    public static DBInfoSystem RecGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "rec"
    }; // DBI 11 
    public static DBInfoSystem RecDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "rec"
    }; // DBI 11 
    public static DBInfoSystem RecDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "rec"
    };
    public static DBInfoSystem RecVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "rec"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        RecClienteNome = 1,
        RecDe = 2,
        RecPara = 3,
        RecAssunto = 4,
        RecConcluido = 5,
        RecProcesso = 6,
        RecCliente = 7,
        RecRecado = 8,
        RecUrgente = 9,
        RecImportante = 10,
        RecHora = 11,
        RecData = 12,
        RecVoltara = 13,
        RecPessoal = 14,
        RecRetornar = 15,
        RecRetornoData = 16,
        RecEmotion = 17,
        RecInternetID = 18,
        RecUploaded = 19,
        RecNatureza = 20,
        RecBIU = 21,
        RecAguardarRetorno = 22,
        RecAguardarRetornoPara = 23,
        RecAguardarRetornoOK = 24,
        RecParaID = 25,
        RecNaoPublicavel = 26,
        RecIsContatoCRM = 27,
        RecMasterID = 28,
        RecListaPara = 29,
        RecTyped = 30,
        RecAssuntoRecado = 31,
        RecHistorico = 32,
        RecContatoCRM = 33,
        RecLigacoes = 34,
        RecAgenda = 35,
        RecGUID = 36,
        RecQuemCad = 37,
        RecDtCad = 38,
        RecQuemAtu = 39,
        RecDtAtu = 40,
        RecVisto = 41
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RecClienteNome => RecClienteNome,
        NomesCamposTabela.RecDe => RecDe,
        NomesCamposTabela.RecPara => RecPara,
        NomesCamposTabela.RecAssunto => RecAssunto,
        NomesCamposTabela.RecConcluido => RecConcluido,
        NomesCamposTabela.RecProcesso => RecProcesso,
        NomesCamposTabela.RecCliente => RecCliente,
        NomesCamposTabela.RecRecado => RecRecado,
        NomesCamposTabela.RecUrgente => RecUrgente,
        NomesCamposTabela.RecImportante => RecImportante,
        NomesCamposTabela.RecHora => RecHora,
        NomesCamposTabela.RecData => RecData,
        NomesCamposTabela.RecVoltara => RecVoltara,
        NomesCamposTabela.RecPessoal => RecPessoal,
        NomesCamposTabela.RecRetornar => RecRetornar,
        NomesCamposTabela.RecRetornoData => RecRetornoData,
        NomesCamposTabela.RecEmotion => RecEmotion,
        NomesCamposTabela.RecInternetID => RecInternetID,
        NomesCamposTabela.RecUploaded => RecUploaded,
        NomesCamposTabela.RecNatureza => RecNatureza,
        NomesCamposTabela.RecBIU => RecBIU,
        NomesCamposTabela.RecAguardarRetorno => RecAguardarRetorno,
        NomesCamposTabela.RecAguardarRetornoPara => RecAguardarRetornoPara,
        NomesCamposTabela.RecAguardarRetornoOK => RecAguardarRetornoOK,
        NomesCamposTabela.RecParaID => RecParaID,
        NomesCamposTabela.RecNaoPublicavel => RecNaoPublicavel,
        NomesCamposTabela.RecIsContatoCRM => RecIsContatoCRM,
        NomesCamposTabela.RecMasterID => RecMasterID,
        NomesCamposTabela.RecListaPara => RecListaPara,
        NomesCamposTabela.RecTyped => RecTyped,
        NomesCamposTabela.RecAssuntoRecado => RecAssuntoRecado,
        NomesCamposTabela.RecHistorico => RecHistorico,
        NomesCamposTabela.RecContatoCRM => RecContatoCRM,
        NomesCamposTabela.RecLigacoes => RecLigacoes,
        NomesCamposTabela.RecAgenda => RecAgenda,
        NomesCamposTabela.RecGUID => RecGUID,
        NomesCamposTabela.RecQuemCad => RecQuemCad,
        NomesCamposTabela.RecDtCad => RecDtCad,
        NomesCamposTabela.RecQuemAtu => RecQuemAtu,
        NomesCamposTabela.RecDtAtu => RecDtAtu,
        NomesCamposTabela.RecVisto => RecVisto,
        _ => null
    };
}