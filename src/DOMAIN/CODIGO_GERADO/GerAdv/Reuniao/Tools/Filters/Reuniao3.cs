#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterReuniao
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("idagenda")]
    public int IDAgenda { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("pauta")]
    public string Pauta { get; set; } = string.Empty;

    [JsonPropertyName("ata")]
    public string ATA { get; set; } = string.Empty;

    [JsonPropertyName("horainicial")]
    public string HoraInicial { get; set; } = string.Empty;

    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = string.Empty;

    [JsonPropertyName("horasaida")]
    public string HoraSaida { get; set; } = string.Empty;

    [JsonPropertyName("horaretorno")]
    public string HoraRetorno { get; set; } = string.Empty;

    [JsonPropertyName("principaisdecisoes")]
    public string PrincipaisDecisoes { get; set; } = string.Empty;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}