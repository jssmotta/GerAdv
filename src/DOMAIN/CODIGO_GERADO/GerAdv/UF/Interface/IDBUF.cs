namespace MenphisSI.GerAdv.Interface;
public partial interface IDBUF
{
    public int ID { get; set; }
    public string? FDDD { get; set; }
    public string? FID { get; set; }
    public int FPais { get; set; }
    public bool FTop { get; set; }
    public string? FDescricao { get; set; }
    public string? FGUID { get; set; }
}