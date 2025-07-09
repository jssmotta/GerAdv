#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputRequestReader
{
    ProcessOutputRequestResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessOutputRequestResponse? Read(Entity.DBProcessOutputRequest dbRec, MsiSqlConnection oCnn);
    ProcessOutputRequestResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessOutputRequestResponse? Read(Entity.DBProcessOutputRequest dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessOutputRequestResponse? Read(DBProcessOutputRequest dbRec);
    ProcessOutputRequestResponseAll? ReadAll(DBProcessOutputRequest dbRec, DataRow dr);
    ProcessOutputRequestResponseAll? ReadAll(DBProcessOutputRequest dbRec, SqlDataReader dr);
    IEnumerable<ProcessOutputRequestResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProcessOutputRequest : IProcessOutputRequestReader
{
    public IEnumerable<ProcessOutputRequestResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProcessOutputRequestResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProcessOutputRequestResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProcessOutputRequestResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProcessOutputRequest(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProcessOutputRequest".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}");
        }

        return query.ToString();
    }

    public ProcessOutputRequestResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputRequest(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputRequestResponse? Read(Entity.DBProcessOutputRequest dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProcessOutputRequestResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputRequest(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputRequestResponse? Read(Entity.DBProcessOutputRequest dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputrequest = new ProcessOutputRequestResponse
        {
            Id = dbRec.ID,
            ProcessOutputEngine = dbRec.FProcessOutputEngine,
            Operador = dbRec.FOperador,
            Processo = dbRec.FProcesso,
            UltimoIdTabelaExo = dbRec.FUltimoIdTabelaExo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputrequest;
    }

    public ProcessOutputRequestResponse? Read(DBProcessOutputRequest dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputrequest = new ProcessOutputRequestResponse
        {
            Id = dbRec.ID,
            ProcessOutputEngine = dbRec.FProcessOutputEngine,
            Operador = dbRec.FOperador,
            Processo = dbRec.FProcesso,
            UltimoIdTabelaExo = dbRec.FUltimoIdTabelaExo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputrequest;
    }

    public ProcessOutputRequestResponseAll? ReadAll(DBProcessOutputRequest dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputrequest = new ProcessOutputRequestResponseAll
        {
            Id = dbRec.ID,
            ProcessOutputEngine = dbRec.FProcessOutputEngine,
            Operador = dbRec.FOperador,
            Processo = dbRec.FProcesso,
            UltimoIdTabelaExo = dbRec.FUltimoIdTabelaExo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        processoutputrequest.NomeProcessOutputEngine = dr["poeNome"]?.ToString() ?? string.Empty;
        processoutputrequest.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        processoutputrequest.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return processoutputrequest;
    }

    public ProcessOutputRequestResponseAll? ReadAll(DBProcessOutputRequest dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputrequest = new ProcessOutputRequestResponseAll
        {
            Id = dbRec.ID,
            ProcessOutputEngine = dbRec.FProcessOutputEngine,
            Operador = dbRec.FOperador,
            Processo = dbRec.FProcesso,
            UltimoIdTabelaExo = dbRec.FUltimoIdTabelaExo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        processoutputrequest.NomeProcessOutputEngine = dr["poeNome"]?.ToString() ?? string.Empty;
        processoutputrequest.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        processoutputrequest.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return processoutputrequest;
    }
}