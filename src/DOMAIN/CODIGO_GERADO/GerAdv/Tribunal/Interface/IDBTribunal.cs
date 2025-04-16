namespace MenphisSI.GerAdv.Interface;
public partial interface IDBTribunal
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public int FArea { get; set; }
    public int FJustica { get; set; }
    public string? FDescricao { get; set; }
    public int FInstancia { get; set; }
    public string? FSigla { get; set; }
    public string? FWeb { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FBold { get; set; }
}