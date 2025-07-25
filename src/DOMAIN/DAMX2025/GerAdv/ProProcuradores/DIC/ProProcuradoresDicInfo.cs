using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProProcuradoresDicInfo
{
    public const string CampoCodigo = "papCodigo";
    public const string CampoNome = "papNome";
    public const string TablePrefix = "pap";
    public const string Advogado = "papAdvogado"; // LOCALIZACAO 170523
    public const string Nome = "papNome"; // LOCALIZACAO 170523
    public const string Processo = "papProcesso"; // LOCALIZACAO 170523
    public const string Data = "papData"; // LOCALIZACAO 170523
    public const string Substabelecimento = "papSubstabelecimento"; // LOCALIZACAO 170523
    public const string Procuracao = "papProcuracao"; // LOCALIZACAO 170523
    public const string Bold = "papBold"; // LOCALIZACAO 170523
    public const string GUID = "papGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "papQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "papDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "papQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "papDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "papVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Advogado,
        2 => Nome,
        3 => Processo,
        4 => Data,
        5 => Substabelecimento,
        6 => Procuracao,
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

    public const string PTabelaNome = "ProProcuradores";
#region PropriedadesDaTabela
    public static DBInfoSystem PapAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false)
    {
        Prefixo = "pap"
    }; // DBI 11 
    public static DBInfoSystem PapNome => new(0, PTabelaNome, CampoCodigo, Nome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "pap"
    };
    public static DBInfoSystem PapProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "pap"
    }; // DBI 11 
    public static DBInfoSystem PapData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "pap"
    };
    public static DBInfoSystem PapSubstabelecimento => new(0, PTabelaNome, CampoCodigo, Substabelecimento, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pap"
    };
    public static DBInfoSystem PapProcuracao => new(0, PTabelaNome, CampoCodigo, Procuracao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "pap"
    };
    public static DBInfoSystem PapBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "pap"
    };
    public static DBInfoSystem PapGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "pap"
    };
    public static DBInfoSystem PapQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pap"
    }; // DBI 11 
    public static DBInfoSystem PapDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "pap"
    };
    public static DBInfoSystem PapQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pap"
    }; // DBI 11 
    public static DBInfoSystem PapDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "pap"
    };
    public static DBInfoSystem PapVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "pap"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PapAdvogado = 1,
        PapNome = 2,
        PapProcesso = 3,
        PapData = 4,
        PapSubstabelecimento = 5,
        PapProcuracao = 6,
        PapBold = 7,
        PapGUID = 8,
        PapQuemCad = 9,
        PapDtCad = 10,
        PapQuemAtu = 11,
        PapDtAtu = 12,
        PapVisto = 13
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PapAdvogado => PapAdvogado,
        NomesCamposTabela.PapNome => PapNome,
        NomesCamposTabela.PapProcesso => PapProcesso,
        NomesCamposTabela.PapData => PapData,
        NomesCamposTabela.PapSubstabelecimento => PapSubstabelecimento,
        NomesCamposTabela.PapProcuracao => PapProcuracao,
        NomesCamposTabela.PapBold => PapBold,
        NomesCamposTabela.PapGUID => PapGUID,
        NomesCamposTabela.PapQuemCad => PapQuemCad,
        NomesCamposTabela.PapDtCad => PapDtCad,
        NomesCamposTabela.PapQuemAtu => PapQuemAtu,
        NomesCamposTabela.PapDtAtu => PapDtAtu,
        NomesCamposTabela.PapVisto => PapVisto,
        _ => null
    };
}