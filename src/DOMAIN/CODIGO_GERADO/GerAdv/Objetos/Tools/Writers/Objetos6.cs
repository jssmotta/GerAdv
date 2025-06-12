#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IObjetosWriter
{
    Entity.DBObjetos Write(Models.Objetos objetos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ObjetosResponse objetos, int operadorId, MsiSqlConnection oCnn);
}

public class Objetos : IObjetosWriter
{
    public void Delete(ObjetosResponse objetos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Objetos] WHERE ojtCodigo={objetos.Id};", oCnn);
    }

    public Entity.DBObjetos Write(Models.Objetos objetos, int auditorQuem, MsiSqlConnection oCnn)
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