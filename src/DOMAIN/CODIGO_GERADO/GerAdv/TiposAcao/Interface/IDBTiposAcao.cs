namespace MenphisSI.GerAdv.Interface;
public partial interface IDBTiposAcao
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public bool FInativo { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}