#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeStatusWriter
{
    Entity.DBGUTPeriodicidadeStatus Write(Models.GUTPeriodicidadeStatus gutperiodicidadestatus, int auditorQuem, SqlConnection oCnn);
}

public class GUTPeriodicidadeStatus : IGUTPeriodicidadeStatusWriter
{
    public Entity.DBGUTPeriodicidadeStatus Write(Models.GUTPeriodicidadeStatus gutperiodicidadestatus, int auditorQuem, SqlConnection oCnn)
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