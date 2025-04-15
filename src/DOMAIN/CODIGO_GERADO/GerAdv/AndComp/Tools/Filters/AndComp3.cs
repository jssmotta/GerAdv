#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAndComp
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("andamento")]
    public int Andamento { get; set; } = -2147483648;

    [JsonPropertyName("compromisso")]
    public int Compromisso { get; set; } = -2147483648;
}