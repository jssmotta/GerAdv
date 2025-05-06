#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreaWriter
{
    Entity.DBArea Write(Models.Area area, int auditorQuem, SqlConnection oCnn);
}

public class Area : IAreaWriter
{
    public Entity.DBArea Write(Models.Area area, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = area.Id.IsEmptyIDNumber() ? new Entity.DBArea() : new Entity.DBArea(area.Id, oCnn);
        dbRec.FDescricao = area.Descricao;
        dbRec.FTop = area.Top;
        dbRec.FGUID = area.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}