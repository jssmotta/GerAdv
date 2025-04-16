#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterLivroCaixa
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("iddes")]
    public int IDDes { get; set; } = -2147483648;

    [JsonPropertyName("pessoal")]
    public int Pessoal { get; set; } = -2147483648;

    [JsonPropertyName("idhon")]
    public int IDHon { get; set; } = -2147483648;

    [JsonPropertyName("idhonparc")]
    public int IDHonParc { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("historico")]
    public string Historico { get; set; } = string.Empty;

    [JsonPropertyName("grupo")]
    public int Grupo { get; set; } = -2147483648;
}