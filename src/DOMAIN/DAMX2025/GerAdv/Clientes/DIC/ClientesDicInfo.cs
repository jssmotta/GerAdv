using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBClientesDicInfo
{
    public const string CampoCodigo = "cliCodigo";
    public const string CampoNome = "cliNome";
    public const string TablePrefix = "cli";
    public const string Empresa = "cliEmpresa"; // LOCALIZACAO 170523
    public const string Icone = "cliIcone"; // LOCALIZACAO 170523
    public const string NomeMae = "cliNomeMae"; // LOCALIZACAO 170523
    public const string RGDataExp = "cliRGDataExp"; // LOCALIZACAO 170523
    public const string Inativo = "cliInativo"; // LOCALIZACAO 170523
    public const string QuemIndicou = "cliQuemIndicou"; // LOCALIZACAO 170523
    public const string SendEMail = "cliSendEMail"; // LOCALIZACAO 170523
    public const string Nome = "cliNome"; // LOCALIZACAO 170523
    public const string Adv = "cliAdv"; // LOCALIZACAO 170523
    public const string IDRep = "cliIDRep"; // LOCALIZACAO 170523
    public const string Juridica = "cliJuridica"; // LOCALIZACAO 170523
    public const string NomeFantasia = "cliNomeFantasia"; // LOCALIZACAO 170523
    public const string Class = "cliClass"; // LOCALIZACAO 170523
    public const string Tipo = "cliTipo"; // LOCALIZACAO 170523
    public const string DtNasc = "cliDtNasc"; // LOCALIZACAO 170523
    public const string InscEst = "cliInscEst"; // LOCALIZACAO 170523
    public const string Qualificacao = "cliQualificacao"; // LOCALIZACAO 170523
    public const string Sexo = "cliSexo"; // LOCALIZACAO 170523
    public const string Idade = "cliIdade"; // LOCALIZACAO 170523
    public const string CNPJ = "cliCNPJ"; // LOCALIZACAO 170523
    public const string CPF = "cliCPF"; // LOCALIZACAO 170523
    public const string RG = "cliRG"; // LOCALIZACAO 170523
    public const string TipoCaptacao = "cliTipoCaptacao"; // LOCALIZACAO 170523
    public const string Observacao = "cliObservacao"; // LOCALIZACAO 170523
    public const string Endereco = "cliEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "cliBairro"; // LOCALIZACAO 170523
    public const string Cidade = "cliCidade"; // LOCALIZACAO 170523
    public const string CEP = "cliCEP"; // LOCALIZACAO 170523
    public const string Fax = "cliFax"; // LOCALIZACAO 170523
    public const string Fone = "cliFone"; // LOCALIZACAO 170523
    public const string Data = "cliData"; // LOCALIZACAO 170523
    public const string HomePage = "cliHomePage"; // LOCALIZACAO 170523
    public const string EMail = "cliEMail"; // LOCALIZACAO 170523
    public const string Obito = "cliObito"; // LOCALIZACAO 170523
    public const string NomePai = "cliNomePai"; // LOCALIZACAO 170523
    public const string RGOExpeditor = "cliRGOExpeditor"; // LOCALIZACAO 170523
    public const string RegimeTributacao = "cliRegimeTributacao"; // LOCALIZACAO 170523
    public const string EnquadramentoEmpresa = "cliEnquadramentoEmpresa"; // LOCALIZACAO 170523
    public const string ReportECBOnly = "cliReportECBOnly"; // LOCALIZACAO 170523
    public const string ProBono = "cliProBono"; // LOCALIZACAO 170523
    public const string CNH = "cliCNH"; // LOCALIZACAO 170523
    public const string PessoaContato = "cliPessoaContato"; // LOCALIZACAO 170523
    public const string Etiqueta = "cliEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "cliAni"; // LOCALIZACAO 170523
    public const string Bold = "cliBold"; // LOCALIZACAO 170523
    public const string GUID = "cliGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "cliQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "cliDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "cliQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "cliDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "cliVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Empresa,
        2 => Icone,
        3 => NomeMae,
        4 => RGDataExp,
        5 => Inativo,
        6 => QuemIndicou,
        7 => SendEMail,
        8 => Nome,
        9 => Adv,
        10 => IDRep,
        11 => Juridica,
        12 => NomeFantasia,
        13 => Class,
        14 => Tipo,
        15 => DtNasc,
        16 => InscEst,
        17 => Qualificacao,
        18 => Sexo,
        19 => Idade,
        20 => CNPJ,
        21 => CPF,
        22 => RG,
        23 => TipoCaptacao,
        24 => Observacao,
        25 => Endereco,
        26 => Bairro,
        27 => Cidade,
        28 => CEP,
        29 => Fax,
        30 => Fone,
        31 => Data,
        32 => HomePage,
        33 => EMail,
        34 => Obito,
        35 => NomePai,
        36 => RGOExpeditor,
        37 => RegimeTributacao,
        38 => EnquadramentoEmpresa,
        39 => ReportECBOnly,
        40 => ProBono,
        41 => CNH,
        42 => PessoaContato,
        43 => Etiqueta,
        44 => Ani,
        45 => Bold,
        46 => GUID,
        47 => QuemCad,
        48 => DtCad,
        49 => QuemAtu,
        50 => DtAtu,
        51 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Clientes";
#region PropriedadesDaTabela
    public static DBInfoSystem CliEmpresa => new(0, PTabelaNome, CampoCodigo, Empresa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliIcone => new(0, PTabelaNome, CampoCodigo, Icone, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliNomeMae => new(0, PTabelaNome, CampoCodigo, NomeMae, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliRGDataExp => new(0, PTabelaNome, CampoCodigo, RGDataExp, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliInativo => new(0, PTabelaNome, CampoCodigo, Inativo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliQuemIndicou => new(0, PTabelaNome, CampoCodigo, QuemIndicou, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliSendEMail => new(0, PTabelaNome, CampoCodigo, SendEMail, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliAdv => new(0, PTabelaNome, CampoCodigo, Adv, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliIDRep => new(0, PTabelaNome, CampoCodigo, IDRep, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliJuridica => new(0, PTabelaNome, CampoCodigo, Juridica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliNomeFantasia => new(0, PTabelaNome, CampoCodigo, NomeFantasia, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliQualificacao => new(0, PTabelaNome, CampoCodigo, Qualificacao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliIdade => new(0, PTabelaNome, CampoCodigo, Idade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliRG => new(0, PTabelaNome, CampoCodigo, RG, 50, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliTipoCaptacao => new(0, PTabelaNome, CampoCodigo, TipoCaptacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "cli"
    }; // DBI 11 
    public static DBInfoSystem CliCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliHomePage => new(0, PTabelaNome, CampoCodigo, HomePage, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliEMail => new(0, PTabelaNome, CampoCodigo, EMail, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliObito => new(0, PTabelaNome, CampoCodigo, Obito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliNomePai => new(0, PTabelaNome, CampoCodigo, NomePai, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliRGOExpeditor => new(0, PTabelaNome, CampoCodigo, RGOExpeditor, 30, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliRegimeTributacao => new(0, PTabelaNome, CampoCodigo, RegimeTributacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBRegimeTributacaoDicInfo.CampoCodigo, DBRegimeTributacaoDicInfo.TabelaNome, new DBRegimeTributacaoODicInfo(), false)
    {
        Prefixo = "cli"
    }; // DBI 11 
    public static DBInfoSystem CliEnquadramentoEmpresa => new(0, PTabelaNome, CampoCodigo, EnquadramentoEmpresa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBEnquadramentoEmpresaDicInfo.CampoCodigo, DBEnquadramentoEmpresaDicInfo.TabelaNome, new DBEnquadramentoEmpresaODicInfo(), false)
    {
        Prefixo = "cli"
    }; // DBI 11 
    public static DBInfoSystem CliReportECBOnly => new(0, PTabelaNome, CampoCodigo, ReportECBOnly, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliProBono => new(0, PTabelaNome, CampoCodigo, ProBono, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliCNH => new(0, PTabelaNome, CampoCodigo, CNH, 100, DevourerOne.PCnh, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnh, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliPessoaContato => new(0, PTabelaNome, CampoCodigo, PessoaContato, 120, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "cli"
    };
    public static DBInfoSystem CliGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "cli"
    }; // DBI 11 
    public static DBInfoSystem CliDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "cli"
    }; // DBI 11 
    public static DBInfoSystem CliDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "cli"
    };
    public static DBInfoSystem CliVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "cli"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        CliEmpresa = 1,
        CliIcone = 2,
        CliNomeMae = 3,
        CliRGDataExp = 4,
        CliInativo = 5,
        CliQuemIndicou = 6,
        CliSendEMail = 7,
        CliNome = 8,
        CliAdv = 9,
        CliIDRep = 10,
        CliJuridica = 11,
        CliNomeFantasia = 12,
        CliClass = 13,
        CliTipo = 14,
        CliDtNasc = 15,
        CliInscEst = 16,
        CliQualificacao = 17,
        CliSexo = 18,
        CliIdade = 19,
        CliCNPJ = 20,
        CliCPF = 21,
        CliRG = 22,
        CliTipoCaptacao = 23,
        CliObservacao = 24,
        CliEndereco = 25,
        CliBairro = 26,
        CliCidade = 27,
        CliCEP = 28,
        CliFax = 29,
        CliFone = 30,
        CliData = 31,
        CliHomePage = 32,
        CliEMail = 33,
        CliObito = 34,
        CliNomePai = 35,
        CliRGOExpeditor = 36,
        CliRegimeTributacao = 37,
        CliEnquadramentoEmpresa = 38,
        CliReportECBOnly = 39,
        CliProBono = 40,
        CliCNH = 41,
        CliPessoaContato = 42,
        CliEtiqueta = 43,
        CliAni = 44,
        CliBold = 45,
        CliGUID = 46,
        CliQuemCad = 47,
        CliDtCad = 48,
        CliQuemAtu = 49,
        CliDtAtu = 50,
        CliVisto = 51
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CliEmpresa => CliEmpresa,
        NomesCamposTabela.CliIcone => CliIcone,
        NomesCamposTabela.CliNomeMae => CliNomeMae,
        NomesCamposTabela.CliRGDataExp => CliRGDataExp,
        NomesCamposTabela.CliInativo => CliInativo,
        NomesCamposTabela.CliQuemIndicou => CliQuemIndicou,
        NomesCamposTabela.CliSendEMail => CliSendEMail,
        NomesCamposTabela.CliNome => CliNome,
        NomesCamposTabela.CliAdv => CliAdv,
        NomesCamposTabela.CliIDRep => CliIDRep,
        NomesCamposTabela.CliJuridica => CliJuridica,
        NomesCamposTabela.CliNomeFantasia => CliNomeFantasia,
        NomesCamposTabela.CliClass => CliClass,
        NomesCamposTabela.CliTipo => CliTipo,
        NomesCamposTabela.CliDtNasc => CliDtNasc,
        NomesCamposTabela.CliInscEst => CliInscEst,
        NomesCamposTabela.CliQualificacao => CliQualificacao,
        NomesCamposTabela.CliSexo => CliSexo,
        NomesCamposTabela.CliIdade => CliIdade,
        NomesCamposTabela.CliCNPJ => CliCNPJ,
        NomesCamposTabela.CliCPF => CliCPF,
        NomesCamposTabela.CliRG => CliRG,
        NomesCamposTabela.CliTipoCaptacao => CliTipoCaptacao,
        NomesCamposTabela.CliObservacao => CliObservacao,
        NomesCamposTabela.CliEndereco => CliEndereco,
        NomesCamposTabela.CliBairro => CliBairro,
        NomesCamposTabela.CliCidade => CliCidade,
        NomesCamposTabela.CliCEP => CliCEP,
        NomesCamposTabela.CliFax => CliFax,
        NomesCamposTabela.CliFone => CliFone,
        NomesCamposTabela.CliData => CliData,
        NomesCamposTabela.CliHomePage => CliHomePage,
        NomesCamposTabela.CliEMail => CliEMail,
        NomesCamposTabela.CliObito => CliObito,
        NomesCamposTabela.CliNomePai => CliNomePai,
        NomesCamposTabela.CliRGOExpeditor => CliRGOExpeditor,
        NomesCamposTabela.CliRegimeTributacao => CliRegimeTributacao,
        NomesCamposTabela.CliEnquadramentoEmpresa => CliEnquadramentoEmpresa,
        NomesCamposTabela.CliReportECBOnly => CliReportECBOnly,
        NomesCamposTabela.CliProBono => CliProBono,
        NomesCamposTabela.CliCNH => CliCNH,
        NomesCamposTabela.CliPessoaContato => CliPessoaContato,
        NomesCamposTabela.CliEtiqueta => CliEtiqueta,
        NomesCamposTabela.CliAni => CliAni,
        NomesCamposTabela.CliBold => CliBold,
        NomesCamposTabela.CliGUID => CliGUID,
        NomesCamposTabela.CliQuemCad => CliQuemCad,
        NomesCamposTabela.CliDtCad => CliDtCad,
        NomesCamposTabela.CliQuemAtu => CliQuemAtu,
        NomesCamposTabela.CliDtAtu => CliDtAtu,
        NomesCamposTabela.CliVisto => CliVisto,
        _ => null
    };
}