#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraStatusReader
{
    PenhoraStatusResponse? Read(int id, SqlConnection oCnn);
    PenhoraStatusResponse? Read(string where, SqlConnection oCnn);
    PenhoraStatusResponse? Read(Entity.DBPenhoraStatus dbRec);
    PenhoraStatusResponse? Read(DBPenhoraStatus dbRec);
}

public partial class PenhoraStatus : IPenhoraStatusReader
{
    public PenhoraStatusResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhoraStatus(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraStatusResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhoraStatus(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraStatusResponse? Read(Entity.DBPenhoraStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhorastatus = new PenhoraStatusResponse
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
        penhorastatus.Auditor = auditor;
        return penhorastatus;
    }

    public PenhoraStatusResponse? Read(DBPenhoraStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhorastatus = new PenhoraStatusResponse
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
        penhorastatus.Auditor = auditor;
        return penhorastatus;
    }
}