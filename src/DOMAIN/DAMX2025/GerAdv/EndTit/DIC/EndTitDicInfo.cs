using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBEndTitDicInfo
{
    public const string CampoCodigo = "ettCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ett";
    public const string Endereco = "ettEndereco"; // LOCALIZACAO 170523
    public const string Titulo = "ettTitulo"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Endereco,
        2 => Titulo,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "EndTit";
#region PropriedadesDaTabela
    public static DBInfoSystem EttEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ett"
    };
    public static DBInfoSystem EttTitulo => new(0, PTabelaNome, CampoCodigo, Titulo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ett"
    };

#endregion
#region SMART_SQLServices 
#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        EttEndereco = 1,
        EttTitulo = 2
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.EttEndereco => EttEndereco,
        NomesCamposTabela.EttTitulo => EttTitulo,
        _ => null
    };
}