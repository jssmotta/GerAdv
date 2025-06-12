#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputSourcesWriter
{
    Entity.DBProcessOutputSources Write(Models.ProcessOutputSources processoutputsources, MsiSqlConnection oCnn);
    void Delete(ProcessOutputSourcesResponse processoutputsources, int operadorId, MsiSqlConnection oCnn);
}

public class ProcessOutputSources : IProcessOutputSourcesWriter
{
    public void Delete(ProcessOutputSourcesResponse processoutputsources, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProcessOutputSources] WHERE posCodigo={processoutputsources.Id};", oCnn);
    }

    public Entity.DBProcessOutputSources Write(Models.ProcessOutputSources processoutputsources, MsiSqlConnection oCnn)
    {
        var dbRec = processoutputsources.Id.IsEmptyIDNumber() ? new Entity.DBProcessOutputSources() : new Entity.DBProcessOutputSources(processoutputsources.Id, oCnn);
        dbRec.FNome = processoutputsources.Nome;
        dbRec.FGUID = processoutputsources.GUID;
        dbRec.Update(oCnn);
        return dbRec;
    }
}