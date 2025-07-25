using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAgendaStatusDicInfo
{
    public const string CampoCodigo = "astCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ast";
    public const string Agenda = "astAgenda"; // LOCALIZACAO 170523
    public const string Completed = "astCompleted"; // LOCALIZACAO 170523
    public const string QuemCad = "astQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "astDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "astQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "astDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "astVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Agenda,
        2 => Completed,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaStatus";
#region PropriedadesDaTabela
    public static DBInfoSystem AstAgenda => new(0, PTabelaNome, CampoCodigo, Agenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAgendaDicInfo.CampoCodigo, DBAgendaDicInfo.TabelaNome, new DBAgendaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "ast"
    }; // DBI 11 
    public static DBInfoSystem AstCompleted => new(0, PTabelaNome, CampoCodigo, Completed, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        IsRequired = true,
        Prefixo = "ast"
    };
    public static DBInfoSystem AstQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "ast"
    }; // DBI 11 
    public static DBInfoSystem AstDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "ast"
    };
    public static DBInfoSystem AstQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ast"
    }; // DBI 11 
    public static DBInfoSystem AstDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ast"
    };
    public static DBInfoSystem AstVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ast"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        AstAgenda = 1,
        AstCompleted = 2,
        AstQuemCad = 3,
        AstDtCad = 4,
        AstQuemAtu = 5,
        AstDtAtu = 6,
        AstVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AstAgenda => AstAgenda,
        NomesCamposTabela.AstCompleted => AstCompleted,
        NomesCamposTabela.AstQuemCad => AstQuemCad,
        NomesCamposTabela.AstDtCad => AstDtCad,
        NomesCamposTabela.AstQuemAtu => AstQuemAtu,
        NomesCamposTabela.AstDtAtu => AstDtAtu,
        NomesCamposTabela.AstVisto => AstVisto,
        _ => null
    };
}