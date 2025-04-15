#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRitoReader
{
    RitoResponse? Read(int id, SqlConnection oCnn);
    RitoResponse? Read(string where, SqlConnection oCnn);
    RitoResponse? Read(Entity.DBRito dbRec);
    RitoResponse? Read(DBRito dbRec);
}

public partial class Rito : IRitoReader
{
    public RitoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRito(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RitoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRito(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RitoResponse? Read(Entity.DBRito dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var rito = new RitoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
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
        rito.Auditor = auditor;
        return rito;
    }

    public RitoResponse? Read(DBRito dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var rito = new RitoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
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
        rito.Auditor = auditor;
        return rito;
    }
}