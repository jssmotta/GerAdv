#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class PoderJudiciarioAssociado
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pjaJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - pjaArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - pjaTribunal  
    /// </summary>
    [JsonPropertyName("tribunal")]
    public int Tribunal { get; set; }

    /// <summary>
    /// Sem descrição - pjaForo  
    /// </summary>
    [JsonPropertyName("foro")]
    public int Foro { get; set; }

    /// <summary>
    /// Cidade - pjaCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - pjaJusticaNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("justicanome")]
    public string JusticaNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - pjaAreaNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("areanome")]
    public string AreaNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - pjaTribunalNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("tribunalnome")]
    public string TribunalNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - pjaForoNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("foronome")]
    public string ForoNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - pjaSubDivisaoNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("subdivisaonome")]
    public string SubDivisaoNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - pjaCidadeNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("cidadenome")]
    public string CidadeNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - pjaSubDivisao  
    /// </summary>
    [JsonPropertyName("subdivisao")]
    public int SubDivisao { get; set; }

    /// <summary>
    /// Sem descrição - pjaTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public int Tipo { get; set; }

    /// <summary>
    /// GUId - pjaGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}