using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProValoresDicInfo
{
    public const string CampoCodigo = "prvCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "prv";
    public const string Processo = "prvProcesso"; // LOCALIZACAO 170523
    public const string TipoValorProcesso = "prvTipoValorProcesso"; // LOCALIZACAO 170523
    public const string Indice = "prvIndice"; // LOCALIZACAO 170523
    public const string Ignorar = "prvIgnorar"; // LOCALIZACAO 170523
    public const string Data = "prvData"; // LOCALIZACAO 170523
    public const string ValorOriginal = "prvValorOriginal"; // LOCALIZACAO 170523
    public const string PercMulta = "prvPercMulta"; // LOCALIZACAO 170523
    public const string ValorMulta = "prvValorMulta"; // LOCALIZACAO 170523
    public const string PercJuros = "prvPercJuros"; // LOCALIZACAO 170523
    public const string ValorOriginalCorrigidoIndice = "prvValorOriginalCorrigidoIndice"; // LOCALIZACAO 170523
    public const string ValorMultaCorrigido = "prvValorMultaCorrigido"; // LOCALIZACAO 170523
    public const string ValorJurosCorrigido = "prvValorJurosCorrigido"; // LOCALIZACAO 170523
    public const string ValorFinal = "prvValorFinal"; // LOCALIZACAO 170523
    public const string DataUltimaCorrecao = "prvDataUltimaCorrecao"; // LOCALIZACAO 170523
    public const string GUID = "prvGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "prvQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "prvDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "prvQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "prvDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "prvVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => TipoValorProcesso,
        3 => Indice,
        4 => Ignorar,
        5 => Data,
        6 => ValorOriginal,
        7 => PercMulta,
        8 => ValorMulta,
        9 => PercJuros,
        10 => ValorOriginalCorrigidoIndice,
        11 => ValorMultaCorrigido,
        12 => ValorJurosCorrigido,
        13 => ValorFinal,
        14 => DataUltimaCorrecao,
        15 => GUID,
        16 => QuemCad,
        17 => DtCad,
        18 => QuemAtu,
        19 => DtAtu,
        20 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProValores";
#region PropriedadesDaTabela
    public static DBInfoSystem PrvProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "prv"
    }; // DBI 11 
    public static DBInfoSystem PrvTipoValorProcesso => new(0, PTabelaNome, CampoCodigo, TipoValorProcesso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoValorProcessoDicInfo.CampoCodigo, DBTipoValorProcessoDicInfo.TabelaNome, new DBTipoValorProcessoODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "prv"
    }; // DBI 11 
    public static DBInfoSystem PrvIndice => new(0, PTabelaNome, CampoCodigo, Indice, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        IsRequired = true,
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvIgnorar => new(0, PTabelaNome, CampoCodigo, Ignorar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvValorOriginal => new(0, PTabelaNome, CampoCodigo, ValorOriginal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        IsRequired = true,
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvPercMulta => new(0, PTabelaNome, CampoCodigo, PercMulta, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvValorMulta => new(0, PTabelaNome, CampoCodigo, ValorMulta, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvPercJuros => new(0, PTabelaNome, CampoCodigo, PercJuros, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvValorOriginalCorrigidoIndice => new(0, PTabelaNome, CampoCodigo, ValorOriginalCorrigidoIndice, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvValorMultaCorrigido => new(0, PTabelaNome, CampoCodigo, ValorMultaCorrigido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvValorJurosCorrigido => new(0, PTabelaNome, CampoCodigo, ValorJurosCorrigido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvValorFinal => new(0, PTabelaNome, CampoCodigo, ValorFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvDataUltimaCorrecao => new(0, PTabelaNome, CampoCodigo, DataUltimaCorrecao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvGUID => new(0, PTabelaNome, CampoCodigo, GUID, 50, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "prv"
    }; // DBI 11 
    public static DBInfoSystem PrvDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "prv"
    }; // DBI 11 
    public static DBInfoSystem PrvDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "prv"
    };
    public static DBInfoSystem PrvVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "prv"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PrvProcesso = 1,
        PrvTipoValorProcesso = 2,
        PrvIndice = 3,
        PrvIgnorar = 4,
        PrvData = 5,
        PrvValorOriginal = 6,
        PrvPercMulta = 7,
        PrvValorMulta = 8,
        PrvPercJuros = 9,
        PrvValorOriginalCorrigidoIndice = 10,
        PrvValorMultaCorrigido = 11,
        PrvValorJurosCorrigido = 12,
        PrvValorFinal = 13,
        PrvDataUltimaCorrecao = 14,
        PrvGUID = 15,
        PrvQuemCad = 16,
        PrvDtCad = 17,
        PrvQuemAtu = 18,
        PrvDtAtu = 19,
        PrvVisto = 20
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PrvProcesso => PrvProcesso,
        NomesCamposTabela.PrvTipoValorProcesso => PrvTipoValorProcesso,
        NomesCamposTabela.PrvIndice => PrvIndice,
        NomesCamposTabela.PrvIgnorar => PrvIgnorar,
        NomesCamposTabela.PrvData => PrvData,
        NomesCamposTabela.PrvValorOriginal => PrvValorOriginal,
        NomesCamposTabela.PrvPercMulta => PrvPercMulta,
        NomesCamposTabela.PrvValorMulta => PrvValorMulta,
        NomesCamposTabela.PrvPercJuros => PrvPercJuros,
        NomesCamposTabela.PrvValorOriginalCorrigidoIndice => PrvValorOriginalCorrigidoIndice,
        NomesCamposTabela.PrvValorMultaCorrigido => PrvValorMultaCorrigido,
        NomesCamposTabela.PrvValorJurosCorrigido => PrvValorJurosCorrigido,
        NomesCamposTabela.PrvValorFinal => PrvValorFinal,
        NomesCamposTabela.PrvDataUltimaCorrecao => PrvDataUltimaCorrecao,
        NomesCamposTabela.PrvGUID => PrvGUID,
        NomesCamposTabela.PrvQuemCad => PrvQuemCad,
        NomesCamposTabela.PrvDtCad => PrvDtCad,
        NomesCamposTabela.PrvQuemAtu => PrvQuemAtu,
        NomesCamposTabela.PrvDtAtu => PrvDtAtu,
        NomesCamposTabela.PrvVisto => PrvVisto,
        _ => null
    };
}