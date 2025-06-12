#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeWriter
{
    Entity.DBGUTPeriodicidade Write(Models.GUTPeriodicidade gutperiodicidade, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(GUTPeriodicidadeResponse gutperiodicidade, int operadorId, MsiSqlConnection oCnn);
}

public class GUTPeriodicidade : IGUTPeriodicidadeWriter
{
    public void Delete(GUTPeriodicidadeResponse gutperiodicidade, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[GUTPeriodicidade] WHERE pcgCodigo={gutperiodicidade.Id};", oCnn);
    }

    public Entity.DBGUTPeriodicidade Write(Models.GUTPeriodicidade gutperiodicidade, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = gutperiodicidade.Id.IsEmptyIDNumber() ? new Entity.DBGUTPeriodicidade() : new Entity.DBGUTPeriodicidade(gutperiodicidade.Id, oCnn);
        dbRec.FNome = gutperiodicidade.Nome;
        dbRec.FIntervaloDias = gutperiodicidade.IntervaloDias;
        dbRec.FGUID = gutperiodicidade.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}