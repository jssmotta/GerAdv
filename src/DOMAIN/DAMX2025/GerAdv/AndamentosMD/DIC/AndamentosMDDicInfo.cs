using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAndamentosMDDicInfo
{
    public const string CampoCodigo = "amdCodigo";
    public const string CampoNome = "amdNome";
    public const string TablePrefix = "amd";
    public const string Nome = "amdNome"; // LOCALIZACAO 170523
    public const string Processo = "amdProcesso"; // LOCALIZACAO 170523
    public const string Andamento = "amdAndamento"; // LOCALIZACAO 170523
    public const string PathFull = "amdPathFull"; // LOCALIZACAO 170523
    public const string UNC = "amdUNC"; // LOCALIZACAO 170523
    public const string GUID = "amdGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "amdQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "amdDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "amdQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "amdDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "amdVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Processo,
        3 => Andamento,
        4 => PathFull,
        5 => UNC,
        6 => GUID,
        7 => QuemCad,
        8 => DtCad,
        9 => QuemAtu,
        10 => DtAtu,
        11 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AndamentosMD";
#region PropriedadesDaTabela
    public static DBInfoSystem AmdNome => new(0, PTabelaNome, CampoCodigo, Nome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "amd"
    };
    public static DBInfoSystem AmdProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "amd"
    }; // DBI 11 
    public static DBInfoSystem AmdAndamento => new(0, PTabelaNome, CampoCodigo, Andamento, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "amd"
    };
    public static DBInfoSystem AmdPathFull => new(0, PTabelaNome, CampoCodigo, PathFull, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "amd"
    };
    public static DBInfoSystem AmdUNC => new(0, PTabelaNome, CampoCodigo, UNC, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "amd"
    };
    public static DBInfoSystem AmdGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "amd"
    };
    public static DBInfoSystem AmdQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "amd"
    }; // DBI 11 
    public static DBInfoSystem AmdDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "amd"
    };
    public static DBInfoSystem AmdQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "amd"
    }; // DBI 11 
    public static DBInfoSystem AmdDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "amd"
    };
    public static DBInfoSystem AmdVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "amd"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        AmdNome = 1,
        AmdProcesso = 2,
        AmdAndamento = 3,
        AmdPathFull = 4,
        AmdUNC = 5,
        AmdGUID = 6,
        AmdQuemCad = 7,
        AmdDtCad = 8,
        AmdQuemAtu = 9,
        AmdDtAtu = 10,
        AmdVisto = 11
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AmdNome => AmdNome,
        NomesCamposTabela.AmdProcesso => AmdProcesso,
        NomesCamposTabela.AmdAndamento => AmdAndamento,
        NomesCamposTabela.AmdPathFull => AmdPathFull,
        NomesCamposTabela.AmdUNC => AmdUNC,
        NomesCamposTabela.AmdGUID => AmdGUID,
        NomesCamposTabela.AmdQuemCad => AmdQuemCad,
        NomesCamposTabela.AmdDtCad => AmdDtCad,
        NomesCamposTabela.AmdQuemAtu => AmdQuemAtu,
        NomesCamposTabela.AmdDtAtu => AmdDtAtu,
        NomesCamposTabela.AmdVisto => AmdVisto,
        _ => null
    };
}