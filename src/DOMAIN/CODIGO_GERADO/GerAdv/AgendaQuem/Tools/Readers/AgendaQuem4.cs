#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaQuemReader
{
    AgendaQuemResponse? Read(int id, SqlConnection oCnn);
    AgendaQuemResponse? Read(string where, SqlConnection oCnn);
    AgendaQuemResponse? Read(Entity.DBAgendaQuem dbRec);
    AgendaQuemResponse? Read(DBAgendaQuem dbRec);
}

public partial class AgendaQuem : IAgendaQuemReader
{
    public AgendaQuemResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaQuem(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaQuemResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaQuem(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaQuemResponse? Read(Entity.DBAgendaQuem dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendaquem = new AgendaQuemResponse
        {
            Id = dbRec.ID,
            IDAgenda = dbRec.FIDAgenda,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            Preposto = dbRec.FPreposto,
        };
        return agendaquem;
    }

    public AgendaQuemResponse? Read(DBAgendaQuem dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendaquem = new AgendaQuemResponse
        {
            Id = dbRec.ID,
            IDAgenda = dbRec.FIDAgenda,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            Preposto = dbRec.FPreposto,
        };
        return agendaquem;
    }
}