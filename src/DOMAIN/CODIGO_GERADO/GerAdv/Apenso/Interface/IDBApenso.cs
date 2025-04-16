namespace MenphisSI.GerAdv.Interface;
public partial interface IDBApenso
{
    public int ID { get; set; }
    public int FProcesso { get; set; }
    public string? FApenso { get; set; }
    public string? FAcao { get; set; }
    public string? FDtDist { get; set; }
    public string? FOBS { get; set; }
    public decimal FValorCausa { get; set; }
}