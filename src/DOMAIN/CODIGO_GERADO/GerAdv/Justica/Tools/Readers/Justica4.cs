#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IJusticaReader
{
    JusticaResponse? Read(int id, MsiSqlConnection oCnn);
    JusticaResponse? Read(Entity.DBJustica dbRec, MsiSqlConnection oCnn);
    JusticaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    JusticaResponse? Read(Entity.DBJustica dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    JusticaResponse? Read(DBJustica dbRec);
    JusticaResponseAll? ReadAll(DBJustica dbRec, DataRow dr);
    JusticaResponseAll? ReadAll(DBJustica dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<JusticaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Justica : IJusticaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{jusCodigo, jusNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<JusticaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<JusticaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<JusticaResponseAll>> ReadLocalAsync()
        {
            var result = new List<JusticaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBJustica(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Justica".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}jusNome");
        }

        return query.ToString();
    }

    public JusticaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBJustica(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public JusticaResponse? Read(Entity.DBJustica dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public JusticaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBJustica(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public JusticaResponse? Read(Entity.DBJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var justica = new JusticaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return justica;
    }

    public JusticaResponse? Read(DBJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var justica = new JusticaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return justica;
    }

    public JusticaResponseAll? ReadAll(DBJustica dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var justica = new JusticaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return justica;
    }

    public JusticaResponseAll? ReadAll(DBJustica dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var justica = new JusticaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return justica;
    }
}