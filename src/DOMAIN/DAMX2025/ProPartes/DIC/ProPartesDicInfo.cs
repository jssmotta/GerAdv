using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBProPartesDicInfo
{
    public const string CampoCodigo = "oppCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "opp";
    public const string Parte = "oppParte"; // LOCALIZACAO 170523
    public const string Processo = "oppProcesso"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Parte,
        2 => Processo,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProPartes";
#region PropriedadesDaTabela
    public static DBInfoSystem OppParte => new(0, PTabelaNome, CampoCodigo, Parte, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem OppProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string ParteDiff(int id) => Parte.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ParteSql(int id) => Parte.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ParteIsNull => Parte.SqlCmdIsNull() ?? string.Empty;
    public static string ParteNotIsNull => Parte.SqlCmdNotIsNull() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        OppParte = 1,
        OppProcesso = 2
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OppParte => OppParte,
        NomesCamposTabela.OppProcesso => OppProcesso,
        _ => null
    };
}