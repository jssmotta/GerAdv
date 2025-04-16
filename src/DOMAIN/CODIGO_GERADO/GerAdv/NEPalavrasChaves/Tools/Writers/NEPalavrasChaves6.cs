#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INEPalavrasChavesWriter
{
    Entity.DBNEPalavrasChaves Write(Models.NEPalavrasChaves nepalavraschaves, int auditorQuem, SqlConnection oCnn);
}

public class NEPalavrasChaves : INEPalavrasChavesWriter
{
    public Entity.DBNEPalavrasChaves Write(Models.NEPalavrasChaves nepalavraschaves, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = nepalavraschaves.Id.IsEmptyIDNumber() ? new Entity.DBNEPalavrasChaves() : new Entity.DBNEPalavrasChaves(nepalavraschaves.Id, oCnn);
        dbRec.FNome = nepalavraschaves.Nome;
        dbRec.FBold = nepalavraschaves.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}