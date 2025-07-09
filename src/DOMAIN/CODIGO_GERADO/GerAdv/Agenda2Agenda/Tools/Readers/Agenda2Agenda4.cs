#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgenda2AgendaReader
{
    Agenda2AgendaResponse? Read(int id, MsiSqlConnection oCnn);
    Agenda2AgendaResponse? Read(Entity.DBAgenda2Agenda dbRec, MsiSqlConnection oCnn);
    Agenda2AgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Agenda2AgendaResponse? Read(Entity.DBAgenda2Agenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Agenda2AgendaResponse? Read(DBAgenda2Agenda dbRec);
    Agenda2AgendaResponseAll? ReadAll(DBAgenda2Agenda dbRec, DataRow dr);
    Agenda2AgendaResponseAll? ReadAll(DBAgenda2Agenda dbRec, SqlDataReader dr);
    IEnumerable<Agenda2AgendaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Agenda2Agenda : IAgenda2AgendaReader
{
    public IEnumerable<Agenda2AgendaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<Agenda2AgendaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<Agenda2AgendaResponseAll>> ReadLocalAsync()
        {
            var result = new List<Agenda2AgendaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAgenda2Agenda(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Agenda2Agenda".dbo(oCnn)} (NOLOCK) ");
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

    public Agenda2AgendaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda2Agenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Agenda2AgendaResponse? Read(Entity.DBAgenda2Agenda dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public Agenda2AgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgenda2Agenda(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Agenda2AgendaResponse? Read(Entity.DBAgenda2Agenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda2agenda = new Agenda2AgendaResponse
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Agenda = dbRec.FAgenda,
        };
        return agenda2agenda;
    }

    public Agenda2AgendaResponse? Read(DBAgenda2Agenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda2agenda = new Agenda2AgendaResponse
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Agenda = dbRec.FAgenda,
        };
        return agenda2agenda;
    }

    public Agenda2AgendaResponseAll? ReadAll(DBAgenda2Agenda dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda2agenda = new Agenda2AgendaResponseAll
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Agenda = dbRec.FAgenda,
        };
        return agenda2agenda;
    }

    public Agenda2AgendaResponseAll? ReadAll(DBAgenda2Agenda dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agenda2agenda = new Agenda2AgendaResponseAll
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Agenda = dbRec.FAgenda,
        };
        return agenda2agenda;
    }
}