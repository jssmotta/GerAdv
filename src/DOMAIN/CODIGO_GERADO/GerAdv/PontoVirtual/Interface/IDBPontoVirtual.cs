namespace MenphisSI.GerAdv.Interface;
public partial interface IDBPontoVirtual
{
    public int ID { get; set; }
    public string? FHoraEntrada { get; set; }
    public string? FHoraSaida { get; set; }
    public int FOperador { get; set; }
    public string? FKey { get; set; }
}