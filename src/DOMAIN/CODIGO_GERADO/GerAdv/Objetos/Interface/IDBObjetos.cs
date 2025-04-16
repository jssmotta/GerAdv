namespace MenphisSI.GerAdv.Interface;
public partial interface IDBObjetos
{
    public int ID { get; set; }
    public int FJustica { get; set; }
    public int FArea { get; set; }
    public string? FNome { get; set; }
    public bool FBold { get; set; }
}