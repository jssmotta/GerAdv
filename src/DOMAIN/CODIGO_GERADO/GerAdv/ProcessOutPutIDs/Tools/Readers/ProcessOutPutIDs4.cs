#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutPutIDsReader
{
    ProcessOutPutIDsResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessOutPutIDsResponse? Read(Entity.DBProcessOutPutIDs dbRec, MsiSqlConnection oCnn);
    ProcessOutPutIDsResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessOutPutIDsResponse? Read(Entity.DBProcessOutPutIDs dbRec);
    ProcessOutPutIDsResponse? Read(DBProcessOutPutIDs dbRec);
    ProcessOutPutIDsResponseAll? ReadAll(DBProcessOutPutIDs dbRec, DataRow dr);
    ProcessOutPutIDsResponseAll? ReadAll(DBProcessOutPutIDs dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ProcessOutPutIDsResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProcessOutPutIDs : IProcessOutPutIDsReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{poiCodigo, poiNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ProcessOutPutIDsResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProcessOutPutIDsResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProcessOutPutIDsResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProcessOutPutIDsResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProcessOutPutIDs(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProcessOutPutIDs".dbo(oCnn)} (NOLOCK) ");
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

    public ProcessOutPutIDsResponse? Read(Entity.DBProcessOutPutIDs dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
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

    public ProcessOutPutIDsResponseAll? ReadAll(DBProcessOutPutIDs dbRec, SqlDataReader dr)
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