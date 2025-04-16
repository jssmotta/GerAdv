namespace MenphisSI.GerAdv.Interface;
public partial interface IDBEnderecos
{
    public int ID { get; set; }
    public bool FTopIndex { get; set; }
    public string? FDescricao { get; set; }
    public string? FContato { get; set; }
    public string? FDtNasc { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public bool FPrivativo { get; set; }
    public bool FAddContato { get; set; }
    public string? FCEP { get; set; }
    public string? FOAB { get; set; }
    public string? FOBS { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public string? FTratamento { get; set; }
    public int FCidade { get; set; }
    public string? FSite { get; set; }
    public string? FEMail { get; set; }
    public int FQuem { get; set; }
    public string? FQuemIndicou { get; set; }
    public bool FReportECBOnly { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FAni { get; set; }
    public bool FBold { get; set; }
}