using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAgendaQuemDicInfo
{
    public const string CampoCodigo = "agqCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "agq";
    public const string IDAgenda = "agqIDAgenda"; // LOCALIZACAO 170523
    public const string Advogado = "agqAdvogado"; // LOCALIZACAO 170523
    public const string Funcionario = "agqFuncionario"; // LOCALIZACAO 170523
    public const string Preposto = "agqPreposto"; // LOCALIZACAO 170523
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
    public static DBInfoSystem AgqIDAgenda => new(0, PTabelaNome, CampoCodigo, IDAgenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "agq"
    };
    public static DBInfoSystem AgqAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false)
    {
        Prefixo = "agq"
    }; // DBI 11 
    public static DBInfoSystem AgqFuncionario => new(0, PTabelaNome, CampoCodigo, Funcionario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncionariosDicInfo.CampoCodigo, DBFuncionariosDicInfo.TabelaNome, new DBFuncionariosODicInfo(), false)
    {
        Prefixo = "agq"
    }; // DBI 11 
    public static DBInfoSystem AgqPreposto => new(0, PTabelaNome, CampoCodigo, Preposto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPrepostosDicInfo.CampoCodigo, DBPrepostosDicInfo.TabelaNome, new DBPrepostosODicInfo(), false)
    {
        Prefixo = "agq"
    }; // DBI 11 

#endregion
#region SMART_SQLServices 
#endregion // 005 " : string.Empty)} 

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