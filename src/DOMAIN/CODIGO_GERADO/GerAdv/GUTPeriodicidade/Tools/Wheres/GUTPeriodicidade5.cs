#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeWhere
{
    GUTPeriodicidadeResponse Read(string where, SqlConnection oCnn);
}

public partial class GUTPeriodicidade : IGUTPeriodicidadeWhere
{
    public GUTPeriodicidadeResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidade(sqlWhere: where, oCnn: oCnn);
        var gutperiodicidade = new GUTPeriodicidadeResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
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
        gutperiodicidade.Auditor = auditor;
        return gutperiodicidade;
    }
}