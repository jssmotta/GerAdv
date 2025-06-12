#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaReader
{
    AgendaResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaResponse? Read(Entity.DBAgenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaResponse? Read(DBAgenda dbRec);
    AgendaResponseAll? ReadAll(DBAgenda dbRec, DataRow dr);
}

public partial class Agenda : IAgendaReader
{
    public AgendaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaResponse? Read(Entity.DBAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda = new AgendaResponse
        {
            Id = dbRec.ID,
            IDCOB = dbRec.FIDCOB,
            ClienteAvisado = dbRec.FClienteAvisado,
            RevisarP2 = dbRec.FRevisarP2,
            IDNE = dbRec.FIDNE,
            Cidade = dbRec.FCidade,
            Oculto = dbRec.FOculto,
            CartaPrecatoria = dbRec.FCartaPrecatoria,
            Revisar = dbRec.FRevisar,
            Advogado = dbRec.FAdvogado,
            EventoGerador = dbRec.FEventoGerador,
            Funcionario = dbRec.FFuncionario,
            EventoPrazo = dbRec.FEventoPrazo,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Cliente = dbRec.FCliente,
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
            Decisao = dbRec.FDecisao ?? string.Empty,
            Sempre = dbRec.FSempre,
            PrazoDias = dbRec.FPrazoDias,
            ProtocoloIntegrado = dbRec.FProtocoloIntegrado,
            UsuarioCiente = dbRec.FUsuarioCiente,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHrFinal, out _))
            agenda.HrFinal = dbRec.FHrFinal;
        if (DateTime.TryParse(dbRec.FEventoData, out _))
            agenda.EventoData = dbRec.FEventoData;
        if (DateTime.TryParse(dbRec.FData, out _))
            agenda.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agenda.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FDataInicioPrazo, out _))
            agenda.DataInicioPrazo = dbRec.FDataInicioPrazo;
        return agenda;
    }

    public AgendaResponse? Read(DBAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda = new AgendaResponse
        {
            Id = dbRec.ID,
            IDCOB = dbRec.FIDCOB,
            ClienteAvisado = dbRec.FClienteAvisado,
            RevisarP2 = dbRec.FRevisarP2,
            IDNE = dbRec.FIDNE,
            Cidade = dbRec.FCidade,
            Oculto = dbRec.FOculto,
            CartaPrecatoria = dbRec.FCartaPrecatoria,
            Revisar = dbRec.FRevisar,
            Advogado = dbRec.FAdvogado,
            EventoGerador = dbRec.FEventoGerador,
            Funcionario = dbRec.FFuncionario,
            EventoPrazo = dbRec.FEventoPrazo,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Cliente = dbRec.FCliente,
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
            Decisao = dbRec.FDecisao ?? string.Empty,
            Sempre = dbRec.FSempre,
            PrazoDias = dbRec.FPrazoDias,
            ProtocoloIntegrado = dbRec.FProtocoloIntegrado,
            UsuarioCiente = dbRec.FUsuarioCiente,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHrFinal, out _))
            agenda.HrFinal = dbRec.FHrFinal;
        if (DateTime.TryParse(dbRec.FEventoData, out _))
            agenda.EventoData = dbRec.FEventoData;
        if (DateTime.TryParse(dbRec.FData, out _))
            agenda.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agenda.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FDataInicioPrazo, out _))
            agenda.DataInicioPrazo = dbRec.FDataInicioPrazo;
        return agenda;
    }

    public AgendaResponseAll? ReadAll(DBAgenda dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda = new AgendaResponseAll
        {
            Id = dbRec.ID,
            IDCOB = dbRec.FIDCOB,
            ClienteAvisado = dbRec.FClienteAvisado,
            RevisarP2 = dbRec.FRevisarP2,
            IDNE = dbRec.FIDNE,
            Cidade = dbRec.FCidade,
            Oculto = dbRec.FOculto,
            CartaPrecatoria = dbRec.FCartaPrecatoria,
            Revisar = dbRec.FRevisar,
            Advogado = dbRec.FAdvogado,
            EventoGerador = dbRec.FEventoGerador,
            Funcionario = dbRec.FFuncionario,
            EventoPrazo = dbRec.FEventoPrazo,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Cliente = dbRec.FCliente,
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
            Decisao = dbRec.FDecisao ?? string.Empty,
            Sempre = dbRec.FSempre,
            PrazoDias = dbRec.FPrazoDias,
            ProtocoloIntegrado = dbRec.FProtocoloIntegrado,
            UsuarioCiente = dbRec.FUsuarioCiente,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHrFinal, out _))
            agenda.HrFinal = dbRec.FHrFinal;
        if (DateTime.TryParse(dbRec.FEventoData, out _))
            agenda.EventoData = dbRec.FEventoData;
        if (DateTime.TryParse(dbRec.FData, out _))
            agenda.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agenda.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FDataInicioPrazo, out _))
            agenda.DataInicioPrazo = dbRec.FDataInicioPrazo;
        agenda.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        agenda.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agenda.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agenda.DescricaoTipoCompromisso = dr["tipDescricao"]?.ToString() ?? string.Empty;
        agenda.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        agenda.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        agenda.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        agenda.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        agenda.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        agenda.NomePrepostos = dr["preNome"]?.ToString() ?? string.Empty;
        return agenda;
    }
}