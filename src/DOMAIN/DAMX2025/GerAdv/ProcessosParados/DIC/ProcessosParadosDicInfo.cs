using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProcessosParadosDicInfo
{
    public const string CampoCodigo = "pprCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "ppr";
    public const string Processo = "pprProcesso"; // LOCALIZACAO 170523
    public const string Semana = "pprSemana"; // LOCALIZACAO 170523
    public const string Ano = "pprAno"; // LOCALIZACAO 170523
    public const string DataHora = "pprDataHora"; // LOCALIZACAO 170523
    public const string Operador = "pprOperador"; // LOCALIZACAO 170523
    public const string DataHistorico = "pprDataHistorico"; // LOCALIZACAO 170523
    public const string DataNENotas = "pprDataNENotas"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Semana,
        3 => Ano,
        4 => DataHora,
        5 => Operador,
        6 => DataHistorico,
        7 => DataNENotas,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProcessosParados";
#region PropriedadesDaTabela
    public static DBInfoSystem PprProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "ppr"
    }; // DBI 11 
    public static DBInfoSystem PprSemana => new(0, PTabelaNome, CampoCodigo, Semana, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        IsRequired = true,
        Prefixo = "ppr"
    };
    public static DBInfoSystem PprAno => new(0, PTabelaNome, CampoCodigo, Ano, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        IsRequired = true,
        Prefixo = "ppr"
    };
    public static DBInfoSystem PprDataHora => new(0, PTabelaNome, CampoCodigo, DataHora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ppr"
    };
    public static DBInfoSystem PprOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ppr"
    }; // DBI 11 
    public static DBInfoSystem PprDataHistorico => new(0, PTabelaNome, CampoCodigo, DataHistorico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ppr"
    };
    public static DBInfoSystem PprDataNENotas => new(0, PTabelaNome, CampoCodigo, DataNENotas, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "ppr"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        PprProcesso = 1,
        PprSemana = 2,
        PprAno = 3,
        PprDataHora = 4,
        PprOperador = 5,
        PprDataHistorico = 6,
        PprDataNENotas = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PprProcesso => PprProcesso,
        NomesCamposTabela.PprSemana => PprSemana,
        NomesCamposTabela.PprAno => PprAno,
        NomesCamposTabela.PprDataHora => PprDataHora,
        NomesCamposTabela.PprOperador => PprOperador,
        NomesCamposTabela.PprDataHistorico => PprDataHistorico,
        NomesCamposTabela.PprDataNENotas => PprDataNENotas,
        _ => null
    };
}