using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBLivroCaixaClientesDicInfo
{
    public const string CampoCodigo = "lccCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "lcc";
    public const string LivroCaixa = "lccLivroCaixa"; // LOCALIZACAO 170523
    public const string Cliente = "lccCliente"; // LOCALIZACAO 170523
    public const string Lancado = "lccLancado"; // LOCALIZACAO 170523
    public const string QuemCad = "lccQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "lccDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "lccQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "lccDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "lccVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => LivroCaixa,
        2 => Cliente,
        3 => Lancado,
        4 => QuemCad,
        5 => DtCad,
        6 => QuemAtu,
        7 => DtAtu,
        8 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "LivroCaixaClientes";
#region PropriedadesDaTabela
    public static DBInfoSystem LccLivroCaixa => new(0, PTabelaNome, CampoCodigo, LivroCaixa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBLivroCaixaDicInfo.CampoCodigo, DBLivroCaixaDicInfo.TabelaNome, new DBLivroCaixaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "lcc"
    }; // DBI 11 
    public static DBInfoSystem LccCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "lcc"
    }; // DBI 11 
    public static DBInfoSystem LccLancado => new(0, PTabelaNome, CampoCodigo, Lancado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "lcc"
    };
    public static DBInfoSystem LccQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "lcc"
    }; // DBI 11 
    public static DBInfoSystem LccDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "lcc"
    };
    public static DBInfoSystem LccQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "lcc"
    }; // DBI 11 
    public static DBInfoSystem LccDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "lcc"
    };
    public static DBInfoSystem LccVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "lcc"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        LccLivroCaixa = 1,
        LccCliente = 2,
        LccLancado = 3,
        LccQuemCad = 4,
        LccDtCad = 5,
        LccQuemAtu = 6,
        LccDtAtu = 7,
        LccVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.LccLivroCaixa => LccLivroCaixa,
        NomesCamposTabela.LccCliente => LccCliente,
        NomesCamposTabela.LccLancado => LccLancado,
        NomesCamposTabela.LccQuemCad => LccQuemCad,
        NomesCamposTabela.LccDtCad => LccDtCad,
        NomesCamposTabela.LccQuemAtu => LccQuemAtu,
        NomesCamposTabela.LccDtAtu => LccDtAtu,
        NomesCamposTabela.LccVisto => LccVisto,
        _ => null
    };
}