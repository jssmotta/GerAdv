#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTTipoReader
{
    GUTTipoResponse? Read(int id, MsiSqlConnection oCnn);
    GUTTipoResponse? Read(Entity.DBGUTTipo dbRec, MsiSqlConnection oCnn);
    GUTTipoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTTipoResponse? Read(Entity.DBGUTTipo dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTTipoResponse? Read(DBGUTTipo dbRec);
    GUTTipoResponseAll? ReadAll(DBGUTTipo dbRec, DataRow dr);
    GUTTipoResponseAll? ReadAll(DBGUTTipo dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<GUTTipoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GUTTipo : IGUTTipoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{gttCodigo, gttNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<GUTTipoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<GUTTipoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<GUTTipoResponseAll>> ReadLocalAsync()
        {
            var result = new List<GUTTipoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBGUTTipo(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"GUTTipo".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}gttNome");
        }

        return query.ToString();
    }

    public GUTTipoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTTipo(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTTipoResponse? Read(Entity.DBGUTTipo dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public GUTTipoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTTipo(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTTipoResponse? Read(Entity.DBGUTTipo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var guttipo = new GUTTipoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Ordem = dbRec.FOrdem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return guttipo;
    }

    public GUTTipoResponse? Read(DBGUTTipo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var guttipo = new GUTTipoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Ordem = dbRec.FOrdem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return guttipo;
    }

    public GUTTipoResponseAll? ReadAll(DBGUTTipo dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var guttipo = new GUTTipoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Ordem = dbRec.FOrdem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return guttipo;
    }

    public GUTTipoResponseAll? ReadAll(DBGUTTipo dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var guttipo = new GUTTipoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Ordem = dbRec.FOrdem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return guttipo;
    }
}