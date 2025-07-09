#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosParadosReader
{
    ProcessosParadosResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessosParadosResponse? Read(Entity.DBProcessosParados dbRec, MsiSqlConnection oCnn);
    ProcessosParadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessosParadosResponse? Read(Entity.DBProcessosParados dbRec);
    ProcessosParadosResponse? Read(DBProcessosParados dbRec);
    ProcessosParadosResponseAll? ReadAll(DBProcessosParados dbRec, DataRow dr);
    ProcessosParadosResponseAll? ReadAll(DBProcessosParados dbRec, SqlDataReader dr);
    IEnumerable<ProcessosParadosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProcessosParados : IProcessosParadosReader
{
    public IEnumerable<ProcessosParadosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProcessosParadosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProcessosParadosResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProcessosParadosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProcessosParados(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProcessosParados".dbo(oCnn)} (NOLOCK) ");
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

    public ProcessosParadosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosParados(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosParadosResponse? Read(Entity.DBProcessosParados dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProcessosParadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosParados(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosParadosResponse? Read(Entity.DBProcessosParados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosparados = new ProcessosParadosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Semana = dbRec.FSemana,
            Ano = dbRec.FAno,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            processosparados.DataHora = dbRec.FDataHora;
        if (DateTime.TryParse(dbRec.FDataHistorico, out _))
            processosparados.DataHistorico = dbRec.FDataHistorico;
        if (DateTime.TryParse(dbRec.FDataNENotas, out _))
            processosparados.DataNENotas = dbRec.FDataNENotas;
        return processosparados;
    }

    public ProcessosParadosResponse? Read(DBProcessosParados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosparados = new ProcessosParadosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Semana = dbRec.FSemana,
            Ano = dbRec.FAno,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            processosparados.DataHora = dbRec.FDataHora;
        if (DateTime.TryParse(dbRec.FDataHistorico, out _))
            processosparados.DataHistorico = dbRec.FDataHistorico;
        if (DateTime.TryParse(dbRec.FDataNENotas, out _))
            processosparados.DataNENotas = dbRec.FDataNENotas;
        return processosparados;
    }

    public ProcessosParadosResponseAll? ReadAll(DBProcessosParados dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosparados = new ProcessosParadosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Semana = dbRec.FSemana,
            Ano = dbRec.FAno,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            processosparados.DataHora = dbRec.FDataHora;
        if (DateTime.TryParse(dbRec.FDataHistorico, out _))
            processosparados.DataHistorico = dbRec.FDataHistorico;
        if (DateTime.TryParse(dbRec.FDataNENotas, out _))
            processosparados.DataNENotas = dbRec.FDataNENotas;
        processosparados.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        processosparados.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return processosparados;
    }

    public ProcessosParadosResponseAll? ReadAll(DBProcessosParados dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosparados = new ProcessosParadosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Semana = dbRec.FSemana,
            Ano = dbRec.FAno,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            processosparados.DataHora = dbRec.FDataHora;
        if (DateTime.TryParse(dbRec.FDataHistorico, out _))
            processosparados.DataHistorico = dbRec.FDataHistorico;
        if (DateTime.TryParse(dbRec.FDataNENotas, out _))
            processosparados.DataNENotas = dbRec.FDataNENotas;
        processosparados.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        processosparados.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return processosparados;
    }
}