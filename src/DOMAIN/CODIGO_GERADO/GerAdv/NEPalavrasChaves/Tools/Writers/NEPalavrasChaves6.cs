#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INEPalavrasChavesWriter
{
    Entity.DBNEPalavrasChaves Write(Models.NEPalavrasChaves nepalavraschaves, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(NEPalavrasChavesResponse nepalavraschaves, int operadorId, MsiSqlConnection oCnn);
}

public class NEPalavrasChaves : INEPalavrasChavesWriter
{
    public void Delete(NEPalavrasChavesResponse nepalavraschaves, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[NEPalavrasChaves] WHERE npcCodigo={nepalavraschaves.Id};", oCnn);
    }

    public Entity.DBNEPalavrasChaves Write(Models.NEPalavrasChaves nepalavraschaves, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = nepalavraschaves.Id.IsEmptyIDNumber() ? new Entity.DBNEPalavrasChaves() : new Entity.DBNEPalavrasChaves(nepalavraschaves.Id, oCnn);
        dbRec.FNome = nepalavraschaves.Nome;
        dbRec.FBold = nepalavraschaves.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}