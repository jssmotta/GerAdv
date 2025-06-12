#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class SMSAlice
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - smaOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - smaTipoEMail  
    /// </summary>
    [JsonPropertyName("tipoemail")]
    public int TipoEMail { get; set; }

    /// <summary>
    /// Sem descrição - smaNome - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// GUId - smaGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class SMSAliceAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - smaOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - smaTipoEMail  
    /// </summary>
    [JsonPropertyName("tipoemail")]
    public int TipoEMail { get; set; }

    /// <summary>
    /// Sem descrição - smaNome - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// GUId - smaGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomeoperador")]
    public string NomeOperador { get; set; } = string.Empty;

    [JsonPropertyName("nometipoemail")]
    public string NomeTipoEMail { get; set; } = string.Empty;
}