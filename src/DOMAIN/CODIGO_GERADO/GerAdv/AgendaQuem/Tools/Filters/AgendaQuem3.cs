#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAgendaQuem
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("idagenda")]
    public int IDAgenda { get; set; } = -2147483648;

    [JsonPropertyName("advogado")]
    public int Advogado { get; set; } = -2147483648;

    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; } = -2147483648;

    [JsonPropertyName("preposto")]
    public int Preposto { get; set; } = -2147483648;
}