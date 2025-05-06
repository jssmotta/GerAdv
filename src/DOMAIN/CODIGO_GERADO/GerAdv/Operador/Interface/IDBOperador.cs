namespace MenphisSI.GerAdv.Interface;
public partial interface IDBOperador
{
    public int ID { get; set; }
    public string? FEMail { get; set; }
    public string? FPasta { get; set; }
    public bool FTelefonista { get; set; }
    public bool FMaster { get; set; }
    public string? FNome { get; set; }
    public string? FNick { get; set; }
    public string? FRamal { get; set; }
    public int FCadID { get; set; }
    public int FCadCod { get; set; }
    public bool FExcluido { get; set; }
    public bool FSituacao { get; set; }
    public int FComputador { get; set; }
    public string? FMinhaDescricao { get; set; }
    public string? FUltimoLogoff { get; set; }
    public string? FEMailNet { get; set; }
    public string? FOnlineIP { get; set; }
    public bool FOnLine { get; set; }
    public bool FSysOp { get; set; }
    public int FStatusId { get; set; }
    public string? FStatusMessage { get; set; }
    public bool FIsFinanceiro { get; set; }
    public bool FTop { get; set; }
    public bool FSexo { get; set; }
    public bool FBasico { get; set; }
    public bool FExterno { get; set; }
    public string? FSenha256 { get; set; }
    public bool FEMailConfirmado { get; set; }
    public string? FDataLimiteReset { get; set; }
    public string? FSuporteSenha256 { get; set; }
    public string? FSuporteMaxAge { get; set; }
    public string? FSuporteNomeSolicitante { get; set; }
    public string? FSuporteUltimoAcesso { get; set; }
    public string? FSuporteIpUltimoAcesso { get; set; }
    public string? FGUID { get; set; }
}