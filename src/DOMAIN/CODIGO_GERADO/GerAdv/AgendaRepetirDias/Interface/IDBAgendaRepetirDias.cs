namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAgendaRepetirDias
{
    public int ID { get; set; }
    public string? FHoraFinal { get; set; }
    public int FMaster { get; set; }
    public int FDia { get; set; }
    public string? FHora { get; set; }
}