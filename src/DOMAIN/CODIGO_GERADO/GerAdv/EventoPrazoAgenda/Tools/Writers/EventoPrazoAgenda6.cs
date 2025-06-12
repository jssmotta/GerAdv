#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEventoPrazoAgendaWriter
{
    Entity.DBEventoPrazoAgenda Write(Models.EventoPrazoAgenda eventoprazoagenda, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(EventoPrazoAgendaResponse eventoprazoagenda, int operadorId, MsiSqlConnection oCnn);
}

public class EventoPrazoAgenda : IEventoPrazoAgendaWriter
{
    public void Delete(EventoPrazoAgendaResponse eventoprazoagenda, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[EventoPrazoAgenda] WHERE epaCodigo={eventoprazoagenda.Id};", oCnn);
    }

    public Entity.DBEventoPrazoAgenda Write(Models.EventoPrazoAgenda eventoprazoagenda, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = eventoprazoagenda.Id.IsEmptyIDNumber() ? new Entity.DBEventoPrazoAgenda() : new Entity.DBEventoPrazoAgenda(eventoprazoagenda.Id, oCnn);
        dbRec.FNome = eventoprazoagenda.Nome;
        dbRec.FBold = eventoprazoagenda.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}