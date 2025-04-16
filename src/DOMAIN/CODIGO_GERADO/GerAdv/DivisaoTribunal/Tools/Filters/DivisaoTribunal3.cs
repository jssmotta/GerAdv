#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterDivisaoTribunal
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("numcodigo")]
    public int NumCodigo { get; set; } = -2147483648;

    [JsonPropertyName("justica")]
    public int Justica { get; set; } = -2147483648;

    [JsonPropertyName("nomeespecial")]
    public string NomeEspecial { get; set; } = string.Empty;

    [JsonPropertyName("area")]
    public int Area { get; set; } = -2147483648;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("foro")]
    public int Foro { get; set; } = -2147483648;

    [JsonPropertyName("tribunal")]
    public int Tribunal { get; set; } = -2147483648;

    [JsonPropertyName("codigodiv")]
    public string CodigoDiv { get; set; } = string.Empty;

    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = string.Empty;

    [JsonPropertyName("fone")]
    public string Fone { get; set; } = string.Empty;

    [JsonPropertyName("fax")]
    public string Fax { get; set; } = string.Empty;

    [JsonPropertyName("cep")]
    public string CEP { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string Obs { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("andar")]
    public string Andar { get; set; } = string.Empty;
}