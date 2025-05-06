#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAuditor4KWriter
{
    Entity.DBAuditor4K Write(Models.Auditor4K auditor4k, int auditorQuem, SqlConnection oCnn);
}

public class Auditor4K : IAuditor4KWriter
{
    public Entity.DBAuditor4K Write(Models.Auditor4K auditor4k, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = auditor4k.Id.IsEmptyIDNumber() ? new Entity.DBAuditor4K() : new Entity.DBAuditor4K(auditor4k.Id, oCnn);
        dbRec.FNome = auditor4k.Nome;
        dbRec.FGUID = auditor4k.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}