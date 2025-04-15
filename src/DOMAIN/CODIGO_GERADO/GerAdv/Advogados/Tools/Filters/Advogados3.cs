#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAdvogados
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("cargo")]
    public int Cargo { get; set; } = -2147483648;

    [JsonPropertyName("emailpro")]
    public string EMailPro { get; set; } = string.Empty;

    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("rg")]
    public string RG { get; set; } = string.Empty;

    [JsonPropertyName("nomemae")]
    public string NomeMae { get; set; } = string.Empty;

    [JsonPropertyName("escritorio")]
    public int Escritorio { get; set; } = -2147483648;

    [JsonPropertyName("oab")]
    public string OAB { get; set; } = string.Empty;

    [JsonPropertyName("nomecompleto")]
    public string NomeCompleto { get; set; } = string.Empty;

    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = string.Empty;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("cep")]
    public string CEP { get; set; } = string.Empty;

    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [JsonPropertyName("ctpsserie")]
    public string CTPSSerie { get; set; } = string.Empty;

    [JsonPropertyName("ctps")]
    public string CTPS { get; set; } = string.Empty;

    [JsonPropertyName("fone")]
    public string Fone { get; set; } = string.Empty;

    [JsonPropertyName("fax")]
    public string Fax { get; set; } = string.Empty;

    [JsonPropertyName("comissao")]
    public int Comissao { get; set; } = -2147483648;

    [JsonPropertyName("dtinicio")]
    public string DtInicio { get; set; } = string.Empty;

    [JsonPropertyName("dtfim")]
    public string DtFim { get; set; } = string.Empty;

    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = string.Empty;

    [JsonPropertyName("secretaria")]
    public string Secretaria { get; set; } = string.Empty;

    [JsonPropertyName("textoprocuracao")]
    public string TextoProcuracao { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("especializacao")]
    public string Especializacao { get; set; } = string.Empty;

    [JsonPropertyName("pasta")]
    public string Pasta { get; set; } = string.Empty;

    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = string.Empty;

    [JsonPropertyName("contabancaria")]
    public string ContaBancaria { get; set; } = string.Empty;

    [JsonPropertyName("class")]
    public string Class { get; set; } = string.Empty;
}