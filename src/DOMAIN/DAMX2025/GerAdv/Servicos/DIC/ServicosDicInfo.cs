using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBServicosDicInfo
{
    public const string CampoCodigo = "serCodigo";
    public const string CampoNome = "serDescricao";
    public const string TablePrefix = "ser";
    public const string Cobrar = "serCobrar"; // LOCALIZACAO 170523
    public const string Descricao = "serDescricao"; // LOCALIZACAO 170523
    public const string Basico = "serBasico"; // LOCALIZACAO 170523
    public const string GUID = "serGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "serQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "serDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "serQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "serDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "serVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cobrar,
        2 => Descricao,
        3 => Basico,
        4 => GUID,
        5 => QuemCad,
        6 => DtCad,
        7 => QuemAtu,
        8 => DtAtu,
        9 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Servicos";
#region PropriedadesDaTabela
    public static DBInfoSystem SerCobrar => new(0, PTabelaNome, CampoCodigo, Cobrar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ser"
    };
    public static DBInfoSystem SerDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ser"
    };
    public static DBInfoSystem SerBasico => new(0, PTabelaNome, CampoCodigo, Basico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ser"
    };
    public static DBInfoSystem SerGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "ser"
    };
    public static DBInfoSystem SerQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ser"
    }; // DBI 11 
    public static DBInfoSystem SerDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ser"
    };
    public static DBInfoSystem SerQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ser"
    }; // DBI 11 
    public static DBInfoSystem SerDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ser"
    };
    public static DBInfoSystem SerVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        Prefixo = "ser"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        SerCobrar = 1,
        SerDescricao = 2,
        SerBasico = 3,
        SerGUID = 4,
        SerQuemCad = 5,
        SerDtCad = 6,
        SerQuemAtu = 7,
        SerDtAtu = 8,
        SerVisto = 9
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.SerCobrar => SerCobrar,
        NomesCamposTabela.SerDescricao => SerDescricao,
        NomesCamposTabela.SerBasico => SerBasico,
        NomesCamposTabela.SerGUID => SerGUID,
        NomesCamposTabela.SerQuemCad => SerQuemCad,
        NomesCamposTabela.SerDtCad => SerDtCad,
        NomesCamposTabela.SerQuemAtu => SerQuemAtu,
        NomesCamposTabela.SerDtAtu => SerDtAtu,
        NomesCamposTabela.SerVisto => SerVisto,
        _ => null
    };
}