namespace MenphisSI.GerAdv.Interface;
public partial interface IDBDocumentos
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public string? FData { get; set; }
    public string? FObservacao { get; set; }
    public string? FGUID { get; set; }
}