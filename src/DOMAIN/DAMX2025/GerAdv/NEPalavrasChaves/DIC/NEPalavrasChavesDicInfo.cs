using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBNEPalavrasChavesDicInfo
{
    public const string CampoCodigo = "npcCodigo";
    public const string CampoNome = "npcNome";
    public const string TablePrefix = "npc";
    public const string Nome = "npcNome"; // LOCALIZACAO 170523
    public const string Bold = "npcBold"; // LOCALIZACAO 170523
    public const string QuemCad = "npcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "npcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "npcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "npcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "npcVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Bold,
        3 => QuemCad,
        4 => DtCad,
        5 => QuemAtu,
        6 => DtAtu,
        7 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "NEPalavrasChaves";
#region PropriedadesDaTabela
    public static DBInfoSystem NpcNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "npc"
    };
    public static DBInfoSystem NpcBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "npc"
    };
    public static DBInfoSystem NpcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "npc"
    }; // DBI 11 
    public static DBInfoSystem NpcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "npc"
    };
    public static DBInfoSystem NpcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "npc"
    }; // DBI 11 
    public static DBInfoSystem NpcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "npc"
    };
    public static DBInfoSystem NpcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "npc"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        NpcNome = 1,
        NpcBold = 2,
        NpcQuemCad = 3,
        NpcDtCad = 4,
        NpcQuemAtu = 5,
        NpcDtAtu = 6,
        NpcVisto = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.NpcNome => NpcNome,
        NomesCamposTabela.NpcBold => NpcBold,
        NomesCamposTabela.NpcQuemCad => NpcQuemCad,
        NomesCamposTabela.NpcDtCad => NpcDtCad,
        NomesCamposTabela.NpcQuemAtu => NpcQuemAtu,
        NomesCamposTabela.NpcDtAtu => NpcDtAtu,
        NomesCamposTabela.NpcVisto => NpcVisto,
        _ => null
    };
}