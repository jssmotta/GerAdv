#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterHistorico
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("extraid")]
    public int ExtraID { get; set; } = -2147483648;

    [JsonPropertyName("idne")]
    public int IDNE { get; set; } = -2147483648;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;

    [JsonPropertyName("liminarorigem")]
    public int LiminarOrigem { get; set; } = -2147483648;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("precatoria")]
    public int Precatoria { get; set; } = -2147483648;

    [JsonPropertyName("apenso")]
    public int Apenso { get; set; } = -2147483648;

    [JsonPropertyName("idinstprocesso")]
    public int IDInstProcesso { get; set; } = -2147483648;

    [JsonPropertyName("fase")]
    public int Fase { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = string.Empty;

    [JsonPropertyName("sad")]
    public int SAD { get; set; } = -2147483648;

    [JsonPropertyName("statusandamento")]
    public int StatusAndamento { get; set; } = -2147483648;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}