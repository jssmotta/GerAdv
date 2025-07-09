#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusTarefasReader
{
    StatusTarefasResponse? Read(int id, MsiSqlConnection oCnn);
    StatusTarefasResponse? Read(Entity.DBStatusTarefas dbRec, MsiSqlConnection oCnn);
    StatusTarefasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    StatusTarefasResponse? Read(Entity.DBStatusTarefas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    StatusTarefasResponse? Read(DBStatusTarefas dbRec);
    StatusTarefasResponseAll? ReadAll(DBStatusTarefas dbRec, DataRow dr);
    StatusTarefasResponseAll? ReadAll(DBStatusTarefas dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<StatusTarefasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class StatusTarefas : IStatusTarefasReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{sttCodigo, sttNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<StatusTarefasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<StatusTarefasResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<StatusTarefasResponseAll>> ReadLocalAsync()
        {
            var result = new List<StatusTarefasResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBStatusTarefas(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"StatusTarefas".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}sttNome");
        }

        return query.ToString();
    }

    public StatusTarefasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusTarefas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusTarefasResponse? Read(Entity.DBStatusTarefas dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public StatusTarefasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusTarefas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusTarefasResponse? Read(Entity.DBStatusTarefas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statustarefas = new StatusTarefasResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statustarefas;
    }

    public StatusTarefasResponse? Read(DBStatusTarefas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statustarefas = new StatusTarefasResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statustarefas;
    }

    public StatusTarefasResponseAll? ReadAll(DBStatusTarefas dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statustarefas = new StatusTarefasResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statustarefas;
    }

    public StatusTarefasResponseAll? ReadAll(DBStatusTarefas dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statustarefas = new StatusTarefasResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statustarefas;
    }
}