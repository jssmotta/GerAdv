#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IJusticaWriter
{
    Entity.DBJustica Write(Models.Justica justica, int auditorQuem, SqlConnection oCnn);
}

public class Justica : IJusticaWriter
{
    public Entity.DBJustica Write(Models.Justica justica, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = justica.Id.IsEmptyIDNumber() ? new Entity.DBJustica() : new Entity.DBJustica(justica.Id, oCnn);
        dbRec.FNome = justica.Nome;
        dbRec.FBold = justica.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}