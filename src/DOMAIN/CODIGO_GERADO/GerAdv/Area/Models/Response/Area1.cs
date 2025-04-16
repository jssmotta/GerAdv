#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AreaResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - areDescricao - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - areTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// GUId - areGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}