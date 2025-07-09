#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParteClienteOutrasReader
{
    ParteClienteOutrasResponse? Read(int id, MsiSqlConnection oCnn);
    ParteClienteOutrasResponse? Read(Entity.DBParteClienteOutras dbRec, MsiSqlConnection oCnn);
    ParteClienteOutrasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ParteClienteOutrasResponse? Read(Entity.DBParteClienteOutras dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ParteClienteOutrasResponse? Read(DBParteClienteOutras dbRec);
    ParteClienteOutrasResponseAll? ReadAll(DBParteClienteOutras dbRec, DataRow dr);
    ParteClienteOutrasResponseAll? ReadAll(DBParteClienteOutras dbRec, SqlDataReader dr);
    IEnumerable<ParteClienteOutrasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ParteClienteOutras : IParteClienteOutrasReader
{
    public IEnumerable<ParteClienteOutrasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ParteClienteOutrasResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ParteClienteOutrasResponseAll>> ReadLocalAsync()
        {
            var result = new List<ParteClienteOutrasResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBParteClienteOutras(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ParteClienteOutras".dbo(oCnn)} (NOLOCK) ");
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

    public ParteClienteOutrasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParteClienteOutras(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParteClienteOutrasResponse? Read(Entity.DBParteClienteOutras dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ParteClienteOutrasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParteClienteOutras(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParteClienteOutrasResponse? Read(Entity.DBParteClienteOutras dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteclienteoutras = new ParteClienteOutrasResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
            PrimeiraReclamada = dbRec.FPrimeiraReclamada,
        };
        return parteclienteoutras;
    }

    public ParteClienteOutrasResponse? Read(DBParteClienteOutras dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteclienteoutras = new ParteClienteOutrasResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
            PrimeiraReclamada = dbRec.FPrimeiraReclamada,
        };
        return parteclienteoutras;
    }

    public ParteClienteOutrasResponseAll? ReadAll(DBParteClienteOutras dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteclienteoutras = new ParteClienteOutrasResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
            PrimeiraReclamada = dbRec.FPrimeiraReclamada,
        };
        parteclienteoutras.NomeOutrasPartesCliente = dr["opcNome"]?.ToString() ?? string.Empty;
        parteclienteoutras.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return parteclienteoutras;
    }

    public ParteClienteOutrasResponseAll? ReadAll(DBParteClienteOutras dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteclienteoutras = new ParteClienteOutrasResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
            PrimeiraReclamada = dbRec.FPrimeiraReclamada,
        };
        parteclienteoutras.NomeOutrasPartesCliente = dr["opcNome"]?.ToString() ?? string.Empty;
        parteclienteoutras.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return parteclienteoutras;
    }
}