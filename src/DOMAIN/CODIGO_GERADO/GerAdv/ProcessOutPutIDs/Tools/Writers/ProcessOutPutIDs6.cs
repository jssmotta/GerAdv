#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutPutIDsWriter
{
    Entity.DBProcessOutPutIDs Write(Models.ProcessOutPutIDs processoutputids, SqlConnection oCnn);
}

public class ProcessOutPutIDs : IProcessOutPutIDsWriter
{
    public Entity.DBProcessOutPutIDs Write(Models.ProcessOutPutIDs processoutputids, SqlConnection oCnn)
    {
        var dbRec = processoutputids.Id.IsEmptyIDNumber() ? new Entity.DBProcessOutPutIDs() : new Entity.DBProcessOutPutIDs(processoutputids.Id, oCnn);
        dbRec.FNome = processoutputids.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}