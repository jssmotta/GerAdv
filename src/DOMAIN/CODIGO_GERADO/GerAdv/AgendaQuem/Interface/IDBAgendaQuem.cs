namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAgendaQuem
{
    public int ID { get; set; }
    public int FIDAgenda { get; set; }
    public int FAdvogado { get; set; }
    public int FFuncionario { get; set; }
    public int FPreposto { get; set; }
}