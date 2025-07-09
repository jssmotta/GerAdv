#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INEPalavrasChavesReader
{
    NEPalavrasChavesResponse? Read(int id, MsiSqlConnection oCnn);
    NEPalavrasChavesResponse? Read(Entity.DBNEPalavrasChaves dbRec, MsiSqlConnection oCnn);
    NEPalavrasChavesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NEPalavrasChavesResponse? Read(Entity.DBNEPalavrasChaves dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NEPalavrasChavesResponse? Read(DBNEPalavrasChaves dbRec);
    NEPalavrasChavesResponseAll? ReadAll(DBNEPalavrasChaves dbRec, DataRow dr);
    NEPalavrasChavesResponseAll? ReadAll(DBNEPalavrasChaves dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<NEPalavrasChavesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class NEPalavrasChaves : INEPalavrasChavesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{npcCodigo, npcNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<NEPalavrasChavesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<NEPalavrasChavesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<NEPalavrasChavesResponseAll>> ReadLocalAsync()
        {
            var result = new List<NEPalavrasChavesResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBNEPalavrasChaves(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"NEPalavrasChaves".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}npcNome");
        }

        return query.ToString();
    }

    public NEPalavrasChavesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNEPalavrasChaves(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NEPalavrasChavesResponse? Read(Entity.DBNEPalavrasChaves dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public NEPalavrasChavesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNEPalavrasChaves(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NEPalavrasChavesResponse? Read(Entity.DBNEPalavrasChaves dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nepalavraschaves = new NEPalavrasChavesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return nepalavraschaves;
    }

    public NEPalavrasChavesResponse? Read(DBNEPalavrasChaves dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nepalavraschaves = new NEPalavrasChavesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return nepalavraschaves;
    }

    public NEPalavrasChavesResponseAll? ReadAll(DBNEPalavrasChaves dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nepalavraschaves = new NEPalavrasChavesResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return nepalavraschaves;
    }

    public NEPalavrasChavesResponseAll? ReadAll(DBNEPalavrasChaves dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nepalavraschaves = new NEPalavrasChavesResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return nepalavraschaves;
    }
}