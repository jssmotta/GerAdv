using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBTipoOrigemSucumbenciaDicInfo
{
    public const string CampoCodigo = "tosCodigo";
    public const string CampoNome = "tosNome";
    public const string TablePrefix = "tos";
    public const string Nome = "tosNome"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TipoOrigemSucumbencia";
#region PropriedadesDaTabela
    public static DBInfoSystem TosNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        TosNome = 1
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TosNome => TosNome,
        _ => null
    };
}