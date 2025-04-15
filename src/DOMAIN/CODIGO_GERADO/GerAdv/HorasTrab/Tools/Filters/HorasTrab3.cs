#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterHorasTrab
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("idcontatocrm")]
    public int IDContatoCRM { get; set; } = -2147483648;

    [JsonPropertyName("idagenda")]
    public int IDAgenda { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("status")]
    public int Status { get; set; } = -2147483648;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("advogado")]
    public int Advogado { get; set; } = -2147483648;

    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; } = -2147483648;

    [JsonPropertyName("hrini")]
    public string HrIni { get; set; } = string.Empty;

    [JsonPropertyName("hrfim")]
    public string HrFim { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string OBS { get; set; } = string.Empty;

    [JsonPropertyName("anexo")]
    public string Anexo { get; set; } = string.Empty;

    [JsonPropertyName("anexocomp")]
    public string AnexoComp { get; set; } = string.Empty;

    [JsonPropertyName("anexounc")]
    public string AnexoUNC { get; set; } = string.Empty;

    [JsonPropertyName("servico")]
    public int Servico { get; set; } = -2147483648;
}