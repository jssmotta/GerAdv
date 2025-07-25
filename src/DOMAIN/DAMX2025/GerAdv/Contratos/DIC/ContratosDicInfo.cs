using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBContratosDicInfo
{
    public const string CampoCodigo = "cttCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ctt";
    public const string Processo = "cttProcesso"; // LOCALIZACAO 170523
    public const string Cliente = "cttCliente"; // LOCALIZACAO 170523
    public const string Advogado = "cttAdvogado"; // LOCALIZACAO 170523
    public const string Dia = "cttDia"; // LOCALIZACAO 170523
    public const string Valor = "cttValor"; // LOCALIZACAO 170523
    public const string DataInicio = "cttDataInicio"; // LOCALIZACAO 170523
    public const string DataTermino = "cttDataTermino"; // LOCALIZACAO 170523
    public const string OcultarRelatorio = "cttOcultarRelatorio"; // LOCALIZACAO 170523
    public const string PercEscritorio = "cttPercEscritorio"; // LOCALIZACAO 170523
    public const string ValorConsultoria = "cttValorConsultoria"; // LOCALIZACAO 170523
    public const string TipoCobranca = "cttTipoCobranca"; // LOCALIZACAO 170523
    public const string Protestar = "cttProtestar"; // LOCALIZACAO 170523
    public const string Juros = "cttJuros"; // LOCALIZACAO 170523
    public const string ValorRealizavel = "cttValorRealizavel"; // LOCALIZACAO 170523
    public const string DOCUMENTO = "cttDOCUMENTO"; // LOCALIZACAO 170523
    public const string EMail1 = "cttEMail1"; // LOCALIZACAO 170523
    public const string EMail2 = "cttEMail2"; // LOCALIZACAO 170523
    public const string EMail3 = "cttEMail3"; // LOCALIZACAO 170523
    public const string Pessoa1 = "cttPessoa1"; // LOCALIZACAO 170523
    public const string Pessoa2 = "cttPessoa2"; // LOCALIZACAO 170523
    public const string Pessoa3 = "cttPessoa3"; // LOCALIZACAO 170523
    public const string OBS = "cttOBS"; // LOCALIZACAO 170523
    public const string ClienteContrato = "cttClienteContrato"; // LOCALIZACAO 170523
    public const string IdExtrangeiro = "cttIdExtrangeiro"; // LOCALIZACAO 170523
    public const string ChaveContrato = "cttChaveContrato"; // LOCALIZACAO 170523
    public const string Avulso = "cttAvulso"; // LOCALIZACAO 170523
    public const string Suspenso = "cttSuspenso"; // LOCALIZACAO 170523
    public const string Multa = "cttMulta"; // LOCALIZACAO 170523
    public const string Bold = "cttBold"; // LOCALIZACAO 170523
    public const string GUID = "cttGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "cttQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "cttDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "cttQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "cttDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "cttVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Cliente,
        3 => Advogado,
        4 => Dia,
        5 => Valor,
        6 => DataInicio,
        7 => DataTermino,
        8 => OcultarRelatorio,
        9 => PercEscritorio,
        10 => ValorConsultoria,
        11 => TipoCobranca,
        12 => Protestar,
        13 => Juros,
        14 => ValorRealizavel,
        15 => DOCUMENTO,
        16 => EMail1,
        17 => EMail2,
        18 => EMail3,
        19 => Pessoa1,
        20 => Pessoa2,
        21 => Pessoa3,
        22 => OBS,
        23 => ClienteContrato,
        24 => IdExtrangeiro,
        25 => ChaveContrato,
        26 => Avulso,
        27 => Suspenso,
        28 => Multa,
        29 => Bold,
        30 => GUID,
        31 => QuemCad,
        32 => DtCad,
        33 => QuemAtu,
        34 => DtAtu,
        35 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Contratos";
#region PropriedadesDaTabela
    public static DBInfoSystem CttProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "ctt"
    }; // DBI 11 
    public static DBInfoSystem CttCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "ctt"
    }; // DBI 11 
    public static DBInfoSystem CttAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false)
    {
        Prefixo = "ctt"
    }; // DBI 11 
    public static DBInfoSystem CttDia => new(0, PTabelaNome, CampoCodigo, Dia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttDataInicio => new(0, PTabelaNome, CampoCodigo, DataInicio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttDataTermino => new(0, PTabelaNome, CampoCodigo, DataTermino, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttOcultarRelatorio => new(0, PTabelaNome, CampoCodigo, OcultarRelatorio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttPercEscritorio => new(0, PTabelaNome, CampoCodigo, PercEscritorio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttValorConsultoria => new(0, PTabelaNome, CampoCodigo, ValorConsultoria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttTipoCobranca => new(0, PTabelaNome, CampoCodigo, TipoCobranca, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttProtestar => new(0, PTabelaNome, CampoCodigo, Protestar, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttJuros => new(0, PTabelaNome, CampoCodigo, Juros, 5, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttValorRealizavel => new(0, PTabelaNome, CampoCodigo, ValorRealizavel, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttDOCUMENTO => new(0, PTabelaNome, CampoCodigo, DOCUMENTO, 15, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttEMail1 => new(0, PTabelaNome, CampoCodigo, EMail1, 300, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttEMail2 => new(0, PTabelaNome, CampoCodigo, EMail2, 300, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttEMail3 => new(0, PTabelaNome, CampoCodigo, EMail3, 300, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttPessoa1 => new(0, PTabelaNome, CampoCodigo, Pessoa1, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttPessoa2 => new(0, PTabelaNome, CampoCodigo, Pessoa2, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttPessoa3 => new(0, PTabelaNome, CampoCodigo, Pessoa3, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttClienteContrato => new(0, PTabelaNome, CampoCodigo, ClienteContrato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttIdExtrangeiro => new(0, PTabelaNome, CampoCodigo, IdExtrangeiro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttChaveContrato => new(0, PTabelaNome, CampoCodigo, ChaveContrato, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttAvulso => new(0, PTabelaNome, CampoCodigo, Avulso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttSuspenso => new(0, PTabelaNome, CampoCodigo, Suspenso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttMulta => new(0, PTabelaNome, CampoCodigo, Multa, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ctt"
    }; // DBI 11 
    public static DBInfoSystem CttDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ctt"
    }; // DBI 11 
    public static DBInfoSystem CttDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ctt"
    };
    public static DBInfoSystem CttVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ctt"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        CttProcesso = 1,
        CttCliente = 2,
        CttAdvogado = 3,
        CttDia = 4,
        CttValor = 5,
        CttDataInicio = 6,
        CttDataTermino = 7,
        CttOcultarRelatorio = 8,
        CttPercEscritorio = 9,
        CttValorConsultoria = 10,
        CttTipoCobranca = 11,
        CttProtestar = 12,
        CttJuros = 13,
        CttValorRealizavel = 14,
        CttDOCUMENTO = 15,
        CttEMail1 = 16,
        CttEMail2 = 17,
        CttEMail3 = 18,
        CttPessoa1 = 19,
        CttPessoa2 = 20,
        CttPessoa3 = 21,
        CttOBS = 22,
        CttClienteContrato = 23,
        CttIdExtrangeiro = 24,
        CttChaveContrato = 25,
        CttAvulso = 26,
        CttSuspenso = 27,
        CttMulta = 28,
        CttBold = 29,
        CttGUID = 30,
        CttQuemCad = 31,
        CttDtCad = 32,
        CttQuemAtu = 33,
        CttDtAtu = 34,
        CttVisto = 35
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CttProcesso => CttProcesso,
        NomesCamposTabela.CttCliente => CttCliente,
        NomesCamposTabela.CttAdvogado => CttAdvogado,
        NomesCamposTabela.CttDia => CttDia,
        NomesCamposTabela.CttValor => CttValor,
        NomesCamposTabela.CttDataInicio => CttDataInicio,
        NomesCamposTabela.CttDataTermino => CttDataTermino,
        NomesCamposTabela.CttOcultarRelatorio => CttOcultarRelatorio,
        NomesCamposTabela.CttPercEscritorio => CttPercEscritorio,
        NomesCamposTabela.CttValorConsultoria => CttValorConsultoria,
        NomesCamposTabela.CttTipoCobranca => CttTipoCobranca,
        NomesCamposTabela.CttProtestar => CttProtestar,
        NomesCamposTabela.CttJuros => CttJuros,
        NomesCamposTabela.CttValorRealizavel => CttValorRealizavel,
        NomesCamposTabela.CttDOCUMENTO => CttDOCUMENTO,
        NomesCamposTabela.CttEMail1 => CttEMail1,
        NomesCamposTabela.CttEMail2 => CttEMail2,
        NomesCamposTabela.CttEMail3 => CttEMail3,
        NomesCamposTabela.CttPessoa1 => CttPessoa1,
        NomesCamposTabela.CttPessoa2 => CttPessoa2,
        NomesCamposTabela.CttPessoa3 => CttPessoa3,
        NomesCamposTabela.CttOBS => CttOBS,
        NomesCamposTabela.CttClienteContrato => CttClienteContrato,
        NomesCamposTabela.CttIdExtrangeiro => CttIdExtrangeiro,
        NomesCamposTabela.CttChaveContrato => CttChaveContrato,
        NomesCamposTabela.CttAvulso => CttAvulso,
        NomesCamposTabela.CttSuspenso => CttSuspenso,
        NomesCamposTabela.CttMulta => CttMulta,
        NomesCamposTabela.CttBold => CttBold,
        NomesCamposTabela.CttGUID => CttGUID,
        NomesCamposTabela.CttQuemCad => CttQuemCad,
        NomesCamposTabela.CttDtCad => CttDtCad,
        NomesCamposTabela.CttQuemAtu => CttQuemAtu,
        NomesCamposTabela.CttDtAtu => CttDtAtu,
        NomesCamposTabela.CttVisto => CttVisto,
        _ => null
    };
}