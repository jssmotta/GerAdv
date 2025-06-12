#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaQuemReader
{
    AgendaQuemResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaQuemResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaQuemResponse? Read(Entity.DBAgendaQuem dbRec);
    AgendaQuemResponse? Read(DBAgendaQuem dbRec);
    AgendaQuemResponseAll? ReadAll(DBAgendaQuem dbRec, DataRow dr);
}

public partial class AgendaQuem : IAgendaQuemReader
{
    public AgendaQuemResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaQuem(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaQuemResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaQuem(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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

    public AgendaQuemResponseAll? ReadAll(DBAgendaQuem dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendaquem = new AgendaQuemResponseAll
        {
            Id = dbRec.ID,
            IDAgenda = dbRec.FIDAgenda,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            Preposto = dbRec.FPreposto,
        };
        agendaquem.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agendaquem.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agendaquem.NomePrepostos = dr["preNome"]?.ToString() ?? string.Empty;
        return agendaquem;
    }
}