#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusTarefasWhere
{
    StatusTarefasResponse Read(string where, SqlConnection oCnn);
}

public partial class StatusTarefas : IStatusTarefasWhere
{
    public StatusTarefasResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusTarefas(sqlWhere: where, oCnn: oCnn);
        var statustarefas = new StatusTarefasResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
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