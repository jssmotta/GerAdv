#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProcessOutputRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - porProcessOutputEngine  
    /// </summary>
    [JsonPropertyName("processoutputengine")]
    public int ProcessOutputEngine { get; set; }

    /// <summary>
    /// Sem descrição - porOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - porProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - porUltimoIdTabelaExo  
    /// </summary>
    [JsonPropertyName("ultimoidtabelaexo")]
    public int UltimoIdTabelaExo { get; set; }

    /// <summary>
    /// GUId - porGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}