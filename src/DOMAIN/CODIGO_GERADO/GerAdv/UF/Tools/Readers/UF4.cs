#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUFReader
{
    UFResponse? Read(int id, SqlConnection oCnn);
    UFResponse? Read(string where, SqlConnection oCnn);
    UFResponse? Read(Entity.DBUF dbRec);
    UFResponse? Read(DBUF dbRec);
}

public partial class UF : IUFReader
{
    public UFResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUF(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UFResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUF(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UFResponse? Read(Entity.DBUF dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var uf = new UFResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        uf.Auditor = auditor;
        return uf;
    }

    public UFResponse? Read(DBUF dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var uf = new UFResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        uf.Auditor = auditor;
        return uf;
    }
}