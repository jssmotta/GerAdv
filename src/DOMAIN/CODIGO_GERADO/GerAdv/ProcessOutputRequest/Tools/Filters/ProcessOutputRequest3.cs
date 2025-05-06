#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterProcessOutputRequest
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("processoutputengine")]
    public int ProcessOutputEngine { get; set; } = -2147483648;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("ultimoidtabelaexo")]
    public int UltimoIdTabelaExo { get; set; } = -2147483648;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}