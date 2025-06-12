#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class TipoCompromissoResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - tipIcone  
    /// </summary>
    [JsonPropertyName("icone")]
    public int Icone { get; set; }

    /// <summary>
    /// Sem descrição - tipDescricao - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - tipFinanceiro  
    /// </summary>
    [JsonPropertyName("financeiro")]
    public bool Financeiro { get; set; }

    /// <summary>
    /// Negritar - tipBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - tipGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class TipoCompromissoResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - tipIcone  
    /// </summary>
    [JsonPropertyName("icone")]
    public int Icone { get; set; }

    /// <summary>
    /// Sem descrição - tipDescricao - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - tipFinanceiro  
    /// </summary>
    [JsonPropertyName("financeiro")]
    public bool Financeiro { get; set; }

    /// <summary>
    /// Negritar - tipBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - tipGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}