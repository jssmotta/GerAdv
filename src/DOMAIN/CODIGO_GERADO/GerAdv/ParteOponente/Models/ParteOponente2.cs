#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ParteOponente
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - opoOponente  
    /// </summary>
    [JsonPropertyName("oponente")]
    public int Oponente { get; set; }

    /// <summary>
    /// Sem descrição - opoProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }
}