#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GruposEmpresas
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - grpOponente  
    /// </summary>
    [JsonPropertyName("oponente")]
    public int Oponente { get; set; }

    /// <summary>
    /// Sem descrição - grpCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - grpEMail - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - grpInativo  
    /// </summary>
    [JsonPropertyName("inativo")]
    public bool Inativo { get; set; }

    /// <summary>
    /// Sem descrição - grpDescricao - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - grpObservacoes  
    /// </summary>
    [JsonPropertyName("observacoes")]
    public string Observacoes { get; set; } = "";

    /// <summary>
    /// Sem descrição - grpIcone - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("icone")]
    public string Icone { get; set; } = "";

    /// <summary>
    /// Sem descrição - grpDespesaUnificada  
    /// </summary>
    [JsonPropertyName("despesaunificada")]
    public bool DespesaUnificada { get; set; }

    /// <summary>
    /// GUId - grpGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}