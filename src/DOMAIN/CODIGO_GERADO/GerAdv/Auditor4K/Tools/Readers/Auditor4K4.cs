#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAuditor4KReader
{
    Auditor4KResponse? Read(int id, SqlConnection oCnn);
    Auditor4KResponse? Read(string where, SqlConnection oCnn);
    Auditor4KResponse? Read(Entity.DBAuditor4K dbRec);
    Auditor4KResponse? Read(DBAuditor4K dbRec);
}

public partial class Auditor4K : IAuditor4KReader
{
    public Auditor4KResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAuditor4K(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Auditor4KResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAuditor4K(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Auditor4KResponse? Read(Entity.DBAuditor4K dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var auditor4k = new Auditor4KResponse
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
        auditor4k.Auditor = auditor;
        return auditor4k;
    }

    public Auditor4KResponse? Read(DBAuditor4K dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var auditor4k = new Auditor4KResponse
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
        auditor4k.Auditor = auditor;
        return auditor4k;
    }
}