namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProDespesas
{
    public int ID { get; set; }
    public int FLigacaoID { get; set; }
    public int FCliente { get; set; }
    public bool FCorrigido { get; set; }
    public string? FData { get; set; }
    public decimal FValorOriginal { get; set; }
    public int FProcesso { get; set; }
    public int FQuitado { get; set; }
    public string? FDataCorrecao { get; set; }
    public decimal FValor { get; set; }
    public bool FTipo { get; set; }
    public string? FHistorico { get; set; }
    public bool FLivroCaixa { get; set; }
}