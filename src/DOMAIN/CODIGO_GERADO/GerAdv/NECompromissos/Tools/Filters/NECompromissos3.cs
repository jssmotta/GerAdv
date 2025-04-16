#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterNECompromissos
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("palavrachave")]
    public int PalavraChave { get; set; } = -2147483648;

    [JsonPropertyName("tipocompromisso")]
    public int TipoCompromisso { get; set; } = -2147483648;

    [JsonPropertyName("textocompromisso")]
    public string TextoCompromisso { get; set; } = string.Empty;
}