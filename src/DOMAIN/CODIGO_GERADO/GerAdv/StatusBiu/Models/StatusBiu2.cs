#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class StatusBiu
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - stbTipoStatusBiu  
    /// </summary>
    [JsonPropertyName("tipostatusbiu")]
    public int TipoStatusBiu { get; set; }

    /// <summary>
    /// Sem descrição - stbOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - stbNome - tamanho máximo: 1024 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - stbIcone  
    /// </summary>
    [JsonPropertyName("icone")]
    public int Icone { get; set; }
}

[Serializable]
public partial class StatusBiuAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - stbTipoStatusBiu  
    /// </summary>
    [JsonPropertyName("tipostatusbiu")]
    public int TipoStatusBiu { get; set; }

    /// <summary>
    /// Sem descrição - stbOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - stbNome - tamanho máximo: 1024 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - stbIcone  
    /// </summary>
    [JsonPropertyName("icone")]
    public int Icone { get; set; }

    [JsonPropertyName("nometipostatusbiu")]
    public string NomeTipoStatusBiu { get; set; } = string.Empty;

    [JsonPropertyName("nomeoperador")]
    public string NomeOperador { get; set; } = string.Empty;
}