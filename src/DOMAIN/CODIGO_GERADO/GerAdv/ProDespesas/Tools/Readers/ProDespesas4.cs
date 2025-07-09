#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDespesasReader
{
    ProDespesasResponse? Read(int id, MsiSqlConnection oCnn);
    ProDespesasResponse? Read(Entity.DBProDespesas dbRec, MsiSqlConnection oCnn);
    ProDespesasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProDespesasResponse? Read(Entity.DBProDespesas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProDespesasResponse? Read(DBProDespesas dbRec);
    ProDespesasResponseAll? ReadAll(DBProDespesas dbRec, DataRow dr);
    ProDespesasResponseAll? ReadAll(DBProDespesas dbRec, SqlDataReader dr);
    IEnumerable<ProDespesasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProDespesas : IProDespesasReader
{
    public IEnumerable<ProDespesasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProDespesasResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProDespesasResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProDespesasResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProDespesas(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProDespesas".dbo(oCnn)} (NOLOCK) ");
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

    public ProDespesasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDespesas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDespesasResponse? Read(Entity.DBProDespesas dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProDespesasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDespesas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDespesasResponse? Read(Entity.DBProDespesas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodespesas = new ProDespesasResponse
        {
            Id = dbRec.ID,
            LigacaoID = dbRec.FLigacaoID,
            Cliente = dbRec.FCliente,
            Corrigido = dbRec.FCorrigido,
            ValorOriginal = dbRec.FValorOriginal,
            Processo = dbRec.FProcesso,
            Quitado = dbRec.FQuitado,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            LivroCaixa = dbRec.FLivroCaixa,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodespesas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataCorrecao, out _))
            prodespesas.DataCorrecao = dbRec.FDataCorrecao;
        return prodespesas;
    }

    public ProDespesasResponse? Read(DBProDespesas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodespesas = new ProDespesasResponse
        {
            Id = dbRec.ID,
            LigacaoID = dbRec.FLigacaoID,
            Cliente = dbRec.FCliente,
            Corrigido = dbRec.FCorrigido,
            ValorOriginal = dbRec.FValorOriginal,
            Processo = dbRec.FProcesso,
            Quitado = dbRec.FQuitado,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            LivroCaixa = dbRec.FLivroCaixa,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodespesas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataCorrecao, out _))
            prodespesas.DataCorrecao = dbRec.FDataCorrecao;
        return prodespesas;
    }

    public ProDespesasResponseAll? ReadAll(DBProDespesas dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodespesas = new ProDespesasResponseAll
        {
            Id = dbRec.ID,
            LigacaoID = dbRec.FLigacaoID,
            Cliente = dbRec.FCliente,
            Corrigido = dbRec.FCorrigido,
            ValorOriginal = dbRec.FValorOriginal,
            Processo = dbRec.FProcesso,
            Quitado = dbRec.FQuitado,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            LivroCaixa = dbRec.FLivroCaixa,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodespesas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataCorrecao, out _))
            prodespesas.DataCorrecao = dbRec.FDataCorrecao;
        prodespesas.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        prodespesas.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return prodespesas;
    }

    public ProDespesasResponseAll? ReadAll(DBProDespesas dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodespesas = new ProDespesasResponseAll
        {
            Id = dbRec.ID,
            LigacaoID = dbRec.FLigacaoID,
            Cliente = dbRec.FCliente,
            Corrigido = dbRec.FCorrigido,
            ValorOriginal = dbRec.FValorOriginal,
            Processo = dbRec.FProcesso,
            Quitado = dbRec.FQuitado,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            LivroCaixa = dbRec.FLivroCaixa,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodespesas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataCorrecao, out _))
            prodespesas.DataCorrecao = dbRec.FDataCorrecao;
        prodespesas.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        prodespesas.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return prodespesas;
    }
}