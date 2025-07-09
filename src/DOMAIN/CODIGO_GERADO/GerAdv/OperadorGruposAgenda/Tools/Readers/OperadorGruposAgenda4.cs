#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaReader
{
    OperadorGruposAgendaResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(Entity.DBOperadorGruposAgenda dbRec, MsiSqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(Entity.DBOperadorGruposAgenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(DBOperadorGruposAgenda dbRec);
    OperadorGruposAgendaResponseAll? ReadAll(DBOperadorGruposAgenda dbRec, DataRow dr);
    OperadorGruposAgendaResponseAll? ReadAll(DBOperadorGruposAgenda dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<OperadorGruposAgendaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OperadorGruposAgenda : IOperadorGruposAgendaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{groCodigo, groNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<OperadorGruposAgendaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<OperadorGruposAgendaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<OperadorGruposAgendaResponseAll>> ReadLocalAsync()
        {
            var result = new List<OperadorGruposAgendaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBOperadorGruposAgenda(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"OperadorGruposAgenda".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}groNome");
        }

        return query.ToString();
    }

    public OperadorGruposAgendaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaResponse? Read(Entity.DBOperadorGruposAgenda dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public OperadorGruposAgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgenda(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaResponse? Read(Entity.DBOperadorGruposAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagenda = new OperadorGruposAgendaResponse
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadorgruposagenda;
    }

    public OperadorGruposAgendaResponse? Read(DBOperadorGruposAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagenda = new OperadorGruposAgendaResponse
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadorgruposagenda;
    }

    public OperadorGruposAgendaResponseAll? ReadAll(DBOperadorGruposAgenda dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagenda = new OperadorGruposAgendaResponseAll
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        operadorgruposagenda.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadorgruposagenda;
    }

    public OperadorGruposAgendaResponseAll? ReadAll(DBOperadorGruposAgenda dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagenda = new OperadorGruposAgendaResponseAll
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        operadorgruposagenda.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadorgruposagenda;
    }
}