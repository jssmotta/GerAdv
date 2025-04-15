namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAgendaStatus
{
    public int ID { get; set; }
    public int FAgenda { get; set; }
    public int FCompleted { get; set; }
}