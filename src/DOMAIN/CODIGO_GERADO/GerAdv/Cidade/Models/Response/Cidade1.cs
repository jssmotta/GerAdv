#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class CidadeResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - cidUF  
    /// </summary>
    [JsonPropertyName("uf")]
    public int UF { get; set; }

    /// <summary>
    /// Sem descrição - cidDDD - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("ddd")]
    public string DDD { get; set; } = "";

    /// <summary>
    /// Sem descrição - cidTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Sem descrição - cidComarca  
    /// </summary>
    [JsonPropertyName("comarca")]
    public bool Comarca { get; set; }

    /// <summary>
    /// Sem descrição - cidCapital  
    /// </summary>
    [JsonPropertyName("capital")]
    public bool Capital { get; set; }

    /// <summary>
    /// Sem descrição - cidNome - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - cidSigla - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("sigla")]
    public string Sigla { get; set; } = "";

    /// <summary>
    /// GUId - cidGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}