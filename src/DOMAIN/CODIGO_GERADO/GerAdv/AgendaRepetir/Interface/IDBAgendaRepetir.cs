namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAgendaRepetir
{
    public int ID { get; set; }
    public int FAdvogado { get; set; }
    public int FCliente { get; set; }
    public string? FDataFinal { get; set; }
    public int FFuncionario { get; set; }
    public string? FHoraFinal { get; set; }
    public int FProcesso { get; set; }
    public bool FPessoal { get; set; }
    public int FFrequencia { get; set; }
    public int FDia { get; set; }
    public int FMes { get; set; }
    public string? FHora { get; set; }
    public int FIDQuem { get; set; }
    public int FIDQuem2 { get; set; }
    public string? FMensagem { get; set; }
    public int FIDTipo { get; set; }
    public int FID1 { get; set; }
    public int FID2 { get; set; }
    public int FID3 { get; set; }
    public int FID4 { get; set; }
    public bool FSegunda { get; set; }
    public bool FQuarta { get; set; }
    public bool FQuinta { get; set; }
    public bool FSexta { get; set; }
    public bool FSabado { get; set; }
    public bool FDomingo { get; set; }
    public bool FTerca { get; set; }
}