#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEventoPrazoAgendaReader
{
    EventoPrazoAgendaResponse? Read(int id, SqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(string where, SqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(Entity.DBEventoPrazoAgenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(DBEventoPrazoAgenda dbRec);
}

public partial class EventoPrazoAgenda : IEventoPrazoAgendaReader
{
    public EventoPrazoAgendaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEventoPrazoAgenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EventoPrazoAgendaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEventoPrazoAgenda(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EventoPrazoAgendaResponse? Read(Entity.DBEventoPrazoAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var eventoprazoagenda = new EventoPrazoAgendaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
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
        eventoprazoagenda.Auditor = auditor;
        return eventoprazoagenda;
    }

    public EventoPrazoAgendaResponse? Read(DBEventoPrazoAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var eventoprazoagenda = new EventoPrazoAgendaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
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
        eventoprazoagenda.Auditor = auditor;
        return eventoprazoagenda;
    }
}