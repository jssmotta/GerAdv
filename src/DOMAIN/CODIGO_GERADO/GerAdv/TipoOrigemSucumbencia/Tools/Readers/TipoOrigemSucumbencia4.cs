#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoOrigemSucumbenciaReader
{
    TipoOrigemSucumbenciaResponse? Read(int id, MsiSqlConnection oCnn);
    TipoOrigemSucumbenciaResponse? Read(Entity.DBTipoOrigemSucumbencia dbRec, MsiSqlConnection oCnn);
    TipoOrigemSucumbenciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoOrigemSucumbenciaResponse? Read(Entity.DBTipoOrigemSucumbencia dbRec);
    TipoOrigemSucumbenciaResponse? Read(DBTipoOrigemSucumbencia dbRec);
    TipoOrigemSucumbenciaResponseAll? ReadAll(DBTipoOrigemSucumbencia dbRec, DataRow dr);
    TipoOrigemSucumbenciaResponseAll? ReadAll(DBTipoOrigemSucumbencia dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<TipoOrigemSucumbenciaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoOrigemSucumbencia : ITipoOrigemSucumbenciaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{tosCodigo, tosNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<TipoOrigemSucumbenciaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<TipoOrigemSucumbenciaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<TipoOrigemSucumbenciaResponseAll>> ReadLocalAsync()
        {
            var result = new List<TipoOrigemSucumbenciaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBTipoOrigemSucumbencia(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"TipoOrigemSucumbencia".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tosNome");
        }

        return query.ToString();
    }

    public TipoOrigemSucumbenciaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoOrigemSucumbencia(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoOrigemSucumbenciaResponse? Read(Entity.DBTipoOrigemSucumbencia dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public TipoOrigemSucumbenciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoOrigemSucumbencia(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoOrigemSucumbenciaResponse? Read(Entity.DBTipoOrigemSucumbencia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }

    public TipoOrigemSucumbenciaResponse? Read(DBTipoOrigemSucumbencia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }

    public TipoOrigemSucumbenciaResponseAll? ReadAll(DBTipoOrigemSucumbencia dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }

    public TipoOrigemSucumbenciaResponseAll? ReadAll(DBTipoOrigemSucumbencia dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }
}