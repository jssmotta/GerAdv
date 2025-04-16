#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class OperadorGruposAgendaOperadores
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ogpOperadorGruposAgenda  
    /// </summary>
    [JsonPropertyName("operadorgruposagenda")]
    public int OperadorGruposAgenda { get; set; }

    /// <summary>
    /// Sem descrição - ogpOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// GUId - ogpGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}