namespace MenphisSI.GerAdv.Interface;
public partial interface IDBHonorariosDadosContrato
{
    public int ID { get; set; }
    public int FCliente { get; set; }
    public bool FFixo { get; set; }
    public bool FVariavel { get; set; }
    public decimal FPercSucesso { get; set; }
    public int FProcesso { get; set; }
    public string? FArquivoContrato { get; set; }
    public string? FTextoContrato { get; set; }
    public decimal FValorFixo { get; set; }
    public string? FObservacao { get; set; }
    public string? FDataContrato { get; set; }
}