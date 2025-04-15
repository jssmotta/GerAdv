#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndamentosMDWriter
{
    Entity.DBAndamentosMD Write(Models.AndamentosMD andamentosmd, int auditorQuem, SqlConnection oCnn);
}

public class AndamentosMD : IAndamentosMDWriter
{
    public Entity.DBAndamentosMD Write(Models.AndamentosMD andamentosmd, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = andamentosmd.Id.IsEmptyIDNumber() ? new Entity.DBAndamentosMD() : new Entity.DBAndamentosMD(andamentosmd.Id, oCnn);
        dbRec.FNome = andamentosmd.Nome;
        dbRec.FProcesso = andamentosmd.Processo;
        dbRec.FAndamento = andamentosmd.Andamento;
        dbRec.FPathFull = andamentosmd.PathFull;
        dbRec.FUNC = andamentosmd.UNC;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}