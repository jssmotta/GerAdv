#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ModelosDocumentosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - mdcTipoModeloDocumento  
    /// </summary>
    [JsonPropertyName("tipomodelodocumento")]
    public int TipoModeloDocumento { get; set; }

    /// <summary>
    /// Sem descrição - mdcNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcRemuneracao  
    /// </summary>
    [JsonPropertyName("remuneracao")]
    public string Remuneracao { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcAssinatura  
    /// </summary>
    [JsonPropertyName("assinatura")]
    public string Assinatura { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcHeader  
    /// </summary>
    [JsonPropertyName("header")]
    public string Header { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcFooter  
    /// </summary>
    [JsonPropertyName("footer")]
    public string Footer { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcExtra1  
    /// </summary>
    [JsonPropertyName("extra1")]
    public string Extra1 { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcExtra2  
    /// </summary>
    [JsonPropertyName("extra2")]
    public string Extra2 { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcExtra3  
    /// </summary>
    [JsonPropertyName("extra3")]
    public string Extra3 { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcOutorgante  
    /// </summary>
    [JsonPropertyName("outorgante")]
    public string Outorgante { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcOutorgados  
    /// </summary>
    [JsonPropertyName("outorgados")]
    public string Outorgados { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcPoderes  
    /// </summary>
    [JsonPropertyName("poderes")]
    public string Poderes { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcObjeto  
    /// </summary>
    [JsonPropertyName("objeto")]
    public string Objeto { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcTitulo - tamanho máximo: 2000 
    /// </summary>
    [JsonPropertyName("titulo")]
    public string Titulo { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcTestemunhas  
    /// </summary>
    [JsonPropertyName("testemunhas")]
    public string Testemunhas { get; set; } = "";

    /// <summary>
    /// Sem descrição - mdcCSS  
    /// </summary>
    [JsonPropertyName("css")]
    public string CSS { get; set; } = "";

    /// <summary>
    /// GUId - mdcGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}