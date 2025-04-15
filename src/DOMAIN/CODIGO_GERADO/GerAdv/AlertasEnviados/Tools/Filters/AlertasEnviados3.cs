#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAlertasEnviados
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;

    [JsonPropertyName("alerta")]
    public int Alerta { get; set; } = -2147483648;

    [JsonPropertyName("dataalertado")]
    public string DataAlertado { get; set; } = string.Empty;
}