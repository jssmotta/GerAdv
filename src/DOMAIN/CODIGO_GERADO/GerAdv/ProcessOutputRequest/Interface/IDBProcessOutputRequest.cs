namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProcessOutputRequest
{
    public int ID { get; set; }
    public int FProcessOutputEngine { get; set; }
    public int FOperador { get; set; }
    public int FProcesso { get; set; }
    public int FUltimoIdTabelaExo { get; set; }
    public string? FGUID { get; set; }
}