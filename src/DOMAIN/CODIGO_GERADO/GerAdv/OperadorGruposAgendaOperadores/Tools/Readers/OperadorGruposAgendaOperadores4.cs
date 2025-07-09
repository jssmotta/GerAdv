#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaOperadoresReader
{
    OperadorGruposAgendaOperadoresResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(Entity.DBOperadorGruposAgendaOperadores dbRec, MsiSqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(Entity.DBOperadorGruposAgendaOperadores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(DBOperadorGruposAgendaOperadores dbRec);
    OperadorGruposAgendaOperadoresResponseAll? ReadAll(DBOperadorGruposAgendaOperadores dbRec, DataRow dr);
    OperadorGruposAgendaOperadoresResponseAll? ReadAll(DBOperadorGruposAgendaOperadores dbRec, SqlDataReader dr);
    IEnumerable<OperadorGruposAgendaOperadoresResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OperadorGruposAgendaOperadores : IOperadorGruposAgendaOperadoresReader
{
    public IEnumerable<OperadorGruposAgendaOperadoresResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<OperadorGruposAgendaOperadoresResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<OperadorGruposAgendaOperadoresResponseAll>> ReadLocalAsync()
        {
            var result = new List<OperadorGruposAgendaOperadoresResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBOperadorGruposAgendaOperadores(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"OperadorGruposAgendaOperadores".dbo(oCnn)} (NOLOCK) ");
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

    public OperadorGruposAgendaOperadoresResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgendaOperadores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaOperadoresResponse? Read(Entity.DBOperadorGruposAgendaOperadores dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public OperadorGruposAgendaOperadoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgendaOperadores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaOperadoresResponse? Read(Entity.DBOperadorGruposAgendaOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagendaoperadores = new OperadorGruposAgendaOperadoresResponse
        {
            Id = dbRec.ID,
            OperadorGruposAgenda = dbRec.FOperadorGruposAgenda,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadorgruposagendaoperadores;
    }

    public OperadorGruposAgendaOperadoresResponse? Read(DBOperadorGruposAgendaOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagendaoperadores = new OperadorGruposAgendaOperadoresResponse
        {
            Id = dbRec.ID,
            OperadorGruposAgenda = dbRec.FOperadorGruposAgenda,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadorgruposagendaoperadores;
    }

    public OperadorGruposAgendaOperadoresResponseAll? ReadAll(DBOperadorGruposAgendaOperadores dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagendaoperadores = new OperadorGruposAgendaOperadoresResponseAll
        {
            Id = dbRec.ID,
            OperadorGruposAgenda = dbRec.FOperadorGruposAgenda,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        operadorgruposagendaoperadores.NomeOperadorGruposAgenda = dr["groNome"]?.ToString() ?? string.Empty;
        operadorgruposagendaoperadores.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadorgruposagendaoperadores;
    }

    public OperadorGruposAgendaOperadoresResponseAll? ReadAll(DBOperadorGruposAgendaOperadores dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagendaoperadores = new OperadorGruposAgendaOperadoresResponseAll
        {
            Id = dbRec.ID,
            OperadorGruposAgenda = dbRec.FOperadorGruposAgenda,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        operadorgruposagendaoperadores.NomeOperadorGruposAgenda = dr["groNome"]?.ToString() ?? string.Empty;
        operadorgruposagendaoperadores.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadorgruposagendaoperadores;
    }
}