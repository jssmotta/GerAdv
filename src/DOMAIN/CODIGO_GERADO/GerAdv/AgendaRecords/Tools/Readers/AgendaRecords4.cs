#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRecordsReader
{
    AgendaRecordsResponse? Read(int id, SqlConnection oCnn);
    AgendaRecordsResponse? Read(string where, SqlConnection oCnn);
    AgendaRecordsResponse? Read(Entity.DBAgendaRecords dbRec);
    AgendaRecordsResponse? Read(DBAgendaRecords dbRec);
}

public partial class AgendaRecords : IAgendaRecordsReader
{
    public AgendaRecordsResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRecords(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRecordsResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRecords(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRecordsResponse? Read(Entity.DBAgendaRecords dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarecords = new AgendaRecordsResponse
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Julgador = dbRec.FJulgador,
            ClientesSocios = dbRec.FClientesSocios,
            Perito = dbRec.FPerito,
            Colaborador = dbRec.FColaborador,
            Foro = dbRec.FForo,
            Aviso1 = dbRec.FAviso1,
            Aviso2 = dbRec.FAviso2,
            Aviso3 = dbRec.FAviso3,
            CrmAviso1 = dbRec.FCrmAviso1,
            CrmAviso2 = dbRec.FCrmAviso2,
            CrmAviso3 = dbRec.FCrmAviso3,
        };
        if (DateTime.TryParse(dbRec.FDataAviso1, out _))
            agendarecords.DataAviso1 = dbRec.FDataAviso1;
        if (DateTime.TryParse(dbRec.FDataAviso2, out _))
            agendarecords.DataAviso2 = dbRec.FDataAviso2;
        if (DateTime.TryParse(dbRec.FDataAviso3, out _))
            agendarecords.DataAviso3 = dbRec.FDataAviso3;
        return agendarecords;
    }

    public AgendaRecordsResponse? Read(DBAgendaRecords dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarecords = new AgendaRecordsResponse
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Julgador = dbRec.FJulgador,
            ClientesSocios = dbRec.FClientesSocios,
            Perito = dbRec.FPerito,
            Colaborador = dbRec.FColaborador,
            Foro = dbRec.FForo,
            Aviso1 = dbRec.FAviso1,
            Aviso2 = dbRec.FAviso2,
            Aviso3 = dbRec.FAviso3,
            CrmAviso1 = dbRec.FCrmAviso1,
            CrmAviso2 = dbRec.FCrmAviso2,
            CrmAviso3 = dbRec.FCrmAviso3,
        };
        if (DateTime.TryParse(dbRec.FDataAviso1, out _))
            agendarecords.DataAviso1 = dbRec.FDataAviso1;
        if (DateTime.TryParse(dbRec.FDataAviso2, out _))
            agendarecords.DataAviso2 = dbRec.FDataAviso2;
        if (DateTime.TryParse(dbRec.FDataAviso3, out _))
            agendarecords.DataAviso3 = dbRec.FDataAviso3;
        return agendarecords;
    }
}