namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProDepositos
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public int FFase { get; set; }
    public string? FData { get; set; }
    public decimal FValor { get; set; }
    public int FTipoProDesposito { get; set; }
}