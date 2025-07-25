using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBDocsRecebidosItensDicInfo
{
    public const string CampoCodigo = "driCodigo";
    public const string CampoNome = "driNome";
    public const string TablePrefix = "dri";
    public const string ContatoCRM = "driContatoCRM"; // LOCALIZACAO 170523
    public const string Nome = "driNome"; // LOCALIZACAO 170523
    public const string Devolvido = "driDevolvido"; // LOCALIZACAO 170523
    public const string SeraDevolvido = "driSeraDevolvido"; // LOCALIZACAO 170523
    public const string Observacoes = "driObservacoes"; // LOCALIZACAO 170523
    public const string Bold = "driBold"; // LOCALIZACAO 170523
    public const string GUID = "driGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "driQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "driDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "driQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "driDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "driVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => ContatoCRM,
        2 => Nome,
        3 => Devolvido,
        4 => SeraDevolvido,
        5 => Observacoes,
        6 => Bold,
        7 => GUID,
        8 => QuemCad,
        9 => DtCad,
        10 => QuemAtu,
        11 => DtAtu,
        12 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "DocsRecebidosItens";
#region PropriedadesDaTabela
    public static DBInfoSystem DriContatoCRM => new(0, PTabelaNome, CampoCodigo, ContatoCRM, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBContatoCRMDicInfo.CampoCodigo, DBContatoCRMDicInfo.TabelaNome, new DBContatoCRMODicInfo(), false)
    {
        Prefixo = "dri"
    }; // DBI 11 
    public static DBInfoSystem DriNome => new(0, PTabelaNome, CampoCodigo, Nome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "dri"
    };
    public static DBInfoSystem DriDevolvido => new(0, PTabelaNome, CampoCodigo, Devolvido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "dri"
    };
    public static DBInfoSystem DriSeraDevolvido => new(0, PTabelaNome, CampoCodigo, SeraDevolvido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "dri"
    };
    public static DBInfoSystem DriObservacoes => new(0, PTabelaNome, CampoCodigo, Observacoes, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "dri"
    };
    public static DBInfoSystem DriBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "dri"
    };
    public static DBInfoSystem DriGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "dri"
    };
    public static DBInfoSystem DriQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "dri"
    }; // DBI 11 
    public static DBInfoSystem DriDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "dri"
    };
    public static DBInfoSystem DriQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "dri"
    }; // DBI 11 
    public static DBInfoSystem DriDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "dri"
    };
    public static DBInfoSystem DriVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "dri"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        DriContatoCRM = 1,
        DriNome = 2,
        DriDevolvido = 3,
        DriSeraDevolvido = 4,
        DriObservacoes = 5,
        DriBold = 6,
        DriGUID = 7,
        DriQuemCad = 8,
        DriDtCad = 9,
        DriQuemAtu = 10,
        DriDtAtu = 11,
        DriVisto = 12
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.DriContatoCRM => DriContatoCRM,
        NomesCamposTabela.DriNome => DriNome,
        NomesCamposTabela.DriDevolvido => DriDevolvido,
        NomesCamposTabela.DriSeraDevolvido => DriSeraDevolvido,
        NomesCamposTabela.DriObservacoes => DriObservacoes,
        NomesCamposTabela.DriBold => DriBold,
        NomesCamposTabela.DriGUID => DriGUID,
        NomesCamposTabela.DriQuemCad => DriQuemCad,
        NomesCamposTabela.DriDtCad => DriDtCad,
        NomesCamposTabela.DriQuemAtu => DriQuemAtu,
        NomesCamposTabela.DriDtAtu => DriDtAtu,
        NomesCamposTabela.DriVisto => DriVisto,
        _ => null
    };
}