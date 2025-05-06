namespace MenphisSI.GerAdv.Interface;
public partial interface IDBPosicaoOutrasPartes
{
    public int ID { get; set; }
    public string? FDescricao { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}