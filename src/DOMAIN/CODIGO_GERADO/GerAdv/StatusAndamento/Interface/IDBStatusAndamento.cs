namespace MenphisSI.GerAdv.Interface;
public partial interface IDBStatusAndamento
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public int FIcone { get; set; }
    public bool FBold { get; set; }
}