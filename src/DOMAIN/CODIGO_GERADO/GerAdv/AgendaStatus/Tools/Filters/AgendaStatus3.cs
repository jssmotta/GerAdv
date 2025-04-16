#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAgendaStatus
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("agenda")]
    public int Agenda { get; set; } = -2147483648;

    [JsonPropertyName("completed")]
    public int Completed { get; set; } = -2147483648;
}