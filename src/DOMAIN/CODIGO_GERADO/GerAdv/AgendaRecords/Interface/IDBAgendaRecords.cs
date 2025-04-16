namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAgendaRecords
{
    public int ID { get; set; }
    public int FAgenda { get; set; }
    public int FJulgador { get; set; }
    public int FClientesSocios { get; set; }
    public int FPerito { get; set; }
    public int FColaborador { get; set; }
    public int FForo { get; set; }
    public bool FAviso1 { get; set; }
    public bool FAviso2 { get; set; }
    public bool FAviso3 { get; set; }
    public int FCrmAviso1 { get; set; }
    public int FCrmAviso2 { get; set; }
    public int FCrmAviso3 { get; set; }
    public string? FDataAviso1 { get; set; }
    public string? FDataAviso2 { get; set; }
    public string? FDataAviso3 { get; set; }
}