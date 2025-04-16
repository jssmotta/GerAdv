#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoOrigemSucumbenciaReader
{
    TipoOrigemSucumbenciaResponse? Read(int id, SqlConnection oCnn);
    TipoOrigemSucumbenciaResponse? Read(string where, SqlConnection oCnn);
    TipoOrigemSucumbenciaResponse? Read(Entity.DBTipoOrigemSucumbencia dbRec);
    TipoOrigemSucumbenciaResponse? Read(DBTipoOrigemSucumbencia dbRec);
}

public partial class TipoOrigemSucumbencia : ITipoOrigemSucumbenciaReader
{
    public TipoOrigemSucumbenciaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoOrigemSucumbencia(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoOrigemSucumbenciaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoOrigemSucumbencia(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoOrigemSucumbenciaResponse? Read(Entity.DBTipoOrigemSucumbencia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }

    public TipoOrigemSucumbenciaResponse? Read(DBTipoOrigemSucumbencia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }
}