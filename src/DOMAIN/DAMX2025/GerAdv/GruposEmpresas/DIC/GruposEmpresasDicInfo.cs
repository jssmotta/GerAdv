using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBGruposEmpresasDicInfo
{
    public const string CampoCodigo = "grpCodigo";
    public const string CampoNome = "grpDescricao";
    public const string TablePrefix = "grp";
    public const string EMail = "grpEMail"; // LOCALIZACAO 170523
    public const string Inativo = "grpInativo"; // LOCALIZACAO 170523
    public const string Oponente = "grpOponente"; // LOCALIZACAO 170523
    public const string Descricao = "grpDescricao"; // LOCALIZACAO 170523
    public const string Observacoes = "grpObservacoes"; // LOCALIZACAO 170523
    public const string Cliente = "grpCliente"; // LOCALIZACAO 170523
    public const string Icone = "grpIcone"; // LOCALIZACAO 170523
    public const string DespesaUnificada = "grpDespesaUnificada"; // LOCALIZACAO 170523
    public const string GUID = "grpGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "grpQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "grpDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "grpQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "grpDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "grpVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => EMail,
        2 => Inativo,
        3 => Oponente,
        4 => Descricao,
        5 => Observacoes,
        6 => Cliente,
        7 => Icone,
        8 => DespesaUnificada,
        9 => GUID,
        10 => QuemCad,
        11 => DtCad,
        12 => QuemAtu,
        13 => DtAtu,
        14 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "GruposEmpresas";
#region PropriedadesDaTabela
    public static DBInfoSystem GrpEMail => new(0, PTabelaNome, CampoCodigo, EMail, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "grp"
    };
    public static DBInfoSystem GrpInativo => new(0, PTabelaNome, CampoCodigo, Inativo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "grp"
    };
    public static DBInfoSystem GrpOponente => new(0, PTabelaNome, CampoCodigo, Oponente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOponentesDicInfo.CampoCodigo, DBOponentesDicInfo.TabelaNome, new DBOponentesODicInfo(), false)
    {
        Prefixo = "grp"
    }; // DBI 11 
    public static DBInfoSystem GrpDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "grp"
    };
    public static DBInfoSystem GrpObservacoes => new(0, PTabelaNome, CampoCodigo, Observacoes, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "grp"
    };
    public static DBInfoSystem GrpCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "grp"
    }; // DBI 11 
    public static DBInfoSystem GrpIcone => new(0, PTabelaNome, CampoCodigo, Icone, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "grp"
    };
    public static DBInfoSystem GrpDespesaUnificada => new(0, PTabelaNome, CampoCodigo, DespesaUnificada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "grp"
    };
    public static DBInfoSystem GrpGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "grp"
    };
    public static DBInfoSystem GrpQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "grp"
    }; // DBI 11 
    public static DBInfoSystem GrpDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "grp"
    };
    public static DBInfoSystem GrpQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "grp"
    }; // DBI 11 
    public static DBInfoSystem GrpDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "grp"
    };
    public static DBInfoSystem GrpVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "grp"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        GrpEMail = 1,
        GrpInativo = 2,
        GrpOponente = 3,
        GrpDescricao = 4,
        GrpObservacoes = 5,
        GrpCliente = 6,
        GrpIcone = 7,
        GrpDespesaUnificada = 8,
        GrpGUID = 9,
        GrpQuemCad = 10,
        GrpDtCad = 11,
        GrpQuemAtu = 12,
        GrpDtAtu = 13,
        GrpVisto = 14
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.GrpEMail => GrpEMail,
        NomesCamposTabela.GrpInativo => GrpInativo,
        NomesCamposTabela.GrpOponente => GrpOponente,
        NomesCamposTabela.GrpDescricao => GrpDescricao,
        NomesCamposTabela.GrpObservacoes => GrpObservacoes,
        NomesCamposTabela.GrpCliente => GrpCliente,
        NomesCamposTabela.GrpIcone => GrpIcone,
        NomesCamposTabela.GrpDespesaUnificada => GrpDespesaUnificada,
        NomesCamposTabela.GrpGUID => GrpGUID,
        NomesCamposTabela.GrpQuemCad => GrpQuemCad,
        NomesCamposTabela.GrpDtCad => GrpDtCad,
        NomesCamposTabela.GrpQuemAtu => GrpQuemAtu,
        NomesCamposTabela.GrpDtAtu => GrpDtAtu,
        NomesCamposTabela.GrpVisto => GrpVisto,
        _ => null
    };
}