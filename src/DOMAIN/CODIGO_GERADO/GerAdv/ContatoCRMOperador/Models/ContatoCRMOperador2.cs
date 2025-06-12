#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ContatoCRMOperador
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ccoContatoCRM  
    /// </summary>
    [JsonPropertyName("contatocrm")]
    public int ContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - ccoOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - ccoCargoEsc  
    /// </summary>
    [JsonPropertyName("cargoesc")]
    public int CargoEsc { get; set; }
}

[Serializable]
public partial class ContatoCRMOperadorAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ccoContatoCRM  
    /// </summary>
    [JsonPropertyName("contatocrm")]
    public int ContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - ccoOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - ccoCargoEsc  
    /// </summary>
    [JsonPropertyName("cargoesc")]
    public int CargoEsc { get; set; }

    [JsonPropertyName("nomeoperador")]
    public string NomeOperador { get; set; } = string.Empty;
}