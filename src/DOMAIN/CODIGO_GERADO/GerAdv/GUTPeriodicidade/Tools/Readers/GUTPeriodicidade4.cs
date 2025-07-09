#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeReader
{
    GUTPeriodicidadeResponse? Read(int id, MsiSqlConnection oCnn);
    GUTPeriodicidadeResponse? Read(Entity.DBGUTPeriodicidade dbRec, MsiSqlConnection oCnn);
    GUTPeriodicidadeResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTPeriodicidadeResponse? Read(Entity.DBGUTPeriodicidade dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTPeriodicidadeResponse? Read(DBGUTPeriodicidade dbRec);
    GUTPeriodicidadeResponseAll? ReadAll(DBGUTPeriodicidade dbRec, DataRow dr);
    GUTPeriodicidadeResponseAll? ReadAll(DBGUTPeriodicidade dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<GUTPeriodicidadeResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GUTPeriodicidade : IGUTPeriodicidadeReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{pcgCodigo, pcgNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<GUTPeriodicidadeResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<GUTPeriodicidadeResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<GUTPeriodicidadeResponseAll>> ReadLocalAsync()
        {
            var result = new List<GUTPeriodicidadeResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBGUTPeriodicidade(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"GUTPeriodicidade".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}pcgNome");
        }

        return query.ToString();
    }

    public GUTPeriodicidadeResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidade(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeResponse? Read(Entity.DBGUTPeriodicidade dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public GUTPeriodicidadeResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidade(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeResponse? Read(Entity.DBGUTPeriodicidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidade = new GUTPeriodicidadeResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutperiodicidade;
    }

    public GUTPeriodicidadeResponse? Read(DBGUTPeriodicidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidade = new GUTPeriodicidadeResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutperiodicidade;
    }

    public GUTPeriodicidadeResponseAll? ReadAll(DBGUTPeriodicidade dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidade = new GUTPeriodicidadeResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutperiodicidade;
    }

    public GUTPeriodicidadeResponseAll? ReadAll(DBGUTPeriodicidade dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidade = new GUTPeriodicidadeResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutperiodicidade;
    }
}