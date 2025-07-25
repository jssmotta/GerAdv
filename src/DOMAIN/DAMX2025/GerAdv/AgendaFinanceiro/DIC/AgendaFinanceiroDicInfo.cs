using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBAgendaFinanceiroDicInfo
{
    public const string CampoCodigo = "ageCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "age";
    public const string IDCOB = "ageIDCOB"; // LOCALIZACAO 170523
    public const string IDNE = "ageIDNE"; // LOCALIZACAO 170523
    public const string PrazoProvisionado = "agePrazoProvisionado"; // LOCALIZACAO 170523
    public const string Cidade = "ageCidade"; // LOCALIZACAO 170523
    public const string Oculto = "ageOculto"; // LOCALIZACAO 170523
    public const string CartaPrecatoria = "ageCartaPrecatoria"; // LOCALIZACAO 170523
    public const string RepetirDias = "ageRepetirDias"; // LOCALIZACAO 170523
    public const string HrFinal = "ageHrFinal"; // LOCALIZACAO 170523
    public const string Repetir = "ageRepetir"; // LOCALIZACAO 170523
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
    public const string DDias = "ageDDias"; // LOCALIZACAO 170523
    public const string Dias = "ageDias"; // LOCALIZACAO 170523
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
    public const string CompromissoHTML = "ageCompromissoHTML"; // LOCALIZACAO 170523
    public const string Decisao = "ageDecisao"; // LOCALIZACAO 170523
    public const string Revisar = "ageRevisar"; // LOCALIZACAO 170523
    public const string RevisarP2 = "ageRevisarP2"; // LOCALIZACAO 170523
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
        2 => IDNE,
        3 => PrazoProvisionado,
        4 => Cidade,
        5 => Oculto,
        6 => CartaPrecatoria,
        7 => RepetirDias,
        8 => HrFinal,
        9 => Repetir,
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
        20 => DDias,
        21 => Dias,
        22 => Liberado,
        23 => Importante,
        24 => Concluido,
        25 => Area,
        26 => Justica,
        27 => Processo,
        28 => IDHistorico,
        29 => IDInsProcesso,
        30 => Usuario,
        31 => Preposto,
        32 => QuemID,
        33 => QuemCodigo,
        34 => Status,
        35 => Valor,
        36 => CompromissoHTML,
        37 => Decisao,
        38 => Revisar,
        39 => RevisarP2,
        40 => Sempre,
        41 => PrazoDias,
        42 => ProtocoloIntegrado,
        43 => DataInicioPrazo,
        44 => UsuarioCiente,
        45 => GUID,
        46 => QuemCad,
        47 => DtCad,
        48 => QuemAtu,
        49 => DtAtu,
        50 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaFinanceiro";
#region PropriedadesDaTabela
    public static DBInfoSystem AgeIDCOB => new(0, PTabelaNome, CampoCodigo, IDCOB, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeIDNE => new(0, PTabelaNome, CampoCodigo, IDNE, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgePrazoProvisionado => new(0, PTabelaNome, CampoCodigo, PrazoProvisionado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
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
    public static DBInfoSystem AgeRepetirDias => new(0, PTabelaNome, CampoCodigo, RepetirDias, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeHrFinal => new(0, PTabelaNome, CampoCodigo, HrFinal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeRepetir => new(0, PTabelaNome, CampoCodigo, Repetir, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
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
    public static DBInfoSystem AgeDDias => new(0, PTabelaNome, CampoCodigo, DDias, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeDias => new(0, PTabelaNome, CampoCodigo, Dias, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "age"
    };
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
    public static DBInfoSystem AgeCompromissoHTML => new(0, PTabelaNome, CampoCodigo, CompromissoHTML, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeDecisao => new(0, PTabelaNome, CampoCodigo, Decisao, 2048, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeRevisar => new(0, PTabelaNome, CampoCodigo, Revisar, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "age"
    };
    public static DBInfoSystem AgeRevisarP2 => new(0, PTabelaNome, CampoCodigo, RevisarP2, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
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
        AgeIDNE = 2,
        AgePrazoProvisionado = 3,
        AgeCidade = 4,
        AgeOculto = 5,
        AgeCartaPrecatoria = 6,
        AgeRepetirDias = 7,
        AgeHrFinal = 8,
        AgeRepetir = 9,
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
        AgeDDias = 20,
        AgeDias = 21,
        AgeLiberado = 22,
        AgeImportante = 23,
        AgeConcluido = 24,
        AgeArea = 25,
        AgeJustica = 26,
        AgeProcesso = 27,
        AgeIDHistorico = 28,
        AgeIDInsProcesso = 29,
        AgeUsuario = 30,
        AgePreposto = 31,
        AgeQuemID = 32,
        AgeQuemCodigo = 33,
        AgeStatus = 34,
        AgeValor = 35,
        AgeCompromissoHTML = 36,
        AgeDecisao = 37,
        AgeRevisar = 38,
        AgeRevisarP2 = 39,
        AgeSempre = 40,
        AgePrazoDias = 41,
        AgeProtocoloIntegrado = 42,
        AgeDataInicioPrazo = 43,
        AgeUsuarioCiente = 44,
        AgeGUID = 45,
        AgeQuemCad = 46,
        AgeDtCad = 47,
        AgeQuemAtu = 48,
        AgeDtAtu = 49,
        AgeVisto = 50
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AgeIDCOB => AgeIDCOB,
        NomesCamposTabela.AgeIDNE => AgeIDNE,
        NomesCamposTabela.AgePrazoProvisionado => AgePrazoProvisionado,
        NomesCamposTabela.AgeCidade => AgeCidade,
        NomesCamposTabela.AgeOculto => AgeOculto,
        NomesCamposTabela.AgeCartaPrecatoria => AgeCartaPrecatoria,
        NomesCamposTabela.AgeRepetirDias => AgeRepetirDias,
        NomesCamposTabela.AgeHrFinal => AgeHrFinal,
        NomesCamposTabela.AgeRepetir => AgeRepetir,
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
        NomesCamposTabela.AgeDDias => AgeDDias,
        NomesCamposTabela.AgeDias => AgeDias,
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
        NomesCamposTabela.AgeCompromissoHTML => AgeCompromissoHTML,
        NomesCamposTabela.AgeDecisao => AgeDecisao,
        NomesCamposTabela.AgeRevisar => AgeRevisar,
        NomesCamposTabela.AgeRevisarP2 => AgeRevisarP2,
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