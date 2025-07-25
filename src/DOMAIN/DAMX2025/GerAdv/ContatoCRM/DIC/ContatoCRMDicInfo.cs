using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBContatoCRMDicInfo
{
    public const string CampoCodigo = "ctcCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ctc";
    public const string AgeClienteAvisado = "ctcAgeClienteAvisado"; // LOCALIZACAO 170523
    public const string DocsViaRecebimento = "ctcDocsViaRecebimento"; // LOCALIZACAO 170523
    public const string NaoPublicavel = "ctcNaoPublicavel"; // LOCALIZACAO 170523
    public const string Notificar = "ctcNotificar"; // LOCALIZACAO 170523
    public const string Ocultar = "ctcOcultar"; // LOCALIZACAO 170523
    public const string Assunto = "ctcAssunto"; // LOCALIZACAO 170523
    public const string IsDocsRecebidos = "ctcIsDocsRecebidos"; // LOCALIZACAO 170523
    public const string QuemNotificou = "ctcQuemNotificou"; // LOCALIZACAO 170523
    public const string DataNotificou = "ctcDataNotificou"; // LOCALIZACAO 170523
    public const string Operador = "ctcOperador"; // LOCALIZACAO 170523
    public const string Cliente = "ctcCliente"; // LOCALIZACAO 170523
    public const string HoraNotificou = "ctcHoraNotificou"; // LOCALIZACAO 170523
    public const string ObjetoNotificou = "ctcObjetoNotificou"; // LOCALIZACAO 170523
    public const string PessoaContato = "ctcPessoaContato"; // LOCALIZACAO 170523
    public const string Data = "ctcData"; // LOCALIZACAO 170523
    public const string Tempo = "ctcTempo"; // LOCALIZACAO 170523
    public const string HoraInicial = "ctcHoraInicial"; // LOCALIZACAO 170523
    public const string HoraFinal = "ctcHoraFinal"; // LOCALIZACAO 170523
    public const string Processo = "ctcProcesso"; // LOCALIZACAO 170523
    public const string Importante = "ctcImportante"; // LOCALIZACAO 170523
    public const string Urgente = "ctcUrgente"; // LOCALIZACAO 170523
    public const string GerarHoraTrabalhada = "ctcGerarHoraTrabalhada"; // LOCALIZACAO 170523
    public const string ExibirNoTopo = "ctcExibirNoTopo"; // LOCALIZACAO 170523
    public const string TipoContatoCRM = "ctcTipoContatoCRM"; // LOCALIZACAO 170523
    public const string Contato = "ctcContato"; // LOCALIZACAO 170523
    public const string Emocao = "ctcEmocao"; // LOCALIZACAO 170523
    public const string Continuar = "ctcContinuar"; // LOCALIZACAO 170523
    public const string Bold = "ctcBold"; // LOCALIZACAO 170523
    public const string GUID = "ctcGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ctcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ctcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ctcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ctcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ctcVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => AgeClienteAvisado,
        2 => DocsViaRecebimento,
        3 => NaoPublicavel,
        4 => Notificar,
        5 => Ocultar,
        6 => Assunto,
        7 => IsDocsRecebidos,
        8 => QuemNotificou,
        9 => DataNotificou,
        10 => Operador,
        11 => Cliente,
        12 => HoraNotificou,
        13 => ObjetoNotificou,
        14 => PessoaContato,
        15 => Data,
        16 => Tempo,
        17 => HoraInicial,
        18 => HoraFinal,
        19 => Processo,
        20 => Importante,
        21 => Urgente,
        22 => GerarHoraTrabalhada,
        23 => ExibirNoTopo,
        24 => TipoContatoCRM,
        25 => Contato,
        26 => Emocao,
        27 => Continuar,
        28 => Bold,
        29 => GUID,
        30 => QuemCad,
        31 => DtCad,
        32 => QuemAtu,
        33 => DtAtu,
        34 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ContatoCRM";
#region PropriedadesDaTabela
    public static DBInfoSystem CtcAgeClienteAvisado => new(0, PTabelaNome, CampoCodigo, AgeClienteAvisado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcDocsViaRecebimento => new(0, PTabelaNome, CampoCodigo, DocsViaRecebimento, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcNaoPublicavel => new(0, PTabelaNome, CampoCodigo, NaoPublicavel, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcNotificar => new(0, PTabelaNome, CampoCodigo, Notificar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcOcultar => new(0, PTabelaNome, CampoCodigo, Ocultar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcAssunto => new(0, PTabelaNome, CampoCodigo, Assunto, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcIsDocsRecebidos => new(0, PTabelaNome, CampoCodigo, IsDocsRecebidos, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcQuemNotificou => new(0, PTabelaNome, CampoCodigo, QuemNotificou, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcDataNotificou => new(0, PTabelaNome, CampoCodigo, DataNotificou, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ctc"
    }; // DBI 11 
    public static DBInfoSystem CtcCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "ctc"
    }; // DBI 11 
    public static DBInfoSystem CtcHoraNotificou => new(0, PTabelaNome, CampoCodigo, HoraNotificou, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcObjetoNotificou => new(0, PTabelaNome, CampoCodigo, ObjetoNotificou, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcPessoaContato => new(0, PTabelaNome, CampoCodigo, PessoaContato, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcTempo => new(0, PTabelaNome, CampoCodigo, Tempo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcHoraInicial => new(0, PTabelaNome, CampoCodigo, HoraInicial, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcHoraFinal => new(0, PTabelaNome, CampoCodigo, HoraFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "ctc"
    }; // DBI 11 
    public static DBInfoSystem CtcImportante => new(0, PTabelaNome, CampoCodigo, Importante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcUrgente => new(0, PTabelaNome, CampoCodigo, Urgente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcGerarHoraTrabalhada => new(0, PTabelaNome, CampoCodigo, GerarHoraTrabalhada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcExibirNoTopo => new(0, PTabelaNome, CampoCodigo, ExibirNoTopo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcTipoContatoCRM => new(0, PTabelaNome, CampoCodigo, TipoContatoCRM, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoContatoCRMDicInfo.CampoCodigo, DBTipoContatoCRMDicInfo.TabelaNome, new DBTipoContatoCRMODicInfo(), false)
    {
        Prefixo = "ctc"
    }; // DBI 11 
    public static DBInfoSystem CtcContato => new(0, PTabelaNome, CampoCodigo, Contato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcEmocao => new(0, PTabelaNome, CampoCodigo, Emocao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcContinuar => new(0, PTabelaNome, CampoCodigo, Continuar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ctc"
    }; // DBI 11 
    public static DBInfoSystem CtcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ctc"
    }; // DBI 11 
    public static DBInfoSystem CtcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ctc"
    };
    public static DBInfoSystem CtcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ctc"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        CtcAgeClienteAvisado = 1,
        CtcDocsViaRecebimento = 2,
        CtcNaoPublicavel = 3,
        CtcNotificar = 4,
        CtcOcultar = 5,
        CtcAssunto = 6,
        CtcIsDocsRecebidos = 7,
        CtcQuemNotificou = 8,
        CtcDataNotificou = 9,
        CtcOperador = 10,
        CtcCliente = 11,
        CtcHoraNotificou = 12,
        CtcObjetoNotificou = 13,
        CtcPessoaContato = 14,
        CtcData = 15,
        CtcTempo = 16,
        CtcHoraInicial = 17,
        CtcHoraFinal = 18,
        CtcProcesso = 19,
        CtcImportante = 20,
        CtcUrgente = 21,
        CtcGerarHoraTrabalhada = 22,
        CtcExibirNoTopo = 23,
        CtcTipoContatoCRM = 24,
        CtcContato = 25,
        CtcEmocao = 26,
        CtcContinuar = 27,
        CtcBold = 28,
        CtcGUID = 29,
        CtcQuemCad = 30,
        CtcDtCad = 31,
        CtcQuemAtu = 32,
        CtcDtAtu = 33,
        CtcVisto = 34
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CtcAgeClienteAvisado => CtcAgeClienteAvisado,
        NomesCamposTabela.CtcDocsViaRecebimento => CtcDocsViaRecebimento,
        NomesCamposTabela.CtcNaoPublicavel => CtcNaoPublicavel,
        NomesCamposTabela.CtcNotificar => CtcNotificar,
        NomesCamposTabela.CtcOcultar => CtcOcultar,
        NomesCamposTabela.CtcAssunto => CtcAssunto,
        NomesCamposTabela.CtcIsDocsRecebidos => CtcIsDocsRecebidos,
        NomesCamposTabela.CtcQuemNotificou => CtcQuemNotificou,
        NomesCamposTabela.CtcDataNotificou => CtcDataNotificou,
        NomesCamposTabela.CtcOperador => CtcOperador,
        NomesCamposTabela.CtcCliente => CtcCliente,
        NomesCamposTabela.CtcHoraNotificou => CtcHoraNotificou,
        NomesCamposTabela.CtcObjetoNotificou => CtcObjetoNotificou,
        NomesCamposTabela.CtcPessoaContato => CtcPessoaContato,
        NomesCamposTabela.CtcData => CtcData,
        NomesCamposTabela.CtcTempo => CtcTempo,
        NomesCamposTabela.CtcHoraInicial => CtcHoraInicial,
        NomesCamposTabela.CtcHoraFinal => CtcHoraFinal,
        NomesCamposTabela.CtcProcesso => CtcProcesso,
        NomesCamposTabela.CtcImportante => CtcImportante,
        NomesCamposTabela.CtcUrgente => CtcUrgente,
        NomesCamposTabela.CtcGerarHoraTrabalhada => CtcGerarHoraTrabalhada,
        NomesCamposTabela.CtcExibirNoTopo => CtcExibirNoTopo,
        NomesCamposTabela.CtcTipoContatoCRM => CtcTipoContatoCRM,
        NomesCamposTabela.CtcContato => CtcContato,
        NomesCamposTabela.CtcEmocao => CtcEmocao,
        NomesCamposTabela.CtcContinuar => CtcContinuar,
        NomesCamposTabela.CtcBold => CtcBold,
        NomesCamposTabela.CtcGUID => CtcGUID,
        NomesCamposTabela.CtcQuemCad => CtcQuemCad,
        NomesCamposTabela.CtcDtCad => CtcDtCad,
        NomesCamposTabela.CtcQuemAtu => CtcQuemAtu,
        NomesCamposTabela.CtcDtAtu => CtcDtAtu,
        NomesCamposTabela.CtcVisto => CtcVisto,
        _ => null
    };
}