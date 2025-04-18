#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusTarefasReader
{
    StatusTarefasResponse? Read(int id, SqlConnection oCnn);
    StatusTarefasResponse? Read(string where, SqlConnection oCnn);
    StatusTarefasResponse? Read(Entity.DBStatusTarefas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    StatusTarefasResponse? Read(DBStatusTarefas dbRec);
}

public partial class StatusTarefas : IStatusTarefasReader
{
    public StatusTarefasResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusTarefas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusTarefasResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusTarefas(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusTarefasResponse? Read(Entity.DBStatusTarefas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statustarefas = new StatusTarefasResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        statustarefas.Auditor = auditor;
        return statustarefas;
    }

    public StatusTarefasResponse? Read(DBStatusTarefas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statustarefas = new StatusTarefasResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        statustarefas.Auditor = auditor;
        return statustarefas;
    }
}