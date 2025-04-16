#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAgendaRepetir
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("advogado")]
    public int Advogado { get; set; } = -2147483648;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("datafinal")]
    public string DataFinal { get; set; } = string.Empty;

    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; } = -2147483648;

    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("frequencia")]
    public int Frequencia { get; set; } = -2147483648;

    [JsonPropertyName("dia")]
    public int Dia { get; set; } = -2147483648;

    [JsonPropertyName("mes")]
    public int Mes { get; set; } = -2147483648;

    [JsonPropertyName("hora")]
    public string Hora { get; set; } = string.Empty;

    [JsonPropertyName("idquem")]
    public int IDQuem { get; set; } = -2147483648;

    [JsonPropertyName("idquem2")]
    public int IDQuem2 { get; set; } = -2147483648;

    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; } = string.Empty;

    [JsonPropertyName("idtipo")]
    public int IDTipo { get; set; } = -2147483648;

    [JsonPropertyName("id1")]
    public int ID1 { get; set; } = -2147483648;

    [JsonPropertyName("id2")]
    public int ID2 { get; set; } = -2147483648;

    [JsonPropertyName("id3")]
    public int ID3 { get; set; } = -2147483648;

    [JsonPropertyName("id4")]
    public int ID4 { get; set; } = -2147483648;
}