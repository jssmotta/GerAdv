#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ContatoCRMOperadorResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ccoContatoCRM  
    /// </summary>
    [JsonPropertyName("contatocrm")]
    public int ContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - ccoOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - ccoCargoEsc  
    /// </summary>
    [JsonPropertyName("cargoesc")]
    public int CargoEsc { get; set; }

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}