namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProSucumbencia
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public int FInstancia { get; set; }
    public string? FData { get; set; }
    public string? FNome { get; set; }
    public int FTipoOrigemSucumbencia { get; set; }
    public decimal FValor { get; set; }
    public string? FPercentual { get; set; }
}