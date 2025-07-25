using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAtividadesDicInfo
{
    public const string CampoCodigo = "atvCodigo";
    public const string CampoNome = "atvDescricao";
    public const string TablePrefix = "atv";
    public const string Descricao = "atvDescricao"; // LOCALIZACAO 170523
    public const string GUID = "atvGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "atvQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "atvDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "atvQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "atvDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "atvVisto"; // LOCALIZACAO 170523
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

    public const string PTabelaNome = "Atividades";
#region PropriedadesDaTabela
    public static DBInfoSystem AtvDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "atv"
    };
    public static DBInfoSystem AtvGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "atv"
    };
    public static DBInfoSystem AtvQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "atv"
    }; // DBI 11 
    public static DBInfoSystem AtvDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "atv"
    };
    public static DBInfoSystem AtvQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "atv"
    }; // DBI 11 
    public static DBInfoSystem AtvDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "atv"
    };
    public static DBInfoSystem AtvVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "atv"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        AtvDescricao = 1,
        AtvGUID = 2,
        AtvQuemCad = 3,
        AtvDtCad = 4,
        AtvQuemAtu = 5,
        AtvDtAtu = 6,
        AtvVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AtvDescricao => AtvDescricao,
        NomesCamposTabela.AtvGUID => AtvGUID,
        NomesCamposTabela.AtvQuemCad => AtvQuemCad,
        NomesCamposTabela.AtvDtCad => AtvDtCad,
        NomesCamposTabela.AtvQuemAtu => AtvQuemAtu,
        NomesCamposTabela.AtvDtAtu => AtvDtAtu,
        NomesCamposTabela.AtvVisto => AtvVisto,
        _ => null
    };
}