#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Apenso2Response
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ap2Processo  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - ap2Apensado  
    /// </summary>
    [JsonPropertyName("apensado")]
    public int Apensado { get; set; }

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}