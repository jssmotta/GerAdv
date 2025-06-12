#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraStatusWriter
{
    Entity.DBPenhoraStatus Write(Models.PenhoraStatus penhorastatus, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(PenhoraStatusResponse penhorastatus, int operadorId, MsiSqlConnection oCnn);
}

public class PenhoraStatus : IPenhoraStatusWriter
{
    public void Delete(PenhoraStatusResponse penhorastatus, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[PenhoraStatus] WHERE phsCodigo={penhorastatus.Id};", oCnn);
    }

    public Entity.DBPenhoraStatus Write(Models.PenhoraStatus penhorastatus, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = penhorastatus.Id.IsEmptyIDNumber() ? new Entity.DBPenhoraStatus() : new Entity.DBPenhoraStatus(penhorastatus.Id, oCnn);
        dbRec.FNome = penhorastatus.Nome;
        dbRec.FGUID = penhorastatus.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}