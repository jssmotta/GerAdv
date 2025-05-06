#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterLigacoes
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("assunto")]
    public string Assunto { get; set; } = string.Empty;

    [JsonPropertyName("ageclienteavisado")]
    public int AgeClienteAvisado { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("contato")]
    public string Contato { get; set; } = string.Empty;

    [JsonPropertyName("datarealizada")]
    public string DataRealizada { get; set; } = string.Empty;

    [JsonPropertyName("quemid")]
    public int QuemID { get; set; } = -2147483648;

    [JsonPropertyName("telefonista")]
    public int Telefonista { get; set; } = -2147483648;

    [JsonPropertyName("ultimoaviso")]
    public string UltimoAviso { get; set; } = string.Empty;

    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("quemcodigo")]
    public int QuemCodigo { get; set; } = -2147483648;

    [JsonPropertyName("solicitante")]
    public int Solicitante { get; set; } = -2147483648;

    [JsonPropertyName("para")]
    public string Para { get; set; } = string.Empty;

    [JsonPropertyName("fone")]
    public string Fone { get; set; } = string.Empty;

    [JsonPropertyName("ramal")]
    public int Ramal { get; set; } = -2147483648;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("hora")]
    public string Hora { get; set; } = string.Empty;

    [JsonPropertyName("ligarpara")]
    public string LigarPara { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("emotion")]
    public int Emotion { get; set; } = -2147483648;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}