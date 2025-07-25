using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBCargosDicInfo
{
    public const string CampoCodigo = "carCodigo";
    public const string CampoNome = "carNome";
    public const string TablePrefix = "car";
    public const string Nome = "carNome"; // LOCALIZACAO 170523
    public const string QuemCad = "carQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "carDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "carQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "carDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "carVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => QuemCad,
        3 => DtCad,
        4 => QuemAtu,
        5 => DtAtu,
        6 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Cargos";
#region PropriedadesDaTabela
    public static DBInfoSystem CarNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "car"
    };
    public static DBInfoSystem CarQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "car"
    }; // DBI 11 
    public static DBInfoSystem CarDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "car"
    };
    public static DBInfoSystem CarQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "car"
    }; // DBI 11 
    public static DBInfoSystem CarDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "car"
    };
    public static DBInfoSystem CarVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "car"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        CarNome = 1,
        CarQuemCad = 2,
        CarDtCad = 3,
        CarQuemAtu = 4,
        CarDtAtu = 5,
        CarVisto = 6
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CarNome => CarNome,
        NomesCamposTabela.CarQuemCad => CarQuemCad,
        NomesCamposTabela.CarDtCad => CarDtCad,
        NomesCamposTabela.CarQuemAtu => CarQuemAtu,
        NomesCamposTabela.CarDtAtu => CarDtAtu,
        NomesCamposTabela.CarVisto => CarVisto,
        _ => null
    };
}