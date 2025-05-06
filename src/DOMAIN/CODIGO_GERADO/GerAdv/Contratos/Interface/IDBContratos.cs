namespace MenphisSI.GerAdv.Interface;
public partial interface IDBContratos
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public int FCliente { get; set; }
    public int FAdvogado { get; set; }
    public int FDia { get; set; }
    public decimal FValor { get; set; }
    public string? FDataInicio { get; set; }
    public string? FDataTermino { get; set; }
    public bool FOcultarRelatorio { get; set; }
    public decimal FPercEscritorio { get; set; }
    public decimal FValorConsultoria { get; set; }
    public int FTipoCobranca { get; set; }
    public string? FProtestar { get; set; }
    public string? FJuros { get; set; }
    public decimal FValorRealizavel { get; set; }
    public string? FDOCUMENTO { get; set; }
    public string? FEMail1 { get; set; }
    public string? FEMail2 { get; set; }
    public string? FEMail3 { get; set; }
    public string? FPessoa1 { get; set; }
    public string? FPessoa2 { get; set; }
    public string? FPessoa3 { get; set; }
    public string? FOBS { get; set; }
    public int FClienteContrato { get; set; }
    public int FIdExtrangeiro { get; set; }
    public string? FChaveContrato { get; set; }
    public bool FAvulso { get; set; }
    public bool FSuspenso { get; set; }
    public string? FMulta { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}