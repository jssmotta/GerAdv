namespace MenphisSI.GerAdv.Interface;
public partial interface IDBGUTPeriodicidade
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public int FIntervaloDias { get; set; }
    public string? FGUID { get; set; }
}