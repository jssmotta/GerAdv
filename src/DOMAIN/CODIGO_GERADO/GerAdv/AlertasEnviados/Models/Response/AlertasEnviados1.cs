#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AlertasEnviadosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - aloOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - aloAlerta  
    /// </summary>
    [JsonPropertyName("alerta")]
    public int Alerta { get; set; }

    /// <summary>
    /// Sem descrição - aloDataAlertado  
    /// </summary>
    [JsonPropertyName("dataalertado")]
    public string DataAlertado { get; set; } = "";

    /// <summary>
    /// Sem descrição - aloVisualizado  
    /// </summary>
    [JsonPropertyName("visualizado")]
    public bool Visualizado { get; set; }
}