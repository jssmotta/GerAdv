#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterProValores
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("tipovalorprocesso")]
    public int TipoValorProcesso { get; set; } = -2147483648;

    [JsonPropertyName("indice")]
    public string Indice { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("dataultimacorrecao")]
    public string DataUltimaCorrecao { get; set; } = string.Empty;
}