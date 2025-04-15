namespace MenphisSI.GerAdv.Interface;
public partial interface IDBOponentesRepLegal
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public string? FFone { get; set; }
    public int FOponente { get; set; }
    public bool FSexo { get; set; }
    public string? FCPF { get; set; }
    public string? FRG { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public string? FCEP { get; set; }
    public int FCidade { get; set; }
    public string? FFax { get; set; }
    public string? FEMail { get; set; }
    public string? FSite { get; set; }
    public string? FObservacao { get; set; }
    public bool FBold { get; set; }
}