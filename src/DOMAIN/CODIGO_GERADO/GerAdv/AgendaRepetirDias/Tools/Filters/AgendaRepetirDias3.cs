#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAgendaRepetirDias
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = string.Empty;

    [JsonPropertyName("master")]
    public int Master { get; set; } = -2147483648;

    [JsonPropertyName("dia")]
    public int Dia { get; set; } = -2147483648;

    [JsonPropertyName("hora")]
    public string Hora { get; set; } = string.Empty;
}