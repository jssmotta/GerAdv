#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaQuemWriter
{
    Entity.DBAgendaQuem Write(Models.AgendaQuem agendaquem, MsiSqlConnection oCnn);
    void Delete(AgendaQuemResponse agendaquem, int operadorId, MsiSqlConnection oCnn);
}

public class AgendaQuem : IAgendaQuemWriter
{
    public void Delete(AgendaQuemResponse agendaquem, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[AgendaQuem] WHERE agqCodigo={agendaquem.Id};", oCnn);
    }

    public Entity.DBAgendaQuem Write(Models.AgendaQuem agendaquem, MsiSqlConnection oCnn)
    {
        var dbRec = agendaquem.Id.IsEmptyIDNumber() ? new Entity.DBAgendaQuem() : new Entity.DBAgendaQuem(agendaquem.Id, oCnn);
        dbRec.FIDAgenda = agendaquem.IDAgenda;
        dbRec.FAdvogado = agendaquem.Advogado;
        dbRec.FFuncionario = agendaquem.Funcionario;
        dbRec.FPreposto = agendaquem.Preposto;
        dbRec.Update(oCnn);
        return dbRec;
    }
}