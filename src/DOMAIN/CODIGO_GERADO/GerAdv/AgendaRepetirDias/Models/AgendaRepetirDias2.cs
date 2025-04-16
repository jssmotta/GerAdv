#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AgendaRepetirDias
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - rpdHoraFinal  
    /// </summary>
    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - rpdMaster  
    /// </summary>
    [JsonPropertyName("master")]
    public int Master { get; set; }

    /// <summary>
    /// Sem descrição - rpdDia  
    /// </summary>
    [JsonPropertyName("dia")]
    public int Dia { get; set; }

    /// <summary>
    /// Sem descrição - rpdHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public string Hora { get; set; } = "";
}