namespace MenphisSI.GerAdv.Interface;
public partial interface IDBCargosEsc
{
    public int ID { get; set; }
    public decimal FPercentual { get; set; }
    public string? FNome { get; set; }
    public int FClassificacao { get; set; }
}