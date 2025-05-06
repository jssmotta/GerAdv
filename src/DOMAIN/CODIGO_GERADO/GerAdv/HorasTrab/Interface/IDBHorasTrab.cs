namespace MenphisSI.GerAdv.Interface;
public partial interface IDBHorasTrab
{
    public int ID { get; set; }
    public int FIDContatoCRM { get; set; }
    public bool FHonorario { get; set; }
    public int FIDAgenda { get; set; }
    public string? FData { get; set; }
    public int FCliente { get; set; }
    public int FStatus { get; set; }
    public int FProcesso { get; set; }
    public int FAdvogado { get; set; }
    public int FFuncionario { get; set; }
    public string? FHrIni { get; set; }
    public string? FHrFim { get; set; }
    public decimal FTempo { get; set; }
    public decimal FValor { get; set; }
    public string? FOBS { get; set; }
    public string? FAnexo { get; set; }
    public string? FAnexoComp { get; set; }
    public string? FAnexoUNC { get; set; }
    public int FServico { get; set; }
    public string? FGUID { get; set; }
}