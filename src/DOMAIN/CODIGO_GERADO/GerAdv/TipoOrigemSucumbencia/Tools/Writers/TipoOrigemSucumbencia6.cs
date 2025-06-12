#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoOrigemSucumbenciaWriter
{
    Entity.DBTipoOrigemSucumbencia Write(Models.TipoOrigemSucumbencia tipoorigemsucumbencia, MsiSqlConnection oCnn);
    void Delete(TipoOrigemSucumbenciaResponse tipoorigemsucumbencia, int operadorId, MsiSqlConnection oCnn);
}

public class TipoOrigemSucumbencia : ITipoOrigemSucumbenciaWriter
{
    public void Delete(TipoOrigemSucumbenciaResponse tipoorigemsucumbencia, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoOrigemSucumbencia] WHERE tosCodigo={tipoorigemsucumbencia.Id};", oCnn);
    }

    public Entity.DBTipoOrigemSucumbencia Write(Models.TipoOrigemSucumbencia tipoorigemsucumbencia, MsiSqlConnection oCnn)
    {
        var dbRec = tipoorigemsucumbencia.Id.IsEmptyIDNumber() ? new Entity.DBTipoOrigemSucumbencia() : new Entity.DBTipoOrigemSucumbencia(tipoorigemsucumbencia.Id, oCnn);
        dbRec.FNome = tipoorigemsucumbencia.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}