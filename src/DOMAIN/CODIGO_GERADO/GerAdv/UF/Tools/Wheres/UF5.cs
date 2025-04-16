#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUFWhere
{
    UFResponse Read(string where, SqlConnection oCnn);
}

public partial class UF : IUFWhere
{
    public UFResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUF(sqlWhere: where, oCnn: oCnn);
        var uf = new UFResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        uf.Auditor = auditor;
        return uf;
    }
}