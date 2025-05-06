#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutPutIDsReader
{
    ProcessOutPutIDsResponse? Read(int id, SqlConnection oCnn);
    ProcessOutPutIDsResponse? Read(string where, SqlConnection oCnn);
    ProcessOutPutIDsResponse? Read(Entity.DBProcessOutPutIDs dbRec);
    ProcessOutPutIDsResponse? Read(DBProcessOutPutIDs dbRec);
}

public partial class ProcessOutPutIDs : IProcessOutPutIDsReader
{
    public ProcessOutPutIDsResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutPutIDs(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutPutIDsResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutPutIDs(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutPutIDsResponse? Read(Entity.DBProcessOutPutIDs dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputids = new ProcessOutPutIDsResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputids;
    }

    public ProcessOutPutIDsResponse? Read(DBProcessOutPutIDs dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputids = new ProcessOutPutIDsResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputids;
    }
}