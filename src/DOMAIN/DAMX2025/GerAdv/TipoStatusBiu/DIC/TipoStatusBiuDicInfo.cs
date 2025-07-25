using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTipoStatusBiuDicInfo
{
    public const string CampoCodigo = "tsbCodigo";
    public const string CampoNome = "tsbNome";
    public const string TablePrefix = "tsb";
    public const string Nome = "tsbNome"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TipoStatusBiu";
#region PropriedadesDaTabela
    public static DBInfoSystem TsbNome => new(0, PTabelaNome, CampoCodigo, Nome, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        IsRequired = true,
        Prefixo = "tsb"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TsbNome = 1
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TsbNome => TsbNome,
        _ => null
    };
}