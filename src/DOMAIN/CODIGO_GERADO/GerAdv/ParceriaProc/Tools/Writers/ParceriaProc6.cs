#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParceriaProcWriter
{
    Entity.DBParceriaProc Write(Models.ParceriaProc parceriaproc, int auditorQuem, SqlConnection oCnn);
}

public class ParceriaProc : IParceriaProcWriter
{
    public Entity.DBParceriaProc Write(Models.ParceriaProc parceriaproc, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = parceriaproc.Id.IsEmptyIDNumber() ? new Entity.DBParceriaProc() : new Entity.DBParceriaProc(parceriaproc.Id, oCnn);
        dbRec.FAdvogado = parceriaproc.Advogado;
        dbRec.FProcesso = parceriaproc.Processo;
        dbRec.FGUID = parceriaproc.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}