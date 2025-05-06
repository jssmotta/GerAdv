namespace MenphisSI.GerAdv.Interface;
public partial interface IDBRecados
{
    public int ID { get; set; }
    public string? FClienteNome { get; set; }
    public string? FDe { get; set; }
    public string? FPara { get; set; }
    public string? FAssunto { get; set; }
    public bool FConcluido { get; set; }
    public int FProcesso { get; set; }
    public int FCliente { get; set; }
    public string? FRecado { get; set; }
    public bool FUrgente { get; set; }
    public bool FImportante { get; set; }
    public string? FHora { get; set; }
    public string? FData { get; set; }
    public bool FVoltara { get; set; }
    public bool FPessoal { get; set; }
    public bool FRetornar { get; set; }
    public string? FRetornoData { get; set; }
    public int FEmotion { get; set; }
    public int FInternetID { get; set; }
    public bool FUploaded { get; set; }
    public int FNatureza { get; set; }
    public bool FBIU { get; set; }
    public bool FAguardarRetorno { get; set; }
    public string? FAguardarRetornoPara { get; set; }
    public bool FAguardarRetornoOK { get; set; }
    public int FParaID { get; set; }
    public bool FNaoPublicavel { get; set; }
    public bool FIsContatoCRM { get; set; }
    public int FMasterID { get; set; }
    public string? FListaPara { get; set; }
    public bool FTyped { get; set; }
    public int FAssuntoRecado { get; set; }
    public int FHistorico { get; set; }
    public int FContatoCRM { get; set; }
    public int FLigacoes { get; set; }
    public int FAgenda { get; set; }
    public string? FGUID { get; set; }
}