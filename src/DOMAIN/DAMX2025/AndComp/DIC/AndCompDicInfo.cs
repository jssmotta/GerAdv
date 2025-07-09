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
#region SMART_SQLServices 
#endregion // 005 " : string.Empty)} 

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