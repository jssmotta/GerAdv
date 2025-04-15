namespace MenphisSI.GerAdv.Interface;
public partial interface IDBGUTMatriz
{
    public int ID { get; set; }
    public string? FDescricao { get; set; }
    public int FGUTTipo { get; set; }
    public int FValor { get; set; }
}