#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraStatusReader
{
    PenhoraStatusResponse? Read(int id, MsiSqlConnection oCnn);
    PenhoraStatusResponse? Read(Entity.DBPenhoraStatus dbRec, MsiSqlConnection oCnn);
    PenhoraStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PenhoraStatusResponse? Read(Entity.DBPenhoraStatus dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PenhoraStatusResponse? Read(DBPenhoraStatus dbRec);
    PenhoraStatusResponseAll? ReadAll(DBPenhoraStatus dbRec, DataRow dr);
    PenhoraStatusResponseAll? ReadAll(DBPenhoraStatus dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<PenhoraStatusResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class PenhoraStatus : IPenhoraStatusReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{phsCodigo, phsNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<PenhoraStatusResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<PenhoraStatusResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<PenhoraStatusResponseAll>> ReadLocalAsync()
        {
            var result = new List<PenhoraStatusResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBPenhoraStatus(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"PenhoraStatus".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}phsNome");
        }

        return query.ToString();
    }

    public PenhoraStatusResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhoraStatus(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraStatusResponse? Read(Entity.DBPenhoraStatus dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public PenhoraStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhoraStatus(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraStatusResponse? Read(Entity.DBPenhoraStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhorastatus = new PenhoraStatusResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return penhorastatus;
    }

    public PenhoraStatusResponse? Read(DBPenhoraStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhorastatus = new PenhoraStatusResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return penhorastatus;
    }

    public PenhoraStatusResponseAll? ReadAll(DBPenhoraStatus dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhorastatus = new PenhoraStatusResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return penhorastatus;
    }

    public PenhoraStatusResponseAll? ReadAll(DBPenhoraStatus dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhorastatus = new PenhoraStatusResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return penhorastatus;
    }
}