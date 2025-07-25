using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBLivroCaixaDicInfo
{
    public const string CampoCodigo = "livCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "liv";
    public const string IDDes = "livIDDes"; // LOCALIZACAO 170523
    public const string Pessoal = "livPessoal"; // LOCALIZACAO 170523
    public const string Ajuste = "livAjuste"; // LOCALIZACAO 170523
    public const string IDHon = "livIDHon"; // LOCALIZACAO 170523
    public const string IDHonParc = "livIDHonParc"; // LOCALIZACAO 170523
    public const string IDHonSuc = "livIDHonSuc"; // LOCALIZACAO 170523
    public const string Data = "livData"; // LOCALIZACAO 170523
    public const string Processo = "livProcesso"; // LOCALIZACAO 170523
    public const string Valor = "livValor"; // LOCALIZACAO 170523
    public const string Tipo = "livTipo"; // LOCALIZACAO 170523
    public const string Historico = "livHistorico"; // LOCALIZACAO 170523
    public const string Previsto = "livPrevisto"; // LOCALIZACAO 170523
    public const string Grupo = "livGrupo"; // LOCALIZACAO 170523
    public const string QuemCad = "livQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "livDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "livQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "livDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "livVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => IDDes,
        2 => Pessoal,
        3 => Ajuste,
        4 => IDHon,
        5 => IDHonParc,
        6 => IDHonSuc,
        7 => Data,
        8 => Processo,
        9 => Valor,
        10 => Tipo,
        11 => Historico,
        12 => Previsto,
        13 => Grupo,
        14 => QuemCad,
        15 => DtCad,
        16 => QuemAtu,
        17 => DtAtu,
        18 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "LivroCaixa";
#region PropriedadesDaTabela
    public static DBInfoSystem LivIDDes => new(0, PTabelaNome, CampoCodigo, IDDes, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivPessoal => new(0, PTabelaNome, CampoCodigo, Pessoal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivAjuste => new(0, PTabelaNome, CampoCodigo, Ajuste, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "liv"
    };
    public static DBInfoSystem LivIDHon => new(0, PTabelaNome, CampoCodigo, IDHon, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivIDHonParc => new(0, PTabelaNome, CampoCodigo, IDHonParc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivIDHonSuc => new(0, PTabelaNome, CampoCodigo, IDHonSuc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "liv"
    };
    public static DBInfoSystem LivData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "liv"
    }; // DBI 11 
    public static DBInfoSystem LivValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa)
    {
        IsRequired = true,
        Prefixo = "liv"
    };
    public static DBInfoSystem LivHistorico => new(0, PTabelaNome, CampoCodigo, Historico, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivPrevisto => new(0, PTabelaNome, CampoCodigo, Previsto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "liv"
    };
    public static DBInfoSystem LivGrupo => new(0, PTabelaNome, CampoCodigo, Grupo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "liv"
    }; // DBI 11 
    public static DBInfoSystem LivDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "liv"
    }; // DBI 11 
    public static DBInfoSystem LivDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "liv"
    };
    public static DBInfoSystem LivVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "liv"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        LivIDDes = 1,
        LivPessoal = 2,
        LivAjuste = 3,
        LivIDHon = 4,
        LivIDHonParc = 5,
        LivIDHonSuc = 6,
        LivData = 7,
        LivProcesso = 8,
        LivValor = 9,
        LivTipo = 10,
        LivHistorico = 11,
        LivPrevisto = 12,
        LivGrupo = 13,
        LivQuemCad = 14,
        LivDtCad = 15,
        LivQuemAtu = 16,
        LivDtAtu = 17,
        LivVisto = 18
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.LivIDDes => LivIDDes,
        NomesCamposTabela.LivPessoal => LivPessoal,
        NomesCamposTabela.LivAjuste => LivAjuste,
        NomesCamposTabela.LivIDHon => LivIDHon,
        NomesCamposTabela.LivIDHonParc => LivIDHonParc,
        NomesCamposTabela.LivIDHonSuc => LivIDHonSuc,
        NomesCamposTabela.LivData => LivData,
        NomesCamposTabela.LivProcesso => LivProcesso,
        NomesCamposTabela.LivValor => LivValor,
        NomesCamposTabela.LivTipo => LivTipo,
        NomesCamposTabela.LivHistorico => LivHistorico,
        NomesCamposTabela.LivPrevisto => LivPrevisto,
        NomesCamposTabela.LivGrupo => LivGrupo,
        NomesCamposTabela.LivQuemCad => LivQuemCad,
        NomesCamposTabela.LivDtCad => LivDtCad,
        NomesCamposTabela.LivQuemAtu => LivQuemAtu,
        NomesCamposTabela.LivDtAtu => LivDtAtu,
        NomesCamposTabela.LivVisto => LivVisto,
        _ => null
    };
}