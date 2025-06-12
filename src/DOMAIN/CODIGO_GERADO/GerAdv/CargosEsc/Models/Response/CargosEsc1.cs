#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class CargosEscResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - cgePercentual  
    /// </summary>
    [JsonPropertyName("percentual")]
    public decimal Percentual { get; set; }

    /// <summary>
    /// Sem descrição - cgeNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - cgeClassificacao  
    /// </summary>
    [JsonPropertyName("classificacao")]
    public int Classificacao { get; set; }

    /// <summary>
    /// GUId - cgeGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class CargosEscResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - cgePercentual  
    /// </summary>
    [JsonPropertyName("percentual")]
    public decimal Percentual { get; set; }

    /// <summary>
    /// Sem descrição - cgeNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - cgeClassificacao  
    /// </summary>
    [JsonPropertyName("classificacao")]
    public int Classificacao { get; set; }

    /// <summary>
    /// GUId - cgeGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}