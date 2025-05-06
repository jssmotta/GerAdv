namespace MenphisSI.GerAdv.Interface;
public partial interface IDBContatoCRM
{
    public int ID { get; set; }
    public int FAgeClienteAvisado { get; set; }
    public int FDocsViaRecebimento { get; set; }
    public bool FNaoPublicavel { get; set; }
    public bool FNotificar { get; set; }
    public bool FOcultar { get; set; }
    public string? FAssunto { get; set; }
    public bool FIsDocsRecebidos { get; set; }
    public int FQuemNotificou { get; set; }
    public string? FDataNotificou { get; set; }
    public int FOperador { get; set; }
    public int FCliente { get; set; }
    public string? FHoraNotificou { get; set; }
    public int FObjetoNotificou { get; set; }
    public string? FPessoaContato { get; set; }
    public string? FData { get; set; }
    public decimal FTempo { get; set; }
    public string? FHoraInicial { get; set; }
    public string? FHoraFinal { get; set; }
    public int FProcesso { get; set; }
    public bool FImportante { get; set; }
    public bool FUrgente { get; set; }
    public bool FGerarHoraTrabalhada { get; set; }
    public bool FExibirNoTopo { get; set; }
    public int FTipoContatoCRM { get; set; }
    public string? FContato { get; set; }
    public int FEmocao { get; set; }
    public bool FContinuar { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}