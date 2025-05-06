#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputSourcesWhere
{
    ProcessOutputSourcesResponse Read(string where, SqlConnection oCnn);
}

public partial class ProcessOutputSources : IProcessOutputSourcesWhere
{
    public ProcessOutputSourcesResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputSources(sqlWhere: where, oCnn: oCnn);
        var processoutputsources = new ProcessOutputSourcesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputsources;
    }
}