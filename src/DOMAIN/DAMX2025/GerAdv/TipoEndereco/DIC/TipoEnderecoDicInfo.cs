using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTipoEnderecoDicInfo
{
    public const string CampoCodigo = "tipCodigo";
    public const string CampoNome = "tipDescricao";
    public const string TablePrefix = "tip";
    public const string Descricao = "tipDescricao"; // LOCALIZACAO 170523
    public const string GUID = "tipGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "tipQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "tipDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "tipQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "tipDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "tipVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
        2 => GUID,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TipoEndereco";
#region PropriedadesDaTabela
    public static DBInfoSystem TipDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tip"
    }; // DBI 11 
    public static DBInfoSystem TipDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tip"
    }; // DBI 11 
    public static DBInfoSystem TipDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "tip"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TipDescricao = 1,
        TipGUID = 2,
        TipQuemCad = 3,
        TipDtCad = 4,
        TipQuemAtu = 5,
        TipDtAtu = 6,
        TipVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TipDescricao => TipDescricao,
        NomesCamposTabela.TipGUID => TipGUID,
        NomesCamposTabela.TipQuemCad => TipQuemCad,
        NomesCamposTabela.TipDtCad => TipDtCad,
        NomesCamposTabela.TipQuemAtu => TipQuemAtu,
        NomesCamposTabela.TipDtAtu => TipDtAtu,
        NomesCamposTabela.TipVisto => TipVisto,
        _ => null
    };
}