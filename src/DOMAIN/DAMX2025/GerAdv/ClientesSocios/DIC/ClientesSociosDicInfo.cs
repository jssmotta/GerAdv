using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBClientesSociosDicInfo
{
    public const string CampoCodigo = "cscCodigo";
    public const string CampoNome = "cscNome";
    public const string TablePrefix = "csc";
    public const string SomenteRepresentante = "cscSomenteRepresentante"; // LOCALIZACAO 170523
    public const string Idade = "cscIdade"; // LOCALIZACAO 170523
    public const string IsRepresentanteLegal = "cscIsRepresentanteLegal"; // LOCALIZACAO 170523
    public const string Qualificacao = "cscQualificacao"; // LOCALIZACAO 170523
    public const string Sexo = "cscSexo"; // LOCALIZACAO 170523
    public const string DtNasc = "cscDtNasc"; // LOCALIZACAO 170523
    public const string Nome = "cscNome"; // LOCALIZACAO 170523
    public const string Site = "cscSite"; // LOCALIZACAO 170523
    public const string RepresentanteLegal = "cscRepresentanteLegal"; // LOCALIZACAO 170523
    public const string Cliente = "cscCliente"; // LOCALIZACAO 170523
    public const string Endereco = "cscEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "cscBairro"; // LOCALIZACAO 170523
    public const string CEP = "cscCEP"; // LOCALIZACAO 170523
    public const string Cidade = "cscCidade"; // LOCALIZACAO 170523
    public const string RG = "cscRG"; // LOCALIZACAO 170523
    public const string CPF = "cscCPF"; // LOCALIZACAO 170523
    public const string Fone = "cscFone"; // LOCALIZACAO 170523
    public const string Participacao = "cscParticipacao"; // LOCALIZACAO 170523
    public const string Cargo = "cscCargo"; // LOCALIZACAO 170523
    public const string EMail = "cscEMail"; // LOCALIZACAO 170523
    public const string Obs = "cscObs"; // LOCALIZACAO 170523
    public const string CNH = "cscCNH"; // LOCALIZACAO 170523
    public const string DataContrato = "cscDataContrato"; // LOCALIZACAO 170523
    public const string CNPJ = "cscCNPJ"; // LOCALIZACAO 170523
    public const string InscEst = "cscInscEst"; // LOCALIZACAO 170523
    public const string SocioEmpresaAdminNome = "cscSocioEmpresaAdminNome"; // LOCALIZACAO 170523
    public const string EnderecoSocio = "cscEnderecoSocio"; // LOCALIZACAO 170523
    public const string BairroSocio = "cscBairroSocio"; // LOCALIZACAO 170523
    public const string CEPSocio = "cscCEPSocio"; // LOCALIZACAO 170523
    public const string CidadeSocio = "cscCidadeSocio"; // LOCALIZACAO 170523
    public const string RGDataExp = "cscRGDataExp"; // LOCALIZACAO 170523
    public const string SocioEmpresaAdminSomente = "cscSocioEmpresaAdminSomente"; // LOCALIZACAO 170523
    public const string Tipo = "cscTipo"; // LOCALIZACAO 170523
    public const string Fax = "cscFax"; // LOCALIZACAO 170523
    public const string Class = "cscClass"; // LOCALIZACAO 170523
    public const string Etiqueta = "cscEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "cscAni"; // LOCALIZACAO 170523
    public const string Bold = "cscBold"; // LOCALIZACAO 170523
    public const string GUID = "cscGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "cscQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "cscDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "cscQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "cscDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "cscVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => SomenteRepresentante,
        2 => Idade,
        3 => IsRepresentanteLegal,
        4 => Qualificacao,
        5 => Sexo,
        6 => DtNasc,
        7 => Nome,
        8 => Site,
        9 => RepresentanteLegal,
        10 => Cliente,
        11 => Endereco,
        12 => Bairro,
        13 => CEP,
        14 => Cidade,
        15 => RG,
        16 => CPF,
        17 => Fone,
        18 => Participacao,
        19 => Cargo,
        20 => EMail,
        21 => Obs,
        22 => CNH,
        23 => DataContrato,
        24 => CNPJ,
        25 => InscEst,
        26 => SocioEmpresaAdminNome,
        27 => EnderecoSocio,
        28 => BairroSocio,
        29 => CEPSocio,
        30 => CidadeSocio,
        31 => RGDataExp,
        32 => SocioEmpresaAdminSomente,
        33 => Tipo,
        34 => Fax,
        35 => Class,
        36 => Etiqueta,
        37 => Ani,
        38 => Bold,
        39 => GUID,
        40 => QuemCad,
        41 => DtCad,
        42 => QuemAtu,
        43 => DtAtu,
        44 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ClientesSocios";
#region PropriedadesDaTabela
    public static DBInfoSystem CscSomenteRepresentante => new(0, PTabelaNome, CampoCodigo, SomenteRepresentante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "csc"
    };
    public static DBInfoSystem CscIdade => new(0, PTabelaNome, CampoCodigo, Idade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscIsRepresentanteLegal => new(0, PTabelaNome, CampoCodigo, IsRepresentanteLegal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "csc"
    };
    public static DBInfoSystem CscQualificacao => new(0, PTabelaNome, CampoCodigo, Qualificacao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "csc"
    };
    public static DBInfoSystem CscDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscRepresentanteLegal => new(0, PTabelaNome, CampoCodigo, RepresentanteLegal, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "csc"
    }; // DBI 11 
    public static DBInfoSystem CscEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "csc"
    }; // DBI 11 
    public static DBInfoSystem CscRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscParticipacao => new(0, PTabelaNome, CampoCodigo, Participacao, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscCargo => new(0, PTabelaNome, CampoCodigo, Cargo, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscEMail => new(0, PTabelaNome, CampoCodigo, EMail, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscObs => new(0, PTabelaNome, CampoCodigo, Obs, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscCNH => new(0, PTabelaNome, CampoCodigo, CNH, 100, DevourerOne.PCnh, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnh, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscDataContrato => new(0, PTabelaNome, CampoCodigo, DataContrato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscSocioEmpresaAdminNome => new(0, PTabelaNome, CampoCodigo, SocioEmpresaAdminNome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscEnderecoSocio => new(0, PTabelaNome, CampoCodigo, EnderecoSocio, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscBairroSocio => new(0, PTabelaNome, CampoCodigo, BairroSocio, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscCEPSocio => new(0, PTabelaNome, CampoCodigo, CEPSocio, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscCidadeSocio => new(0, PTabelaNome, CampoCodigo, CidadeSocio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscRGDataExp => new(0, PTabelaNome, CampoCodigo, RGDataExp, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscSocioEmpresaAdminSomente => new(0, PTabelaNome, CampoCodigo, SocioEmpresaAdminSomente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscFax => new(0, PTabelaNome, CampoCodigo, Fax, 2048, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "csc"
    };
    public static DBInfoSystem CscAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "csc"
    };
    public static DBInfoSystem CscGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "csc"
    }; // DBI 11 
    public static DBInfoSystem CscDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "csc"
    }; // DBI 11 
    public static DBInfoSystem CscDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "csc"
    };
    public static DBInfoSystem CscVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "csc"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        CscSomenteRepresentante = 1,
        CscIdade = 2,
        CscIsRepresentanteLegal = 3,
        CscQualificacao = 4,
        CscSexo = 5,
        CscDtNasc = 6,
        CscNome = 7,
        CscSite = 8,
        CscRepresentanteLegal = 9,
        CscCliente = 10,
        CscEndereco = 11,
        CscBairro = 12,
        CscCEP = 13,
        CscCidade = 14,
        CscRG = 15,
        CscCPF = 16,
        CscFone = 17,
        CscParticipacao = 18,
        CscCargo = 19,
        CscEMail = 20,
        CscObs = 21,
        CscCNH = 22,
        CscDataContrato = 23,
        CscCNPJ = 24,
        CscInscEst = 25,
        CscSocioEmpresaAdminNome = 26,
        CscEnderecoSocio = 27,
        CscBairroSocio = 28,
        CscCEPSocio = 29,
        CscCidadeSocio = 30,
        CscRGDataExp = 31,
        CscSocioEmpresaAdminSomente = 32,
        CscTipo = 33,
        CscFax = 34,
        CscClass = 35,
        CscEtiqueta = 36,
        CscAni = 37,
        CscBold = 38,
        CscGUID = 39,
        CscQuemCad = 40,
        CscDtCad = 41,
        CscQuemAtu = 42,
        CscDtAtu = 43,
        CscVisto = 44
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CscSomenteRepresentante => CscSomenteRepresentante,
        NomesCamposTabela.CscIdade => CscIdade,
        NomesCamposTabela.CscIsRepresentanteLegal => CscIsRepresentanteLegal,
        NomesCamposTabela.CscQualificacao => CscQualificacao,
        NomesCamposTabela.CscSexo => CscSexo,
        NomesCamposTabela.CscDtNasc => CscDtNasc,
        NomesCamposTabela.CscNome => CscNome,
        NomesCamposTabela.CscSite => CscSite,
        NomesCamposTabela.CscRepresentanteLegal => CscRepresentanteLegal,
        NomesCamposTabela.CscCliente => CscCliente,
        NomesCamposTabela.CscEndereco => CscEndereco,
        NomesCamposTabela.CscBairro => CscBairro,
        NomesCamposTabela.CscCEP => CscCEP,
        NomesCamposTabela.CscCidade => CscCidade,
        NomesCamposTabela.CscRG => CscRG,
        NomesCamposTabela.CscCPF => CscCPF,
        NomesCamposTabela.CscFone => CscFone,
        NomesCamposTabela.CscParticipacao => CscParticipacao,
        NomesCamposTabela.CscCargo => CscCargo,
        NomesCamposTabela.CscEMail => CscEMail,
        NomesCamposTabela.CscObs => CscObs,
        NomesCamposTabela.CscCNH => CscCNH,
        NomesCamposTabela.CscDataContrato => CscDataContrato,
        NomesCamposTabela.CscCNPJ => CscCNPJ,
        NomesCamposTabela.CscInscEst => CscInscEst,
        NomesCamposTabela.CscSocioEmpresaAdminNome => CscSocioEmpresaAdminNome,
        NomesCamposTabela.CscEnderecoSocio => CscEnderecoSocio,
        NomesCamposTabela.CscBairroSocio => CscBairroSocio,
        NomesCamposTabela.CscCEPSocio => CscCEPSocio,
        NomesCamposTabela.CscCidadeSocio => CscCidadeSocio,
        NomesCamposTabela.CscRGDataExp => CscRGDataExp,
        NomesCamposTabela.CscSocioEmpresaAdminSomente => CscSocioEmpresaAdminSomente,
        NomesCamposTabela.CscTipo => CscTipo,
        NomesCamposTabela.CscFax => CscFax,
        NomesCamposTabela.CscClass => CscClass,
        NomesCamposTabela.CscEtiqueta => CscEtiqueta,
        NomesCamposTabela.CscAni => CscAni,
        NomesCamposTabela.CscBold => CscBold,
        NomesCamposTabela.CscGUID => CscGUID,
        NomesCamposTabela.CscQuemCad => CscQuemCad,
        NomesCamposTabela.CscDtCad => CscDtCad,
        NomesCamposTabela.CscQuemAtu => CscQuemAtu,
        NomesCamposTabela.CscDtAtu => CscDtAtu,
        NomesCamposTabela.CscVisto => CscVisto,
        _ => null
    };
}