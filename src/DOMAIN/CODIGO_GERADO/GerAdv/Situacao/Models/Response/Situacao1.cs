#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class SituacaoResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - sitParte_Int - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("parte_int")]
    public string Parte_Int { get; set; } = "";

    /// <summary>
    /// Sem descrição - sitParte_Opo - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("parte_opo")]
    public string Parte_Opo { get; set; } = "";

    /// <summary>
    /// Sem descrição - sitTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Negritar - sitBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - sitGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class SituacaoResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - sitParte_Int - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("parte_int")]
    public string Parte_Int { get; set; } = "";

    /// <summary>
    /// Sem descrição - sitParte_Opo - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("parte_opo")]
    public string Parte_Opo { get; set; } = "";

    /// <summary>
    /// Sem descrição - sitTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Negritar - sitBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - sitGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}