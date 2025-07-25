using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOutrasPartesClienteDicInfo
{
    public const string CampoCodigo = "opcCodigo";
    public const string CampoNome = "opcNome";
    public const string TablePrefix = "opc";
    public const string Nome = "opcNome"; // LOCALIZACAO 170523
    public const string Terceirizado = "opcTerceirizado"; // LOCALIZACAO 170523
    public const string ClientePrincipal = "opcClientePrincipal"; // LOCALIZACAO 170523
    public const string Tipo = "opcTipo"; // LOCALIZACAO 170523
    public const string Sexo = "opcSexo"; // LOCALIZACAO 170523
    public const string DtNasc = "opcDtNasc"; // LOCALIZACAO 170523
    public const string CPF = "opcCPF"; // LOCALIZACAO 170523
    public const string RG = "opcRG"; // LOCALIZACAO 170523
    public const string CNPJ = "opcCNPJ"; // LOCALIZACAO 170523
    public const string InscEst = "opcInscEst"; // LOCALIZACAO 170523
    public const string NomeFantasia = "opcNomeFantasia"; // LOCALIZACAO 170523
    public const string Endereco = "opcEndereco"; // LOCALIZACAO 170523
    public const string Cidade = "opcCidade"; // LOCALIZACAO 170523
    public const string CEP = "opcCEP"; // LOCALIZACAO 170523
    public const string Bairro = "opcBairro"; // LOCALIZACAO 170523
    public const string Fone = "opcFone"; // LOCALIZACAO 170523
    public const string Fax = "opcFax"; // LOCALIZACAO 170523
    public const string EMail = "opcEMail"; // LOCALIZACAO 170523
    public const string Site = "opcSite"; // LOCALIZACAO 170523
    public const string Class = "opcClass"; // LOCALIZACAO 170523
    public const string Etiqueta = "opcEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "opcAni"; // LOCALIZACAO 170523
    public const string Bold = "opcBold"; // LOCALIZACAO 170523
    public const string GUID = "opcGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "opcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "opcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "opcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "opcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "opcVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Terceirizado,
        3 => ClientePrincipal,
        4 => Tipo,
        5 => Sexo,
        6 => DtNasc,
        7 => CPF,
        8 => RG,
        9 => CNPJ,
        10 => InscEst,
        11 => NomeFantasia,
        12 => Endereco,
        13 => Cidade,
        14 => CEP,
        15 => Bairro,
        16 => Fone,
        17 => Fax,
        18 => EMail,
        19 => Site,
        20 => Class,
        21 => Etiqueta,
        22 => Ani,
        23 => Bold,
        24 => GUID,
        25 => QuemCad,
        26 => DtCad,
        27 => QuemAtu,
        28 => DtAtu,
        29 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "OutrasPartesCliente";
#region PropriedadesDaTabela
    public static DBInfoSystem OpcNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcTerceirizado => new(0, PTabelaNome, CampoCodigo, Terceirizado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcClientePrincipal => new(0, PTabelaNome, CampoCodigo, ClientePrincipal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa)
    {
        IsRequired = true,
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcNomeFantasia => new(0, PTabelaNome, CampoCodigo, NomeFantasia, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "opc"
    }; // DBI 11 
    public static DBInfoSystem OpcCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opc"
    }; // DBI 11 
    public static DBInfoSystem OpcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opc"
    }; // DBI 11 
    public static DBInfoSystem OpcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "opc"
    };
    public static DBInfoSystem OpcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "opc"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        OpcNome = 1,
        OpcTerceirizado = 2,
        OpcClientePrincipal = 3,
        OpcTipo = 4,
        OpcSexo = 5,
        OpcDtNasc = 6,
        OpcCPF = 7,
        OpcRG = 8,
        OpcCNPJ = 9,
        OpcInscEst = 10,
        OpcNomeFantasia = 11,
        OpcEndereco = 12,
        OpcCidade = 13,
        OpcCEP = 14,
        OpcBairro = 15,
        OpcFone = 16,
        OpcFax = 17,
        OpcEMail = 18,
        OpcSite = 19,
        OpcClass = 20,
        OpcEtiqueta = 21,
        OpcAni = 22,
        OpcBold = 23,
        OpcGUID = 24,
        OpcQuemCad = 25,
        OpcDtCad = 26,
        OpcQuemAtu = 27,
        OpcDtAtu = 28,
        OpcVisto = 29
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OpcNome => OpcNome,
        NomesCamposTabela.OpcTerceirizado => OpcTerceirizado,
        NomesCamposTabela.OpcClientePrincipal => OpcClientePrincipal,
        NomesCamposTabela.OpcTipo => OpcTipo,
        NomesCamposTabela.OpcSexo => OpcSexo,
        NomesCamposTabela.OpcDtNasc => OpcDtNasc,
        NomesCamposTabela.OpcCPF => OpcCPF,
        NomesCamposTabela.OpcRG => OpcRG,
        NomesCamposTabela.OpcCNPJ => OpcCNPJ,
        NomesCamposTabela.OpcInscEst => OpcInscEst,
        NomesCamposTabela.OpcNomeFantasia => OpcNomeFantasia,
        NomesCamposTabela.OpcEndereco => OpcEndereco,
        NomesCamposTabela.OpcCidade => OpcCidade,
        NomesCamposTabela.OpcCEP => OpcCEP,
        NomesCamposTabela.OpcBairro => OpcBairro,
        NomesCamposTabela.OpcFone => OpcFone,
        NomesCamposTabela.OpcFax => OpcFax,
        NomesCamposTabela.OpcEMail => OpcEMail,
        NomesCamposTabela.OpcSite => OpcSite,
        NomesCamposTabela.OpcClass => OpcClass,
        NomesCamposTabela.OpcEtiqueta => OpcEtiqueta,
        NomesCamposTabela.OpcAni => OpcAni,
        NomesCamposTabela.OpcBold => OpcBold,
        NomesCamposTabela.OpcGUID => OpcGUID,
        NomesCamposTabela.OpcQuemCad => OpcQuemCad,
        NomesCamposTabela.OpcDtCad => OpcDtCad,
        NomesCamposTabela.OpcQuemAtu => OpcQuemAtu,
        NomesCamposTabela.OpcDtAtu => OpcDtAtu,
        NomesCamposTabela.OpcVisto => OpcVisto,
        _ => null
    };
}