namespace MenphisSI.GerAdv.Interface;
public partial interface IDBOperadorEMailPopup
{
    public int ID { get; set; }
    public int FOperador { get; set; }
    public string? FNome { get; set; }
    public string? FSenha { get; set; }
    public string? FSMTP { get; set; }
    public string? FPOP3 { get; set; }
    public bool FAutenticacao { get; set; }
    public string? FDescricao { get; set; }
    public string? FUsuario { get; set; }
    public int FPortaSmtp { get; set; }
    public int FPortaPop3 { get; set; }
    public string? FAssinatura { get; set; }
    public string? FSenha256 { get; set; }
    public string? FGUID { get; set; }
}