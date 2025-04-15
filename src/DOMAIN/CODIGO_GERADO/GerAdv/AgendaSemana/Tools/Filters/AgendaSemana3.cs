#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAgendaSemana
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("paranome")]
    public string ParaNome { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; } = -2147483648;

    [JsonPropertyName("advogado")]
    public int Advogado { get; set; } = -2147483648;

    [JsonPropertyName("hora")]
    public string Hora { get; set; } = string.Empty;

    [JsonPropertyName("tipocompromisso")]
    public int TipoCompromisso { get; set; } = -2147483648;

    [JsonPropertyName("compromisso")]
    public string Compromisso { get; set; } = string.Empty;

    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("nomecliente")]
    public string NomeCliente { get; set; } = string.Empty;

    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;
}