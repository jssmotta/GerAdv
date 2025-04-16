namespace MenphisSI.GerAdv.Interface;
public partial interface IDBPoderJudiciarioAssociado
{
    public int ID { get; set; }
    public int FJustica { get; set; }
    public string? FJusticaNome { get; set; }
    public int FArea { get; set; }
    public string? FAreaNome { get; set; }
    public int FTribunal { get; set; }
    public string? FTribunalNome { get; set; }
    public int FForo { get; set; }
    public string? FForoNome { get; set; }
    public int FCidade { get; set; }
    public string? FSubDivisaoNome { get; set; }
    public string? FCidadeNome { get; set; }
    public int FSubDivisao { get; set; }
    public int FTipo { get; set; }
}