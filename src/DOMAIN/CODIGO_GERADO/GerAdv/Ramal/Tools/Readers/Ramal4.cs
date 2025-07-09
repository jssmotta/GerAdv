#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRamalReader
{
    RamalResponse? Read(int id, MsiSqlConnection oCnn);
    RamalResponse? Read(Entity.DBRamal dbRec, MsiSqlConnection oCnn);
    RamalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    RamalResponse? Read(Entity.DBRamal dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    RamalResponse? Read(DBRamal dbRec);
    RamalResponseAll? ReadAll(DBRamal dbRec, DataRow dr);
    RamalResponseAll? ReadAll(DBRamal dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<RamalResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Ramal : IRamalReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{ramCodigo, ramNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<RamalResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<RamalResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<RamalResponseAll>> ReadLocalAsync()
        {
            var result = new List<RamalResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBRamal(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Ramal".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ramNome");
        }

        return query.ToString();
    }

    public RamalResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRamal(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RamalResponse? Read(Entity.DBRamal dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public RamalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRamal(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RamalResponse? Read(Entity.DBRamal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ramal = new RamalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
        };
        return ramal;
    }

    public RamalResponse? Read(DBRamal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ramal = new RamalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
        };
        return ramal;
    }

    public RamalResponseAll? ReadAll(DBRamal dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ramal = new RamalResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
        };
        return ramal;
    }

    public RamalResponseAll? ReadAll(DBRamal dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ramal = new RamalResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
        };
        return ramal;
    }
}