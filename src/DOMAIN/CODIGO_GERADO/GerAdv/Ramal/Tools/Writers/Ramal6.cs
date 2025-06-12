#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRamalWriter
{
    Entity.DBRamal Write(Models.Ramal ramal, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(RamalResponse ramal, int operadorId, MsiSqlConnection oCnn);
}

public class Ramal : IRamalWriter
{
    public void Delete(RamalResponse ramal, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Ramal] WHERE ramCodigo={ramal.Id};", oCnn);
    }

    public Entity.DBRamal Write(Models.Ramal ramal, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = ramal.Id.IsEmptyIDNumber() ? new Entity.DBRamal() : new Entity.DBRamal(ramal.Id, oCnn);
        dbRec.FNome = ramal.Nome;
        dbRec.FObs = ramal.Obs;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}