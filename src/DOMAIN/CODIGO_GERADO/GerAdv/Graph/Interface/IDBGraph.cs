namespace MenphisSI.GerAdv.Interface;
public partial interface IDBGraph
{
    public int ID { get; set; }
    public string? FTabela { get; set; }
    public int FTabelaId { get; set; }
    public byte[] FImagem { get; set; }
}