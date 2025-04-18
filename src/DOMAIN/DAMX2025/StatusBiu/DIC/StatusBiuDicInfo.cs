using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBStatusBiuDicInfo
{
    public const string CampoCodigo = "stbCodigo";
    public const string CampoNome = "stbNome";
    public const string TablePrefix = "stb";
    public const string Nome = "stbNome"; // LOCALIZACAO 170523
    public const string TipoStatusBiu = "stbTipoStatusBiu"; // LOCALIZACAO 170523
    public const string Operador = "stbOperador"; // LOCALIZACAO 170523
    public const string Icone = "stbIcone"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => TipoStatusBiu,
        3 => Operador,
        4 => Icone,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "StatusBiu";
#region PropriedadesDaTabela
    public static DBInfoSystem StbNome => new(0, PTabelaNome, CampoCodigo, Nome, 1024, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem StbTipoStatusBiu => new(0, PTabelaNome, CampoCodigo, TipoStatusBiu, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoStatusBiuDicInfo.CampoCodigo, DBTipoStatusBiuDicInfo.TabelaNome, new DBTipoStatusBiuODicInfo(), false); // DBI 11 
    public static DBInfoSystem StbOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem StbIcone => new(0, PTabelaNome, CampoCodigo, Icone, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 1024) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TipoStatusBiuDiff(int id) => TipoStatusBiu.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string TipoStatusBiuSql(int id) => TipoStatusBiu.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string TipoStatusBiuIsNull => TipoStatusBiu.SqlCmdIsNull() ?? string.Empty;
    public static string TipoStatusBiuNotIsNull => TipoStatusBiu.SqlCmdNotIsNull() ?? string.Empty;

    public static string OperadorDiff(int id) => Operador.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string OperadorSql(int id) => Operador.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string OperadorIsNull => Operador.SqlCmdIsNull() ?? string.Empty;
    public static string OperadorNotIsNull => Operador.SqlCmdNotIsNull() ?? string.Empty;

    public static string IconeDiff(int id) => Icone.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IconeSql(int id) => Icone.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IconeIsNull => Icone.SqlCmdIsNull() ?? string.Empty;
    public static string IconeNotIsNull => Icone.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        StbNome = 1,
        StbTipoStatusBiu = 2,
        StbOperador = 3,
        StbIcone = 4
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.StbNome => StbNome,
        NomesCamposTabela.StbTipoStatusBiu => StbTipoStatusBiu,
        NomesCamposTabela.StbOperador => StbOperador,
        NomesCamposTabela.StbIcone => StbIcone,
        _ => null
    };
}