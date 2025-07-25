using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBParteClienteOutrasDicInfo
{
    public const string CampoCodigo = "pcoCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "pco";
    public const string Cliente = "pcoCliente"; // LOCALIZACAO 170523
    public const string Processo = "pcoProcesso"; // LOCALIZACAO 170523
    public const string PrimeiraReclamada = "pcoPrimeiraReclamada"; // LOCALIZACAO 170523
    public const string QuemCad = "pcoQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "pcoDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "pcoQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "pcoDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "pcoVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cliente,
        2 => Processo,
        3 => PrimeiraReclamada,
        4 => QuemCad,
        5 => DtCad,
        6 => QuemAtu,
        7 => DtAtu,
        8 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ParteClienteOutras";
#region PropriedadesDaTabela
    public static DBInfoSystem PcoCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOutrasPartesClienteDicInfo.CampoCodigo, DBOutrasPartesClienteDicInfo.TabelaNome, new DBOutrasPartesClienteODicInfo(), false)
    {
        Prefixo = "pco"
    }; // DBI 11 
    public static DBInfoSystem PcoProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "pco"
    }; // DBI 11 
    public static DBInfoSystem PcoPrimeiraReclamada => new(0, PTabelaNome, CampoCodigo, PrimeiraReclamada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "pco"
    };
    public static DBInfoSystem PcoQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pco"
    }; // DBI 11 
    public static DBInfoSystem PcoDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "pco"
    };
    public static DBInfoSystem PcoQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "pco"
    }; // DBI 11 
    public static DBInfoSystem PcoDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "pco"
    };
    public static DBInfoSystem PcoVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "pco"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PcoCliente = 1,
        PcoProcesso = 2,
        PcoPrimeiraReclamada = 3,
        PcoQuemCad = 4,
        PcoDtCad = 5,
        PcoQuemAtu = 6,
        PcoDtAtu = 7,
        PcoVisto = 8
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PcoCliente => PcoCliente,
        NomesCamposTabela.PcoProcesso => PcoProcesso,
        NomesCamposTabela.PcoPrimeiraReclamada => PcoPrimeiraReclamada,
        NomesCamposTabela.PcoQuemCad => PcoQuemCad,
        NomesCamposTabela.PcoDtCad => PcoDtCad,
        NomesCamposTabela.PcoQuemAtu => PcoQuemAtu,
        NomesCamposTabela.PcoDtAtu => PcoDtAtu,
        NomesCamposTabela.PcoVisto => PcoVisto,
        _ => null
    };
}