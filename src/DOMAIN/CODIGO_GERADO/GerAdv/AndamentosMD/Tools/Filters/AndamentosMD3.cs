#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAndamentosMD
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("andamento")]
    public int Andamento { get; set; } = -2147483648;

    [JsonPropertyName("pathfull")]
    public string PathFull { get; set; } = string.Empty;

    [JsonPropertyName("unc")]
    public string UNC { get; set; } = string.Empty;
}