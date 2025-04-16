#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterModelosDocumentos
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("remuneracao")]
    public string Remuneracao { get; set; } = string.Empty;

    [JsonPropertyName("assinatura")]
    public string Assinatura { get; set; } = string.Empty;

    [JsonPropertyName("header")]
    public string Header { get; set; } = string.Empty;

    [JsonPropertyName("footer")]
    public string Footer { get; set; } = string.Empty;

    [JsonPropertyName("extra1")]
    public string Extra1 { get; set; } = string.Empty;

    [JsonPropertyName("extra2")]
    public string Extra2 { get; set; } = string.Empty;

    [JsonPropertyName("extra3")]
    public string Extra3 { get; set; } = string.Empty;

    [JsonPropertyName("outorgante")]
    public string Outorgante { get; set; } = string.Empty;

    [JsonPropertyName("outorgados")]
    public string Outorgados { get; set; } = string.Empty;

    [JsonPropertyName("poderes")]
    public string Poderes { get; set; } = string.Empty;

    [JsonPropertyName("objeto")]
    public string Objeto { get; set; } = string.Empty;

    [JsonPropertyName("titulo")]
    public string Titulo { get; set; } = string.Empty;

    [JsonPropertyName("testemunhas")]
    public string Testemunhas { get; set; } = string.Empty;

    [JsonPropertyName("tipomodelodocumento")]
    public int TipoModeloDocumento { get; set; } = -2147483648;

    [JsonPropertyName("css")]
    public string CSS { get; set; } = string.Empty;
}