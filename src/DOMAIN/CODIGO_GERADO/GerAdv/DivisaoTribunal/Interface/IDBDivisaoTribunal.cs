namespace MenphisSI.GerAdv.Interface;
public partial interface IDBDivisaoTribunal
{
    public int ID { get; set; }
    public int FNumCodigo { get; set; }
    public int FJustica { get; set; }
    public string? FNomeEspecial { get; set; }
    public int FArea { get; set; }
    public int FCidade { get; set; }
    public int FForo { get; set; }
    public int FTribunal { get; set; }
    public string? FCodigoDiv { get; set; }
    public string? FEndereco { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public string? FCEP { get; set; }
    public string? FObs { get; set; }
    public string? FEMail { get; set; }
    public string? FAndar { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}