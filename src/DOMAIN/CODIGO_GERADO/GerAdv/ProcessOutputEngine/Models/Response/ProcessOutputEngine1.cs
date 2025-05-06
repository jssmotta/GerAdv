#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProcessOutputEngineResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - poeNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - poeDatabase - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("database")]
    public string Database { get; set; } = "";

    /// <summary>
    /// Sem descrição - poeTabela - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("tabela")]
    public string Tabela { get; set; } = "";

    /// <summary>
    /// Sem descrição - poeCampo - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("campo")]
    public string Campo { get; set; } = "";

    /// <summary>
    /// Sem descrição - poeValor - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("valor")]
    public string Valor { get; set; } = "";

    /// <summary>
    /// Sem descrição - poeOutput  
    /// </summary>
    [JsonPropertyName("output")]
    public string Output { get; set; } = "";

    /// <summary>
    /// Sem descrição - poeAdministrador  
    /// </summary>
    [JsonPropertyName("administrador")]
    public bool Administrador { get; set; }

    /// <summary>
    /// Sem descrição - poeOutputSource  
    /// </summary>
    [JsonPropertyName("outputsource")]
    public int OutputSource { get; set; }

    /// <summary>
    /// Sem descrição - poeDisabledItem  
    /// </summary>
    [JsonPropertyName("disableditem")]
    public bool DisabledItem { get; set; }

    /// <summary>
    /// Sem descrição - poeIDModulo  
    /// </summary>
    [JsonPropertyName("idmodulo")]
    public int IDModulo { get; set; }

    /// <summary>
    /// Sem descrição - poeIsOnlyProcesso  
    /// </summary>
    [JsonPropertyName("isonlyprocesso")]
    public bool IsOnlyProcesso { get; set; }

    /// <summary>
    /// Sem descrição - poeMyID  
    /// </summary>
    [JsonPropertyName("myid")]
    public int MyID { get; set; }

    /// <summary>
    /// GUId - poeGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}