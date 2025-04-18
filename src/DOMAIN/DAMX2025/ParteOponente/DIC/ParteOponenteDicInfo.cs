using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBParteOponenteDicInfo
{
    public const string CampoCodigo = "";
    public const string CampoNome = "";
    public const string TablePrefix = "opo";
    public const string Oponente = "opoOponente"; // LOCALIZACAO 170523
    public const string Processo = "opoProcesso"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Oponente,
        2 => Processo,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ParteOponente";
#region PropriedadesDaTabela
    public static DBInfoSystem OpoOponente => new(0, PTabelaNome, CampoCodigo, Oponente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOponentesDicInfo.CampoCodigo, DBOponentesDicInfo.TabelaNome, new DBOponentesODicInfo(), false); // DBI 11 
    public static DBInfoSystem OpoProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string OponenteDiff(int id) => Oponente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string OponenteSql(int id) => Oponente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string OponenteIsNull => Oponente.SqlCmdIsNull() ?? string.Empty;
    public static string OponenteNotIsNull => Oponente.SqlCmdNotIsNull() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        OpoOponente = 1,
        OpoProcesso = 2
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OpoOponente => OpoOponente,
        NomesCamposTabela.OpoProcesso => OpoProcesso,
        _ => null
    };
}