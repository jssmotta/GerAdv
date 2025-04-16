namespace MenphisSI.GerAdv.Interface;
public partial interface IDBProcessosParados
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public int FSemana { get; set; }
    public int FAno { get; set; }
    public string? FDataHora { get; set; }
    public int FOperador { get; set; }
    public string? FDataHistorico { get; set; }
    public string? FDataNENotas { get; set; }
}