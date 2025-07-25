using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTipoModeloDocumentoDicInfo
{
    public const string CampoCodigo = "tpdCodigo";
    public const string CampoNome = "tpdNome";
    public const string TablePrefix = "tpd";
    public const string Nome = "tpdNome"; // LOCALIZACAO 170523
    public const string GUID = "tpdGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "tpdQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "tpdDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "tpdQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "tpdDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "tpdVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => GUID,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TipoModeloDocumento";
#region PropriedadesDaTabela
    public static DBInfoSystem TpdNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "tpd"
    };
    public static DBInfoSystem TpdGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "tpd"
    };
    public static DBInfoSystem TpdQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "tpd"
    }; // DBI 11 
    public static DBInfoSystem TpdDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "tpd"
    };
    public static DBInfoSystem TpdQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tpd"
    }; // DBI 11 
    public static DBInfoSystem TpdDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "tpd"
    };
    public static DBInfoSystem TpdVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "tpd"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TpdNome = 1,
        TpdGUID = 2,
        TpdQuemCad = 3,
        TpdDtCad = 4,
        TpdQuemAtu = 5,
        TpdDtAtu = 6,
        TpdVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TpdNome => TpdNome,
        NomesCamposTabela.TpdGUID => TpdGUID,
        NomesCamposTabela.TpdQuemCad => TpdQuemCad,
        NomesCamposTabela.TpdDtCad => TpdDtCad,
        NomesCamposTabela.TpdQuemAtu => TpdQuemAtu,
        NomesCamposTabela.TpdDtAtu => TpdDtAtu,
        NomesCamposTabela.TpdVisto => TpdVisto,
        _ => null
    };
}