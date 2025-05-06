#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class PrecatoriaResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - preProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - preDtDist  
    /// </summary>
    [JsonPropertyName("dtdist")]
    public string DtDist { get; set; } = "";

    /// <summary>
    /// Sem descrição - prePrecatoria - tamanho máximo: 25 
    /// </summary>
    [JsonPropertyName("precatoriax")]
    public string PrecatoriaX { get; set; } = "";

    /// <summary>
    /// Sem descrição - preDeprecante - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("deprecante")]
    public string Deprecante { get; set; } = "";

    /// <summary>
    /// Sem descrição - preDeprecado - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("deprecado")]
    public string Deprecado { get; set; } = "";

    /// <summary>
    /// Sem descrição - preOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Negritar - preBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - preGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}