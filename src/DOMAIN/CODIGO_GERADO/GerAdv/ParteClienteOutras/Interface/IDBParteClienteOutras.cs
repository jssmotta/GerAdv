namespace MenphisSI.GerAdv.Interface;
public partial interface IDBParteClienteOutras
{
    public int ID { get; set; }
    public int FCliente { get; set; }
    public int FProcesso { get; set; }
    public bool FPrimeiraReclamada { get; set; }
}