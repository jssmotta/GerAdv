#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRepetirDiasWriter
{
    Entity.DBAgendaRepetirDias Write(Models.AgendaRepetirDias agendarepetirdias, SqlConnection oCnn);
}

public class AgendaRepetirDias : IAgendaRepetirDiasWriter
{
    public Entity.DBAgendaRepetirDias Write(Models.AgendaRepetirDias agendarepetirdias, SqlConnection oCnn)
    {
        var dbRec = agendarepetirdias.Id.IsEmptyIDNumber() ? new Entity.DBAgendaRepetirDias() : new Entity.DBAgendaRepetirDias(agendarepetirdias.Id, oCnn);
        if (agendarepetirdias.HoraFinal != null)
            dbRec.FHoraFinal = agendarepetirdias.HoraFinal.ToString();
        dbRec.FMaster = agendarepetirdias.Master;
        dbRec.FDia = agendarepetirdias.Dia;
        if (agendarepetirdias.Hora != null)
            dbRec.FHora = agendarepetirdias.Hora.ToString();
        dbRec.Update(oCnn);
        return dbRec;
    }
}