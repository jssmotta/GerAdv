#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAgenda
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("idcob")]
    public int IDCOB { get; set; } = -2147483648;

    [JsonPropertyName("idne")]
    public int IDNE { get; set; } = -2147483648;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("oculto")]
    public int Oculto { get; set; } = -2147483648;

    [JsonPropertyName("cartaprecatoria")]
    public int CartaPrecatoria { get; set; } = -2147483648;

    [JsonPropertyName("hrfinal")]
    public string HrFinal { get; set; } = string.Empty;

    [JsonPropertyName("advogado")]
    public int Advogado { get; set; } = -2147483648;

    [JsonPropertyName("eventogerador")]
    public int EventoGerador { get; set; } = -2147483648;

    [JsonPropertyName("eventodata")]
    public string EventoData { get; set; } = string.Empty;

    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("eventoprazo")]
    public int EventoPrazo { get; set; } = -2147483648;

    [JsonPropertyName("hora")]
    public string Hora { get; set; } = string.Empty;

    [JsonPropertyName("compromisso")]
    public string Compromisso { get; set; } = string.Empty;

    [JsonPropertyName("tipocompromisso")]
    public int TipoCompromisso { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("area")]
    public int Area { get; set; } = -2147483648;

    [JsonPropertyName("justica")]
    public int Justica { get; set; } = -2147483648;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("idhistorico")]
    public int IDHistorico { get; set; } = -2147483648;

    [JsonPropertyName("idinsprocesso")]
    public int IDInsProcesso { get; set; } = -2147483648;

    [JsonPropertyName("usuario")]
    public int Usuario { get; set; } = -2147483648;

    [JsonPropertyName("preposto")]
    public int Preposto { get; set; } = -2147483648;

    [JsonPropertyName("quemid")]
    public int QuemID { get; set; } = -2147483648;

    [JsonPropertyName("quemcodigo")]
    public int QuemCodigo { get; set; } = -2147483648;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("decisao")]
    public string Decisao { get; set; } = string.Empty;

    [JsonPropertyName("sempre")]
    public int Sempre { get; set; } = -2147483648;

    [JsonPropertyName("prazodias")]
    public int PrazoDias { get; set; } = -2147483648;

    [JsonPropertyName("protocolointegrado")]
    public int ProtocoloIntegrado { get; set; } = -2147483648;

    [JsonPropertyName("datainicioprazo")]
    public string DataInicioPrazo { get; set; } = string.Empty;
}