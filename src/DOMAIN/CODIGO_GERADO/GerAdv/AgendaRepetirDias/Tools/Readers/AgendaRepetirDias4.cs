#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRepetirDiasReader
{
    AgendaRepetirDiasResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaRepetirDiasResponse? Read(Entity.DBAgendaRepetirDias dbRec, MsiSqlConnection oCnn);
    AgendaRepetirDiasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaRepetirDiasResponse? Read(Entity.DBAgendaRepetirDias dbRec);
    AgendaRepetirDiasResponse? Read(DBAgendaRepetirDias dbRec);
    AgendaRepetirDiasResponseAll? ReadAll(DBAgendaRepetirDias dbRec, DataRow dr);
    AgendaRepetirDiasResponseAll? ReadAll(DBAgendaRepetirDias dbRec, SqlDataReader dr);
    IEnumerable<AgendaRepetirDiasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AgendaRepetirDias : IAgendaRepetirDiasReader
{
    public IEnumerable<AgendaRepetirDiasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AgendaRepetirDiasResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AgendaRepetirDiasResponseAll>> ReadLocalAsync()
        {
            var result = new List<AgendaRepetirDiasResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAgendaRepetirDias(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AgendaRepetirDias".dbo(oCnn)} (NOLOCK) ");
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

    public AgendaRepetirDiasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRepetirDias(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRepetirDiasResponse? Read(Entity.DBAgendaRepetirDias dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AgendaRepetirDiasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRepetirDias(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRepetirDiasResponse? Read(Entity.DBAgendaRepetirDias dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetirdias = new AgendaRepetirDiasResponse
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Dia = dbRec.FDia,
        };
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetirdias.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetirdias.Hora = dbRec.FHora;
        return agendarepetirdias;
    }

    public AgendaRepetirDiasResponse? Read(DBAgendaRepetirDias dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetirdias = new AgendaRepetirDiasResponse
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Dia = dbRec.FDia,
        };
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetirdias.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetirdias.Hora = dbRec.FHora;
        return agendarepetirdias;
    }

    public AgendaRepetirDiasResponseAll? ReadAll(DBAgendaRepetirDias dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetirdias = new AgendaRepetirDiasResponseAll
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Dia = dbRec.FDia,
        };
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetirdias.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetirdias.Hora = dbRec.FHora;
        return agendarepetirdias;
    }

    public AgendaRepetirDiasResponseAll? ReadAll(DBAgendaRepetirDias dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetirdias = new AgendaRepetirDiasResponseAll
        {
            Id = dbRec.ID,
            Master = dbRec.FMaster,
            Dia = dbRec.FDia,
        };
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetirdias.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetirdias.Hora = dbRec.FHora;
        return agendarepetirdias;
    }
}