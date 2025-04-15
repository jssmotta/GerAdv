#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUltimosProcessosWriter
{
    Entity.DBUltimosProcessos Write(Models.UltimosProcessos ultimosprocessos, SqlConnection oCnn);
}

public class UltimosProcessos : IUltimosProcessosWriter
{
    public Entity.DBUltimosProcessos Write(Models.UltimosProcessos ultimosprocessos, SqlConnection oCnn)
    {
        var dbRec = ultimosprocessos.Id.IsEmptyIDNumber() ? new Entity.DBUltimosProcessos() : new Entity.DBUltimosProcessos(ultimosprocessos.Id, oCnn);
        dbRec.FProcesso = ultimosprocessos.Processo;
        if (ultimosprocessos.Quando != null)
            dbRec.FQuando = ultimosprocessos.Quando.ToString();
        dbRec.FQuem = ultimosprocessos.Quem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}