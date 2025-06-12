#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParceriaProcWriter
{
    Entity.DBParceriaProc Write(Models.ParceriaProc parceriaproc, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ParceriaProcResponse parceriaproc, int operadorId, MsiSqlConnection oCnn);
}

public class ParceriaProc : IParceriaProcWriter
{
    public void Delete(ParceriaProcResponse parceriaproc, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ParceriaProc] WHERE parCodigo={parceriaproc.Id};", oCnn);
    }

    public Entity.DBParceriaProc Write(Models.ParceriaProc parceriaproc, int auditorQuem, MsiSqlConnection oCnn)
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