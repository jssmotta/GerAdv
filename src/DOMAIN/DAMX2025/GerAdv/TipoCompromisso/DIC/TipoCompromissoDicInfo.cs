using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTipoCompromissoDicInfo
{
    public const string CampoCodigo = "tipCodigo";
    public const string CampoNome = "tipDescricao";
    public const string TablePrefix = "tip";
    public const string Icone = "tipIcone"; // LOCALIZACAO 170523
    public const string Descricao = "tipDescricao"; // LOCALIZACAO 170523
    public const string Financeiro = "tipFinanceiro"; // LOCALIZACAO 170523
    public const string Bold = "tipBold"; // LOCALIZACAO 170523
    public const string GUID = "tipGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "tipQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "tipDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "tipQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "tipDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "tipVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Icone,
        2 => Descricao,
        3 => Financeiro,
        4 => Bold,
        5 => GUID,
        6 => QuemCad,
        7 => DtCad,
        8 => QuemAtu,
        9 => DtAtu,
        10 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TipoCompromisso";
#region PropriedadesDaTabela
    public static DBInfoSystem TipIcone => new(0, PTabelaNome, CampoCodigo, Icone, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipFinanceiro => new(0, PTabelaNome, CampoCodigo, Financeiro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "tip"
    };
    public static DBInfoSystem TipGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tip"
    }; // DBI 11 
    public static DBInfoSystem TipDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "tip"
    }; // DBI 11 
    public static DBInfoSystem TipDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "tip"
    };
    public static DBInfoSystem TipVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "tip"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TipIcone = 1,
        TipDescricao = 2,
        TipFinanceiro = 3,
        TipBold = 4,
        TipGUID = 5,
        TipQuemCad = 6,
        TipDtCad = 7,
        TipQuemAtu = 8,
        TipDtAtu = 9,
        TipVisto = 10
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TipIcone => TipIcone,
        NomesCamposTabela.TipDescricao => TipDescricao,
        NomesCamposTabela.TipFinanceiro => TipFinanceiro,
        NomesCamposTabela.TipBold => TipBold,
        NomesCamposTabela.TipGUID => TipGUID,
        NomesCamposTabela.TipQuemCad => TipQuemCad,
        NomesCamposTabela.TipDtCad => TipDtCad,
        NomesCamposTabela.TipQuemAtu => TipQuemAtu,
        NomesCamposTabela.TipDtAtu => TipDtAtu,
        NomesCamposTabela.TipVisto => TipVisto,
        _ => null
    };
}