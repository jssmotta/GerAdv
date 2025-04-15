#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterContratos
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("advogado")]
    public int Advogado { get; set; } = -2147483648;

    [JsonPropertyName("dia")]
    public int Dia { get; set; } = -2147483648;

    [JsonPropertyName("datainicio")]
    public string DataInicio { get; set; } = string.Empty;

    [JsonPropertyName("datatermino")]
    public string DataTermino { get; set; } = string.Empty;

    [JsonPropertyName("tipocobranca")]
    public int TipoCobranca { get; set; } = -2147483648;

    [JsonPropertyName("protestar")]
    public string Protestar { get; set; } = string.Empty;

    [JsonPropertyName("juros")]
    public string Juros { get; set; } = string.Empty;

    [JsonPropertyName("documento")]
    public string DOCUMENTO { get; set; } = string.Empty;

    [JsonPropertyName("email1")]
    public string EMail1 { get; set; } = string.Empty;

    [JsonPropertyName("email2")]
    public string EMail2 { get; set; } = string.Empty;

    [JsonPropertyName("email3")]
    public string EMail3 { get; set; } = string.Empty;

    [JsonPropertyName("pessoa1")]
    public string Pessoa1 { get; set; } = string.Empty;

    [JsonPropertyName("pessoa2")]
    public string Pessoa2 { get; set; } = string.Empty;

    [JsonPropertyName("pessoa3")]
    public string Pessoa3 { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string OBS { get; set; } = string.Empty;

    [JsonPropertyName("clientecontrato")]
    public int ClienteContrato { get; set; } = -2147483648;

    [JsonPropertyName("idextrangeiro")]
    public int IdExtrangeiro { get; set; } = -2147483648;

    [JsonPropertyName("chavecontrato")]
    public string ChaveContrato { get; set; } = string.Empty;

    [JsonPropertyName("multa")]
    public string Multa { get; set; } = string.Empty;
}