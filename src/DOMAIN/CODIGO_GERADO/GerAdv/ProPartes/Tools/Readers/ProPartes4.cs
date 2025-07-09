#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProPartesReader
{
    ProPartesResponse? Read(int id, MsiSqlConnection oCnn);
    ProPartesResponse? Read(Entity.DBProPartes dbRec, MsiSqlConnection oCnn);
    ProPartesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProPartesResponse? Read(Entity.DBProPartes dbRec);
    ProPartesResponse? Read(DBProPartes dbRec);
    ProPartesResponseAll? ReadAll(DBProPartes dbRec, DataRow dr);
    ProPartesResponseAll? ReadAll(DBProPartes dbRec, SqlDataReader dr);
    IEnumerable<ProPartesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProPartes : IProPartesReader
{
    public IEnumerable<ProPartesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProPartesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProPartesResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProPartesResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProPartes(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProPartes".dbo(oCnn)} (NOLOCK) ");
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

    public ProPartesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProPartes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProPartesResponse? Read(Entity.DBProPartes dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProPartesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProPartes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProPartesResponse? Read(Entity.DBProPartes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var propartes = new ProPartesResponse
        {
            Id = dbRec.ID,
            Parte = dbRec.FParte,
            Processo = dbRec.FProcesso,
        };
        return propartes;
    }

    public ProPartesResponse? Read(DBProPartes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var propartes = new ProPartesResponse
        {
            Id = dbRec.ID,
            Parte = dbRec.FParte,
            Processo = dbRec.FProcesso,
        };
        return propartes;
    }

    public ProPartesResponseAll? ReadAll(DBProPartes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var propartes = new ProPartesResponseAll
        {
            Id = dbRec.ID,
            Parte = dbRec.FParte,
            Processo = dbRec.FProcesso,
        };
        propartes.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return propartes;
    }

    public ProPartesResponseAll? ReadAll(DBProPartes dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var propartes = new ProPartesResponseAll
        {
            Id = dbRec.ID,
            Parte = dbRec.FParte,
            Processo = dbRec.FProcesso,
        };
        propartes.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return propartes;
    }
}