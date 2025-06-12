#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaFinanceiroReader
{
    AgendaFinanceiroResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaFinanceiroResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaFinanceiroResponse? Read(Entity.DBAgendaFinanceiro dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaFinanceiroResponse? Read(DBAgendaFinanceiro dbRec);
    AgendaFinanceiroResponseAll? ReadAll(DBAgendaFinanceiro dbRec, DataRow dr);
}

public partial class AgendaFinanceiro : IAgendaFinanceiroReader
{
    public AgendaFinanceiroResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaFinanceiro(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaFinanceiroResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaFinanceiro(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaFinanceiroResponse? Read(Entity.DBAgendaFinanceiro dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendafinanceiro = new AgendaFinanceiroResponse
        {
            Id = dbRec.ID,
            IDCOB = dbRec.FIDCOB,
            IDNE = dbRec.FIDNE,
            PrazoProvisionado = dbRec.FPrazoProvisionado,
            Cidade = dbRec.FCidade,
            Oculto = dbRec.FOculto,
            CartaPrecatoria = dbRec.FCartaPrecatoria,
            RepetirDias = dbRec.FRepetirDias,
            Repetir = dbRec.FRepetir,
            Advogado = dbRec.FAdvogado,
            EventoGerador = dbRec.FEventoGerador,
            Funcionario = dbRec.FFuncionario,
            EventoPrazo = dbRec.FEventoPrazo,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Cliente = dbRec.FCliente,
            Dias = dbRec.FDias,
            Liberado = dbRec.FLiberado,
            Importante = dbRec.FImportante,
            Concluido = dbRec.FConcluido,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
            Processo = dbRec.FProcesso,
            IDHistorico = dbRec.FIDHistorico,
            IDInsProcesso = dbRec.FIDInsProcesso,
            Usuario = dbRec.FUsuario,
            Preposto = dbRec.FPreposto,
            QuemID = dbRec.FQuemID,
            QuemCodigo = dbRec.FQuemCodigo,
            Status = dbRec.FStatus ?? string.Empty,
            Valor = dbRec.FValor,
            CompromissoHTML = dbRec.FCompromissoHTML ?? string.Empty,
            Decisao = dbRec.FDecisao ?? string.Empty,
            Revisar = dbRec.FRevisar,
            RevisarP2 = dbRec.FRevisarP2,
            Sempre = dbRec.FSempre,
            PrazoDias = dbRec.FPrazoDias,
            ProtocoloIntegrado = dbRec.FProtocoloIntegrado,
            UsuarioCiente = dbRec.FUsuarioCiente,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHrFinal, out _))
            agendafinanceiro.HrFinal = dbRec.FHrFinal;
        if (DateTime.TryParse(dbRec.FEventoData, out _))
            agendafinanceiro.EventoData = dbRec.FEventoData;
        if (DateTime.TryParse(dbRec.FData, out _))
            agendafinanceiro.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendafinanceiro.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FDDias, out _))
            agendafinanceiro.DDias = dbRec.FDDias;
        if (DateTime.TryParse(dbRec.FDataInicioPrazo, out _))
            agendafinanceiro.DataInicioPrazo = dbRec.FDataInicioPrazo;
        return agendafinanceiro;
    }

    public AgendaFinanceiroResponse? Read(DBAgendaFinanceiro dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendafinanceiro = new AgendaFinanceiroResponse
        {
            Id = dbRec.ID,
            IDCOB = dbRec.FIDCOB,
            IDNE = dbRec.FIDNE,
            PrazoProvisionado = dbRec.FPrazoProvisionado,
            Cidade = dbRec.FCidade,
            Oculto = dbRec.FOculto,
            CartaPrecatoria = dbRec.FCartaPrecatoria,
            RepetirDias = dbRec.FRepetirDias,
            Repetir = dbRec.FRepetir,
            Advogado = dbRec.FAdvogado,
            EventoGerador = dbRec.FEventoGerador,
            Funcionario = dbRec.FFuncionario,
            EventoPrazo = dbRec.FEventoPrazo,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Cliente = dbRec.FCliente,
            Dias = dbRec.FDias,
            Liberado = dbRec.FLiberado,
            Importante = dbRec.FImportante,
            Concluido = dbRec.FConcluido,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
            Processo = dbRec.FProcesso,
            IDHistorico = dbRec.FIDHistorico,
            IDInsProcesso = dbRec.FIDInsProcesso,
            Usuario = dbRec.FUsuario,
            Preposto = dbRec.FPreposto,
            QuemID = dbRec.FQuemID,
            QuemCodigo = dbRec.FQuemCodigo,
            Status = dbRec.FStatus ?? string.Empty,
            Valor = dbRec.FValor,
            CompromissoHTML = dbRec.FCompromissoHTML ?? string.Empty,
            Decisao = dbRec.FDecisao ?? string.Empty,
            Revisar = dbRec.FRevisar,
            RevisarP2 = dbRec.FRevisarP2,
            Sempre = dbRec.FSempre,
            PrazoDias = dbRec.FPrazoDias,
            ProtocoloIntegrado = dbRec.FProtocoloIntegrado,
            UsuarioCiente = dbRec.FUsuarioCiente,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHrFinal, out _))
            agendafinanceiro.HrFinal = dbRec.FHrFinal;
        if (DateTime.TryParse(dbRec.FEventoData, out _))
            agendafinanceiro.EventoData = dbRec.FEventoData;
        if (DateTime.TryParse(dbRec.FData, out _))
            agendafinanceiro.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendafinanceiro.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FDDias, out _))
            agendafinanceiro.DDias = dbRec.FDDias;
        if (DateTime.TryParse(dbRec.FDataInicioPrazo, out _))
            agendafinanceiro.DataInicioPrazo = dbRec.FDataInicioPrazo;
        return agendafinanceiro;
    }

    public AgendaFinanceiroResponseAll? ReadAll(DBAgendaFinanceiro dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendafinanceiro = new AgendaFinanceiroResponseAll
        {
            Id = dbRec.ID,
            IDCOB = dbRec.FIDCOB,
            IDNE = dbRec.FIDNE,
            PrazoProvisionado = dbRec.FPrazoProvisionado,
            Cidade = dbRec.FCidade,
            Oculto = dbRec.FOculto,
            CartaPrecatoria = dbRec.FCartaPrecatoria,
            RepetirDias = dbRec.FRepetirDias,
            Repetir = dbRec.FRepetir,
            Advogado = dbRec.FAdvogado,
            EventoGerador = dbRec.FEventoGerador,
            Funcionario = dbRec.FFuncionario,
            EventoPrazo = dbRec.FEventoPrazo,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Cliente = dbRec.FCliente,
            Dias = dbRec.FDias,
            Liberado = dbRec.FLiberado,
            Importante = dbRec.FImportante,
            Concluido = dbRec.FConcluido,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
            Processo = dbRec.FProcesso,
            IDHistorico = dbRec.FIDHistorico,
            IDInsProcesso = dbRec.FIDInsProcesso,
            Usuario = dbRec.FUsuario,
            Preposto = dbRec.FPreposto,
            QuemID = dbRec.FQuemID,
            QuemCodigo = dbRec.FQuemCodigo,
            Status = dbRec.FStatus ?? string.Empty,
            Valor = dbRec.FValor,
            CompromissoHTML = dbRec.FCompromissoHTML ?? string.Empty,
            Decisao = dbRec.FDecisao ?? string.Empty,
            Revisar = dbRec.FRevisar,
            RevisarP2 = dbRec.FRevisarP2,
            Sempre = dbRec.FSempre,
            PrazoDias = dbRec.FPrazoDias,
            ProtocoloIntegrado = dbRec.FProtocoloIntegrado,
            UsuarioCiente = dbRec.FUsuarioCiente,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHrFinal, out _))
            agendafinanceiro.HrFinal = dbRec.FHrFinal;
        if (DateTime.TryParse(dbRec.FEventoData, out _))
            agendafinanceiro.EventoData = dbRec.FEventoData;
        if (DateTime.TryParse(dbRec.FData, out _))
            agendafinanceiro.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendafinanceiro.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FDDias, out _))
            agendafinanceiro.DDias = dbRec.FDDias;
        if (DateTime.TryParse(dbRec.FDataInicioPrazo, out _))
            agendafinanceiro.DataInicioPrazo = dbRec.FDataInicioPrazo;
        agendafinanceiro.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        agendafinanceiro.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agendafinanceiro.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agendafinanceiro.DescricaoTipoCompromisso = dr["tipDescricao"]?.ToString() ?? string.Empty;
        agendafinanceiro.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        agendafinanceiro.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        agendafinanceiro.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        agendafinanceiro.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        agendafinanceiro.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        agendafinanceiro.NomePrepostos = dr["preNome"]?.ToString() ?? string.Empty;
        return agendafinanceiro;
    }
}