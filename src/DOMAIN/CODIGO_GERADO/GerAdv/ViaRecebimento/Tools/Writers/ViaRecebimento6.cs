#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IViaRecebimentoWriter
{
    Entity.DBViaRecebimento Write(Models.ViaRecebimento viarecebimento, MsiSqlConnection oCnn);
    void Delete(ViaRecebimentoResponse viarecebimento, int operadorId, MsiSqlConnection oCnn);
}

public class ViaRecebimento : IViaRecebimentoWriter
{
    public void Delete(ViaRecebimentoResponse viarecebimento, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ViaRecebimento] WHERE vrbCodigo={viarecebimento.Id};", oCnn);
    }

    public Entity.DBViaRecebimento Write(Models.ViaRecebimento viarecebimento, MsiSqlConnection oCnn)
    {
        var dbRec = viarecebimento.Id.IsEmptyIDNumber() ? new Entity.DBViaRecebimento() : new Entity.DBViaRecebimento(viarecebimento.Id, oCnn);
        dbRec.FNome = viarecebimento.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}