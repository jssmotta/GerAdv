#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IObjetosWriter
{
    Entity.DBObjetos Write(Models.Objetos objetos, int auditorQuem, SqlConnection oCnn);
}

public class Objetos : IObjetosWriter
{
    public Entity.DBObjetos Write(Models.Objetos objetos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = objetos.Id.IsEmptyIDNumber() ? new Entity.DBObjetos() : new Entity.DBObjetos(objetos.Id, oCnn);
        dbRec.FJustica = objetos.Justica;
        dbRec.FArea = objetos.Area;
        dbRec.FNome = objetos.Nome;
        dbRec.FBold = objetos.Bold;
        dbRec.FGUID = objetos.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}