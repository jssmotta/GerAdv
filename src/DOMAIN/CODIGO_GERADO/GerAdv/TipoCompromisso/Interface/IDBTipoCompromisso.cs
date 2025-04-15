namespace MenphisSI.GerAdv.Interface;
public partial interface IDBTipoCompromisso
{
    public int ID { get; set; }
    public int FIcone { get; set; }
    public string? FDescricao { get; set; }
    public bool FFinanceiro { get; set; }
    public bool FBold { get; set; }
}