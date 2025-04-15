#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreasJusticaReader
{
    AreasJusticaResponse? Read(int id, SqlConnection oCnn);
    AreasJusticaResponse? Read(string where, SqlConnection oCnn);
    AreasJusticaResponse? Read(Entity.DBAreasJustica dbRec);
    AreasJusticaResponse? Read(DBAreasJustica dbRec);
}

public partial class AreasJustica : IAreasJusticaReader
{
    public AreasJusticaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAreasJustica(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreasJusticaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAreasJustica(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreasJusticaResponse? Read(Entity.DBAreasJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var areasjustica = new AreasJusticaResponse
        {
            Id = dbRec.ID,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
        };
        return areasjustica;
    }

    public AreasJusticaResponse? Read(DBAreasJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var areasjustica = new AreasJusticaResponse
        {
            Id = dbRec.ID,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
        };
        return areasjustica;
    }
}