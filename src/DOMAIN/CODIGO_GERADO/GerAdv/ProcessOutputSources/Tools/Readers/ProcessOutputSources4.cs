#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputSourcesReader
{
    ProcessOutputSourcesResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessOutputSourcesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessOutputSourcesResponse? Read(Entity.DBProcessOutputSources dbRec);
    ProcessOutputSourcesResponse? Read(DBProcessOutputSources dbRec);
    ProcessOutputSourcesResponseAll? ReadAll(DBProcessOutputSources dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProcessOutputSources : IProcessOutputSourcesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) posCodigo, posNome FROM {"ProcessOutputSources".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}posNome");
        }

        return query.ToString();
    }

    public ProcessOutputSourcesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputSources(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputSourcesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputSources(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputSourcesResponse? Read(Entity.DBProcessOutputSources dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputsources = new ProcessOutputSourcesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputsources;
    }

    public ProcessOutputSourcesResponse? Read(DBProcessOutputSources dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputsources = new ProcessOutputSourcesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputsources;
    }

    public ProcessOutputSourcesResponseAll? ReadAll(DBProcessOutputSources dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputsources = new ProcessOutputSourcesResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputsources;
    }
}