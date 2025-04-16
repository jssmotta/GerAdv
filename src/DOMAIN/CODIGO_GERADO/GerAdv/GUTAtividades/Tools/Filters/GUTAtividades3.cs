#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterGUTAtividades
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = string.Empty;

    [JsonPropertyName("gutgrupo")]
    public int GUTGrupo { get; set; } = -2147483648;

    [JsonPropertyName("gutperiodicidade")]
    public int GUTPeriodicidade { get; set; } = -2147483648;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;

    [JsonPropertyName("dataconcluido")]
    public string DataConcluido { get; set; } = string.Empty;

    [JsonPropertyName("diasparainiciar")]
    public int DiasParaIniciar { get; set; } = -2147483648;

    [JsonPropertyName("minutospararealizar")]
    public int MinutosParaRealizar { get; set; } = -2147483648;
}