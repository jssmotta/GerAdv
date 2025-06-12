#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ServicosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - serCobrar  
    /// </summary>
    [JsonPropertyName("cobrar")]
    public bool Cobrar { get; set; }

    /// <summary>
    /// Sem descrição - serDescricao - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - serBasico  
    /// </summary>
    [JsonPropertyName("basico")]
    public bool Basico { get; set; }

    /// <summary>
    /// GUId - serGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class ServicosResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - serCobrar  
    /// </summary>
    [JsonPropertyName("cobrar")]
    public bool Cobrar { get; set; }

    /// <summary>
    /// Sem descrição - serDescricao - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - serBasico  
    /// </summary>
    [JsonPropertyName("basico")]
    public bool Basico { get; set; }

    /// <summary>
    /// GUId - serGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}