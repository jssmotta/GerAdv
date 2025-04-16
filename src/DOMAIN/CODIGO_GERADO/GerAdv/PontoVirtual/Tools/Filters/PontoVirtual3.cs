#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterPontoVirtual
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("horaentrada")]
    public string HoraEntrada { get; set; } = string.Empty;

    [JsonPropertyName("horasaida")]
    public string HoraSaida { get; set; } = string.Empty;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;

    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
}