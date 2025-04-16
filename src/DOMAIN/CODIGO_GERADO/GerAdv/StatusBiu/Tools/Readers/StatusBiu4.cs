#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusBiuReader
{
    StatusBiuResponse? Read(int id, SqlConnection oCnn);
    StatusBiuResponse? Read(string where, SqlConnection oCnn);
    StatusBiuResponse? Read(Entity.DBStatusBiu dbRec);
    StatusBiuResponse? Read(DBStatusBiu dbRec);
}

public partial class StatusBiu : IStatusBiuReader
{
    public StatusBiuResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusBiu(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusBiuResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusBiu(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusBiuResponse? Read(Entity.DBStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusbiu = new StatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        return statusbiu;
    }

    public StatusBiuResponse? Read(DBStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusbiu = new StatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        return statusbiu;
    }
}