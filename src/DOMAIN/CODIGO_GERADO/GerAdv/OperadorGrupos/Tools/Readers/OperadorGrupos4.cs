#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposReader
{
    OperadorGruposResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorGruposResponse? Read(Entity.DBOperadorGrupos dbRec, MsiSqlConnection oCnn);
    OperadorGruposResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposResponse? Read(Entity.DBOperadorGrupos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposResponse? Read(DBOperadorGrupos dbRec);
    OperadorGruposResponseAll? ReadAll(DBOperadorGrupos dbRec, DataRow dr);
    OperadorGruposResponseAll? ReadAll(DBOperadorGrupos dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<OperadorGruposResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OperadorGrupos : IOperadorGruposReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{opgCodigo, opgNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<OperadorGruposResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<OperadorGruposResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<OperadorGruposResponseAll>> ReadLocalAsync()
        {
            var result = new List<OperadorGruposResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBOperadorGrupos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"OperadorGrupos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}opgNome");
        }

        return query.ToString();
    }

    public OperadorGruposResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposResponse? Read(Entity.DBOperadorGrupos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public OperadorGruposResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposResponse? Read(Entity.DBOperadorGrupos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupos = new OperadorGruposResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return operadorgrupos;
    }

    public OperadorGruposResponse? Read(DBOperadorGrupos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupos = new OperadorGruposResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return operadorgrupos;
    }

    public OperadorGruposResponseAll? ReadAll(DBOperadorGrupos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupos = new OperadorGruposResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return operadorgrupos;
    }

    public OperadorGruposResponseAll? ReadAll(DBOperadorGrupos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupos = new OperadorGruposResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return operadorgrupos;
    }
}