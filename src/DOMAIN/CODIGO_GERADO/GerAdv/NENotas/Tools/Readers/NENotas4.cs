#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INENotasReader
{
    NENotasResponse? Read(int id, MsiSqlConnection oCnn);
    NENotasResponse? Read(Entity.DBNENotas dbRec, MsiSqlConnection oCnn);
    NENotasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NENotasResponse? Read(Entity.DBNENotas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NENotasResponse? Read(DBNENotas dbRec);
    NENotasResponseAll? ReadAll(DBNENotas dbRec, DataRow dr);
    NENotasResponseAll? ReadAll(DBNENotas dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<NENotasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class NENotas : INENotasReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{nepCodigo, nepNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<NENotasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<NENotasResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<NENotasResponseAll>> ReadLocalAsync()
        {
            var result = new List<NENotasResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBNENotas(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"NENotas".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}nepNome");
        }

        return query.ToString();
    }

    public NENotasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNENotas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NENotasResponse? Read(Entity.DBNENotas dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public NENotasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNENotas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NENotasResponse? Read(Entity.DBNENotas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nenotas = new NENotasResponse
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
        return nenotas;
    }

    public NENotasResponse? Read(DBNENotas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nenotas = new NENotasResponse
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
        return nenotas;
    }

    public NENotasResponseAll? ReadAll(DBNENotas dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nenotas = new NENotasResponseAll
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
        nenotas.NroProcessoInstancia = dr["insNroProcesso"]?.ToString() ?? string.Empty;
        nenotas.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return nenotas;
    }

    public NENotasResponseAll? ReadAll(DBNENotas dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nenotas = new NENotasResponseAll
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
        nenotas.NroProcessoInstancia = dr["insNroProcesso"]?.ToString() ?? string.Empty;
        nenotas.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return nenotas;
    }
}