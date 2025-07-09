#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEndTitReader
{
    EndTitResponse? Read(int id, MsiSqlConnection oCnn);
    EndTitResponse? Read(Entity.DBEndTit dbRec, MsiSqlConnection oCnn);
    EndTitResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EndTitResponse? Read(Entity.DBEndTit dbRec);
    EndTitResponse? Read(DBEndTit dbRec);
    EndTitResponseAll? ReadAll(DBEndTit dbRec, DataRow dr);
    EndTitResponseAll? ReadAll(DBEndTit dbRec, SqlDataReader dr);
    IEnumerable<EndTitResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class EndTit : IEndTitReader
{
    public IEnumerable<EndTitResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<EndTitResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<EndTitResponseAll>> ReadLocalAsync()
        {
            var result = new List<EndTitResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBEndTit(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"EndTit".dbo(oCnn)} (NOLOCK) ");
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

    public EndTitResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEndTit(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EndTitResponse? Read(Entity.DBEndTit dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public EndTitResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEndTit(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EndTitResponse? Read(Entity.DBEndTit dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var endtit = new EndTitResponse
        {
            Id = dbRec.ID,
            Endereco = dbRec.FEndereco,
            Titulo = dbRec.FTitulo,
        };
        return endtit;
    }

    public EndTitResponse? Read(DBEndTit dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var endtit = new EndTitResponse
        {
            Id = dbRec.ID,
            Endereco = dbRec.FEndereco,
            Titulo = dbRec.FTitulo,
        };
        return endtit;
    }

    public EndTitResponseAll? ReadAll(DBEndTit dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var endtit = new EndTitResponseAll
        {
            Id = dbRec.ID,
            Endereco = dbRec.FEndereco,
            Titulo = dbRec.FTitulo,
        };
        return endtit;
    }

    public EndTitResponseAll? ReadAll(DBEndTit dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var endtit = new EndTitResponseAll
        {
            Id = dbRec.ID,
            Endereco = dbRec.FEndereco,
            Titulo = dbRec.FTitulo,
        };
        return endtit;
    }
}