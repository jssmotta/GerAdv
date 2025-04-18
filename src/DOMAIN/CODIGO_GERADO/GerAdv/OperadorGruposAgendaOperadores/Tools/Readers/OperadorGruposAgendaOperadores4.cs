#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaOperadoresReader
{
    OperadorGruposAgendaOperadoresResponse? Read(int id, SqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(string where, SqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(Entity.DBOperadorGruposAgendaOperadores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(DBOperadorGruposAgendaOperadores dbRec);
}

public partial class OperadorGruposAgendaOperadores : IOperadorGruposAgendaOperadoresReader
{
    public OperadorGruposAgendaOperadoresResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgendaOperadores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaOperadoresResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgendaOperadores(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaOperadoresResponse? Read(Entity.DBOperadorGruposAgendaOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagendaoperadores = new OperadorGruposAgendaOperadoresResponse
        {
            Id = dbRec.ID,
            OperadorGruposAgenda = dbRec.FOperadorGruposAgenda,
            Operador = dbRec.FOperador,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        operadorgruposagendaoperadores.Auditor = auditor;
        return operadorgruposagendaoperadores;
    }

    public OperadorGruposAgendaOperadoresResponse? Read(DBOperadorGruposAgendaOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagendaoperadores = new OperadorGruposAgendaOperadoresResponse
        {
            Id = dbRec.ID,
            OperadorGruposAgenda = dbRec.FOperadorGruposAgenda,
            Operador = dbRec.FOperador,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        operadorgruposagendaoperadores.Auditor = auditor;
        return operadorgruposagendaoperadores;
    }
}