namespace MenphisSI.GerAdv.Interface;
public partial interface IDBGUTAtividadesMatriz
{
    public int ID { get; set; }
    public int FGUTMatriz { get; set; }
    public int FGUTAtividade { get; set; }
    public string? FGUID { get; set; }
}