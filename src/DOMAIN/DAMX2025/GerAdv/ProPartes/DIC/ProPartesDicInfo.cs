using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProPartesDicInfo
{
    public const string CampoCodigo = "oppCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "opp";
    public const string Parte = "oppParte"; // LOCALIZACAO 170523
    public const string Processo = "oppProcesso"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Parte,
        2 => Processo,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProPartes";
#region PropriedadesDaTabela
    public static DBInfoSystem OppParte => new(0, PTabelaNome, CampoCodigo, Parte, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opp"
    };
    public static DBInfoSystem OppProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "opp"
    }; // DBI 11 

#endregion
#region SMART_SQLServices 
#endregion // 005 " : string.Empty)} 

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