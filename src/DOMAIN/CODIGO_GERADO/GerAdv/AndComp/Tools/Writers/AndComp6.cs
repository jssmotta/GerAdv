#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndCompWriter
{
    Entity.DBAndComp Write(Models.AndComp andcomp, SqlConnection oCnn);
}

public class AndComp : IAndCompWriter
{
    public Entity.DBAndComp Write(Models.AndComp andcomp, SqlConnection oCnn)
    {
        var dbRec = andcomp.Id.IsEmptyIDNumber() ? new Entity.DBAndComp() : new Entity.DBAndComp(andcomp.Id, oCnn);
        dbRec.FAndamento = andcomp.Andamento;
        dbRec.FCompromisso = andcomp.Compromisso;
        dbRec.Update(oCnn);
        return dbRec;
    }
}