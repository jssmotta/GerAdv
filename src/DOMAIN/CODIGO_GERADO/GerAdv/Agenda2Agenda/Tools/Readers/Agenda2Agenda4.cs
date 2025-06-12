#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgenda2AgendaReader
{
    Agenda2AgendaResponse? Read(int id, MsiSqlConnection oCnn);
    Agenda2AgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Agenda2AgendaResponse? Read(Entity.DBAgenda2Agenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Agenda2AgendaResponse? Read(DBAgenda2Agenda dbRec);
    Agenda2AgendaResponseAll? ReadAll(DBAgenda2Agenda dbRec, DataRow dr);
}

public partial class Agenda2Agenda : IAgenda2AgendaReader
{
    public Agenda2AgendaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda2Agenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Agenda2AgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda2Agenda(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
        return agenda2agenda;
    }

    public Agenda2AgendaResponseAll? ReadAll(DBAgenda2Agenda dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda2agenda = new Agenda2AgendaResponseAll
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Agenda = dbRec.FAgenda,
        };
        return agenda2agenda;
    }
}