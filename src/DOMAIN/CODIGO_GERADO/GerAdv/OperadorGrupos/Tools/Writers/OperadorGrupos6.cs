#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposWriter
{
    Entity.DBOperadorGrupos Write(Models.OperadorGrupos operadorgrupos, int auditorQuem, SqlConnection oCnn);
}

public class OperadorGrupos : IOperadorGruposWriter
{
    public Entity.DBOperadorGrupos Write(Models.OperadorGrupos operadorgrupos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = operadorgrupos.Id.IsEmptyIDNumber() ? new Entity.DBOperadorGrupos() : new Entity.DBOperadorGrupos(operadorgrupos.Id, oCnn);
        dbRec.FNome = operadorgrupos.Nome;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}