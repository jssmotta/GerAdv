#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPrecatoriaWriter
{
    Entity.DBPrecatoria Write(Models.Precatoria precatoria, int auditorQuem, SqlConnection oCnn);
}

public class Precatoria : IPrecatoriaWriter
{
    public Entity.DBPrecatoria Write(Models.Precatoria precatoria, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = precatoria.Id.IsEmptyIDNumber() ? new Entity.DBPrecatoria() : new Entity.DBPrecatoria(precatoria.Id, oCnn);
        if (precatoria.DtDist != null)
            dbRec.FDtDist = precatoria.DtDist.ToString();
        dbRec.FProcesso = precatoria.Processo;
        dbRec.FPrecatoria = precatoria.PrecatoriaX;
        dbRec.FDeprecante = precatoria.Deprecante;
        dbRec.FDeprecado = precatoria.Deprecado;
        dbRec.FOBS = precatoria.OBS;
        dbRec.FBold = precatoria.Bold;
        dbRec.FGUID = precatoria.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}