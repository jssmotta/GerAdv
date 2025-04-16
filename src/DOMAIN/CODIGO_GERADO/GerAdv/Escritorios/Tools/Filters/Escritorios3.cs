#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterEscritorios
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("oab")]
    public string OAB { get; set; } = string.Empty;

    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = string.Empty;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [JsonPropertyName("cep")]
    public string CEP { get; set; } = string.Empty;

    [JsonPropertyName("fone")]
    public string Fone { get; set; } = string.Empty;

    [JsonPropertyName("fax")]
    public string Fax { get; set; } = string.Empty;

    [JsonPropertyName("site")]
    public string Site { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string OBS { get; set; } = string.Empty;

    [JsonPropertyName("advresponsavel")]
    public string AdvResponsavel { get; set; } = string.Empty;

    [JsonPropertyName("secretaria")]
    public string Secretaria { get; set; } = string.Empty;

    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = string.Empty;
}