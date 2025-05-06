namespace MenphisSI.GerAdv.Interface;
public partial interface IDBCidade
{
    public int ID { get; set; }
    public string? FDDD { get; set; }
    public bool FTop { get; set; }
    public bool FComarca { get; set; }
    public bool FCapital { get; set; }
    public string? FNome { get; set; }
    public int FUF { get; set; }
    public string? FSigla { get; set; }
    public string? FGUID { get; set; }
}