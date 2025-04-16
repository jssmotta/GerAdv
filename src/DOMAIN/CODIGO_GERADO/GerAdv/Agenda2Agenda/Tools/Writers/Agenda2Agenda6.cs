#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgenda2AgendaWriter
{
    Entity.DBAgenda2Agenda Write(Models.Agenda2Agenda agenda2agenda, int auditorQuem, SqlConnection oCnn);
}

public class Agenda2Agenda : IAgenda2AgendaWriter
{
    public Entity.DBAgenda2Agenda Write(Models.Agenda2Agenda agenda2agenda, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = agenda2agenda.Id.IsEmptyIDNumber() ? new Entity.DBAgenda2Agenda() : new Entity.DBAgenda2Agenda(agenda2agenda.Id, oCnn);
        dbRec.FMaster = agenda2agenda.Master;
        dbRec.FAgenda = agenda2agenda.Agenda;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}