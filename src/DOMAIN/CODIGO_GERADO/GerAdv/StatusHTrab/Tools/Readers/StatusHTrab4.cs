#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusHTrabReader
{
    StatusHTrabResponse? Read(int id, SqlConnection oCnn);
    StatusHTrabResponse? Read(string where, SqlConnection oCnn);
    StatusHTrabResponse? Read(Entity.DBStatusHTrab dbRec);
    StatusHTrabResponse? Read(DBStatusHTrab dbRec);
}

public partial class StatusHTrab : IStatusHTrabReader
{
    public StatusHTrabResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusHTrab(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusHTrabResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusHTrab(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusHTrabResponse? Read(Entity.DBStatusHTrab dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statushtrab = new StatusHTrabResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            ResID = dbRec.FResID,
        };
        return statushtrab;
    }

    public StatusHTrabResponse? Read(DBStatusHTrab dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statushtrab = new StatusHTrabResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            ResID = dbRec.FResID,
        };
        return statushtrab;
    }
}