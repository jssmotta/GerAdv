#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeStatusWriter
{
    Entity.DBGUTPeriodicidadeStatus Write(Models.GUTPeriodicidadeStatus gutperiodicidadestatus, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(GUTPeriodicidadeStatusResponse gutperiodicidadestatus, int operadorId, MsiSqlConnection oCnn);
}

public class GUTPeriodicidadeStatus : IGUTPeriodicidadeStatusWriter
{
    public void Delete(GUTPeriodicidadeStatusResponse gutperiodicidadestatus, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[GUTPeriodicidadeStatus] WHERE pgsCodigo={gutperiodicidadestatus.Id};", oCnn);
    }

    public Entity.DBGUTPeriodicidadeStatus Write(Models.GUTPeriodicidadeStatus gutperiodicidadestatus, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = gutperiodicidadestatus.Id.IsEmptyIDNumber() ? new Entity.DBGUTPeriodicidadeStatus() : new Entity.DBGUTPeriodicidadeStatus(gutperiodicidadestatus.Id, oCnn);
        dbRec.FGUTAtividade = gutperiodicidadestatus.GUTAtividade;
        if (gutperiodicidadestatus.DataRealizado != null)
            dbRec.FDataRealizado = gutperiodicidadestatus.DataRealizado.ToString();
        dbRec.FGUID = gutperiodicidadestatus.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}