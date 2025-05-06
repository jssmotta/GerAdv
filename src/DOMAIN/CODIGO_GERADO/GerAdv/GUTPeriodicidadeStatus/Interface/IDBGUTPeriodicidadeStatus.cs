namespace MenphisSI.GerAdv.Interface;
public partial interface IDBGUTPeriodicidadeStatus
{
    public int ID { get; set; }
    public int FGUTAtividade { get; set; }
    public string? FDataRealizado { get; set; }
    public string? FGUID { get; set; }
}