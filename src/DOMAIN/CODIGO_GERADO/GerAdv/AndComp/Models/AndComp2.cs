#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AndComp
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - acpAndamento  
    /// </summary>
    [JsonPropertyName("andamento")]
    public int Andamento { get; set; }

    /// <summary>
    /// Sem descrição - acpCompromisso  
    /// </summary>
    [JsonPropertyName("compromisso")]
    public int Compromisso { get; set; }
}

[Serializable]
public partial class AndCompAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - acpAndamento  
    /// </summary>
    [JsonPropertyName("andamento")]
    public int Andamento { get; set; }

    /// <summary>
    /// Sem descrição - acpCompromisso  
    /// </summary>
    [JsonPropertyName("compromisso")]
    public int Compromisso { get; set; }
}