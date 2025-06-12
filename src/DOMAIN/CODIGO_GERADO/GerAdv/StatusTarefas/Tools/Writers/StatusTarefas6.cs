#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusTarefasWriter
{
    Entity.DBStatusTarefas Write(Models.StatusTarefas statustarefas, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(StatusTarefasResponse statustarefas, int operadorId, MsiSqlConnection oCnn);
}

public class StatusTarefas : IStatusTarefasWriter
{
    public void Delete(StatusTarefasResponse statustarefas, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[StatusTarefas] WHERE sttCodigo={statustarefas.Id};", oCnn);
    }

    public Entity.DBStatusTarefas Write(Models.StatusTarefas statustarefas, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = statustarefas.Id.IsEmptyIDNumber() ? new Entity.DBStatusTarefas() : new Entity.DBStatusTarefas(statustarefas.Id, oCnn);
        dbRec.FNome = statustarefas.Nome;
        dbRec.FGUID = statustarefas.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}