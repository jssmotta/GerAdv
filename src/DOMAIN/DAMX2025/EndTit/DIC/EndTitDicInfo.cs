using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBEndTitDicInfo
{
    public const string CampoCodigo = "ettCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ett";
    public const string Endereco = "ettEndereco"; // LOCALIZACAO 170523
    public const string Titulo = "ettTitulo"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Endereco,
        2 => Titulo,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "EndTit";
#region PropriedadesDaTabela
    public static DBInfoSystem EttEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem EttTitulo => new(0, PTabelaNome, CampoCodigo, Titulo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string EnderecoDiff(int id) => Endereco.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string EnderecoSql(int id) => Endereco.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string EnderecoIsNull => Endereco.SqlCmdIsNull() ?? string.Empty;
    public static string EnderecoNotIsNull => Endereco.SqlCmdNotIsNull() ?? string.Empty;

    public static string TituloDiff(int id) => Titulo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string TituloSql(int id) => Titulo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string TituloIsNull => Titulo.SqlCmdIsNull() ?? string.Empty;
    public static string TituloNotIsNull => Titulo.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

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