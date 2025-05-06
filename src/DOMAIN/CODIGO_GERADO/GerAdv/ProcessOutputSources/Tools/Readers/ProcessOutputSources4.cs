#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputSourcesReader
{
    ProcessOutputSourcesResponse? Read(int id, SqlConnection oCnn);
    ProcessOutputSourcesResponse? Read(string where, SqlConnection oCnn);
    ProcessOutputSourcesResponse? Read(Entity.DBProcessOutputSources dbRec);
    ProcessOutputSourcesResponse? Read(DBProcessOutputSources dbRec);
}

public partial class ProcessOutputSources : IProcessOutputSourcesReader
{
    public ProcessOutputSourcesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputSources(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputSourcesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputSources(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputSourcesResponse? Read(Entity.DBProcessOutputSources dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputsources = new ProcessOutputSourcesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputsources;
    }

    public ProcessOutputSourcesResponse? Read(DBProcessOutputSources dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputsources = new ProcessOutputSourcesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputsources;
    }
}