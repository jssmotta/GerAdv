#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterReuniaoPessoas
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("reuniao")]
    public int Reuniao { get; set; } = -2147483648;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;
}