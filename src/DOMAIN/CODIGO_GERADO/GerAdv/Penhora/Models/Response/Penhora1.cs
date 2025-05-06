#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class PenhoraResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - phrProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - phrPenhoraStatus  
    /// </summary>
    [JsonPropertyName("penhorastatus")]
    public int PenhoraStatus { get; set; }

    /// <summary>
    /// Sem descrição - phrNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - phrDescricao  
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - phrDataPenhora  
    /// </summary>
    [JsonPropertyName("datapenhora")]
    public string DataPenhora { get; set; } = "";

    /// <summary>
    /// Sem descrição - phrMaster  
    /// </summary>
    [JsonPropertyName("master")]
    public int Master { get; set; }

    /// <summary>
    /// GUId - phrGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}