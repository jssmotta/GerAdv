#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRepetirDiasWriter
{
    Entity.DBAgendaRepetirDias Write(Models.AgendaRepetirDias agendarepetirdias, MsiSqlConnection oCnn);
    void Delete(AgendaRepetirDiasResponse agendarepetirdias, int operadorId, MsiSqlConnection oCnn);
}

public class AgendaRepetirDias : IAgendaRepetirDiasWriter
{
    public void Delete(AgendaRepetirDiasResponse agendarepetirdias, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[AgendaRepetirDias] WHERE rpdCodigo={agendarepetirdias.Id};", oCnn);
    }

    public Entity.DBAgendaRepetirDias Write(Models.AgendaRepetirDias agendarepetirdias, MsiSqlConnection oCnn)
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