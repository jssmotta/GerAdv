#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaStatusReader
{
    AgendaStatusResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaStatusResponse? Read(Entity.DBAgendaStatus dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaStatusResponse? Read(DBAgendaStatus dbRec);
    AgendaStatusResponseAll? ReadAll(DBAgendaStatus dbRec, DataRow dr);
}

public partial class AgendaStatus : IAgendaStatusReader
{
    public AgendaStatusResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaStatus(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaStatus(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
        return agendastatus;
    }

    public AgendaStatusResponseAll? ReadAll(DBAgendaStatus dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendastatus = new AgendaStatusResponseAll
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Completed = dbRec.FCompleted,
        };
        return agendastatus;
    }
}