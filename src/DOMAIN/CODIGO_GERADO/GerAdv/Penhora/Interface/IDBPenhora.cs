namespace MenphisSI.GerAdv.Interface;
public partial interface IDBPenhora
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public string? FNome { get; set; }
    public string? FDescricao { get; set; }
    public string? FDataPenhora { get; set; }
    public int FPenhoraStatus { get; set; }
    public int FMaster { get; set; }
}