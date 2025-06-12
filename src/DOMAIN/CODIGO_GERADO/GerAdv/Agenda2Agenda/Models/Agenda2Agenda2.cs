#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Agenda2Agenda
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ag2Agenda  
    /// </summary>
    [JsonPropertyName("agenda")]
    public int Agenda { get; set; }

    /// <summary>
    /// Sem descrição - ag2Master  
    /// </summary>
    [JsonPropertyName("master")]
    public int Master { get; set; }
}

[Serializable]
public partial class Agenda2AgendaAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ag2Agenda  
    /// </summary>
    [JsonPropertyName("agenda")]
    public int Agenda { get; set; }

    /// <summary>
    /// Sem descrição - ag2Master  
    /// </summary>
    [JsonPropertyName("master")]
    public int Master { get; set; }
}