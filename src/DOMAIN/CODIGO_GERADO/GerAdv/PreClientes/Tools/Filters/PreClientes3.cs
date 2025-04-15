#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterPreClientes
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("quemindicou")]
    public string QuemIndicou { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("adv")]
    public int Adv { get; set; } = -2147483648;

    [JsonPropertyName("idrep")]
    public int IDRep { get; set; } = -2147483648;

    [JsonPropertyName("nomefantasia")]
    public string NomeFantasia { get; set; } = string.Empty;

    [JsonPropertyName("class")]
    public string Class { get; set; } = string.Empty;

    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = string.Empty;

    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = string.Empty;

    [JsonPropertyName("qualificacao")]
    public string Qualificacao { get; set; } = string.Empty;

    [JsonPropertyName("idade")]
    public int Idade { get; set; } = -2147483648;

    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = string.Empty;

    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = string.Empty;

    [JsonPropertyName("rg")]
    public string RG { get; set; } = string.Empty;

    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = string.Empty;

    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = string.Empty;

    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("cep")]
    public string CEP { get; set; } = string.Empty;

    [JsonPropertyName("fax")]
    public string Fax { get; set; } = string.Empty;

    [JsonPropertyName("fone")]
    public string Fone { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("homepage")]
    public string HomePage { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("assistido")]
    public string Assistido { get; set; } = string.Empty;

    [JsonPropertyName("assrg")]
    public string AssRG { get; set; } = string.Empty;

    [JsonPropertyName("asscpf")]
    public string AssCPF { get; set; } = string.Empty;

    [JsonPropertyName("assendereco")]
    public string AssEndereco { get; set; } = string.Empty;

    [JsonPropertyName("cnh")]
    public string CNH { get; set; } = string.Empty;
}