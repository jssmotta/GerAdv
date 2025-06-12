#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class TipoRecurso
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - trcJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - trcArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - trcDescricao - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// GUId - trcGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class TipoRecursoAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - trcJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - trcArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - trcDescricao - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// GUId - trcGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomejustica")]
    public string NomeJustica { get; set; } = string.Empty;

    [JsonPropertyName("descricaoarea")]
    public string DescricaoArea { get; set; } = string.Empty;
}