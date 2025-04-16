#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class JusticaResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - jusNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Negritar - jusBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - jusGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}