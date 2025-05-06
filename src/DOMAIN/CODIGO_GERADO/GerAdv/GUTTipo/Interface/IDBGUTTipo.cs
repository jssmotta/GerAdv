namespace MenphisSI.GerAdv.Interface;
public partial interface IDBGUTTipo
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public int FOrdem { get; set; }
    public string? FGUID { get; set; }
}