namespace MenphisSI.GerAdv.Interface;
public partial interface IDBNECompromissos
{
    public int ID { get; set; }
    public int FPalavraChave { get; set; }
    public bool FProvisionar { get; set; }
    public int FTipoCompromisso { get; set; }
    public string? FTextoCompromisso { get; set; }
    public bool FBold { get; set; }
}