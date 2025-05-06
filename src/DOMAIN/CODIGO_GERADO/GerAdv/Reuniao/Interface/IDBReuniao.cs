namespace MenphisSI.GerAdv.Interface;
public partial interface IDBReuniao
{
    public int ID { get; set; }
    public int FCliente { get; set; }
    public int FIDAgenda { get; set; }
    public string? FData { get; set; }
    public string? FPauta { get; set; }
    public string? FATA { get; set; }
    public string? FHoraInicial { get; set; }
    public string? FHoraFinal { get; set; }
    public bool FExterna { get; set; }
    public string? FHoraSaida { get; set; }
    public string? FHoraRetorno { get; set; }
    public string? FPrincipaisDecisoes { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}