#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class OperadorGrupo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ogrOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - ogrGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    /// <summary>
    /// Sem descrição - ogrInativo  
    /// </summary>
    [JsonPropertyName("inativo")]
    public bool Inativo { get; set; }

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}