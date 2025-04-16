namespace MenphisSI.GerAdv.Interface;
public partial interface IDBLivroCaixaClientes
{
    public int ID { get; set; }
    public int FLivroCaixa { get; set; }
    public int FCliente { get; set; }
    public bool FLancado { get; set; }
}