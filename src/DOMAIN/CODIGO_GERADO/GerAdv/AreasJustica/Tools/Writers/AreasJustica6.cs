#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreasJusticaWriter
{
    Entity.DBAreasJustica Write(Models.AreasJustica areasjustica, SqlConnection oCnn);
}

public class AreasJustica : IAreasJusticaWriter
{
    public Entity.DBAreasJustica Write(Models.AreasJustica areasjustica, SqlConnection oCnn)
    {
        var dbRec = areasjustica.Id.IsEmptyIDNumber() ? new Entity.DBAreasJustica() : new Entity.DBAreasJustica(areasjustica.Id, oCnn);
        dbRec.FArea = areasjustica.Area;
        dbRec.FJustica = areasjustica.Justica;
        dbRec.Update(oCnn);
        return dbRec;
    }
}