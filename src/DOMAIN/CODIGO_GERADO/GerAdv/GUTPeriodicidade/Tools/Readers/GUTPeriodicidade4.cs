#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeReader
{
    GUTPeriodicidadeResponse? Read(int id, SqlConnection oCnn);
    GUTPeriodicidadeResponse? Read(string where, SqlConnection oCnn);
    GUTPeriodicidadeResponse? Read(Entity.DBGUTPeriodicidade dbRec);
    GUTPeriodicidadeResponse? Read(DBGUTPeriodicidade dbRec);
}

public partial class GUTPeriodicidade : IGUTPeriodicidadeReader
{
    public GUTPeriodicidadeResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidade(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidade(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeResponse? Read(Entity.DBGUTPeriodicidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidade = new GUTPeriodicidadeResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
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
        gutperiodicidade.Auditor = auditor;
        return gutperiodicidade;
    }

    public GUTPeriodicidadeResponse? Read(DBGUTPeriodicidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidade = new GUTPeriodicidadeResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
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
        gutperiodicidade.Auditor = auditor;
        return gutperiodicidade;
    }
}