#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterPenhora
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [JsonPropertyName("datapenhora")]
    public string DataPenhora { get; set; } = string.Empty;

    [JsonPropertyName("penhorastatus")]
    public int PenhoraStatus { get; set; } = -2147483648;

    [JsonPropertyName("master")]
    public int Master { get; set; } = -2147483648;
}