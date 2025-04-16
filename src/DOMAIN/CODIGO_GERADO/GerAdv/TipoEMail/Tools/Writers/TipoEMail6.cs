#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEMailWriter
{
    Entity.DBTipoEMail Write(Models.TipoEMail tipoemail, SqlConnection oCnn);
}

public class TipoEMail : ITipoEMailWriter
{
    public Entity.DBTipoEMail Write(Models.TipoEMail tipoemail, SqlConnection oCnn)
    {
        var dbRec = tipoemail.Id.IsEmptyIDNumber() ? new Entity.DBTipoEMail() : new Entity.DBTipoEMail(tipoemail.Id, oCnn);
        dbRec.FNome = tipoemail.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}