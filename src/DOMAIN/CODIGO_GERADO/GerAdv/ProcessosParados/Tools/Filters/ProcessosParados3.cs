#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterProcessosParados
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("semana")]
    public int Semana { get; set; } = -2147483648;

    [JsonPropertyName("ano")]
    public int Ano { get; set; } = -2147483648;

    [JsonPropertyName("datahora")]
    public string DataHora { get; set; } = string.Empty;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;

    [JsonPropertyName("datahistorico")]
    public string DataHistorico { get; set; } = string.Empty;

    [JsonPropertyName("datanenotas")]
    public string DataNENotas { get; set; } = string.Empty;
}