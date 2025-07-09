#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaSemanaReader
{
    AgendaSemanaResponse? Read(DBAgendaSemana dbRec);
    AgendaSemanaResponseAll? ReadAll(DBAgendaSemana dbRec, DataRow dr);
    AgendaSemanaResponseAll? ReadAll(DBAgendaSemana dbRec, SqlDataReader dr);
    IEnumerable<AgendaSemanaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AgendaSemana : IAgendaSemanaReader
{
    public IEnumerable<AgendaSemanaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AgendaSemanaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AgendaSemanaResponseAll>> ReadLocalAsync()
        {
            var result = new List<AgendaSemanaResponseAll>(max);
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
                result.Add(ReadAll(new DBAgendaSemana(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AgendaSemana".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}xxxParaNome");
        }

        return query.ToString();
    }

    public AgendaSemanaResponse? Read(DBAgendaSemana dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendasemana = new AgendaSemanaResponse
        {
            Id = dbRec.ID,
            ParaNome = dbRec.FParaNome ?? string.Empty,
            Data = dbRec.FData ?? string.Empty,
            Funcionario = dbRec.FFuncionario,
            Advogado = dbRec.FAdvogado,
            Hora = dbRec.FHora ?? string.Empty,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Liberado = dbRec.FLiberado,
            Importante = dbRec.FImportante,
            HoraFinal = dbRec.FHoraFinal ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Cliente = dbRec.FCliente,
            NomeCliente = dbRec.FNomeCliente ?? string.Empty,
            Tipo = dbRec.FTipo ?? string.Empty,
        };
        return agendasemana;
    }

    public AgendaSemanaResponseAll? ReadAll(DBAgendaSemana dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendasemana = new AgendaSemanaResponseAll
        {
            Id = dbRec.ID,
            ParaNome = dbRec.FParaNome ?? string.Empty,
            Data = dbRec.FData ?? string.Empty,
            Funcionario = dbRec.FFuncionario,
            Advogado = dbRec.FAdvogado,
            Hora = dbRec.FHora ?? string.Empty,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Liberado = dbRec.FLiberado,
            Importante = dbRec.FImportante,
            HoraFinal = dbRec.FHoraFinal ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Cliente = dbRec.FCliente,
            NomeCliente = dbRec.FNomeCliente ?? string.Empty,
            Tipo = dbRec.FTipo ?? string.Empty,
        };
        agendasemana.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agendasemana.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agendasemana.DescricaoTipoCompromisso = dr["tipDescricao"]?.ToString() ?? string.Empty;
        agendasemana.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return agendasemana;
    }

    public AgendaSemanaResponseAll? ReadAll(DBAgendaSemana dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendasemana = new AgendaSemanaResponseAll
        {
            Id = dbRec.ID,
            ParaNome = dbRec.FParaNome ?? string.Empty,
            Data = dbRec.FData ?? string.Empty,
            Funcionario = dbRec.FFuncionario,
            Advogado = dbRec.FAdvogado,
            Hora = dbRec.FHora ?? string.Empty,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Liberado = dbRec.FLiberado,
            Importante = dbRec.FImportante,
            HoraFinal = dbRec.FHoraFinal ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Cliente = dbRec.FCliente,
            NomeCliente = dbRec.FNomeCliente ?? string.Empty,
            Tipo = dbRec.FTipo ?? string.Empty,
        };
        agendasemana.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agendasemana.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agendasemana.DescricaoTipoCompromisso = dr["tipDescricao"]?.ToString() ?? string.Empty;
        agendasemana.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return agendasemana;
    }
}