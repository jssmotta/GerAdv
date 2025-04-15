#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEventoPrazoAgendaWriter
{
    Entity.DBEventoPrazoAgenda Write(Models.EventoPrazoAgenda eventoprazoagenda, int auditorQuem, SqlConnection oCnn);
}

public class EventoPrazoAgenda : IEventoPrazoAgendaWriter
{
    public Entity.DBEventoPrazoAgenda Write(Models.EventoPrazoAgenda eventoprazoagenda, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = eventoprazoagenda.Id.IsEmptyIDNumber() ? new Entity.DBEventoPrazoAgenda() : new Entity.DBEventoPrazoAgenda(eventoprazoagenda.Id, oCnn);
        dbRec.FNome = eventoprazoagenda.Nome;
        dbRec.FBold = eventoprazoagenda.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}