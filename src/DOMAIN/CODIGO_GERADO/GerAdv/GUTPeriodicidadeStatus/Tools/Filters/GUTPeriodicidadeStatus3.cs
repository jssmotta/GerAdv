﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterGUTPeriodicidadeStatus
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("gutatividade")]
    public int GUTAtividade { get; set; } = -2147483648;

    [JsonPropertyName("datarealizado")]
    public string DataRealizado { get; set; } = string.Empty;
}