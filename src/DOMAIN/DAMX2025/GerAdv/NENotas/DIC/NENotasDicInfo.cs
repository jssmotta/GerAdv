using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBNENotasDicInfo
{
    public const string CampoCodigo = "nepCodigo";
    public const string CampoNome = "nepNome";
    public const string TablePrefix = "nep";
    public const string Apenso = "nepApenso"; // LOCALIZACAO 170523
    public const string Precatoria = "nepPrecatoria"; // LOCALIZACAO 170523
    public const string Instancia = "nepInstancia"; // LOCALIZACAO 170523
    public const string MovPro = "nepMovPro"; // LOCALIZACAO 170523
    public const string Nome = "nepNome"; // LOCALIZACAO 170523
    public const string NotaExpedida = "nepNotaExpedida"; // LOCALIZACAO 170523
    public const string Revisada = "nepRevisada"; // LOCALIZACAO 170523
    public const string Processo = "nepProcesso"; // LOCALIZACAO 170523
    public const string PalavraChave = "nepPalavraChave"; // LOCALIZACAO 170523
    public const string Data = "nepData"; // LOCALIZACAO 170523
    public const string NotaPublicada = "nepNotaPublicada"; // LOCALIZACAO 170523
    public const string QuemCad = "nepQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "nepDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "nepQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "nepDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "nepVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Apenso,
        2 => Precatoria,
        3 => Instancia,
        4 => MovPro,
        5 => Nome,
        6 => NotaExpedida,
        7 => Revisada,
        8 => Processo,
        9 => PalavraChave,
        10 => Data,
        11 => NotaPublicada,
        12 => QuemCad,
        13 => DtCad,
        14 => QuemAtu,
        15 => DtAtu,
        16 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "NENotas";
#region PropriedadesDaTabela
    public static DBInfoSystem NepApenso => new(0, PTabelaNome, CampoCodigo, Apenso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBApensoDicInfo.CampoCodigo, DBApensoDicInfo.TabelaNome, new DBApensoODicInfo(), false)
    {
        Prefixo = "nep"
    }; // DBI 11 
    public static DBInfoSystem NepPrecatoria => new(0, PTabelaNome, CampoCodigo, Precatoria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPrecatoriaDicInfo.CampoCodigo, DBPrecatoriaDicInfo.TabelaNome, new DBPrecatoriaODicInfo(), false)
    {
        Prefixo = "nep"
    }; // DBI 11 
    public static DBInfoSystem NepInstancia => new(0, PTabelaNome, CampoCodigo, Instancia, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBInstanciaDicInfo.CampoCodigo, DBInstanciaDicInfo.TabelaNome, new DBInstanciaODicInfo(), false)
    {
        Prefixo = "nep"
    }; // DBI 11 
    public static DBInfoSystem NepMovPro => new(0, PTabelaNome, CampoCodigo, MovPro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "nep"
    };
    public static DBInfoSystem NepNome => new(0, PTabelaNome, CampoCodigo, Nome, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "nep"
    };
    public static DBInfoSystem NepNotaExpedida => new(0, PTabelaNome, CampoCodigo, NotaExpedida, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "nep"
    };
    public static DBInfoSystem NepRevisada => new(0, PTabelaNome, CampoCodigo, Revisada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "nep"
    };
    public static DBInfoSystem NepProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "nep"
    }; // DBI 11 
    public static DBInfoSystem NepPalavraChave => new(0, PTabelaNome, CampoCodigo, PalavraChave, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "nep"
    };
    public static DBInfoSystem NepData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "nep"
    };
    public static DBInfoSystem NepNotaPublicada => new(0, PTabelaNome, CampoCodigo, NotaPublicada, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "nep"
    };
    public static DBInfoSystem NepQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "nep"
    }; // DBI 11 
    public static DBInfoSystem NepDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "nep"
    };
    public static DBInfoSystem NepQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "nep"
    }; // DBI 11 
    public static DBInfoSystem NepDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "nep"
    };
    public static DBInfoSystem NepVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "nep"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        NepApenso = 1,
        NepPrecatoria = 2,
        NepInstancia = 3,
        NepMovPro = 4,
        NepNome = 5,
        NepNotaExpedida = 6,
        NepRevisada = 7,
        NepProcesso = 8,
        NepPalavraChave = 9,
        NepData = 10,
        NepNotaPublicada = 11,
        NepQuemCad = 12,
        NepDtCad = 13,
        NepQuemAtu = 14,
        NepDtAtu = 15,
        NepVisto = 16
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.NepApenso => NepApenso,
        NomesCamposTabela.NepPrecatoria => NepPrecatoria,
        NomesCamposTabela.NepInstancia => NepInstancia,
        NomesCamposTabela.NepMovPro => NepMovPro,
        NomesCamposTabela.NepNome => NepNome,
        NomesCamposTabela.NepNotaExpedida => NepNotaExpedida,
        NomesCamposTabela.NepRevisada => NepRevisada,
        NomesCamposTabela.NepProcesso => NepProcesso,
        NomesCamposTabela.NepPalavraChave => NepPalavraChave,
        NomesCamposTabela.NepData => NepData,
        NomesCamposTabela.NepNotaPublicada => NepNotaPublicada,
        NomesCamposTabela.NepQuemCad => NepQuemCad,
        NomesCamposTabela.NepDtCad => NepDtCad,
        NomesCamposTabela.NepQuemAtu => NepQuemAtu,
        NomesCamposTabela.NepDtAtu => NepDtAtu,
        NomesCamposTabela.NepVisto => NepVisto,
        _ => null
    };
}