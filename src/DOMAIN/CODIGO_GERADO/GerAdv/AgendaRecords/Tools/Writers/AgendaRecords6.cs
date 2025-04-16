#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRecordsWriter
{
    Entity.DBAgendaRecords Write(Models.AgendaRecords agendarecords, SqlConnection oCnn);
}

public class AgendaRecords : IAgendaRecordsWriter
{
    public Entity.DBAgendaRecords Write(Models.AgendaRecords agendarecords, SqlConnection oCnn)
    {
        var dbRec = agendarecords.Id.IsEmptyIDNumber() ? new Entity.DBAgendaRecords() : new Entity.DBAgendaRecords(agendarecords.Id, oCnn);
        dbRec.FAgenda = agendarecords.Agenda;
        dbRec.FJulgador = agendarecords.Julgador;
        dbRec.FClientesSocios = agendarecords.ClientesSocios;
        dbRec.FPerito = agendarecords.Perito;
        dbRec.FColaborador = agendarecords.Colaborador;
        dbRec.FForo = agendarecords.Foro;
        dbRec.FAviso1 = agendarecords.Aviso1;
        dbRec.FAviso2 = agendarecords.Aviso2;
        dbRec.FAviso3 = agendarecords.Aviso3;
        dbRec.FCrmAviso1 = agendarecords.CrmAviso1;
        dbRec.FCrmAviso2 = agendarecords.CrmAviso2;
        dbRec.FCrmAviso3 = agendarecords.CrmAviso3;
        if (agendarecords.DataAviso1 != null)
            dbRec.FDataAviso1 = agendarecords.DataAviso1.ToString();
        if (agendarecords.DataAviso2 != null)
            dbRec.FDataAviso2 = agendarecords.DataAviso2.ToString();
        if (agendarecords.DataAviso3 != null)
            dbRec.FDataAviso3 = agendarecords.DataAviso3.ToString();
        dbRec.Update(oCnn);
        return dbRec;
    }
}