#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaStatusReader
{
    AgendaStatusResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaStatusResponse? Read(Entity.DBAgendaStatus dbRec, MsiSqlConnection oCnn);
    AgendaStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaStatusResponse? Read(Entity.DBAgendaStatus dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaStatusResponse? Read(DBAgendaStatus dbRec);
    AgendaStatusResponseAll? ReadAll(DBAgendaStatus dbRec, DataRow dr);
    AgendaStatusResponseAll? ReadAll(DBAgendaStatus dbRec, SqlDataReader dr);
    IEnumerable<AgendaStatusResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AgendaStatus : IAgendaStatusReader
{
    public IEnumerable<AgendaStatusResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AgendaStatusResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AgendaStatusResponseAll>> ReadLocalAsync()
        {
            var result = new List<AgendaStatusResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAgendaStatus(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AgendaStatus".dbo(oCnn)} (NOLOCK) ");
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

    public AgendaStatusResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaStatus(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaStatusResponse? Read(Entity.DBAgendaStatus dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AgendaStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaStatus(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaStatusResponse? Read(Entity.DBAgendaStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendastatus = new AgendaStatusResponse
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Completed = dbRec.FCompleted,
        };
        return agendastatus;
    }

    public AgendaStatusResponse? Read(DBAgendaStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendastatus = new AgendaStatusResponse
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Completed = dbRec.FCompleted,
        };
        return agendastatus;
    }

    public AgendaStatusResponseAll? ReadAll(DBAgendaStatus dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendastatus = new AgendaStatusResponseAll
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Completed = dbRec.FCompleted,
        };
        return agendastatus;
    }

    public AgendaStatusResponseAll? ReadAll(DBAgendaStatus dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendastatus = new AgendaStatusResponseAll
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Completed = dbRec.FCompleted,
        };
        return agendastatus;
    }
}