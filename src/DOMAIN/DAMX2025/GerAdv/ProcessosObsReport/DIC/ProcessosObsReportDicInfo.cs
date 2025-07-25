using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProcessosObsReportDicInfo
{
    public const string CampoCodigo = "prrCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "prr";
    public const string Data = "prrData"; // LOCALIZACAO 170523
    public const string Processo = "prrProcesso"; // LOCALIZACAO 170523
    public const string Observacao = "prrObservacao"; // LOCALIZACAO 170523
    public const string Historico = "prrHistorico"; // LOCALIZACAO 170523
    public const string QuemCad = "prrQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "prrDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "prrQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "prrDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "prrVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Data,
        2 => Processo,
        3 => Observacao,
        4 => Historico,
        5 => QuemCad,
        6 => DtCad,
        7 => QuemAtu,
        8 => DtAtu,
        9 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProcessosObsReport";
#region PropriedadesDaTabela
    public static DBInfoSystem PrrData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        IsRequired = true,
        Prefixo = "prr"
    };
    public static DBInfoSystem PrrProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "prr"
    }; // DBI 11 
    public static DBInfoSystem PrrObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "prr"
    };
    public static DBInfoSystem PrrHistorico => new(0, PTabelaNome, CampoCodigo, Historico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBHistoricoDicInfo.CampoCodigo, DBHistoricoDicInfo.TabelaNome, new DBHistoricoODicInfo(), false)
    {
        Prefixo = "prr"
    }; // DBI 11 
    public static DBInfoSystem PrrQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "prr"
    }; // DBI 11 
    public static DBInfoSystem PrrDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "prr"
    };
    public static DBInfoSystem PrrQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "prr"
    }; // DBI 11 
    public static DBInfoSystem PrrDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "prr"
    };
    public static DBInfoSystem PrrVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "prr"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PrrData = 1,
        PrrProcesso = 2,
        PrrObservacao = 3,
        PrrHistorico = 4,
        PrrQuemCad = 5,
        PrrDtCad = 6,
        PrrQuemAtu = 7,
        PrrDtAtu = 8,
        PrrVisto = 9
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PrrData => PrrData,
        NomesCamposTabela.PrrProcesso => PrrProcesso,
        NomesCamposTabela.PrrObservacao => PrrObservacao,
        NomesCamposTabela.PrrHistorico => PrrHistorico,
        NomesCamposTabela.PrrQuemCad => PrrQuemCad,
        NomesCamposTabela.PrrDtCad => PrrDtCad,
        NomesCamposTabela.PrrQuemAtu => PrrQuemAtu,
        NomesCamposTabela.PrrDtAtu => PrrDtAtu,
        NomesCamposTabela.PrrVisto => PrrVisto,
        _ => null
    };
}