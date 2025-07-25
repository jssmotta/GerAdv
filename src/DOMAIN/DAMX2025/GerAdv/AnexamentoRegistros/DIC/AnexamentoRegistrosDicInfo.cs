using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAnexamentoRegistrosDicInfo
{
    public const string CampoCodigo = "axrCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "axr";
    public const string Cliente = "axrCliente"; // LOCALIZACAO 170523
    public const string GUIDReg = "axrGUIDReg"; // LOCALIZACAO 170523
    public const string CodigoReg = "axrCodigoReg"; // LOCALIZACAO 170523
    public const string IDReg = "axrIDReg"; // LOCALIZACAO 170523
    public const string Data = "axrData"; // LOCALIZACAO 170523
    public const string GUID = "axrGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "axrQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "axrDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "axrQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "axrDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "axrVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cliente,
        2 => GUIDReg,
        3 => CodigoReg,
        4 => IDReg,
        5 => Data,
        6 => GUID,
        7 => QuemCad,
        8 => DtCad,
        9 => QuemAtu,
        10 => DtAtu,
        11 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AnexamentoRegistros";
#region PropriedadesDaTabela
    public static DBInfoSystem AxrCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "axr"
    }; // DBI 11 
    public static DBInfoSystem AxrGUIDReg => new(0, PTabelaNome, CampoCodigo, GUIDReg, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "axr"
    };
    public static DBInfoSystem AxrCodigoReg => new(0, PTabelaNome, CampoCodigo, CodigoReg, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "axr"
    };
    public static DBInfoSystem AxrIDReg => new(0, PTabelaNome, CampoCodigo, IDReg, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "axr"
    };
    public static DBInfoSystem AxrData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "axr"
    };
    public static DBInfoSystem AxrGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "axr"
    };
    public static DBInfoSystem AxrQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "axr"
    }; // DBI 11 
    public static DBInfoSystem AxrDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "axr"
    };
    public static DBInfoSystem AxrQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "axr"
    }; // DBI 11 
    public static DBInfoSystem AxrDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "axr"
    };
    public static DBInfoSystem AxrVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "axr"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        AxrCliente = 1,
        AxrGUIDReg = 2,
        AxrCodigoReg = 3,
        AxrIDReg = 4,
        AxrData = 5,
        AxrGUID = 6,
        AxrQuemCad = 7,
        AxrDtCad = 8,
        AxrQuemAtu = 9,
        AxrDtAtu = 10,
        AxrVisto = 11
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AxrCliente => AxrCliente,
        NomesCamposTabela.AxrGUIDReg => AxrGUIDReg,
        NomesCamposTabela.AxrCodigoReg => AxrCodigoReg,
        NomesCamposTabela.AxrIDReg => AxrIDReg,
        NomesCamposTabela.AxrData => AxrData,
        NomesCamposTabela.AxrGUID => AxrGUID,
        NomesCamposTabela.AxrQuemCad => AxrQuemCad,
        NomesCamposTabela.AxrDtCad => AxrDtCad,
        NomesCamposTabela.AxrQuemAtu => AxrQuemAtu,
        NomesCamposTabela.AxrDtAtu => AxrDtAtu,
        NomesCamposTabela.AxrVisto => AxrVisto,
        _ => null
    };
}