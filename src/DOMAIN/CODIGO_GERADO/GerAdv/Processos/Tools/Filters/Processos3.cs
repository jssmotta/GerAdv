#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterProcessos
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("advparc")]
    public int AdvParc { get; set; } = -2147483648;

    [JsonPropertyName("dataentrada")]
    public string DataEntrada { get; set; } = string.Empty;

    [JsonPropertyName("tipobaixa")]
    public int TipoBaixa { get; set; } = -2147483648;

    [JsonPropertyName("classrisco")]
    public int ClassRisco { get; set; } = -2147483648;

    [JsonPropertyName("obsbcx")]
    public string ObsBCX { get; set; } = string.Empty;

    [JsonPropertyName("nroextra")]
    public string NroExtra { get; set; } = string.Empty;

    [JsonPropertyName("advopo")]
    public int AdvOpo { get; set; } = -2147483648;

    [JsonPropertyName("justica")]
    public int Justica { get; set; } = -2147483648;

    [JsonPropertyName("advogado")]
    public int Advogado { get; set; } = -2147483648;

    [JsonPropertyName("nrocaixa")]
    public string NroCaixa { get; set; } = string.Empty;

    [JsonPropertyName("preposto")]
    public int Preposto { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("oponente")]
    public int Oponente { get; set; } = -2147483648;

    [JsonPropertyName("area")]
    public int Area { get; set; } = -2147483648;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("situacao")]
    public int Situacao { get; set; } = -2147483648;

    [JsonPropertyName("rito")]
    public int Rito { get; set; } = -2147483648;

    [JsonPropertyName("fato")]
    public string Fato { get; set; } = string.Empty;

    [JsonPropertyName("nropasta")]
    public string NroPasta { get; set; } = string.Empty;

    [JsonPropertyName("atividade")]
    public int Atividade { get; set; } = -2147483648;

    [JsonPropertyName("caixamorto")]
    public string CaixaMorto { get; set; } = string.Empty;

    [JsonPropertyName("dtbaixa")]
    public string DtBaixa { get; set; } = string.Empty;

    [JsonPropertyName("motivobaixa")]
    public string MotivoBaixa { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string OBS { get; set; } = string.Empty;

    [JsonPropertyName("zkey")]
    public string ZKey { get; set; } = string.Empty;

    [JsonPropertyName("zkeyquem")]
    public int ZKeyQuem { get; set; } = -2147483648;

    [JsonPropertyName("zkeyquando")]
    public string ZKeyQuando { get; set; } = string.Empty;

    [JsonPropertyName("resumo")]
    public string Resumo { get; set; } = string.Empty;

    [JsonPropertyName("nrocontrato")]
    public string NroContrato { get; set; } = string.Empty;

    [JsonPropertyName("percprobexitojustificativa")]
    public string PercProbExitoJustificativa { get; set; } = string.Empty;

    [JsonPropertyName("faseauditoria")]
    public int FaseAuditoria { get; set; } = -2147483648;

    [JsonPropertyName("valorcondenacaoprovisorio")]
    public int ValorCondenacaoProvisorio { get; set; } = -2147483648;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}