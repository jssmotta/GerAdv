#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterContatoCRMOperador
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("contatocrm")]
    public int ContatoCRM { get; set; } = -2147483648;

    [JsonPropertyName("cargoesc")]
    public int CargoEsc { get; set; } = -2147483648;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;
}