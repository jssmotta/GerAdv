#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoProDespositoWriter
{
    Entity.DBTipoProDesposito Write(Models.TipoProDesposito tipoprodesposito, SqlConnection oCnn);
}

public class TipoProDesposito : ITipoProDespositoWriter
{
    public Entity.DBTipoProDesposito Write(Models.TipoProDesposito tipoprodesposito, SqlConnection oCnn)
    {
        var dbRec = tipoprodesposito.Id.IsEmptyIDNumber() ? new Entity.DBTipoProDesposito() : new Entity.DBTipoProDesposito(tipoprodesposito.Id, oCnn);
        dbRec.FNome = tipoprodesposito.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}