#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaStatusWriter
{
    Entity.DBAgendaStatus Write(Models.AgendaStatus agendastatus, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(AgendaStatusResponse agendastatus, int operadorId, MsiSqlConnection oCnn);
}

public class AgendaStatus : IAgendaStatusWriter
{
    public void Delete(AgendaStatusResponse agendastatus, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[AgendaStatus] WHERE astCodigo={agendastatus.Id};", oCnn);
    }

    public Entity.DBAgendaStatus Write(Models.AgendaStatus agendastatus, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = agendastatus.Id.IsEmptyIDNumber() ? new Entity.DBAgendaStatus() : new Entity.DBAgendaStatus(agendastatus.Id, oCnn);
        dbRec.FAgenda = agendastatus.Agenda;
        dbRec.FCompleted = agendastatus.Completed;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}