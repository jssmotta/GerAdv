#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class OperadoresResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - operCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - operEnviado  
    /// </summary>
    [JsonPropertyName("enviado")]
    public bool Enviado { get; set; }

    /// <summary>
    /// Sem descrição - operCasa  
    /// </summary>
    [JsonPropertyName("casa")]
    public bool Casa { get; set; }

    /// <summary>
    /// Sem descrição - operCasaID  
    /// </summary>
    [JsonPropertyName("casaid")]
    public int CasaID { get; set; }

    /// <summary>
    /// Sem descrição - operCasaCodigo  
    /// </summary>
    [JsonPropertyName("casacodigo")]
    public int CasaCodigo { get; set; }

    /// <summary>
    /// Sem descrição - operIsNovo  
    /// </summary>
    [JsonPropertyName("isnovo")]
    public bool IsNovo { get; set; }

    /// <summary>
    /// Sem descrição - operGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    /// <summary>
    /// Sem descrição - operNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - operEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - operAtivado  
    /// </summary>
    [JsonPropertyName("ativado")]
    public bool Ativado { get; set; }

    /// <summary>
    /// Sem descrição - operSuporteMaxAge  
    /// </summary>
    [JsonPropertyName("suportemaxage")]
    public string SuporteMaxAge { get; set; } = "";
}

[Serializable]
public partial class OperadoresResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - operCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - operEnviado  
    /// </summary>
    [JsonPropertyName("enviado")]
    public bool Enviado { get; set; }

    /// <summary>
    /// Sem descrição - operCasa  
    /// </summary>
    [JsonPropertyName("casa")]
    public bool Casa { get; set; }

    /// <summary>
    /// Sem descrição - operCasaID  
    /// </summary>
    [JsonPropertyName("casaid")]
    public int CasaID { get; set; }

    /// <summary>
    /// Sem descrição - operCasaCodigo  
    /// </summary>
    [JsonPropertyName("casacodigo")]
    public int CasaCodigo { get; set; }

    /// <summary>
    /// Sem descrição - operIsNovo  
    /// </summary>
    [JsonPropertyName("isnovo")]
    public bool IsNovo { get; set; }

    /// <summary>
    /// Sem descrição - operGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    /// <summary>
    /// Sem descrição - operNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - operEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - operAtivado  
    /// </summary>
    [JsonPropertyName("ativado")]
    public bool Ativado { get; set; }

    /// <summary>
    /// Sem descrição - operSuporteMaxAge  
    /// </summary>
    [JsonPropertyName("suportemaxage")]
    public string SuporteMaxAge { get; set; } = "";

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;
}