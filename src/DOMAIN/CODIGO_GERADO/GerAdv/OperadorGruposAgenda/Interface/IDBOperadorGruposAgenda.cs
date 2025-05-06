namespace MenphisSI.GerAdv.Interface;
public partial interface IDBOperadorGruposAgenda
{
    public int ID { get; set; }
    public string? FSQLWhere { get; set; }
    public string? FNome { get; set; }
    public int FOperador { get; set; }
    public string? FGUID { get; set; }
}