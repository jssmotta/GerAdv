#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutPutIDsWriter
{
    Entity.DBProcessOutPutIDs Write(Models.ProcessOutPutIDs processoutputids, MsiSqlConnection oCnn);
    void Delete(ProcessOutPutIDsResponse processoutputids, int operadorId, MsiSqlConnection oCnn);
}

public class ProcessOutPutIDs : IProcessOutPutIDsWriter
{
    public void Delete(ProcessOutPutIDsResponse processoutputids, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProcessOutPutIDs] WHERE poiCodigo={processoutputids.Id};", oCnn);
    }

    public Entity.DBProcessOutPutIDs Write(Models.ProcessOutPutIDs processoutputids, MsiSqlConnection oCnn)
    {
        var dbRec = processoutputids.Id.IsEmptyIDNumber() ? new Entity.DBProcessOutPutIDs() : new Entity.DBProcessOutPutIDs(processoutputids.Id, oCnn);
        dbRec.FNome = processoutputids.Nome;
        dbRec.FGUID = processoutputids.GUID;
        dbRec.Update(oCnn);
        return dbRec;
    }
}