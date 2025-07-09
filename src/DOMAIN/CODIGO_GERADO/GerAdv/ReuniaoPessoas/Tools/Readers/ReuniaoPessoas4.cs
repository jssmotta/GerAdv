#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoPessoasReader
{
    ReuniaoPessoasResponse? Read(int id, MsiSqlConnection oCnn);
    ReuniaoPessoasResponse? Read(Entity.DBReuniaoPessoas dbRec, MsiSqlConnection oCnn);
    ReuniaoPessoasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ReuniaoPessoasResponse? Read(Entity.DBReuniaoPessoas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ReuniaoPessoasResponse? Read(DBReuniaoPessoas dbRec);
    ReuniaoPessoasResponseAll? ReadAll(DBReuniaoPessoas dbRec, DataRow dr);
    ReuniaoPessoasResponseAll? ReadAll(DBReuniaoPessoas dbRec, SqlDataReader dr);
    IEnumerable<ReuniaoPessoasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ReuniaoPessoas : IReuniaoPessoasReader
{
    public IEnumerable<ReuniaoPessoasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ReuniaoPessoasResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ReuniaoPessoasResponseAll>> ReadLocalAsync()
        {
            var result = new List<ReuniaoPessoasResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBReuniaoPessoas(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ReuniaoPessoas".dbo(oCnn)} (NOLOCK) ");
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

    public ReuniaoPessoasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniaoPessoas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoPessoasResponse? Read(Entity.DBReuniaoPessoas dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ReuniaoPessoasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniaoPessoas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoPessoasResponse? Read(Entity.DBReuniaoPessoas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniaopessoas = new ReuniaoPessoasResponse
        {
            Id = dbRec.ID,
            Reuniao = dbRec.FReuniao,
            Operador = dbRec.FOperador,
        };
        return reuniaopessoas;
    }

    public ReuniaoPessoasResponse? Read(DBReuniaoPessoas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniaopessoas = new ReuniaoPessoasResponse
        {
            Id = dbRec.ID,
            Reuniao = dbRec.FReuniao,
            Operador = dbRec.FOperador,
        };
        return reuniaopessoas;
    }

    public ReuniaoPessoasResponseAll? ReadAll(DBReuniaoPessoas dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniaopessoas = new ReuniaoPessoasResponseAll
        {
            Id = dbRec.ID,
            Reuniao = dbRec.FReuniao,
            Operador = dbRec.FOperador,
        };
        reuniaopessoas.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return reuniaopessoas;
    }

    public ReuniaoPessoasResponseAll? ReadAll(DBReuniaoPessoas dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniaopessoas = new ReuniaoPessoasResponseAll
        {
            Id = dbRec.ID,
            Reuniao = dbRec.FReuniao,
            Operador = dbRec.FOperador,
        };
        reuniaopessoas.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return reuniaopessoas;
    }
}