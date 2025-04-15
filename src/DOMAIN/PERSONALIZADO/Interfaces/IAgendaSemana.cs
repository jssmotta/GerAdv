

namespace MenphisSI.GerMDS.Interface;
public partial interface IAgendaSemanaService
{
    Task<IEnumerable<MenuAgendaSemana>?>? Monta(DateTime dataInicial, bool isMobile, string uri);
    Task<IEnumerable<AgendaSemanaResponse>?>? Filter30(DateTime? data, int paciente, int isMobile, string uri);
  
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