#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterFornecedores
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("grupo")]
    public int Grupo { get; set; } = -2147483648;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("subgrupo")]
    public int SubGrupo { get; set; } = -2147483648;

    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = string.Empty;

    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = string.Empty;

    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = string.Empty;

    [JsonPropertyName("rg")]
    public string RG { get; set; } = string.Empty;

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

    [JsonPropertyName("fax")]
    public string Fax { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("site")]
    public string Site { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string Obs { get; set; } = string.Empty;

    [JsonPropertyName("produtos")]
    public string Produtos { get; set; } = string.Empty;

    [JsonPropertyName("contatos")]
    public string Contatos { get; set; } = string.Empty;
}