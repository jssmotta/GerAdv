#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoProDespositoReader
{
    TipoProDespositoResponse? Read(int id, MsiSqlConnection oCnn);
    TipoProDespositoResponse? Read(Entity.DBTipoProDesposito dbRec, MsiSqlConnection oCnn);
    TipoProDespositoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoProDespositoResponse? Read(Entity.DBTipoProDesposito dbRec);
    TipoProDespositoResponse? Read(DBTipoProDesposito dbRec);
    TipoProDespositoResponseAll? ReadAll(DBTipoProDesposito dbRec, DataRow dr);
    TipoProDespositoResponseAll? ReadAll(DBTipoProDesposito dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<TipoProDespositoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoProDesposito : ITipoProDespositoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{tpdCodigo, tpdNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<TipoProDespositoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<TipoProDespositoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<TipoProDespositoResponseAll>> ReadLocalAsync()
        {
            var result = new List<TipoProDespositoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBTipoProDesposito(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"TipoProDesposito".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tpdNome");
        }

        return query.ToString();
    }

    public TipoProDespositoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoProDesposito(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoProDespositoResponse? Read(Entity.DBTipoProDesposito dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public TipoProDespositoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoProDesposito(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoProDespositoResponse? Read(Entity.DBTipoProDesposito dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoprodesposito = new TipoProDespositoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoprodesposito;
    }

    public TipoProDespositoResponse? Read(DBTipoProDesposito dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoprodesposito = new TipoProDespositoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoprodesposito;
    }

    public TipoProDespositoResponseAll? ReadAll(DBTipoProDesposito dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoprodesposito = new TipoProDespositoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoprodesposito;
    }

    public TipoProDespositoResponseAll? ReadAll(DBTipoProDesposito dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoprodesposito = new TipoProDespositoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoprodesposito;
    }
}