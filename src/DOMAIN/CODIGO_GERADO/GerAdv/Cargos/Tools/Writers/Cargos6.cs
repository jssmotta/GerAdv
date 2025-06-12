#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosWriter
{
    Entity.DBCargos Write(Models.Cargos cargos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(CargosResponse cargos, int operadorId, MsiSqlConnection oCnn);
}

public class Cargos : ICargosWriter
{
    public void Delete(CargosResponse cargos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Cargos] WHERE carCodigo={cargos.Id};", oCnn);
    }

    public Entity.DBCargos Write(Models.Cargos cargos, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = cargos.Id.IsEmptyIDNumber() ? new Entity.DBCargos() : new Entity.DBCargos(cargos.Id, oCnn);
        dbRec.FNome = cargos.Nome;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}