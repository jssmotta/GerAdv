#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class LivroCaixaClientes
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - lccLivroCaixa  
    /// </summary>
    [JsonPropertyName("livrocaixa")]
    public int LivroCaixa { get; set; }

    /// <summary>
    /// Sem descrição - lccCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - lccLancado  
    /// </summary>
    [JsonPropertyName("lancado")]
    public bool Lancado { get; set; }
}

[Serializable]
public partial class LivroCaixaClientesAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - lccLivroCaixa  
    /// </summary>
    [JsonPropertyName("livrocaixa")]
    public int LivroCaixa { get; set; }

    /// <summary>
    /// Sem descrição - lccCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - lccLancado  
    /// </summary>
    [JsonPropertyName("lancado")]
    public bool Lancado { get; set; }

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;
}