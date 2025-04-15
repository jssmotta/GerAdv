#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterRecados
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("clientenome")]
    public string ClienteNome { get; set; } = string.Empty;

    [JsonPropertyName("de")]
    public string De { get; set; } = string.Empty;

    [JsonPropertyName("para")]
    public string Para { get; set; } = string.Empty;

    [JsonPropertyName("assunto")]
    public string Assunto { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("recado")]
    public string Recado { get; set; } = string.Empty;

    [JsonPropertyName("hora")]
    public string Hora { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("retornodata")]
    public string RetornoData { get; set; } = string.Empty;

    [JsonPropertyName("emotion")]
    public int Emotion { get; set; } = -2147483648;

    [JsonPropertyName("internetid")]
    public int InternetID { get; set; } = -2147483648;

    [JsonPropertyName("natureza")]
    public int Natureza { get; set; } = -2147483648;

    [JsonPropertyName("aguardarretornopara")]
    public string AguardarRetornoPara { get; set; } = string.Empty;

    [JsonPropertyName("paraid")]
    public int ParaID { get; set; } = -2147483648;

    [JsonPropertyName("masterid")]
    public int MasterID { get; set; } = -2147483648;

    [JsonPropertyName("listapara")]
    public string ListaPara { get; set; } = string.Empty;

    [JsonPropertyName("assuntorecado")]
    public int AssuntoRecado { get; set; } = -2147483648;

    [JsonPropertyName("historico")]
    public int Historico { get; set; } = -2147483648;

    [JsonPropertyName("contatocrm")]
    public int ContatoCRM { get; set; } = -2147483648;

    [JsonPropertyName("ligacoes")]
    public int Ligacoes { get; set; } = -2147483648;

    [JsonPropertyName("agenda")]
    public int Agenda { get; set; } = -2147483648;
}