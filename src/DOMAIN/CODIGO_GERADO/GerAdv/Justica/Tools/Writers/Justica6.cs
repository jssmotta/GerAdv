#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IJusticaWriter
{
    Entity.DBJustica Write(Models.Justica justica, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(JusticaResponse justica, int operadorId, MsiSqlConnection oCnn);
}

public class Justica : IJusticaWriter
{
    public void Delete(JusticaResponse justica, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Justica] WHERE jusCodigo={justica.Id};", oCnn);
    }

    public Entity.DBJustica Write(Models.Justica justica, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = justica.Id.IsEmptyIDNumber() ? new Entity.DBJustica() : new Entity.DBJustica(justica.Id, oCnn);
        dbRec.FNome = justica.Nome;
        dbRec.FBold = justica.Bold;
        dbRec.FGUID = justica.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}