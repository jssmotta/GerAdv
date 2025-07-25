using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBNECompromissosDicInfo
{
    public const string CampoCodigo = "ncpCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ncp";
    public const string PalavraChave = "ncpPalavraChave"; // LOCALIZACAO 170523
    public const string Provisionar = "ncpProvisionar"; // LOCALIZACAO 170523
    public const string TipoCompromisso = "ncpTipoCompromisso"; // LOCALIZACAO 170523
    public const string TextoCompromisso = "ncpTextoCompromisso"; // LOCALIZACAO 170523
    public const string Bold = "ncpBold"; // LOCALIZACAO 170523
    public const string QuemCad = "ncpQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ncpDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ncpQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ncpDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ncpVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => PalavraChave,
        2 => Provisionar,
        3 => TipoCompromisso,
        4 => TextoCompromisso,
        5 => Bold,
        6 => QuemCad,
        7 => DtCad,
        8 => QuemAtu,
        9 => DtAtu,
        10 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "NECompromissos";
#region PropriedadesDaTabela
    public static DBInfoSystem NcpPalavraChave => new(0, PTabelaNome, CampoCodigo, PalavraChave, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpProvisionar => new(0, PTabelaNome, CampoCodigo, Provisionar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpTipoCompromisso => new(0, PTabelaNome, CampoCodigo, TipoCompromisso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoCompromissoDicInfo.CampoCodigo, DBTipoCompromissoDicInfo.TabelaNome, new DBTipoCompromissoODicInfo(), false)
    {
        Prefixo = "ncp"
    }; // DBI 11 
    public static DBInfoSystem NcpTextoCompromisso => new(0, PTabelaNome, CampoCodigo, TextoCompromisso, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ncp"
    }; // DBI 11 
    public static DBInfoSystem NcpDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ncp"
    }; // DBI 11 
    public static DBInfoSystem NcpDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ncp"
    };
    public static DBInfoSystem NcpVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ncp"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        NcpPalavraChave = 1,
        NcpProvisionar = 2,
        NcpTipoCompromisso = 3,
        NcpTextoCompromisso = 4,
        NcpBold = 5,
        NcpQuemCad = 6,
        NcpDtCad = 7,
        NcpQuemAtu = 8,
        NcpDtAtu = 9,
        NcpVisto = 10
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.NcpPalavraChave => NcpPalavraChave,
        NomesCamposTabela.NcpProvisionar => NcpProvisionar,
        NomesCamposTabela.NcpTipoCompromisso => NcpTipoCompromisso,
        NomesCamposTabela.NcpTextoCompromisso => NcpTextoCompromisso,
        NomesCamposTabela.NcpBold => NcpBold,
        NomesCamposTabela.NcpQuemCad => NcpQuemCad,
        NomesCamposTabela.NcpDtCad => NcpDtCad,
        NomesCamposTabela.NcpQuemAtu => NcpQuemAtu,
        NomesCamposTabela.NcpDtAtu => NcpDtAtu,
        NomesCamposTabela.NcpVisto => NcpVisto,
        _ => null
    };
}