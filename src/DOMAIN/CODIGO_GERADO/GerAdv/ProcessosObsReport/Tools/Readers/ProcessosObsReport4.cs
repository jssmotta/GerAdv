#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosObsReportReader
{
    ProcessosObsReportResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessosObsReportResponse? Read(Entity.DBProcessosObsReport dbRec, MsiSqlConnection oCnn);
    ProcessosObsReportResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessosObsReportResponse? Read(Entity.DBProcessosObsReport dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessosObsReportResponse? Read(DBProcessosObsReport dbRec);
    ProcessosObsReportResponseAll? ReadAll(DBProcessosObsReport dbRec, DataRow dr);
    ProcessosObsReportResponseAll? ReadAll(DBProcessosObsReport dbRec, SqlDataReader dr);
    IEnumerable<ProcessosObsReportResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProcessosObsReport : IProcessosObsReportReader
{
    public IEnumerable<ProcessosObsReportResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProcessosObsReportResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProcessosObsReportResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProcessosObsReportResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProcessosObsReport(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProcessosObsReport".dbo(oCnn)} (NOLOCK) ");
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

    public ProcessosObsReportResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosObsReport(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosObsReportResponse? Read(Entity.DBProcessosObsReport dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProcessosObsReportResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosObsReport(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosObsReportResponse? Read(Entity.DBProcessosObsReport dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosobsreport = new ProcessosObsReportResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Historico = dbRec.FHistorico,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            processosobsreport.Data = dbRec.FData;
        return processosobsreport;
    }

    public ProcessosObsReportResponse? Read(DBProcessosObsReport dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosobsreport = new ProcessosObsReportResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Historico = dbRec.FHistorico,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            processosobsreport.Data = dbRec.FData;
        return processosobsreport;
    }

    public ProcessosObsReportResponseAll? ReadAll(DBProcessosObsReport dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosobsreport = new ProcessosObsReportResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Historico = dbRec.FHistorico,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            processosobsreport.Data = dbRec.FData;
        processosobsreport.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return processosobsreport;
    }

    public ProcessosObsReportResponseAll? ReadAll(DBProcessosObsReport dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosobsreport = new ProcessosObsReportResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Historico = dbRec.FHistorico,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            processosobsreport.Data = dbRec.FData;
        processosobsreport.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return processosobsreport;
    }
}