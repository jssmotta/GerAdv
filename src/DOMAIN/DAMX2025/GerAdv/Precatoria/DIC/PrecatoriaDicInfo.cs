using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBPrecatoriaDicInfo
{
    public const string CampoCodigo = "preCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "pre";
    public const string DtDist = "preDtDist"; // LOCALIZACAO 170523
    public const string Processo = "preProcesso"; // LOCALIZACAO 170523
    public const string Precatoria = "prePrecatoria"; // LOCALIZACAO 170523
    public const string Deprecante = "preDeprecante"; // LOCALIZACAO 170523
    public const string Deprecado = "preDeprecado"; // LOCALIZACAO 170523
    public const string OBS = "preOBS"; // LOCALIZACAO 170523
    public const string Bold = "preBold"; // LOCALIZACAO 170523
    public const string GUID = "preGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "preQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "preDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "preQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "preDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "preVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => DtDist,
        2 => Processo,
        3 => Precatoria,
        4 => Deprecante,
        5 => Deprecado,
        6 => OBS,
        7 => Bold,
        8 => GUID,
        9 => QuemCad,
        10 => DtCad,
        11 => QuemAtu,
        12 => DtAtu,
        13 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Precatoria";
#region PropriedadesDaTabela
    public static DBInfoSystem PreDtDist => new(0, PTabelaNome, CampoCodigo, DtDist, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "pre"
    };
    public static DBInfoSystem PreProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "pre"
    }; // DBI 11 
    public static DBInfoSystem PrePrecatoria => new(0, PTabelaNome, CampoCodigo, Precatoria, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pre"
    };
    public static DBInfoSystem PreDeprecante => new(0, PTabelaNome, CampoCodigo, Deprecante, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pre"
    };
    public static DBInfoSystem PreDeprecado => new(0, PTabelaNome, CampoCodigo, Deprecado, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "pre"
    };
    public static DBInfoSystem PreOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "pre"
    };
    public static DBInfoSystem PreBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "pre"
    };
    public static DBInfoSystem PreGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "pre"
    };
    public static DBInfoSystem PreQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pre"
    }; // DBI 11 
    public static DBInfoSystem PreDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "pre"
    };
    public static DBInfoSystem PreQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pre"
    }; // DBI 11 
    public static DBInfoSystem PreDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "pre"
    };
    public static DBInfoSystem PreVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "pre"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PreDtDist = 1,
        PreProcesso = 2,
        PrePrecatoria = 3,
        PreDeprecante = 4,
        PreDeprecado = 5,
        PreOBS = 6,
        PreBold = 7,
        PreGUID = 8,
        PreQuemCad = 9,
        PreDtCad = 10,
        PreQuemAtu = 11,
        PreDtAtu = 12,
        PreVisto = 13
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PreDtDist => PreDtDist,
        NomesCamposTabela.PreProcesso => PreProcesso,
        NomesCamposTabela.PrePrecatoria => PrePrecatoria,
        NomesCamposTabela.PreDeprecante => PreDeprecante,
        NomesCamposTabela.PreDeprecado => PreDeprecado,
        NomesCamposTabela.PreOBS => PreOBS,
        NomesCamposTabela.PreBold => PreBold,
        NomesCamposTabela.PreGUID => PreGUID,
        NomesCamposTabela.PreQuemCad => PreQuemCad,
        NomesCamposTabela.PreDtCad => PreDtCad,
        NomesCamposTabela.PreQuemAtu => PreQuemAtu,
        NomesCamposTabela.PreDtAtu => PreDtAtu,
        NomesCamposTabela.PreVisto => PreVisto,
        _ => null
    };
}