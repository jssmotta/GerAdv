namespace MenphisSI.GerAdv.Interface;
public partial interface IDBColaboradores
{
    public int ID { get; set; }
    public int FCargo { get; set; }
    public int FCliente { get; set; }
    public bool FSexo { get; set; }
    public string? FNome { get; set; }
    public string? FCPF { get; set; }
    public string? FRG { get; set; }
    public string? FDtNasc { get; set; }
    public int FIdade { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public string? FCEP { get; set; }
    public int FCidade { get; set; }
    public string? FFone { get; set; }
    public string? FObservacao { get; set; }
    public string? FEMail { get; set; }
    public string? FCNH { get; set; }
    public string? FClass { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FAni { get; set; }
    public bool FBold { get; set; }
}