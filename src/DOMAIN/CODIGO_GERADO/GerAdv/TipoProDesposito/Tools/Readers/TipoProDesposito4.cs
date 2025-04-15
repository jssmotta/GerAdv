#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoProDespositoReader
{
    TipoProDespositoResponse? Read(int id, SqlConnection oCnn);
    TipoProDespositoResponse? Read(string where, SqlConnection oCnn);
    TipoProDespositoResponse? Read(Entity.DBTipoProDesposito dbRec);
    TipoProDespositoResponse? Read(DBTipoProDesposito dbRec);
}

public partial class TipoProDesposito : ITipoProDespositoReader
{
    public TipoProDespositoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoProDesposito(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoProDespositoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoProDesposito(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoProDespositoResponse? Read(Entity.DBTipoProDesposito dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoprodesposito = new TipoProDespositoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoprodesposito;
    }

    public TipoProDespositoResponse? Read(DBTipoProDesposito dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoprodesposito = new TipoProDespositoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoprodesposito;
    }
}