#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AgendaQuemResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - agqAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - agqFuncionario  
    /// </summary>
    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; }

    /// <summary>
    /// Sem descrição - agqPreposto  
    /// </summary>
    [JsonPropertyName("preposto")]
    public int Preposto { get; set; }

    /// <summary>
    /// Sem descrição - agqIDAgenda  
    /// </summary>
    [JsonPropertyName("idagenda")]
    public int IDAgenda { get; set; }
}