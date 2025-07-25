using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBPontoVirtualDicInfo
{
    public const string CampoCodigo = "pvtCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "pvt";
    public const string HoraEntrada = "pvtHoraEntrada"; // LOCALIZACAO 170523
    public const string HoraSaida = "pvtHoraSaida"; // LOCALIZACAO 170523
    public const string Operador = "pvtOperador"; // LOCALIZACAO 170523
    public const string Key = "pvtKey"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => HoraEntrada,
        2 => HoraSaida,
        3 => Operador,
        4 => Key,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "PontoVirtual";
#region PropriedadesDaTabela
    public static DBInfoSystem PvtHoraEntrada => new(0, PTabelaNome, CampoCodigo, HoraEntrada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "pvt"
    };
    public static DBInfoSystem PvtHoraSaida => new(0, PTabelaNome, CampoCodigo, HoraSaida, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "pvt"
    };
    public static DBInfoSystem PvtOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "pvt"
    }; // DBI 11 
    public static DBInfoSystem PvtKey => new(0, PTabelaNome, CampoCodigo, Key, 23, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pvt"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PvtHoraEntrada = 1,
        PvtHoraSaida = 2,
        PvtOperador = 3,
        PvtKey = 4
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PvtHoraEntrada => PvtHoraEntrada,
        NomesCamposTabela.PvtHoraSaida => PvtHoraSaida,
        NomesCamposTabela.PvtOperador => PvtOperador,
        NomesCamposTabela.PvtKey => PvtKey,
        _ => null
    };
}