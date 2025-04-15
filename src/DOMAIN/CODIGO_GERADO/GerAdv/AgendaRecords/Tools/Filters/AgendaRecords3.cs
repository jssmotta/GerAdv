#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAgendaRecords
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("agenda")]
    public int Agenda { get; set; } = -2147483648;

    [JsonPropertyName("julgador")]
    public int Julgador { get; set; } = -2147483648;

    [JsonPropertyName("clientessocios")]
    public int ClientesSocios { get; set; } = -2147483648;

    [JsonPropertyName("perito")]
    public int Perito { get; set; } = -2147483648;

    [JsonPropertyName("colaborador")]
    public int Colaborador { get; set; } = -2147483648;

    [JsonPropertyName("foro")]
    public int Foro { get; set; } = -2147483648;

    [JsonPropertyName("crmaviso1")]
    public int CrmAviso1 { get; set; } = -2147483648;

    [JsonPropertyName("crmaviso2")]
    public int CrmAviso2 { get; set; } = -2147483648;

    [JsonPropertyName("crmaviso3")]
    public int CrmAviso3 { get; set; } = -2147483648;

    [JsonPropertyName("dataaviso1")]
    public string DataAviso1 { get; set; } = string.Empty;

    [JsonPropertyName("dataaviso2")]
    public string DataAviso2 { get; set; } = string.Empty;

    [JsonPropertyName("dataaviso3")]
    public string DataAviso3 { get; set; } = string.Empty;
}