#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputSourcesReader
{
    ProcessOutputSourcesResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessOutputSourcesResponse? Read(Entity.DBProcessOutputSources dbRec, MsiSqlConnection oCnn);
    ProcessOutputSourcesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessOutputSourcesResponse? Read(Entity.DBProcessOutputSources dbRec);
    ProcessOutputSourcesResponse? Read(DBProcessOutputSources dbRec);
    ProcessOutputSourcesResponseAll? ReadAll(DBProcessOutputSources dbRec, DataRow dr);
    ProcessOutputSourcesResponseAll? ReadAll(DBProcessOutputSources dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ProcessOutputSourcesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProcessOutputSources : IProcessOutputSourcesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{posCodigo, posNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ProcessOutputSourcesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProcessOutputSourcesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProcessOutputSourcesResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProcessOutputSourcesResponseAll>(max);
            await using var connection = Configuracoes.GetConnectionByUri(uri);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection?.InnerConnection)
            {
                CommandTimeout = 0
            };
            cmd.Parameters.AddRange([..parameters]);
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult).ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                if (await reader.IsDBNullAsync(1).ConfigureAwait(false))
                    continue;
                result.Add(ReadAll(new Entity.DBProcessOutputSources(reader), reader)!);
            }

            return result;
        }
    }

    static string BuildSqlQuery(string campos, string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProcessOutputSources".dbo(oCnn)} (NOLOCK) ");
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

    public ProcessOutputSourcesResponse? Read(Entity.DBProcessOutputSources dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
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

    public ProcessOutputSourcesResponseAll? ReadAll(DBProcessOutputSources dbRec, SqlDataReader dr)
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