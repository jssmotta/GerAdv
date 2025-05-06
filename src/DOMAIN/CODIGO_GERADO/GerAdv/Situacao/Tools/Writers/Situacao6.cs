#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISituacaoWriter
{
    Entity.DBSituacao Write(Models.Situacao situacao, int auditorQuem, SqlConnection oCnn);
}

public class Situacao : ISituacaoWriter
{
    public Entity.DBSituacao Write(Models.Situacao situacao, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = situacao.Id.IsEmptyIDNumber() ? new Entity.DBSituacao() : new Entity.DBSituacao(situacao.Id, oCnn);
        dbRec.FParte_Int = situacao.Parte_Int;
        dbRec.FParte_Opo = situacao.Parte_Opo;
        dbRec.FTop = situacao.Top;
        dbRec.FBold = situacao.Bold;
        dbRec.FGUID = situacao.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}