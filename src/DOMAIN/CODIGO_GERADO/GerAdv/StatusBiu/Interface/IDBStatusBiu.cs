namespace MenphisSI.GerAdv.Interface;
public partial interface IDBStatusBiu
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public int FTipoStatusBiu { get; set; }
    public int FOperador { get; set; }
    public int FIcone { get; set; }
}