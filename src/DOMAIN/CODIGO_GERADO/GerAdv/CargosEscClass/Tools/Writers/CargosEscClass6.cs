#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscClassWriter
{
    Entity.DBCargosEscClass Write(Models.CargosEscClass cargosescclass, int auditorQuem, SqlConnection oCnn);
}

public class CargosEscClass : ICargosEscClassWriter
{
    public Entity.DBCargosEscClass Write(Models.CargosEscClass cargosescclass, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = cargosescclass.Id.IsEmptyIDNumber() ? new Entity.DBCargosEscClass() : new Entity.DBCargosEscClass(cargosescclass.Id, oCnn);
        dbRec.FNome = cargosescclass.Nome;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}