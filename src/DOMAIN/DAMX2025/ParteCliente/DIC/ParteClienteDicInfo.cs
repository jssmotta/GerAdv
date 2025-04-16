using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBParteClienteDicInfo
{
    public const string CampoCodigo = "";
    public const string CampoNome = "";
    public const string TablePrefix = "cli";
    public const string Cliente = "cliCliente"; // LOCALIZACAO 170523
    public const string Processo = "cliProcesso"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cliente,
        2 => Processo,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ParteCliente";
#region PropriedadesDaTabela
    public static DBInfoSystem CliCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem CliProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        CliCliente = 1,
        CliProcesso = 2
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CliCliente => CliCliente,
        NomesCamposTabela.CliProcesso => CliProcesso,
        _ => null
    };
}