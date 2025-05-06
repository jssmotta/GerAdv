#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterDadosProcuracao
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("estadocivil")]
    public string EstadoCivil { get; set; } = string.Empty;

    [JsonPropertyName("nacionalidade")]
    public string Nacionalidade { get; set; } = string.Empty;

    [JsonPropertyName("profissao")]
    public string Profissao { get; set; } = string.Empty;

    [JsonPropertyName("ctps")]
    public string CTPS { get; set; } = string.Empty;

    [JsonPropertyName("pispasep")]
    public string PisPasep { get; set; } = string.Empty;

    [JsonPropertyName("remuneracao")]
    public string Remuneracao { get; set; } = string.Empty;

    [JsonPropertyName("objeto")]
    public string Objeto { get; set; } = string.Empty;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}