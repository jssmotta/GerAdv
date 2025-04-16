#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAlarmSMS
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [JsonPropertyName("hora")]
    public int Hora { get; set; } = -2147483648;

    [JsonPropertyName("minuto")]
    public int Minuto { get; set; } = -2147483648;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("today")]
    public string Today { get; set; } = string.Empty;

    [JsonPropertyName("alertardatahora")]
    public string AlertarDataHora { get; set; } = string.Empty;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;

    [JsonPropertyName("agenda")]
    public int Agenda { get; set; } = -2147483648;

    [JsonPropertyName("recado")]
    public int Recado { get; set; } = -2147483648;

    [JsonPropertyName("emocao")]
    public int Emocao { get; set; } = -2147483648;
}