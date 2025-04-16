#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProcessOutputSources
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - posNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// GUId - posGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";
}