#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterColaboradores
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("cargo")]
    public int Cargo { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = string.Empty;

    [JsonPropertyName("rg")]
    public string RG { get; set; } = string.Empty;

    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = string.Empty;

    [JsonPropertyName("idade")]
    public int Idade { get; set; } = -2147483648;

    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = string.Empty;

    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [JsonPropertyName("cep")]
    public string CEP { get; set; } = string.Empty;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("fone")]
    public string Fone { get; set; } = string.Empty;

    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("cnh")]
    public string CNH { get; set; } = string.Empty;

    [JsonPropertyName("class")]
    public string Class { get; set; } = string.Empty;
}