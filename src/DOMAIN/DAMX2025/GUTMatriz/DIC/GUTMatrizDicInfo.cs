using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBGUTMatrizDicInfo
{
    public const string CampoCodigo = "gutCodigo";
    public const string CampoNome = "gutDescricao";
    public const string TablePrefix = "gut";
    public const string Descricao = "gutDescricao"; // LOCALIZACAO 170523
    public const string GUTTipo = "gutGUTTipo"; // LOCALIZACAO 170523
    public const string Valor = "gutValor"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
        2 => GUTTipo,
        3 => Valor,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "GUTMatriz";
#region PropriedadesDaTabela
    public static DBInfoSystem GutDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem GutGUTTipo => new(0, PTabelaNome, CampoCodigo, GUTTipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBGUTTipoDicInfo.CampoCodigo, DBGUTTipoDicInfo.TabelaNome, new DBGUTTipoODicInfo(), false); // DBI 11 
    public static DBInfoSystem GutValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string GUTTipoDiff(int id) => GUTTipo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string GUTTipoSql(int id) => GUTTipo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string GUTTipoIsNull => GUTTipo.SqlCmdIsNull() ?? string.Empty;
    public static string GUTTipoNotIsNull => GUTTipo.SqlCmdNotIsNull() ?? string.Empty;

    public static string ValorDiff(int id) => Valor.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ValorSql(int id) => Valor.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ValorIsNull => Valor.SqlCmdIsNull() ?? string.Empty;
    public static string ValorNotIsNull => Valor.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        GutDescricao = 1,
        GutGUTTipo = 2,
        GutValor = 3
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.GutDescricao => GutDescricao,
        NomesCamposTabela.GutGUTTipo => GutGUTTipo,
        NomesCamposTabela.GutValor => GutValor,
        _ => null
    };
}