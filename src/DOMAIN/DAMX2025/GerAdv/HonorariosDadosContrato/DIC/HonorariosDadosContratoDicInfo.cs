using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBHonorariosDadosContratoDicInfo
{
    public const string CampoCodigo = "hdcCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "hdc";
    public const string Cliente = "hdcCliente"; // LOCALIZACAO 170523
    public const string Fixo = "hdcFixo"; // LOCALIZACAO 170523
    public const string Variavel = "hdcVariavel"; // LOCALIZACAO 170523
    public const string PercSucesso = "hdcPercSucesso"; // LOCALIZACAO 170523
    public const string Processo = "hdcProcesso"; // LOCALIZACAO 170523
    public const string ArquivoContrato = "hdcArquivoContrato"; // LOCALIZACAO 170523
    public const string TextoContrato = "hdcTextoContrato"; // LOCALIZACAO 170523
    public const string ValorFixo = "hdcValorFixo"; // LOCALIZACAO 170523
    public const string Observacao = "hdcObservacao"; // LOCALIZACAO 170523
    public const string DataContrato = "hdcDataContrato"; // LOCALIZACAO 170523
    public const string GUID = "hdcGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "hdcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "hdcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "hdcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "hdcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "hdcVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cliente,
        2 => Fixo,
        3 => Variavel,
        4 => PercSucesso,
        5 => Processo,
        6 => ArquivoContrato,
        7 => TextoContrato,
        8 => ValorFixo,
        9 => Observacao,
        10 => DataContrato,
        11 => GUID,
        12 => QuemCad,
        13 => DtCad,
        14 => QuemAtu,
        15 => DtAtu,
        16 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "HonorariosDadosContrato";
#region PropriedadesDaTabela
    public static DBInfoSystem HdcCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "hdc"
    }; // DBI 11 
    public static DBInfoSystem HdcFixo => new(0, PTabelaNome, CampoCodigo, Fixo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcVariavel => new(0, PTabelaNome, CampoCodigo, Variavel, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcPercSucesso => new(0, PTabelaNome, CampoCodigo, PercSucesso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "hdc"
    }; // DBI 11 
    public static DBInfoSystem HdcArquivoContrato => new(0, PTabelaNome, CampoCodigo, ArquivoContrato, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcTextoContrato => new(0, PTabelaNome, CampoCodigo, TextoContrato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcValorFixo => new(0, PTabelaNome, CampoCodigo, ValorFixo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcDataContrato => new(0, PTabelaNome, CampoCodigo, DataContrato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "hdc"
    }; // DBI 11 
    public static DBInfoSystem HdcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "hdc"
    }; // DBI 11 
    public static DBInfoSystem HdcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "hdc"
    };
    public static DBInfoSystem HdcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "hdc"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        HdcCliente = 1,
        HdcFixo = 2,
        HdcVariavel = 3,
        HdcPercSucesso = 4,
        HdcProcesso = 5,
        HdcArquivoContrato = 6,
        HdcTextoContrato = 7,
        HdcValorFixo = 8,
        HdcObservacao = 9,
        HdcDataContrato = 10,
        HdcGUID = 11,
        HdcQuemCad = 12,
        HdcDtCad = 13,
        HdcQuemAtu = 14,
        HdcDtAtu = 15,
        HdcVisto = 16
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.HdcCliente => HdcCliente,
        NomesCamposTabela.HdcFixo => HdcFixo,
        NomesCamposTabela.HdcVariavel => HdcVariavel,
        NomesCamposTabela.HdcPercSucesso => HdcPercSucesso,
        NomesCamposTabela.HdcProcesso => HdcProcesso,
        NomesCamposTabela.HdcArquivoContrato => HdcArquivoContrato,
        NomesCamposTabela.HdcTextoContrato => HdcTextoContrato,
        NomesCamposTabela.HdcValorFixo => HdcValorFixo,
        NomesCamposTabela.HdcObservacao => HdcObservacao,
        NomesCamposTabela.HdcDataContrato => HdcDataContrato,
        NomesCamposTabela.HdcGUID => HdcGUID,
        NomesCamposTabela.HdcQuemCad => HdcQuemCad,
        NomesCamposTabela.HdcDtCad => HdcDtCad,
        NomesCamposTabela.HdcQuemAtu => HdcQuemAtu,
        NomesCamposTabela.HdcDtAtu => HdcDtAtu,
        NomesCamposTabela.HdcVisto => HdcVisto,
        _ => null
    };
}