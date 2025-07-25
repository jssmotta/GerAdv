using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTipoValorProcessoDicInfo
{
    public const string CampoCodigo = "ptvCodigo";
    public const string CampoNome = "ptvDescricao";
    public const string TablePrefix = "ptv";
    public const string Descricao = "ptvDescricao"; // LOCALIZACAO 170523
    public const string GUID = "ptvGUID"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
        2 => GUID,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TipoValorProcesso";
#region PropriedadesDaTabela
    public static DBInfoSystem PtvDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        IsRequired = true,
        Prefixo = "ptv"
    };
    public static DBInfoSystem PtvGUID => new(0, PTabelaNome, CampoCodigo, GUID, 50, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "ptv"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PtvDescricao = 1,
        PtvGUID = 2
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PtvDescricao => PtvDescricao,
        NomesCamposTabela.PtvGUID => PtvGUID,
        _ => null
    };
}