using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBUFDicInfo
{
    public const string CampoCodigo = "ufCodigo";
    public const string CampoNome = "ufID";
    public const string TablePrefix = "uf";
    public const string DDD = "ufDDD"; // LOCALIZACAO 170523
    public const string ID = "ufID"; // LOCALIZACAO 170523
    public const string Pais = "ufPais"; // LOCALIZACAO 170523
    public const string Top = "ufTop"; // LOCALIZACAO 170523
    public const string Descricao = "ufDescricao"; // LOCALIZACAO 170523
    public const string GUID = "ufGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ufQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ufDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ufQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ufDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ufVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => DDD,
        2 => ID,
        3 => Pais,
        4 => Top,
        5 => Descricao,
        6 => GUID,
        7 => QuemCad,
        8 => DtCad,
        9 => QuemAtu,
        10 => DtAtu,
        11 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "UF";
#region PropriedadesDaTabela
    public static DBInfoSystem UfDDD => new(0, PTabelaNome, CampoCodigo, DDD, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfID => new(0, PTabelaNome, CampoCodigo, ID, 4, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfPais => new(0, PTabelaNome, CampoCodigo, Pais, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPaisesDicInfo.CampoCodigo, DBPaisesDicInfo.TabelaNome, new DBPaisesODicInfo(), false)
    {
        Prefixo = "uf"
    }; // DBI 11 
    public static DBInfoSystem UfTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "uf"
    };
    public static DBInfoSystem UfDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "uf"
    }; // DBI 11 
    public static DBInfoSystem UfDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "uf"
    }; // DBI 11 
    public static DBInfoSystem UfDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "uf"
    };
    public static DBInfoSystem UfVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "uf"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        UfDDD = 1,
        UfID = 2,
        UfPais = 3,
        UfTop = 4,
        UfDescricao = 5,
        UfGUID = 6,
        UfQuemCad = 7,
        UfDtCad = 8,
        UfQuemAtu = 9,
        UfDtAtu = 10,
        UfVisto = 11
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.UfDDD => UfDDD,
        NomesCamposTabela.UfID => UfID,
        NomesCamposTabela.UfPais => UfPais,
        NomesCamposTabela.UfTop => UfTop,
        NomesCamposTabela.UfDescricao => UfDescricao,
        NomesCamposTabela.UfGUID => UfGUID,
        NomesCamposTabela.UfQuemCad => UfQuemCad,
        NomesCamposTabela.UfDtCad => UfDtCad,
        NomesCamposTabela.UfQuemAtu => UfQuemAtu,
        NomesCamposTabela.UfDtAtu => UfDtAtu,
        NomesCamposTabela.UfVisto => UfVisto,
        _ => null
    };
}