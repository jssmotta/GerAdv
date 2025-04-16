#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoOrigemSucumbenciaWriter
{
    Entity.DBTipoOrigemSucumbencia Write(Models.TipoOrigemSucumbencia tipoorigemsucumbencia, SqlConnection oCnn);
}

public class TipoOrigemSucumbencia : ITipoOrigemSucumbenciaWriter
{
    public Entity.DBTipoOrigemSucumbencia Write(Models.TipoOrigemSucumbencia tipoorigemsucumbencia, SqlConnection oCnn)
    {
        var dbRec = tipoorigemsucumbencia.Id.IsEmptyIDNumber() ? new Entity.DBTipoOrigemSucumbencia() : new Entity.DBTipoOrigemSucumbencia(tipoorigemsucumbencia.Id, oCnn);
        dbRec.FNome = tipoorigemsucumbencia.Nome;
        dbRec.Update(oCnn);
        return dbRec;
    }
}