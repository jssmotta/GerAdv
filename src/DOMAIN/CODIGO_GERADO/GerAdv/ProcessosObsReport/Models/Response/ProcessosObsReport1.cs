#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProcessosObsReportResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - prrProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - prrHistorico  
    /// </summary>
    [JsonPropertyName("historico")]
    public int Historico { get; set; }

    /// <summary>
    /// Sem descrição - prrData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - prrObservacao - tamanho máximo: 2048 
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}