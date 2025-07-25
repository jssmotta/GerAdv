using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOponentesDicInfo
{
    public const string CampoCodigo = "opoCodigo";
    public const string CampoNome = "opoNome";
    public const string TablePrefix = "opo";
    public const string EMPFuncao = "opoEMPFuncao"; // LOCALIZACAO 170523
    public const string CTPSNumero = "opoCTPSNumero"; // LOCALIZACAO 170523
    public const string Site = "opoSite"; // LOCALIZACAO 170523
    public const string CTPSSerie = "opoCTPSSerie"; // LOCALIZACAO 170523
    public const string Nome = "opoNome"; // LOCALIZACAO 170523
    public const string Adv = "opoAdv"; // LOCALIZACAO 170523
    public const string EMPCliente = "opoEMPCliente"; // LOCALIZACAO 170523
    public const string IDRep = "opoIDRep"; // LOCALIZACAO 170523
    public const string PIS = "opoPIS"; // LOCALIZACAO 170523
    public const string Contato = "opoContato"; // LOCALIZACAO 170523
    public const string CNPJ = "opoCNPJ"; // LOCALIZACAO 170523
    public const string RG = "opoRG"; // LOCALIZACAO 170523
    public const string Juridica = "opoJuridica"; // LOCALIZACAO 170523
    public const string Tipo = "opoTipo"; // LOCALIZACAO 170523
    public const string Sexo = "opoSexo"; // LOCALIZACAO 170523
    public const string CPF = "opoCPF"; // LOCALIZACAO 170523
    public const string Endereco = "opoEndereco"; // LOCALIZACAO 170523
    public const string Fone = "opoFone"; // LOCALIZACAO 170523
    public const string Fax = "opoFax"; // LOCALIZACAO 170523
    public const string Cidade = "opoCidade"; // LOCALIZACAO 170523
    public const string Bairro = "opoBairro"; // LOCALIZACAO 170523
    public const string CEP = "opoCEP"; // LOCALIZACAO 170523
    public const string InscEst = "opoInscEst"; // LOCALIZACAO 170523
    public const string Observacao = "opoObservacao"; // LOCALIZACAO 170523
    public const string EMail = "opoEMail"; // LOCALIZACAO 170523
    public const string Class = "opoClass"; // LOCALIZACAO 170523
    public const string Top = "opoTop"; // LOCALIZACAO 170523
    public const string Etiqueta = "opoEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "opoBold"; // LOCALIZACAO 170523
    public const string GUID = "opoGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "opoQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "opoDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "opoQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "opoDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "opoVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => EMPFuncao,
        2 => CTPSNumero,
        3 => Site,
        4 => CTPSSerie,
        5 => Nome,
        6 => Adv,
        7 => EMPCliente,
        8 => IDRep,
        9 => PIS,
        10 => Contato,
        11 => CNPJ,
        12 => RG,
        13 => Juridica,
        14 => Tipo,
        15 => Sexo,
        16 => CPF,
        17 => Endereco,
        18 => Fone,
        19 => Fax,
        20 => Cidade,
        21 => Bairro,
        22 => CEP,
        23 => InscEst,
        24 => Observacao,
        25 => EMail,
        26 => Class,
        27 => Top,
        28 => Etiqueta,
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

    public const string PTabelaNome = "Oponentes";
#region PropriedadesDaTabela
    public static DBInfoSystem OpoEMPFuncao => new(0, PTabelaNome, CampoCodigo, EMPFuncao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCTPSNumero => new(0, PTabelaNome, CampoCodigo, CTPSNumero, 15, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCTPSSerie => new(0, PTabelaNome, CampoCodigo, CTPSSerie, 10, DevourerOne.PNroSerieCtps, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtpsserie, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoAdv => new(0, PTabelaNome, CampoCodigo, Adv, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoEMPCliente => new(0, PTabelaNome, CampoCodigo, EMPCliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoIDRep => new(0, PTabelaNome, CampoCodigo, IDRep, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoPIS => new(0, PTabelaNome, CampoCodigo, PIS, 20, DevourerOne.PNroPis, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextPis, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoContato => new(0, PTabelaNome, CampoCodigo, Contato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoRG => new(0, PTabelaNome, CampoCodigo, RG, 12, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoJuridica => new(0, PTabelaNome, CampoCodigo, Juridica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "opo"
    }; // DBI 11 
    public static DBInfoSystem OpoBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoEMail => new(0, PTabelaNome, CampoCodigo, EMail, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opo"
    }; // DBI 11 
    public static DBInfoSystem OpoDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opo"
    }; // DBI 11 
    public static DBInfoSystem OpoDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "opo"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        OpoEMPFuncao = 1,
        OpoCTPSNumero = 2,
        OpoSite = 3,
        OpoCTPSSerie = 4,
        OpoNome = 5,
        OpoAdv = 6,
        OpoEMPCliente = 7,
        OpoIDRep = 8,
        OpoPIS = 9,
        OpoContato = 10,
        OpoCNPJ = 11,
        OpoRG = 12,
        OpoJuridica = 13,
        OpoTipo = 14,
        OpoSexo = 15,
        OpoCPF = 16,
        OpoEndereco = 17,
        OpoFone = 18,
        OpoFax = 19,
        OpoCidade = 20,
        OpoBairro = 21,
        OpoCEP = 22,
        OpoInscEst = 23,
        OpoObservacao = 24,
        OpoEMail = 25,
        OpoClass = 26,
        OpoTop = 27,
        OpoEtiqueta = 28,
        OpoBold = 29,
        OpoGUID = 30,
        OpoQuemCad = 31,
        OpoDtCad = 32,
        OpoQuemAtu = 33,
        OpoDtAtu = 34,
        OpoVisto = 35
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OpoEMPFuncao => OpoEMPFuncao,
        NomesCamposTabela.OpoCTPSNumero => OpoCTPSNumero,
        NomesCamposTabela.OpoSite => OpoSite,
        NomesCamposTabela.OpoCTPSSerie => OpoCTPSSerie,
        NomesCamposTabela.OpoNome => OpoNome,
        NomesCamposTabela.OpoAdv => OpoAdv,
        NomesCamposTabela.OpoEMPCliente => OpoEMPCliente,
        NomesCamposTabela.OpoIDRep => OpoIDRep,
        NomesCamposTabela.OpoPIS => OpoPIS,
        NomesCamposTabela.OpoContato => OpoContato,
        NomesCamposTabela.OpoCNPJ => OpoCNPJ,
        NomesCamposTabela.OpoRG => OpoRG,
        NomesCamposTabela.OpoJuridica => OpoJuridica,
        NomesCamposTabela.OpoTipo => OpoTipo,
        NomesCamposTabela.OpoSexo => OpoSexo,
        NomesCamposTabela.OpoCPF => OpoCPF,
        NomesCamposTabela.OpoEndereco => OpoEndereco,
        NomesCamposTabela.OpoFone => OpoFone,
        NomesCamposTabela.OpoFax => OpoFax,
        NomesCamposTabela.OpoCidade => OpoCidade,
        NomesCamposTabela.OpoBairro => OpoBairro,
        NomesCamposTabela.OpoCEP => OpoCEP,
        NomesCamposTabela.OpoInscEst => OpoInscEst,
        NomesCamposTabela.OpoObservacao => OpoObservacao,
        NomesCamposTabela.OpoEMail => OpoEMail,
        NomesCamposTabela.OpoClass => OpoClass,
        NomesCamposTabela.OpoTop => OpoTop,
        NomesCamposTabela.OpoEtiqueta => OpoEtiqueta,
        NomesCamposTabela.OpoBold => OpoBold,
        NomesCamposTabela.OpoGUID => OpoGUID,
        NomesCamposTabela.OpoQuemCad => OpoQuemCad,
        NomesCamposTabela.OpoDtCad => OpoDtCad,
        NomesCamposTabela.OpoQuemAtu => OpoQuemAtu,
        NomesCamposTabela.OpoDtAtu => OpoDtAtu,
        NomesCamposTabela.OpoVisto => OpoVisto,
        _ => null
    };
}