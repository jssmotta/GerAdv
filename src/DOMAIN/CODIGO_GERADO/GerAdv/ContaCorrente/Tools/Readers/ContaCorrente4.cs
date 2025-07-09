#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContaCorrenteReader
{
    ContaCorrenteResponse? Read(int id, MsiSqlConnection oCnn);
    ContaCorrenteResponse? Read(Entity.DBContaCorrente dbRec, MsiSqlConnection oCnn);
    ContaCorrenteResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContaCorrenteResponse? Read(Entity.DBContaCorrente dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContaCorrenteResponse? Read(DBContaCorrente dbRec);
    ContaCorrenteResponseAll? ReadAll(DBContaCorrente dbRec, DataRow dr);
    ContaCorrenteResponseAll? ReadAll(DBContaCorrente dbRec, SqlDataReader dr);
    IEnumerable<ContaCorrenteResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ContaCorrente : IContaCorrenteReader
{
    public IEnumerable<ContaCorrenteResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ContaCorrenteResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ContaCorrenteResponseAll>> ReadLocalAsync()
        {
            var result = new List<ContaCorrenteResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBContaCorrente(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ContaCorrente".dbo(oCnn)} (NOLOCK) ");
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

    public ContaCorrenteResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContaCorrente(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContaCorrenteResponse? Read(Entity.DBContaCorrente dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ContaCorrenteResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContaCorrente(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContaCorrenteResponse? Read(Entity.DBContaCorrente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contacorrente = new ContaCorrenteResponse
        {
            Id = dbRec.ID,
            CIAcordo = dbRec.FCIAcordo,
            Quitado = dbRec.FQuitado,
            IDContrato = dbRec.FIDContrato,
            QuitadoID = dbRec.FQuitadoID,
            DebitoID = dbRec.FDebitoID,
            LivroCaixaID = dbRec.FLivroCaixaID,
            Sucumbencia = dbRec.FSucumbencia,
            DistRegra = dbRec.FDistRegra,
            Processo = dbRec.FProcesso,
            ParcelaX = dbRec.FParcelaX,
            Valor = dbRec.FValor,
            Cliente = dbRec.FCliente,
            Historico = dbRec.FHistorico ?? string.Empty,
            Contrato = dbRec.FContrato,
            Pago = dbRec.FPago,
            Distribuir = dbRec.FDistribuir,
            LC = dbRec.FLC,
            IDHTrab = dbRec.FIDHTrab,
            NroParcelas = dbRec.FNroParcelas,
            ValorPrincipal = dbRec.FValorPrincipal,
            ParcelaPrincipalID = dbRec.FParcelaPrincipalID,
            Hide = dbRec.FHide,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtOriginal, out _))
            contacorrente.DtOriginal = dbRec.FDtOriginal;
        if (DateTime.TryParse(dbRec.FData, out _))
            contacorrente.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataPgto, out _))
            contacorrente.DataPgto = dbRec.FDataPgto;
        return contacorrente;
    }

    public ContaCorrenteResponse? Read(DBContaCorrente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contacorrente = new ContaCorrenteResponse
        {
            Id = dbRec.ID,
            CIAcordo = dbRec.FCIAcordo,
            Quitado = dbRec.FQuitado,
            IDContrato = dbRec.FIDContrato,
            QuitadoID = dbRec.FQuitadoID,
            DebitoID = dbRec.FDebitoID,
            LivroCaixaID = dbRec.FLivroCaixaID,
            Sucumbencia = dbRec.FSucumbencia,
            DistRegra = dbRec.FDistRegra,
            Processo = dbRec.FProcesso,
            ParcelaX = dbRec.FParcelaX,
            Valor = dbRec.FValor,
            Cliente = dbRec.FCliente,
            Historico = dbRec.FHistorico ?? string.Empty,
            Contrato = dbRec.FContrato,
            Pago = dbRec.FPago,
            Distribuir = dbRec.FDistribuir,
            LC = dbRec.FLC,
            IDHTrab = dbRec.FIDHTrab,
            NroParcelas = dbRec.FNroParcelas,
            ValorPrincipal = dbRec.FValorPrincipal,
            ParcelaPrincipalID = dbRec.FParcelaPrincipalID,
            Hide = dbRec.FHide,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtOriginal, out _))
            contacorrente.DtOriginal = dbRec.FDtOriginal;
        if (DateTime.TryParse(dbRec.FData, out _))
            contacorrente.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataPgto, out _))
            contacorrente.DataPgto = dbRec.FDataPgto;
        return contacorrente;
    }

    public ContaCorrenteResponseAll? ReadAll(DBContaCorrente dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contacorrente = new ContaCorrenteResponseAll
        {
            Id = dbRec.ID,
            CIAcordo = dbRec.FCIAcordo,
            Quitado = dbRec.FQuitado,
            IDContrato = dbRec.FIDContrato,
            QuitadoID = dbRec.FQuitadoID,
            DebitoID = dbRec.FDebitoID,
            LivroCaixaID = dbRec.FLivroCaixaID,
            Sucumbencia = dbRec.FSucumbencia,
            DistRegra = dbRec.FDistRegra,
            Processo = dbRec.FProcesso,
            ParcelaX = dbRec.FParcelaX,
            Valor = dbRec.FValor,
            Cliente = dbRec.FCliente,
            Historico = dbRec.FHistorico ?? string.Empty,
            Contrato = dbRec.FContrato,
            Pago = dbRec.FPago,
            Distribuir = dbRec.FDistribuir,
            LC = dbRec.FLC,
            IDHTrab = dbRec.FIDHTrab,
            NroParcelas = dbRec.FNroParcelas,
            ValorPrincipal = dbRec.FValorPrincipal,
            ParcelaPrincipalID = dbRec.FParcelaPrincipalID,
            Hide = dbRec.FHide,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtOriginal, out _))
            contacorrente.DtOriginal = dbRec.FDtOriginal;
        if (DateTime.TryParse(dbRec.FData, out _))
            contacorrente.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataPgto, out _))
            contacorrente.DataPgto = dbRec.FDataPgto;
        contacorrente.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        contacorrente.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return contacorrente;
    }

    public ContaCorrenteResponseAll? ReadAll(DBContaCorrente dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contacorrente = new ContaCorrenteResponseAll
        {
            Id = dbRec.ID,
            CIAcordo = dbRec.FCIAcordo,
            Quitado = dbRec.FQuitado,
            IDContrato = dbRec.FIDContrato,
            QuitadoID = dbRec.FQuitadoID,
            DebitoID = dbRec.FDebitoID,
            LivroCaixaID = dbRec.FLivroCaixaID,
            Sucumbencia = dbRec.FSucumbencia,
            DistRegra = dbRec.FDistRegra,
            Processo = dbRec.FProcesso,
            ParcelaX = dbRec.FParcelaX,
            Valor = dbRec.FValor,
            Cliente = dbRec.FCliente,
            Historico = dbRec.FHistorico ?? string.Empty,
            Contrato = dbRec.FContrato,
            Pago = dbRec.FPago,
            Distribuir = dbRec.FDistribuir,
            LC = dbRec.FLC,
            IDHTrab = dbRec.FIDHTrab,
            NroParcelas = dbRec.FNroParcelas,
            ValorPrincipal = dbRec.FValorPrincipal,
            ParcelaPrincipalID = dbRec.FParcelaPrincipalID,
            Hide = dbRec.FHide,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtOriginal, out _))
            contacorrente.DtOriginal = dbRec.FDtOriginal;
        if (DateTime.TryParse(dbRec.FData, out _))
            contacorrente.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataPgto, out _))
            contacorrente.DataPgto = dbRec.FDataPgto;
        contacorrente.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        contacorrente.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return contacorrente;
    }
}