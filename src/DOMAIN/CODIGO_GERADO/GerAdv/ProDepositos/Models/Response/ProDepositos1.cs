#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProDepositosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pdsProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - pdsFase  
    /// </summary>
    [JsonPropertyName("fase")]
    public int Fase { get; set; }

    /// <summary>
    /// Sem descrição - pdsTipoProDesposito  
    /// </summary>
    [JsonPropertyName("tipoprodesposito")]
    public int TipoProDesposito { get; set; }

    /// <summary>
    /// Sem descrição - pdsData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - pdsValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}