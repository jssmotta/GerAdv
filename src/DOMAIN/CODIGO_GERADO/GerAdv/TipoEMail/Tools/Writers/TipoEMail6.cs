#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEMailWriter
{
    Entity.DBTipoEMail Write(Models.TipoEMail tipoemail, MsiSqlConnection oCnn);
    void Delete(TipoEMailResponse tipoemail, int operadorId, MsiSqlConnection oCnn);
}

public class TipoEMail : ITipoEMailWriter
{
    public void Delete(TipoEMailResponse tipoemail, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoEMail] WHERE tmlCodigo={tipoemail.Id};", oCnn);
    }

    public Entity.DBTipoEMail Write(Models.TipoEMail tipoemail, MsiSqlConnection oCnn)
    {
        var dbRec = tipoemail.Id.IsEmptyIDNumber() ? new Entity.DBTipoEMail() : new Entity.DBTipoEMail(tipoemail.Id, oCnn);
        dbRec.FNome = tipoemail.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}