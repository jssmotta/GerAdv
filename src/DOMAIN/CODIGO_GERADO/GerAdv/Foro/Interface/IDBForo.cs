namespace MenphisSI.GerAdv.Interface;
public partial interface IDBForo
{
    public int ID { get; set; }
    public string? FEMail { get; set; }
    public string? FNome { get; set; }
    public bool FUnico { get; set; }
    public int FCidade { get; set; }
    public string? FSite { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public string? FCEP { get; set; }
    public string? FOBS { get; set; }
    public bool FUnicoConfirmado { get; set; }
    public string? FWeb { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FBold { get; set; }
}