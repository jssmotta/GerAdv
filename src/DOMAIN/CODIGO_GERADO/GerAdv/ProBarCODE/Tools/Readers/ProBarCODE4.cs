#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProBarCODEReader
{
    ProBarCODEResponse? Read(string where, SqlConnection oCnn);
    ProBarCODEResponse? Read(Entity.DBProBarCODE dbRec);
    ProBarCODEResponse? Read(DBProBarCODE dbRec);
}

public partial class ProBarCODE : IProBarCODEReader
{
    public ProBarCODEResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProBarCODE(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProBarCODEResponse? Read(Entity.DBProBarCODE dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var probarcode = new ProBarCODEResponse
        {
            Id = dbRec.ID,
            BarCODE = dbRec.FBarCODE ?? string.Empty,
            Processo = dbRec.FProcesso,
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
        probarcode.Auditor = auditor;
        return probarcode;
    }

    public ProBarCODEResponse? Read(DBProBarCODE dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var probarcode = new ProBarCODEResponse
        {
            Id = dbRec.ID,
            BarCODE = dbRec.FBarCODE ?? string.Empty,
            Processo = dbRec.FProcesso,
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
        probarcode.Auditor = auditor;
        return probarcode;
    }
}