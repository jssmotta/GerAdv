#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProTipoBaixa
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ptxNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Negritar - ptxBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - ptxGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}