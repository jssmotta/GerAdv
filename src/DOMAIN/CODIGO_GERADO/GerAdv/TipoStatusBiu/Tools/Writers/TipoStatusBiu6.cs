#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoStatusBiuWriter
{
    Entity.DBTipoStatusBiu Write(Models.TipoStatusBiu tipostatusbiu, SqlConnection oCnn);
}

public class TipoStatusBiu : ITipoStatusBiuWriter
{
    public Entity.DBTipoStatusBiu Write(Models.TipoStatusBiu tipostatusbiu, SqlConnection oCnn)
    {
        var dbRec = tipostatusbiu.Id.IsEmptyIDNumber() ? new Entity.DBTipoStatusBiu() : new Entity.DBTipoStatusBiu(tipostatusbiu.Id, oCnn);
        dbRec.FNome = tipostatusbiu.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}