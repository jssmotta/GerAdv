#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusInstanciaWriter
{
    Entity.DBStatusInstancia Write(Models.StatusInstancia statusinstancia, int auditorQuem, SqlConnection oCnn);
}

public class StatusInstancia : IStatusInstanciaWriter
{
    public Entity.DBStatusInstancia Write(Models.StatusInstancia statusinstancia, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = statusinstancia.Id.IsEmptyIDNumber() ? new Entity.DBStatusInstancia() : new Entity.DBStatusInstancia(statusinstancia.Id, oCnn);
        dbRec.FNome = statusinstancia.Nome;
        dbRec.FBold = statusinstancia.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}