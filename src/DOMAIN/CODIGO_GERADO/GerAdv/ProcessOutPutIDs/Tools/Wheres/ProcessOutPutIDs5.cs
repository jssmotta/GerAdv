#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutPutIDsWhere
{
    ProcessOutPutIDsResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class ProcessOutPutIDs : IProcessOutPutIDsWhere
{
    public ProcessOutPutIDsResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutPutIDs(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var processoutputids = new ProcessOutPutIDsResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputids;
    }
}