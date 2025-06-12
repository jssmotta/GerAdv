#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class UltimosProcessos
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

[Serializable]
public partial class UltimosProcessosAll
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

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;
}