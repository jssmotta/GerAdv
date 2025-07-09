#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEventoPrazoAgendaReader
{
    EventoPrazoAgendaResponse? Read(int id, MsiSqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(Entity.DBEventoPrazoAgenda dbRec, MsiSqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(Entity.DBEventoPrazoAgenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(DBEventoPrazoAgenda dbRec);
    EventoPrazoAgendaResponseAll? ReadAll(DBEventoPrazoAgenda dbRec, DataRow dr);
    EventoPrazoAgendaResponseAll? ReadAll(DBEventoPrazoAgenda dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<EventoPrazoAgendaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class EventoPrazoAgenda : IEventoPrazoAgendaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{epaCodigo, epaNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<EventoPrazoAgendaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<EventoPrazoAgendaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<EventoPrazoAgendaResponseAll>> ReadLocalAsync()
        {
            var result = new List<EventoPrazoAgendaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBEventoPrazoAgenda(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"EventoPrazoAgenda".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}epaNome");
        }

        return query.ToString();
    }

    public EventoPrazoAgendaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEventoPrazoAgenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EventoPrazoAgendaResponse? Read(Entity.DBEventoPrazoAgenda dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public EventoPrazoAgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEventoPrazoAgenda(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EventoPrazoAgendaResponse? Read(Entity.DBEventoPrazoAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var eventoprazoagenda = new EventoPrazoAgendaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return eventoprazoagenda;
    }

    public EventoPrazoAgendaResponse? Read(DBEventoPrazoAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var eventoprazoagenda = new EventoPrazoAgendaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return eventoprazoagenda;
    }

    public EventoPrazoAgendaResponseAll? ReadAll(DBEventoPrazoAgenda dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var eventoprazoagenda = new EventoPrazoAgendaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return eventoprazoagenda;
    }

    public EventoPrazoAgendaResponseAll? ReadAll(DBEventoPrazoAgenda dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var eventoprazoagenda = new EventoPrazoAgendaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return eventoprazoagenda;
    }
}