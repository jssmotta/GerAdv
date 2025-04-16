#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContaCorrenteWriter
{
    Entity.DBContaCorrente Write(Models.ContaCorrente contacorrente, int auditorQuem, SqlConnection oCnn);
}

public class ContaCorrente : IContaCorrenteWriter
{
    public Entity.DBContaCorrente Write(Models.ContaCorrente contacorrente, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = contacorrente.Id.IsEmptyIDNumber() ? new Entity.DBContaCorrente() : new Entity.DBContaCorrente(contacorrente.Id, oCnn);
        dbRec.FCIAcordo = contacorrente.CIAcordo;
        dbRec.FQuitado = contacorrente.Quitado;
        dbRec.FIDContrato = contacorrente.IDContrato;
        dbRec.FQuitadoID = contacorrente.QuitadoID;
        dbRec.FDebitoID = contacorrente.DebitoID;
        dbRec.FLivroCaixaID = contacorrente.LivroCaixaID;
        dbRec.FSucumbencia = contacorrente.Sucumbencia;
        dbRec.FDistRegra = contacorrente.DistRegra;
        if (contacorrente.DtOriginal != null)
            dbRec.FDtOriginal = contacorrente.DtOriginal.ToString();
        dbRec.FProcesso = contacorrente.Processo;
        dbRec.FParcelaX = contacorrente.ParcelaX;
        dbRec.FValor = contacorrente.Valor;
        if (contacorrente.Data != null)
            dbRec.FData = contacorrente.Data.ToString();
        dbRec.FCliente = contacorrente.Cliente;
        dbRec.FHistorico = contacorrente.Historico;
        dbRec.FContrato = contacorrente.Contrato;
        dbRec.FPago = contacorrente.Pago;
        dbRec.FDistribuir = contacorrente.Distribuir;
        dbRec.FLC = contacorrente.LC;
        dbRec.FIDHTrab = contacorrente.IDHTrab;
        dbRec.FNroParcelas = contacorrente.NroParcelas;
        dbRec.FValorPrincipal = contacorrente.ValorPrincipal;
        dbRec.FParcelaPrincipalID = contacorrente.ParcelaPrincipalID;
        dbRec.FHide = contacorrente.Hide;
        if (contacorrente.DataPgto != null)
            dbRec.FDataPgto = contacorrente.DataPgto.ToString();
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}