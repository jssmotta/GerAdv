using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBEscritoriosDicInfo
{
    public const string CampoCodigo = "escCodigo";
    public const string CampoNome = "escNome";
    public const string TablePrefix = "esc";
    public const string CNPJ = "escCNPJ"; // LOCALIZACAO 170523
    public const string Casa = "escCasa"; // LOCALIZACAO 170523
    public const string Parceria = "escParceria"; // LOCALIZACAO 170523
    public const string Nome = "escNome"; // LOCALIZACAO 170523
    public const string OAB = "escOAB"; // LOCALIZACAO 170523
    public const string Endereco = "escEndereco"; // LOCALIZACAO 170523
    public const string Cidade = "escCidade"; // LOCALIZACAO 170523
    public const string Bairro = "escBairro"; // LOCALIZACAO 170523
    public const string CEP = "escCEP"; // LOCALIZACAO 170523
    public const string Fone = "escFone"; // LOCALIZACAO 170523
    public const string Fax = "escFax"; // LOCALIZACAO 170523
    public const string Site = "escSite"; // LOCALIZACAO 170523
    public const string EMail = "escEMail"; // LOCALIZACAO 170523
    public const string OBS = "escOBS"; // LOCALIZACAO 170523
    public const string AdvResponsavel = "escAdvResponsavel"; // LOCALIZACAO 170523
    public const string Secretaria = "escSecretaria"; // LOCALIZACAO 170523
    public const string InscEst = "escInscEst"; // LOCALIZACAO 170523
    public const string Correspondente = "escCorrespondente"; // LOCALIZACAO 170523
    public const string Top = "escTop"; // LOCALIZACAO 170523
    public const string Etiqueta = "escEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "escBold"; // LOCALIZACAO 170523
    public const string GUID = "escGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "escQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "escDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "escQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "escDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "escVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => CNPJ,
        2 => Casa,
        3 => Parceria,
        4 => Nome,
        5 => OAB,
        6 => Endereco,
        7 => Cidade,
        8 => Bairro,
        9 => CEP,
        10 => Fone,
        11 => Fax,
        12 => Site,
        13 => EMail,
        14 => OBS,
        15 => AdvResponsavel,
        16 => Secretaria,
        17 => InscEst,
        18 => Correspondente,
        19 => Top,
        20 => Etiqueta,
        21 => Bold,
        22 => GUID,
        23 => QuemCad,
        24 => DtCad,
        25 => QuemAtu,
        26 => DtAtu,
        27 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Escritorios";
#region PropriedadesDaTabela
    public static DBInfoSystem EscCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscCasa => new(0, PTabelaNome, CampoCodigo, Casa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "esc"
    };
    public static DBInfoSystem EscParceria => new(0, PTabelaNome, CampoCodigo, Parceria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "esc"
    };
    public static DBInfoSystem EscNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscOAB => new(0, PTabelaNome, CampoCodigo, OAB, 15, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 50, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "esc"
    }; // DBI 11 
    public static DBInfoSystem EscBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 30, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscSite => new(0, PTabelaNome, CampoCodigo, Site, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscEMail => new(0, PTabelaNome, CampoCodigo, EMail, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscAdvResponsavel => new(0, PTabelaNome, CampoCodigo, AdvResponsavel, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscSecretaria => new(0, PTabelaNome, CampoCodigo, Secretaria, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscCorrespondente => new(0, PTabelaNome, CampoCodigo, Correspondente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "esc"
    };
    public static DBInfoSystem EscBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "esc"
    };
    public static DBInfoSystem EscGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "esc"
    }; // DBI 11 
    public static DBInfoSystem EscDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "esc"
    }; // DBI 11 
    public static DBInfoSystem EscDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "esc"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        EscCNPJ = 1,
        EscCasa = 2,
        EscParceria = 3,
        EscNome = 4,
        EscOAB = 5,
        EscEndereco = 6,
        EscCidade = 7,
        EscBairro = 8,
        EscCEP = 9,
        EscFone = 10,
        EscFax = 11,
        EscSite = 12,
        EscEMail = 13,
        EscOBS = 14,
        EscAdvResponsavel = 15,
        EscSecretaria = 16,
        EscInscEst = 17,
        EscCorrespondente = 18,
        EscTop = 19,
        EscEtiqueta = 20,
        EscBold = 21,
        EscGUID = 22,
        EscQuemCad = 23,
        EscDtCad = 24,
        EscQuemAtu = 25,
        EscDtAtu = 26,
        EscVisto = 27
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.EscCNPJ => EscCNPJ,
        NomesCamposTabela.EscCasa => EscCasa,
        NomesCamposTabela.EscParceria => EscParceria,
        NomesCamposTabela.EscNome => EscNome,
        NomesCamposTabela.EscOAB => EscOAB,
        NomesCamposTabela.EscEndereco => EscEndereco,
        NomesCamposTabela.EscCidade => EscCidade,
        NomesCamposTabela.EscBairro => EscBairro,
        NomesCamposTabela.EscCEP => EscCEP,
        NomesCamposTabela.EscFone => EscFone,
        NomesCamposTabela.EscFax => EscFax,
        NomesCamposTabela.EscSite => EscSite,
        NomesCamposTabela.EscEMail => EscEMail,
        NomesCamposTabela.EscOBS => EscOBS,
        NomesCamposTabela.EscAdvResponsavel => EscAdvResponsavel,
        NomesCamposTabela.EscSecretaria => EscSecretaria,
        NomesCamposTabela.EscInscEst => EscInscEst,
        NomesCamposTabela.EscCorrespondente => EscCorrespondente,
        NomesCamposTabela.EscTop => EscTop,
        NomesCamposTabela.EscEtiqueta => EscEtiqueta,
        NomesCamposTabela.EscBold => EscBold,
        NomesCamposTabela.EscGUID => EscGUID,
        NomesCamposTabela.EscQuemCad => EscQuemCad,
        NomesCamposTabela.EscDtCad => EscDtCad,
        NomesCamposTabela.EscQuemAtu => EscQuemAtu,
        NomesCamposTabela.EscDtAtu => EscDtAtu,
        NomesCamposTabela.EscVisto => EscVisto,
        _ => null
    };
}