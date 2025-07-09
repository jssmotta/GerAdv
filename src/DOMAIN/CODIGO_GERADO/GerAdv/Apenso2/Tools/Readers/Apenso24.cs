#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IApenso2Reader
{
    Apenso2Response? Read(int id, MsiSqlConnection oCnn);
    Apenso2Response? Read(Entity.DBApenso2 dbRec, MsiSqlConnection oCnn);
    Apenso2Response? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Apenso2Response? Read(Entity.DBApenso2 dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Apenso2Response? Read(DBApenso2 dbRec);
    Apenso2ResponseAll? ReadAll(DBApenso2 dbRec, DataRow dr);
    Apenso2ResponseAll? ReadAll(DBApenso2 dbRec, SqlDataReader dr);
    IEnumerable<Apenso2ResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Apenso2 : IApenso2Reader
{
    public IEnumerable<Apenso2ResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<Apenso2ResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<Apenso2ResponseAll>> ReadLocalAsync()
        {
            var result = new List<Apenso2ResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBApenso2(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Apenso2".dbo(oCnn)} (NOLOCK) ");
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

    public Apenso2Response? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso2(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Apenso2Response? Read(Entity.DBApenso2 dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public Apenso2Response? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso2(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Apenso2Response? Read(Entity.DBApenso2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso2 = new Apenso2Response
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Apensado = dbRec.FApensado,
        };
        return apenso2;
    }

    public Apenso2Response? Read(DBApenso2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso2 = new Apenso2Response
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Apensado = dbRec.FApensado,
        };
        return apenso2;
    }

    public Apenso2ResponseAll? ReadAll(DBApenso2 dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso2 = new Apenso2ResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Apensado = dbRec.FApensado,
        };
        apenso2.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return apenso2;
    }

    public Apenso2ResponseAll? ReadAll(DBApenso2 dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso2 = new Apenso2ResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Apensado = dbRec.FApensado,
        };
        apenso2.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return apenso2;
    }
}