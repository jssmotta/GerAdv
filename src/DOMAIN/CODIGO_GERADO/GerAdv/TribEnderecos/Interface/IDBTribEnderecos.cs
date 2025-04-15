namespace MenphisSI.GerAdv.Interface;
public partial interface IDBTribEnderecos
{
    public int ID { get; set; }
    public int FTribunal { get; set; }
    public int FCidade { get; set; }
    public string? FEndereco { get; set; }
    public string? FCEP { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public string? FOBS { get; set; }
}