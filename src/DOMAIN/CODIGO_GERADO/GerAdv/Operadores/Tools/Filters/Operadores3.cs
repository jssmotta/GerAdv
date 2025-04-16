#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterOperadores
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("casaid")]
    public int CasaID { get; set; } = -2147483648;

    [JsonPropertyName("casacodigo")]
    public int CasaCodigo { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("grupo")]
    public int Grupo { get; set; } = -2147483648;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("senha")]
    public string Senha { get; set; } = string.Empty;

    [JsonPropertyName("senha256")]
    public string Senha256 { get; set; } = string.Empty;

    [JsonPropertyName("suportesenha256")]
    public string SuporteSenha256 { get; set; } = string.Empty;

    [JsonPropertyName("suportemaxage")]
    public string SuporteMaxAge { get; set; } = string.Empty;
}