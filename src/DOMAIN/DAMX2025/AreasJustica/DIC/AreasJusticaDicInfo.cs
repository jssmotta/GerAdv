using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAreasJusticaDicInfo
{
    public const string CampoCodigo = "arjCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "arj";
    public const string Area = "arjArea"; // LOCALIZACAO 170523
    public const string Justica = "arjJustica"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Area,
        2 => Justica,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AreasJustica";
#region PropriedadesDaTabela
    public static DBInfoSystem ArjArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false); // DBI 11 
    public static DBInfoSystem ArjJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false); // DBI 11 

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string AreaDiff(int id) => Area.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AreaSql(int id) => Area.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AreaIsNull => Area.SqlCmdIsNull() ?? string.Empty;
    public static string AreaNotIsNull => Area.SqlCmdNotIsNull() ?? string.Empty;

    public static string JusticaDiff(int id) => Justica.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string JusticaSql(int id) => Justica.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string JusticaIsNull => Justica.SqlCmdIsNull() ?? string.Empty;
    public static string JusticaNotIsNull => Justica.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        ArjArea = 1,
        ArjJustica = 2
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.ArjArea => ArjArea,
        NomesCamposTabela.ArjJustica => ArjJustica,
        _ => null
    };
}