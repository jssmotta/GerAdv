#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterInstancia
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("liminarpedida")]
    public string LiminarPedida { get; set; } = string.Empty;

    [JsonPropertyName("objeto")]
    public string Objeto { get; set; } = string.Empty;

    [JsonPropertyName("statusresultado")]
    public int StatusResultado { get; set; } = -2147483648;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("liminarresultado")]
    public string LiminarResultado { get; set; } = string.Empty;

    [JsonPropertyName("nroprocesso")]
    public string NroProcesso { get; set; } = string.Empty;

    [JsonPropertyName("divisao")]
    public int Divisao { get; set; } = -2147483648;

    [JsonPropertyName("comarca")]
    public int Comarca { get; set; } = -2147483648;

    [JsonPropertyName("subdivisao")]
    public int SubDivisao { get; set; } = -2147483648;

    [JsonPropertyName("acao")]
    public int Acao { get; set; } = -2147483648;

    [JsonPropertyName("foro")]
    public int Foro { get; set; } = -2147483648;

    [JsonPropertyName("tiporecurso")]
    public int TipoRecurso { get; set; } = -2147483648;

    [JsonPropertyName("zkey")]
    public string ZKey { get; set; } = string.Empty;

    [JsonPropertyName("zkeyquem")]
    public int ZKeyQuem { get; set; } = -2147483648;

    [JsonPropertyName("zkeyquando")]
    public string ZKeyQuando { get; set; } = string.Empty;

    [JsonPropertyName("nroantigo")]
    public string NroAntigo { get; set; } = string.Empty;

    [JsonPropertyName("accesscode")]
    public string AccessCode { get; set; } = string.Empty;

    [JsonPropertyName("julgador")]
    public int Julgador { get; set; } = -2147483648;

    [JsonPropertyName("zkeyia")]
    public string ZKeyIA { get; set; } = string.Empty;
}