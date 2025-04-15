namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContaCorrente
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBContaCorrenteDicInfo.CIAcordo:
                FCIAcordo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.Quitado:
                FQuitado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContaCorrenteDicInfo.IDContrato:
                FIDContrato = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.QuitadoID:
                FQuitadoID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.DebitoID:
                FDebitoID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.LivroCaixaID:
                FLivroCaixaID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.Sucumbencia:
                FSucumbencia = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContaCorrenteDicInfo.DistRegra:
                FDistRegra = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContaCorrenteDicInfo.DtOriginal:
                FDtOriginal = $"{value}"; // rgo J3: DateTime
                return;
            case DBContaCorrenteDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.ParcelaX:
                FParcelaX = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBContaCorrenteDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBContaCorrenteDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.Historico:
                FHistorico = $"{value}"; // rgo J3: string
                return;
            case DBContaCorrenteDicInfo.Contrato:
                FContrato = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContaCorrenteDicInfo.Pago:
                FPago = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContaCorrenteDicInfo.Distribuir:
                FDistribuir = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContaCorrenteDicInfo.LC:
                FLC = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContaCorrenteDicInfo.IDHTrab:
                FIDHTrab = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.NroParcelas:
                FNroParcelas = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.ValorPrincipal:
                FValorPrincipal = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBContaCorrenteDicInfo.ParcelaPrincipalID:
                FParcelaPrincipalID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.Hide:
                FHide = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContaCorrenteDicInfo.DataPgto:
                FDataPgto = $"{value}"; // rgo J3: DateTime
                return;
            case DBContaCorrenteDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBContaCorrenteDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBContaCorrenteDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContaCorrenteDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBContaCorrenteDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBContaCorrenteDicInfo.CIAcordo => NFCIAcordo(),
        DBContaCorrenteDicInfo.Quitado => FQuitado.ToString(),
        DBContaCorrenteDicInfo.IDContrato => NFIDContrato(),
        DBContaCorrenteDicInfo.QuitadoID => NFQuitadoID(),
        DBContaCorrenteDicInfo.DebitoID => NFDebitoID(),
        DBContaCorrenteDicInfo.LivroCaixaID => NFLivroCaixaID(),
        DBContaCorrenteDicInfo.Sucumbencia => FSucumbencia.ToString(),
        DBContaCorrenteDicInfo.DistRegra => FDistRegra.ToString(),
        DBContaCorrenteDicInfo.DtOriginal => NFDtOriginal(),
        DBContaCorrenteDicInfo.Processo => NFProcesso(),
        DBContaCorrenteDicInfo.ParcelaX => NFParcelaX(),
        DBContaCorrenteDicInfo.Valor => NFValor(),
        DBContaCorrenteDicInfo.Data => NFData(),
        DBContaCorrenteDicInfo.Cliente => NFCliente(),
        DBContaCorrenteDicInfo.Historico => NFHistorico(),
        DBContaCorrenteDicInfo.Contrato => FContrato.ToString(),
        DBContaCorrenteDicInfo.Pago => FPago.ToString(),
        DBContaCorrenteDicInfo.Distribuir => FDistribuir.ToString(),
        DBContaCorrenteDicInfo.LC => FLC.ToString(),
        DBContaCorrenteDicInfo.IDHTrab => NFIDHTrab(),
        DBContaCorrenteDicInfo.NroParcelas => NFNroParcelas(),
        DBContaCorrenteDicInfo.ValorPrincipal => NFValorPrincipal(),
        DBContaCorrenteDicInfo.ParcelaPrincipalID => NFParcelaPrincipalID(),
        DBContaCorrenteDicInfo.Hide => FHide.ToString(),
        DBContaCorrenteDicInfo.DataPgto => NFDataPgto(),
        DBContaCorrenteDicInfo.GUID => NFGUID(),
        DBContaCorrenteDicInfo.QuemCad => NFQuemCad(),
        DBContaCorrenteDicInfo.DtCad => MDtCad,
        DBContaCorrenteDicInfo.QuemAtu => NFQuemAtu(),
        DBContaCorrenteDicInfo.DtAtu => MDtAtu,
        DBContaCorrenteDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}