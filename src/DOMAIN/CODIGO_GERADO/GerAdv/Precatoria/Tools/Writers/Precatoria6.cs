#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPrecatoriaWriter
{
    Entity.DBPrecatoria Write(Models.Precatoria precatoria, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(PrecatoriaResponse precatoria, int operadorId, MsiSqlConnection oCnn);
}

public class Precatoria : IPrecatoriaWriter
{
    public void Delete(PrecatoriaResponse precatoria, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Precatoria] WHERE preCodigo={precatoria.Id};", oCnn);
    }

    public Entity.DBPrecatoria Write(Models.Precatoria precatoria, int auditorQuem, MsiSqlConnection oCnn)
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