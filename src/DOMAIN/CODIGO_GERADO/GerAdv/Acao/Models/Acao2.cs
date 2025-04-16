#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Acao
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - acaJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - acaArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - acaDescricao - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// GUId - acaGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}