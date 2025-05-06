#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAuditor4KWhere
{
    Auditor4KResponse Read(string where, SqlConnection oCnn);
}

public partial class Auditor4K : IAuditor4KWhere
{
    public Auditor4KResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAuditor4K(sqlWhere: where, oCnn: oCnn);
        var auditor4k = new Auditor4KResponse
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
        auditor4k.Auditor = auditor;
        return auditor4k;
    }
}