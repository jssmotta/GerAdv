namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAnexamentoRegistros
{
    public int ID { get; set; }
    public int FCliente { get; set; }
    public int FCodigoReg { get; set; }
    public int FIDReg { get; set; }
    public string? FData { get; set; }
}