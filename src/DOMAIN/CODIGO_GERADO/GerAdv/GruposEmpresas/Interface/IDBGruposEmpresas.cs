namespace MenphisSI.GerAdv.Interface;
public partial interface IDBGruposEmpresas
{
    public int ID { get; set; }
    public string? FEMail { get; set; }
    public bool FInativo { get; set; }
    public int FOponente { get; set; }
    public string? FDescricao { get; set; }
    public string? FObservacoes { get; set; }
    public int FCliente { get; set; }
    public string? FIcone { get; set; }
    public bool FDespesaUnificada { get; set; }
}