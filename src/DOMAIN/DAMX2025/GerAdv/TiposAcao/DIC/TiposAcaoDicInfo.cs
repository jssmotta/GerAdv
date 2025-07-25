using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTiposAcaoDicInfo
{
    public const string CampoCodigo = "tacCodigo";
    public const string CampoNome = "tacNome";
    public const string TablePrefix = "tac";
    public const string Nome = "tacNome"; // LOCALIZACAO 170523
    public const string Inativo = "tacInativo"; // LOCALIZACAO 170523
    public const string Bold = "tacBold"; // LOCALIZACAO 170523
    public const string GUID = "tacGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "tacQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "tacDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "tacQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "tacDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "tacVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Inativo,
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

    public const string PTabelaNome = "TiposAcao";
#region PropriedadesDaTabela
    public static DBInfoSystem TacNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "tac"
    };
    public static DBInfoSystem TacInativo => new(0, PTabelaNome, CampoCodigo, Inativo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "tac"
    };
    public static DBInfoSystem TacBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "tac"
    };
    public static DBInfoSystem TacGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "tac"
    };
    public static DBInfoSystem TacQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tac"
    }; // DBI 11 
    public static DBInfoSystem TacDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "tac"
    };
    public static DBInfoSystem TacQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tac"
    }; // DBI 11 
    public static DBInfoSystem TacDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "tac"
    };
    public static DBInfoSystem TacVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "tac"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TacNome = 1,
        TacInativo = 2,
        TacBold = 3,
        TacGUID = 4,
        TacQuemCad = 5,
        TacDtCad = 6,
        TacQuemAtu = 7,
        TacDtAtu = 8,
        TacVisto = 9
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TacNome => TacNome,
        NomesCamposTabela.TacInativo => TacInativo,
        NomesCamposTabela.TacBold => TacBold,
        NomesCamposTabela.TacGUID => TacGUID,
        NomesCamposTabela.TacQuemCad => TacQuemCad,
        NomesCamposTabela.TacDtCad => TacDtCad,
        NomesCamposTabela.TacQuemAtu => TacQuemAtu,
        NomesCamposTabela.TacDtAtu => TacDtAtu,
        NomesCamposTabela.TacVisto => TacVisto,
        _ => null
    };
}