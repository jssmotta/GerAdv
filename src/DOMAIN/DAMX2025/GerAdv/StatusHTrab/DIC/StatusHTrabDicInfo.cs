using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBStatusHTrabDicInfo
{
    public const string CampoCodigo = "shtCodigo";
    public const string CampoNome = "shtDescricao";
    public const string TablePrefix = "sht";
    public const string Descricao = "shtDescricao"; // LOCALIZACAO 170523
    public const string ResID = "shtResID"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
        2 => ResID,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "StatusHTrab";
#region PropriedadesDaTabela
    public static DBInfoSystem ShtDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "sht"
    };
    public static DBInfoSystem ShtResID => new(0, PTabelaNome, CampoCodigo, ResID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "sht"
    };

#endregion
#region SMART_SQLServices 
    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        ShtDescricao = 1,
        ShtResID = 2
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.ShtDescricao => ShtDescricao,
        NomesCamposTabela.ShtResID => ShtResID,
        _ => null
    };
}