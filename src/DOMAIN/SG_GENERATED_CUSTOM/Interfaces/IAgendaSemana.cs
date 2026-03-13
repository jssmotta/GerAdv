

namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaSemanaService
{
    Task<IEnumerable<MenuAgendaSemana>?>? Monta(DateTime dataInicial, bool isMobile, string tenantKey);
    Task<IEnumerable<AgendaSemanaResponse>?>? Filter30(DateTime? data, int paciente, int isMobile, string tenantKey);
  
}

public class MenuAgendaSemana
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; } = "";

    [JsonPropertyName("items")]
    public List<MenuAgendaSemana> Items { get; set; } = [];

}