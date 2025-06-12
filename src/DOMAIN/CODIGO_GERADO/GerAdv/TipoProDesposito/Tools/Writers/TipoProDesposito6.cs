#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoProDespositoWriter
{
    Entity.DBTipoProDesposito Write(Models.TipoProDesposito tipoprodesposito, MsiSqlConnection oCnn);
    void Delete(TipoProDespositoResponse tipoprodesposito, int operadorId, MsiSqlConnection oCnn);
}

public class TipoProDesposito : ITipoProDespositoWriter
{
    public void Delete(TipoProDespositoResponse tipoprodesposito, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoProDesposito] WHERE tpdCodigo={tipoprodesposito.Id};", oCnn);
    }

    public Entity.DBTipoProDesposito Write(Models.TipoProDesposito tipoprodesposito, MsiSqlConnection oCnn)
    {
        var dbRec = tipoprodesposito.Id.IsEmptyIDNumber() ? new Entity.DBTipoProDesposito() : new Entity.DBTipoProDesposito(tipoprodesposito.Id, oCnn);
        dbRec.FNome = tipoprodesposito.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}