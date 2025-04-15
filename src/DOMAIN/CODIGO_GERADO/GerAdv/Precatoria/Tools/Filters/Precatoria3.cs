#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterPrecatoria
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("dtdist")]
    public string DtDist { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("precatoriax")]
    public string PrecatoriaX { get; set; } = string.Empty;

    [JsonPropertyName("deprecante")]
    public string Deprecante { get; set; } = string.Empty;

    [JsonPropertyName("deprecado")]
    public string Deprecado { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string OBS { get; set; } = string.Empty;
}