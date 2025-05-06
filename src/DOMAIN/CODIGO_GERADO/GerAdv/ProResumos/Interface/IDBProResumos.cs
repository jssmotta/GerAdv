namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProResumos
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public string? FData { get; set; }
    public string? FResumo { get; set; }
    public int FTipoResumo { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}