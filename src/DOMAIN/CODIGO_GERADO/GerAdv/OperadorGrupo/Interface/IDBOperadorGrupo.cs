namespace MenphisSI.GerAdv.Interface;
public partial interface IDBOperadorGrupo
{
    public int ID { get; set; }
    public int FOperador { get; set; }
    public int FGrupo { get; set; }
    public bool FInativo { get; set; }
}