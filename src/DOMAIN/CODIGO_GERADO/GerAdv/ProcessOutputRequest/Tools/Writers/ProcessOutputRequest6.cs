#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputRequestWriter
{
    Entity.DBProcessOutputRequest Write(Models.ProcessOutputRequest processoutputrequest, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ProcessOutputRequestResponse processoutputrequest, int operadorId, MsiSqlConnection oCnn);
}

public class ProcessOutputRequest : IProcessOutputRequestWriter
{
    public void Delete(ProcessOutputRequestResponse processoutputrequest, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProcessOutputRequest] WHERE porCodigo={processoutputrequest.Id};", oCnn);
    }

    public Entity.DBProcessOutputRequest Write(Models.ProcessOutputRequest processoutputrequest, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = processoutputrequest.Id.IsEmptyIDNumber() ? new Entity.DBProcessOutputRequest() : new Entity.DBProcessOutputRequest(processoutputrequest.Id, oCnn);
        dbRec.FProcessOutputEngine = processoutputrequest.ProcessOutputEngine;
        dbRec.FOperador = processoutputrequest.Operador;
        dbRec.FProcesso = processoutputrequest.Processo;
        dbRec.FUltimoIdTabelaExo = processoutputrequest.UltimoIdTabelaExo;
        dbRec.FGUID = processoutputrequest.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}