#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAgenda2Agenda
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("master")]
    public int Master { get; set; } = -2147483648;

    [JsonPropertyName("agenda")]
    public int Agenda { get; set; } = -2147483648;
}