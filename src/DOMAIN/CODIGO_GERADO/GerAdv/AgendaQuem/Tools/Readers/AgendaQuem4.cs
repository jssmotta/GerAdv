#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaQuemReader
{
    AgendaQuemResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaQuemResponse? Read(Entity.DBAgendaQuem dbRec, MsiSqlConnection oCnn);
    AgendaQuemResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaQuemResponse? Read(Entity.DBAgendaQuem dbRec);
    AgendaQuemResponse? Read(DBAgendaQuem dbRec);
    AgendaQuemResponseAll? ReadAll(DBAgendaQuem dbRec, DataRow dr);
    AgendaQuemResponseAll? ReadAll(DBAgendaQuem dbRec, SqlDataReader dr);
    IEnumerable<AgendaQuemResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AgendaQuem : IAgendaQuemReader
{
    public IEnumerable<AgendaQuemResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AgendaQuemResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AgendaQuemResponseAll>> ReadLocalAsync()
        {
            var result = new List<AgendaQuemResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAgendaQuem(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AgendaQuem".dbo(oCnn)} (NOLOCK) ");
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

    public AgendaQuemResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaQuem(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaQuemResponse? Read(Entity.DBAgendaQuem dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AgendaQuemResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaQuem(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaQuemResponse? Read(Entity.DBAgendaQuem dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendaquem = new AgendaQuemResponse
        {
            Id = dbRec.ID,
            IDAgenda = dbRec.FIDAgenda,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            Preposto = dbRec.FPreposto,
        };
        return agendaquem;
    }

    public AgendaQuemResponse? Read(DBAgendaQuem dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendaquem = new AgendaQuemResponse
        {
            Id = dbRec.ID,
            IDAgenda = dbRec.FIDAgenda,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            Preposto = dbRec.FPreposto,
        };
        return agendaquem;
    }

    public AgendaQuemResponseAll? ReadAll(DBAgendaQuem dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendaquem = new AgendaQuemResponseAll
        {
            Id = dbRec.ID,
            IDAgenda = dbRec.FIDAgenda,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            Preposto = dbRec.FPreposto,
        };
        agendaquem.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agendaquem.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agendaquem.NomePrepostos = dr["preNome"]?.ToString() ?? string.Empty;
        return agendaquem;
    }

    public AgendaQuemResponseAll? ReadAll(DBAgendaQuem dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendaquem = new AgendaQuemResponseAll
        {
            Id = dbRec.ID,
            IDAgenda = dbRec.FIDAgenda,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            Preposto = dbRec.FPreposto,
        };
        agendaquem.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agendaquem.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agendaquem.NomePrepostos = dr["preNome"]?.ToString() ?? string.Empty;
        return agendaquem;
    }
}