#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProValoresResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - prvProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - prvTipoValorProcesso  
    /// </summary>
    [JsonPropertyName("tipovalorprocesso")]
    public int TipoValorProcesso { get; set; }

    /// <summary>
    /// Sem descrição - prvIndice - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("indice")]
    public string Indice { get; set; } = "";

    /// <summary>
    /// Sem descrição - prvIgnorar  
    /// </summary>
    [JsonPropertyName("ignorar")]
    public bool Ignorar { get; set; }

    /// <summary>
    /// Sem descrição - prvData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - prvValorOriginal  
    /// </summary>
    [JsonPropertyName("valororiginal")]
    public decimal ValorOriginal { get; set; }

    /// <summary>
    /// Sem descrição - prvPercMulta  
    /// </summary>
    [JsonPropertyName("percmulta")]
    public decimal PercMulta { get; set; }

    /// <summary>
    /// Sem descrição - prvValorMulta  
    /// </summary>
    [JsonPropertyName("valormulta")]
    public decimal ValorMulta { get; set; }

    /// <summary>
    /// Sem descrição - prvPercJuros  
    /// </summary>
    [JsonPropertyName("percjuros")]
    public decimal PercJuros { get; set; }

    /// <summary>
    /// Sem descrição - prvValorOriginalCorrigidoIndice  
    /// </summary>
    [JsonPropertyName("valororiginalcorrigidoindice")]
    public decimal ValorOriginalCorrigidoIndice { get; set; }

    /// <summary>
    /// Sem descrição - prvValorMultaCorrigido  
    /// </summary>
    [JsonPropertyName("valormultacorrigido")]
    public decimal ValorMultaCorrigido { get; set; }

    /// <summary>
    /// Sem descrição - prvValorJurosCorrigido  
    /// </summary>
    [JsonPropertyName("valorjuroscorrigido")]
    public decimal ValorJurosCorrigido { get; set; }

    /// <summary>
    /// Sem descrição - prvValorFinal  
    /// </summary>
    [JsonPropertyName("valorfinal")]
    public decimal ValorFinal { get; set; }

    /// <summary>
    /// Sem descrição - prvDataUltimaCorrecao  
    /// </summary>
    [JsonPropertyName("dataultimacorrecao")]
    public string DataUltimaCorrecao { get; set; } = "";

    /// <summary>
    /// GUId - prvGUID - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}