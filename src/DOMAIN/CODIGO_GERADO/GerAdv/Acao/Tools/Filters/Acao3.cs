﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterAcao
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("justica")]
    public int Justica { get; set; } = -2147483648;

    [JsonPropertyName("area")]
    public int Area { get; set; } = -2147483648;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}