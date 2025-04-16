#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgenda2AgendaReader
{
    Agenda2AgendaResponse? Read(int id, SqlConnection oCnn);
    Agenda2AgendaResponse? Read(string where, SqlConnection oCnn);
    Agenda2AgendaResponse? Read(Entity.DBAgenda2Agenda dbRec);
    Agenda2AgendaResponse? Read(DBAgenda2Agenda dbRec);
}

public partial class Agenda2Agenda : IAgenda2AgendaReader
{
    public Agenda2AgendaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda2Agenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Agenda2AgendaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda2Agenda(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Agenda2AgendaResponse? Read(Entity.DBAgenda2Agenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda2agenda = new Agenda2AgendaResponse
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Agenda = dbRec.FAgenda,
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
        agenda2agenda.Auditor = auditor;
        return agenda2agenda;
    }

    public Agenda2AgendaResponse? Read(DBAgenda2Agenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda2agenda = new Agenda2AgendaResponse
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Agenda = dbRec.FAgenda,
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
        agenda2agenda.Auditor = auditor;
        return agenda2agenda;
    }
}