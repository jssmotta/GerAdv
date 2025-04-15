#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GruposEmpresasCliResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - gecGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    /// <summary>
    /// Sem descrição - gecCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - gecOculto  
    /// </summary>
    [JsonPropertyName("oculto")]
    public bool Oculto { get; set; }

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}