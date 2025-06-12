#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusHTrabWriter
{
    Entity.DBStatusHTrab Write(Models.StatusHTrab statushtrab, MsiSqlConnection oCnn);
    void Delete(StatusHTrabResponse statushtrab, int operadorId, MsiSqlConnection oCnn);
}

public class StatusHTrab : IStatusHTrabWriter
{
    public void Delete(StatusHTrabResponse statushtrab, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[StatusHTrab] WHERE shtCodigo={statushtrab.Id};", oCnn);
    }

    public Entity.DBStatusHTrab Write(Models.StatusHTrab statushtrab, MsiSqlConnection oCnn)
    {
        var dbRec = statushtrab.Id.IsEmptyIDNumber() ? new Entity.DBStatusHTrab() : new Entity.DBStatusHTrab(statushtrab.Id, oCnn);
        dbRec.FDescricao = statushtrab.Descricao;
        dbRec.FResID = statushtrab.ResID;
        dbRec.Update(oCnn);
        return dbRec;
    }
}