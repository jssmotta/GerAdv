using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAgendaRepetirDiasDicInfo
{
    public const string CampoCodigo = "rpdCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "rpd";
    public const string HoraFinal = "rpdHoraFinal"; // LOCALIZACAO 170523
    public const string Master = "rpdMaster"; // LOCALIZACAO 170523
    public const string Dia = "rpdDia"; // LOCALIZACAO 170523
    public const string Hora = "rpdHora"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => HoraFinal,
        2 => Master,
        3 => Dia,
        4 => Hora,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaRepetirDias";
#region PropriedadesDaTabela
    public static DBInfoSystem RpdHoraFinal => new(0, PTabelaNome, CampoCodigo, HoraFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "rpd"
    };
    public static DBInfoSystem RpdMaster => new(0, PTabelaNome, CampoCodigo, Master, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rpd"
    };
    public static DBInfoSystem RpdDia => new(0, PTabelaNome, CampoCodigo, Dia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rpd"
    };
    public static DBInfoSystem RpdHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "rpd"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        RpdHoraFinal = 1,
        RpdMaster = 2,
        RpdDia = 3,
        RpdHora = 4
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RpdHoraFinal => RpdHoraFinal,
        NomesCamposTabela.RpdMaster => RpdMaster,
        NomesCamposTabela.RpdDia => RpdDia,
        NomesCamposTabela.RpdHora => RpdHora,
        _ => null
    };
}