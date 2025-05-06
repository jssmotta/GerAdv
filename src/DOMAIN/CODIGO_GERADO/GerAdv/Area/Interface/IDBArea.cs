namespace MenphisSI.GerAdv.Interface;
public partial interface IDBArea
{
    public int ID { get; set; }
    public string? FDescricao { get; set; }
    public bool FTop { get; set; }
    public string? FGUID { get; set; }
}