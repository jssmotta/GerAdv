#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ReuniaoPessoas
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - rnpReuniao  
    /// </summary>
    [JsonPropertyName("reuniao")]
    public int Reuniao { get; set; }

    /// <summary>
    /// Sem descrição - rnpOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }
}

[Serializable]
public partial class ReuniaoPessoasAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - rnpReuniao  
    /// </summary>
    [JsonPropertyName("reuniao")]
    public int Reuniao { get; set; }

    /// <summary>
    /// Sem descrição - rnpOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    [JsonPropertyName("nomeoperador")]
    public string NomeOperador { get; set; } = string.Empty;
}