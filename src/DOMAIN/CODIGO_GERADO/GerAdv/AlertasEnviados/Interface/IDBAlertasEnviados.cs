namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAlertasEnviados
{
    public int ID { get; set; }
    public int FOperador { get; set; }
    public int FAlerta { get; set; }
    public string? FDataAlertado { get; set; }
    public bool FVisualizado { get; set; }
}