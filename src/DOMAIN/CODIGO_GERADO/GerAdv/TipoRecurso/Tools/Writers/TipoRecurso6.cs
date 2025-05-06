#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoRecursoWriter
{
    Entity.DBTipoRecurso Write(Models.TipoRecurso tiporecurso, int auditorQuem, SqlConnection oCnn);
}

public class TipoRecurso : ITipoRecursoWriter
{
    public Entity.DBTipoRecurso Write(Models.TipoRecurso tiporecurso, int auditorQuem, SqlConnection oCnn)
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