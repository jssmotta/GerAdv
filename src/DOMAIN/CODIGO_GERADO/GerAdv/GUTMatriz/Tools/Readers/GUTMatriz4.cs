#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTMatrizReader
{
    GUTMatrizResponse? Read(int id, SqlConnection oCnn);
    GUTMatrizResponse? Read(string where, SqlConnection oCnn);
    GUTMatrizResponse? Read(Entity.DBGUTMatriz dbRec);
    GUTMatrizResponse? Read(DBGUTMatriz dbRec);
}

public partial class GUTMatriz : IGUTMatrizReader
{
    public GUTMatrizResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTMatriz(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTMatrizResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTMatriz(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTMatrizResponse? Read(Entity.DBGUTMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutmatriz = new GUTMatrizResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUTTipo = dbRec.FGUTTipo,
            Valor = dbRec.FValor,
        };
        return gutmatriz;
    }

    public GUTMatrizResponse? Read(DBGUTMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutmatriz = new GUTMatrizResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUTTipo = dbRec.FGUTTipo,
            Valor = dbRec.FValor,
        };
        return gutmatriz;
    }
}