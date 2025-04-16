using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAgendaQuemDicInfo
{
    public const string CampoCodigo = "agqCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "agq";
    public const string IDAgenda = "agqIDAgenda"; // LOCALIZACAO 170523
    public const string Advogado = "agqAdvogado"; // LOCALIZACAO 170523
    public const string Funcionario = "agqFuncionario"; // LOCALIZACAO 170523
    public const string Preposto = "agqPreposto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => IDAgenda,
        2 => Advogado,
        3 => Funcionario,
        4 => Preposto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaQuem";
#region PropriedadesDaTabela
    public static DBInfoSystem AgqIDAgenda => new(0, PTabelaNome, CampoCodigo, IDAgenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AgqAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgqFuncionario => new(0, PTabelaNome, CampoCodigo, Funcionario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncionariosDicInfo.CampoCodigo, DBFuncionariosDicInfo.TabelaNome, new DBFuncionariosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AgqPreposto => new(0, PTabelaNome, CampoCodigo, Preposto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPrepostosDicInfo.CampoCodigo, DBPrepostosDicInfo.TabelaNome, new DBPrepostosODicInfo(), false); // DBI 11 

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string IDAgendaDiff(int id) => IDAgenda.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IDAgendaSql(int id) => IDAgenda.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IDAgendaIsNull => IDAgenda.SqlCmdIsNull() ?? string.Empty;
    public static string IDAgendaNotIsNull => IDAgenda.SqlCmdNotIsNull() ?? string.Empty;

    public static string AdvogadoDiff(int id) => Advogado.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AdvogadoSql(int id) => Advogado.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AdvogadoIsNull => Advogado.SqlCmdIsNull() ?? string.Empty;
    public static string AdvogadoNotIsNull => Advogado.SqlCmdNotIsNull() ?? string.Empty;

    public static string FuncionarioDiff(int id) => Funcionario.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string FuncionarioSql(int id) => Funcionario.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string FuncionarioIsNull => Funcionario.SqlCmdIsNull() ?? string.Empty;
    public static string FuncionarioNotIsNull => Funcionario.SqlCmdNotIsNull() ?? string.Empty;

    public static string PrepostoDiff(int id) => Preposto.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string PrepostoSql(int id) => Preposto.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string PrepostoIsNull => Preposto.SqlCmdIsNull() ?? string.Empty;
    public static string PrepostoNotIsNull => Preposto.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        AgqIDAgenda = 1,
        AgqAdvogado = 2,
        AgqFuncionario = 3,
        AgqPreposto = 4
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AgqIDAgenda => AgqIDAgenda,
        NomesCamposTabela.AgqAdvogado => AgqAdvogado,
        NomesCamposTabela.AgqFuncionario => AgqFuncionario,
        NomesCamposTabela.AgqPreposto => AgqPreposto,
        _ => null
    };
}