#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterGUTAtividadesMatriz
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("gutmatriz")]
    public int GUTMatriz { get; set; } = -2147483648;

    [JsonPropertyName("gutatividade")]
    public int GUTAtividade { get; set; } = -2147483648;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}