#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMOperadorReader
{
    ContatoCRMOperadorResponse? Read(int id, MsiSqlConnection oCnn);
    ContatoCRMOperadorResponse? Read(Entity.DBContatoCRMOperador dbRec, MsiSqlConnection oCnn);
    ContatoCRMOperadorResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMOperadorResponse? Read(Entity.DBContatoCRMOperador dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMOperadorResponse? Read(DBContatoCRMOperador dbRec);
    ContatoCRMOperadorResponseAll? ReadAll(DBContatoCRMOperador dbRec, DataRow dr);
    ContatoCRMOperadorResponseAll? ReadAll(DBContatoCRMOperador dbRec, SqlDataReader dr);
    IEnumerable<ContatoCRMOperadorResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ContatoCRMOperador : IContatoCRMOperadorReader
{
    public IEnumerable<ContatoCRMOperadorResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ContatoCRMOperadorResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ContatoCRMOperadorResponseAll>> ReadLocalAsync()
        {
            var result = new List<ContatoCRMOperadorResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBContatoCRMOperador(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ContatoCRMOperador".dbo(oCnn)} (NOLOCK) ");
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

    public ContatoCRMOperadorResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMOperador(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMOperadorResponse? Read(Entity.DBContatoCRMOperador dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ContatoCRMOperadorResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMOperador(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMOperadorResponse? Read(Entity.DBContatoCRMOperador dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmoperador = new ContatoCRMOperadorResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            CargoEsc = dbRec.FCargoEsc,
            Operador = dbRec.FOperador,
        };
        return contatocrmoperador;
    }

    public ContatoCRMOperadorResponse? Read(DBContatoCRMOperador dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmoperador = new ContatoCRMOperadorResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            CargoEsc = dbRec.FCargoEsc,
            Operador = dbRec.FOperador,
        };
        return contatocrmoperador;
    }

    public ContatoCRMOperadorResponseAll? ReadAll(DBContatoCRMOperador dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmoperador = new ContatoCRMOperadorResponseAll
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            CargoEsc = dbRec.FCargoEsc,
            Operador = dbRec.FOperador,
        };
        contatocrmoperador.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return contatocrmoperador;
    }

    public ContatoCRMOperadorResponseAll? ReadAll(DBContatoCRMOperador dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmoperador = new ContatoCRMOperadorResponseAll
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            CargoEsc = dbRec.FCargoEsc,
            Operador = dbRec.FOperador,
        };
        contatocrmoperador.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return contatocrmoperador;
    }
}