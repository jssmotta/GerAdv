#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Agenda2AgendaResponse
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

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}