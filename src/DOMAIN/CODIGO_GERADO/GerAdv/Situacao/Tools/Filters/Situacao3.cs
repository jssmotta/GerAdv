#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterSituacao
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("parte_int")]
    public string Parte_Int { get; set; } = string.Empty;

    [JsonPropertyName("parte_opo")]
    public string Parte_Opo { get; set; } = string.Empty;
}