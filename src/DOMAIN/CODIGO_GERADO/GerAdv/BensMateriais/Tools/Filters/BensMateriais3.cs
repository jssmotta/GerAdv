#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterBensMateriais
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("bensclassificacao")]
    public int BensClassificacao { get; set; } = -2147483648;

    [JsonPropertyName("datacompra")]
    public string DataCompra { get; set; } = string.Empty;

    [JsonPropertyName("datafimdagarantia")]
    public string DataFimDaGarantia { get; set; } = string.Empty;

    [JsonPropertyName("nfnro")]
    public string NFNRO { get; set; } = string.Empty;

    [JsonPropertyName("fornecedor")]
    public int Fornecedor { get; set; } = -2147483648;

    [JsonPropertyName("nroserieproduto")]
    public string NroSerieProduto { get; set; } = string.Empty;

    [JsonPropertyName("comprador")]
    public string Comprador { get; set; } = string.Empty;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("dataterminodagarantiadaloja")]
    public string DataTerminoDaGarantiaDaLoja { get; set; } = string.Empty;

    [JsonPropertyName("observacoes")]
    public string Observacoes { get; set; } = string.Empty;

    [JsonPropertyName("nomevendedor")]
    public string NomeVendedor { get; set; } = string.Empty;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}