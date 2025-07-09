#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRecordsReader
{
    AgendaRecordsResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaRecordsResponse? Read(Entity.DBAgendaRecords dbRec, MsiSqlConnection oCnn);
    AgendaRecordsResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaRecordsResponse? Read(Entity.DBAgendaRecords dbRec);
    AgendaRecordsResponse? Read(DBAgendaRecords dbRec);
    AgendaRecordsResponseAll? ReadAll(DBAgendaRecords dbRec, DataRow dr);
    AgendaRecordsResponseAll? ReadAll(DBAgendaRecords dbRec, SqlDataReader dr);
    IEnumerable<AgendaRecordsResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AgendaRecords : IAgendaRecordsReader
{
    public IEnumerable<AgendaRecordsResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AgendaRecordsResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AgendaRecordsResponseAll>> ReadLocalAsync()
        {
            var result = new List<AgendaRecordsResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAgendaRecords(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AgendaRecords".dbo(oCnn)} (NOLOCK) ");
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

    public AgendaRecordsResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRecords(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRecordsResponse? Read(Entity.DBAgendaRecords dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AgendaRecordsResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRecords(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRecordsResponse? Read(Entity.DBAgendaRecords dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarecords = new AgendaRecordsResponse
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Julgador = dbRec.FJulgador,
            ClientesSocios = dbRec.FClientesSocios,
            Perito = dbRec.FPerito,
            Colaborador = dbRec.FColaborador,
            Foro = dbRec.FForo,
            Aviso1 = dbRec.FAviso1,
            Aviso2 = dbRec.FAviso2,
            Aviso3 = dbRec.FAviso3,
            CrmAviso1 = dbRec.FCrmAviso1,
            CrmAviso2 = dbRec.FCrmAviso2,
            CrmAviso3 = dbRec.FCrmAviso3,
        };
        if (DateTime.TryParse(dbRec.FDataAviso1, out _))
            agendarecords.DataAviso1 = dbRec.FDataAviso1;
        if (DateTime.TryParse(dbRec.FDataAviso2, out _))
            agendarecords.DataAviso2 = dbRec.FDataAviso2;
        if (DateTime.TryParse(dbRec.FDataAviso3, out _))
            agendarecords.DataAviso3 = dbRec.FDataAviso3;
        return agendarecords;
    }

    public AgendaRecordsResponse? Read(DBAgendaRecords dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarecords = new AgendaRecordsResponse
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Julgador = dbRec.FJulgador,
            ClientesSocios = dbRec.FClientesSocios,
            Perito = dbRec.FPerito,
            Colaborador = dbRec.FColaborador,
            Foro = dbRec.FForo,
            Aviso1 = dbRec.FAviso1,
            Aviso2 = dbRec.FAviso2,
            Aviso3 = dbRec.FAviso3,
            CrmAviso1 = dbRec.FCrmAviso1,
            CrmAviso2 = dbRec.FCrmAviso2,
            CrmAviso3 = dbRec.FCrmAviso3,
        };
        if (DateTime.TryParse(dbRec.FDataAviso1, out _))
            agendarecords.DataAviso1 = dbRec.FDataAviso1;
        if (DateTime.TryParse(dbRec.FDataAviso2, out _))
            agendarecords.DataAviso2 = dbRec.FDataAviso2;
        if (DateTime.TryParse(dbRec.FDataAviso3, out _))
            agendarecords.DataAviso3 = dbRec.FDataAviso3;
        return agendarecords;
    }

    public AgendaRecordsResponseAll? ReadAll(DBAgendaRecords dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarecords = new AgendaRecordsResponseAll
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Julgador = dbRec.FJulgador,
            ClientesSocios = dbRec.FClientesSocios,
            Perito = dbRec.FPerito,
            Colaborador = dbRec.FColaborador,
            Foro = dbRec.FForo,
            Aviso1 = dbRec.FAviso1,
            Aviso2 = dbRec.FAviso2,
            Aviso3 = dbRec.FAviso3,
            CrmAviso1 = dbRec.FCrmAviso1,
            CrmAviso2 = dbRec.FCrmAviso2,
            CrmAviso3 = dbRec.FCrmAviso3,
        };
        if (DateTime.TryParse(dbRec.FDataAviso1, out _))
            agendarecords.DataAviso1 = dbRec.FDataAviso1;
        if (DateTime.TryParse(dbRec.FDataAviso2, out _))
            agendarecords.DataAviso2 = dbRec.FDataAviso2;
        if (DateTime.TryParse(dbRec.FDataAviso3, out _))
            agendarecords.DataAviso3 = dbRec.FDataAviso3;
        agendarecords.NomeClientesSocios = dr["cscNome"]?.ToString() ?? string.Empty;
        agendarecords.NomeColaboradores = dr["colNome"]?.ToString() ?? string.Empty;
        agendarecords.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        return agendarecords;
    }

    public AgendaRecordsResponseAll? ReadAll(DBAgendaRecords dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarecords = new AgendaRecordsResponseAll
        {
            Id = dbRec.ID,
            Agenda = dbRec.FAgenda,
            Julgador = dbRec.FJulgador,
            ClientesSocios = dbRec.FClientesSocios,
            Perito = dbRec.FPerito,
            Colaborador = dbRec.FColaborador,
            Foro = dbRec.FForo,
            Aviso1 = dbRec.FAviso1,
            Aviso2 = dbRec.FAviso2,
            Aviso3 = dbRec.FAviso3,
            CrmAviso1 = dbRec.FCrmAviso1,
            CrmAviso2 = dbRec.FCrmAviso2,
            CrmAviso3 = dbRec.FCrmAviso3,
        };
        if (DateTime.TryParse(dbRec.FDataAviso1, out _))
            agendarecords.DataAviso1 = dbRec.FDataAviso1;
        if (DateTime.TryParse(dbRec.FDataAviso2, out _))
            agendarecords.DataAviso2 = dbRec.FDataAviso2;
        if (DateTime.TryParse(dbRec.FDataAviso3, out _))
            agendarecords.DataAviso3 = dbRec.FDataAviso3;
        agendarecords.NomeClientesSocios = dr["cscNome"]?.ToString() ?? string.Empty;
        agendarecords.NomeColaboradores = dr["colNome"]?.ToString() ?? string.Empty;
        agendarecords.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        return agendarecords;
    }
}