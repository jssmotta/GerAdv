#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaClientesReader
{
    LivroCaixaClientesResponse? Read(int id, MsiSqlConnection oCnn);
    LivroCaixaClientesResponse? Read(Entity.DBLivroCaixaClientes dbRec, MsiSqlConnection oCnn);
    LivroCaixaClientesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LivroCaixaClientesResponse? Read(Entity.DBLivroCaixaClientes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LivroCaixaClientesResponse? Read(DBLivroCaixaClientes dbRec);
    LivroCaixaClientesResponseAll? ReadAll(DBLivroCaixaClientes dbRec, DataRow dr);
    LivroCaixaClientesResponseAll? ReadAll(DBLivroCaixaClientes dbRec, SqlDataReader dr);
    IEnumerable<LivroCaixaClientesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class LivroCaixaClientes : ILivroCaixaClientesReader
{
    public IEnumerable<LivroCaixaClientesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<LivroCaixaClientesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<LivroCaixaClientesResponseAll>> ReadLocalAsync()
        {
            var result = new List<LivroCaixaClientesResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBLivroCaixaClientes(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"LivroCaixaClientes".dbo(oCnn)} (NOLOCK) ");
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

    public LivroCaixaClientesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixaClientes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaClientesResponse? Read(Entity.DBLivroCaixaClientes dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public LivroCaixaClientesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixaClientes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaClientesResponse? Read(Entity.DBLivroCaixaClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixaclientes = new LivroCaixaClientesResponse
        {
            Id = dbRec.ID,
            LivroCaixa = dbRec.FLivroCaixa,
            Cliente = dbRec.FCliente,
            Lancado = dbRec.FLancado,
        };
        return livrocaixaclientes;
    }

    public LivroCaixaClientesResponse? Read(DBLivroCaixaClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixaclientes = new LivroCaixaClientesResponse
        {
            Id = dbRec.ID,
            LivroCaixa = dbRec.FLivroCaixa,
            Cliente = dbRec.FCliente,
            Lancado = dbRec.FLancado,
        };
        return livrocaixaclientes;
    }

    public LivroCaixaClientesResponseAll? ReadAll(DBLivroCaixaClientes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixaclientes = new LivroCaixaClientesResponseAll
        {
            Id = dbRec.ID,
            LivroCaixa = dbRec.FLivroCaixa,
            Cliente = dbRec.FCliente,
            Lancado = dbRec.FLancado,
        };
        livrocaixaclientes.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return livrocaixaclientes;
    }

    public LivroCaixaClientesResponseAll? ReadAll(DBLivroCaixaClientes dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixaclientes = new LivroCaixaClientesResponseAll
        {
            Id = dbRec.ID,
            LivroCaixa = dbRec.FLivroCaixa,
            Cliente = dbRec.FCliente,
            Lancado = dbRec.FLancado,
        };
        livrocaixaclientes.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return livrocaixaclientes;
    }
}