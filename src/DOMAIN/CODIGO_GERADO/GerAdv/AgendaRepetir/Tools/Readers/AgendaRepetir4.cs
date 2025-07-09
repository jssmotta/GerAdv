#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRepetirReader
{
    AgendaRepetirResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaRepetirResponse? Read(Entity.DBAgendaRepetir dbRec, MsiSqlConnection oCnn);
    AgendaRepetirResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaRepetirResponse? Read(Entity.DBAgendaRepetir dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaRepetirResponse? Read(DBAgendaRepetir dbRec);
    AgendaRepetirResponseAll? ReadAll(DBAgendaRepetir dbRec, DataRow dr);
    AgendaRepetirResponseAll? ReadAll(DBAgendaRepetir dbRec, SqlDataReader dr);
    IEnumerable<AgendaRepetirResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AgendaRepetir : IAgendaRepetirReader
{
    public IEnumerable<AgendaRepetirResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AgendaRepetirResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AgendaRepetirResponseAll>> ReadLocalAsync()
        {
            var result = new List<AgendaRepetirResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAgendaRepetir(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AgendaRepetir".dbo(oCnn)} (NOLOCK) ");
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

    public AgendaRepetirResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRepetir(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRepetirResponse? Read(Entity.DBAgendaRepetir dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AgendaRepetirResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRepetir(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRepetirResponse? Read(Entity.DBAgendaRepetir dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetir = new AgendaRepetirResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Cliente = dbRec.FCliente,
            Funcionario = dbRec.FFuncionario,
            Processo = dbRec.FProcesso,
            Pessoal = dbRec.FPessoal,
            Frequencia = dbRec.FFrequencia,
            Dia = dbRec.FDia,
            Mes = dbRec.FMes,
            IDQuem = dbRec.FIDQuem,
            IDQuem2 = dbRec.FIDQuem2,
            Mensagem = dbRec.FMensagem ?? string.Empty,
            IDTipo = dbRec.FIDTipo,
            ID1 = dbRec.FID1,
            ID2 = dbRec.FID2,
            ID3 = dbRec.FID3,
            ID4 = dbRec.FID4,
            Segunda = dbRec.FSegunda,
            Quarta = dbRec.FQuarta,
            Quinta = dbRec.FQuinta,
            Sexta = dbRec.FSexta,
            Sabado = dbRec.FSabado,
            Domingo = dbRec.FDomingo,
            Terca = dbRec.FTerca,
        };
        if (DateTime.TryParse(dbRec.FDataFinal, out _))
            agendarepetir.DataFinal = dbRec.FDataFinal;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetir.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetir.Hora = dbRec.FHora;
        return agendarepetir;
    }

    public AgendaRepetirResponse? Read(DBAgendaRepetir dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetir = new AgendaRepetirResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Cliente = dbRec.FCliente,
            Funcionario = dbRec.FFuncionario,
            Processo = dbRec.FProcesso,
            Pessoal = dbRec.FPessoal,
            Frequencia = dbRec.FFrequencia,
            Dia = dbRec.FDia,
            Mes = dbRec.FMes,
            IDQuem = dbRec.FIDQuem,
            IDQuem2 = dbRec.FIDQuem2,
            Mensagem = dbRec.FMensagem ?? string.Empty,
            IDTipo = dbRec.FIDTipo,
            ID1 = dbRec.FID1,
            ID2 = dbRec.FID2,
            ID3 = dbRec.FID3,
            ID4 = dbRec.FID4,
            Segunda = dbRec.FSegunda,
            Quarta = dbRec.FQuarta,
            Quinta = dbRec.FQuinta,
            Sexta = dbRec.FSexta,
            Sabado = dbRec.FSabado,
            Domingo = dbRec.FDomingo,
            Terca = dbRec.FTerca,
        };
        if (DateTime.TryParse(dbRec.FDataFinal, out _))
            agendarepetir.DataFinal = dbRec.FDataFinal;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetir.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetir.Hora = dbRec.FHora;
        return agendarepetir;
    }

    public AgendaRepetirResponseAll? ReadAll(DBAgendaRepetir dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetir = new AgendaRepetirResponseAll
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Cliente = dbRec.FCliente,
            Funcionario = dbRec.FFuncionario,
            Processo = dbRec.FProcesso,
            Pessoal = dbRec.FPessoal,
            Frequencia = dbRec.FFrequencia,
            Dia = dbRec.FDia,
            Mes = dbRec.FMes,
            IDQuem = dbRec.FIDQuem,
            IDQuem2 = dbRec.FIDQuem2,
            Mensagem = dbRec.FMensagem ?? string.Empty,
            IDTipo = dbRec.FIDTipo,
            ID1 = dbRec.FID1,
            ID2 = dbRec.FID2,
            ID3 = dbRec.FID3,
            ID4 = dbRec.FID4,
            Segunda = dbRec.FSegunda,
            Quarta = dbRec.FQuarta,
            Quinta = dbRec.FQuinta,
            Sexta = dbRec.FSexta,
            Sabado = dbRec.FSabado,
            Domingo = dbRec.FDomingo,
            Terca = dbRec.FTerca,
        };
        if (DateTime.TryParse(dbRec.FDataFinal, out _))
            agendarepetir.DataFinal = dbRec.FDataFinal;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetir.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetir.Hora = dbRec.FHora;
        agendarepetir.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agendarepetir.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        agendarepetir.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agendarepetir.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return agendarepetir;
    }

    public AgendaRepetirResponseAll? ReadAll(DBAgendaRepetir dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetir = new AgendaRepetirResponseAll
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Cliente = dbRec.FCliente,
            Funcionario = dbRec.FFuncionario,
            Processo = dbRec.FProcesso,
            Pessoal = dbRec.FPessoal,
            Frequencia = dbRec.FFrequencia,
            Dia = dbRec.FDia,
            Mes = dbRec.FMes,
            IDQuem = dbRec.FIDQuem,
            IDQuem2 = dbRec.FIDQuem2,
            Mensagem = dbRec.FMensagem ?? string.Empty,
            IDTipo = dbRec.FIDTipo,
            ID1 = dbRec.FID1,
            ID2 = dbRec.FID2,
            ID3 = dbRec.FID3,
            ID4 = dbRec.FID4,
            Segunda = dbRec.FSegunda,
            Quarta = dbRec.FQuarta,
            Quinta = dbRec.FQuinta,
            Sexta = dbRec.FSexta,
            Sabado = dbRec.FSabado,
            Domingo = dbRec.FDomingo,
            Terca = dbRec.FTerca,
        };
        if (DateTime.TryParse(dbRec.FDataFinal, out _))
            agendarepetir.DataFinal = dbRec.FDataFinal;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetir.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetir.Hora = dbRec.FHora;
        agendarepetir.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agendarepetir.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        agendarepetir.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agendarepetir.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return agendarepetir;
    }
}