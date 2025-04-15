#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterOperadorEMailPopup
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("operador")]
    public int Operador { get; set; } = -2147483648;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("senha")]
    public string Senha { get; set; } = string.Empty;

    [JsonPropertyName("smtp")]
    public string SMTP { get; set; } = string.Empty;

    [JsonPropertyName("pop3")]
    public string POP3 { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [JsonPropertyName("usuario")]
    public string Usuario { get; set; } = string.Empty;

    [JsonPropertyName("portasmtp")]
    public int PortaSmtp { get; set; } = -2147483648;

    [JsonPropertyName("portapop3")]
    public int PortaPop3 { get; set; } = -2147483648;

    [JsonPropertyName("assinatura")]
    public string Assinatura { get; set; } = string.Empty;

    [JsonPropertyName("senha256")]
    public string Senha256 { get; set; } = string.Empty;
}