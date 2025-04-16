#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProcessosParadosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pprProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - pprOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - pprSemana  
    /// </summary>
    [JsonPropertyName("semana")]
    public int Semana { get; set; }

    /// <summary>
    /// Sem descrição - pprAno  
    /// </summary>
    [JsonPropertyName("ano")]
    public int Ano { get; set; }

    /// <summary>
    /// Sem descrição - pprDataHora  
    /// </summary>
    [JsonPropertyName("datahora")]
    public string DataHora { get; set; } = "";

    /// <summary>
    /// Sem descrição - pprDataHistorico  
    /// </summary>
    [JsonPropertyName("datahistorico")]
    public string DataHistorico { get; set; } = "";

    /// <summary>
    /// Sem descrição - pprDataNENotas  
    /// </summary>
    [JsonPropertyName("datanenotas")]
    public string DataNENotas { get; set; } = "";
}