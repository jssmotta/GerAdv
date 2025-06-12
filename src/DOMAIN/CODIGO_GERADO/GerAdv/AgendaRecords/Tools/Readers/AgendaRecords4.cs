#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRecordsReader
{
    AgendaRecordsResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaRecordsResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaRecordsResponse? Read(Entity.DBAgendaRecords dbRec);
    AgendaRecordsResponse? Read(DBAgendaRecords dbRec);
    AgendaRecordsResponseAll? ReadAll(DBAgendaRecords dbRec, DataRow dr);
}

public partial class AgendaRecords : IAgendaRecordsReader
{
    public AgendaRecordsResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRecords(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRecordsResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRecords(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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

    public AgendaRecordsResponseAll? ReadAll(DBAgendaRecords dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarecords = new AgendaRecordsResponseAll
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
        agendarecords.NomeClientesSocios = dr["cscNome"]?.ToString() ?? string.Empty;
        agendarecords.NomeColaboradores = dr["colNome"]?.ToString() ?? string.Empty;
        agendarecords.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        return agendarecords;
    }
}