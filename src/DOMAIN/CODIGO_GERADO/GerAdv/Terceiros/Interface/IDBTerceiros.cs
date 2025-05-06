namespace MenphisSI.GerAdv.Interface;
public partial interface IDBTerceiros
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public string? FNome { get; set; }
    public int FSituacao { get; set; }
    public int FCidade { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public string? FCEP { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public string? FOBS { get; set; }
    public string? FEMail { get; set; }
    public string? FClass { get; set; }
    public string? FVaraForoComarca { get; set; }
    public bool FSexo { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}