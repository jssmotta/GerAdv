#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaReader
{
    AgendaResponse? Read(int id, SqlConnection oCnn);
    AgendaResponse? Read(string where, SqlConnection oCnn);
    AgendaResponse? Read(Entity.DBAgenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    AgendaResponse? Read(DBAgenda dbRec);
}

public partial class Agenda : IAgendaReader
{
    public AgendaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda(sqlWhere: where, oCnn: oCnn);
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
            Guid = dbRec.FGUID ?? string.Empty,
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
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        agenda.Auditor = auditor;
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
            Guid = dbRec.FGUID ?? string.Empty,
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
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        agenda.Auditor = auditor;
        return agenda;
    }
}