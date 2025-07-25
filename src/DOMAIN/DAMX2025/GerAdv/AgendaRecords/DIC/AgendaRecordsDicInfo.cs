using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAgendaRecordsDicInfo
{
    public const string CampoCodigo = "ragCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "rag";
    public const string Agenda = "ragAgenda"; // LOCALIZACAO 170523
    public const string Julgador = "ragJulgador"; // LOCALIZACAO 170523
    public const string ClientesSocios = "ragClientesSocios"; // LOCALIZACAO 170523
    public const string Perito = "ragPerito"; // LOCALIZACAO 170523
    public const string Colaborador = "ragColaborador"; // LOCALIZACAO 170523
    public const string Foro = "ragForo"; // LOCALIZACAO 170523
    public const string Aviso1 = "ragAviso1"; // LOCALIZACAO 170523
    public const string Aviso2 = "ragAviso2"; // LOCALIZACAO 170523
    public const string Aviso3 = "ragAviso3"; // LOCALIZACAO 170523
    public const string CrmAviso1 = "ragCrmAviso1"; // LOCALIZACAO 170523
    public const string CrmAviso2 = "ragCrmAviso2"; // LOCALIZACAO 170523
    public const string CrmAviso3 = "ragCrmAviso3"; // LOCALIZACAO 170523
    public const string DataAviso1 = "ragDataAviso1"; // LOCALIZACAO 170523
    public const string DataAviso2 = "ragDataAviso2"; // LOCALIZACAO 170523
    public const string DataAviso3 = "ragDataAviso3"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Agenda,
        2 => Julgador,
        3 => ClientesSocios,
        4 => Perito,
        5 => Colaborador,
        6 => Foro,
        7 => Aviso1,
        8 => Aviso2,
        9 => Aviso3,
        10 => CrmAviso1,
        11 => CrmAviso2,
        12 => CrmAviso3,
        13 => DataAviso1,
        14 => DataAviso2,
        15 => DataAviso3,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaRecords";
#region PropriedadesDaTabela
    public static DBInfoSystem RagAgenda => new(0, PTabelaNome, CampoCodigo, Agenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAgendaDicInfo.CampoCodigo, DBAgendaDicInfo.TabelaNome, new DBAgendaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "rag"
    }; // DBI 11 
    public static DBInfoSystem RagJulgador => new(0, PTabelaNome, CampoCodigo, Julgador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagClientesSocios => new(0, PTabelaNome, CampoCodigo, ClientesSocios, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesSociosDicInfo.CampoCodigo, DBClientesSociosDicInfo.TabelaNome, new DBClientesSociosODicInfo(), false)
    {
        Prefixo = "rag"
    }; // DBI 11 
    public static DBInfoSystem RagPerito => new(0, PTabelaNome, CampoCodigo, Perito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagColaborador => new(0, PTabelaNome, CampoCodigo, Colaborador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBColaboradoresDicInfo.CampoCodigo, DBColaboradoresDicInfo.TabelaNome, new DBColaboradoresODicInfo(), false)
    {
        Prefixo = "rag"
    }; // DBI 11 
    public static DBInfoSystem RagForo => new(0, PTabelaNome, CampoCodigo, Foro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBForoDicInfo.CampoCodigo, DBForoDicInfo.TabelaNome, new DBForoODicInfo(), false)
    {
        Prefixo = "rag"
    }; // DBI 11 
    public static DBInfoSystem RagAviso1 => new(0, PTabelaNome, CampoCodigo, Aviso1, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagAviso2 => new(0, PTabelaNome, CampoCodigo, Aviso2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagAviso3 => new(0, PTabelaNome, CampoCodigo, Aviso3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagCrmAviso1 => new(0, PTabelaNome, CampoCodigo, CrmAviso1, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagCrmAviso2 => new(0, PTabelaNome, CampoCodigo, CrmAviso2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagCrmAviso3 => new(0, PTabelaNome, CampoCodigo, CrmAviso3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagDataAviso1 => new(0, PTabelaNome, CampoCodigo, DataAviso1, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagDataAviso2 => new(0, PTabelaNome, CampoCodigo, DataAviso2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "rag"
    };
    public static DBInfoSystem RagDataAviso3 => new(0, PTabelaNome, CampoCodigo, DataAviso3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "rag"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        RagAgenda = 1,
        RagJulgador = 2,
        RagClientesSocios = 3,
        RagPerito = 4,
        RagColaborador = 5,
        RagForo = 6,
        RagAviso1 = 7,
        RagAviso2 = 8,
        RagAviso3 = 9,
        RagCrmAviso1 = 10,
        RagCrmAviso2 = 11,
        RagCrmAviso3 = 12,
        RagDataAviso1 = 13,
        RagDataAviso2 = 14,
        RagDataAviso3 = 15
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.RagAgenda => RagAgenda,
        NomesCamposTabela.RagJulgador => RagJulgador,
        NomesCamposTabela.RagClientesSocios => RagClientesSocios,
        NomesCamposTabela.RagPerito => RagPerito,
        NomesCamposTabela.RagColaborador => RagColaborador,
        NomesCamposTabela.RagForo => RagForo,
        NomesCamposTabela.RagAviso1 => RagAviso1,
        NomesCamposTabela.RagAviso2 => RagAviso2,
        NomesCamposTabela.RagAviso3 => RagAviso3,
        NomesCamposTabela.RagCrmAviso1 => RagCrmAviso1,
        NomesCamposTabela.RagCrmAviso2 => RagCrmAviso2,
        NomesCamposTabela.RagCrmAviso3 => RagCrmAviso3,
        NomesCamposTabela.RagDataAviso1 => RagDataAviso1,
        NomesCamposTabela.RagDataAviso2 => RagDataAviso2,
        NomesCamposTabela.RagDataAviso3 => RagDataAviso3,
        _ => null
    };
}