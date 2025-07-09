#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGraphReader
{
    GraphResponse? Read(int id, MsiSqlConnection oCnn);
    GraphResponse? Read(Entity.DBGraph dbRec, MsiSqlConnection oCnn);
    GraphResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GraphResponse? Read(Entity.DBGraph dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GraphResponse? Read(DBGraph dbRec);
    GraphResponseAll? ReadAll(DBGraph dbRec, DataRow dr);
    GraphResponseAll? ReadAll(DBGraph dbRec, SqlDataReader dr);
    IEnumerable<GraphResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Graph : IGraphReader
{
    public IEnumerable<GraphResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<GraphResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<GraphResponseAll>> ReadLocalAsync()
        {
            var result = new List<GraphResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBGraph(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Graph".dbo(oCnn)} (NOLOCK) ");
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

    public GraphResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGraph(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GraphResponse? Read(Entity.DBGraph dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public GraphResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGraph(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GraphResponse? Read(Entity.DBGraph dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var graph = new GraphResponse
        {
            Id = dbRec.ID,
            Tabela = dbRec.FTabela ?? string.Empty,
            TabelaId = dbRec.FTabelaId,
            Imagem = dbRec.FImagem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return graph;
    }

    public GraphResponse? Read(DBGraph dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var graph = new GraphResponse
        {
            Id = dbRec.ID,
            Tabela = dbRec.FTabela ?? string.Empty,
            TabelaId = dbRec.FTabelaId,
            Imagem = dbRec.FImagem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return graph;
    }

    public GraphResponseAll? ReadAll(DBGraph dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var graph = new GraphResponseAll
        {
            Id = dbRec.ID,
            Tabela = dbRec.FTabela ?? string.Empty,
            TabelaId = dbRec.FTabelaId,
            Imagem = dbRec.FImagem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return graph;
    }

    public GraphResponseAll? ReadAll(DBGraph dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var graph = new GraphResponseAll
        {
            Id = dbRec.ID,
            Tabela = dbRec.FTabela ?? string.Empty,
            TabelaId = dbRec.FTabelaId,
            Imagem = dbRec.FImagem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return graph;
    }
}