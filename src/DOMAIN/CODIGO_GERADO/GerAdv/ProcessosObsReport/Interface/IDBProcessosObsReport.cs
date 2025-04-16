namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProcessosObsReport
{
    public int ID { get; set; }
    public string? FData { get; set; }
    public int FProcesso { get; set; }
    public string? FObservacao { get; set; }
    public int FHistorico { get; set; }
}