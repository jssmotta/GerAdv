namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAlertas
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public string? FData { get; set; }
    public int FOperador { get; set; }
    public string? FDataAte { get; set; }
}