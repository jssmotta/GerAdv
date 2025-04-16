#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterPoderJudiciarioAssociado
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("justica")]
    public int Justica { get; set; } = -2147483648;

    [JsonPropertyName("justicanome")]
    public string JusticaNome { get; set; } = string.Empty;

    [JsonPropertyName("area")]
    public int Area { get; set; } = -2147483648;

    [JsonPropertyName("areanome")]
    public string AreaNome { get; set; } = string.Empty;

    [JsonPropertyName("tribunal")]
    public int Tribunal { get; set; } = -2147483648;

    [JsonPropertyName("tribunalnome")]
    public string TribunalNome { get; set; } = string.Empty;

    [JsonPropertyName("foro")]
    public int Foro { get; set; } = -2147483648;

    [JsonPropertyName("foronome")]
    public string ForoNome { get; set; } = string.Empty;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("subdivisaonome")]
    public string SubDivisaoNome { get; set; } = string.Empty;

    [JsonPropertyName("cidadenome")]
    public string CidadeNome { get; set; } = string.Empty;

    [JsonPropertyName("subdivisao")]
    public int SubDivisao { get; set; } = -2147483648;

    [JsonPropertyName("tipo")]
    public int Tipo { get; set; } = -2147483648;
}