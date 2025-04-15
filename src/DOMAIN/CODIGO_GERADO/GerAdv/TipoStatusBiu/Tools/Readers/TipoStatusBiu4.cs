#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoStatusBiuReader
{
    TipoStatusBiuResponse? Read(int id, SqlConnection oCnn);
    TipoStatusBiuResponse? Read(string where, SqlConnection oCnn);
    TipoStatusBiuResponse? Read(Entity.DBTipoStatusBiu dbRec);
    TipoStatusBiuResponse? Read(DBTipoStatusBiu dbRec);
}

public partial class TipoStatusBiu : ITipoStatusBiuReader
{
    public TipoStatusBiuResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoStatusBiu(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoStatusBiuResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoStatusBiu(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoStatusBiuResponse? Read(Entity.DBTipoStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipostatusbiu = new TipoStatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }

    public TipoStatusBiuResponse? Read(DBTipoStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipostatusbiu = new TipoStatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }
}