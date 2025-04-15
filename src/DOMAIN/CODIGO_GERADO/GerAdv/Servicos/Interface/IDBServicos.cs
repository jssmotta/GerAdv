namespace MenphisSI.GerAdv.Interface;
public partial interface IDBServicos
{
    public int ID { get; set; }
    public bool FCobrar { get; set; }
    public string? FDescricao { get; set; }
    public bool FBasico { get; set; }
}