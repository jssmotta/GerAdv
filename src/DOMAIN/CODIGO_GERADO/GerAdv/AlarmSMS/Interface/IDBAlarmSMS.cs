namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAlarmSMS
{
    public int ID { get; set; }
    public string? FDescricao { get; set; }
    public int FHora { get; set; }
    public int FMinuto { get; set; }
    public bool FD1 { get; set; }
    public bool FD2 { get; set; }
    public bool FD3 { get; set; }
    public bool FD4 { get; set; }
    public bool FD5 { get; set; }
    public bool FD6 { get; set; }
    public bool FD7 { get; set; }
    public string? FEMail { get; set; }
    public bool FDesativar { get; set; }
    public string? FToday { get; set; }
    public bool FExcetoDiasFelizes { get; set; }
    public bool FDesktop { get; set; }
    public string? FAlertarDataHora { get; set; }
    public int FOperador { get; set; }
    public int FAgenda { get; set; }
    public int FRecado { get; set; }
    public int FEmocao { get; set; }
}