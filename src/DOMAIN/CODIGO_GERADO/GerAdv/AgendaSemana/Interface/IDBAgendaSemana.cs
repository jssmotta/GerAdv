namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAgendaSemana
{
    public int ID { get; set; }
    public string? FParaNome { get; set; }
    public string? FData { get; set; }
    public int FFuncionario { get; set; }
    public int FAdvogado { get; set; }
    public string? FHora { get; set; }
    public int FTipoCompromisso { get; set; }
    public string? FCompromisso { get; set; }
    public bool FConcluido { get; set; }
    public bool FLiberado { get; set; }
    public bool FImportante { get; set; }
    public string? FHoraFinal { get; set; }
    public string? FNome { get; set; }
    public int FCliente { get; set; }
    public string? FNomeCliente { get; set; }
    public string? FTipo { get; set; }
}