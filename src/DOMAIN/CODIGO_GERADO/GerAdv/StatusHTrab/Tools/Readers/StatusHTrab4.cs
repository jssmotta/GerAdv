#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusHTrabReader
{
    StatusHTrabResponse? Read(int id, MsiSqlConnection oCnn);
    StatusHTrabResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    StatusHTrabResponse? Read(Entity.DBStatusHTrab dbRec);
    StatusHTrabResponse? Read(DBStatusHTrab dbRec);
    StatusHTrabResponseAll? ReadAll(DBStatusHTrab dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class StatusHTrab : IStatusHTrabReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) shtCodigo, shtDescricao FROM {"StatusHTrab".dbo(oCnn)} (NOLOCK) ");
        if (!string.IsNullOrEmpty(whereClause))
        {
            query.Append(!whereClause.ToUpperInvariant().Contains(TSql.Where, StringComparison.OrdinalIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
        }

        if (!string.IsNullOrEmpty(orderClause))
        {
            query.Append(!orderClause.ToUpperInvariant().Contains(TSql.OrderBy, StringComparison.OrdinalIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
        }
        else
        {
            query.Append($"{TSql.OrderBy}shtDescricao");
        }

        return query.ToString();
    }

    public StatusHTrabResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusHTrab(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusHTrabResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusHTrab(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusHTrabResponse? Read(Entity.DBStatusHTrab dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statushtrab = new StatusHTrabResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            ResID = dbRec.FResID,
        };
        return statushtrab;
    }

    public StatusHTrabResponse? Read(DBStatusHTrab dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statushtrab = new StatusHTrabResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            ResID = dbRec.FResID,
        };
        return statushtrab;
    }

    public StatusHTrabResponseAll? ReadAll(DBStatusHTrab dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statushtrab = new StatusHTrabResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            ResID = dbRec.FResID,
        };
        return statushtrab;
    }
}