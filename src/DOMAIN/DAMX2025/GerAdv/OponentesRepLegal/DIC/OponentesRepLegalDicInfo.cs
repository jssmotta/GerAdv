using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOponentesRepLegalDicInfo
{
    public const string CampoCodigo = "oprCodigo";
    public const string CampoNome = "oprNome";
    public const string TablePrefix = "opr";
    public const string Nome = "oprNome"; // LOCALIZACAO 170523
    public const string Fone = "oprFone"; // LOCALIZACAO 170523
    public const string Oponente = "oprOponente"; // LOCALIZACAO 170523
    public const string Sexo = "oprSexo"; // LOCALIZACAO 170523
    public const string CPF = "oprCPF"; // LOCALIZACAO 170523
    public const string RG = "oprRG"; // LOCALIZACAO 170523
    public const string Endereco = "oprEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "oprBairro"; // LOCALIZACAO 170523
    public const string CEP = "oprCEP"; // LOCALIZACAO 170523
    public const string Cidade = "oprCidade"; // LOCALIZACAO 170523
    public const string Fax = "oprFax"; // LOCALIZACAO 170523
    public const string EMail = "oprEMail"; // LOCALIZACAO 170523
    public const string Site = "oprSite"; // LOCALIZACAO 170523
    public const string Observacao = "oprObservacao"; // LOCALIZACAO 170523
    public const string Bold = "oprBold"; // LOCALIZACAO 170523
    public const string QuemCad = "oprQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "oprDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "oprQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "oprDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "oprVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Fone,
        3 => Oponente,
        4 => Sexo,
        5 => CPF,
        6 => RG,
        7 => Endereco,
        8 => Bairro,
        9 => CEP,
        10 => Cidade,
        11 => Fax,
        12 => EMail,
        13 => Site,
        14 => Observacao,
        15 => Bold,
        16 => QuemCad,
        17 => DtCad,
        18 => QuemAtu,
        19 => DtAtu,
        20 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "OponentesRepLegal";
#region PropriedadesDaTabela
    public static DBInfoSystem OprNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprOponente => new(0, PTabelaNome, CampoCodigo, Oponente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOponentesDicInfo.CampoCodigo, DBOponentesDicInfo.TabelaNome, new DBOponentesODicInfo(), false)
    {
        Prefixo = "opr"
    }; // DBI 11 
    public static DBInfoSystem OprSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "opr"
    };
    public static DBInfoSystem OprCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "opr"
    }; // DBI 11 
    public static DBInfoSystem OprFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "opr"
    };
    public static DBInfoSystem OprQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opr"
    }; // DBI 11 
    public static DBInfoSystem OprDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opr"
    }; // DBI 11 
    public static DBInfoSystem OprDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "opr"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        OprNome = 1,
        OprFone = 2,
        OprOponente = 3,
        OprSexo = 4,
        OprCPF = 5,
        OprRG = 6,
        OprEndereco = 7,
        OprBairro = 8,
        OprCEP = 9,
        OprCidade = 10,
        OprFax = 11,
        OprEMail = 12,
        OprSite = 13,
        OprObservacao = 14,
        OprBold = 15,
        OprQuemCad = 16,
        OprDtCad = 17,
        OprQuemAtu = 18,
        OprDtAtu = 19,
        OprVisto = 20
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OprNome => OprNome,
        NomesCamposTabela.OprFone => OprFone,
        NomesCamposTabela.OprOponente => OprOponente,
        NomesCamposTabela.OprSexo => OprSexo,
        NomesCamposTabela.OprCPF => OprCPF,
        NomesCamposTabela.OprRG => OprRG,
        NomesCamposTabela.OprEndereco => OprEndereco,
        NomesCamposTabela.OprBairro => OprBairro,
        NomesCamposTabela.OprCEP => OprCEP,
        NomesCamposTabela.OprCidade => OprCidade,
        NomesCamposTabela.OprFax => OprFax,
        NomesCamposTabela.OprEMail => OprEMail,
        NomesCamposTabela.OprSite => OprSite,
        NomesCamposTabela.OprObservacao => OprObservacao,
        NomesCamposTabela.OprBold => OprBold,
        NomesCamposTabela.OprQuemCad => OprQuemCad,
        NomesCamposTabela.OprDtCad => OprDtCad,
        NomesCamposTabela.OprQuemAtu => OprQuemAtu,
        NomesCamposTabela.OprDtAtu => OprDtAtu,
        NomesCamposTabela.OprVisto => OprVisto,
        _ => null
    };
}