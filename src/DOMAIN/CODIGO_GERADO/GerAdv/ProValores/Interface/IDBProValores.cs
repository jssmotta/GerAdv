namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProValores
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public int FTipoValorProcesso { get; set; }
    public string? FIndice { get; set; }
    public bool FIgnorar { get; set; }
    public string? FData { get; set; }
    public decimal FValorOriginal { get; set; }
    public decimal FPercMulta { get; set; }
    public decimal FValorMulta { get; set; }
    public decimal FPercJuros { get; set; }
    public decimal FValorOriginalCorrigidoIndice { get; set; }
    public decimal FValorMultaCorrigido { get; set; }
    public decimal FValorJurosCorrigido { get; set; }
    public decimal FValorFinal { get; set; }
    public string? FDataUltimaCorrecao { get; set; }
    public string? FGUID { get; set; }
}