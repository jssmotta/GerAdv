namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProProcuradores
{
    public int ID { get; set; }
    public int FAdvogado { get; set; }
    public string? FNome { get; set; }
    public int FProcesso { get; set; }
    public string? FData { get; set; }
    public bool FSubstabelecimento { get; set; }
    public bool FProcuracao { get; set; }
    public bool FBold { get; set; }
}