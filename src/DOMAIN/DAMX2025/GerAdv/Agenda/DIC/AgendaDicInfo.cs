using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAgendaDicInfo
{
    public const string CampoCodigo = "ageCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "age";
    public const string IDCOB = "ageIDCOB"; // LOCALIZACAO 170523
    public const string ClienteAvisado = "ageClienteAvisado"; // LOCALIZACAO 170523
    public const string RevisarP2 = "ageRevisarP2"; // LOCALIZACAO 170523
    public const string IDNE = "ageIDNE"; // LOCALIZACAO 170523
    public const string Cidade = "ageCidade"; // LOCALIZACAO 170523
    public const string Oculto = "ageOculto"; // LOCALIZACAO 170523
    public const string CartaPrecatoria = "ageCartaPrecatoria"; // LOCALIZACAO 170523
    public const string Revisar = "ageRevisar"; // LOCALIZACAO 170523
    public const string HrFinal = "ageHrFinal"; // LOCALIZACAO 170523
    public const string Advogado = "ageAdvogado"; // LOCALIZACAO 170523
    public const string EventoGerador = "ageEventoGerador"; // LOCALIZACAO 170523
    public const string EventoData = "ageEventoData"; // LOCALIZACAO 170523
    public const string Funcionario = "ageFuncionario"; // LOCALIZACAO 170523
    public const string Data = "ageData"; // LOCALIZACAO 170523
    public const string EventoPrazo = "ageEventoPrazo"; // LOCALIZACAO 170523
    public const string Hora = "ageHora"; // LOCALIZACAO 170523
    public const string Compromisso = "ageCompromisso"; // LOCALIZACAO 170523
    public const string TipoCompromisso = "ageTipoCompromisso"; // LOCALIZACAO 170523
    public const string Cliente = "ageCliente"; // LOCALIZACAO 170523
    public const string Liberado = "ageLiberado"; // LOCALIZACAO 170523
    public const string Importante = "ageImportante"; // LOCALIZACAO 170523
    public const string Concluido = "ageConcluido"; // LOCALIZACAO 170523
    public const string Area = "ageArea"; // LOCALIZACAO 170523
    public const string Justica = "ageJustica"; // LOCALIZACAO 170523
    public const string Processo = "ageProcesso"; // LOCALIZACAO 170523
    public const string IDHistorico = "ageIDHistorico"; // LOCALIZACAO 170523
    public const string IDInsProcesso = "ageIDInsProcesso"; // LOCALIZACAO 170523
    public const string Usuario = "ageUsuario"; // LOCALIZACAO 170523
    public const string Preposto = "agePreposto"; // LOCALIZACAO 170523
    public const string QuemID = "ageQuemID"; // LOCALIZACAO 170523
    public const string QuemCodigo = "ageQuemCodigo"; // LOCALIZACAO 170523
    public const string Status = "ageStatus"; // LOCALIZACAO 170523
    public const string Valor = "ageValor"; // LOCALIZACAO 170523
    public const string Decisao = "ageDecisao"; // LOCALIZACAO 170523
    public const string Sempre = "ageSempre"; // LOCALIZACAO 170523
    public const string PrazoDias = "agePrazoDias"; // LOCALIZACAO 170523
    public const string ProtocoloIntegrado = "ageProtocoloIntegrado"; // LOCALIZACAO 170523
    public const string DataInicioPrazo = "ageDataInicioPrazo"; // LOCALIZACAO 170523
    public const string UsuarioCiente = "ageUsuarioCiente"; // LOCALIZACAO 170523
    public const string GUID = "ageGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "ageQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "ageDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "ageQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "ageDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "ageVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => IDCOB,
        2 => ClienteAvisado,
        3 => RevisarP2,
        4 => IDNE,
        5 => Cidade,
        6 => Oculto,
        7 => CartaPrecatoria,
        8 => Revisar,
        9 => HrFinal,
        10 => Advogado,
        11 => EventoGerador,
        12 => EventoData,
        13 => Funcionario,
        14 => Data,
        15 => EventoPrazo,
        16 => Hora,
        17 => Compromisso,
        18 => TipoCompromisso,
        19 => Cliente,
        20 => Liberado,
        21 => Importante,
        22 => Concluido,
        23 => Area,
        24 => Justica,
        25 => Processo,
        26 => IDHistorico,
        27 => IDInsProcesso,
        28 => Usuario,
        29 => Preposto,
        30 => QuemID,
        31 => QuemCodigo,
        32 => Status,
        33 => Valor,
        34 => Decisao,
        35 => Sempre,
        36 => PrazoDias,
        37 => ProtocoloIntegrado,
        38 => DataInicioPrazo,
        39 => UsuarioCiente,
        40 => GUID,
        41 => QuemCad,
        42 => DtCad,
        43 => QuemAtu,
        44 => DtAtu,
        45 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Agenda";
#region PropriedadesDaTabela
    public static DBInfoSystem AgeIDCOB => new(0, PTabelaNome, CampoCodigo, IDCOB, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeClienteAvisado => new(0, PTabelaNome, CampoCodigo, ClienteAvisado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "age"
    };
    public static DBInfoSystem AgeRevisarP2 => new(0, PTabelaNome, CampoCodigo, RevisarP2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "age"
    };
    public static DBInfoSystem AgeIDNE => new(0, PTabelaNome, CampoCodigo, IDNE, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeOculto => new(0, PTabelaNome, CampoCodigo, Oculto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeCartaPrecatoria => new(0, PTabelaNome, CampoCodigo, CartaPrecatoria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeRevisar => new(0, PTabelaNome, CampoCodigo, Revisar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "age"
    };
    public static DBInfoSystem AgeHrFinal => new(0, PTabelaNome, CampoCodigo, HrFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeAdvogado => new(0, PTabelaNome, CampoCodigo, Advogado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAdvogadosDicInfo.CampoCodigo, DBAdvogadosDicInfo.TabelaNome, new DBAdvogadosODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeEventoGerador => new(0, PTabelaNome, CampoCodigo, EventoGerador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeEventoData => new(0, PTabelaNome, CampoCodigo, EventoData, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeFuncionario => new(0, PTabelaNome, CampoCodigo, Funcionario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncionariosDicInfo.CampoCodigo, DBFuncionariosDicInfo.TabelaNome, new DBFuncionariosODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeEventoPrazo => new(0, PTabelaNome, CampoCodigo, EventoPrazo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeHora => new(0, PTabelaNome, CampoCodigo, Hora, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeCompromisso => new(0, PTabelaNome, CampoCodigo, Compromisso, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeTipoCompromisso => new(0, PTabelaNome, CampoCodigo, TipoCompromisso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoCompromissoDicInfo.CampoCodigo, DBTipoCompromissoDicInfo.TabelaNome, new DBTipoCompromissoODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeLiberado => new(0, PTabelaNome, CampoCodigo, Liberado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "age"
    };
    public static DBInfoSystem AgeImportante => new(0, PTabelaNome, CampoCodigo, Importante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "age"
    };
    public static DBInfoSystem AgeConcluido => new(0, PTabelaNome, CampoCodigo, Concluido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "age"
    };
    public static DBInfoSystem AgeArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeIDHistorico => new(0, PTabelaNome, CampoCodigo, IDHistorico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeIDInsProcesso => new(0, PTabelaNome, CampoCodigo, IDInsProcesso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeUsuario => new(0, PTabelaNome, CampoCodigo, Usuario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgePreposto => new(0, PTabelaNome, CampoCodigo, Preposto, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPrepostosDicInfo.CampoCodigo, DBPrepostosDicInfo.TabelaNome, new DBPrepostosODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeQuemID => new(0, PTabelaNome, CampoCodigo, QuemID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeQuemCodigo => new(0, PTabelaNome, CampoCodigo, QuemCodigo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeStatus => new(0, PTabelaNome, CampoCodigo, Status, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeDecisao => new(0, PTabelaNome, CampoCodigo, Decisao, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeSempre => new(0, PTabelaNome, CampoCodigo, Sempre, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgePrazoDias => new(0, PTabelaNome, CampoCodigo, PrazoDias, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeProtocoloIntegrado => new(0, PTabelaNome, CampoCodigo, ProtocoloIntegrado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeDataInicioPrazo => new(0, PTabelaNome, CampoCodigo, DataInicioPrazo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeUsuarioCiente => new(0, PTabelaNome, CampoCodigo, UsuarioCiente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "age"
    }; // DBI 11 
    public static DBInfoSystem AgeDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "age"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        AgeIDCOB = 1,
        AgeClienteAvisado = 2,
        AgeRevisarP2 = 3,
        AgeIDNE = 4,
        AgeCidade = 5,
        AgeOculto = 6,
        AgeCartaPrecatoria = 7,
        AgeRevisar = 8,
        AgeHrFinal = 9,
        AgeAdvogado = 10,
        AgeEventoGerador = 11,
        AgeEventoData = 12,
        AgeFuncionario = 13,
        AgeData = 14,
        AgeEventoPrazo = 15,
        AgeHora = 16,
        AgeCompromisso = 17,
        AgeTipoCompromisso = 18,
        AgeCliente = 19,
        AgeLiberado = 20,
        AgeImportante = 21,
        AgeConcluido = 22,
        AgeArea = 23,
        AgeJustica = 24,
        AgeProcesso = 25,
        AgeIDHistorico = 26,
        AgeIDInsProcesso = 27,
        AgeUsuario = 28,
        AgePreposto = 29,
        AgeQuemID = 30,
        AgeQuemCodigo = 31,
        AgeStatus = 32,
        AgeValor = 33,
        AgeDecisao = 34,
        AgeSempre = 35,
        AgePrazoDias = 36,
        AgeProtocoloIntegrado = 37,
        AgeDataInicioPrazo = 38,
        AgeUsuarioCiente = 39,
        AgeGUID = 40,
        AgeQuemCad = 41,
        AgeDtCad = 42,
        AgeQuemAtu = 43,
        AgeDtAtu = 44,
        AgeVisto = 45
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AgeIDCOB => AgeIDCOB,
        NomesCamposTabela.AgeClienteAvisado => AgeClienteAvisado,
        NomesCamposTabela.AgeRevisarP2 => AgeRevisarP2,
        NomesCamposTabela.AgeIDNE => AgeIDNE,
        NomesCamposTabela.AgeCidade => AgeCidade,
        NomesCamposTabela.AgeOculto => AgeOculto,
        NomesCamposTabela.AgeCartaPrecatoria => AgeCartaPrecatoria,
        NomesCamposTabela.AgeRevisar => AgeRevisar,
        NomesCamposTabela.AgeHrFinal => AgeHrFinal,
        NomesCamposTabela.AgeAdvogado => AgeAdvogado,
        NomesCamposTabela.AgeEventoGerador => AgeEventoGerador,
        NomesCamposTabela.AgeEventoData => AgeEventoData,
        NomesCamposTabela.AgeFuncionario => AgeFuncionario,
        NomesCamposTabela.AgeData => AgeData,
        NomesCamposTabela.AgeEventoPrazo => AgeEventoPrazo,
        NomesCamposTabela.AgeHora => AgeHora,
        NomesCamposTabela.AgeCompromisso => AgeCompromisso,
        NomesCamposTabela.AgeTipoCompromisso => AgeTipoCompromisso,
        NomesCamposTabela.AgeCliente => AgeCliente,
        NomesCamposTabela.AgeLiberado => AgeLiberado,
        NomesCamposTabela.AgeImportante => AgeImportante,
        NomesCamposTabela.AgeConcluido => AgeConcluido,
        NomesCamposTabela.AgeArea => AgeArea,
        NomesCamposTabela.AgeJustica => AgeJustica,
        NomesCamposTabela.AgeProcesso => AgeProcesso,
        NomesCamposTabela.AgeIDHistorico => AgeIDHistorico,
        NomesCamposTabela.AgeIDInsProcesso => AgeIDInsProcesso,
        NomesCamposTabela.AgeUsuario => AgeUsuario,
        NomesCamposTabela.AgePreposto => AgePreposto,
        NomesCamposTabela.AgeQuemID => AgeQuemID,
        NomesCamposTabela.AgeQuemCodigo => AgeQuemCodigo,
        NomesCamposTabela.AgeStatus => AgeStatus,
        NomesCamposTabela.AgeValor => AgeValor,
        NomesCamposTabela.AgeDecisao => AgeDecisao,
        NomesCamposTabela.AgeSempre => AgeSempre,
        NomesCamposTabela.AgePrazoDias => AgePrazoDias,
        NomesCamposTabela.AgeProtocoloIntegrado => AgeProtocoloIntegrado,
        NomesCamposTabela.AgeDataInicioPrazo => AgeDataInicioPrazo,
        NomesCamposTabela.AgeUsuarioCiente => AgeUsuarioCiente,
        NomesCamposTabela.AgeGUID => AgeGUID,
        NomesCamposTabela.AgeQuemCad => AgeQuemCad,
        NomesCamposTabela.AgeDtCad => AgeDtCad,
        NomesCamposTabela.AgeQuemAtu => AgeQuemAtu,
        NomesCamposTabela.AgeDtAtu => AgeDtAtu,
        NomesCamposTabela.AgeVisto => AgeVisto,
        _ => null
    };
}