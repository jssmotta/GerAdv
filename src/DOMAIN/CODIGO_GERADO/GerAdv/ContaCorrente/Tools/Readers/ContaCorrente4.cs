#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContaCorrenteReader
{
    ContaCorrenteResponse? Read(int id, MsiSqlConnection oCnn);
    ContaCorrenteResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContaCorrenteResponse? Read(Entity.DBContaCorrente dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContaCorrenteResponse? Read(DBContaCorrente dbRec);
    ContaCorrenteResponseAll? ReadAll(DBContaCorrente dbRec, DataRow dr);
}

public partial class ContaCorrente : IContaCorrenteReader
{
    public ContaCorrenteResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContaCorrente(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
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
}