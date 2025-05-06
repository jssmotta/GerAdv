#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutPutIDsWhere
{
    ProcessOutPutIDsResponse Read(string where, SqlConnection oCnn);
}

public partial class ProcessOutPutIDs : IProcessOutPutIDsWhere
{
    public ProcessOutPutIDsResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutPutIDs(sqlWhere: where, oCnn: oCnn);
        var processoutputids = new ProcessOutPutIDsResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputids;
    }
}