﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Setor
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - setDescricao - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// GUId - setGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}