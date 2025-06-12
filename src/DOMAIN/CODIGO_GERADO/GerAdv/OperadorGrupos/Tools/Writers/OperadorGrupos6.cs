#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposWriter
{
    Entity.DBOperadorGrupos Write(Models.OperadorGrupos operadorgrupos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(OperadorGruposResponse operadorgrupos, int operadorId, MsiSqlConnection oCnn);
}

public class OperadorGrupos : IOperadorGruposWriter
{
    public void Delete(OperadorGruposResponse operadorgrupos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[OperadorGrupos] WHERE opgCodigo={operadorgrupos.Id};", oCnn);
    }

    public Entity.DBOperadorGrupos Write(Models.OperadorGrupos operadorgrupos, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = operadorgrupos.Id.IsEmptyIDNumber() ? new Entity.DBOperadorGrupos() : new Entity.DBOperadorGrupos(operadorgrupos.Id, oCnn);
        dbRec.FNome = operadorgrupos.Nome;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}