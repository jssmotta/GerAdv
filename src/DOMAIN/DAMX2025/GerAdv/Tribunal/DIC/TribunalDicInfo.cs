using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTribunalDicInfo
{
    public const string CampoCodigo = "triCodigo";
    public const string CampoNome = "triNome";
    public const string TablePrefix = "tri";
    public const string Nome = "triNome"; // LOCALIZACAO 170523
    public const string Area = "triArea"; // LOCALIZACAO 170523
    public const string Justica = "triJustica"; // LOCALIZACAO 170523
    public const string Descricao = "triDescricao"; // LOCALIZACAO 170523
    public const string Instancia = "triInstancia"; // LOCALIZACAO 170523
    public const string Sigla = "triSigla"; // LOCALIZACAO 170523
    public const string Web = "triWeb"; // LOCALIZACAO 170523
    public const string Etiqueta = "triEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "triBold"; // LOCALIZACAO 170523
    public const string GUID = "triGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "triQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "triDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "triQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "triDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "triVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Area,
        3 => Justica,
        4 => Descricao,
        5 => Instancia,
        6 => Sigla,
        7 => Web,
        8 => Etiqueta,
        9 => Bold,
        10 => GUID,
        11 => QuemCad,
        12 => DtCad,
        13 => QuemAtu,
        14 => DtAtu,
        15 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Tribunal";
#region PropriedadesDaTabela
    public static DBInfoSystem TriNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false)
    {
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriInstancia => new(0, PTabelaNome, CampoCodigo, Instancia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBInstanciaDicInfo.CampoCodigo, DBInstanciaDicInfo.TabelaNome, new DBInstanciaODicInfo(), false)
    {
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriSigla => new(0, PTabelaNome, CampoCodigo, Sigla, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriWeb => new(0, PTabelaNome, CampoCodigo, Web, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "tri"
    };
    public static DBInfoSystem TriBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "tri"
    };
    public static DBInfoSystem TriGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tri"
    }; // DBI 11 
    public static DBInfoSystem TriDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "tri"
    };
    public static DBInfoSystem TriVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "tri"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TriNome = 1,
        TriArea = 2,
        TriJustica = 3,
        TriDescricao = 4,
        TriInstancia = 5,
        TriSigla = 6,
        TriWeb = 7,
        TriEtiqueta = 8,
        TriBold = 9,
        TriGUID = 10,
        TriQuemCad = 11,
        TriDtCad = 12,
        TriQuemAtu = 13,
        TriDtAtu = 14,
        TriVisto = 15
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TriNome => TriNome,
        NomesCamposTabela.TriArea => TriArea,
        NomesCamposTabela.TriJustica => TriJustica,
        NomesCamposTabela.TriDescricao => TriDescricao,
        NomesCamposTabela.TriInstancia => TriInstancia,
        NomesCamposTabela.TriSigla => TriSigla,
        NomesCamposTabela.TriWeb => TriWeb,
        NomesCamposTabela.TriEtiqueta => TriEtiqueta,
        NomesCamposTabela.TriBold => TriBold,
        NomesCamposTabela.TriGUID => TriGUID,
        NomesCamposTabela.TriQuemCad => TriQuemCad,
        NomesCamposTabela.TriDtCad => TriDtCad,
        NomesCamposTabela.TriQuemAtu => TriQuemAtu,
        NomesCamposTabela.TriDtAtu => TriDtAtu,
        NomesCamposTabela.TriVisto => TriVisto,
        _ => null
    };
}