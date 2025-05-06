namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProcessOutputEngine
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public string? FDatabase { get; set; }
    public string? FTabela { get; set; }
    public string? FCampo { get; set; }
    public string? FValor { get; set; }
    public string? FOutput { get; set; }
    public bool FAdministrador { get; set; }
    public int FOutputSource { get; set; }
    public bool FDisabledItem { get; set; }
    public int FIDModulo { get; set; }
    public bool FIsOnlyProcesso { get; set; }
    public int FMyID { get; set; }
    public string? FGUID { get; set; }
}