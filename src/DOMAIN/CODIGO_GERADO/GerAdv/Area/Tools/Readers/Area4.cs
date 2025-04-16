#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreaReader
{
    AreaResponse? Read(int id, SqlConnection oCnn);
    AreaResponse? Read(string where, SqlConnection oCnn);
    AreaResponse? Read(Entity.DBArea dbRec);
    AreaResponse? Read(DBArea dbRec);
}

public partial class Area : IAreaReader
{
    public AreaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBArea(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBArea(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreaResponse? Read(Entity.DBArea dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var area = new AreaResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Top = dbRec.FTop,
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
        area.Auditor = auditor;
        return area;
    }

    public AreaResponse? Read(DBArea dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var area = new AreaResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Top = dbRec.FTop,
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
        area.Auditor = auditor;
        return area;
    }
}