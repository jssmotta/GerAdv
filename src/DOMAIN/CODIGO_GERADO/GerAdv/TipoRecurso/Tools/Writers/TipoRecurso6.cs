#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoRecursoWriter
{
    Entity.DBTipoRecurso Write(Models.TipoRecurso tiporecurso, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(TipoRecursoResponse tiporecurso, int operadorId, MsiSqlConnection oCnn);
}

public class TipoRecurso : ITipoRecursoWriter
{
    public void Delete(TipoRecursoResponse tiporecurso, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoRecurso] WHERE trcCodigo={tiporecurso.Id};", oCnn);
    }

    public Entity.DBTipoRecurso Write(Models.TipoRecurso tiporecurso, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = tiporecurso.Id.IsEmptyIDNumber() ? new Entity.DBTipoRecurso() : new Entity.DBTipoRecurso(tiporecurso.Id, oCnn);
        dbRec.FJustica = tiporecurso.Justica;
        dbRec.FArea = tiporecurso.Area;
        dbRec.FDescricao = tiporecurso.Descricao;
        dbRec.FGUID = tiporecurso.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}