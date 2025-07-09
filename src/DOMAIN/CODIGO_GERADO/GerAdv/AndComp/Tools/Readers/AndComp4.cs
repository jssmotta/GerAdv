#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndCompReader
{
    AndCompResponse? Read(int id, MsiSqlConnection oCnn);
    AndCompResponse? Read(Entity.DBAndComp dbRec, MsiSqlConnection oCnn);
    AndCompResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AndCompResponse? Read(Entity.DBAndComp dbRec);
    AndCompResponse? Read(DBAndComp dbRec);
    AndCompResponseAll? ReadAll(DBAndComp dbRec, DataRow dr);
    AndCompResponseAll? ReadAll(DBAndComp dbRec, SqlDataReader dr);
    IEnumerable<AndCompResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AndComp : IAndCompReader
{
    public IEnumerable<AndCompResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AndCompResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AndCompResponseAll>> ReadLocalAsync()
        {
            var result = new List<AndCompResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAndComp(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AndComp".dbo(oCnn)} (NOLOCK) ");
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

    public AndCompResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndComp(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndCompResponse? Read(Entity.DBAndComp dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AndCompResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndComp(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndCompResponse? Read(Entity.DBAndComp dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andcomp = new AndCompResponse
        {
            Id = dbRec.ID,
            Andamento = dbRec.FAndamento,
            Compromisso = dbRec.FCompromisso,
        };
        return andcomp;
    }

    public AndCompResponse? Read(DBAndComp dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andcomp = new AndCompResponse
        {
            Id = dbRec.ID,
            Andamento = dbRec.FAndamento,
            Compromisso = dbRec.FCompromisso,
        };
        return andcomp;
    }

    public AndCompResponseAll? ReadAll(DBAndComp dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andcomp = new AndCompResponseAll
        {
            Id = dbRec.ID,
            Andamento = dbRec.FAndamento,
            Compromisso = dbRec.FCompromisso,
        };
        return andcomp;
    }

    public AndCompResponseAll? ReadAll(DBAndComp dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andcomp = new AndCompResponseAll
        {
            Id = dbRec.ID,
            Andamento = dbRec.FAndamento,
            Compromisso = dbRec.FCompromisso,
        };
        return andcomp;
    }
}