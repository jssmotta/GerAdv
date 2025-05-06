#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTTipoWriter
{
    Entity.DBGUTTipo Write(Models.GUTTipo guttipo, int auditorQuem, SqlConnection oCnn);
}

public class GUTTipo : IGUTTipoWriter
{
    public Entity.DBGUTTipo Write(Models.GUTTipo guttipo, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = guttipo.Id.IsEmptyIDNumber() ? new Entity.DBGUTTipo() : new Entity.DBGUTTipo(guttipo.Id, oCnn);
        dbRec.FNome = guttipo.Nome;
        dbRec.FOrdem = guttipo.Ordem;
        dbRec.FGUID = guttipo.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}