namespace MenphisSI.GerAdv.Interface;
public partial interface IDBDiario2
{
    public int ID { get; set; }
    public string? FData { get; set; }
    public string? FHora { get; set; }
    public int FOperador { get; set; }
    public string? FNome { get; set; }
    public string? FOcorrencia { get; set; }
    public int FCliente { get; set; }
    public bool FBold { get; set; }
}