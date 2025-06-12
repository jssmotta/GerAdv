#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndamentosMDWriter
{
    Entity.DBAndamentosMD Write(Models.AndamentosMD andamentosmd, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(AndamentosMDResponse andamentosmd, int operadorId, MsiSqlConnection oCnn);
}

public class AndamentosMD : IAndamentosMDWriter
{
    public void Delete(AndamentosMDResponse andamentosmd, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[AndamentosMD] WHERE amdCodigo={andamentosmd.Id};", oCnn);
    }

    public Entity.DBAndamentosMD Write(Models.AndamentosMD andamentosmd, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = andamentosmd.Id.IsEmptyIDNumber() ? new Entity.DBAndamentosMD() : new Entity.DBAndamentosMD(andamentosmd.Id, oCnn);
        dbRec.FNome = andamentosmd.Nome;
        dbRec.FProcesso = andamentosmd.Processo;
        dbRec.FAndamento = andamentosmd.Andamento;
        dbRec.FPathFull = andamentosmd.PathFull;
        dbRec.FUNC = andamentosmd.UNC;
        dbRec.FGUID = andamentosmd.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}