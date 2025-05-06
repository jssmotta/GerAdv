namespace MenphisSI.GerAdv.Interface;
public partial interface IDBEscritorios
{
    public int ID { get; set; }
    public string? FCNPJ { get; set; }
    public bool FCasa { get; set; }
    public bool FParceria { get; set; }
    public string? FNome { get; set; }
    public string? FOAB { get; set; }
    public string? FEndereco { get; set; }
    public int FCidade { get; set; }
    public string? FBairro { get; set; }
    public string? FCEP { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public string? FSite { get; set; }
    public string? FEMail { get; set; }
    public string? FOBS { get; set; }
    public string? FAdvResponsavel { get; set; }
    public string? FSecretaria { get; set; }
    public string? FInscEst { get; set; }
    public bool FCorrespondente { get; set; }
    public bool FTop { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}