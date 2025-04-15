#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterProDespesas
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("ligacaoid")]
    public int LigacaoID { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("quitado")]
    public int Quitado { get; set; } = -2147483648;

    [JsonPropertyName("datacorrecao")]
    public string DataCorrecao { get; set; } = string.Empty;

    [JsonPropertyName("historico")]
    public string Historico { get; set; } = string.Empty;
}