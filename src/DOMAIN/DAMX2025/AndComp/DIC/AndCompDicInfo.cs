using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAndCompDicInfo
{
    public const string CampoCodigo = "acpCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "acp";
    public const string Andamento = "acpAndamento"; // LOCALIZACAO 170523
    public const string Compromisso = "acpCompromisso"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Andamento,
        2 => Compromisso,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AndComp";
#region PropriedadesDaTabela
    public static DBInfoSystem AcpAndamento => new(0, PTabelaNome, CampoCodigo, Andamento, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AcpCompromisso => new(0, PTabelaNome, CampoCodigo, Compromisso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string AndamentoDiff(int id) => Andamento.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AndamentoSql(int id) => Andamento.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AndamentoIsNull => Andamento.SqlCmdIsNull() ?? string.Empty;
    public static string AndamentoNotIsNull => Andamento.SqlCmdNotIsNull() ?? string.Empty;

    public static string CompromissoDiff(int id) => Compromisso.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CompromissoSql(int id) => Compromisso.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CompromissoIsNull => Compromisso.SqlCmdIsNull() ?? string.Empty;
    public static string CompromissoNotIsNull => Compromisso.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        AcpAndamento = 1,
        AcpCompromisso = 2
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AcpAndamento => AcpAndamento,
        NomesCamposTabela.AcpCompromisso => AcpCompromisso,
        _ => null
    };
}