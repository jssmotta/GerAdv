#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoStatusBiuWriter
{
    Entity.DBTipoStatusBiu Write(Models.TipoStatusBiu tipostatusbiu, MsiSqlConnection oCnn);
    void Delete(TipoStatusBiuResponse tipostatusbiu, int operadorId, MsiSqlConnection oCnn);
}

public class TipoStatusBiu : ITipoStatusBiuWriter
{
    public void Delete(TipoStatusBiuResponse tipostatusbiu, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoStatusBiu] WHERE tsbCodigo={tipostatusbiu.Id};", oCnn);
    }

    public Entity.DBTipoStatusBiu Write(Models.TipoStatusBiu tipostatusbiu, MsiSqlConnection oCnn)
    {
        var dbRec = tipostatusbiu.Id.IsEmptyIDNumber() ? new Entity.DBTipoStatusBiu() : new Entity.DBTipoStatusBiu(tipostatusbiu.Id, oCnn);
        dbRec.FNome = tipostatusbiu.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}