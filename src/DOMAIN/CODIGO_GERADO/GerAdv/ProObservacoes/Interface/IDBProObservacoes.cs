namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProObservacoes
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public string? FNome { get; set; }
    public string? FObservacoes { get; set; }
    public string? FData { get; set; }
}