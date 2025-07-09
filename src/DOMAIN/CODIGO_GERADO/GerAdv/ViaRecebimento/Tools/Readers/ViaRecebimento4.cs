#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IViaRecebimentoReader
{
    ViaRecebimentoResponse? Read(int id, MsiSqlConnection oCnn);
    ViaRecebimentoResponse? Read(Entity.DBViaRecebimento dbRec, MsiSqlConnection oCnn);
    ViaRecebimentoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ViaRecebimentoResponse? Read(Entity.DBViaRecebimento dbRec);
    ViaRecebimentoResponse? Read(DBViaRecebimento dbRec);
    ViaRecebimentoResponseAll? ReadAll(DBViaRecebimento dbRec, DataRow dr);
    ViaRecebimentoResponseAll? ReadAll(DBViaRecebimento dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ViaRecebimentoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ViaRecebimento : IViaRecebimentoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{vrbCodigo, vrbNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ViaRecebimentoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ViaRecebimentoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ViaRecebimentoResponseAll>> ReadLocalAsync()
        {
            var result = new List<ViaRecebimentoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBViaRecebimento(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ViaRecebimento".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}vrbNome");
        }

        return query.ToString();
    }

    public ViaRecebimentoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBViaRecebimento(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ViaRecebimentoResponse? Read(Entity.DBViaRecebimento dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ViaRecebimentoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBViaRecebimento(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ViaRecebimentoResponse? Read(Entity.DBViaRecebimento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var viarecebimento = new ViaRecebimentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }

    public ViaRecebimentoResponse? Read(DBViaRecebimento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var viarecebimento = new ViaRecebimentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }

    public ViaRecebimentoResponseAll? ReadAll(DBViaRecebimento dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var viarecebimento = new ViaRecebimentoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }

    public ViaRecebimentoResponseAll? ReadAll(DBViaRecebimento dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var viarecebimento = new ViaRecebimentoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }
}