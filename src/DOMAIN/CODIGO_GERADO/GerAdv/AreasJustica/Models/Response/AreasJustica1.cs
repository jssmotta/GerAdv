#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AreasJusticaResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - arjArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - arjJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }
}

[Serializable]
public partial class AreasJusticaResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - arjArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - arjJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    [JsonPropertyName("descricaoarea")]
    public string DescricaoArea { get; set; } = string.Empty;

    [JsonPropertyName("nomejustica")]
    public string NomeJustica { get; set; } = string.Empty;
}