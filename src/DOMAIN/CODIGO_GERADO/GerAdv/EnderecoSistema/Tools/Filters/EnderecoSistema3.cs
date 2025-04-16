#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterEnderecoSistema
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("cadastro")]
    public int Cadastro { get; set; } = -2147483648;

    [JsonPropertyName("cadastroexcod")]
    public int CadastroExCod { get; set; } = -2147483648;

    [JsonPropertyName("tipoenderecosistema")]
    public int TipoEnderecoSistema { get; set; } = -2147483648;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("motivo")]
    public string Motivo { get; set; } = string.Empty;

    [JsonPropertyName("contatonolocal")]
    public string ContatoNoLocal { get; set; } = string.Empty;

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

    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = string.Empty;
}