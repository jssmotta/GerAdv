namespace MenphisSI.GerAdv.Interface;
public partial interface IDBLigacoes
{
    public int ID { get; set; }
    public string? FAssunto { get; set; }
    public int FAgeClienteAvisado { get; set; }
    public bool FCelular { get; set; }
    public int FCliente { get; set; }
    public string? FContato { get; set; }
    public string? FDataRealizada { get; set; }
    public int FQuemID { get; set; }
    public int FTelefonista { get; set; }
    public string? FUltimoAviso { get; set; }
    public string? FHoraFinal { get; set; }
    public string? FNome { get; set; }
    public int FQuemCodigo { get; set; }
    public int FSolicitante { get; set; }
    public string? FPara { get; set; }
    public string? FFone { get; set; }
    public int FRamal { get; set; }
    public bool FParticular { get; set; }
    public bool FRealizada { get; set; }
    public string? FStatus { get; set; }
    public string? FData { get; set; }
    public string? FHora { get; set; }
    public bool FUrgente { get; set; }
    public string? FLigarPara { get; set; }
    public int FProcesso { get; set; }
    public bool FStartScreen { get; set; }
    public int FEmotion { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}