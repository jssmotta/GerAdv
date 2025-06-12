#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GUTMatrizResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - gutGUTTipo  
    /// </summary>
    [JsonPropertyName("guttipo")]
    public int GUTTipo { get; set; }

    /// <summary>
    /// Sem descrição - gutDescricao - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - gutValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public int Valor { get; set; }
}

[Serializable]
public partial class GUTMatrizResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - gutGUTTipo  
    /// </summary>
    [JsonPropertyName("guttipo")]
    public int GUTTipo { get; set; }

    /// <summary>
    /// Sem descrição - gutDescricao - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - gutValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public int Valor { get; set; }

    [JsonPropertyName("nomeguttipo")]
    public string NomeGUTTipo { get; set; } = string.Empty;
}