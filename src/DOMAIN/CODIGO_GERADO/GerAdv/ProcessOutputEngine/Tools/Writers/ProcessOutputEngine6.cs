#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputEngineWriter
{
    Entity.DBProcessOutputEngine Write(Models.ProcessOutputEngine processoutputengine, MsiSqlConnection oCnn);
    void Delete(ProcessOutputEngineResponse processoutputengine, int operadorId, MsiSqlConnection oCnn);
}

public class ProcessOutputEngine : IProcessOutputEngineWriter
{
    public void Delete(ProcessOutputEngineResponse processoutputengine, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProcessOutputEngine] WHERE poeCodigo={processoutputengine.Id};", oCnn);
    }

    public Entity.DBProcessOutputEngine Write(Models.ProcessOutputEngine processoutputengine, MsiSqlConnection oCnn)
    {
        var dbRec = processoutputengine.Id.IsEmptyIDNumber() ? new Entity.DBProcessOutputEngine() : new Entity.DBProcessOutputEngine(processoutputengine.Id, oCnn);
        dbRec.FNome = processoutputengine.Nome;
        dbRec.FDatabase = processoutputengine.Database;
        dbRec.FTabela = processoutputengine.Tabela;
        dbRec.FCampo = processoutputengine.Campo;
        dbRec.FValor = processoutputengine.Valor;
        dbRec.FOutput = processoutputengine.Output;
        dbRec.FAdministrador = processoutputengine.Administrador;
        dbRec.FOutputSource = processoutputengine.OutputSource;
        dbRec.FDisabledItem = processoutputengine.DisabledItem;
        dbRec.FIDModulo = processoutputengine.IDModulo;
        dbRec.FIsOnlyProcesso = processoutputengine.IsOnlyProcesso;
        dbRec.FMyID = processoutputengine.MyID;
        dbRec.FGUID = processoutputengine.GUID;
        dbRec.Update(oCnn);
        return dbRec;
    }
}