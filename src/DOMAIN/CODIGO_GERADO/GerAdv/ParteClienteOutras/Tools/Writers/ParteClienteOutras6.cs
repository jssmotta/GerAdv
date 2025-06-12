#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParteClienteOutrasWriter
{
    Entity.DBParteClienteOutras Write(Models.ParteClienteOutras parteclienteoutras, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ParteClienteOutrasResponse parteclienteoutras, int operadorId, MsiSqlConnection oCnn);
}

public class ParteClienteOutras : IParteClienteOutrasWriter
{
    public void Delete(ParteClienteOutrasResponse parteclienteoutras, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ParteClienteOutras] WHERE pcoCodigo={parteclienteoutras.Id};", oCnn);
    }

    public Entity.DBParteClienteOutras Write(Models.ParteClienteOutras parteclienteoutras, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = parteclienteoutras.Id.IsEmptyIDNumber() ? new Entity.DBParteClienteOutras() : new Entity.DBParteClienteOutras(parteclienteoutras.Id, oCnn);
        dbRec.FCliente = parteclienteoutras.Cliente;
        dbRec.FProcesso = parteclienteoutras.Processo;
        dbRec.FPrimeiraReclamada = parteclienteoutras.PrimeiraReclamada;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}