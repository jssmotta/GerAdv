#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGrupoWriter
{
    Entity.DBOperadorGrupo Write(Models.OperadorGrupo operadorgrupo, int auditorQuem, SqlConnection oCnn);
}

public class OperadorGrupo : IOperadorGrupoWriter
{
    public Entity.DBOperadorGrupo Write(Models.OperadorGrupo operadorgrupo, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = operadorgrupo.Id.IsEmptyIDNumber() ? new Entity.DBOperadorGrupo() : new Entity.DBOperadorGrupo(operadorgrupo.Id, oCnn);
        dbRec.FOperador = operadorgrupo.Operador;
        dbRec.FGrupo = operadorgrupo.Grupo;
        dbRec.FInativo = operadorgrupo.Inativo;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}