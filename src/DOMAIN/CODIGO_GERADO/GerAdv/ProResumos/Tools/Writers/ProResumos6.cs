#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProResumosWriter
{
    Entity.DBProResumos Write(Models.ProResumos proresumos, int auditorQuem, SqlConnection oCnn);
}

public class ProResumos : IProResumosWriter
{
    public Entity.DBProResumos Write(Models.ProResumos proresumos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = proresumos.Id.IsEmptyIDNumber() ? new Entity.DBProResumos() : new Entity.DBProResumos(proresumos.Id, oCnn);
        dbRec.FProcesso = proresumos.Processo;
        if (proresumos.Data != null)
            dbRec.FData = proresumos.Data.ToString();
        dbRec.FResumo = proresumos.Resumo;
        dbRec.FTipoResumo = proresumos.TipoResumo;
        dbRec.FBold = proresumos.Bold;
        dbRec.FGUID = proresumos.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}