#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class UF
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ufPais  
    /// </summary>
    [JsonPropertyName("pais")]
    public int Pais { get; set; }

    /// <summary>
    /// Sem descrição - ufDDD - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("ddd")]
    public string DDD { get; set; } = "";

    /// <summary>
    /// Sem descrição - ufID - tamanho máximo: 4 
    /// </summary>
    [JsonPropertyName("iduf")]
    public string IdUF { get; set; } = "";

    /// <summary>
    /// Sem descrição - ufTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Sem descrição - ufDescricao - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// GUId - ufGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}