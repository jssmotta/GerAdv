#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncaoReader
{
    FuncaoResponse? Read(int id, MsiSqlConnection oCnn);
    FuncaoResponse? Read(Entity.DBFuncao dbRec, MsiSqlConnection oCnn);
    FuncaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FuncaoResponse? Read(Entity.DBFuncao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FuncaoResponse? Read(DBFuncao dbRec);
    FuncaoResponseAll? ReadAll(DBFuncao dbRec, DataRow dr);
    FuncaoResponseAll? ReadAll(DBFuncao dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<FuncaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Funcao : IFuncaoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{funCodigo, funDescricao}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<FuncaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<FuncaoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<FuncaoResponseAll>> ReadLocalAsync()
        {
            var result = new List<FuncaoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBFuncao(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Funcao".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}funDescricao");
        }

        return query.ToString();
    }

    public FuncaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FuncaoResponse? Read(Entity.DBFuncao dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public FuncaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FuncaoResponse? Read(Entity.DBFuncao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcao = new FuncaoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
        };
        return funcao;
    }

    public FuncaoResponse? Read(DBFuncao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcao = new FuncaoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
        };
        return funcao;
    }

    public FuncaoResponseAll? ReadAll(DBFuncao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcao = new FuncaoResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
        };
        return funcao;
    }

    public FuncaoResponseAll? ReadAll(DBFuncao dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcao = new FuncaoResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
        };
        return funcao;
    }
}