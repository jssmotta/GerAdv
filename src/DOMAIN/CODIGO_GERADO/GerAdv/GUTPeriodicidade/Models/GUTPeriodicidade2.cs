﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GUTPeriodicidade
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pcgNome - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - pcgIntervaloDias  
    /// </summary>
    [JsonPropertyName("intervalodias")]
    public int IntervaloDias { get; set; }

    /// <summary>
    /// GUId - pcgGUID - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}