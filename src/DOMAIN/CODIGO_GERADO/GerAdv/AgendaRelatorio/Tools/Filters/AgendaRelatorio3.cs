#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAgendaRelatorio
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("paranome")]
    public string ParaNome { get; set; } = string.Empty;

    [JsonPropertyName("parapessoas")]
    public string ParaPessoas { get; set; } = string.Empty;

    [JsonPropertyName("boxaudiencia")]
    public string BoxAudiencia { get; set; } = string.Empty;

    [JsonPropertyName("boxaudienciamobile")]
    public string BoxAudienciaMobile { get; set; } = string.Empty;

    [JsonPropertyName("nomeadvogado")]
    public string NomeAdvogado { get; set; } = string.Empty;

    [JsonPropertyName("nomeforo")]
    public string NomeForo { get; set; } = string.Empty;

    [JsonPropertyName("nomejustica")]
    public string NomeJustica { get; set; } = string.Empty;

    [JsonPropertyName("nomearea")]
    public string NomeArea { get; set; } = string.Empty;
}