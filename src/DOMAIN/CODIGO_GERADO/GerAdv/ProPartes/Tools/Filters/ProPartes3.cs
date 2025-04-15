#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterProPartes
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("parte")]
    public int Parte { get; set; } = -2147483648;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;
}