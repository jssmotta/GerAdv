#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreaReader
{
    AreaResponse? Read(int id, MsiSqlConnection oCnn);
    AreaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AreaResponse? Read(Entity.DBArea dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AreaResponse? Read(DBArea dbRec);
    AreaResponseAll? ReadAll(DBArea dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Area : IAreaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) areCodigo, areDescricao FROM {"Area".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}areDescricao");
        }

        return query.ToString();
    }

    public AreaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBArea(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBArea(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreaResponse? Read(Entity.DBArea dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var area = new AreaResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Top = dbRec.FTop,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return area;
    }

    public AreaResponse? Read(DBArea dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var area = new AreaResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Top = dbRec.FTop,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return area;
    }

    public AreaResponseAll? ReadAll(DBArea dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var area = new AreaResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Top = dbRec.FTop,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return area;
    }
}