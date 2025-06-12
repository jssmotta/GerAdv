#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AgendaStatus
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - astAgenda  
    /// </summary>
    [JsonPropertyName("agenda")]
    public int Agenda { get; set; }

    /// <summary>
    /// Sem descrição - astCompleted  
    /// </summary>
    [JsonPropertyName("completed")]
    public int Completed { get; set; }
}

[Serializable]
public partial class AgendaStatusAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - astAgenda  
    /// </summary>
    [JsonPropertyName("agenda")]
    public int Agenda { get; set; }

    /// <summary>
    /// Sem descrição - astCompleted  
    /// </summary>
    [JsonPropertyName("completed")]
    public int Completed { get; set; }
}