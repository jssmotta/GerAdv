namespace MenphisSI.GerAdv.Interface;
public partial interface IDBSMSAlice
{
    public int ID { get; set; }
    public int FOperador { get; set; }
    public string? FNome { get; set; }
    public int FTipoEMail { get; set; }
    public string? FGUID { get; set; }
}