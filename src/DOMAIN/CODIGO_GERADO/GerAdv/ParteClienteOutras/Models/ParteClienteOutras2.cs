#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ParteClienteOutras
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pcoCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - pcoProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - pcoPrimeiraReclamada  
    /// </summary>
    [JsonPropertyName("primeirareclamada")]
    public bool PrimeiraReclamada { get; set; }

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}