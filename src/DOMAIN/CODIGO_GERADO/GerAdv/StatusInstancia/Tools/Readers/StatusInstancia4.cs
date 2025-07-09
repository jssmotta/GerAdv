#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusInstanciaReader
{
    StatusInstanciaResponse? Read(int id, MsiSqlConnection oCnn);
    StatusInstanciaResponse? Read(Entity.DBStatusInstancia dbRec, MsiSqlConnection oCnn);
    StatusInstanciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    StatusInstanciaResponse? Read(Entity.DBStatusInstancia dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    StatusInstanciaResponse? Read(DBStatusInstancia dbRec);
    StatusInstanciaResponseAll? ReadAll(DBStatusInstancia dbRec, DataRow dr);
    StatusInstanciaResponseAll? ReadAll(DBStatusInstancia dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<StatusInstanciaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class StatusInstancia : IStatusInstanciaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{istCodigo, istNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<StatusInstanciaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<StatusInstanciaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<StatusInstanciaResponseAll>> ReadLocalAsync()
        {
            var result = new List<StatusInstanciaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBStatusInstancia(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"StatusInstancia".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}istNome");
        }

        return query.ToString();
    }

    public StatusInstanciaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusInstancia(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusInstanciaResponse? Read(Entity.DBStatusInstancia dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public StatusInstanciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusInstancia(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusInstanciaResponse? Read(Entity.DBStatusInstancia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusinstancia = new StatusInstanciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statusinstancia;
    }

    public StatusInstanciaResponse? Read(DBStatusInstancia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusinstancia = new StatusInstanciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statusinstancia;
    }

    public StatusInstanciaResponseAll? ReadAll(DBStatusInstancia dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusinstancia = new StatusInstanciaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statusinstancia;
    }

    public StatusInstanciaResponseAll? ReadAll(DBStatusInstancia dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusinstancia = new StatusInstanciaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statusinstancia;
    }
}