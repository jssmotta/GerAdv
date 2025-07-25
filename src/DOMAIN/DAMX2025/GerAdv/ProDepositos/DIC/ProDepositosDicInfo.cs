using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProDepositosDicInfo
{
    public const string CampoCodigo = "pdsCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "pds";
    public const string Processo = "pdsProcesso"; // LOCALIZACAO 170523
    public const string Fase = "pdsFase"; // LOCALIZACAO 170523
    public const string Data = "pdsData"; // LOCALIZACAO 170523
    public const string Valor = "pdsValor"; // LOCALIZACAO 170523
    public const string TipoProDesposito = "pdsTipoProDesposito"; // LOCALIZACAO 170523
    public const string QuemCad = "pdsQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "pdsDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "pdsQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "pdsDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "pdsVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Fase,
        3 => Data,
        4 => Valor,
        5 => TipoProDesposito,
        6 => QuemCad,
        7 => DtCad,
        8 => QuemAtu,
        9 => DtAtu,
        10 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProDepositos";
#region PropriedadesDaTabela
    public static DBInfoSystem PdsProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "pds"
    }; // DBI 11 
    public static DBInfoSystem PdsFase => new(0, PTabelaNome, CampoCodigo, Fase, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFaseDicInfo.CampoCodigo, DBFaseDicInfo.TabelaNome, new DBFaseODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "pds"
    }; // DBI 11 
    public static DBInfoSystem PdsData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "pds"
    };
    public static DBInfoSystem PdsValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        IsRequired = true,
        Prefixo = "pds"
    };
    public static DBInfoSystem PdsTipoProDesposito => new(0, PTabelaNome, CampoCodigo, TipoProDesposito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoProDespositoDicInfo.CampoCodigo, DBTipoProDespositoDicInfo.TabelaNome, new DBTipoProDespositoODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "pds"
    }; // DBI 11 
    public static DBInfoSystem PdsQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "pds"
    }; // DBI 11 
    public static DBInfoSystem PdsDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "pds"
    };
    public static DBInfoSystem PdsQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pds"
    }; // DBI 11 
    public static DBInfoSystem PdsDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "pds"
    };
    public static DBInfoSystem PdsVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "pds"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PdsProcesso = 1,
        PdsFase = 2,
        PdsData = 3,
        PdsValor = 4,
        PdsTipoProDesposito = 5,
        PdsQuemCad = 6,
        PdsDtCad = 7,
        PdsQuemAtu = 8,
        PdsDtAtu = 9,
        PdsVisto = 10
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PdsProcesso => PdsProcesso,
        NomesCamposTabela.PdsFase => PdsFase,
        NomesCamposTabela.PdsData => PdsData,
        NomesCamposTabela.PdsValor => PdsValor,
        NomesCamposTabela.PdsTipoProDesposito => PdsTipoProDesposito,
        NomesCamposTabela.PdsQuemCad => PdsQuemCad,
        NomesCamposTabela.PdsDtCad => PdsDtCad,
        NomesCamposTabela.PdsQuemAtu => PdsQuemAtu,
        NomesCamposTabela.PdsDtAtu => PdsDtAtu,
        NomesCamposTabela.PdsVisto => PdsVisto,
        _ => null
    };
}