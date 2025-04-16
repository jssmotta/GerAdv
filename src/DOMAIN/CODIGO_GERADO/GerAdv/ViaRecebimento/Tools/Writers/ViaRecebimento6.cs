#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IViaRecebimentoWriter
{
    Entity.DBViaRecebimento Write(Models.ViaRecebimento viarecebimento, SqlConnection oCnn);
}

public class ViaRecebimento : IViaRecebimentoWriter
{
    public Entity.DBViaRecebimento Write(Models.ViaRecebimento viarecebimento, SqlConnection oCnn)
    {
        var dbRec = viarecebimento.Id.IsEmptyIDNumber() ? new Entity.DBViaRecebimento() : new Entity.DBViaRecebimento(viarecebimento.Id, oCnn);
        dbRec.FNome = viarecebimento.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}