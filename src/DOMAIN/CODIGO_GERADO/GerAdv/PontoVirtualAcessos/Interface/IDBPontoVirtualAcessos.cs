namespace MenphisSI.GerAdv.Interface;
public partial interface IDBPontoVirtualAcessos
{
    public int ID { get; set; }
    public int FOperador { get; set; }
    public string? FDataHora { get; set; }
    public bool FTipo { get; set; }
    public string? FOrigem { get; set; }
}