#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutPutIDsReader
{
    ProcessOutPutIDsResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessOutPutIDsResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessOutPutIDsResponse? Read(Entity.DBProcessOutPutIDs dbRec);
    ProcessOutPutIDsResponse? Read(DBProcessOutPutIDs dbRec);
    ProcessOutPutIDsResponseAll? ReadAll(DBProcessOutPutIDs dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProcessOutPutIDs : IProcessOutPutIDsReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) poiCodigo, poiNome FROM {"ProcessOutPutIDs".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}poiNome");
        }

        return query.ToString();
    }

    public ProcessOutPutIDsResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutPutIDs(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutPutIDsResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutPutIDs(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutPutIDsResponse? Read(Entity.DBProcessOutPutIDs dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputids = new ProcessOutPutIDsResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputids;
    }

    public ProcessOutPutIDsResponse? Read(DBProcessOutPutIDs dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputids = new ProcessOutPutIDsResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputids;
    }

    public ProcessOutPutIDsResponseAll? ReadAll(DBProcessOutPutIDs dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputids = new ProcessOutPutIDsResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputids;
    }
}