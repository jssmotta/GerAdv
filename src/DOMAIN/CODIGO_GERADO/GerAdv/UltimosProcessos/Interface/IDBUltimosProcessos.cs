namespace MenphisSI.GerAdv.Interface;
public partial interface IDBUltimosProcessos
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public string? FQuando { get; set; }
    public int FQuem { get; set; }
}