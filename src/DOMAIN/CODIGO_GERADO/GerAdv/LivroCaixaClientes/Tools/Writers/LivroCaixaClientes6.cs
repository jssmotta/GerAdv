#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaClientesWriter
{
    Entity.DBLivroCaixaClientes Write(Models.LivroCaixaClientes livrocaixaclientes, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(LivroCaixaClientesResponse livrocaixaclientes, int operadorId, MsiSqlConnection oCnn);
}

public class LivroCaixaClientes : ILivroCaixaClientesWriter
{
    public void Delete(LivroCaixaClientesResponse livrocaixaclientes, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[LivroCaixaClientes] WHERE lccCodigo={livrocaixaclientes.Id};", oCnn);
    }

    public Entity.DBLivroCaixaClientes Write(Models.LivroCaixaClientes livrocaixaclientes, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = livrocaixaclientes.Id.IsEmptyIDNumber() ? new Entity.DBLivroCaixaClientes() : new Entity.DBLivroCaixaClientes(livrocaixaclientes.Id, oCnn);
        dbRec.FLivroCaixa = livrocaixaclientes.LivroCaixa;
        dbRec.FCliente = livrocaixaclientes.Cliente;
        dbRec.FLancado = livrocaixaclientes.Lancado;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}