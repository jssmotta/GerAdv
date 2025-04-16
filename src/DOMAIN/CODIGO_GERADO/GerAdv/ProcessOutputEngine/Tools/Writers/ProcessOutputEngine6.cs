#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputEngineWriter
{
    Entity.DBProcessOutputEngine Write(Models.ProcessOutputEngine processoutputengine, SqlConnection oCnn);
}

public class ProcessOutputEngine : IProcessOutputEngineWriter
{
    public Entity.DBProcessOutputEngine Write(Models.ProcessOutputEngine processoutputengine, SqlConnection oCnn)
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
        dbRec.Update(oCnn);
        return dbRec;
    }
}