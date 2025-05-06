namespace MenphisSI.GerAdv.Interface;
public partial interface IDBGUTAtividades
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public string? FObservacao { get; set; }
    public int FGUTGrupo { get; set; }
    public int FGUTPeriodicidade { get; set; }
    public int FOperador { get; set; }
    public bool FConcluido { get; set; }
    public string? FDataConcluido { get; set; }
    public int FDiasParaIniciar { get; set; }
    public int FMinutosParaRealizar { get; set; }
    public string? FGUID { get; set; }
}