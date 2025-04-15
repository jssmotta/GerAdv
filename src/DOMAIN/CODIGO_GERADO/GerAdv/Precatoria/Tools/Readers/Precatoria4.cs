#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPrecatoriaReader
{
    PrecatoriaResponse? Read(int id, SqlConnection oCnn);
    PrecatoriaResponse? Read(string where, SqlConnection oCnn);
    PrecatoriaResponse? Read(Entity.DBPrecatoria dbRec);
    PrecatoriaResponse? Read(DBPrecatoria dbRec);
}

public partial class Precatoria : IPrecatoriaReader
{
    public PrecatoriaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPrecatoria(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PrecatoriaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPrecatoria(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PrecatoriaResponse? Read(Entity.DBPrecatoria dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var precatoria = new PrecatoriaResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            PrecatoriaX = dbRec.FPrecatoria ?? string.Empty,
            Deprecante = dbRec.FDeprecante ?? string.Empty,
            Deprecado = dbRec.FDeprecado ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            precatoria.DtDist = dbRec.FDtDist;
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
        precatoria.Auditor = auditor;
        return precatoria;
    }

    public PrecatoriaResponse? Read(DBPrecatoria dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var precatoria = new PrecatoriaResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            PrecatoriaX = dbRec.FPrecatoria ?? string.Empty,
            Deprecante = dbRec.FDeprecante ?? string.Empty,
            Deprecado = dbRec.FDeprecado ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            precatoria.DtDist = dbRec.FDtDist;
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
        precatoria.Auditor = auditor;
        return precatoria;
    }
}