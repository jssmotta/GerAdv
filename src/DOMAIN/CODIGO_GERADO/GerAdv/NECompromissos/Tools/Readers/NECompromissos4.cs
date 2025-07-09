#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INECompromissosReader
{
    NECompromissosResponse? Read(int id, MsiSqlConnection oCnn);
    NECompromissosResponse? Read(Entity.DBNECompromissos dbRec, MsiSqlConnection oCnn);
    NECompromissosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NECompromissosResponse? Read(Entity.DBNECompromissos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NECompromissosResponse? Read(DBNECompromissos dbRec);
    NECompromissosResponseAll? ReadAll(DBNECompromissos dbRec, DataRow dr);
    NECompromissosResponseAll? ReadAll(DBNECompromissos dbRec, SqlDataReader dr);
    IEnumerable<NECompromissosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class NECompromissos : INECompromissosReader
{
    public IEnumerable<NECompromissosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<NECompromissosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<NECompromissosResponseAll>> ReadLocalAsync()
        {
            var result = new List<NECompromissosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBNECompromissos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"NECompromissos".dbo(oCnn)} (NOLOCK) ");
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

    public NECompromissosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNECompromissos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NECompromissosResponse? Read(Entity.DBNECompromissos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public NECompromissosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNECompromissos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NECompromissosResponse? Read(Entity.DBNECompromissos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var necompromissos = new NECompromissosResponse
        {
            Id = dbRec.ID,
            PalavraChave = dbRec.FPalavraChave,
            Provisionar = dbRec.FProvisionar,
            TipoCompromisso = dbRec.FTipoCompromisso,
            TextoCompromisso = dbRec.FTextoCompromisso ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return necompromissos;
    }

    public NECompromissosResponse? Read(DBNECompromissos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var necompromissos = new NECompromissosResponse
        {
            Id = dbRec.ID,
            PalavraChave = dbRec.FPalavraChave,
            Provisionar = dbRec.FProvisionar,
            TipoCompromisso = dbRec.FTipoCompromisso,
            TextoCompromisso = dbRec.FTextoCompromisso ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return necompromissos;
    }

    public NECompromissosResponseAll? ReadAll(DBNECompromissos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var necompromissos = new NECompromissosResponseAll
        {
            Id = dbRec.ID,
            PalavraChave = dbRec.FPalavraChave,
            Provisionar = dbRec.FProvisionar,
            TipoCompromisso = dbRec.FTipoCompromisso,
            TextoCompromisso = dbRec.FTextoCompromisso ?? string.Empty,
            Bold = dbRec.FBold,
        };
        necompromissos.DescricaoTipoCompromisso = dr["tipDescricao"]?.ToString() ?? string.Empty;
        return necompromissos;
    }

    public NECompromissosResponseAll? ReadAll(DBNECompromissos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var necompromissos = new NECompromissosResponseAll
        {
            Id = dbRec.ID,
            PalavraChave = dbRec.FPalavraChave,
            Provisionar = dbRec.FProvisionar,
            TipoCompromisso = dbRec.FTipoCompromisso,
            TextoCompromisso = dbRec.FTextoCompromisso ?? string.Empty,
            Bold = dbRec.FBold,
        };
        necompromissos.DescricaoTipoCompromisso = dr["tipDescricao"]?.ToString() ?? string.Empty;
        return necompromissos;
    }
}