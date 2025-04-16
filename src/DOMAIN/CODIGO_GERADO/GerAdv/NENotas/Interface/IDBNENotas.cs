namespace MenphisSI.GerAdv.Interface;
public partial interface IDBNENotas
{
    public int ID { get; set; }
    public int FApenso { get; set; }
    public int FPrecatoria { get; set; }
    public int FInstancia { get; set; }
    public bool FMovPro { get; set; }
    public string? FNome { get; set; }
    public bool FNotaExpedida { get; set; }
    public bool FRevisada { get; set; }
    public int FProcesso { get; set; }
    public int FPalavraChave { get; set; }
    public string? FData { get; set; }
    public string? FNotaPublicada { get; set; }
}