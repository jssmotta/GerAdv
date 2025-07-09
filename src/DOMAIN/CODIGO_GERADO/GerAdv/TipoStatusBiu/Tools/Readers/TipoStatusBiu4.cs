#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoStatusBiuReader
{
    TipoStatusBiuResponse? Read(int id, MsiSqlConnection oCnn);
    TipoStatusBiuResponse? Read(Entity.DBTipoStatusBiu dbRec, MsiSqlConnection oCnn);
    TipoStatusBiuResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoStatusBiuResponse? Read(Entity.DBTipoStatusBiu dbRec);
    TipoStatusBiuResponse? Read(DBTipoStatusBiu dbRec);
    TipoStatusBiuResponseAll? ReadAll(DBTipoStatusBiu dbRec, DataRow dr);
    TipoStatusBiuResponseAll? ReadAll(DBTipoStatusBiu dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<TipoStatusBiuResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoStatusBiu : ITipoStatusBiuReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{tsbCodigo, tsbNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<TipoStatusBiuResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<TipoStatusBiuResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<TipoStatusBiuResponseAll>> ReadLocalAsync()
        {
            var result = new List<TipoStatusBiuResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBTipoStatusBiu(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"TipoStatusBiu".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tsbNome");
        }

        return query.ToString();
    }

    public TipoStatusBiuResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoStatusBiu(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoStatusBiuResponse? Read(Entity.DBTipoStatusBiu dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public TipoStatusBiuResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoStatusBiu(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoStatusBiuResponse? Read(Entity.DBTipoStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipostatusbiu = new TipoStatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }

    public TipoStatusBiuResponse? Read(DBTipoStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipostatusbiu = new TipoStatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }

    public TipoStatusBiuResponseAll? ReadAll(DBTipoStatusBiu dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipostatusbiu = new TipoStatusBiuResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }

    public TipoStatusBiuResponseAll? ReadAll(DBTipoStatusBiu dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipostatusbiu = new TipoStatusBiuResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }
}