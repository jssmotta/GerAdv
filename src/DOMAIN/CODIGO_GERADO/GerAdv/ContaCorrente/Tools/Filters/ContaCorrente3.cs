#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterContaCorrente
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("ciacordo")]
    public int CIAcordo { get; set; } = -2147483648;

    [JsonPropertyName("idcontrato")]
    public int IDContrato { get; set; } = -2147483648;

    [JsonPropertyName("quitadoid")]
    public int QuitadoID { get; set; } = -2147483648;

    [JsonPropertyName("debitoid")]
    public int DebitoID { get; set; } = -2147483648;

    [JsonPropertyName("livrocaixaid")]
    public int LivroCaixaID { get; set; } = -2147483648;

    [JsonPropertyName("dtoriginal")]
    public string DtOriginal { get; set; } = string.Empty;

    [JsonPropertyName("processo")]
    public int Processo { get; set; } = -2147483648;

    [JsonPropertyName("parcelax")]
    public int ParcelaX { get; set; } = -2147483648;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("historico")]
    public string Historico { get; set; } = string.Empty;

    [JsonPropertyName("idhtrab")]
    public int IDHTrab { get; set; } = -2147483648;

    [JsonPropertyName("nroparcelas")]
    public int NroParcelas { get; set; } = -2147483648;

    [JsonPropertyName("parcelaprincipalid")]
    public int ParcelaPrincipalID { get; set; } = -2147483648;

    [JsonPropertyName("datapgto")]
    public string DataPgto { get; set; } = string.Empty;
}