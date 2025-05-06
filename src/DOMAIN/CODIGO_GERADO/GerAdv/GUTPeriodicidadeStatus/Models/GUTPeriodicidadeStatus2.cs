#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GUTPeriodicidadeStatus
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pgsGUTAtividade  
    /// </summary>
    [JsonPropertyName("gutatividade")]
    public int GUTAtividade { get; set; }

    /// <summary>
    /// Sem descrição - pgsDataRealizado  
    /// </summary>
    [JsonPropertyName("datarealizado")]
    public string DataRealizado { get; set; } = "";

    /// <summary>
    /// GUId - pgsGUID - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}