#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ContatoCRMViewResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ccwCGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("cguid")]
    public string CGUID { get; set; } = "";

    /// <summary>
    /// Sem descrição - ccwData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - ccwIP - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("ip")]
    public string IP { get; set; } = "";
}

[Serializable]
public partial class ContatoCRMViewResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ccwCGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("cguid")]
    public string CGUID { get; set; } = "";

    /// <summary>
    /// Sem descrição - ccwData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - ccwIP - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("ip")]
    public string IP { get; set; } = "";
}