#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterApenso
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("apensox")]
    public string ApensoX { get; set; } = string.Empty;

    [JsonPropertyName("acao")]
    public string Acao { get; set; } = string.Empty;

    [JsonPropertyName("dtdist")]
    public string DtDist { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string OBS { get; set; } = string.Empty;
}