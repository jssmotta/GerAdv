#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterTerceiros
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("situacao")]
    public int Situacao { get; set; } = -2147483648;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = string.Empty;

    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [JsonPropertyName("cep")]
    public string CEP { get; set; } = string.Empty;

    [JsonPropertyName("fone")]
    public string Fone { get; set; } = string.Empty;

    [JsonPropertyName("fax")]
    public string Fax { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string OBS { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("class")]
    public string Class { get; set; } = string.Empty;

    [JsonPropertyName("varaforocomarca")]
    public string VaraForoComarca { get; set; } = string.Empty;
}