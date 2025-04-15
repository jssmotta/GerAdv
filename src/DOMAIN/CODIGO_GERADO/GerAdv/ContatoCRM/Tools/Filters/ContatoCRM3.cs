#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterContatoCRM
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("ageclienteavisado")]
    public int AgeClienteAvisado { get; set; } = -2147483648;

    [JsonPropertyName("docsviarecebimento")]
    public int DocsViaRecebimento { get; set; } = -2147483648;

    [JsonPropertyName("assunto")]
    public string Assunto { get; set; } = string.Empty;

    [JsonPropertyName("quemnotificou")]
    public int QuemNotificou { get; set; } = -2147483648;

    [JsonPropertyName("datanotificou")]
    public string DataNotificou { get; set; } = string.Empty;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("horanotificou")]
    public string HoraNotificou { get; set; } = string.Empty;

    [JsonPropertyName("objetonotificou")]
    public int ObjetoNotificou { get; set; } = -2147483648;

    [JsonPropertyName("pessoacontato")]
    public string PessoaContato { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("horainicial")]
    public string HoraInicial { get; set; } = string.Empty;

    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("tipocontatocrm")]
    public int TipoContatoCRM { get; set; } = -2147483648;

    [JsonPropertyName("contato")]
    public string Contato { get; set; } = string.Empty;

    [JsonPropertyName("emocao")]
    public int Emocao { get; set; } = -2147483648;
}