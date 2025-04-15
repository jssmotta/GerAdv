#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRepetirDiasReader
{
    AgendaRepetirDiasResponse? Read(int id, SqlConnection oCnn);
    AgendaRepetirDiasResponse? Read(string where, SqlConnection oCnn);
    AgendaRepetirDiasResponse? Read(Entity.DBAgendaRepetirDias dbRec);
    AgendaRepetirDiasResponse? Read(DBAgendaRepetirDias dbRec);
}

public partial class AgendaRepetirDias : IAgendaRepetirDiasReader
{
    public AgendaRepetirDiasResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRepetirDias(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRepetirDiasResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRepetirDias(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRepetirDiasResponse? Read(Entity.DBAgendaRepetirDias dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetirdias = new AgendaRepetirDiasResponse
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Dia = dbRec.FDia,
        };
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetirdias.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetirdias.Hora = dbRec.FHora;
        return agendarepetirdias;
    }

    public AgendaRepetirDiasResponse? Read(DBAgendaRepetirDias dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetirdias = new AgendaRepetirDiasResponse
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Dia = dbRec.FDia,
        };
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetirdias.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetirdias.Hora = dbRec.FHora;
        return agendarepetirdias;
    }
}