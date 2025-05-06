namespace MenphisSI.GerAdv.Interface;
public partial interface IDBDocsRecebidosItens
{
    public int ID { get; set; }
    public int FContatoCRM { get; set; }
    public string? FNome { get; set; }
    public bool FDevolvido { get; set; }
    public bool FSeraDevolvido { get; set; }
    public string? FObservacoes { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}