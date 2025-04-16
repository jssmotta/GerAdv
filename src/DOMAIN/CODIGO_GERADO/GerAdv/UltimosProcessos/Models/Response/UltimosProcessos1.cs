#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class UltimosProcessosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ultProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - ultQuando  
    /// </summary>
    [JsonPropertyName("quando")]
    public string Quando { get; set; } = "";

    /// <summary>
    /// Sem descrição - ultQuem  
    /// </summary>
    [JsonPropertyName("quem")]
    public int Quem { get; set; }
}