﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GUTTipoResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - gttNome - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - gttOrdem  
    /// </summary>
    [JsonPropertyName("ordem")]
    public int Ordem { get; set; }

    /// <summary>
    /// GUId - gttGUID - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}