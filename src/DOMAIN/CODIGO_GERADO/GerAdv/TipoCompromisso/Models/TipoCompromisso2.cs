#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class TipoCompromisso
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
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}