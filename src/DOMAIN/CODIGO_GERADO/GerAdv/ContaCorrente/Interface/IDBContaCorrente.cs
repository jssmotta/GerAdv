namespace MenphisSI.GerAdv.Interface;
public partial interface IDBContaCorrente
{
    public int ID { get; set; }
    public int FCIAcordo { get; set; }
    public bool FQuitado { get; set; }
    public int FIDContrato { get; set; }
    public int FQuitadoID { get; set; }
    public int FDebitoID { get; set; }
    public int FLivroCaixaID { get; set; }
    public bool FSucumbencia { get; set; }
    public bool FDistRegra { get; set; }
    public string? FDtOriginal { get; set; }
    public int FProcesso { get; set; }
    public int FParcelaX { get; set; }
    public decimal FValor { get; set; }
    public string? FData { get; set; }
    public int FCliente { get; set; }
    public string? FHistorico { get; set; }
    public bool FContrato { get; set; }
    public bool FPago { get; set; }
    public bool FDistribuir { get; set; }
    public bool FLC { get; set; }
    public int FIDHTrab { get; set; }
    public int FNroParcelas { get; set; }
    public decimal FValorPrincipal { get; set; }
    public int FParcelaPrincipalID { get; set; }
    public bool FHide { get; set; }
    public string? FDataPgto { get; set; }
    public string? FGUID { get; set; }
}