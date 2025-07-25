using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAdvogadosDicInfo
{
    public const string CampoCodigo = "advCodigo";
    public const string CampoNome = "advNome";
    public const string TablePrefix = "adv";
    public const string Cargo = "advCargo"; // LOCALIZACAO 170523
    public const string EMailPro = "advEMailPro"; // LOCALIZACAO 170523
    public const string CPF = "advCPF"; // LOCALIZACAO 170523
    public const string Nome = "advNome"; // LOCALIZACAO 170523
    public const string RG = "advRG"; // LOCALIZACAO 170523
    public const string Casa = "advCasa"; // LOCALIZACAO 170523
    public const string NomeMae = "advNomeMae"; // LOCALIZACAO 170523
    public const string Escritorio = "advEscritorio"; // LOCALIZACAO 170523
    public const string Estagiario = "advEstagiario"; // LOCALIZACAO 170523
    public const string OAB = "advOAB"; // LOCALIZACAO 170523
    public const string NomeCompleto = "advNomeCompleto"; // LOCALIZACAO 170523
    public const string Endereco = "advEndereco"; // LOCALIZACAO 170523
    public const string Cidade = "advCidade"; // LOCALIZACAO 170523
    public const string CEP = "advCEP"; // LOCALIZACAO 170523
    public const string Sexo = "advSexo"; // LOCALIZACAO 170523
    public const string Bairro = "advBairro"; // LOCALIZACAO 170523
    public const string CTPSSerie = "advCTPSSerie"; // LOCALIZACAO 170523
    public const string CTPS = "advCTPS"; // LOCALIZACAO 170523
    public const string Fone = "advFone"; // LOCALIZACAO 170523
    public const string Fax = "advFax"; // LOCALIZACAO 170523
    public const string Comissao = "advComissao"; // LOCALIZACAO 170523
    public const string DtInicio = "advDtInicio"; // LOCALIZACAO 170523
    public const string DtFim = "advDtFim"; // LOCALIZACAO 170523
    public const string DtNasc = "advDtNasc"; // LOCALIZACAO 170523
    public const string Salario = "advSalario"; // LOCALIZACAO 170523
    public const string Secretaria = "advSecretaria"; // LOCALIZACAO 170523
    public const string TextoProcuracao = "advTextoProcuracao"; // LOCALIZACAO 170523
    public const string EMail = "advEMail"; // LOCALIZACAO 170523
    public const string Especializacao = "advEspecializacao"; // LOCALIZACAO 170523
    public const string Pasta = "advPasta"; // LOCALIZACAO 170523
    public const string Observacao = "advObservacao"; // LOCALIZACAO 170523
    public const string ContaBancaria = "advContaBancaria"; // LOCALIZACAO 170523
    public const string ParcTop = "advParcTop"; // LOCALIZACAO 170523
    public const string Class = "advClass"; // LOCALIZACAO 170523
    public const string Top = "advTop"; // LOCALIZACAO 170523
    public const string Etiqueta = "advEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "advAni"; // LOCALIZACAO 170523
    public const string Bold = "advBold"; // LOCALIZACAO 170523
    public const string GUID = "advGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "advQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "advDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "advQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "advDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "advVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cargo,
        2 => EMailPro,
        3 => CPF,
        4 => Nome,
        5 => RG,
        6 => Casa,
        7 => NomeMae,
        8 => Escritorio,
        9 => Estagiario,
        10 => OAB,
        11 => NomeCompleto,
        12 => Endereco,
        13 => Cidade,
        14 => CEP,
        15 => Sexo,
        16 => Bairro,
        17 => CTPSSerie,
        18 => CTPS,
        19 => Fone,
        20 => Fax,
        21 => Comissao,
        22 => DtInicio,
        23 => DtFim,
        24 => DtNasc,
        25 => Salario,
        26 => Secretaria,
        27 => TextoProcuracao,
        28 => EMail,
        29 => Especializacao,
        30 => Pasta,
        31 => Observacao,
        32 => ContaBancaria,
        33 => ParcTop,
        34 => Class,
        35 => Top,
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

    public const string PTabelaNome = "Advogados";
#region PropriedadesDaTabela
    public static DBInfoSystem AdvCargo => new(0, PTabelaNome, CampoCodigo, Cargo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCargosDicInfo.CampoCodigo, DBCargosDicInfo.TabelaNome, new DBCargosODicInfo(), false)
    {
        Prefixo = "adv"
    }; // DBI 11 
    public static DBInfoSystem AdvEMailPro => new(0, PTabelaNome, CampoCodigo, EMailPro, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmailPro, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvCasa => new(0, PTabelaNome, CampoCodigo, Casa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvNomeMae => new(0, PTabelaNome, CampoCodigo, NomeMae, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvEscritorio => new(0, PTabelaNome, CampoCodigo, Escritorio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBEscritoriosDicInfo.CampoCodigo, DBEscritoriosDicInfo.TabelaNome, new DBEscritoriosODicInfo(), false)
    {
        Prefixo = "adv"
    }; // DBI 11 
    public static DBInfoSystem AdvEstagiario => new(0, PTabelaNome, CampoCodigo, Estagiario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvOAB => new(0, PTabelaNome, CampoCodigo, OAB, 12, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvNomeCompleto => new(0, PTabelaNome, CampoCodigo, NomeCompleto, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "adv"
    }; // DBI 11 
    public static DBInfoSystem AdvCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvCTPSSerie => new(0, PTabelaNome, CampoCodigo, CTPSSerie, 10, DevourerOne.PNroSerieCtps, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtpsserie, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvCTPS => new(0, PTabelaNome, CampoCodigo, CTPS, 15, DevourerOne.PCarteiraTrabalhoNro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtps, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvComissao => new(0, PTabelaNome, CampoCodigo, Comissao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvDtInicio => new(0, PTabelaNome, CampoCodigo, DtInicio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataInicio)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvDtFim => new(0, PTabelaNome, CampoCodigo, DtFim, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataTermino)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvSalario => new(0, PTabelaNome, CampoCodigo, Salario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDoubleSalario)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvSecretaria => new(0, PTabelaNome, CampoCodigo, Secretaria, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvTextoProcuracao => new(0, PTabelaNome, CampoCodigo, TextoProcuracao, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvEMail => new(0, PTabelaNome, CampoCodigo, EMail, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvEspecializacao => new(0, PTabelaNome, CampoCodigo, Especializacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvPasta => new(0, PTabelaNome, CampoCodigo, Pasta, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvContaBancaria => new(0, PTabelaNome, CampoCodigo, ContaBancaria, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvParcTop => new(0, PTabelaNome, CampoCodigo, ParcTop, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario)
    {
        IsRequired = true,
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "adv"
    }; // DBI 11 
    public static DBInfoSystem AdvDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "adv"
    }; // DBI 11 
    public static DBInfoSystem AdvDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "adv"
    };
    public static DBInfoSystem AdvVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "adv"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        AdvCargo = 1,
        AdvEMailPro = 2,
        AdvCPF = 3,
        AdvNome = 4,
        AdvRG = 5,
        AdvCasa = 6,
        AdvNomeMae = 7,
        AdvEscritorio = 8,
        AdvEstagiario = 9,
        AdvOAB = 10,
        AdvNomeCompleto = 11,
        AdvEndereco = 12,
        AdvCidade = 13,
        AdvCEP = 14,
        AdvSexo = 15,
        AdvBairro = 16,
        AdvCTPSSerie = 17,
        AdvCTPS = 18,
        AdvFone = 19,
        AdvFax = 20,
        AdvComissao = 21,
        AdvDtInicio = 22,
        AdvDtFim = 23,
        AdvDtNasc = 24,
        AdvSalario = 25,
        AdvSecretaria = 26,
        AdvTextoProcuracao = 27,
        AdvEMail = 28,
        AdvEspecializacao = 29,
        AdvPasta = 30,
        AdvObservacao = 31,
        AdvContaBancaria = 32,
        AdvParcTop = 33,
        AdvClass = 34,
        AdvTop = 35,
        AdvEtiqueta = 36,
        AdvAni = 37,
        AdvBold = 38,
        AdvGUID = 39,
        AdvQuemCad = 40,
        AdvDtCad = 41,
        AdvQuemAtu = 42,
        AdvDtAtu = 43,
        AdvVisto = 44
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AdvCargo => AdvCargo,
        NomesCamposTabela.AdvEMailPro => AdvEMailPro,
        NomesCamposTabela.AdvCPF => AdvCPF,
        NomesCamposTabela.AdvNome => AdvNome,
        NomesCamposTabela.AdvRG => AdvRG,
        NomesCamposTabela.AdvCasa => AdvCasa,
        NomesCamposTabela.AdvNomeMae => AdvNomeMae,
        NomesCamposTabela.AdvEscritorio => AdvEscritorio,
        NomesCamposTabela.AdvEstagiario => AdvEstagiario,
        NomesCamposTabela.AdvOAB => AdvOAB,
        NomesCamposTabela.AdvNomeCompleto => AdvNomeCompleto,
        NomesCamposTabela.AdvEndereco => AdvEndereco,
        NomesCamposTabela.AdvCidade => AdvCidade,
        NomesCamposTabela.AdvCEP => AdvCEP,
        NomesCamposTabela.AdvSexo => AdvSexo,
        NomesCamposTabela.AdvBairro => AdvBairro,
        NomesCamposTabela.AdvCTPSSerie => AdvCTPSSerie,
        NomesCamposTabela.AdvCTPS => AdvCTPS,
        NomesCamposTabela.AdvFone => AdvFone,
        NomesCamposTabela.AdvFax => AdvFax,
        NomesCamposTabela.AdvComissao => AdvComissao,
        NomesCamposTabela.AdvDtInicio => AdvDtInicio,
        NomesCamposTabela.AdvDtFim => AdvDtFim,
        NomesCamposTabela.AdvDtNasc => AdvDtNasc,
        NomesCamposTabela.AdvSalario => AdvSalario,
        NomesCamposTabela.AdvSecretaria => AdvSecretaria,
        NomesCamposTabela.AdvTextoProcuracao => AdvTextoProcuracao,
        NomesCamposTabela.AdvEMail => AdvEMail,
        NomesCamposTabela.AdvEspecializacao => AdvEspecializacao,
        NomesCamposTabela.AdvPasta => AdvPasta,
        NomesCamposTabela.AdvObservacao => AdvObservacao,
        NomesCamposTabela.AdvContaBancaria => AdvContaBancaria,
        NomesCamposTabela.AdvParcTop => AdvParcTop,
        NomesCamposTabela.AdvClass => AdvClass,
        NomesCamposTabela.AdvTop => AdvTop,
        NomesCamposTabela.AdvEtiqueta => AdvEtiqueta,
        NomesCamposTabela.AdvAni => AdvAni,
        NomesCamposTabela.AdvBold => AdvBold,
        NomesCamposTabela.AdvGUID => AdvGUID,
        NomesCamposTabela.AdvQuemCad => AdvQuemCad,
        NomesCamposTabela.AdvDtCad => AdvDtCad,
        NomesCamposTabela.AdvQuemAtu => AdvQuemAtu,
        NomesCamposTabela.AdvDtAtu => AdvDtAtu,
        NomesCamposTabela.AdvVisto => AdvVisto,
        _ => null
    };
}