#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterNENotas
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("apenso")]
    public int Apenso { get; set; } = -2147483648;

    [JsonPropertyName("precatoria")]
    public int Precatoria { get; set; } = -2147483648;

    [JsonPropertyName("instancia")]
    public int Instancia { get; set; } = -2147483648;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("palavrachave")]
    public int PalavraChave { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("notapublicada")]
    public string NotaPublicada { get; set; } = string.Empty;
}