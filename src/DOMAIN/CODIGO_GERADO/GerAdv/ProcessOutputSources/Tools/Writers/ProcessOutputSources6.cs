#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputSourcesWriter
{
    Entity.DBProcessOutputSources Write(Models.ProcessOutputSources processoutputsources, SqlConnection oCnn);
}

public class ProcessOutputSources : IProcessOutputSourcesWriter
{
    public Entity.DBProcessOutputSources Write(Models.ProcessOutputSources processoutputsources, SqlConnection oCnn)
    {
        var dbRec = processoutputsources.Id.IsEmptyIDNumber() ? new Entity.DBProcessOutputSources() : new Entity.DBProcessOutputSources(processoutputsources.Id, oCnn);
        dbRec.FNome = processoutputsources.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}