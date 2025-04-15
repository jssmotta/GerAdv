#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaStatusReader
{
    AgendaStatusResponse? Read(int id, SqlConnection oCnn);
    AgendaStatusResponse? Read(string where, SqlConnection oCnn);
    AgendaStatusResponse? Read(Entity.DBAgendaStatus dbRec);
    AgendaStatusResponse? Read(DBAgendaStatus dbRec);
}

public partial class AgendaStatus : IAgendaStatusReader
{
    public AgendaStatusResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaStatus(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaStatusResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaStatus(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaStatusResponse? Read(Entity.DBAgendaStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendastatus = new AgendaStatusResponse
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Completed = dbRec.FCompleted,
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
        agendastatus.Auditor = auditor;
        return agendastatus;
    }

    public AgendaStatusResponse? Read(DBAgendaStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendastatus = new AgendaStatusResponse
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Completed = dbRec.FCompleted,
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
        agendastatus.Auditor = auditor;
        return agendastatus;
    }
}