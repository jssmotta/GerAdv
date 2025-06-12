#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProResumosWriter
{
    Entity.DBProResumos Write(Models.ProResumos proresumos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ProResumosResponse proresumos, int operadorId, MsiSqlConnection oCnn);
}

public class ProResumos : IProResumosWriter
{
    public void Delete(ProResumosResponse proresumos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProResumos] WHERE prsCodigo={proresumos.Id};", oCnn);
    }

    public Entity.DBProResumos Write(Models.ProResumos proresumos, int auditorQuem, MsiSqlConnection oCnn)
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