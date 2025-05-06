#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusAndamentoWriter
{
    Entity.DBStatusAndamento Write(Models.StatusAndamento statusandamento, int auditorQuem, SqlConnection oCnn);
}

public class StatusAndamento : IStatusAndamentoWriter
{
    public Entity.DBStatusAndamento Write(Models.StatusAndamento statusandamento, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = statusandamento.Id.IsEmptyIDNumber() ? new Entity.DBStatusAndamento() : new Entity.DBStatusAndamento(statusandamento.Id, oCnn);
        dbRec.FNome = statusandamento.Nome;
        dbRec.FIcone = statusandamento.Icone;
        dbRec.FBold = statusandamento.Bold;
        dbRec.FGUID = statusandamento.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}