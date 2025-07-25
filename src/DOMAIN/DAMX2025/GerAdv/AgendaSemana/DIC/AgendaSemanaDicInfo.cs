using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAgendaSemanaDicInfo
{
    public const string CampoCodigo = "xxxCodigo";
    public const string CampoNome = "xxxParaNome";
    public const string TablePrefix = "xxx";
    public const string ParaNome = "xxxParaNome"; // LOCALIZACAO 170523
    public const string Data = "xxxData"; // LOCALIZACAO 170523
    public const string Funcionario = "xxxFuncionario"; // LOCALIZACAO 170523
    public const string Advogado = "xxxAdvogado"; // LOCALIZACAO 170523
    public const string Hora = "xxxHora"; // LOCALIZACAO 170523
    public const string TipoCompromisso = "xxxTipoCompromisso"; // LOCALIZACAO 170523
    public const string Compromisso = "xxxCompromisso"; // LOCALIZACAO 170523
    public const string Concluido = "xxxConcluido"; // LOCALIZACAO 170523
    public const string Liberado = "xxxLiberado"; // LOCALIZACAO 170523
    public const string Importante = "xxxImportante"; // LOCALIZACAO 170523
    public const string HoraFinal = "xxxHoraFinal"; // LOCALIZACAO 170523
    public const string Nome = "xxxNome"; // LOCALIZACAO 170523
    public const string Cliente = "xxxCliente"; // LOCALIZACAO 170523
    public const string NomeCliente = "xxxNomeCliente"; // LOCALIZACAO 170523
    public const string Tipo = "xxxTipo"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => ParaNome,
        2 => Data,
        3 => Funcionario,
        4 => Advogado,
        5 => Hora,
        6 => TipoCompromisso,
        7 => Compromisso,
        8 => Concluido,
        9 => Liberado,
        10 => Importante,
        11 => HoraFinal,
        12 => Nome,
        13 => Cliente,
        14 => NomeCliente,
        15 => Tipo,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaSemana";
#region PropriedadesDaTabela
    public static DBInfoSystem XxxParaNome => new(0, PTabelaNome, CampoCodigo, ParaNome, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxFuncionario => new(0, PTabelaNome, CampoCodigo, Funcionario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncionariosDicInfo.CampoCodigo, DBFuncionariosDicInfo.TabelaNome, new DBFuncionariosODicInfo(), false)
    {
        Prefixo = "xxx"
    }; // DBI 11 
    public static DBInfoSystem XxxAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false)
    {
        Prefixo = "xxx"
    }; // DBI 11 
    public static DBInfoSystem XxxHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxTipoCompromisso => new(0, PTabelaNome, CampoCodigo, TipoCompromisso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoCompromissoDicInfo.CampoCodigo, DBTipoCompromissoDicInfo.TabelaNome, new DBTipoCompromissoODicInfo(), false)
    {
        Prefixo = "xxx"
    }; // DBI 11 
    public static DBInfoSystem XxxCompromisso => new(0, PTabelaNome, CampoCodigo, Compromisso, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxConcluido => new(0, PTabelaNome, CampoCodigo, Concluido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxLiberado => new(0, PTabelaNome, CampoCodigo, Liberado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxImportante => new(0, PTabelaNome, CampoCodigo, Importante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxHoraFinal => new(0, PTabelaNome, CampoCodigo, HoraFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "xxx"
    }; // DBI 11 
    public static DBInfoSystem XxxNomeCliente => new(0, PTabelaNome, CampoCodigo, NomeCliente, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "xxx"
    };
    public static DBInfoSystem XxxTipo => new(0, PTabelaNome, CampoCodigo, Tipo, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "xxx"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        XxxParaNome = 1,
        XxxData = 2,
        XxxFuncionario = 3,
        XxxAdvogado = 4,
        XxxHora = 5,
        XxxTipoCompromisso = 6,
        XxxCompromisso = 7,
        XxxConcluido = 8,
        XxxLiberado = 9,
        XxxImportante = 10,
        XxxHoraFinal = 11,
        XxxNome = 12,
        XxxCliente = 13,
        XxxNomeCliente = 14,
        XxxTipo = 15
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.XxxParaNome => XxxParaNome,
        NomesCamposTabela.XxxData => XxxData,
        NomesCamposTabela.XxxFuncionario => XxxFuncionario,
        NomesCamposTabela.XxxAdvogado => XxxAdvogado,
        NomesCamposTabela.XxxHora => XxxHora,
        NomesCamposTabela.XxxTipoCompromisso => XxxTipoCompromisso,
        NomesCamposTabela.XxxCompromisso => XxxCompromisso,
        NomesCamposTabela.XxxConcluido => XxxConcluido,
        NomesCamposTabela.XxxLiberado => XxxLiberado,
        NomesCamposTabela.XxxImportante => XxxImportante,
        NomesCamposTabela.XxxHoraFinal => XxxHoraFinal,
        NomesCamposTabela.XxxNome => XxxNome,
        NomesCamposTabela.XxxCliente => XxxCliente,
        NomesCamposTabela.XxxNomeCliente => XxxNomeCliente,
        NomesCamposTabela.XxxTipo => XxxTipo,
        _ => null
    };
}