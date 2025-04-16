#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterProSucumbencia
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("instancia")]
    public int Instancia { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("tipoorigemsucumbencia")]
    public int TipoOrigemSucumbencia { get; set; } = -2147483648;

    [JsonPropertyName("percentual")]
    public string Percentual { get; set; } = string.Empty;
}