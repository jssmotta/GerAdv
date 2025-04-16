namespace MenphisSI.GerAdv.Interface;
public partial interface IDBGruposEmpresasCli
{
    public int ID { get; set; }
    public int FGrupo { get; set; }
    public int FCliente { get; set; }
    public bool FOculto { get; set; }
}