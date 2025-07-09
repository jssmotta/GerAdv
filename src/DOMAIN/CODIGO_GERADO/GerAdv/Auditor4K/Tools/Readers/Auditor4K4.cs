#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAuditor4KReader
{
    Auditor4KResponse? Read(int id, MsiSqlConnection oCnn);
    Auditor4KResponse? Read(Entity.DBAuditor4K dbRec, MsiSqlConnection oCnn);
    Auditor4KResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Auditor4KResponse? Read(Entity.DBAuditor4K dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Auditor4KResponse? Read(DBAuditor4K dbRec);
    Auditor4KResponseAll? ReadAll(DBAuditor4K dbRec, DataRow dr);
    Auditor4KResponseAll? ReadAll(DBAuditor4K dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<Auditor4KResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Auditor4K : IAuditor4KReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{audCodigo, audNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<Auditor4KResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<Auditor4KResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<Auditor4KResponseAll>> ReadLocalAsync()
        {
            var result = new List<Auditor4KResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAuditor4K(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Auditor4K".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}audNome");
        }

        return query.ToString();
    }

    public Auditor4KResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAuditor4K(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Auditor4KResponse? Read(Entity.DBAuditor4K dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public Auditor4KResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAuditor4K(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Auditor4KResponse? Read(Entity.DBAuditor4K dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var auditor4k = new Auditor4KResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return auditor4k;
    }

    public Auditor4KResponse? Read(DBAuditor4K dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var auditor4k = new Auditor4KResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return auditor4k;
    }

    public Auditor4KResponseAll? ReadAll(DBAuditor4K dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var auditor4k = new Auditor4KResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return auditor4k;
    }

    public Auditor4KResponseAll? ReadAll(DBAuditor4K dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var auditor4k = new Auditor4KResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return auditor4k;
    }
}