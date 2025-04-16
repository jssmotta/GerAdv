namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProCDA
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public string? FNome { get; set; }
    public string? FNroInterno { get; set; }
    public bool FBold { get; set; }
}