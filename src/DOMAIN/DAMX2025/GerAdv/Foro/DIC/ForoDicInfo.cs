using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBForoDicInfo
{
    public const string CampoCodigo = "forCodigo";
    public const string CampoNome = "forNome";
    public const string TablePrefix = "for";
    public const string EMail = "forEMail"; // LOCALIZACAO 170523
    public const string Nome = "forNome"; // LOCALIZACAO 170523
    public const string Unico = "forUnico"; // LOCALIZACAO 170523
    public const string Cidade = "forCidade"; // LOCALIZACAO 170523
    public const string Site = "forSite"; // LOCALIZACAO 170523
    public const string Endereco = "forEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "forBairro"; // LOCALIZACAO 170523
    public const string Fone = "forFone"; // LOCALIZACAO 170523
    public const string Fax = "forFax"; // LOCALIZACAO 170523
    public const string CEP = "forCEP"; // LOCALIZACAO 170523
    public const string OBS = "forOBS"; // LOCALIZACAO 170523
    public const string UnicoConfirmado = "forUnicoConfirmado"; // LOCALIZACAO 170523
    public const string Web = "forWeb"; // LOCALIZACAO 170523
    public const string Etiqueta = "forEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "forBold"; // LOCALIZACAO 170523
    public const string QuemCad = "forQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "forDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "forQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "forDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "forVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => EMail,
        2 => Nome,
        3 => Unico,
        4 => Cidade,
        5 => Site,
        6 => Endereco,
        7 => Bairro,
        8 => Fone,
        9 => Fax,
        10 => CEP,
        11 => OBS,
        12 => UnicoConfirmado,
        13 => Web,
        14 => Etiqueta,
        15 => Bold,
        16 => QuemCad,
        17 => DtCad,
        18 => QuemAtu,
        19 => DtAtu,
        20 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Foro";
#region PropriedadesDaTabela
    public static DBInfoSystem ForEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForNome => new(0, PTabelaNome, CampoCodigo, Nome, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForUnico => new(0, PTabelaNome, CampoCodigo, Unico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "for"
    }; // DBI 11 
    public static DBInfoSystem ForSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 50, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 255, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForUnicoConfirmado => new(0, PTabelaNome, CampoCodigo, UnicoConfirmado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForWeb => new(0, PTabelaNome, CampoCodigo, Web, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
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
        ForEMail = 1,
        ForNome = 2,
        ForUnico = 3,
        ForCidade = 4,
        ForSite = 5,
        ForEndereco = 6,
        ForBairro = 7,
        ForFone = 8,
        ForFax = 9,
        ForCEP = 10,
        ForOBS = 11,
        ForUnicoConfirmado = 12,
        ForWeb = 13,
        ForEtiqueta = 14,
        ForBold = 15,
        ForQuemCad = 16,
        ForDtCad = 17,
        ForQuemAtu = 18,
        ForDtAtu = 19,
        ForVisto = 20
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.ForEMail => ForEMail,
        NomesCamposTabela.ForNome => ForNome,
        NomesCamposTabela.ForUnico => ForUnico,
        NomesCamposTabela.ForCidade => ForCidade,
        NomesCamposTabela.ForSite => ForSite,
        NomesCamposTabela.ForEndereco => ForEndereco,
        NomesCamposTabela.ForBairro => ForBairro,
        NomesCamposTabela.ForFone => ForFone,
        NomesCamposTabela.ForFax => ForFax,
        NomesCamposTabela.ForCEP => ForCEP,
        NomesCamposTabela.ForOBS => ForOBS,
        NomesCamposTabela.ForUnicoConfirmado => ForUnicoConfirmado,
        NomesCamposTabela.ForWeb => ForWeb,
        NomesCamposTabela.ForEtiqueta => ForEtiqueta,
        NomesCamposTabela.ForBold => ForBold,
        NomesCamposTabela.ForQuemCad => ForQuemCad,
        NomesCamposTabela.ForDtCad => ForDtCad,
        NomesCamposTabela.ForQuemAtu => ForQuemAtu,
        NomesCamposTabela.ForDtAtu => ForDtAtu,
        NomesCamposTabela.ForVisto => ForVisto,
        _ => null
    };
}