#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRamalWriter
{
    Entity.DBRamal Write(Models.Ramal ramal, int auditorQuem, SqlConnection oCnn);
}

public class Ramal : IRamalWriter
{
    public Entity.DBRamal Write(Models.Ramal ramal, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = ramal.Id.IsEmptyIDNumber() ? new Entity.DBRamal() : new Entity.DBRamal(ramal.Id, oCnn);
        dbRec.FNome = ramal.Nome;
        dbRec.FObs = ramal.Obs;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}