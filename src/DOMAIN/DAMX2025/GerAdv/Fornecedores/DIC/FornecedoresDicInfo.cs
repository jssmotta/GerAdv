using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBFornecedoresDicInfo
{
    public const string CampoCodigo = "forCodigo";
    public const string CampoNome = "forNome";
    public const string TablePrefix = "for";
    public const string Grupo = "forGrupo"; // LOCALIZACAO 170523
    public const string Nome = "forNome"; // LOCALIZACAO 170523
    public const string SubGrupo = "forSubGrupo"; // LOCALIZACAO 170523
    public const string Tipo = "forTipo"; // LOCALIZACAO 170523
    public const string Sexo = "forSexo"; // LOCALIZACAO 170523
    public const string CNPJ = "forCNPJ"; // LOCALIZACAO 170523
    public const string InscEst = "forInscEst"; // LOCALIZACAO 170523
    public const string CPF = "forCPF"; // LOCALIZACAO 170523
    public const string RG = "forRG"; // LOCALIZACAO 170523
    public const string Endereco = "forEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "forBairro"; // LOCALIZACAO 170523
    public const string CEP = "forCEP"; // LOCALIZACAO 170523
    public const string Cidade = "forCidade"; // LOCALIZACAO 170523
    public const string Fone = "forFone"; // LOCALIZACAO 170523
    public const string Fax = "forFax"; // LOCALIZACAO 170523
    public const string Email = "forEmail"; // LOCALIZACAO 170523
    public const string Site = "forSite"; // LOCALIZACAO 170523
    public const string Obs = "forObs"; // LOCALIZACAO 170523
    public const string Produtos = "forProdutos"; // LOCALIZACAO 170523
    public const string Contatos = "forContatos"; // LOCALIZACAO 170523
    public const string Etiqueta = "forEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "forBold"; // LOCALIZACAO 170523
    public const string GUID = "forGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "forQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "forDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "forQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "forDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "forVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Grupo,
        2 => Nome,
        3 => SubGrupo,
        4 => Tipo,
        5 => Sexo,
        6 => CNPJ,
        7 => InscEst,
        8 => CPF,
        9 => RG,
        10 => Endereco,
        11 => Bairro,
        12 => CEP,
        13 => Cidade,
        14 => Fone,
        15 => Fax,
        16 => Email,
        17 => Site,
        18 => Obs,
        19 => Produtos,
        20 => Contatos,
        21 => Etiqueta,
        22 => Bold,
        23 => GUID,
        24 => QuemCad,
        25 => DtCad,
        26 => QuemAtu,
        27 => DtAtu,
        28 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Fornecedores";
#region PropriedadesDaTabela
    public static DBInfoSystem ForGrupo => new(0, PTabelaNome, CampoCodigo, Grupo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForSubGrupo => new(0, PTabelaNome, CampoCodigo, SubGrupo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "for"
    }; // DBI 11 
    public static DBInfoSystem ForFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForEmail => new(0, PTabelaNome, CampoCodigo, Email, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForObs => new(0, PTabelaNome, CampoCodigo, Obs, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForProdutos => new(0, PTabelaNome, CampoCodigo, Produtos, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForContatos => new(0, PTabelaNome, CampoCodigo, Contatos, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "for"
    }; // DBI 11 
    public static DBInfoSystem ForDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "for"
    }; // DBI 11 
    public static DBInfoSystem ForDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "for"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        ForGrupo = 1,
        ForNome = 2,
        ForSubGrupo = 3,
        ForTipo = 4,
        ForSexo = 5,
        ForCNPJ = 6,
        ForInscEst = 7,
        ForCPF = 8,
        ForRG = 9,
        ForEndereco = 10,
        ForBairro = 11,
        ForCEP = 12,
        ForCidade = 13,
        ForFone = 14,
        ForFax = 15,
        ForEmail = 16,
        ForSite = 17,
        ForObs = 18,
        ForProdutos = 19,
        ForContatos = 20,
        ForEtiqueta = 21,
        ForBold = 22,
        ForGUID = 23,
        ForQuemCad = 24,
        ForDtCad = 25,
        ForQuemAtu = 26,
        ForDtAtu = 27,
        ForVisto = 28
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.ForGrupo => ForGrupo,
        NomesCamposTabela.ForNome => ForNome,
        NomesCamposTabela.ForSubGrupo => ForSubGrupo,
        NomesCamposTabela.ForTipo => ForTipo,
        NomesCamposTabela.ForSexo => ForSexo,
        NomesCamposTabela.ForCNPJ => ForCNPJ,
        NomesCamposTabela.ForInscEst => ForInscEst,
        NomesCamposTabela.ForCPF => ForCPF,
        NomesCamposTabela.ForRG => ForRG,
        NomesCamposTabela.ForEndereco => ForEndereco,
        NomesCamposTabela.ForBairro => ForBairro,
        NomesCamposTabela.ForCEP => ForCEP,
        NomesCamposTabela.ForCidade => ForCidade,
        NomesCamposTabela.ForFone => ForFone,
        NomesCamposTabela.ForFax => ForFax,
        NomesCamposTabela.ForEmail => ForEmail,
        NomesCamposTabela.ForSite => ForSite,
        NomesCamposTabela.ForObs => ForObs,
        NomesCamposTabela.ForProdutos => ForProdutos,
        NomesCamposTabela.ForContatos => ForContatos,
        NomesCamposTabela.ForEtiqueta => ForEtiqueta,
        NomesCamposTabela.ForBold => ForBold,
        NomesCamposTabela.ForGUID => ForGUID,
        NomesCamposTabela.ForQuemCad => ForQuemCad,
        NomesCamposTabela.ForDtCad => ForDtCad,
        NomesCamposTabela.ForQuemAtu => ForQuemAtu,
        NomesCamposTabela.ForDtAtu => ForDtAtu,
        NomesCamposTabela.ForVisto => ForVisto,
        _ => null
    };
}