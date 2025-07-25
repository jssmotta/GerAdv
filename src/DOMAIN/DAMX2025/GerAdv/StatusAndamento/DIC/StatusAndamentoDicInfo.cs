using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBStatusAndamentoDicInfo
{
    public const string CampoCodigo = "sanCodigo";
    public const string CampoNome = "sanNome";
    public const string TablePrefix = "san";
    public const string Nome = "sanNome"; // LOCALIZACAO 170523
    public const string Icone = "sanIcone"; // LOCALIZACAO 170523
    public const string Bold = "sanBold"; // LOCALIZACAO 170523
    public const string GUID = "sanGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "sanQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "sanDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "sanQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "sanDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "sanVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Icone,
        3 => Bold,
        4 => GUID,
        5 => QuemCad,
        6 => DtCad,
        7 => QuemAtu,
        8 => DtAtu,
        9 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "StatusAndamento";
#region PropriedadesDaTabela
    public static DBInfoSystem SanNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "san"
    };
    public static DBInfoSystem SanIcone => new(0, PTabelaNome, CampoCodigo, Icone, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "san"
    };
    public static DBInfoSystem SanBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "san"
    };
    public static DBInfoSystem SanGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "san"
    };
    public static DBInfoSystem SanQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "san"
    }; // DBI 11 
    public static DBInfoSystem SanDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "san"
    };
    public static DBInfoSystem SanQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "san"
    }; // DBI 11 
    public static DBInfoSystem SanDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "san"
    };
    public static DBInfoSystem SanVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "san"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        SanNome = 1,
        SanIcone = 2,
        SanBold = 3,
        SanGUID = 4,
        SanQuemCad = 5,
        SanDtCad = 6,
        SanQuemAtu = 7,
        SanDtAtu = 8,
        SanVisto = 9
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.SanNome => SanNome,
        NomesCamposTabela.SanIcone => SanIcone,
        NomesCamposTabela.SanBold => SanBold,
        NomesCamposTabela.SanGUID => SanGUID,
        NomesCamposTabela.SanQuemCad => SanQuemCad,
        NomesCamposTabela.SanDtCad => SanDtCad,
        NomesCamposTabela.SanQuemAtu => SanQuemAtu,
        NomesCamposTabela.SanDtAtu => SanDtAtu,
        NomesCamposTabela.SanVisto => SanVisto,
        _ => null
    };
}