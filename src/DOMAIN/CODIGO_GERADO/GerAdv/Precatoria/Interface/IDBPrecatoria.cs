namespace MenphisSI.GerAdv.Interface;
public partial interface IDBPrecatoria
{
    public int ID { get; set; }
    public string? FDtDist { get; set; }
    public int FProcesso { get; set; }
    public string? FPrecatoria { get; set; }
    public string? FDeprecante { get; set; }
    public string? FDeprecado { get; set; }
    public string? FOBS { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}