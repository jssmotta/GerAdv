#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRelatorioReader
{
    AgendaRelatorioResponse? Read(DBAgendaRelatorio dbRec);
    AgendaRelatorioResponseAll? ReadAll(DBAgendaRelatorio dbRec, DataRow dr);
    AgendaRelatorioResponseAll? ReadAll(DBAgendaRelatorio dbRec, SqlDataReader dr);
    IEnumerable<AgendaRelatorioResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AgendaRelatorio : IAgendaRelatorioReader
{
    public IEnumerable<AgendaRelatorioResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AgendaRelatorioResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AgendaRelatorioResponseAll>> ReadLocalAsync()
        {
            var result = new List<AgendaRelatorioResponseAll>(max);
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
                result.Add(ReadAll(new DBAgendaRelatorio(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AgendaRelatorio".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}advNome");
        }

        return query.ToString();
    }

    public AgendaRelatorioResponse? Read(DBAgendaRelatorio dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarelatorio = new AgendaRelatorioResponse
        {
            Id = dbRec.ID,
            Data = dbRec.FData ?? string.Empty,
            Processo = dbRec.FProcesso,
            ParaNome = dbRec.FParaNome ?? string.Empty,
            ParaPessoas = dbRec.FParaPessoas ?? string.Empty,
            BoxAudiencia = dbRec.FBoxAudiencia ?? string.Empty,
            BoxAudienciaMobile = dbRec.FBoxAudienciaMobile ?? string.Empty,
            NomeAdvogado = dbRec.FNomeAdvogado ?? string.Empty,
            NomeForo = dbRec.FNomeForo ?? string.Empty,
            NomeJustica = dbRec.FNomeJustica ?? string.Empty,
            NomeArea = dbRec.FNomeArea ?? string.Empty,
        };
        return agendarelatorio;
    }

    public AgendaRelatorioResponseAll? ReadAll(DBAgendaRelatorio dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarelatorio = new AgendaRelatorioResponseAll
        {
            Id = dbRec.ID,
            Data = dbRec.FData ?? string.Empty,
            Processo = dbRec.FProcesso,
            ParaNome = dbRec.FParaNome ?? string.Empty,
            ParaPessoas = dbRec.FParaPessoas ?? string.Empty,
            BoxAudiencia = dbRec.FBoxAudiencia ?? string.Empty,
            BoxAudienciaMobile = dbRec.FBoxAudienciaMobile ?? string.Empty,
            NomeAdvogado = dbRec.FNomeAdvogado ?? string.Empty,
            NomeForo = dbRec.FNomeForo ?? string.Empty,
            NomeJustica = dbRec.FNomeJustica ?? string.Empty,
            NomeArea = dbRec.FNomeArea ?? string.Empty,
        };
        agendarelatorio.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return agendarelatorio;
    }

    public AgendaRelatorioResponseAll? ReadAll(DBAgendaRelatorio dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarelatorio = new AgendaRelatorioResponseAll
        {
            Id = dbRec.ID,
            Data = dbRec.FData ?? string.Empty,
            Processo = dbRec.FProcesso,
            ParaNome = dbRec.FParaNome ?? string.Empty,
            ParaPessoas = dbRec.FParaPessoas ?? string.Empty,
            BoxAudiencia = dbRec.FBoxAudiencia ?? string.Empty,
            BoxAudienciaMobile = dbRec.FBoxAudienciaMobile ?? string.Empty,
            NomeAdvogado = dbRec.FNomeAdvogado ?? string.Empty,
            NomeForo = dbRec.FNomeForo ?? string.Empty,
            NomeJustica = dbRec.FNomeJustica ?? string.Empty,
            NomeArea = dbRec.FNomeArea ?? string.Empty,
        };
        agendarelatorio.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return agendarelatorio;
    }
}