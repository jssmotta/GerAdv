namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAndamentosMD
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public int FProcesso { get; set; }
    public int FAndamento { get; set; }
    public string? FPathFull { get; set; }
    public string? FUNC { get; set; }
}