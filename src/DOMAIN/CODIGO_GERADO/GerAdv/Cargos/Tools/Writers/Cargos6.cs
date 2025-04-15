#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosWriter
{
    Entity.DBCargos Write(Models.Cargos cargos, int auditorQuem, SqlConnection oCnn);
}

public class Cargos : ICargosWriter
{
    public Entity.DBCargos Write(Models.Cargos cargos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = cargos.Id.IsEmptyIDNumber() ? new Entity.DBCargos() : new Entity.DBCargos(cargos.Id, oCnn);
        dbRec.FNome = cargos.Nome;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}