using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAlarmSMSDicInfo
{
    public const string CampoCodigo = "alrCodigo";
    public const string CampoNome = "alrDescricao";
    public const string TablePrefix = "alr";
    public const string Descricao = "alrDescricao"; // LOCALIZACAO 170523
    public const string Hora = "alrHora"; // LOCALIZACAO 170523
    public const string Minuto = "alrMinuto"; // LOCALIZACAO 170523
    public const string D1 = "alrD1"; // LOCALIZACAO 170523
    public const string D2 = "alrD2"; // LOCALIZACAO 170523
    public const string D3 = "alrD3"; // LOCALIZACAO 170523
    public const string D4 = "alrD4"; // LOCALIZACAO 170523
    public const string D5 = "alrD5"; // LOCALIZACAO 170523
    public const string D6 = "alrD6"; // LOCALIZACAO 170523
    public const string D7 = "alrD7"; // LOCALIZACAO 170523
    public const string EMail = "alrEMail"; // LOCALIZACAO 170523
    public const string Desativar = "alrDesativar"; // LOCALIZACAO 170523
    public const string Today = "alrToday"; // LOCALIZACAO 170523
    public const string ExcetoDiasFelizes = "alrExcetoDiasFelizes"; // LOCALIZACAO 170523
    public const string Desktop = "alrDesktop"; // LOCALIZACAO 170523
    public const string AlertarDataHora = "alrAlertarDataHora"; // LOCALIZACAO 170523
    public const string Operador = "alrOperador"; // LOCALIZACAO 170523
    public const string GuidExo = "alrGuidExo"; // LOCALIZACAO 170523
    public const string Agenda = "alrAgenda"; // LOCALIZACAO 170523
    public const string Recado = "alrRecado"; // LOCALIZACAO 170523
    public const string Emocao = "alrEmocao"; // LOCALIZACAO 170523
    public const string GUID = "alrGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "alrQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "alrDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "alrQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "alrDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "alrVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Descricao,
        2 => Hora,
        3 => Minuto,
        4 => D1,
        5 => D2,
        6 => D3,
        7 => D4,
        8 => D5,
        9 => D6,
        10 => D7,
        11 => EMail,
        12 => Desativar,
        13 => Today,
        14 => ExcetoDiasFelizes,
        15 => Desktop,
        16 => AlertarDataHora,
        17 => Operador,
        18 => GuidExo,
        19 => Agenda,
        20 => Recado,
        21 => Emocao,
        22 => GUID,
        23 => QuemCad,
        24 => DtCad,
        25 => QuemAtu,
        26 => DtAtu,
        27 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AlarmSMS";
#region PropriedadesDaTabela
    public static DBInfoSystem AlrDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrMinuto => new(0, PTabelaNome, CampoCodigo, Minuto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrD1 => new(0, PTabelaNome, CampoCodigo, D1, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrD2 => new(0, PTabelaNome, CampoCodigo, D2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrD3 => new(0, PTabelaNome, CampoCodigo, D3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrD4 => new(0, PTabelaNome, CampoCodigo, D4, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrD5 => new(0, PTabelaNome, CampoCodigo, D5, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrD6 => new(0, PTabelaNome, CampoCodigo, D6, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrD7 => new(0, PTabelaNome, CampoCodigo, D7, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrEMail => new(0, PTabelaNome, CampoCodigo, EMail, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrDesativar => new(0, PTabelaNome, CampoCodigo, Desativar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrToday => new(0, PTabelaNome, CampoCodigo, Today, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrExcetoDiasFelizes => new(0, PTabelaNome, CampoCodigo, ExcetoDiasFelizes, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrDesktop => new(0, PTabelaNome, CampoCodigo, Desktop, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrAlertarDataHora => new(0, PTabelaNome, CampoCodigo, AlertarDataHora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "alr"
    }; // DBI 11 
    public static DBInfoSystem AlrGuidExo => new(0, PTabelaNome, CampoCodigo, GuidExo, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrAgenda => new(0, PTabelaNome, CampoCodigo, Agenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAgendaDicInfo.CampoCodigo, DBAgendaDicInfo.TabelaNome, new DBAgendaODicInfo(), false)
    {
        Prefixo = "alr"
    }; // DBI 11 
    public static DBInfoSystem AlrRecado => new(0, PTabelaNome, CampoCodigo, Recado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBRecadosDicInfo.CampoCodigo, DBRecadosDicInfo.TabelaNome, new DBRecadosODicInfo(), false)
    {
        Prefixo = "alr"
    }; // DBI 11 
    public static DBInfoSystem AlrEmocao => new(0, PTabelaNome, CampoCodigo, Emocao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "alr"
    }; // DBI 11 
    public static DBInfoSystem AlrDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "alr"
    }; // DBI 11 
    public static DBInfoSystem AlrDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "alr"
    };
    public static DBInfoSystem AlrVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        Prefixo = "alr"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        AlrDescricao = 1,
        AlrHora = 2,
        AlrMinuto = 3,
        AlrD1 = 4,
        AlrD2 = 5,
        AlrD3 = 6,
        AlrD4 = 7,
        AlrD5 = 8,
        AlrD6 = 9,
        AlrD7 = 10,
        AlrEMail = 11,
        AlrDesativar = 12,
        AlrToday = 13,
        AlrExcetoDiasFelizes = 14,
        AlrDesktop = 15,
        AlrAlertarDataHora = 16,
        AlrOperador = 17,
        AlrGuidExo = 18,
        AlrAgenda = 19,
        AlrRecado = 20,
        AlrEmocao = 21,
        AlrGUID = 22,
        AlrQuemCad = 23,
        AlrDtCad = 24,
        AlrQuemAtu = 25,
        AlrDtAtu = 26,
        AlrVisto = 27
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AlrDescricao => AlrDescricao,
        NomesCamposTabela.AlrHora => AlrHora,
        NomesCamposTabela.AlrMinuto => AlrMinuto,
        NomesCamposTabela.AlrD1 => AlrD1,
        NomesCamposTabela.AlrD2 => AlrD2,
        NomesCamposTabela.AlrD3 => AlrD3,
        NomesCamposTabela.AlrD4 => AlrD4,
        NomesCamposTabela.AlrD5 => AlrD5,
        NomesCamposTabela.AlrD6 => AlrD6,
        NomesCamposTabela.AlrD7 => AlrD7,
        NomesCamposTabela.AlrEMail => AlrEMail,
        NomesCamposTabela.AlrDesativar => AlrDesativar,
        NomesCamposTabela.AlrToday => AlrToday,
        NomesCamposTabela.AlrExcetoDiasFelizes => AlrExcetoDiasFelizes,
        NomesCamposTabela.AlrDesktop => AlrDesktop,
        NomesCamposTabela.AlrAlertarDataHora => AlrAlertarDataHora,
        NomesCamposTabela.AlrOperador => AlrOperador,
        NomesCamposTabela.AlrGuidExo => AlrGuidExo,
        NomesCamposTabela.AlrAgenda => AlrAgenda,
        NomesCamposTabela.AlrRecado => AlrRecado,
        NomesCamposTabela.AlrEmocao => AlrEmocao,
        NomesCamposTabela.AlrGUID => AlrGUID,
        NomesCamposTabela.AlrQuemCad => AlrQuemCad,
        NomesCamposTabela.AlrDtCad => AlrDtCad,
        NomesCamposTabela.AlrQuemAtu => AlrQuemAtu,
        NomesCamposTabela.AlrDtAtu => AlrDtAtu,
        NomesCamposTabela.AlrVisto => AlrVisto,
        _ => null
    };
}