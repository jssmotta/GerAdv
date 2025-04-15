#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterOperador
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("pasta")]
    public string Pasta { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("nick")]
    public string Nick { get; set; } = string.Empty;

    [JsonPropertyName("ramal")]
    public string Ramal { get; set; } = string.Empty;

    [JsonPropertyName("cadid")]
    public int CadID { get; set; } = -2147483648;

    [JsonPropertyName("cadcod")]
    public int CadCod { get; set; } = -2147483648;

    [JsonPropertyName("computador")]
    public int Computador { get; set; } = -2147483648;

    [JsonPropertyName("minhadescricao")]
    public string MinhaDescricao { get; set; } = string.Empty;

    [JsonPropertyName("ultimologoff")]
    public string UltimoLogoff { get; set; } = string.Empty;

    [JsonPropertyName("emailnet")]
    public string EMailNet { get; set; } = string.Empty;

    [JsonPropertyName("onlineip")]
    public string OnlineIP { get; set; } = string.Empty;

    [JsonPropertyName("statusid")]
    public int StatusId { get; set; } = -2147483648;

    [JsonPropertyName("statusmessage")]
    public string StatusMessage { get; set; } = string.Empty;

    [JsonPropertyName("senha256")]
    public string Senha256 { get; set; } = string.Empty;

    [JsonPropertyName("datalimitereset")]
    public string DataLimiteReset { get; set; } = string.Empty;

    [JsonPropertyName("suportesenha256")]
    public string SuporteSenha256 { get; set; } = string.Empty;

    [JsonPropertyName("suportemaxage")]
    public string SuporteMaxAge { get; set; } = string.Empty;

    [JsonPropertyName("suportenomesolicitante")]
    public string SuporteNomeSolicitante { get; set; } = string.Empty;

    [JsonPropertyName("suporteultimoacesso")]
    public string SuporteUltimoAcesso { get; set; } = string.Empty;

    [JsonPropertyName("suporteipultimoacesso")]
    public string SuporteIpUltimoAcesso { get; set; } = string.Empty;
}